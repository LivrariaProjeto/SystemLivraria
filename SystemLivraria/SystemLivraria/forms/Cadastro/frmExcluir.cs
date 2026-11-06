using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmExcluir : Form
    {
        // Conexão lida a partir do App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;
        private int nivelUsuario = 3;
        private DataTable tabelaDados;

        public frmExcluir(int nivel)
        {
            InitializeComponent();
            this.nivelUsuario = nivel;
        }

        public frmExcluir()
        {
            InitializeComponent();
            this.nivelUsuario = 3;
        }

        

        private void frmExcluirProdutos_Load(object sender, EventArgs e)
        {
            if (nivelUsuario == 3)
            {
                MessageBox.Show("Você não tem permissão para acessar esta tela.", "Acesso negado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }
            
            else if (nivelUsuario == 2)
            {
                cbTabelas.Items.Clear();
                cbTabelas.Items.Add(new ItemTabela("Produtos", "Produtos", "Id_Pro", "Nome_Pro", "sp_ExcluirPro"));
                cbTabelas.Items.Add(new ItemTabela("Cliente", "Cliente", "Id_Cli", "Nome_Cli", ""));
            }
            // Preenche o ComboBox (Dropdown) com as tabelas, definindo a tabela, a chave primária e o nome da coluna correspondente
            else
            {
                cbTabelas.Items.Clear();
                cbTabelas.Items.Add(new ItemTabela("Produtos", "Produtos", "Id_Pro", "Nome_Pro", "sp_ExcluirPro"));
                cbTabelas.Items.Add(new ItemTabela("Cliente", "Cliente", "Id_Cli", "Nome_Cli", ""));
                cbTabelas.Items.Add(new ItemTabela("Estoque", "Estoque", "Id_Est", "Nome_Pro", ""));
                cbTabelas.Items.Add(new ItemTabela("Fornecedores", "Fornecedores", "Id_Forne", "Nome_Forne", ""));
                cbTabelas.Items.Add(new ItemTabela("Funcionários", "Funcionarios", "Id_Funci", "Nome_Funci", ""));
            }
            

            // Seleciona "Produtos" por padrão ao abrir a tela
            cbTabelas.SelectedIndex = 0;
        }

        private void cbTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void CarregarTabela()
        {
            if (cbTabelas.SelectedItem == null) return;

            ItemTabela item = (ItemTabela)cbTabelas.SelectedItem;
            string sql = "";

            // Monta o SELECT de acordo com a tabela selecionada usando os nomes exatos das colunas
            switch (item.TabelaBanco)
            {
                case "Produtos":
                    sql = @"SELECT P.Id_Pro AS [Código], P.Nome_Pro AS [Nome], P.Preco_Pro AS [Preço] FROM Produtos P ORDER BY P.Nome_Pro";
                    break;
                case "Cliente":
                    sql = @"SELECT Id_Cli AS [Código], Nome_Cli AS [Nome], Tel_Cli AS [Telefone], CPF_Cli AS [CPF] FROM Cliente ORDER BY Nome_Cli";
                    break;
                case "Estoque":
                    sql = @"SELECT Id_Est AS [Código], Id_Pro AS [Cód. Produto], Nome_Pro AS [Nome], QTD_Est AS [Quantidade] FROM Estoque ORDER BY Id_Est";
                    break;
                case "Fornecedores":
                    sql = @"SELECT Id_Forne AS [Código], Nome_Forne AS [Nome], Tel_Forne AS [Telefone] FROM Fornecedores ORDER BY Nome_Forne";
                    break;
                case "Funcionarios":
                    sql = @"SELECT Id_Funci AS [Código], Nome_Funci AS [Nome], Cargo_Funci AS [Cargo] FROM Funcionarios ORDER BY Nome_Funci";
                    break;
                case "Usuarios":
                    sql = @"SELECT Id_Usu AS [Código], Login_usu AS [Nome], Perfil_usu AS [Perfil] FROM Usuarios ORDER BY Login_usu";
                    break;
            }

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conexao))
                {
                    tabelaDados = new DataTable();
                    da.Fill(tabelaDados);

                    dataGridView1.DataSource = tabelaDados;

                    // Formatação de preço caso exista a coluna na grid
                    if (dataGridView1.Columns["Preço"] != null)
                    {
                        dataGridView1.Columns["Preço"].DefaultCellStyle.Format = "C2";
                        dataGridView1.Columns["Preço"].DefaultCellStyle.FormatProvider =
                            System.Globalization.CultureInfo.GetCultureInfo("pt-BR");
                    }

                    AplicarFiltro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a tabela: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltro()
        {
            if (tabelaDados == null) return;

            string texto = txt_busca.Text.Trim().Replace("'", "''")
                .Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");

            // Filtra pela coluna [Nome] que padronizamos em todas as consultas
            tabelaDados.DefaultView.RowFilter = string.IsNullOrEmpty(texto)
                ? string.Empty
                : "[Nome] LIKE '%" + texto + "%'";

            lbl_total.Text = tabelaDados.DefaultView.Count + " registro(s)";
        }

        private void txt_busca_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemTabela itemSelecionado = (ItemTabela)cbTabelas.SelectedItem;

            if (itemSelecionado.TabelaBanco == "Usuarios")
            {
                MessageBox.Show(
                    "Use Gerenciar usuários para desativar uma conta.");

                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Código"].Value);
            string nome = dataGridView1.Columns.Contains("Nome") ? Convert.ToString(dataGridView1.CurrentRow.Cells["Nome"].Value) : id.ToString();

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir o registro \"" + nome + "\"?\n\nEsta ação não pode ser desfeita.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resposta != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        // Se for Produtos, usa a Stored Procedure. Para as outras tabelas, usa comando SQL direto.
                        if (itemSelecionado.TabelaBanco == "Produtos")
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = itemSelecionado.StoredProcedure;
                            cmd.Parameters.Add("@idpro", SqlDbType.Int).Value = id;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = $"DELETE FROM {itemSelecionado.TabelaBanco} WHERE {itemSelecionado.ChavePrimaria} = @id";
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registro excluído com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarTabela();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao excluir registro (verifique se há registros vinculados em outras tabelas):\n\n" + ex.Message, "Erro no banco de dados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir registro:\n" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTabelas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CarregarTabela();
        }
    }

    // Classe de apoio para mapear as propriedades de cada tabela no ComboBox
    public class ItemTabela
    {
        public string NomeExibicao { get; set; }
        public string TabelaBanco { get; set; }
        public string ChavePrimaria { get; set; }
        public string ColunaNome { get; set; }
        public string StoredProcedure { get; set; }

        public ItemTabela(string exibicao, string tabela, string pk, string colNome, string sp)
        {
            NomeExibicao = exibicao;
            TabelaBanco = tabela;
            ChavePrimaria = pk;
            ColunaNome = colNome;
            StoredProcedure = sp;
        }

        public override string ToString()
        {
            return NomeExibicao;
        }
    }
}