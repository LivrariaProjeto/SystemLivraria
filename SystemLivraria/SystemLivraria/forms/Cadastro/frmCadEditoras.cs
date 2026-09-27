using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmCadEditoras : Form
    {
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;
        public frmCadEditoras()
        {
            InitializeComponent();
        }

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Editoras (Nome_Edi, Email_Edi, Site_Edi, Telefone_Edi)
                            VALUES (@Nome, @Email, @Site, @Telefone)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Site", txt_site.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txt_telefone.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Editora cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar editora: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTabela()
        {
            string sql = "SELECT Id_Edi, Nome_Edi, Email_Edi, Site_Edi, Telefone_Edi FROM Editoras";

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
            txt_email.Clear();
            txt_site.Clear();
            txt_telefone.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
    }
}
