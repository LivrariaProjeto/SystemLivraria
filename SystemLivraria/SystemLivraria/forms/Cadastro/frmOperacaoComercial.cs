using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SystemLivraria.classes;

namespace SystemLivraria.forms
{
    public class frmOperacaoComercial : Form
    {
        internal bool EhVenda { get; private set; }

        private readonly int usuario;
        private readonly BindingList<ItemComercial> itens =
            new BindingList<ItemComercial>();
        private readonly BindingSource fonte = new BindingSource();
        private readonly CultureInfo cultura =
            CultureInfo.GetCultureInfo("pt-BR");
        private readonly Color azul = Color.FromArgb(16, 50, 86);

        private readonly ComboBox parceiro = new ComboBox();
        private readonly ComboBox produto = new ComboBox();
        private readonly DateTimePicker data = new DateTimePicker();
        private readonly NumericUpDown quantidade = new NumericUpDown();
        private readonly NumericUpDown preco = new NumericUpDown();
        private readonly CheckBox quitado = new CheckBox();
        private readonly Label estoque = new Label();
        private readonly Label total = new Label();
        private readonly DataGridView grade = new DataGridView();
        private readonly TableLayoutPanel layout = new TableLayoutPanel();

        private Button confirmar;
        private bool gravando, incerto;

        protected frmOperacaoComercial(bool venda, int idUsuario)
        {
            EhVenda = venda;
            usuario = idUsuario;

            Text = venda
                ? "Cadastro de vendas"
                : "Cadastro de compras";

            BackColor = Color.Silver;
            Font = new Font("Segoe UI", 11.25f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 600);
            MinimumSize = new Size(850, 560);

            MontarTela();

            fonte.DataSource = itens;
            grade.DataSource = fonte;

            itens.ListChanged += delegate { AtualizarTotal(); };
            produto.SelectedIndexChanged += delegate
            {
                SelecionarProduto();
            };

            Load += delegate { AtualizarListas(); };
            FormClosing += AoFechar;
            Disposed += delegate { fonte.Dispose(); };

            AtualizarTotal();
        }

