using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmCadFuncionarios : Form
    {
        // Obtém a conexão padrão salva no App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        public frmCadFuncionarios()
        {
            InitializeComponent();
        }

        private void frmCadFuncionarios_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void btnSalvar_Funcionarios_Click(object sender, EventArgs e)
        {
            // Query ajustada com os nomes exatos do DER
            string sql = @"INSERT INTO Funcionarios 
                            (Nome_Funci, CPF_Funci, Cargo_Funci, DataAdmissao_Funci, Email_Funci, Tel_Funci)
                            VALUES 
                            (@Nome, @CPF, @Cargo, @DataAdmissao, @Email, @Telefone)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@CPF", txt_cpf.Text);
                    cmd.Parameters.AddWithValue("@Cargo", txt_cargo.Text);

                    // Trata o envio de data para garantir compatibilidade no SQL Server
                    if (DateTime.TryParse(txt_dataadmissao.Text, out DateTime dataAdmissao))
                    {
                        cmd.Parameters.AddWithValue("@DataAdmissao", dataAdmissao);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DataAdmissao", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txt_telefone.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário:\n\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTabela()
        {
            // Seleciona os campos idênticos aos definidos na tabela Funcionarios do DER
            string sql = @"SELECT Id_Funci, Nome_Funci, CPF_Funci, Cargo_Funci, 
                                  DataAdmissao_Funci, Email_Funci, Tel_Funci 
                           FROM Funcionarios";

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
            txt_cpf.Clear();
            txt_cargo.Clear();
            txt_dataadmissao.Clear();
            txt_email.Clear();
            txt_telefone.Clear();
        }

        // Métodos de evento vazios mantidos para evitar falhas de carregamento no Designer
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
        private void txtnome_Funcionarios_Paint(object sender, PaintEventArgs e) { }
    }
}