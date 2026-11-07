using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    internal sealed class ProdutoEdicao
    {
        internal int Id, IdAutor, IdCategoria, IdEditora;
        internal string Nome, Autor, Categoria, Editora, ISBN;
        internal decimal Preco;

        internal static ProdutoEdicao DaLinha(DataRow r)
        {
            return new ProdutoEdicao
            {
                Id = Convert.ToInt32(r["Id_Pro"]),
                IdAutor = Convert.ToInt32(r["Id_Autor"]),
                IdCategoria = Convert.ToInt32(r["Id_Cat"]),
                IdEditora = Convert.ToInt32(r["Id_Edi"]),
                Nome = Convert.ToString(r["Nome_Pro"]),
                Autor = Convert.ToString(r["Nome_Autor"]),
                Categoria = Convert.ToString(r["Nome_Cat"]),
                Editora = Convert.ToString(r["Nome_Edi"]),
                Preco = Convert.ToDecimal(r["Preco_Pro"]),
                ISBN = r.IsNull("ISBN_Pro")
                    ? null
                    : Convert.ToString(r["ISBN_Pro"])
            };
        }

        internal bool ContinuaIgual(DataRow r)
        {
            return
                IdAutor == Convert.ToInt32(r["Id_Autor"]) &&
                IdCategoria == Convert.ToInt32(r["Id_Cat"]) &&
                IdEditora == Convert.ToInt32(r["Id_Edi"]) &&
                Nome == Convert.ToString(r["Nome_Pro"]) &&
                Autor == Convert.ToString(r["Nome_Autor"]) &&
                Categoria == Convert.ToString(r["Nome_Cat"]) &&
                Editora == Convert.ToString(r["Nome_Edi"]) &&
                Preco == Convert.ToDecimal(r["Preco_Pro"]) &&
                ISBN == (
                    r.IsNull("ISBN_Pro")
                        ? null
                        : Convert.ToString(r["ISBN_Pro"]));
        }

        internal static decimal LerPreco(string texto)
        {
            decimal valor;

            if (!decimal.TryParse(
                    (texto ?? "").Trim(),
                    NumberStyles.AllowDecimalPoint |
                    NumberStyles.AllowLeadingSign,
                    CultureInfo.GetCultureInfo("pt-BR"),
                    out valor) ||
                valor <= 0 ||
                valor > 99999999.99m ||
                decimal.Round(valor, 2) != valor)
            {
                throw new InvalidOperationException(
                    "Informe um preço positivo com até duas casas " +
                    "decimais. Exemplo: 49,90, sem separador de milhares.");
            }

            return valor;
        }
    }

    public partial class frmCadProdutos : Form
    {
        private readonly CultureInfo cultura =
            CultureInfo.GetCultureInfo("pt-BR");

        private ProdutoEdicao produtoSelecionado;

        private bool carregandoDados;
        private bool ocupado;
        private bool dadosProntos;

        private string Conexao
        {
            get
            {
                var c = ConfigurationManager.ConnectionStrings[
                    "SystemLivraria.Properties.Settings.db_250064ConnectionString"];

                if (c == null ||
                    string.IsNullOrWhiteSpace(c.ConnectionString))
                {
                    throw new ConfigurationErrorsException(
                        "Configure a conexão no App.config.");
                }

                return c.ConnectionString;
            }
        }

        public frmCadProdutos()
        {
            InitializeComponent();

            // Remove o cadastro associado ao clique do formulário.
            this.Click -= btn_adicionar_Click;

            // Mantém uma única associação de cada evento.
            this.Load -= frmCadProdutos_Load;
            this.Load += frmCadProdutos_Load;

            btn_adicionar.Click -= btn_adicionar_Click;
            btn_adicionar.Click += btn_adicionar_Click;

            btn_salvar.Click -= btn_salvar_Click;
            btn_salvar.Click += btn_salvar_Click;

            btn_limpar.Click -= btn_limpar_Click;
            btn_limpar.Click += btn_limpar_Click;

            dataGridView1.CellClick -= dataGridView1_CellClick;
            dataGridView1.CellClick += dataGridView1_CellClick;

            txt_nome.TextChanged += Campos_TextChanged;
            txt_autor.TextChanged += Campos_TextChanged;
            txt_editora.TextChanged += Campos_TextChanged;
            txt_preco.TextChanged += Campos_TextChanged;
            txt_isbn.TextChanged += Campos_TextChanged;
            cbo_categoria.SelectedIndexChanged += Campos_TextChanged;

            txt_nome.MaxLength = 150;
            txt_autor.MaxLength = 100;
            txt_editora.MaxLength = 100;
            txt_isbn.MaxLength = 20;

            // Preserva as colunas configuradas no Designer.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            BloquearGravacao();
        }

        private static SqlParameter P(
            string nome,
            SqlDbType tipo,
            object valor,
            int tamanho = 0)
        {
            var p = new SqlParameter(nome, tipo)
            {
                Value = valor ?? DBNull.Value
            };

            if (tamanho > 0)
                p.Size = tamanho;

            if (tipo == SqlDbType.Decimal)
            {
                p.Precision = 10;
                p.Scale = 2;
            }

            return p;
        }

        private static DataTable Consultar(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            params SqlParameter[] parametros)
        {
            using (var cmd = new SqlCommand(sql, c, t))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(parametros);

                var tabela = new DataTable();
                da.Fill(tabela);

                return tabela;
            }
        }

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            Executar(RecarregarDados);
        }

        private static void Autocompletar(
            TextBox campo,
            DataTable dados,
            string coluna)
        {
            var nomes = new AutoCompleteStringCollection();

            foreach (DataRow r in dados.Rows)
                nomes.Add(Convert.ToString(r[coluna]));

            campo.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            campo.AutoCompleteSource =
                AutoCompleteSource.CustomSource;

            campo.AutoCompleteCustomSource = nomes;
        }

        private void RecarregarDados()
        {
            dadosProntos = false;
            BloquearGravacao();
            carregandoDados = true;

            try
            {
                using (var c = new SqlConnection(Conexao))
                {
                    c.Open();

                    var categorias = Consultar(c, null, @"
SELECT Id_Cat,Nome_Cat
FROM dbo.Categorias
ORDER BY Nome_Cat;");

                    cbo_categoria.DisplayMember = "Nome_Cat";
                    cbo_categoria.ValueMember = "Id_Cat";
                    cbo_categoria.DataSource = categorias;

                    Autocompletar(
                        txt_autor,
                        Consultar(c, null, @"
SELECT Nome_Autor
FROM dbo.Autores
ORDER BY Nome_Autor;"),
                        "Nome_Autor");

                    Autocompletar(
                        txt_editora,
                        Consultar(c, null, @"
SELECT Nome_Edi
FROM dbo.Editoras
ORDER BY Nome_Edi;"),
                        "Nome_Edi");

                    dataGridView1.DataSource = Consultar(c, null, @"
SELECT
    P.Id_Pro,
    P.Id_Autor,
    P.Id_Cat,
    P.Id_Edi,
    P.Nome_Pro,
    P.Preco_Pro,
    P.ISBN_Pro,
    A.Nome_Autor,
    C.Nome_Cat,
    E.Nome_Edi
FROM dbo.Produtos P
JOIN dbo.Autores A ON A.Id_Autor=P.Id_Autor
JOIN dbo.Categorias C ON C.Id_Cat=P.Id_Cat
JOIN dbo.Editoras E ON E.Id_Edi=P.Id_Edi
ORDER BY P.Id_Pro;");
                }

                dadosProntos = true;
                EstadoInicial();
            }
            finally
            {
                carregandoDados = false;
            }
        }

        private void BloquearGravacao()
        {
            DefinirEstadoBotao(btn_adicionar, false);
            DefinirEstadoBotao(btn_salvar, false);
            DefinirEstadoBotao(btn_limpar, true);
        }

        private void EstadoInicial()
        {
            carregandoDados = true;

            try
            {
                produtoSelecionado = null;

                txt_nome.Clear();
                txt_autor.Clear();
                txt_editora.Clear();
                txt_preco.Clear();
                txt_isbn.Clear();

                cbo_categoria.SelectedIndex = -1;
                dataGridView1.ClearSelection();
            }
            finally
            {
                carregandoDados = false;
            }

            DefinirEstadoBotao(btn_adicionar, dadosProntos);
            DefinirEstadoBotao(btn_salvar, false);
            DefinirEstadoBotao(btn_limpar, false);
        }

        private void DefinirEstadoBotao(
            Button botao, bool habilitado)
        {
            // Mantém o padrão visual de texto branco do projeto.
            botao.Tag = habilitado;

            botao.BackColor = habilitado
                ? Color.FromArgb(16, 50, 86)
                : Color.Gray;

            botao.ForeColor = Color.White;
        }

        private static bool Permitido(Button botao)
        {
            return botao.Tag is bool && (bool)botao.Tag;
        }

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (ocupado ||
                !dadosProntos ||
                e.RowIndex < 0 ||
                dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            Executar(() =>
            {
                var linha = dataGridView1.Rows[e.RowIndex]
                    .DataBoundItem as DataRowView;

                if (linha == null)
                    return;

                var p = ProdutoEdicao.DaLinha(linha.Row);

                carregandoDados = true;

                try
                {
                    txt_nome.Text = p.Nome;
                    txt_autor.Text = p.Autor;
                    txt_editora.Text = p.Editora;
                    txt_preco.Text =
                        p.Preco.ToString("0.00", cultura);
                    txt_isbn.Text = p.ISBN ?? "";

                    // Seleção pelo ID real da categoria.
                    cbo_categoria.SelectedValue = p.IdCategoria;

                    if (cbo_categoria.SelectedIndex < 0)
                    {
                        throw new InvalidOperationException(
                            "A lista de categorias mudou. " +
                            "Clique em LIMPAR e selecione " +
                            "o produto novamente.");
                    }

                    produtoSelecionado = p;
                }
                catch
                {
                    EstadoInicial();
                    throw;
                }
                finally
                {
                    carregandoDados = false;
                }

                DefinirEstadoBotao(btn_adicionar, false);
                DefinirEstadoBotao(btn_salvar, false);
                DefinirEstadoBotao(btn_limpar, true);
            });
        }

        private void Campos_TextChanged(
            object sender, EventArgs e)
        {
            if (carregandoDados || ocupado || !dadosProntos)
                return;

            DefinirEstadoBotao(
                btn_salvar,
                produtoSelecionado != null);

            DefinirEstadoBotao(btn_limpar, true);
        }

        private void btn_adicionar_Click(
            object sender, EventArgs e)
        {
            if (!Permitido(btn_adicionar) ||
                produtoSelecionado != null ||
                !dadosProntos)
            {
                return;
            }

            Executar(() => Gravar(false));
        }

        private void btn_salvar_Click(
            object sender, EventArgs e)
        {
            if (!Permitido(btn_salvar) ||
                produtoSelecionado == null ||
                !dadosProntos)
            {
                return;
            }

            Executar(() => Gravar(true));
        }

        private void btn_limpar_Click(
            object sender, EventArgs e)
        {
            if (Permitido(btn_limpar))
                Executar(RecarregarDados);
        }

        private static int Resolver(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            string nome,
            string campo)
        {
            var encontrados = Consultar(
                c,
                t,
                sql,
                P("@nome", SqlDbType.VarChar, nome, 100));

            if (encontrados.Rows.Count == 0)
            {
                throw new InvalidOperationException(
                    campo + " não encontrado. Cadastre-o na " +
                    "tela correspondente ou escolha um nome existente.");
            }

            if (encontrados.Rows.Count > 1)
            {
                throw new InvalidOperationException(
                    "Existe mais de um cadastro de " + campo +
                    " com esse nome. Confira os cadastros " +
                    "antes de continuar.");
            }

            return Convert.ToInt32(encontrados.Rows[0][0]);
        }

        private void Gravar(bool editar)
        {
            string nome = txt_nome.Text.Trim();
            string autor = txt_autor.Text.Trim();
            string editora = txt_editora.Text.Trim();

            string isbn = string.IsNullOrWhiteSpace(txt_isbn.Text)
                ? null
                : txt_isbn.Text.Trim();

            if (nome.Length == 0 ||
                nome.Length > 150 ||
                autor.Length == 0 ||
                autor.Length > 100 ||
                editora.Length == 0 ||
                editora.Length > 100 ||
                cbo_categoria.SelectedIndex < 0 ||
                (isbn != null && isbn.Length > 20))
            {
                throw new InvalidOperationException(
                    "Preencha nome, autor, editora e categoria. " +
                    "Respeite os limites dos campos.");
            }

            decimal preco =
                ProdutoEdicao.LerPreco(txt_preco.Text);

            int categoria =
                Convert.ToInt32(cbo_categoria.SelectedValue);

            int id = editar ? produtoSelecionado.Id : 0;

            using (var c = new SqlConnection(Conexao))
            {
                c.Open();

                using (var t = c.BeginTransaction(
                    IsolationLevel.Serializable))
                {
                    bool confirmando = false;

                    try
                    {
                        if (editar)
                        {
                            var atual = Consultar(c, t, @"
SELECT
    P.Id_Autor,
    P.Id_Cat,
    P.Id_Edi,
    P.Nome_Pro,
    P.Preco_Pro,
    P.ISBN_Pro,
    A.Nome_Autor,
    C.Nome_Cat,
    E.Nome_Edi
FROM dbo.Produtos P WITH (UPDLOCK,HOLDLOCK)
JOIN dbo.Autores A ON A.Id_Autor=P.Id_Autor
JOIN dbo.Categorias C ON C.Id_Cat=P.Id_Cat
JOIN dbo.Editoras E ON E.Id_Edi=P.Id_Edi
WHERE P.Id_Pro=@id;",
                                P("@id", SqlDbType.Int, id));

                            if (atual.Rows.Count != 1)
                            {
                                throw new InvalidOperationException(
                                    "O produto não existe mais. " +
                                    "Clique em LIMPAR para atualizar a lista.");
                            }

                            if (!produtoSelecionado.ContinuaIgual(
                                atual.Rows[0]))
                            {
                                throw new InvalidOperationException(
                                    "O produto ou um de seus cadastros " +
                                    "relacionados foi alterado em outra tela. " +
                                    "Clique em LIMPAR e selecione-o " +
                                    "novamente antes de salvar.");
                            }
                        }

                        int idAutor = Resolver(
                            c, t, @"
SELECT Id_Autor
FROM dbo.Autores
WHERE LTRIM(RTRIM(Nome_Autor))=@nome;",
                            autor,
                            "Autor");

                        int idEditora = Resolver(
                            c, t, @"
SELECT Id_Edi
FROM dbo.Editoras
WHERE LTRIM(RTRIM(Nome_Edi))=@nome;",
                            editora,
                            "Editora");

                        var categoriaAtual = Consultar(c, t, @"
SELECT Id_Cat
FROM dbo.Categorias
WHERE Id_Cat=@id;",
                            P("@id", SqlDbType.Int, categoria));

                        if (categoriaAtual.Rows.Count != 1)
                        {
                            throw new InvalidOperationException(
                                "A categoria não existe mais. " +
                                "Atualize a lista com LIMPAR.");
                        }

                        using (var cmd = new SqlCommand(
                            editar
                                ? "dbo.sp_AlterarLivro"
                                : "dbo.sp_CadastroPro",
                            c,
                            t))
                        {
                            cmd.CommandType =
                                CommandType.StoredProcedure;

                            cmd.Parameters.Add(P(
                                editar ? "@nomepro" : "@Nomepro",
                                SqlDbType.VarChar,
                                nome,
                                150));

                            cmd.Parameters.Add(P(
                                "@autor", SqlDbType.Int, idAutor));

                            cmd.Parameters.Add(P(
                                "@categoria", SqlDbType.Int, categoria));

                            cmd.Parameters.Add(P(
                                "@editora", SqlDbType.Int, idEditora));

                            cmd.Parameters.Add(P(
                                "@preco", SqlDbType.Decimal, preco));

                            cmd.Parameters.Add(P(
                                "@isbn", SqlDbType.VarChar, isbn, 20));

                            SqlParameter saida = null;

                            if (editar)
                            {
                                cmd.Parameters.Add(P(
                                    "@idpro", SqlDbType.Int, id));
                            }
                            else
                            {
                                saida = cmd.Parameters.Add(
                                    "@Id_Pro", SqlDbType.Int);

                                saida.Direction =
                                    ParameterDirection.Output;
                            }

                            cmd.ExecuteNonQuery();

                            if (!editar)
                                id = Convert.ToInt32(saida.Value);
                        }

                        if (editar &&
                            nome != produtoSelecionado.Nome)
                        {
                            // Atualiza somente a cópia textual do nome.
                            using (var cmd = new SqlCommand(@"
UPDATE dbo.Estoque
SET Nome_Pro=@nome
WHERE Id_Pro=@id;", c, t))
                            {
                                cmd.Parameters.Add(P(
                                    "@nome",
                                    SqlDbType.VarChar,
                                    nome,
                                    150));

                                cmd.Parameters.Add(P(
                                    "@id",
                                    SqlDbType.Int,
                                    id));

                                cmd.ExecuteNonQuery();
                            }
                        }

                        confirmando = true;
                        t.Commit();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            t.Rollback();
                        }
                        catch
                        {
                        }

                        if (confirmando)
                        {
                            dadosProntos = false;
                            BloquearGravacao();

                            throw new InvalidOperationException(
                                "A resposta da confirmação foi perdida. " +
                                "Clique em LIMPAR e confira o produto " +
                                id + " antes de repetir a operação.", ex);
                        }

                        throw;
                    }
                }
            }

            EstadoInicial();

            MessageBox.Show(
                this,
                "Produto " + id +
                (editar ? " atualizado" : " cadastrado") +
                " com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            try
            {
                RecarregarDados();
            }
            catch (Exception ex)
            {
                dadosProntos = false;
                BloquearGravacao();

                throw new InvalidOperationException(
                    "O produto foi salvo, mas a lista não foi " +
                    "atualizada. Clique em LIMPAR para tentar " +
                    "novamente. " + ex.Message, ex);
            }
        }

        private void Executar(Action acao)
        {
            if (ocupado)
                return;

            ocupado = true;
            UseWaitCursor = true;

            try
            {
                acao();
            }
            catch (SqlException ex)
            {
                string mensagem =
                    ex.Number == 2601 || ex.Number == 2627
                    ? "O ISBN já está cadastrado. Se ficou vazio, " +
                      "o UNIQUE atual do banco permite somente " +
                      "um produto com ISBN nulo."
                    : ex.Number == 547
                        ? "Um dos cadastros relacionados não está " +
                          "disponível. Atualize a lista e confira " +
                          "autor, categoria e editora."
                        : ex.Message;

                MessageBox.Show(
                    this,
                    mensagem,
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
            finally
            {
                ocupado = false;
                UseWaitCursor = false;
            }
        }

        // Eventos utilizados pelo Designer atual.
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
    }
}