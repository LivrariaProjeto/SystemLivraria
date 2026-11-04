using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SystemLivraria.forms.Relatorios
{
    public enum TipoRelatorioComplementar
    {
        MovimentoEstoque,
        EntradaFinanceira,
        SaidaFinanceira,
        FluxoFinanceiro
    }

    public sealed class frmRelatoriosComplementares : Form
    {
        private readonly ReportViewer viewer;
        private readonly DateTimePicker inicio;
        private readonly DateTimePicker fim;

        public TipoRelatorioComplementar Tipo { get; private set; }

        public frmRelatoriosComplementares(TipoRelatorioComplementar tipo)
        {
            Tipo = tipo;

            Text = tipo == TipoRelatorioComplementar.MovimentoEstoque
                ? "Movimentação comercial do estoque"
                : tipo == TipoRelatorioComplementar.EntradaFinanceira
                ? "Entradas financeiras realizadas"
                : tipo == TipoRelatorioComplementar.SaidaFinanceira
                ? "Saídas financeiras realizadas"
                : "Fluxo de caixa realizado";

            ClientSize = new Size(1000, 600);

            inicio = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 115,
                Value = new DateTime(
                    DateTime.Today.Year,
                    DateTime.Today.Month,
                    1)
            };

            fim = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 115,
                MaxDate = new DateTime(9998, 12, 31),
                Value = DateTime.Today
            };

            var gerar = new Button
            {
                Text = "Gerar relatório",
                AutoSize = true
            };

            gerar.Click += delegate { GerarRelatorio(); };

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(6)
            };

            filtros.Controls.Add(
                new Label { Text = "De", AutoSize = true });

            filtros.Controls.Add(inicio);

            filtros.Controls.Add(
                new Label { Text = "até", AutoSize = true });

            filtros.Controls.Add(fim);
            filtros.Controls.Add(gerar);

            viewer = new ReportViewer
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(viewer);
            Controls.Add(filtros);

            Load += delegate { GerarRelatorio(); };
        }

        private void GerarRelatorio()
        {
            if (inicio.Value.Date > fim.Value.Date)
            {
                MessageBox.Show(
                    "A data inicial não pode ser posterior à final.");

                return;
            }

            try
            {
                UseWaitCursor = true;
                viewer.Reset();

                DataTable dados = MotorRelatoriosComplementares.Consultar(
                    Tipo,
                    inicio.Value.Date,
                    fim.Value.Date.AddDays(1));

                bool movimento =
                    Tipo == TipoRelatorioComplementar.MovimentoEstoque;

                string periodo = string.Format(
                    "Período: {0:dd/MM/yyyy} a {1:dd/MM/yyyy}. ",
                    inicio.Value.Date,
                    fim.Value.Date);

                periodo += movimento
                    ? "Compras e vendas; não inclui ajustes manuais."
                    : "Pagamentos e recebimentos; não inclui contas pendentes.";

                string rdlc = MotorRelatoriosComplementares.CriarRdlc(
                dados, movimento, Text, periodo);

                rdlc = EstiloRelatorios.Aplicar(rdlc, Text);

                viewer.ProcessingMode = ProcessingMode.Local;

                using (var leitor = new StringReader(rdlc))
                {
                    viewer.LocalReport.LoadReportDefinition(leitor);
                }

                viewer.LocalReport.DataSources.Clear();

                viewer.LocalReport.DataSources.Add(
                    new ReportDataSource(
                        "DadosRelatorio",
                        (object)dados));

                viewer.ZoomMode = ZoomMode.PageWidth;
                viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    ex.GetBaseException().Message,
                    "Erro no relatório",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }
    }

    internal static class MotorRelatoriosComplementares
    {
        // Compras representam entradas; vendas representam saídas.
        private const string SqlEstoque = @"
SELECT M.Data, M.Tipo, M.Documento, M.Descricao,
       M.Complemento, M.Entrada, M.Saida
FROM (
    SELECT C.Data_CMP AS Data,
           'Entrada' AS Tipo,
           'Compra ' + CONVERT(varchar(12), C.Id_CMP) AS Documento,
           P.Nome_Pro AS Descricao,
           F.Nome_Forne AS Complemento,
           I.QTD_Item AS Entrada,
           CONVERT(int, 0) AS Saida,
           I.Id_Item AS Ordem
    FROM dbo.Itens_CMP I
    JOIN dbo.Compras C ON C.Id_CMP = I.Id_CMP
    JOIN dbo.Produtos P ON P.Id_Pro = I.Id_Pro
    JOIN dbo.Fornecedores F ON F.Id_Forne = C.Id_Forne

    UNION ALL

    SELECT V.Data_VDS,
           'Saída',
           'Venda ' + CONVERT(varchar(12), V.Id_VDS),
           P.Nome_Pro,
           C.Nome_Cli,
           CONVERT(int, 0),
           I.QTD_Item,
           I.Id_Item_VDS
    FROM dbo.Itens_Vendas I
    JOIN dbo.Vendas V ON V.Id_VDS = I.Id_VDS
    JOIN dbo.Produtos P ON P.Id_Pro = I.Id_Pro
    JOIN dbo.Cliente C ON C.Id_Cli = V.Id_Cli
) M
WHERE M.Data >= @Inicio AND M.Data < @Fim
ORDER BY M.Data, M.Documento, M.Ordem";

        // Usa o valor efetivamente pago/recebido, inclusive pagamentos parciais.
        private const string SqlFinanceiro = @"
WITH Movimentos AS (
    SELECT M.Id_Mov,
           M.Data_Mov AS Data,
           CASE
               WHEN UPPER(LTRIM(RTRIM(F.Tipo_VDS)))
                    IN ('RECEITA', 'ENTRADA') THEN 'Entrada'
               WHEN UPPER(LTRIM(RTRIM(F.Tipo_VDS)))
                    IN ('DESPESA', 'SAIDA', 'SAÍDA') THEN 'Saída'
               ELSE 'Tipo inválido'
           END AS Tipo,
           'Conta ' + CONVERT(varchar(12), M.Id_Fin) AS Documento,
           F.Desc_VDS AS Descricao,
           COALESCE(
               F.Categoria_Fin,
               CASE
                   WHEN F.Id_VDS IS NOT NULL THEN 'Venda'
                   WHEN F.Id_CMP IS NOT NULL THEN 'Compra'
                   ELSE 'Outros'
               END
           ) AS Complemento,
           M.Valor_Mov
    FROM dbo.Movimentacoes_Financeiro M
    JOIN dbo.Financeiro F ON F.Id_Fin = M.Id_Fin
    WHERE M.Data_Mov >= @Inicio AND M.Data_Mov < @Fim
)
SELECT Data,
       Tipo,
       Documento,
       Descricao,
       Complemento,
       CONVERT(decimal(19,2),
           CASE WHEN Tipo = 'Entrada'
                THEN Valor_Mov ELSE 0 END) AS Entrada,
       CONVERT(decimal(19,2),
           CASE WHEN Tipo = 'Saída'
                THEN Valor_Mov ELSE 0 END) AS Saida
FROM Movimentos
ORDER BY Data, Id_Mov";

        internal static DataTable Consultar(
            TipoRelatorioComplementar tipo,
            DateTime inicio,
            DateTime fim)
        {
            if (!Enum.IsDefined(typeof(TipoRelatorioComplementar), tipo))
            {
                throw new ArgumentOutOfRangeException(nameof(tipo));
            }

            if (inicio >= fim)
            {
                throw new ArgumentException("Período inválido.");
            }

            var config = ConfigurationManager.ConnectionStrings[
                "SystemLivraria.Properties.Settings.db_250064ConnectionString"];

            if (config == null ||
                string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "A conexão com o banco não foi configurada no App.config.");
            }

            bool movimento =
                tipo == TipoRelatorioComplementar.MovimentoEstoque;

            var dados = new DataTable();

            using (var conexao = new SqlConnection(config.ConnectionString))
            using (var comando = new SqlCommand(
                movimento ? SqlEstoque : SqlFinanceiro, conexao))
            using (var adaptador = new SqlDataAdapter(comando))
            {
                comando.Parameters.Add(
                    "@Inicio", SqlDbType.DateTime2).Value = inicio;

                comando.Parameters.Add(
                    "@Fim", SqlDbType.DateTime2).Value = fim;

                adaptador.Fill(dados);
            }

            return movimento
                ? dados
                : FiltrarFinanceiro(dados, tipo);
        }

        internal static DataTable FiltrarFinanceiro(
            DataTable dados,
            TipoRelatorioComplementar tipo)
        {
            foreach (DataRow linha in dados.Rows)
            {
                if ((string)linha["Tipo"] != "Entrada" &&
                    (string)linha["Tipo"] != "Saída")
                {
                    throw new InvalidOperationException(
                        "Há movimentação com tipo financeiro desconhecido. " +
                        "Confira Financeiro.Tipo_VDS: " +
                        "RECEITA/ENTRADA ou DESPESA/SAIDA.");
                }
            }

            if (tipo == TipoRelatorioComplementar.FluxoFinanceiro)
            {
                return dados;
            }

            using (var filtro = new DataView(dados))
            {
                filtro.RowFilter =
                    tipo == TipoRelatorioComplementar.EntradaFinanceira
                    ? "Tipo = 'Entrada'"
                    : "Tipo = 'Saída'";

                return filtro.ToTable();
            }
        }

        // A partir daqui é montado o layout RDLC.
        // Não é necessário criar arquivos .rdlc separados.
        private static readonly XNamespace R =
            "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition";

        private static readonly XNamespace RD =
            "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner";

        private static XElement X(string nome, params object[] conteudo)
        {
            return new XElement(R + nome, conteudo);
        }

        private static XElement Texto(
            string nome,
            string valor,
            bool destaque,
            string formato = null,
            string alinhamento = "Left")
        {
            return X(
                "Textbox",
                new XAttribute("Name", nome),
                X("CanGrow", "true"),
                X("KeepTogether", "true"),
                X(
                    "Paragraphs",
                    X(
                        "Paragraph",
                        X(
                            "TextRuns",
                            X(
                                "TextRun",
                                X("Value", valor),
                                X(
                                    "Style",
                                    X("FontFamily", "Arial"),
                                    X("FontSize", "9pt"),
                                    destaque
                                        ? X("FontWeight", "Bold")
                                        : null,
                                    formato == null
                                        ? null
                                        : X("Format", formato)))),
                        X("Style", X("TextAlign", alinhamento)))),
                X(
                    "Style",
                    X(
                        "Border",
                        X("Color", "LightGrey"),
                        X("Style", "Solid")),
                    destaque
                        ? X("BackgroundColor", "#E5E7EB")
                        : null,
                    X("PaddingLeft", "3pt"),
                    X("PaddingRight", "3pt"),
                    X("PaddingTop", "3pt"),
                    X("PaddingBottom", "3pt")));
        }

        private static XElement Posicionar(
            XElement texto,
            string topo,
            string altura)
        {
            texto.Add(
                X("Top", topo),
                X("Left", "0cm"),
                X("Height", altura),
                X("Width", "27cm"));

            return texto;
        }

        internal static string CriarRdlc(
            DataTable dados,
            bool movimento,
            string titulo,
            string periodo)
        {
            string[] campos =
            {
                "Data", "Tipo", "Documento", "Descricao",
                "Complemento", "Entrada", "Saida"
            };

            string[] cabecalhos =
            {
                "Data",
                "Tipo",
                "Documento",
                movimento ? "Produto" : "Descrição",
                movimento ? "Cliente / fornecedor" : "Categoria",
                "Entradas",
                "Saídas"
            };

            string[] larguras =
            {
                "2.8cm", "1.7cm", "2.8cm", "8cm",
                "4.9cm", "3.4cm", "3.4cm"
            };

            string formato = movimento ? "N0" : "C2";

            var camposXml = X("Fields");
            var colunas = X("TablixColumns");
            var membrosColunas = X("TablixMembers");

            foreach (string campo in campos)
            {
                camposXml.Add(
                    X(
                        "Field",
                        new XAttribute("Name", campo),
                        X("DataField", campo),
                        new XElement(
                            RD + "TypeName",
                            dados.Columns[campo].DataType.FullName)));
            }

            foreach (string largura in larguras)
            {
                colunas.Add(
                    X("TablixColumn", X("Width", largura)));

                membrosColunas.Add(X("TablixMember"));
            }

            var linhas = X("TablixRows");

            // Linha 0: cabeçalho.
            // Linha 1: registros.
            // Linha 2: totais.
            for (int linha = 0; linha < 3; linha++)
            {
                var celulas = X("TablixCells");

                for (int coluna = 0; coluna < campos.Length; coluna++)
                {
                    bool numero = coluna >= 5;

                    string valor =
                        linha == 0 ? cabecalhos[coluna]
                        : linha == 1
                            ? "=Fields!" + campos[coluna] + ".Value"
                        : coluna == 3 ? "Totais selecionados"
                        : numero
                            ? "=IIF(CountRows(\"DadosRelatorio\")=0, 0, " +
                              "Sum(Fields!" + campos[coluna] +
                              ".Value, \"DadosRelatorio\"))"
                            : "";

                    string mascara =
                        linha == 0 ? null
                        : numero ? formato
                        : coluna == 0
                            ? (movimento
                                ? "dd/MM/yyyy"
                                : "dd/MM/yyyy HH:mm")
                            : null;

                    celulas.Add(
                        X(
                            "TablixCell",
                            X(
                                "CellContents",
                                Texto(
                                    "Celula" + linha + "_" + coluna,
                                    valor,
                                    linha != 1,
                                    mascara,
                                    numero ? "Right" : "Left"))));
                }

                linhas.Add(
                    X("TablixRow", X("Height", "0.8cm"), celulas));
            }

            string resultado =
                "=\"Entradas menos saídas" +
                (movimento ? " (unidades)" : "") +
                ": \" & Format(" +
                "IIF(CountRows(\"DadosRelatorio\")=0, 0, " +
                "Sum(Fields!Entrada.Value, \"DadosRelatorio\") - " +
                "Sum(Fields!Saida.Value, \"DadosRelatorio\")), " +
                "\"" + formato + "\")";

            var itens = X(
                "ReportItems",

                Posicionar(
                    Texto("Titulo", titulo, true),
                    "0cm", "0.8cm"),

                Posicionar(
                    Texto("Periodo", periodo, false),
                    "0.9cm", "0.9cm"),

                X(
                    "Tablix",
                    new XAttribute("Name", "Tabela"),

                    X("TablixBody", colunas, linhas),

                    X("TablixColumnHierarchy", membrosColunas),

                    X(
                        "TablixRowHierarchy",
                        X(
                            "TablixMembers",
                            X(
                                "TablixMember",
                                X("KeepWithGroup", "After"),
                                X("RepeatOnNewPage", "true")),
                            X(
                                "TablixMember",
                                X(
                                    "Group",
                                    new XAttribute("Name", "Detalhes"))),
                            X(
                                "TablixMember",
                                X("KeepWithGroup", "Before")))),

                    X("DataSetName", "DadosRelatorio"),

                    X(
                        "NoRowsMessage",
                        "Nenhum registro para o período selecionado."),

                    X("Top", "2cm"),
                    X("Left", "0cm"),
                    X("Height", "2.4cm"),
                    X("Width", "27cm"),
                    X("Style")),

                Posicionar(
                    Texto("Resultado", resultado, true),
                    "4.6cm", "0.8cm"));

            var pagina = X(
                "Page",
                X("PageHeight", "21cm"),
                X("PageWidth", "29.7cm"),
                X("LeftMargin", "1cm"),
                X("RightMargin", "1cm"),
                X("TopMargin", "1cm"),
                X("BottomMargin", "1cm"),

                X(
                    "PageFooter",
                    X("Height", "0.8cm"),
                    X("PrintOnFirstPage", "true"),
                    X("PrintOnLastPage", "true"),
                    X(
                        "ReportItems",
                        Posicionar(
                            Texto(
                                "Rodape",
                                "=\"Página \" & Globals!PageNumber & " +
                                "\" de \" & Globals!TotalPages",
                                false),
                            "0cm",
                            "0.7cm"))),

                X("Style"));

            return new XDocument(
                X(
                    "Report",
                    new XAttribute(
                        XNamespace.Xmlns + "rd",
                        RD.NamespaceName),

                    X(
                        "DataSources",
                        X(
                            "DataSource",
                            new XAttribute("Name", "Aplicacao"),
                            X(
                                "ConnectionProperties",
                                X("DataProvider", "System.Data.DataSet"),
                                X(
                                    "ConnectString",
                                    "/* Dados fornecidos pelo aplicativo */")))),

                    X(
                        "DataSets",
                        X(
                            "DataSet",
                            new XAttribute("Name", "DadosRelatorio"),
                            camposXml,
                            X(
                                "Query",
                                X("DataSourceName", "Aplicacao"),
                                X("CommandText", "/* Dados locais */")))),

                    X("Body", itens, X("Height", "5.5cm"), X("Style")),
                    X("Width", "27cm"),
                    pagina,
                    X("Language", "pt-BR"),
                    X("ConsumeContainerWhitespace", "true")
                )
            ).ToString();
        }
    }
}