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
        // Obtém a conexão padrão centralizada no App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        // Variável para guardar o ID do fornecedor selecionado para edição/exclusão
        private int? idFornecedorSelecionado = null;

        // Flag para impedir que o evento TextChanged dispare quando preenchemos os campos via código
        private bool carregandoDados = false;

        public frmCadFornecedores()
        {
            InitializeComponent();

            // Vinculando eventos necessários via código
            this.Load += frmCadFornecedores_Load;
            this.dataGridView1.CellClick += dataGridView1_CellClick;

            this.txt_nome.TextChanged += Campos_TextChanged;
            this.txt_endereco.TextChanged += Campos_TextChanged;
            this.txt_cnpj.TextChanged += Campos_TextChanged;
            this.txt_telefone.TextChanged += Campos_TextChanged;
            this.txt_email.TextChanged += Campos_TextChanged;

            // Formatação automática ao sair dos campos (Leave)
            this.txt_telefone.Leave += txt_telefone_Leave;
            this.txt_cnpj.Leave += txt_cnpj_Leave;
        }

        private void frmCadFornecedores_Load(object sender, EventArgs e)
        {
            CarregarTabela();
            EstadoInicial();
        }

        // Define o estado padrão (ao abrir ou após limpar/salvar)
        private void EstadoInicial()
        {
            LimparCampos();
            dataGridView1.ClearSelection();
            idFornecedorSelecionado = null;

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
            string sql = @"SELECT 
                            Id_Forne AS Id_Forne, 
                            Nome_Forne AS Nome_Forne, 
                            Endereco_Forne AS Endereco_Forne, 
                            CNPJ_Forne AS CNPJ_Forne, 
                            Tel_Forne AS Tel_Forne, 
                            Email_Forne AS Email_Forne 
                           FROM Fornecedores";

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
            txt_endereco.Clear();
            txt_cnpj.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            carregandoDados = false;
        }

        // Função de formatação do telefone
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

        // Função de formatação do CNPJ (00.000.000/0000-00)
        private string FormatarCnpj(string cnpj)
        {
            string numeros = new string(Array.FindAll(cnpj.ToCharArray(), char.IsDigit));

            if (numeros.Length == 14)
            {
                return Convert.ToInt64(numeros).ToString(@"00\.000\.000\/0000\-00");
            }

            return cnpj;
        }

        private void txt_telefone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_telefone.Text))
            {
                txt_telefone.Text = FormatarTelefone(txt_telefone.Text);
            }
        }

        private void txt_cnpj_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_cnpj.Text))
            {
                txt_cnpj.Text = FormatarCnpj(txt_cnpj.Text);
            }
        }

       
            private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (btn_adicionar.Tag is bool habilitado && !habilitado) return;

            if (string.IsNullOrWhiteSpace(txt_nome.Text) || string.IsNullOrWhiteSpace(txt_cnpj.Text) || string.IsNullOrWhiteSpace(txt_telefone.Text))
            {
                MessageBox.Show("Preencha os campos obrigatórios para adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Valida o CNPJ antes de salvar
            if (!ValidarCnpj(txt_cnpj.Text))
            {
                MessageBox.Show("O CNPJ informado é inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cnpj.Focus();
                return;
            }

            string telefoneFormatado = FormatarTelefone(txt_telefone.Text);
            string cnpjFormatado = FormatarCnpj(txt_cnpj.Text);

            string sql = @"INSERT INTO Fornecedores 
                            (Nome_Forne, Endereco_Forne, CNPJ_Forne, Tel_Forne, Email_Forne)
                            VALUES 
                            (@Nome, @Endereco, @CNPJ, @Telefone, @Email)";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@Endereco", txt_endereco.Text);
                    cmd.Parameters.AddWithValue("@CNPJ", cnpjFormatado);
                    cmd.Parameters.AddWithValue("@Telefone", telefoneFormatado);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoInicial();
                    CarregarTabela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar fornecedor:\n\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btn_salvar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                carregandoDados = true;
                idFornecedorSelecionado = Convert.ToInt32(row.Cells[0].Value); // Id_Forne
                txt_nome.Text = row.Cells[1].Value.ToString();                 // Nome_Forne
                txt_endereco.Text = row.Cells[2].Value.ToString();             // Endereco_Forne
                txt_cnpj.Text = row.Cells[3].Value.ToString();                 // CNPJ_Forne
                txt_telefone.Text = row.Cells[4].Value.ToString();             // Tel_Forne
                txt_email.Text = row.Cells[5].Value.ToString();                // Email_Forne
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

            // Se há um fornecedor selecionado e o usuário alterou algum texto, habilita o botão salvar
            if (idFornecedorSelecionado != null)
            {
                DefinirEstadoBotao(btn_salvar, true);
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            if (btn_limpar.Tag is bool habilitado && !habilitado) return;
            EstadoInicial();
        }

        private void btnExcluir_Fornecedor_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || idFornecedorSelecionado == null)
            {
                MessageBox.Show("Selecione um fornecedor para excluir.");
                return;
            }

            int id = idFornecedorSelecionado.Value;

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este fornecedor?",
                "Excluir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                string sql = "DELETE FROM Fornecedores WHERE Id_Forne = @Id";

                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Fornecedor excluído com sucesso!");

                        EstadoInicial();
                        CarregarTabela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir fornecedor: " + ex.Message);
                }
            }
        }

        // Eventos gerados automaticamente preservados
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e) { }
        private void lbl__Click(object sender, EventArgs e) { }

        // Função para validar se o CNPJ é real (Regra dos Dígitos Verificadores)
        private bool ValidarCnpj(string cnpj)
        {
            // Remove tudo o que não for número
            string tempCnpj = new string(Array.FindAll(cnpj.ToCharArray(), char.IsDigit));

            // CNPJ precisa ter exatamente 14 dígitos
            if (tempCnpj.Length != 14) return false;

            // Evita CNPJs com todos os números iguais (ex: 00.000.000/0000-00), que são inválidos
            bool todosIguais = true;
            for (int i = 1; i < 14; i++)
            {
                if (tempCnpj[i] != tempCnpj[0])
                {
                    todosIguais = false;
                    break;
                }
            }
            if (todosIguais) return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp = tempCnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(temp[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            temp = temp + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(temp[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return tempCnpj.EndsWith(digito);
        }
    }
}