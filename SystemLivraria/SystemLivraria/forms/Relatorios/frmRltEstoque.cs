using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SystemLivraria.forms.Relatorios
{
    public partial class frmRltEstoque : Form
    {
        public frmRltEstoque()
        {
            InitializeComponent();

            Text = "Estoque atual";

            Load -= frmRltEstoque_Load;
            Load += frmRltEstoque_Load;

            reportViewer1.ReportRefresh -= reportViewer1_ReportRefresh;
            reportViewer1.ReportRefresh += reportViewer1_ReportRefresh;
        }

        private void frmRltEstoque_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                CarregarEstoque();
        }

        // O botão Atualizar do ReportViewer consulta o banco novamente.
        private void reportViewer1_ReportRefresh(
            object sender,
            CancelEventArgs e)
        {
            e.Cancel = true;
            CarregarEstoque();
        }

        private void CarregarEstoque()
        {
            try
            {
                UseWaitCursor = true;

                reportViewer1.Reset();

                DataTable dados = GeradorEstoqueAtual.Consultar();

                string rdlc = GeradorEstoqueAtual.CriarRdlc(
                    dados,
                    DateTime.Now);

                rdlc = EstiloRelatorios.Aplicar(rdlc, Text);

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                using (var leitor = new StringReader(rdlc))
                {
                    reportViewer1.LocalReport.LoadReportDefinition(leitor);
                }

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource(
                        "DataEstoque",
                        (object)dados));

                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    ex.GetBaseException().Message,
                    "Erro no estoque",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        // Mantido porque o Designer original referencia este evento.
        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }
    }

    // Esta classe consulta o estoque e monta o RDLC automaticamente.
    internal static class GeradorEstoqueAtual
    {
        private const string SqlEstoque = @"
SELECT P.Id_Pro AS Codigo,
       P.Nome_Pro AS Produto,
       SUM(CONVERT(bigint, COALESCE(E.QTD_Est, 0))) AS Quantidade,
       MAX(COALESCE(E.Est_Min, 0)) AS Minimo,
       MAX(COALESCE(E.Est_Max, 0)) AS Maximo
FROM dbo.Produtos P
LEFT JOIN dbo.Estoque E ON E.Id_Pro = P.Id_Pro
GROUP BY P.Id_Pro, P.Nome_Pro
ORDER BY P.Nome_Pro, P.Id_Pro";

        internal static DataTable Consultar()
        {
            var config = ConfigurationManager.ConnectionStrings[
                "SystemLivraria.Properties.Settings.db_250064ConnectionString"];

            if (config == null ||
                string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "Configure a conexão no App.config.");
            }

            using (var conexao = new SqlConnection(config.ConnectionString))
            using (var comando = new SqlCommand(SqlEstoque, conexao))
            using (var adaptador = new SqlDataAdapter(comando))
            {
                var dados = new DataTable();
                adaptador.Fill(dados);

                return dados;
            }
        }

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
            bool direita = false)
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
                                    X("FontSize", "10pt"),
                                    destaque
                                        ? X("FontWeight", "Bold")
                                        : null,
                                    formato == null
                                        ? null
                                        : X("Format", formato)))),
                        X(
                            "Style",
                            X("TextAlign", direita ? "Right" : "Left")))),

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
                X("Width", "18cm"));

            return texto;
        }

        internal static string CriarRdlc(
            DataTable dados,
            DateTime consultadoEm)
        {
            string[] campos =
            {
                "Codigo", "Produto", "Quantidade", "Minimo", "Maximo"
            };

            string[] titulos =
            {
                "Código", "Produto", "Quantidade", "Mínimo", "Máximo"
            };

            string[] larguras =
            {
                "1.5cm", "8.5cm", "3cm", "2.5cm", "2.5cm"
            };

            var fields = X("Fields");
            var colunas = X("TablixColumns");
            var membrosColunas = X("TablixMembers");

            for (int i = 0; i < campos.Length; i++)
            {
                fields.Add(
                    X(
                        "Field",
                        new XAttribute("Name", campos[i]),
                        X("DataField", campos[i]),
                        new XElement(
                            RD + "TypeName",
                            dados.Columns[campos[i]].DataType.FullName)));

                colunas.Add(
                    X("TablixColumn", X("Width", larguras[i])));

                membrosColunas.Add(X("TablixMember"));
            }

            var linhas = X("TablixRows");

            // 0 = cabeçalho, 1 = registros, 2 = total.
            for (int linha = 0; linha < 3; linha++)
            {
                var celulas = X("TablixCells");

                for (int coluna = 0; coluna < campos.Length; coluna++)
                {
                    string valor =
                        linha == 0 ? titulos[coluna]
                        : linha == 1
                            ? "=Fields!" + campos[coluna] + ".Value"
                        : coluna == 1
                            ? "Total de unidades"
                        : coluna == 2
                            ? "=IIF(CountRows(\"DataEstoque\")=0, CLng(0), " +
                              "Sum(Fields!Quantidade.Value, \"DataEstoque\"))"
                            : "";

                    string formato =
                        linha == 0 || coluna == 1
                            ? null
                            : coluna == 0 ? "0" : "N0";

                    celulas.Add(
                        X(
                            "TablixCell",
                            X(
                                "CellContents",
                                Texto(
                                    "Celula" + linha + "_" + coluna,
                                    valor,
                                    linha != 1,
                                    formato,
                                    coluna != 1))));
                }

                linhas.Add(
                    X("TablixRow", X("Height", "0.8cm"), celulas));
            }

            var itens = X(
                "ReportItems",

                Posicionar(
                    Texto("Titulo", "ESTOQUE ATUAL", true),
                    "0cm", "0.8cm"),

                Posicionar(
                    Texto(
                        "DataConsulta",
                        "Posição consultada em " +
                        consultadoEm.ToString("dd/MM/yyyy HH:mm:ss"),
                        false),
                    "0.9cm", "0.8cm"),

                X(
                    "Tablix",
                    new XAttribute("Name", "TabelaEstoque"),

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

                    X("DataSetName", "DataEstoque"),

                    X(
                        "NoRowsMessage",
                        "Nenhum produto cadastrado."),

                    X("Top", "1.9cm"),
                    X("Left", "0cm"),
                    X("Height", "2.4cm"),
                    X("Width", "18cm"),
                    X("Style")),

                Posicionar(
                    Texto(
                        "Produtos",
                        "=\"Produtos listados: \" & CountRows(\"DataEstoque\")",
                        false),
                    "4.5cm", "0.8cm"));

            var pagina = X(
                "Page",
                X("PageHeight", "29.7cm"),
                X("PageWidth", "21cm"),
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
                                X("ConnectString", "/* Dados locais */")))),

                    X(
                        "DataSets",
                        X(
                            "DataSet",
                            new XAttribute("Name", "DataEstoque"),
                            fields,
                            X(
                                "Query",
                                X("DataSourceName", "Aplicacao"),
                                X(
                                    "CommandText",
                                    "/* Dados fornecidos pelo programa */")))),

                    X(
                        "Body",
                        itens,
                        X("Height", "5.4cm"),
                        X("Style")),

                    X("Width", "18cm"),
                    pagina,
                    X("Language", "pt-BR"),
                    X("ConsumeContainerWhitespace", "true")
                )
            ).ToString();
        }
    }
}