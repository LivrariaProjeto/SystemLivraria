using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemLivraria.forms.Cadastro;
using SystemLivraria.forms.Relatorios;

namespace SystemLivraria.forms
{
    public partial class frmDashboard : Form
    {
        private readonly int nivelUsuario;
        private readonly int idUsuarioLogado;
        private readonly DateTime inicioSessao;

        private readonly CultureInfo cultura =
            CultureInfo.GetCultureInfo("pt-BR");

        private readonly Color azul =
            Color.FromArgb(16, 50, 86);

        private Panel painelConteudo;
        private Panel painelInicio;

        private Label lblBemVindo;
        private Label lblUsuario;
        private Label lblPermissao;
        private Label lblSituacao;
        private Label lblHora;
        private Label lblData;
        private Label lblEntrada;

        private System.Windows.Forms.Timer relogio;

        private Button btnLogoff;
        private bool processandoLogoff;

        public bool SolicitouLogoff { get; private set; }

        public frmDashboard() : this(3, 0)
        {
        }

        public frmDashboard(int nivel) : this(nivel, 0)
        {
        }

        public frmDashboard(int nivel, int idUsuario)
        {
            InitializeComponent();

            AdicionarBotaoLogoff();

            nivelUsuario = nivel;
            idUsuarioLogado = idUsuario;
            inicioSessao = DateTime.Now;

            MontarAreaPrincipal();
            AplicarPermissoes();
            customizeDesign();

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

            this.Load -= frmDashboard_Load;
            this.Load += frmDashboard_Load;
        }

        // CABEÇALHO E ÁREA PRINCIPAL

        private static Label Texto(
            string texto,
            float tamanho,
            bool negrito,
            Color cor,
            ContentAlignment alinhamento =
                ContentAlignment.MiddleLeft)
        {
            var fonte = new Font(
                negrito ? "Century Gothic" : "Segoe UI",
                tamanho,
                negrito ? FontStyle.Bold : FontStyle.Regular);

            var label = new Label
            {
                Text = texto,
                Dock = DockStyle.Fill,
                AutoSize = false,
                AutoEllipsis = true,
                Font = fonte,
                ForeColor = cor,
                TextAlign = alinhamento,
                Margin = Padding.Empty
            };

            label.Disposed += delegate
            {
                fonte.Dispose();
            };

            return label;
        }

        private static TableLayoutPanel Coluna(
            params int[] alturas)
        {
            var coluna = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = alturas.Length,
                Margin = Padding.Empty
            };

