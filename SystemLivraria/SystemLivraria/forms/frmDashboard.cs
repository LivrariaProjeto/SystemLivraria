using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemLivraria.forms.Relatorios;

namespace SystemLivraria.forms
{
    public partial class frmDashboard : Form
    {
        private int nivelUsuario;

        // Construtor padrão (caso abra direto, assume nível 3)
        public frmDashboard()
        {
            InitializeComponent();
            nivelUsuario = 3;
            AplicarPermissoes();
            customizeDesign();
        }

        // Construtor recebendo o nível do usuário
        public frmDashboard(int nivel)
        {
            InitializeComponent();
            nivelUsuario = nivel;
            AplicarPermissoes();
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
            if (pnl_relatoriosSubmenu.Visible == true)
                pnl_relatoriosSubmenu.Visible = false;

            // Correção lógica para fechar o de cadastro se estiver aberto
            if (pnl_cadastroSubmenu.Visible == true)
                pnl_cadastroSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void AplicarPermissoes()
        {
            // Nível 1: Funcionário
            // - Consulta: só o estoque
            // - Cadastro: só cadastra produto, autor, editora e cliente
            if (nivelUsuario == 1)
            {
                if (btn_cadFuncionarios != null) btn_cadFuncionarios.Visible = false;
                if (btn_cadFornecedores != null) btn_cadFornecedores.Visible = false;

                // Ocultar menus de relatórios ou financeiro se existirem no dashboard
                if (pnl_relatoriosSubmenu != null) pnl_relatoriosSubmenu.Visible = false;
                if (btn_relatorios != null) btn_relatorios.Visible = false;
            }
            // Nível 2: Gerente
            // - Consulta: estoque, vendas e compras
            // - Cadastro: produtos, autores, editoras, clientes e funcionários
            // - Relatório: venda, compra, estoque (sem financeiro)
            else if (nivelUsuario == 2)
            {
                if (btn_cadFornecedores != null) btn_cadFornecedores.Visible = false;

                // Ocultar botões financeiros nos relatórios, se houver
                if (btn_rltEntradaFinanceira != null) btn_rltEntradaFinanceira.Visible = false;
                if (btn_rltSaidaFinanceira != null) btn_rltSaidaFinanceira.Visible = false;
                if (btn_rltFluxoFinanceira != null) btn_rltFluxoFinanceira.Visible = false;
            }
            // Nível 3: Chefe (Acesso total)
            else if (nivelUsuario == 3)
            {
                // Tudo visível
            }
        }

        // Método genérico para abrir os formulários evitando duplicação
        // Método genérico atualizado para abrir múltiplos formulários dentro do painel sem sobrepô-los totalmente
        private void AbrirFormulario<T>() where T : Form, new()
        {
            // Verifica se já existe um formulário desse tipo aberto
            foreach (Form formAberto in Application.OpenForms)
            {
                if (formAberto is T)
                {
                    formAberto.Activate();
                    formAberto.BringToFront(); // Garante que vai para a frente se já estiver aberto
                    return;
                }
            }

            // Cria a nova instância do formulário
            T novoForm = new T();

            // Configura para se comportar como um controle interno do painel
            novoForm.TopLevel = false;
            novoForm.FormBorderStyle = FormBorderStyle.Sizable;

            // Define uma posição inicial em cascata
            int deslocamento = pnl_tudo.Controls.Count * 20;
            novoForm.Location = new Point(10 + deslocamento, 10 + deslocamento);

            // Adiciona ao painel do dashboard
            pnl_tudo.Controls.Add(novoForm);

            // Mostra o formulário e traz para a frente de todos no painel
            novoForm.Show();
            novoForm.BringToFront();
        }

        //CADASTRO
        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_cadastroSubmenu);
        }

        private void btn_cadProdutos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadProdutos>();
            hideSubmenu();
        }

        private void btn_cadAutores_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadAutores>();
            hideSubmenu();
        }

        private void btn_cadEditoras_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadEditoras>();
            hideSubmenu();
        }

        private void btn_cadFornecedores_Click(object sender, EventArgs e)
        {
            // Validação extra de segurança por nível
            if (nivelUsuario == 1 || nivelUsuario == 2)
            {
                MessageBox.Show("Acesso negado para este nível!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hideSubmenu();
                return;
            }
            AbrirFormulario<frmCadFornecedores>();
            hideSubmenu();
        }

        private void btn_cadClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadClientes>();
            hideSubmenu();
        }

        private void btn_cadFuncionarios_Click(object sender, EventArgs e)
        {
            if (nivelUsuario == 1)
            {
                MessageBox.Show("Acesso negado para funcionários!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hideSubmenu();
                return;
            }
            AbrirFormulario<frmCadFuncionarios>();
            hideSubmenu();
        }

        //RELATORIOS
        private void btn_relatorios_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_relatoriosSubmenu);
        }

        private void btn_rltEstoqueAtual_Click(object sender, EventArgs e)
        {
            // Substitua pelo formulário de relatório correspondente, se houver
            // Exemplo: AbrirFormulario<frmRelEstoqueAtual>();
            hideSubmenu();
        }

        private void btn_rltMovimentoEstoque_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmRltMovEstoque>();
            hideSubmenu();
        }

        private void btn_rltEntradaFinanceira_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_rltSaidaFinanceira_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_rltFluxoFinanceira_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        //CONSULTA
        private void btn_Consulta_Click(object sender, EventArgs e)
        {
            // Verifica se já está aberto
            foreach (Form formAberto in Application.OpenForms)
            {
                if (formAberto is frmConsulta)
                {
                    formAberto.Activate();
                    formAberto.BringToFront();
                    hideSubmenu();
                    return;
                }
            }

            // Cria o form de consulta passando o nível
            frmConsulta novoForm = new frmConsulta(nivelUsuario);
            novoForm.TopLevel = false;
            novoForm.FormBorderStyle = FormBorderStyle.Sizable;

            int deslocamento = pnl_tudo.Controls.Count * 20;
            novoForm.Location = new Point(10 + deslocamento, 10 + deslocamento);

            pnl_tudo.Controls.Add(novoForm);
            novoForm.Show();
            novoForm.BringToFront(); // Traz para a frente de todos

            hideSubmenu();
        }

        //EXCLUIR
        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmExcluirProdutos>();
            hideSubmenu();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void pnl_tudo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}