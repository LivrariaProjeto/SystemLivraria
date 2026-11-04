using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

using DadosRelatorio = SystemLivraria.data.DataSet2;
using AdaptadorEstoque =
    SystemLivraria.data.DataSet2TableAdapters.EstoqueTableAdapter;
using AdaptadorProdutos =
    SystemLivraria.data.DataSet2TableAdapters.ProdutosTableAdapter;

namespace SystemLivraria.forms.Relatorios
{
    public partial class frmRltEstoque : Form
    {
        public frmRltEstoque()
        {
            InitializeComponent();
        }

        private void frmRltEstoque_Load(object sender, EventArgs e)
        {
            try
            {
                var dados = new DadosRelatorio();

                using (var adaptador = new AdaptadorEstoque())
                {
                    adaptador.Fill(dados.Estoque);
                }

                using (var adaptador = new AdaptadorProdutos())
                {
                    adaptador.Fill(dados.Produtos);
                }

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportViewer1.LocalReport.ReportEmbeddedResource =
                    "SystemLivraria.forms.Relatorios.ReportEstoque.rdlc";

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource(
                        "DataEstoque",
                        (object)dados.Estoque
                    )
                );

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource(
                        "DataProdutos",
                        (object)dados.Produtos
                    )
                );

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar o relatório: " +
                    ex.GetBaseException().Message,
                    "Relatório de estoque",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }
    }
}