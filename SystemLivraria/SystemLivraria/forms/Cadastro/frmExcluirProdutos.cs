using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmExcluirProdutos : Form
    {
        // Conexão lida a partir do App.config
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        private DataTable tabelaProdutos;

        public frmExcluirProdutos()
        {
            InitializeComponent();
        }

        private void frmExcluirProdutos_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void CarregarTabela()
        {
            string sql = @"SELECT P.Id_Pro        AS [Código],
                                  P.Nome_Pro      AS [Produto],
                                  A.Nome_Autor    AS [Autor],
                                  C.Nome_Cat      AS [Categoria],
                                  E.Nome_Edi      AS [Editora],
                                  P.Preco_Pro     AS [Preço],
                                  P.ISBN_Pro      AS [ISBN]
                           FROM Produtos P
                           INNER JOIN Autores A    ON P.Id_Autor = A.Id_Autor
                           INNER JOIN Categorias C ON P.Id_Cat   = C.Id_Cat
                           INNER JOIN Editoras E   ON P.Id_Edi   = E.Id_Edi
                           ORDER BY P.Nome_Pro";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conexao))
                {
                    tabelaProdutos = new DataTable();
                    da.Fill(tabelaProdutos);

                    dataGridView1.DataSource = tabelaProdutos;
                    dataGridView1.Columns["Preço"].DefaultCellStyle.Format = "C2";
                    dataGridView1.Columns["Preço"].DefaultCellStyle.FormatProvider =
                        System.Globalization.CultureInfo.GetCultureInfo("pt-BR");

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
            if (tabelaProdutos == null) return;

            string texto = txt_busca.Text.Trim().Replace("'", "''")
                .Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");

            tabelaProdutos.DefaultView.RowFilter = string.IsNullOrEmpty(texto)
                ? string.Empty
                : "[Produto] LIKE '%" + texto + "%'";

            lbl_total.Text = tabelaProdutos.DefaultView.Count + " produto(s)";
        }

        private void txt_busca_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Código"].Value);
            string nome = Convert.ToString(dataGridView1.CurrentRow.Cells["Produto"].Value);

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir o produto \"" + nome + "\"?\n\n" +
                "Atenção: o estoque e os itens de vendas/compras ligados a este produto também serão removidos. " +
                "Esta ação não pode ser desfeita.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resposta != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand("Proc_ExcluirPro", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idpro", SqlDbType.Int).Value = id;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto excluído com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarTabela();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao excluir produto:\n" + ex.Message, "Erro no banco de dados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto:\n" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
