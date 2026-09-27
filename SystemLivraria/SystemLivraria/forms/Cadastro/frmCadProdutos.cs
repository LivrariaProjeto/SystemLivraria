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

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void CadProduto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nome.Text) ||
                string.IsNullOrWhiteSpace(txt_preco.Text) ||
                string.IsNullOrWhiteSpace(txt_autor.Text) ||
                string.IsNullOrWhiteSpace(txt_categoria.Text) ||
                string.IsNullOrWhiteSpace(txt_editora.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query ajustada estritamente aos nomes do DER
            string sql = @"INSERT INTO Produtos 
                            (Id_Autor, Id_Cat, ID_Edi, Nome_Pro, Preco_Pro, ISBN_Pro)
                            VALUES 
                            (@IdAutor, @IdCategoria, @IdEditora, @Nome, @Preco, @ISBN)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAutor", Convert.ToInt32(txt_autor.Text));
                    cmd.Parameters.AddWithValue("@IdCategoria", Convert.ToInt32(txt_categoria.Text));
                    cmd.Parameters.AddWithValue("@IdEditora", Convert.ToInt32(txt_editora.Text));
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Preco", Convert.ToDecimal(txt_preco.Text));
                    cmd.Parameters.AddWithValue("@ISBN", txt_isbn.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txt_categoria.Clear();
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