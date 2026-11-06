using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmCadProdutos : Form
    {
        // Conexão lida a partir do App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        // Variável para guardar o ID do produto selecionado para edição/exclusão
        private int? idProdutoSelecionado = null;

        // Flag para impedir que o evento TextChanged dispare quando preenchemos os campos via código
        private bool carregandoDados = false;

        public frmCadProdutos()
        {
            InitializeComponent();

            // Vinculando eventos necessários via código
            this.Load += frmCadProdutos_Load;
            this.dataGridView1.CellClick += dataGridView1_CellClick;

            this.txt_nome.TextChanged += Campos_TextChanged;
            this.txt_autor.TextChanged += Campos_TextChanged;
            this.cbo_categoria.SelectedIndexChanged += Campos_TextChanged;
            this.txt_editora.TextChanged += Campos_TextChanged;
            this.txt_preco.TextChanged += Campos_TextChanged;
            this.txt_isbn.TextChanged += Campos_TextChanged;
        }

        // Gêneros/categorias de livro (mesmos nomes cadastrados na tabela Categorias)
        private static readonly string[] Generos = new string[]
        {
            "Romance", "Drama", "Terror", "Suspense", "Fantasia",
            "Ficção Científica", "Policial", "Aventura", "Comédia", "Poesia",
            "História", "Filosofia", "Sociologia", "Direito", "Economia"
        };

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            cbo_categoria.Items.Clear();
            cbo_categoria.Items.AddRange(Generos);
            cbo_categoria.SelectedIndex = -1;

            CarregarTabela();
            EstadoInicial();
        }

        // Define o estado padrão (ao abrir ou após limpar/salvar)
        private void EstadoInicial()
        {
            LimparCampos();
            dataGridView1.ClearSelection();
            idProdutoSelecionado = null;

            // Estados iniciais: Adicionar liberado, Salvar e Limpar desativados (cinza com texto branco)
            DefinirEstadoBotao(btn_adicionar, true); // Ajuste para 'CadProduto' se o seu botão se chamar assim no designer
            DefinirEstadoBotao(btn_salvar, false);
            DefinirEstadoBotao(btn_limpar, false);
        }

        // Método auxiliar para colorir e controlar visualmente os botões mantendo o texto branco
        private void DefinirEstadoBotao(Button botao, bool habilitado)
        {
            if (botao == null) return;
            botao.Tag = habilitado; // Guarda o estado lógico
            if (habilitado)
            {
                botao.BackColor = Color.FromArgb(16, 50, 86); // Sua cor padrão de fundo
                botao.ForeColor = Color.White;
            }
            else
            {
                botao.BackColor = Color.Gray; // Cinza quando desativado
                botao.ForeColor = Color.White; // Texto branco
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (btn_adicionar.Tag is bool habilitado && !habilitado) return; // Substitua btn_adicionar por CadProduto se necessário

            if (string.IsNullOrWhiteSpace(txt_nome.Text) ||
                string.IsNullOrWhiteSpace(txt_preco.Text) ||
                string.IsNullOrWhiteSpace(txt_autor.Text) ||
                cbo_categoria.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txt_editora.Text))
            {
                MessageBox.Show(
                    "Por favor, preencha todos os campos obrigatórios.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal preco;

            if (!decimal.TryParse(
                txt_preco.Text,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                out preco))
            {
                MessageBox.Show(
                    "Digite um preço válido. Exemplo: 49,90",
                    "Preço inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string sql = "sp_CadastrarProdutoPorNome";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nome_Pro", SqlDbType.VarChar, 150)
                        .Value = txt_nome.Text.Trim();

                    cmd.Parameters.Add("@Nome_Autor", SqlDbType.VarChar, 100)
                        .Value = txt_autor.Text.Trim();

                    cmd.Parameters.Add("@Nome_Cat", SqlDbType.VarChar, 50)
                        .Value = cbo_categoria.SelectedItem.ToString();

                    cmd.Parameters.Add("@Nome_Edi", SqlDbType.VarChar, 100)
                        .Value = txt_editora.Text.Trim();

                    cmd.Parameters.Add("@Preco_Pro", SqlDbType.Decimal)
                        .Value = preco;

                    cmd.Parameters["@Preco_Pro"].Precision = 10;
                    cmd.Parameters["@Preco_Pro"].Scale = 2;

                    cmd.Parameters.Add("@ISBN_Pro", SqlDbType.VarChar, 20)
                        .Value = string.IsNullOrWhiteSpace(txt_isbn.Text)
                            ? (object)DBNull.Value
                            : txt_isbn.Text.Trim();

                    SqlParameter idProduto = cmd.Parameters.Add(
                        "@Id_Pro", SqlDbType.Int);

                    idProduto.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    int idGerado = Convert.ToInt32(idProduto.Value);

                    MessageBox.Show(
                        "Produto cadastrado com sucesso!\nID do produto: " + idGerado,
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar produto:\n" + ex.Message,
                    "Erro no banco de dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar produto:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (btn_salvar.Tag is bool habilitado && !habilitado) return;
            if (idProdutoSelecionado == null) return;

            decimal preco;
            if (!decimal.TryParse(txt_preco.Text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), out preco))
            {
                MessageBox.Show("Digite um preço válido. Exemplo: 49,90", "Preço inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exemplo de comando UPDATE direto ou procedure de atualização se houver
            string sql = @"UPDATE Produtos SET 
                            Nome_Pro = @Nome, 
                            Preco_Pro = @Preco, 
                            ISBN_Pro = @ISBN 
                           WHERE Id_Pro = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text.Trim());
                    cmd.Parameters.AddWithValue("@Preco", preco);
                    cmd.Parameters.AddWithValue("@ISBN", string.IsNullOrWhiteSpace(txt_isbn.Text) ? (object)DBNull.Value : txt_isbn.Text.Trim());
                    cmd.Parameters.AddWithValue("@Id", idProdutoSelecionado.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                carregandoDados = true;
                idProdutoSelecionado = Convert.ToInt32(row.Cells[0].Value); // Id_Pro
                txt_nome.Text = row.Cells[4].Value.ToString();             // Nome_Pro (ajuste o índice conforme sua grid)
                txt_preco.Text = row.Cells[5].Value.ToString();            // Preco_Pro
                txt_isbn.Text = row.Cells[6].Value != DBNull.Value ? row.Cells[6].Value.ToString() : string.Empty;
                carregandoDados = false;

                // Regras de estado ao clicar na linha
                DefinirEstadoBotao(btn_adicionar, false);
                DefinirEstadoBotao(btn_salvar, false);
                DefinirEstadoBotao(btn_limpar, true);
            }
        }

        private void Campos_TextChanged(object sender, EventArgs e)
        {
            if (carregandoDados) return;

            if (idProdutoSelecionado != null)
            {
                DefinirEstadoBotao(btn_salvar, true);
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            if (btn_limpar.Tag is bool habilitado && !habilitado) return;
            EstadoInicial();
        }

        private void CarregarTabela()
        {
            // Nomes idênticos aos definidos no DER
            string sql = @"SELECT Id_Pro, Id_Autor, Id_Cat, ID_Edi, Nome_Pro, Preco_Pro, ISBN_Pro 
                           FROM Produtos";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conexao))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a tabela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            carregandoDados = true;
            txt_nome.Clear();
            txt_autor.Clear();
            cbo_categoria.SelectedIndex = -1;
            txt_editora.Clear();
            txt_preco.Clear();
            txt_isbn.Clear();
            carregandoDados = false;
        }

        // Métodos preservados para evitar incompatibilidade com o Designer
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
    }
}