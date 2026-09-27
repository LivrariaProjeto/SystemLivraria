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
    public partial class frmCadFuncionarios : Form
    {
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.LIVRARIAConnectionString"].ConnectionString;
        public frmCadFuncionarios()
        {
            InitializeComponent();
        }

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSet2.Funcionarios'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionariosTableAdapter.Fill(this.dataSet2.Funcionarios);
            // TODO: esta linha de código carrega dados na tabela 'dataSet2.Produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.dataSet2.Produtos);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl__Click(object sender, EventArgs e)
        {

        }

        private void txtnome_Funcionarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalvar_Funcionarios_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Funcionarios (Nome_Funci, CPF_funci, Cargo_Funci, DataAdmissao_Funci, Email_Funci, Tel_Funci)
                            VALUES (@Nome, @CPF, @Cargo, @DataAdmissao, @Email, @Telefone)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@CPF", txt_cpf.Text);
                    cmd.Parameters.AddWithValue("@Cargo", txt_cargo.Text);
                    cmd.Parameters.AddWithValue("@DataAdmissao", txt_dataadmissao.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txt_telefone.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Autor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionario: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTabela()
        {
            string sql = "SELECT Id_Funci, Nome_Funci, CPF_funci, Cargo_Funci, DataAdmissao_Funci, Email_Funci, Tel_Funci FROM Funcionarios";

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
            txt_cargo.Clear();
            txt_cpf.Clear();
            txt_dataadmissao.Clear();
            txt_email.Clear();
            txt_telefone.Clear();
            txt_nome.Clear();
        }

        private void frmCadFuncionarios_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }
    }
}
