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
    public partial class frmCadClientes : Form
    {
        // Obtém a conexão diretamente do App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        // Variável para guardar o ID do cliente selecionado para edição/exclusão
        private int? idClienteSelecionado = null;

        // Flag para impedir que o evento TextChanged dispare quando preenchemos os campos via código
        private bool carregandoDados = false;

        public frmCadClientes()
        {
            InitializeComponent();

            // Vinculando eventos necessários via código
            this.Load += frmCadClientes_Load;
            this.dataGridView1.CellClick += dataGridView1_CellClick;

            // Vinculando o evento de alteração de texto em todos os campos do cliente
            this.txt_nome.TextChanged += Campos_TextChanged;
            this.txt_telefone.TextChanged += Campos_TextChanged;
            this.txt_cpf.TextChanged += Campos_TextChanged;
            this.txt_email.TextChanged += Campos_TextChanged;
            this.txt_endereco.TextChanged += Campos_TextChanged;

            //Vincula o evento Leave para formatar automaticamente ao sair do campo
            this.txt_telefone.Leave += txt_telefone_Leave;
            this.txt_cpf.Leave += txt_cpf_Leave;
        }

        private void frmCadClientes_Load(object sender, EventArgs e)
        {
            CarregarTabela();
            EstadoInicial();
        }

        // Define o estado padrão (ao abrir ou após limpar/salvar)
        private void EstadoInicial()
        {
            LimparCampos();
            dataGridView1.ClearSelection();
            idClienteSelecionado = null;

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
            carregandoDados = true;
            txt_nome.Clear();
            txt_telefone.Clear();
            txt_cpf.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
            carregandoDados = false;
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (btn_adicionar.Tag is bool habilitado && !habilitado) return;

            if (string.IsNullOrWhiteSpace(txt_nome.Text) || string.IsNullOrWhiteSpace(txt_telefone.Text) || string.IsNullOrWhiteSpace(txt_cpf.Text))
            {
                MessageBox.Show("Preencha ao menos os campos obrigatórios para adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = @"INSERT INTO Cliente (Nome_Cli, Tel_Cli, CPF_Cli, Email_Cli, Endereco_Cli)
                            VALUES (@Nome, @Tel, @Cpf, @Email, @Endereco)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Tel", txt_telefone.Text);
                    cmd.Parameters.AddWithValue("@Cpf", txt_cpf.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Endereco", txt_endereco.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (btn_salvar.Tag is bool habilitado && !habilitado) return;
            if (idClienteSelecionado == null) return;

            string sql = @"UPDATE Cliente SET Nome_Cli = @Nome, Tel_Cli = @Tel, CPF_Cli = @Cpf, Email_Cli = @Email, Endereco_Cli = @Endereco WHERE Id_Cli = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Tel", txt_telefone.Text);
                    cmd.Parameters.AddWithValue("@Cpf", txt_cpf.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Endereco", txt_endereco.Text);
                    cmd.Parameters.AddWithValue("@Id", idClienteSelecionado.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de clique na tabela para preencher os campos com base na ordem das colunas do SELECT
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                carregandoDados = true;
                idClienteSelecionado = Convert.ToInt32(row.Cells[0].Value); // Id_Cli
                txt_nome.Text = row.Cells[1].Value.ToString();               // Nome_Cli
                txt_telefone.Text = row.Cells[2].Value.ToString();           // Tel_Cli
                txt_cpf.Text = row.Cells[3].Value.ToString();                // CPF_Cli
                txt_email.Text = row.Cells[4].Value.ToString();              // Email_Cli
                txt_endereco.Text = row.Cells[5].Value.ToString();           // Endereco_Cli
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

        // Monitora se o usuário digitou/editou algo nos TextBoxes
        private void Campos_TextChanged(object sender, EventArgs e)
        {
            if (carregandoDados) return;

            // Se há um cliente selecionado e o usuário alterou algum texto, habilita o botão salvar
            if (idClienteSelecionado != null)
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
            if (dataGridView1.CurrentRow == null || idClienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente para excluir.");
                return;
            }

            int id = idClienteSelecionado.Value;

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este cliente?",
                "Excluir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                string sql = "DELETE FROM Cliente WHERE Id_Cli = @Id";

                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente excluído com sucesso!");

                        EstadoInicial();
                        CarregarTabela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir cliente: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }

        //formata telefone
        private string FormatarTelefone(string telefone)
        {
            //remove oq nao é numero
            string numeros = new string(Array.FindAll(telefone.ToCharArray(), char.IsDigit));

            if (numeros.Length == 11)
            {
                //formato com 9 dígitos:
                return Convert.ToInt64(numeros).ToString(@"(00) 00000-0000");
            }
            else if (numeros.Length == 10)
            {
                //formato com 8 digitos:
                return Convert.ToInt64(numeros).ToString(@"(00) 0000-0000");
            }

            //Se não tiver 10 ou 11 dígitos, retorna como o usuário digitou
            return telefone;
        }

        //formata o cpg
        private string FormatarCpf(string cpf)
        {
            //remove oq nao é numero
            string numeros = new string(Array.FindAll(cpf.ToCharArray(), char.IsDigit));

            if (numeros.Length == 11)
            {
                return Convert.ToInt64(numeros).ToString(@"000\.000\.000\-00");
            }

            // Se não tiver 11 dígitos, retorna original
            return cpf;
        }

        //validação de cpf
        private bool ValidarCpf(string cpf)
        {
            //remove oq nao é numero
            string tempCpf = new string(Array.FindAll(cpf.ToCharArray(), char.IsDigit));

            //CPF precisa ter exatamente 11 dígitos
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

        // Evento que formata o Telefone automaticamente quando o usuário sai do campo
        private void txt_telefone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_telefone.Text))
            {
                txt_telefone.Text = FormatarTelefone(txt_telefone.Text);
            }
        }

        // Evento que formata e valida o CPF automaticamente quando o usuário sai do campo
        private void txt_cpf_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_cpf.Text))
            {
                // Opcional: já valida o CPF na hora que sai do campo
                if (!ValidarCpf(txt_cpf.Text))
                {
                    MessageBox.Show("O CPF informado parece inválido. Verifique os números.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txt_cpf.Text = FormatarCpf(txt_cpf.Text);
            }
        }
    }
}