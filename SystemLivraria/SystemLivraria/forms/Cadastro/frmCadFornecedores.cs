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
    public partial class frmCadFornecedores : Form
    {
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.LIVRARIAConnectionString"].ConnectionString;
        public frmCadFornecedores()
        {
            InitializeComponent();
        }

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSet2.Fornecedores'. Você pode movê-la ou removê-la conforme necessário.
            this.fornecedoresTableAdapter.Fill(this.dataSet2.Fornecedores);
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

        private void btnAdicionar_Fornecedores_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Fornecedores (Nome_Forne, Endereco_Forne, CNPJ_Forne, Email_Forne)
                            VALUES (@Nome_Forne, @Endereco_Forne, @CNPJ_Forne, @Email_Forne)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome_Forne", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Endereco_Forne", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@CNPJ_Forne", txt_cnpj.Text);
                    cmd.Parameters.AddWithValue("@Email_Forne", txt_email.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTabela()
        {
            string sql = "SELECT Id_Forne, Nome_Forne, Endereco_Forne, CNPJ_Forne, Email_Forne FROM Fornecedores";

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
            txt_cnpj.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
            txt_telefone.Clear();
        }

        private void frmCadFornecedores_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

private void btnSalvar_Fornecedores_Click(object sender, EventArgs e)
        {
            btnAdicionar_Fornecedores_Click(sender, e);
        }
    }
}
