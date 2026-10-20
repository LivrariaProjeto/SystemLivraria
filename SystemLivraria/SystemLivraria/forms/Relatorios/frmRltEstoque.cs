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
    public partial class frmRltEstoque : Form
    {
        public frmRltEstoque()
        {
            InitializeComponent();
        }

        private void frmRltEstoque_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
