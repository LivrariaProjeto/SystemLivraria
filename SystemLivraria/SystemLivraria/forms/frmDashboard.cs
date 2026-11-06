using System;
using System.Drawing;
using System.Windows.Forms;
using SystemLivraria.forms.Cadastro;
using SystemLivraria.forms.Relatorios;

namespace SystemLivraria.forms
{
    public partial class frmDashboard : Form
    {
        private int nivelUsuario;
        private int idUsuarioLogado;

        // Construtor padrão, utilizado também pelo Designer.
        public frmDashboard()
        {
            InitializeComponent();

            nivelUsuario = 3;

            AplicarPermissoes();
            customizeDesign();
        }

        // Mantido para compatibilidade com chamadas existentes.
        public frmDashboard(int nivel)
        {
            InitializeComponent();

            nivelUsuario = nivel;

            AplicarPermissoes();
            customizeDesign();
        }

        // Construtor utilizado pelo login:
        // recebe o nível e o ID do usuário autenticado.
        public frmDashboard(int nivel, int idUsuario) : this(nivel)
        {
            idUsuarioLogado = idUsuario;

            if (idUsuarioLogado > 0 &&
                (nivelUsuario == 1 || nivelUsuario == 2))
            {
                AdicionarMenuComercial("Cadastrar venda", true);
                AdicionarMenuComercial("Cadastrar compra", false);

                pnl_cadastroSubmenu.Height += 110;
            }

            if (idUsuarioLogado > 0 && nivelUsuario == 1)
            {
                AdicionarMenuUsuarios();
            }
        }

        private void AdicionarMenuUsuarios()
        {
            var botao = new Button
            {
                Text = "Gerenciar usuários",
                Dock = DockStyle.Top,
                Height = 55,
                FlatStyle = FlatStyle.Flat,
                ForeColor = SystemColors.Control,
                Font = btn_cadClientes.Font,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(35, 0, 0, 0)
            };

            botao.FlatAppearance.BorderSize = 0;

            botao.Click += delegate
            {
                AbrirCadastroUsuarios();
            };

            pnl_cadastroSubmenu.Controls.Add(botao);
            pnl_cadastroSubmenu.Controls.SetChildIndex(botao, 0);
            pnl_cadastroSubmenu.Height += 55;
        }

        private void AbrirCadastroUsuarios()
        {
            if (idUsuarioLogado <= 0 || nivelUsuario != 1)
            {
                MessageBox.Show(
                    "Somente o Administrador pode gerenciar usuários.");

                return;
            }

            foreach (Control controle in pnl_tudo.Controls)
            {
                var aberta = controle as frmCadUsuarios;

                if (aberta != null && !aberta.IsDisposed)
                {
                    aberta.BringToFront();
                    aberta.Focus();

                    hideSubmenu();
                    return;
                }
            }

            var nova = new frmCadUsuarios(idUsuarioLogado)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.Sizable,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(10, 10)
            };

            pnl_tudo.AutoScroll = true;
            pnl_tudo.Controls.Add(nova);

            nova.Show();
            nova.BringToFront();

            hideSubmenu();
        }

        private void customizeDesign()
        {
            pnl_cadastroSubmenu.Visible = false;
            pnl_relatoriosSubmenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if (pnl_relatoriosSubmenu.Visible)
                pnl_relatoriosSubmenu.Visible = false;

            if (pnl_cadastroSubmenu.Visible)
                pnl_cadastroSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
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
            // Nível 3: Funcionário.
            if (nivelUsuario == 3)
            {
                if (btn_cadFuncionarios != null)
                    btn_cadFuncionarios.Visible = false;

                if (btn_cadFornecedores != null)
                    btn_cadFornecedores.Visible = false;

                if (pnl_relatoriosSubmenu != null)
                    pnl_relatoriosSubmenu.Visible = false;

                if (btn_relatorios != null)
                    btn_relatorios.Visible = false;

                if (btn_excluir != null)
                    btn_excluir.Visible = false;
            }
            // Nível 2: Gerente.
            else if (nivelUsuario == 2)
            {
                if (btn_cadFornecedores != null)
                    btn_cadFornecedores.Visible = false;

                if (btn_rltEntradaFinanceira != null)
                    btn_rltEntradaFinanceira.Visible = false;

                if (btn_rltSaidaFinanceira != null)
                    btn_rltSaidaFinanceira.Visible = false;

                if (btn_rltFluxoFinanceira != null)
                    btn_rltFluxoFinanceira.Visible = false;
            }
            // Nível 1: Chefe, com acesso total.
            else if (nivelUsuario == 1)
            {
                // Mantém os controles visíveis.
            }
        }

