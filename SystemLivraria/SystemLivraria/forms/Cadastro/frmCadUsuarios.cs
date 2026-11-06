using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SystemLivraria.classes;

namespace SystemLivraria.forms
{
    public sealed class frmCadUsuarios : Form
    {
        private readonly int administrador;

        private int? selecionado;
        private bool ocupado;

        private readonly Color azul = Color.FromArgb(16, 50, 86);
        private readonly TableLayoutPanel layout =
            new TableLayoutPanel();

        private readonly ComboBox funcionario = new ComboBox();
        private readonly ComboBox nivel = new ComboBox();
        private readonly TextBox login = new TextBox();
        private readonly TextBox senha = new TextBox();
        private readonly TextBox confirmacao = new TextBox();
        private readonly CheckBox ativo = new CheckBox();
        private readonly CheckBox mostrar = new CheckBox();
        private readonly Label estado = new Label();
        private readonly DataGridView grade = new DataGridView();

        private Button salvar;
        private Button redefinir;

        public frmCadUsuarios(int idAdministrador)
        {
            administrador = idAdministrador;

            Text = "Gerenciamento de usuários";
            BackColor = Color.Silver;
            Font = new Font("Segoe UI", 11.25f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 600);
            MinimumSize = new Size(850, 540);

            MontarTela();

            Load += delegate
            {
                Executar(() =>
                {
                    nivel.DataSource =
                        UsuariosService.Permissoes(administrador);

                    Recarregar();
                });
            };

            FormClosing += delegate (
                object sender, FormClosingEventArgs e)
            {
                if (ocupado)
                    e.Cancel = true;
            };
        }

        private Button Botao(
            string texto, int largura, EventHandler evento)
        {
            var b = new ButtonPersonalizado
            {
                Text = texto,
                Width = largura,
                Height = 40,
                BackColor = azul,
                ForeColor = Color.White,
                Font = new Font(
                    "Century Gothic", 11, FontStyle.Bold),
                BorderRadius = 20,
                UseVisualStyleBackColor = false
            };

            b.Click += evento;
            return b;
        }

        private Control Campo(
            string titulo, Control controle, int largura)
        {
            var p = new Panel
            {
                Width = largura,
                Height = 70,
                Margin = new Padding(3, 0, 12, 0)
            };

            p.Controls.Add(new Label
            {
                Text = titulo,
                AutoSize = true,
                ForeColor = azul,
                Font = new Font(
                    "Century Gothic", 11, FontStyle.Bold),
                Location = new Point(0, 2)
            });

            controle.SetBounds(0, 29, largura, 28);
            controle.BackColor = Color.Silver;
            p.Controls.Add(controle);

            return p;
        }

        private FlowLayoutPanel Linha()
        {
            return new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                AutoScroll = true
            };
        }

