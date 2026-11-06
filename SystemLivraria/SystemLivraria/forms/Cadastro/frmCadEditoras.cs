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
    public partial class frmCadEditoras : Form
    {
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        // Variável para guardar o ID da editora selecionada para edição/exclusão
        private int? idEditoraSelecionada = null;

        // Flag para impedir que o evento TextChanged dispare quando preenchemos os campos via código
        private bool carregandoDados = false;

        public frmCadEditoras()
        {
            InitializeComponent();

            // Vinculando eventos necessários via código
            this.Load += frmCadEditoras_Load;
            this.dataGridView1.CellClick += dataGridView1_CellClick;

            this.txt_nome.TextChanged += Campos_TextChanged;
            this.txt_email.TextChanged += Campos_TextChanged;
            this.txt_site.TextChanged += Campos_TextChanged;
            this.txt_telefone.TextChanged += Campos_TextChanged;

            // Formatação do telefone ao sair do campo
            this.txt_telefone.Leave += txt_telefone_Leave;


        }

        private void frmCadEditoras_Load(object sender, EventArgs e)
        {
            CarregarTabela();
            EstadoInicial();
        }

        // Define o estado padrão (ao abrir ou após limpar/salvar)
        private void EstadoInicial()
        {
            LimparCampos();
            dataGridView1.ClearSelection();
            idEditoraSelecionada = null;

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
                botao.BackColor = Color.FromArgb(16, 50, 86); // Sua cor padrão de fundo
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
            carregandoDados = true;
            txt_nome.Clear();
            txt_email.Clear();
            txt_site.Clear();
            txt_telefone.Clear();
            carregandoDados = false;
        }

        // Função de formatação do telefone
        private string FormatarTelefone(string telefone)
        {
            // remove oq nao é numero
            string numeros = new string(Array.FindAll(telefone.ToCharArray(), char.IsDigit));

            if (numeros.Length == 11)
            {
                //formato com 9 dígitos: (xx) xxxxx-xxxx
                return Convert.ToInt64(numeros).ToString(@"(00) 00000-0000");
            }
            else if (numeros.Length == 10)
            {
                //formato com 8 digitos: (xx) xxxx-xxxx
                return Convert.ToInt64(numeros).ToString(@"(00) 0000-0000");
            }

            //Se não tiver 10 ou 11 dígitos, retorna como o usuário digitou
            return telefone;
        }

        private void txt_telefone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_telefone.Text))
            {
                txt_telefone.Text = FormatarTelefone(txt_telefone.Text);
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (btn_adicionar.Tag is bool habilitado && !habilitado) return;

            if (string.IsNullOrWhiteSpace(txt_nome.Text) || string.IsNullOrWhiteSpace(txt_telefone.Text))
            {
                MessageBox.Show("Preencha os campos obrigatórios para adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string telefoneFormatado = FormatarTelefone(txt_telefone.Text);

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
                    cmd.Parameters.AddWithValue("@Telefone", telefoneFormatado);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Editora cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar editora: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (btn_salvar.Tag is bool habilitado && !habilitado) return;
            if (idEditoraSelecionada == null) return;

            string telefoneFormatado = FormatarTelefone(txt_telefone.Text);

            string sql = @"UPDATE Editoras SET Nome_Edi = @Nome, Email_Edi = @Email, Site_Edi = @Site, Telefone_Edi = @Telefone WHERE Id_Edi = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Site", txt_site.Text);
                    cmd.Parameters.AddWithValue("@Telefone", telefoneFormatado);
                    cmd.Parameters.AddWithValue("@Id", idEditoraSelecionada.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Editora atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar editora: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                carregandoDados = true;
                idEditoraSelecionada = Convert.ToInt32(row.Cells[0].Value); // Id_Edi
                txt_nome.Text = row.Cells[1].Value.ToString();               // Nome_Edi
                txt_email.Text = row.Cells[2].Value.ToString();              // Email_Edi
                txt_site.Text = row.Cells[3].Value.ToString();               // Site_Edi
                txt_telefone.Text = row.Cells[4].Value.ToString();           // Telefone_Edi
                carregandoDados = false;

                // Regras quando seleciona uma linha:
                // - Adicionar desativado (cinza)
                // - Salvar continua desativado (cinza) até que edite algo
                // - Limpar ativado
                DefinirEstadoBotao(btn_adicionar, false);
                DefinirEstadoBotao(btn_salvar, false);
                DefinirEstadoBotao(btn_limpar, true);
            }
        }

        private void Campos_TextChanged(object sender, EventArgs e)
        {
            if (carregandoDados) return;

            // Se há uma editora selecionada e o usuário alterou algum texto, habilita o botão salvar
            if (idEditoraSelecionada != null)
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
            if (dataGridView1.CurrentRow == null || idEditoraSelecionada == null)
            {
                MessageBox.Show("Selecione uma editora para excluir.");
                return;
            }

            int id = idEditoraSelecionada.Value;

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir esta editora?",
                "Excluir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                string sql = "DELETE FROM Editoras WHERE Id_Edi = @Id";

                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Editora excluída com sucesso!");

                        EstadoInicial();
                        CarregarTabela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir editora: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
    }
}