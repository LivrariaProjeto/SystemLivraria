using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmCadClientes : Form
    {
        // Obtém a conexão diretamente do App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        public frmCadClientes()
        {
            InitializeComponent();
        }

        private void frmCadClientes_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Cliente (Nome_Cli, Tel_Cli, CPF_Cli, Email_Cli, Endereco_Cli)
                            VALUES (@Nome, @Telefone, @CPF, @Email, @Endereco)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txt_telefone.Text);
                    cmd.Parameters.AddWithValue("@CPF", txt_cpf.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Endereco", txt_endereco.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTabela()
        {
            string sql = "SELECT Id_Cli, Nome_Cli, Tel_Cli, CPF_Cli, Email_Cli, Endereco_Cli FROM Cliente";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conexao))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
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
            txt_telefone.Clear();
            txt_cpf.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
    }
}