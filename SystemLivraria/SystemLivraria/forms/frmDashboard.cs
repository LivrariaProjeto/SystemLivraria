using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            pnl_cadastroSubmenu.Visible = false;
            pnl_relatoriosSubmenu.Visible = false;
            //..
        }

        private void hideSubmenu()
        {
            if(pnl_relatoriosSubmenu.Visible == true)
                pnl_relatoriosSubmenu.Visible = false;
            if(pnl_cadastroSubmenu.Visible == false)
                pnl_cadastroSubmenu.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        //CADASTRO
        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_cadastroSubmenu);
        }

        private void btn_cadProdutos_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_cadAutores_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_cadEditoras_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_cadFornecedores_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_cadClientes_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_cadFuncionarios_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        //RELATORIOS
        private void btn_relatorios_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_relatoriosSubmenu);
        }

        private void btn_rltEstoqueAtual_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_rltMovimentoEstoque_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_rltEntradaFinanceira_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_rltSaidaFinanceira_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        private void btn_rltFluxoFinanceira_Click(object sender, EventArgs e)
        {
            //COLOCAR O CODIGO NO EM CIMA DESSE HIDESUBMENU
            hideSubmenu();
        }

        //CONSULTA
        private void btn_Consulta_Click(object sender, EventArgs e)
        {

        }

        //EXCLUIR
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