            coluna.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            foreach (int altura in alturas)
            {
                coluna.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, altura));
            }

            return coluna;
        }

        private void MontarAreaPrincipal()
        {
            panel1.Dock = DockStyle.Left;

            pnl_tudo.Dock = DockStyle.Fill;
            pnl_tudo.AutoScroll = false;

            Controls.SetChildIndex(pnl_tudo, 0);

            Color fundo = Color.FromArgb(244, 246, 249);

            var estrutura = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = fundo,
                Margin = Padding.Empty
            };

            estrutura.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            estrutura.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 178));

            estrutura.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            pnl_tudo.Controls.Add(estrutura);

            var cabecalho = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(12, 12, 12, 6)
            };

            var dados = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(18, 12, 18, 10)
            };

            dados.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            dados.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 280));

            dados.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            cabecalho.Controls.Add(dados);

            cabecalho.Controls.Add(new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 3,
                BackColor = azul
            });

            estrutura.Controls.Add(cabecalho, 0, 0);

            var identidade = Coluna(42, 26, 26, 24);
            identidade.Padding = new Padding(0, 0, 12, 0);

            lblBemVindo = Texto(
                "Bem-vindo à Livraria",
                19,
                true,
                azul);

            lblUsuario = Texto(
                "Carregando identificação...",
                11,
                false,
                Color.FromArgb(65, 75, 90));

            lblPermissao = Texto(
                "Permissão da sessão: " + NomeNivel(nivelUsuario),
                11,
                true,
                azul);

            lblSituacao = Texto(
                "",
                9,
                false,
                Color.DimGray);

            identidade.Controls.Add(lblBemVindo, 0, 0);
            identidade.Controls.Add(lblUsuario, 0, 1);
            identidade.Controls.Add(lblPermissao, 0, 2);
            identidade.Controls.Add(lblSituacao, 0, 3);

            dados.Controls.Add(identidade, 0, 0);

            var horario = Coluna(18, 50, 26, 24);

            horario.Controls.Add(
                Texto(
                    "Horário local",
                    9,
                    false,
                    Color.DimGray,
                    ContentAlignment.MiddleRight),
                0,
                0);

            lblHora = Texto(
                "--:--:--",
                28,
                true,
                azul,
                ContentAlignment.MiddleRight);

            lblData = Texto(
                "",
                10,
                false,
                Color.DimGray,
                ContentAlignment.MiddleRight);

            lblEntrada = Texto(
                "Entrada: " +
                inicioSessao.ToString(
                    "dd/MM/yyyy HH:mm:ss", cultura),
                9,
                false,
                Color.DimGray,
                ContentAlignment.MiddleRight);

            horario.Controls.Add(lblHora, 0, 1);
            horario.Controls.Add(lblData, 0, 2);
            horario.Controls.Add(lblEntrada, 0, 3);

            dados.Controls.Add(horario, 1, 0);

            painelConteudo = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = fundo,
                Margin = Padding.Empty
            };

            estrutura.Controls.Add(painelConteudo, 0, 1);

            painelInicio = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = fundo,
                Padding = new Padding(30)
            };

            var orientacao = Texto(
                "Utilize o menu lateral para acessar as " +
                "opções disponíveis para sua conta.",
                11,
                false,
                Color.DimGray);

            orientacao.Dock = DockStyle.Top;
            orientacao.Height = 60;

            var titulo = Texto(
                "Selecione uma opção para começar",
                18,
                true,
                azul);

            titulo.Dock = DockStyle.Top;
            titulo.Height = 48;

            painelInicio.Controls.Add(orientacao);
            painelInicio.Controls.Add(titulo);

            painelConteudo.Controls.Add(painelInicio);

            painelConteudo.ControlRemoved += delegate
            {
                AtualizarInicio();
            };

            // O Dispose do Designer também descartará o Timer.
            if (components == null)
                components = new Container();

            relogio = new System.Windows.Forms.Timer(components)
            {
                Interval = 1000
            };

            relogio.Tick += delegate
            {
                AtualizarRelogio();
            };

            FormClosed += delegate
            {
                relogio.Stop();
            };
        }

        private static string NomeNivel(int nivel)
        {
            switch (nivel)
            {
                case 1:
                    return "Administrador";

                case 2:
                    return "Gerente";

                case 3:
                    return "Funcionário";

                default:
                    return "Não identificado";
            }
        }

        private void AtualizarRelogio()
        {
            if (IsDisposed || Disposing)
                return;

            DateTime agora = DateTime.Now;

            lblHora.Text =
                agora.ToString("HH:mm:ss", cultura);

            lblData.Text =
                agora.ToString("dddd, dd/MM/yyyy", cultura);
        }

        private sealed class DadosUsuario
        {
            internal string Nome;
            internal string Login;
            internal string Cargo;
            internal string Permissao;
            internal int Nivel;
            internal bool Ativo;
        }

        private static DadosUsuario LerUsuario(int idUsuario)
        {
            var config = ConfigurationManager.ConnectionStrings[
                "SystemLivraria.Properties.Settings.db_250064ConnectionString"];

            if (config == null ||
                string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "Conexão não configurada.");
            }

            using (var c = new SqlConnection(config.ConnectionString))
            using (var cmd = new SqlCommand(@"
SELECT
    F.Nome_Funci,
    F.Cargo_Funci,
    U.Login_usu,
    U.Id_Permi,
    U.Ativo_usu,
    P.Nome_Permi
FROM dbo.Usuarios U
JOIN dbo.Funcionarios F ON F.Id_Funci=U.Id_Funci
JOIN dbo.Permissoes P ON P.Id_Permi=U.Id_Permi
WHERE U.Id_Usu=@id;", c))
            {
                cmd.CommandTimeout = 15;

                cmd.Parameters.Add(
                    "@id", SqlDbType.Int).Value = idUsuario;

                c.Open();

                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read())
                        return null;

                    return new DadosUsuario
                    {
                        Nome = Convert.ToString(r["Nome_Funci"]),
                        Cargo = Convert.ToString(r["Cargo_Funci"]),
                        Login = Convert.ToString(r["Login_usu"]),
                        Nivel = Convert.ToInt32(r["Id_Permi"]),
                        Permissao = Convert.ToString(r["Nome_Permi"]),
                        Ativo = Convert.ToBoolean(r["Ativo_usu"])
                    };
                }
            }
        }

        private async void frmDashboard_Load(
            object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            AtualizarRelogio();
            relogio.Start();

            if (idUsuarioLogado <= 0)
            {
                lblUsuario.Text = "Usuário não identificado";

                lblPermissao.Text =
                    "Permissão: sem sessão identificada";

                lblSituacao.Text =
                    "Abra o sistema pela tela de login.";

                return;
            }

            lblUsuario.Text =
                "Usuário: código " + idUsuarioLogado;

            try
            {
                DadosUsuario usuario = await Task.Run(
                    () => LerUsuario(idUsuarioLogado));

                if (IsDisposed || Disposing)
                    return;

                if (usuario == null)
                {
                    lblSituacao.Text =
                        "Cadastro do usuário não encontrado.";

                    return;
                }

                lblBemVindo.Text =
                    "Bem-vindo, " + usuario.Nome;

                lblUsuario.Text =
                    "Usuário: " + usuario.Login +
                    "   |   Cargo: " +
                    (string.IsNullOrWhiteSpace(usuario.Cargo)
                        ? "Não informado"
                        : usuario.Cargo);

                if (usuario.Nivel == nivelUsuario &&
                    usuario.Ativo)
                {
                    lblPermissao.Text =
                        "Permissão: " + usuario.Permissao +
                        " (nível " + nivelUsuario + ")";

                    lblSituacao.Text = "Conta ativa";
                }
                else
                {
                    lblSituacao.Text =
                        "O acesso foi alterado no cadastro. " +
                        "Entre novamente para atualizar a sessão.";
                }
            }
            catch (Exception)
            {
                if (IsDisposed || Disposing)
                    return;

                lblSituacao.Text =
                    "Os dados do usuário estão indisponíveis " +
                    "neste momento.";
            }
        }

        // NAVEGAÇÃO DOS FORMULÁRIOS

        private void AtualizarInicio(Form ignorar = null)
        {
            if (IsDisposed || Disposing)
                return;

            bool temFormulario = false;

            foreach (Control controle in painelConteudo.Controls)
            {
                var f = controle as Form;

                if (f != null &&
                    f != ignorar &&
                    !f.IsDisposed)
                {
                    temFormulario = true;
                    break;
                }
            }

            painelInicio.Visible = !temFormulario;

            if (!temFormulario)
            {
                painelConteudo.AutoScrollPosition = Point.Empty;
                painelInicio.SendToBack();
            }
        }

        private Form Encontrar(
            Type tipo, Predicate<Form> filtro = null)
        {
            foreach (Control controle in painelConteudo.Controls)
            {
                var f = controle as Form;

                if (f != null &&
                    !f.IsDisposed &&
                    tipo.IsInstanceOfType(f) &&
                    (filtro == null || filtro(f)))
                {
                    return f;
                }
            }

            return null;
        }

        private void Ativar(
            Form formulario, bool relatorio = false)
        {
            if (relatorio)
            {
                JanelaRelatorios.Ajustar(
                    formulario, painelConteudo);
            }
            else if (formulario.WindowState ==
                     FormWindowState.Minimized)
            {
                formulario.WindowState =
                    FormWindowState.Normal;
            }

            formulario.BringToFront();
            formulario.Focus();
        }

        private void Hospedar(
            Form formulario,
            bool relatorio = false,
            bool deslocar = false)
        {
            int quantidade = 0;

            foreach (Control controle in painelConteudo.Controls)
            {
                if (controle is Form &&
                    !controle.IsDisposed)
                {
                    quantidade++;
                }
            }

            formulario.TopLevel = false;

            formulario.FormBorderStyle =
                FormBorderStyle.Sizable;

            formulario.StartPosition =
                FormStartPosition.Manual;

            int deslocamento = deslocar
                ? quantidade * 20
                : 0;

            formulario.Location = new Point(
                10 + deslocamento,
                10 + deslocamento);

            formulario.FormClosed += delegate
            {
                AtualizarInicio(formulario);
            };

            painelConteudo.Controls.Add(formulario);

            if (relatorio)
            {
                JanelaRelatorios.Ajustar(
                    formulario, painelConteudo);
            }

            AtualizarInicio();

            formulario.Show();
            formulario.BringToFront();
        }

        private void AbrirFormulario<T>()
            where T : Form, new()
        {
            Form aberta = Encontrar(typeof(T));

            if (aberta != null)
                Ativar(aberta);
            else
                Hospedar(new T());
        }

        // MENUS

        private void AdicionarBotaoMenu(
            string texto, EventHandler clique)
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
            botao.Click += clique;

            pnl_cadastroSubmenu.Controls.Add(botao);
            pnl_cadastroSubmenu.Controls.SetChildIndex(botao, 0);
        }

        private void AdicionarMenuUsuarios()
        {
            AdicionarBotaoMenu(
                "Gerenciar usuários",
                delegate { AbrirCadastroUsuarios(); });

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

            Form aberta = Encontrar(typeof(frmCadUsuarios));

            if (aberta != null)
                Ativar(aberta);
            else
                Hospedar(new frmCadUsuarios(idUsuarioLogado));

            hideSubmenu();
        }

        private void AdicionarMenuComercial(
            string texto, bool venda)
        {
            AdicionarBotaoMenu(
                texto,
                delegate { AbrirComercial(venda); });
        }

        private void AbrirComercial(bool venda)
        {
            if (idUsuarioLogado <= 0 ||
                (nivelUsuario != 1 && nivelUsuario != 2))
            {
                MessageBox.Show(
                    "Acesso negado para este usuário.");

                return;
            }

            Form aberta = Encontrar(
                typeof(frmOperacaoComercial),
                f => ((frmOperacaoComercial)f).EhVenda == venda);

            if (aberta != null)
            {
                Ativar(aberta);
            }
            else
            {
                Hospedar(
                    venda
                        ? (Form)new frmCadVendas(idUsuarioLogado)
                        : new frmCadCompras(idUsuarioLogado));
            }

            hideSubmenu();
        }

        private void customizeDesign()
        {
            pnl_cadastroSubmenu.Visible = false;
            pnl_relatoriosSubmenu.Visible = false;
        }

        private void hideSubmenu()
        {
            pnl_cadastroSubmenu.Visible = false;
            pnl_relatoriosSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            bool abrir = !subMenu.Visible;

            hideSubmenu();

            subMenu.Visible = abrir;
        }

        private void AplicarPermissoes()
        {
            if (nivelUsuario == 3)
            {
                btn_cadFuncionarios.Visible = false;
                btn_cadFornecedores.Visible = false;
                pnl_relatoriosSubmenu.Visible = false;
                btn_relatorios.Visible = false;
                btn_excluir.Visible = false;
            }
            else if (nivelUsuario == 2)
            {
                btn_cadFornecedores.Visible = false;
                btn_rltEntradaFinanceira.Visible = false;
                btn_rltSaidaFinanceira.Visible = false;
                btn_rltFluxoFinanceira.Visible = false;
            }
        }

        // CADASTROS

        private void btn_cadastro_Click(
            object sender, EventArgs e)
        {
            showSubMenu(pnl_cadastroSubmenu);
        }

        private void btn_cadProdutos_Click(
            object sender, EventArgs e)
        {
            AbrirFormulario<frmCadProdutos>();
            hideSubmenu();
        }

        private void btn_cadAutores_Click(
            object sender, EventArgs e)
        {
            AbrirFormulario<frmCadAutores>();
            hideSubmenu();
        }

        private void btn_cadEditoras_Click(
            object sender, EventArgs e)
        {
            AbrirFormulario<frmCadEditoras>();
            hideSubmenu();
        }

        private void btn_cadClientes_Click(
            object sender, EventArgs e)
        {
            AbrirFormulario<frmCadClientes>();
            hideSubmenu();
        }

        private void btn_cadFornecedores_Click(
            object sender, EventArgs e)
        {
            if (nivelUsuario == 3 || nivelUsuario == 2)
            {
                MessageBox.Show(
                    "Acesso negado para este nível!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                AbrirFormulario<frmCadFornecedores>();
            }

            hideSubmenu();
        }

        private void btn_cadFuncionarios_Click(
            object sender, EventArgs e)
        {
            if (nivelUsuario == 3)
            {
                MessageBox.Show(
                    "Acesso negado para funcionários!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                AbrirFormulario<frmCadFuncionarios>();
            }

            hideSubmenu();
        }

        // RELATÓRIOS

        private void btn_relatorios_Click(
            object sender, EventArgs e)
        {
            showSubMenu(pnl_relatoriosSubmenu);
        }

        private void btn_rltEstoqueAtual_Click(
            object sender, EventArgs e)
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

            Form aberta = Encontrar(
                typeof(frmRelatoriosComplementares),
                f => ((frmRelatoriosComplementares)f).Tipo == tipo);

            if (aberta != null)
            {
                Ativar(aberta, true);
            }
            else
            {
                Hospedar(
                    new frmRelatoriosComplementares(tipo),
                    true);
            }
        }

        // CONSULTA

        private void btn_Consulta_Click(
            object sender, EventArgs e)
        {
            Form aberta = Encontrar(typeof(frmConsulta));

            if (aberta != null)
            {
                Ativar(aberta);
            }
            else
            {
                Hospedar(
                    new frmConsulta(nivelUsuario),
                    false,
                    true);
            }

            hideSubmenu();
        }

        // EXCLUSÃO

        private void btn_Excluir_Click(
            object sender, EventArgs e)
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
            Form aberta = Encontrar(novoForm.GetType());

            if (aberta != null)
            {
                novoForm.Dispose();
                Ativar(aberta);
            }
            else
            {
                Hospedar(novoForm);
            }
        }

        // LOGOFF

        private void AdicionarBotaoLogoff()
        {
            if (btnLogoff != null)
                return;

            var controlesAtuais =
                new Control[panel1.Controls.Count];

            panel1.Controls.CopyTo(controlesAtuais, 0);

            // Menus podem rolar; o botão permanece fixo abaixo.
            var menuRolavel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = panel1.BackColor
            };

            panel1.SuspendLayout();
            menuRolavel.SuspendLayout();

            try
            {
                foreach (Control controle in controlesAtuais)
                    menuRolavel.Controls.Add(controle);

                for (int i = 0; i < controlesAtuais.Length; i++)
                {
                    menuRolavel.Controls.SetChildIndex(
                        controlesAtuais[i], i);
                }

                panel1.AutoScroll = false;

                btnLogoff = new Button
                {
                    Name = "btnLogoff",
                    Text = "SAIR DA CONTA",
                    Dock = DockStyle.Bottom,
                    Height = 60,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = panel1.BackColor,
                    ForeColor = Color.White,
                    Font = btn_cadastro.Font,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(14, 0, 0, 0),
                    UseVisualStyleBackColor = false
                };

                btnLogoff.FlatAppearance.BorderSize = 0;

                btnLogoff.FlatAppearance.MouseOverBackColor =
                    Color.FromArgb(24, 70, 115);

                btnLogoff.Click += btnLogoff_Click;

                panel1.Controls.Add(menuRolavel);
                panel1.Controls.Add(btnLogoff);

                panel1.Controls.SetChildIndex(menuRolavel, 0);
                panel1.Controls.SetChildIndex(btnLogoff, 1);
            }
            finally
            {
                menuRolavel.ResumeLayout(true);
                panel1.ResumeLayout(true);
            }
        }

        private static void ColetarFormularios(
            Control raiz, List<Form> formularios)
        {
            foreach (Control controle in raiz.Controls)
            {
                ColetarFormularios(controle, formularios);

                var formulario = controle as Form;

                if (formulario != null &&
                    !formulario.IsDisposed)
                {
                    formularios.Add(formulario);
                }
            }
        }

        private void btnLogoff_Click(
            object sender, EventArgs e)
        {
            if (processandoLogoff)
                return;

            processandoLogoff = true;
            btnLogoff.Enabled = false;

            try
            {
                var formularios = new List<Form>();
                ColetarFormularios(this, formularios);

                foreach (Form formulario in formularios)
                {
                    if (formulario.IsDisposed)
                        continue;

                    formulario.Close();

                    // Respeita o cancelamento feito pelo formulário.
                    if (!formulario.IsDisposed)
                        return;
                }

                SolicitouLogoff = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "Não foi possível sair da conta: " + ex.Message,
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                // Se algum fechamento foi cancelado,
                // o dashboard continua com a sessão atual.
                if (!IsDisposed)
                {
                    SolicitouLogoff = false;
                    processandoLogoff = false;
                    btnLogoff.Enabled = true;
                }
            }
        }

        // Evento associado no Designer.
        private void pnl_tudo_Paint(
            object sender, PaintEventArgs e)
        {
        }
    }
}