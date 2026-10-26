using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemLivraria.data;
using SystemLivraria.data.DataSet2TableAdapters;

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
                // 1. Instancia o DataSet e o TableAdapter correspondentes
                // (Certifica-te de usar os nomes exatos das tuas classes geradas pelo XSD)
                DataSet2 datasetLocal = new DataSet2();
                DataSet2TableAdapters.estoqueTableAdapter adaptadorEstoque = new DataSet2TableAdapters.estoqueTableAdapter();

                // 2. Preenche os dados do banco na tabela do DataSet
                adaptadorEstoque.Fill(datasetLocal.Estoque);

                // 3. Configura a fonte de dados do ReportViewer
                // O nome "DataSetEstoque" deve corresponder ao nome do conjunto de dados definido no seu arquivo .rdlc
                ReportDataSource rds = new ReportDataSource("DataSetEstoque", (object)datasetLocal.Estoque);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                // 4. Atualiza e renderiza o relatório
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregar o relatório: " + ex.Message);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