        private Button Botao(string texto, EventHandler evento)
        {
            var b = new ButtonPersonalizado
            {
                Text = texto,
                Width = 175,
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
            string texto, Control controle, int largura)
        {
            var p = new Panel
            {
                Width = largura,
                Height = 70,
                Margin = new Padding(3, 0, 10, 0)
            };

            p.Controls.Add(new Label
            {
                Text = texto,
                AutoSize = true,
                ForeColor = azul,
                Font = new Font(
                    "Century Gothic", 11, FontStyle.Bold),
                Location = new Point(0, 2)
            });

            controle.Location = new Point(0, 29);
            controle.Width = largura;
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

            foreach (int altura in new[] { 38, 80, 80, 52 })
                layout.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, altura));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 60));

            Controls.Add(layout);

            layout.Controls.Add(new Label
            {
                Text = Text,
                Dock = DockStyle.Fill,
                ForeColor = azul,
                Font = new Font(
                    "Century Gothic", 16, FontStyle.Bold)
            }, 0, 0);

            foreach (var combo in new[] { parceiro, produto })
            {
                combo.DropDownStyle = ComboBoxStyle.DropDownList;

                // Primeiro configura a fonte de autocompletar
                combo.AutoCompleteSource = AutoCompleteSource.ListItems;

                // Depois habilita o autocompletar
                combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                combo.DisplayMember = "Rotulo";
            }

            parceiro.ValueMember = "Id";
            produto.ValueMember = "Id_Pro";

            data.Format = DateTimePickerFormat.Short;
            data.MaxDate = DateTime.Today;
            data.Value = DateTime.Today;

            quitado.Checked = true;
            quitado.AutoSize = false;
            quitado.Size = new Size(285, 65);
            quitado.Text = EhVenda
                ? "Recebido integralmente na data da venda"
                : "Pago integralmente na data da compra";

            var cabecalho = Linha();
            cabecalho.Controls.Add(Campo(
                EhVenda ? "Cliente *" : "Fornecedor *",
                parceiro, 340));
            cabecalho.Controls.Add(Campo("Data *", data, 140));
            cabecalho.Controls.Add(quitado);
            layout.Controls.Add(cabecalho, 0, 1);

            quantidade.Minimum = 1;
            quantidade.Maximum = int.MaxValue;
            quantidade.Value = 1;

            preco.DecimalPlaces = 2;
            preco.Minimum = 0;
            preco.Maximum = ComercialService.LimiteValor;
            preco.Enabled = !EhVenda;

            estoque.AutoSize = true;
            estoque.Margin = new Padding(4, 30, 0, 0);

            var entrada = Linha();
            entrada.Controls.Add(Campo("Produto *", produto, 340));
            entrada.Controls.Add(Campo(
                "Quantidade *", quantidade, 110));
            entrada.Controls.Add(Campo(
                "Preço unitário *", preco, 150));
            entrada.Controls.Add(estoque);
            layout.Controls.Add(entrada, 0, 2);

            var acoes = Linha();

            acoes.Controls.Add(
                Botao("Adicionar item", Adicionar));

            acoes.Controls.Add(Botao("Remover item", delegate
            {
                var item = grade.CurrentRow == null
                    ? null
                    : grade.CurrentRow.DataBoundItem as ItemComercial;

                if (item != null)
                    itens.Remove(item);
            }));

            acoes.Controls.Add(
                Botao("Atualizar listas", delegate
                {
                    AtualizarListas();
                }));

            layout.Controls.Add(acoes, 0, 3);

            grade.Dock = DockStyle.Fill;
            grade.ReadOnly = true;
            grade.AllowUserToAddRows = false;
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
            grade.DefaultCellStyle.FormatProvider = cultura;

            grade.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Produto",
                HeaderText = "Produto",
                FillWeight = 220
            });

            grade.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantidade",
                HeaderText = "Quantidade",
                FillWeight = 80
            });

            foreach (string propriedade in new[] { "Preco", "Subtotal" })
                grade.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = propriedade,
                    HeaderText = propriedade == "Preco"
                        ? "Preço unitário"
                        : "Subtotal",
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        FormatProvider = cultura
                    }
                });

            layout.Controls.Add(grade, 0, 4);

            var rodape = Linha();

            total.Width = 340;
            total.Height = 45;
            total.TextAlign = ContentAlignment.MiddleLeft;
            total.ForeColor = azul;
            total.Font = new Font(
                "Century Gothic", 14, FontStyle.Bold);

            rodape.Controls.Add(total);

            confirmar = Botao(
                EhVenda ? "Confirmar venda" : "Confirmar compra",
                Salvar);

            rodape.Controls.Add(confirmar);
            rodape.Controls.Add(
                Botao("Fechar", delegate { Close(); }));

            layout.Controls.Add(rodape, 0, 5);
        }

        private void AtualizarListas()
        {
            if (itens.Count > 0)
            {
                Avisar(
                    "Remova os itens antes de atualizar " +
                    "preços e cadastros.");
                return;
            }

            try
            {
                parceiro.DataSource =
                    ComercialService.Parceiros(EhVenda);
                produto.DataSource = ComercialService.Produtos();

                parceiro.SelectedIndex = -1;
                produto.SelectedIndex = -1;
                SelecionarProduto();
            }
            catch (Exception ex)
            {
                Avisar(
                    "Não foi possível carregar os cadastros: " +
                    ex.Message);
            }
        }

        private void SelecionarProduto()
        {
            var linha = produto.SelectedItem as DataRowView;

            if (linha == null)
            {
                preco.Value = 0;
                estoque.Text = "";
                return;
            }

            decimal valor = Convert.ToDecimal(linha["Preco_Pro"]);

            preco.Value =
                EhVenda && valor >= 0 && valor <= preco.Maximum
                ? valor
                : 0;

            estoque.Text = "Estoque total: " + linha["Disponivel"];
        }

        private void Adicionar(object sender, EventArgs e)
        {
            try
            {
                Validate();

                var linha = produto.SelectedItem as DataRowView;

                if (linha == null)
                    throw new InvalidOperationException(
                        "Selecione um produto.");

                var item = new ItemComercial
                {
                    IdProduto = Convert.ToInt32(linha["Id_Pro"]),
                    Produto = Convert.ToString(linha["Rotulo"]),
                    Quantidade = decimal.ToInt32(quantidade.Value),
                    Preco = preco.Value
                };

                var candidatos = itens.ToList();
                candidatos.Add(item);

                ComercialService.ValidarItens(candidatos);

                if (EhVenda &&
                    item.Quantidade >
                    Convert.ToInt64(linha["Disponivel"]))
                    throw new InvalidOperationException(
                        "Quantidade maior que o estoque exibido. " +
                        "Atualize a lista se houve uma entrada recente.");

                itens.Add(item);
                quantidade.Value = 1;
            }
            catch (Exception ex)
            {
                Avisar(ex.Message);
            }
        }

        private void AtualizarTotal()
        {
            total.Text = "Total: " +
                itens.Sum(i => i.Subtotal).ToString("C2", cultura);

            if (confirmar != null)
                confirmar.Enabled =
                    itens.Count > 0 && !gravando && !incerto;
        }

        private void Salvar(object sender, EventArgs e)
        {
            if (gravando || incerto)
                return;

            try
            {
                if (parceiro.SelectedIndex < 0)
                    throw new InvalidOperationException(
                        EhVenda
                            ? "Selecione o cliente."
                            : "Selecione o fornecedor.");

                gravando = true;
                layout.Enabled = false;
                UseWaitCursor = true;

                int id = ComercialService.Registrar(
                    EhVenda,
                    Convert.ToInt32(parceiro.SelectedValue),
                    usuario,
                    data.Value.Date,
                    quitado.Checked,
                    itens.ToList());

                itens.Clear();

                MessageBox.Show(
                    this,
                    (EhVenda ? "Venda " : "Compra ") +
                    id + " registrada com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                AtualizarListas();
            }
            catch (ResultadoIncertoException ex)
            {
                incerto = true;
                Avisar(ex.Message);
            }
            catch (SqlException ex)
            {
                Avisar(ex.Number == 1205
                    ? "A operação foi desfeita por conflito " +
                      "com outra operação. Confira os dados " +
                      "e tente novamente."
                    : "A operação não foi confirmada: " +
                      ex.Message);
            }
            catch (Exception ex)
            {
                Avisar(ex.Message);
            }
            finally
            {
                gravando = false;
                UseWaitCursor = false;
                layout.Enabled = !incerto;
                AtualizarTotal();
            }
        }

        private void Avisar(string mensagem)
        {
            MessageBox.Show(
                this, mensagem, "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void AoFechar(
            object sender, FormClosingEventArgs e)
        {
            if (gravando)
            {
                e.Cancel = true;
                return;
            }

            if (!incerto && itens.Count > 0 &&
                MessageBox.Show(
                    this,
                    "Descartar os itens ainda não confirmados?",
                    "Fechar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}