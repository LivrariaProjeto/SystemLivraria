using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmCadProdutos : Form
    {
        // Conexão lida a partir do App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        public frmCadProdutos()
        {
            InitializeComponent();
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
        }


private void CadProduto_Click(object sender, EventArgs e)
        {
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

                    LimparCampos();
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
            txt_nome.Clear();
            txt_autor.Clear();
            cbo_categoria.SelectedIndex = -1;
            txt_editora.Clear();
            txt_preco.Clear();
            txt_isbn.Clear();
        }

        // Métodos preservados para evitar incompatibilidade com o Designer
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
    }
}