using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmConsulta : System.Windows.Forms.Form
    {
        private string tabela = "";
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            // Popula os tipos de filtro no cbo_filtro
            cbo_filtro.Items.Clear();
            cbo_filtro.Items.Add("Todos");
            cbo_filtro.Items.Add("Começa com");
            cbo_filtro.Items.Add("Termina com");
            cbo_filtro.Items.Add("Igual a");
            cbo_filtro.Items.Add("Data");
            cbo_filtro.SelectedIndex = 0;

            // Carrega as tabelas do banco no primeiro ComboBox
            try
            {
                cbo_tabela.Items.Clear();

                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();
                    DataTable schemaTables = conn.GetSchema("Tables", new string[] { null, null, null, "BASE TABLE" });

                    foreach (DataRow row in schemaTables.Rows)
                    {
                        cbo_tabela.Items.Add(row["TABLE_NAME"].ToString());
                    }
                }

                if (cbo_tabela.Items.Count > 0)
                {
                    cbo_tabela.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar tabelas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbo_tabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_coluna.Items.Clear();

            if (cbo_tabela.SelectedItem == null) return;
            tabela = cbo_tabela.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(tabela))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    {
                        conn.Open();

                        // Lista as colunas da tabela selecionada
                        string queryCols = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tabela ORDER BY ORDINAL_POSITION";
                        using (SqlCommand cmd = new SqlCommand(queryCols, conn))
                        {
                            cmd.Parameters.AddWithValue("@tabela", tabela);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cbo_coluna.Items.Add(reader["COLUMN_NAME"].ToString());
                                }
                            }
                        }
                    }

                    if (cbo_coluna.Items.Count > 0)
                    {
                        cbo_coluna.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar as colunas da tabela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            CarregarTabela();
        }

        private void cbo_coluna_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aguarda o clique no botão "Consultar"
        }

        private void cbo_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_filtro.SelectedItem?.ToString() == "Todos")
            {
                txt_filtro.Clear();
                txt_filtro.Enabled = false;
                CarregarTabela();
            }
            else
            {
                txt_filtro.Enabled = true;
                txt_filtro.Focus();
            }
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            // Aguarda o clique no botão "Consultar"
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_filtro.Clear();

            if (cbo_filtro.Items.Count > 0)
                cbo_filtro.SelectedIndex = 0;

            if (cbo_coluna.Items.Count > 0)
                cbo_coluna.SelectedIndex = 0;

            CarregarTabela();
        }

        private void CarregarTabela()
        {
            if (string.IsNullOrEmpty(tabela)) return;

            string coluna = cbo_coluna.SelectedItem?.ToString();
            string tipoFiltro = cbo_filtro.SelectedItem?.ToString() ?? "Todos";
            string termo = txt_filtro.Text.Trim();

            string sql = $"SELECT * FROM [{tabela}]";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexao))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if (tipoFiltro != "Todos" && !string.IsNullOrEmpty(termo) && !string.IsNullOrEmpty(coluna))
                    {
                        switch (tipoFiltro)
                        {
                            case "Começa com":
                                sql += $" WHERE [{coluna}] LIKE @termo + '%'";
                                cmd.Parameters.AddWithValue("@termo", termo);
                                break;

                            case "Termina com":
                                sql += $" WHERE [{coluna}] LIKE '%' + @termo";
                                cmd.Parameters.AddWithValue("@termo", termo);
                                break;

                            case "Igual a":
                                sql += $" WHERE [{coluna}] = @termo";
                                cmd.Parameters.AddWithValue("@termo", termo);
                                break;

                            case "Data":
                                if (DateTime.TryParse(termo, out DateTime dataValida))
                                {
                                    sql += $" WHERE CAST([{coluna}] AS DATE) = @termo";
                                    cmd.Parameters.AddWithValue("@termo", dataValida.Date);
                                }
                                else
                                {
                                    MessageBox.Show("Introduza uma data válida (exemplo: dd/mm/aaaa).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                break;
                        }
                    }

                    cmd.CommandText = sql;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a tabela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string text = cbo_tabela.Items[e.Index].ToString();
            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void panelPersonalizado3_Paint(object sender, PaintEventArgs e) { }

    }
}