        private void MontarTela()
        {
            layout.Dock = DockStyle.Fill;
            layout.Padding = new Padding(12);
            layout.ColumnCount = 1;
            layout.RowCount = 6;

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            foreach (int altura in new[] { 44, 76, 76, 76, 52 })
                layout.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, altura));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Controls.Add(layout);

            layout.Controls.Add(new Label
            {
                Text = Text,
                Dock = DockStyle.Fill,
                ForeColor = azul,
                Font = new Font(
                    "Century Gothic", 16, FontStyle.Bold)
            }, 0, 0);

            foreach (var combo in new[] { funcionario, nivel })
            {
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.AutoCompleteSource =
                    AutoCompleteSource.ListItems;
                combo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
            }

            funcionario.DisplayMember = "Rotulo";
            funcionario.ValueMember = "Id_Funci";

            nivel.DisplayMember = "Nome_Permi";
            nivel.ValueMember = "Id_Permi";

            var vinculo = Linha();
            vinculo.Controls.Add(
                Campo("Funcionário *", funcionario, 510));
            vinculo.Controls.Add(
                Campo("Permissão *", nivel, 280));

            layout.Controls.Add(vinculo, 0, 1);

            login.MaxLength = 50;

            ativo.Text = "Conta ativa";
            ativo.Width = 150;
            ativo.Height = 55;
            ativo.Margin = new Padding(12, 15, 6, 0);

            estado.Width = 400;
            estado.Height = 68;
            estado.ForeColor = azul;

            var acesso = Linha();
            acesso.Controls.Add(Campo("Login *", login, 300));
            acesso.Controls.Add(ativo);
            acesso.Controls.Add(estado);

            layout.Controls.Add(acesso, 0, 2);

            senha.MaxLength = confirmacao.MaxLength = 128;
            senha.UseSystemPasswordChar =
                confirmacao.UseSystemPasswordChar = true;

            mostrar.Text = "Mostrar senha";
            mostrar.AutoSize = true;
            mostrar.Margin = new Padding(8, 30, 0, 0);

            mostrar.CheckedChanged += delegate
            {
                senha.UseSystemPasswordChar =
                    confirmacao.UseSystemPasswordChar =
                    !mostrar.Checked;
            };

            var senhas = Linha();

            senhas.Controls.Add(
                Campo("Senha (8 a 128 caracteres)", senha, 300));

            senhas.Controls.Add(
                Campo("Confirmar senha", confirmacao, 300));

            senhas.Controls.Add(mostrar);
            layout.Controls.Add(senhas, 0, 3);

            var botoes = Linha();

            botoes.Controls.Add(
                Botao("Novo", 120, delegate
                {
                    Executar(Novo);
                }));

            salvar = Botao("Cadastrar", 150, Salvar);
            redefinir = Botao("Redefinir senha", 185, Redefinir);

            botoes.Controls.Add(salvar);
            botoes.Controls.Add(redefinir);

            botoes.Controls.Add(
                Botao("Atualizar lista", 170, delegate
                {
                    Executar(Recarregar);
                }));

            botoes.Controls.Add(
                Botao("Fechar", 120, delegate
                {
                    Close();
                }));

            layout.Controls.Add(botoes, 0, 4);

            grade.Dock = DockStyle.Fill;
            grade.ReadOnly = true;

            grade.AllowUserToAddRows =
                grade.AllowUserToDeleteRows = false;

            grade.MultiSelect = false;
            grade.RowHeadersVisible = false;

            grade.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            grade.AutoGenerateColumns = false;
            grade.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            grade.BackgroundColor = Color.LightGray;
            grade.EnableHeadersVisualStyles = false;
            grade.ColumnHeadersDefaultCellStyle.BackColor = azul;
            grade.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            grade.DefaultCellStyle.SelectionBackColor = azul;
            grade.DefaultCellStyle.SelectionForeColor =
                Color.White;

            grade.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_Usu",
                HeaderText = "Código",
                FillWeight = 55
            });

            grade.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome_Funci",
                HeaderText = "Funcionário",
                FillWeight = 220
            });

            grade.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Login_usu",
                HeaderText = "Login",
                FillWeight = 120
            });

            grade.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome_Permi",
                HeaderText = "Permissão",
                FillWeight = 115
            });

            grade.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Ativo_usu",
                HeaderText = "Ativo",
                FillWeight = 55
            });

            grade.CellClick += Selecionar;
            layout.Controls.Add(grade, 0, 5);
        }

        private void Novo()
        {
            selecionado = null;

            funcionario.DataSource =
                UsuariosService.FuncionariosDisponiveis(
                    administrador);

            funcionario.SelectedIndex = -1;
            funcionario.Enabled = true;
            nivel.SelectedIndex = -1;

            login.Clear();
            senha.Clear();
            confirmacao.Clear();

            senha.Enabled =
                confirmacao.Enabled =
                mostrar.Enabled = true;

            mostrar.Checked = false;
            ativo.Checked = true;

            salvar.Text = "Cadastrar";
            salvar.Enabled = funcionario.Items.Count > 0;
            redefinir.Enabled = false;

            estado.Text = funcionario.Items.Count == 0
                ? "Todos os funcionários já possuem conta. " +
                  "Cadastre outro funcionário para criar um novo acesso."
                : "Novo usuário. Selecione um funcionário sem conta.";

            grade.ClearSelection();
        }

        private void Recarregar()
        {
            grade.DataSource =
                UsuariosService.Listar(administrador);

            Novo();
        }

        private void Selecionar(
            object sender, DataGridViewCellEventArgs e)
        {
            if (ocupado || e.RowIndex < 0)
                return;

            var linha = grade.Rows[e.RowIndex]
                .DataBoundItem as DataRowView;

            if (linha == null)
                return;

            selecionado = Convert.ToInt32(linha["Id_Usu"]);

            var vinculo = new DataTable();
            vinculo.Columns.Add("Id_Funci", typeof(int));
            vinculo.Columns.Add("Rotulo", typeof(string));

            vinculo.Rows.Add(
                linha["Id_Funci"],
                linha["Id_Funci"] + " - " + linha["Nome_Funci"]);

            funcionario.DataSource = vinculo;
            funcionario.SelectedIndex = 0;
            funcionario.Enabled = false;

            nivel.SelectedValue =
                Convert.ToInt32(linha["Id_Permi"]);

            login.Text =
                Convert.ToString(linha["Login_usu"]);

            ativo.Checked =
                Convert.ToBoolean(linha["Ativo_usu"]);

            senha.Clear();
            confirmacao.Clear();
            mostrar.Checked = false;

            senha.Enabled =
                confirmacao.Enabled =
                mostrar.Enabled = false;

            salvar.Text = "Salvar alterações";
            salvar.Enabled = redefinir.Enabled = true;

            estado.Text =
                "Editando usuário " + selecionado +
                ". Para trocar a senha, use Redefinir senha.";
        }

        private void Salvar(object sender, EventArgs e)
        {
            Executar(() =>
            {
                if (nivel.SelectedIndex < 0)
                    throw new InvalidOperationException(
                        "Selecione a permissão.");

                if (selecionado.HasValue)
                {
                    UsuariosService.Alterar(
                        administrador,
                        selecionado.Value,
                        login.Text,
                        Convert.ToInt32(nivel.SelectedValue),
                        ativo.Checked);
                }
                else
                {
                    if (funcionario.SelectedIndex < 0)
                        throw new InvalidOperationException(
                            "Selecione o funcionário.");

                    if (senha.Text != confirmacao.Text)
                        throw new InvalidOperationException(
                            "As senhas não conferem.");

                    UsuariosService.Cadastrar(
                        administrador,
                        Convert.ToInt32(funcionario.SelectedValue),
                        login.Text,
                        Convert.ToInt32(nivel.SelectedValue),
                        ativo.Checked,
                        senha.Text);
                }

                senha.Clear();
                confirmacao.Clear();

                MessageBox.Show(
                    this,
                    "Usuário salvo com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Recarregar();
            });
        }

        private void Redefinir(object sender, EventArgs e)
        {
            if (!selecionado.HasValue || ocupado)
                return;

            int id = selecionado.Value;

            using (var dialogo = new frmSenhaUsuario(login.Text))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                    return;

                string nova = dialogo.NovaSenha;

                Executar(() =>
                {
                    UsuariosService.RedefinirSenha(
                        administrador, id, nova);

                    MessageBox.Show(
                        this,
                        "Senha redefinida com sucesso.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                });
            }
        }

        private bool Executar(Action acao)
        {
            if (ocupado)
                return false;

            bool fechar = false;

            ocupado = true;
            layout.Enabled = false;
            UseWaitCursor = true;

            try
            {
                acao();
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                Avisar(ex.Message);
                fechar = true;
                return false;
            }
            catch (SqlException ex)
            {
                Avisar(
                    ex.Number == 2601 || ex.Number == 2627
                    ? "O login já existe ou o funcionário já " +
                      "possui uma conta. Atualize a lista."
                    : "Não foi possível concluir a operação: " +
                      ex.Message);

                return false;
            }
            catch (Exception ex)
            {
                Avisar(ex.Message);
                return false;
            }
            finally
            {
                ocupado = false;
                layout.Enabled = true;
                UseWaitCursor = false;

                if (fechar)
                    BeginInvoke(new Action(Close));
            }
        }

        private void Avisar(string mensagem)
        {
            MessageBox.Show(
                this,
                mensagem,
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    internal sealed class frmSenhaUsuario : Form
    {
        private readonly TextBox senha = new TextBox();
        private readonly TextBox confirmar = new TextBox();

        internal string NovaSenha
        {
            get { return senha.Text; }
        }

        internal frmSenhaUsuario(string login)
        {
            Text = "Redefinir senha - " + login;
            ClientSize = new Size(460, 225);
            BackColor = Color.Silver;
            Font = new Font("Segoe UI", 11.25f);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = MinimizeBox = false;

            Controls.Add(new Label
            {
                Text = "Nova senha (8 a 128 caracteres)",
                AutoSize = true,
                Location = new Point(20, 15)
            });

            senha.SetBounds(20, 43, 420, 28);
            Controls.Add(senha);

            Controls.Add(new Label
            {
                Text = "Confirmar nova senha",
                AutoSize = true,
                Location = new Point(20, 85)
            });

            confirmar.SetBounds(20, 113, 420, 28);
            Controls.Add(confirmar);

            senha.MaxLength = confirmar.MaxLength = 128;
            senha.UseSystemPasswordChar =
                confirmar.UseSystemPasswordChar = true;

            var salvar = new ButtonPersonalizado
            {
                Text = "Confirmar",
                BackColor = Color.FromArgb(16, 50, 86),
                ForeColor = Color.White,
                BorderRadius = 20,
                Location = new Point(20, 165),
                Size = new Size(180, 40),
                UseVisualStyleBackColor = false
            };

            salvar.Click += delegate
            {
                try
                {
                    SenhaUsuarios.ValidarNova(senha.Text);

                    if (senha.Text != confirmar.Text)
                        throw new InvalidOperationException(
                            "As senhas não conferem.");

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            };

            var cancelar = new ButtonPersonalizado
            {
                Text = "Cancelar",
                BackColor = Color.FromArgb(16, 50, 86),
                ForeColor = Color.White,
                BorderRadius = 20,
                Location = new Point(220, 165),
                Size = new Size(180, 40),
                DialogResult = DialogResult.Cancel,
                UseVisualStyleBackColor = false
            };

            Controls.Add(salvar);
            Controls.Add(cancelar);

            AcceptButton = salvar;
            CancelButton = cancelar;
        }
    }
}