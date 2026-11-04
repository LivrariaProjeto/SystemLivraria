using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms.Relatorios
{
    internal static class ApoioRelatoriosSeparados
    {
        internal static void PrepararPeriodo(
            DateTimePicker inicio,
            DateTimePicker fim)
        {
            inicio.Format = DateTimePickerFormat.Short;
            fim.Format = DateTimePickerFormat.Short;
            fim.MaxDate = new DateTime(9998, 12, 31);

            inicio.Value = new DateTime(
                DateTime.Today.Year,
                DateTime.Today.Month,
                1);

            fim.Value = DateTime.Today;
        }

        internal static void Mostrar(
            ReportViewer viewer,
            string arquivo,
            string dataset,
            DateTime inicio,
            DateTime fim,
            Func<DateTime, DateTime, DataTable> consultar)
        {
            if (inicio.Date > fim.Date)
            {
                MessageBox.Show(
                    "A data inicial não pode ser posterior à final.");

                return;
            }

            try
            {
                viewer.Reset();

                // O limite exclusivo inclui o dia final inteiro.
                DataTable dados = consultar(
                    inicio.Date,
                    fim.Date.AddDays(1));

                viewer.ProcessingMode = ProcessingMode.Local;

                viewer.LocalReport.ReportEmbeddedResource =
                    "SystemLivraria.forms.Relatorios." + arquivo;

                viewer.LocalReport.DataSources.Clear();

                viewer.LocalReport.DataSources.Add(
                    new ReportDataSource(dataset, (object)dados));

                viewer.LocalReport.SetParameters(
                    new[]
                    {
                        new ReportParameter(
                            "Periodo",
                            string.Format(
                                "Período: {0:dd/MM/yyyy} a {1:dd/MM/yyyy}",
                                inicio.Date,
                                fim.Date))
                    });

                viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    viewer.FindForm(),
                    ex.GetBaseException().Message,
                    "Erro no relatório",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private const string SqlEstoque = @"
SELECT M.Data,
       M.Tipo,
       M.Documento,
       M.Descricao,
       M.Complemento,
       M.Entrada,
       M.Saida
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

        internal static DataTable MovimentoEstoque(
            DateTime inicio,
            DateTime fimExclusivo)
        {
            return Consultar(SqlEstoque, inicio, fimExclusivo);
        }

        internal static DataTable Financeiro(
            DateTime inicio,
            DateTime fimExclusivo,
            string tipo)
        {
            return FiltrarFinanceiro(
                Consultar(SqlFinanceiro, inicio, fimExclusivo),
                tipo);
        }

        internal static DataTable FiltrarFinanceiro(
            DataTable dados,
            string tipo)
        {
            if (tipo != null &&
                tipo != "Entrada" &&
                tipo != "Saída")
            {
                throw new ArgumentException(
                    "Tipo de relatório financeiro inválido.");
            }

            foreach (DataRow linha in dados.Rows)
            {
                if ((string)linha["Tipo"] != "Entrada" &&
                    (string)linha["Tipo"] != "Saída")
                {
                    throw new InvalidOperationException(
                        "Confira Financeiro.Tipo_VDS: " +
                        "use RECEITA/ENTRADA ou DESPESA/SAIDA.");
                }
            }

            // null indica o fluxo completo: entradas e saídas.
            if (tipo == null)
            {
                return dados;
            }

            using (var filtro = new DataView(dados))
            {
                filtro.RowFilter = tipo == "Entrada"
                    ? "Tipo = 'Entrada'"
                    : "Tipo = 'Saída'";

                return filtro.ToTable();
            }
        }

        private static DataTable Consultar(
            string sql,
            DateTime inicio,
            DateTime fimExclusivo)
        {
            if (inicio >= fimExclusivo)
            {
                throw new ArgumentException("Período inválido.");
            }

            var config = ConfigurationManager.ConnectionStrings[
                "SystemLivraria.Properties.Settings.db_250064ConnectionString"];

            if (config == null ||
                string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "Configure a conexão no App.config.");
            }

            using (var conexao = new SqlConnection(config.ConnectionString))
            using (var comando = new SqlCommand(sql, conexao))
            using (var adaptador = new SqlDataAdapter(comando))
            {
                comando.Parameters.Add(
                    "@Inicio", SqlDbType.DateTime2).Value = inicio;

                comando.Parameters.Add(
                    "@Fim", SqlDbType.DateTime2).Value = fimExclusivo;

                var dados = new DataTable();
                adaptador.Fill(dados);

                return dados;
            }
        }
    }
}