        // Cria os botões de Vendas e Compras no submenu existente.
        private void AdicionarMenuComercial(string texto, bool venda)
        {
            var botao = new Button
            {
                Text = texto,
                Dock = DockStyle.Top,
                Height = 55,
                FlatStyle = FlatStyle.Flat,
                ForeColor = SystemColors.Control,
                Font = btn_cadClientes.Font,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(35, 0, 0, 0)
            };

            botao.FlatAppearance.BorderSize = 0;

            botao.Click += delegate
            {
                AbrirComercial(venda);
            };

            pnl_cadastroSubmenu.Controls.Add(botao);
            pnl_cadastroSubmenu.Controls.SetChildIndex(botao, 0);
        }

        // Abre Vendas ou Compras, passando o usuário autenticado.
        private void AbrirComercial(bool venda)
        {
            if (idUsuarioLogado <= 0 ||
                (nivelUsuario != 1 && nivelUsuario != 2))
            {
                MessageBox.Show("Acesso negado para este usuário.");
                return;
            }

            // Evita abrir a mesma tela comercial duas vezes.
            foreach (Control controle in pnl_tudo.Controls)
            {
                var aberta = controle as frmOperacaoComercial;

                if (aberta != null &&
                    !aberta.IsDisposed &&
                    aberta.EhVenda == venda)
                {
                    aberta.BringToFront();
                    aberta.Focus();

                    hideSubmenu();
                    return;
                }
            }

            Form nova = venda
                ? (Form)new frmCadVendas(idUsuarioLogado)
                : new frmCadCompras(idUsuarioLogado);

            nova.TopLevel = false;
            nova.FormBorderStyle = FormBorderStyle.Sizable;
            nova.StartPosition = FormStartPosition.Manual;
            nova.Location = new Point(10, 10);

            pnl_tudo.AutoScroll = true;
            pnl_tudo.Controls.Add(nova);

            nova.Show();
            nova.BringToFront();

            hideSubmenu();
        }

        // Abertura dos demais formulários.
        private void AbrirFormulario<T>() where T : Form, new()
        {
            foreach (Form formAberto in Application.OpenForms)
            {
                if (formAberto is T && !formAberto.IsDisposed)
                {
                    formAberto.Activate();
                    formAberto.BringToFront();
                    return;
                }
            }

            T novoForm = new T();

            novoForm.TopLevel = false;
            novoForm.FormBorderStyle = FormBorderStyle.Sizable;
            novoForm.StartPosition = FormStartPosition.Manual;
            novoForm.Location = new Point(10, 10);

            pnl_tudo.Controls.Add(novoForm);

            novoForm.Show();
            novoForm.BringToFront();
        }

        // CADASTROS

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
            if (nivelUsuario == 3 || nivelUsuario == 2)
            {
                MessageBox.Show(
                    "Acesso negado para este nível!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

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
            if (nivelUsuario == 3)
            {
                MessageBox.Show(
                    "Acesso negado para funcionários!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                hideSubmenu();
                return;
            }

            AbrirFormulario<frmCadFuncionarios>();
            hideSubmenu();
        }

        // RELATÓRIOS

        private void btn_relatorios_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_relatoriosSubmenu);
        }

