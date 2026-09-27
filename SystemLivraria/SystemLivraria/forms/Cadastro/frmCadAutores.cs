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
    public partial class frmCadAutores : Form
    {
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.LIVRARIAConnectionString"].ConnectionString;

        public frmCadAutores()
        {
            InitializeComponent();
        }

        //private void frmCadProdutos_Load(object sender, EventArgs e)
        //{
            // TODO: esta linha de código carrega dados na tabela 'dataSet2.Funcionarios'. Você pode movê-la ou removê-la conforme necessário.
            //this.funcionariosTableAdapter.Fill(this.dataSet2.Funcionarios);
            // TODO: esta linha de código carrega dados na tabela 'dataSet2.Autores'. Você pode movê-la ou removê-la conforme necessário.
            //this.autoresTableAdapter.Fill(this.dataSet2.Autores);
            // TODO: esta linha de código carrega dados na tabela 'dataSet2.Produtos'. Você pode movê-la ou removê-la conforme necessário.
          //  this.produtosTableAdapter.Fill(this.dataSet2.Produtos);

        //}

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

        private void frmCadAutores_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Autores (Nome_Autor, Pais_Autor)
                            VALUES (@Nome, @Pais)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Pais", txt_pais.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Autor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            string sql = "SELECT Id_Autor, Nome_Autor, Pais_Autor FROM Autores";

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
            txt_pais.Clear();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Autor_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um autor para excluir.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_Autor"].Value);

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este autor?",
                "Excluir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                string sql = "DELETE FROM Autores WHERE Id_Autor = @Id";

                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Autor excluído com sucesso!");

                        CarregarTabela();
                        LimparCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir autor: " + ex.Message);
                }
            }
        }

        private void btnSalvar_Autor_Click(object sender, EventArgs e)
        {
            btnAdicionar_Click(sender, e);
        }
    }
}
