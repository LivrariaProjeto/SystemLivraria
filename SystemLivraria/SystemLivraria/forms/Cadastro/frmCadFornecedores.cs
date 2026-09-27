using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmCadFornecedores : Form
    {
        // Obtém a conexão padrão centralizada no App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        public frmCadFornecedores()
        {
            InitializeComponent();
        }

        private void frmCadFornecedores_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void btnAdicionar_Fornecedores_Click(object sender, EventArgs e)
        {
            // Query adaptada conforme a tabela Fornecedores
            string sql = @"INSERT INTO Fornecedores 
                            (Nome_Forne, Endereco_Forne, CNPJ_Forne, Tel_Forne, Email_Forne)
                            VALUES 
                            (@Nome, @Endereco, @CNPJ, @Telefone, @Email)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Endereco", txt_endereco.Text);
                    cmd.Parameters.AddWithValue("@CNPJ", txt_cnpj.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txt_telefone.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar fornecedor:\n\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTabela()
        {
            // Seleciona as colunas com aliases para coincidir com as cabeçalhos do seu DataGridView
            string sql = @"SELECT 
                            Id_Forne AS Id_Forne, 
                            Nome_Forne AS Nome_Forne, 
                            Endereco_Forne AS Endereco_Forne, 
                            CNPJ_Forne AS CNPJ_Forne, 
                            Tel_Forne AS Tel_Forne, 
                            Email_Forne AS Email_Forne 
                           FROM Fornecedores";

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
            txt_endereco.Clear();
            txt_cnpj.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
        }

        // Eventos vazios preservados para garantir compatibilidade com o Designer
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
    }
}