        private void btn_rltEstoqueAtual_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmRltEstoque>();
            hideSubmenu();
        }

        private void btn_rltMovimentoEstoque_Click(
            object sender, EventArgs e)
        {
            AbrirRelatorioComplementar(
                TipoRelatorioComplementar.MovimentoEstoque);

            hideSubmenu();
        }

        private void btn_rltEntradaFinanceira_Click(
            object sender, EventArgs e)
        {
            AbrirRelatorioComplementar(
                TipoRelatorioComplementar.EntradaFinanceira);

            hideSubmenu();
        }

        private void btn_rltSaidaFinanceira_Click(
            object sender, EventArgs e)
        {
            AbrirRelatorioComplementar(
                TipoRelatorioComplementar.SaidaFinanceira);

            hideSubmenu();
        }

        private void btn_rltFluxoFinanceira_Click(
            object sender, EventArgs e)
        {
            AbrirRelatorioComplementar(
                TipoRelatorioComplementar.FluxoFinanceiro);

            hideSubmenu();
        }

        private void AbrirRelatorioComplementar(
            TipoRelatorioComplementar tipo)
        {
            bool financeiro =
                tipo != TipoRelatorioComplementar.MovimentoEstoque;

            if ((financeiro && nivelUsuario != 1) ||
                (!financeiro &&
                 nivelUsuario != 1 &&
                 nivelUsuario != 2))
            {
                MessageBox.Show(
                    "Você não tem permissão para este relatório.");

                return;
            }

            foreach (Form aberta in Application.OpenForms)
            {
                var relatorio =
                    aberta as frmRelatoriosComplementares;

                if (relatorio != null &&
                    !relatorio.IsDisposed &&
                    relatorio.Tipo == tipo)
                {
                    JanelaRelatorios.Ajustar(relatorio, pnl_tudo);

                    relatorio.Activate();
                    relatorio.BringToFront();
                    return;
                }
            }

            var novo = new frmRelatoriosComplementares(tipo);

            novo.TopLevel = false;
            novo.FormBorderStyle = FormBorderStyle.Sizable;

            pnl_tudo.Controls.Add(novo);

            JanelaRelatorios.Ajustar(novo, pnl_tudo);

            novo.Show();
            novo.BringToFront();
        }

        // CONSULTA

        private void btn_Consulta_Click(object sender, EventArgs e)
        {
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

            frmConsulta novoForm = new frmConsulta(nivelUsuario);

            novoForm.TopLevel = false;
            novoForm.FormBorderStyle = FormBorderStyle.Sizable;

            int deslocamento = pnl_tudo.Controls.Count * 20;

            novoForm.Location = new Point(
                10 + deslocamento,
                10 + deslocamento);

            pnl_tudo.Controls.Add(novoForm);

            novoForm.Show();
            novoForm.BringToFront();

            hideSubmenu();
        }

        // EXCLUSÃO

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (nivelUsuario == 3)
            {
                MessageBox.Show(
                    "Você não tem permissão para acessar esta tela.",
                    "Acesso negado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            AbrirFormularioExcluir(
                new frmExcluir(nivelUsuario));

            hideSubmenu();
        }

        private void AbrirFormularioExcluir(Form novoForm)
        {
            foreach (Form formAberto in Application.OpenForms)
            {
                if (formAberto.GetType() == novoForm.GetType() &&
                    !formAberto.IsDisposed)
                {
                    novoForm.Dispose();

                    formAberto.Activate();
                    formAberto.BringToFront();
                    return;
                }
            }

            novoForm.TopLevel = false;
            novoForm.FormBorderStyle = FormBorderStyle.Sizable;
            novoForm.StartPosition = FormStartPosition.Manual;
            novoForm.Location = new Point(10, 10);

            pnl_tudo.Controls.Add(novoForm);

            novoForm.Show();
            novoForm.BringToFront();
        }

        // Eventos mantidos porque podem estar vinculados no Designer.

        private void frmDashboard_Load(object sender, EventArgs e)
        {
        }

        private void pnl_tudo_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}