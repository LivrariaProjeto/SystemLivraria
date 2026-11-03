using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemLivraria.forms.Relatorios
{
    public partial class frmRltMovEstoque : Form
    {
        public frmRltMovEstoque()
        {
            InitializeComponent();
        }

        private void frmRltMovEstoque_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'db_250064DataSet2.Estoque'. Você pode movê-la ou removê-la conforme necessário.
            this.estoqueTableAdapter1.Fill(this.db_250064DataSet2.Estoque);
            // TODO: esta linha de código carrega dados na tabela 'db_250064DataSet.Estoque'. Você pode movê-la ou removê-la conforme necessário.
            this.estoqueTableAdapter.Fill(this.db_250064DataSet.Estoque);

            this.rpt_movestoque.RefreshReport();
        }
    }
}
