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
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        // Variável para guardar o ID do autor selecionado para edição
        private int? idAutorSelecionado = null;

        // Flag para impedir que o evento TextChanged dispare quando preenchemos os campos via código
        private bool carregandoDados = false;

        public frmCadAutores()
        {
            InitializeComponent();

            // Vinculando eventos necessários via código
            this.Load += frmCadAutores_Load;
            this.dataGridView1.CellClick += dataGridView1_CellClick;
            this.txt_nome.TextChanged += Campos_TextChanged;
            this.txt_pais.TextChanged += Campos_TextChanged;
        }

        private void frmCadAutores_Load(object sender, EventArgs e)
        {
            CarregarTabela();
            EstadoInicial();
        }

        // Define o estado padrão (ao abrir ou após limpar/salvar)
        private void EstadoInicial()
        {
            LimparCampos();
            dataGridView1.ClearSelection();
            idAutorSelecionado = null;

            // Estados iniciais: Adicionar liberado, Salvar e Limpar desativados (cinza com texto branco)
            DefinirEstadoBotao(btn_adicionar, true);
            DefinirEstadoBotao(btn_salvar, false);
            DefinirEstadoBotao(btn_limpar, false);
        }

        // Método auxiliar para colorir e controlar visualmente os botões mantendo o texto branco
        private void DefinirEstadoBotao(Button botao, bool habilitado)
        {
            botao.Tag = habilitado; // Guarda o estado lógico
            if (habilitado)
            {
                botao.BackColor = Color.FromArgb(16, 50, 86); // Sua cor normal de fundo
                botao.ForeColor = Color.White;
            }
            else
            {
                botao.BackColor = Color.Gray; // Cinza quando desativado
                botao.ForeColor = Color.White; // Texto branco
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
            carregandoDados = true;
            txt_nome.Clear();
            txt_pais.Clear();
            carregandoDados = false;
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (btn_adicionar.Tag is bool habilitado && !habilitado) return;

            if (string.IsNullOrWhiteSpace(txt_nome.Text) || string.IsNullOrWhiteSpace(txt_pais.Text))
            {
                MessageBox.Show("Preencha todos os campos para adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar autor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (btn_salvar.Tag is bool habilitado && !habilitado) return;
            if (idAutorSelecionado == null) return;

            string sql = @"UPDATE Autores SET Nome_Autor = @Nome, Pais_Autor = @Pais WHERE Id_Autor = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Pais", txt_pais.Text);
                    cmd.Parameters.AddWithValue("@Id", idAutorSelecionado.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Autor atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar autor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de clique na tabela para preencher os campos
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                carregandoDados = true;
                idAutorSelecionado = Convert.ToInt32(row.Cells[0].Value);
                txt_nome.Text = row.Cells[1].Value.ToString();
                txt_pais.Text = row.Cells[2].Value.ToString();
                carregandoDados = false;

                // Regras quando seleciona uma linha:
                // - Adicionar desativado (cinza)
                // - Salvar continua desativado (cinza) até editar algo
                // - Limpar ativado
                DefinirEstadoBotao(btn_adicionar, false);
                DefinirEstadoBotao(btn_salvar, false);
                DefinirEstadoBotao(btn_limpar, true);
            }
        }

        // Monitora se o usuário digitou/editou algo nos TextBoxes
        private void Campos_TextChanged(object sender, EventArgs e)
        {
            if (carregandoDados) return;

            // Se há uma linha selecionada e o usuário alterou algum texto, habilita o botão salvar
            if (idAutorSelecionado != null)
            {
                DefinirEstadoBotao(btn_salvar, true);
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            if (btn_limpar.Tag is bool habilitado && !habilitado) return;
            EstadoInicial();
        }

        private void btnExcluir_Autor_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || idAutorSelecionado == null)
            {
                MessageBox.Show("Selecione um autor para excluir.");
                return;
            }

            int id = idAutorSelecionado.Value;

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

                        EstadoInicial();
                        CarregarTabela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir autor: " + ex.Message);
                }
            }
        }

        // Outros eventos gerados automaticamente
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
    }
}