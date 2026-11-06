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
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        private int? idFuncionarioSelecionado = null;
        private bool carregandoDados = false;

        public frmCadFuncionarios()
        {
            InitializeComponent();

            this.Load += frmCadFuncionarios_Load;
            this.dataGridView1.CellClick += dataGridView1_CellClick;

            this.txt_nome.TextChanged += Campos_TextChanged;
            this.txt_cpf.TextChanged += Campos_TextChanged;
            this.txt_cargo.TextChanged += Campos_TextChanged;
            this.txt_dataadmissao.TextChanged += Campos_TextChanged;
            this.txt_telefone.TextChanged += Campos_TextChanged;
            this.txt_email.TextChanged += Campos_TextChanged;

            // Formatação automática ao sair dos campos (Leave)
            this.txt_telefone.Leave += txt_telefone_Leave;
            this.txt_cpf.Leave += txt_cpf_Leave;
            this.txt_dataadmissao.Leave += txt_dataadmissao_Leave; // <-- Adicionado aqui
        }

        private void frmCadFuncionarios_Load(object sender, EventArgs e)
        {
            CarregarTabela();
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            LimparCampos();
            dataGridView1.ClearSelection();
            idFuncionarioSelecionado = null;

            DefinirEstadoBotao(btn_adicionar, true);
            DefinirEstadoBotao(btn_salvar, false);
            DefinirEstadoBotao(btn_limpar, false);
        }

        private void DefinirEstadoBotao(Button botao, bool habilitado)
        {
            botao.Tag = habilitado;
            if (habilitado)
            {
                botao.BackColor = Color.FromArgb(16, 50, 86);
                botao.ForeColor = Color.White;
            }
            else
            {
                botao.BackColor = Color.Gray;
                botao.ForeColor = Color.White;
            }
        }

        private void CarregarTabela()
        {
            string sql = @"SELECT Id_Funci, Nome_Funci, CPF_Funci, Cargo_Funci, 
                                  Tel_Funci, DataAdmissao_Funci, Email_Funci 
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
            carregandoDados = true;
            txt_nome.Clear();
            txt_cpf.Clear();
            txt_cargo.Clear();
            txt_dataadmissao.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            carregandoDados = false;
        }

        private string FormatarTelefone(string telefone)
        {
            string numeros = new string(Array.FindAll(telefone.ToCharArray(), char.IsDigit));

            if (numeros.Length == 11)
            {
                return Convert.ToInt64(numeros).ToString(@"(00) 00000-0000");
            }
            else if (numeros.Length == 10)
            {
                return Convert.ToInt64(numeros).ToString(@"(00) 0000-0000");
            }

            return telefone;
        }

        private string FormatarCpf(string cpf)
        {
            string numeros = new string(Array.FindAll(cpf.ToCharArray(), char.IsDigit));

            if (numeros.Length == 11)
            {
                return Convert.ToInt64(numeros).ToString(@"000\.000\.000\-00");
            }

            return cpf;
        }

        // Função de formatação da Data (converte 15112024 em 15/11/2024)
        private string FormatarData(string data)
        {
            string numeros = new string(Array.FindAll(data.ToCharArray(), char.IsDigit));

            if (numeros.Length == 8)
            {
                string dia = numeros.Substring(0, 2);
                string mes = numeros.Substring(2, 2);
                string ano = numeros.Substring(4, 4);
                return $"{dia}/{mes}/{ano}";
            }

            return data;
        }

        private bool ValidarCpf(string cpf)
        {
            string tempCpf = new string(Array.FindAll(cpf.ToCharArray(), char.IsDigit));

            if (tempCpf.Length != 11) return false;

            bool todosIguais = true;
            for (int i = 1; i < 11; i++)
            {
                if (tempCpf[i] != tempCpf[0])
                {
                    todosIguais = false;
                    break;
                }
            }
            if (todosIguais) return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string srtCpf = tempCpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(srtCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            srtCpf = srtCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(srtCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return tempCpf.EndsWith(digito);
        }

        private void txt_telefone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_telefone.Text))
            {
                txt_telefone.Text = FormatarTelefone(txt_telefone.Text);
            }
        }

        private void txt_cpf_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_cpf.Text))
            {
                txt_cpf.Text = FormatarCpf(txt_cpf.Text);
            }
        }

        private void txt_dataadmissao_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_dataadmissao.Text))
            {
                txt_dataadmissao.Text = FormatarData(txt_dataadmissao.Text);
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (btn_adicionar.Tag is bool habilitado && !habilitado) return;

            if (string.IsNullOrWhiteSpace(txt_nome.Text) || string.IsNullOrWhiteSpace(txt_cpf.Text) || string.IsNullOrWhiteSpace(txt_telefone.Text))
            {
                MessageBox.Show("Preencha os campos obrigatórios para adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCpf(txt_cpf.Text))
            {
                MessageBox.Show("O CPF informado é inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpf.Focus();
                return;
            }

            string telefoneFormatado = FormatarTelefone(txt_telefone.Text);
            string cpfFormatado = FormatarCpf(txt_cpf.Text);
            string dataFormatadaStr = FormatarData(txt_dataadmissao.Text);

            string sql = @"INSERT INTO Funcionarios 
                (Nome_Funci, CPF_Funci, Cargo_Funci, Tel_Funci, DataAdmissao_Funci, Email_Funci)
                VALUES 
                (@Nome, @CPF, @Cargo, @Telefone, @DataAdmissao, @Email)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text.Trim());
                    cmd.Parameters.AddWithValue("@CPF", cpfFormatado);
                    cmd.Parameters.AddWithValue("@Cargo", txt_cargo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefone", telefoneFormatado);

                    if (!string.IsNullOrWhiteSpace(dataFormatadaStr) &&
                        DateTime.TryParseExact(dataFormatadaStr, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime dataAdmissao))
                    {
                        cmd.Parameters.Add("@DataAdmissao", SqlDbType.Date).Value = dataAdmissao;
                    }
                    else
                    {
                        cmd.Parameters.Add("@DataAdmissao", SqlDbType.Date).Value = DBNull.Value;
                    }

                    cmd.Parameters.AddWithValue("@Email", txt_email.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário:\n\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (btn_salvar.Tag is bool habilitado && !habilitado) return;
            if (idFuncionarioSelecionado == null) return;

            if (!ValidarCpf(txt_cpf.Text))
            {
                MessageBox.Show("O CPF informado é inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpf.Focus();
                return;
            }

            string telefoneFormatado = FormatarTelefone(txt_telefone.Text);
            string cpfFormatado = FormatarCpf(txt_cpf.Text);
            string dataFormatadaStr = FormatarData(txt_dataadmissao.Text);

            string sql = @"UPDATE Funcionarios SET 
                            Nome_Funci = @Nome, 
                            CPF_Funci = @CPF, 
                            Cargo_Funci = @Cargo,
                            Tel_Funci = @Telefone,
                            DataAdmissao_Funci = @DataAdmissao,
                            Email_Funci = @Email 
                           WHERE Id_Funci = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text.Trim());
                    cmd.Parameters.AddWithValue("@CPF", cpfFormatado);
                    cmd.Parameters.AddWithValue("@Cargo", txt_cargo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefone", telefoneFormatado);

                    if (!string.IsNullOrWhiteSpace(dataFormatadaStr) &&
                        DateTime.TryParseExact(dataFormatadaStr, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime dataAdmissao))
                    {
                        cmd.Parameters.Add("@DataAdmissao", SqlDbType.Date).Value = dataAdmissao;
                    }
                    else
                    {
                        cmd.Parameters.Add("@DataAdmissao", SqlDbType.Date).Value = DBNull.Value;
                    }

                    cmd.Parameters.AddWithValue("@Email", txt_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Id", idFuncionarioSelecionado.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Funcionário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                carregandoDados = true;
                idFuncionarioSelecionado = Convert.ToInt32(row.Cells[0].Value); // Id_Funci
                txt_nome.Text = row.Cells[1].Value.ToString();                 // Nome_Funci
                txt_cpf.Text = row.Cells[2].Value.ToString();                  // CPF_Funci
                txt_cargo.Text = row.Cells[3].Value.ToString();                // Cargo_Funci
                txt_telefone.Text = row.Cells[4].Value.ToString();             // Tel_Funci

                if (row.Cells[5].Value != DBNull.Value && DateTime.TryParse(row.Cells[5].Value.ToString(), out DateTime data))
                {
                    txt_dataadmissao.Text = data.ToString("dd/MM/yyyy");
                }
                else
                {
                    txt_dataadmissao.Text = string.Empty;
                }

                txt_email.Text = row.Cells[6].Value.ToString();                // Email_Funci
                carregandoDados = false;

                DefinirEstadoBotao(btn_adicionar, false);
                DefinirStateBotaoCustom(); // Mantém estado
                DefinirEstadoBotao(btn_salvar, false);
                DefinirEstadoBotao(btn_limpar, true);
            }
        }

        private void DefinirStateBotaoCustom() { } // Auxiliar mantido

        private void Campos_TextChanged(object sender, EventArgs e)
        {
            if (carregandoDados) return;

            if (idFuncionarioSelecionado != null)
            {
                DefinirEstadoBotao(btn_salvar, true);
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            if (btn_limpar.Tag is bool habilitado && !habilitado) return;
            EstadoInicial();
        }

        private void btnExcluir_Funcionario_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || idFuncionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário para excluir.");
                return;
            }

            int id = idFuncionarioSelecionado.Value;

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este funcionário?",
                "Excluir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                string sql = "DELETE FROM Funcionarios WHERE Id_Funci = @Id";

                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Funcionário excluído com sucesso!");

                        EstadoInicial();
                        CarregarTabela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir funcionário: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }
        private void txtnome_Funcionarios_Paint(object sender, PaintEventArgs e) { }
    }
}