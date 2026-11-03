using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmConsulta : Form
    {
        // Variáveis globais simples
        private string tabela = "";
        private int nivelUsuario = 3;
        private string conexao = ConfigurationManager.ConnectionStrings["SystemLivraria.Properties.Settings.db_250064ConnectionString"].ConnectionString;

        // Construtor padrão
        public frmConsulta()
        {
            InitializeComponent();
        }

        // Construtor que recebe o nível
        public frmConsulta(int nivel)
        {
            InitializeComponent();
            nivelUsuario = nivel;
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            // Limpa e adiciona os itens do filtro manualmente
            cbo_filtro.Items.Clear();
            cbo_filtro.Items.Add("Todos");
            cbo_filtro.Items.Add("Começa com");
            cbo_filtro.Items.Add("Termina com");
            cbo_filtro.Items.Add("Igual a");
            cbo_filtro.SelectedIndex = 0;

            // Carrega as tabelas de forma bem direta com IF/ELSE simples
            cbo_tabela.Items.Clear();

            if (nivelUsuario == 1)
            {
                cbo_tabela.Items.Add("Estoque");
            }
            else if (nivelUsuario == 2)
            {
                cbo_tabela.Items.Add("Estoque");
                cbo_tabela.Items.Add("Vendas");
                cbo_tabela.Items.Add("Compras");
            }
            else
            {
                // Se for chefe, adiciona as tabelas principais manualmente (evita usar GetSchema que é avançado)
                cbo_tabela.Items.Add("Estoque");
                cbo_tabela.Items.Add("Vendas");
                cbo_tabela.Items.Add("Compras");
                cbo_tabela.Items.Add("Clientes");
                cbo_tabela.Items.Add("Funcionarios");
            }

            if (cbo_tabela.Items.Count > 0)
            {
                cbo_tabela.SelectedIndex = 0;
            }
        }





        private void cbo_tabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tabela.SelectedItem == null) return;

            tabela = cbo_tabela.SelectedItem.ToString();
            cbo_coluna.Items.Clear();

            // Adicionando colunas genéricas comuns em vez de buscar no INFORMATION_SCHEMA
            cbo_coluna.Items.Add("ID");
            cbo_coluna.Items.Add("Nome");
            cbo_coluna.Items.Add("Descricao");

            if (cbo_coluna.Items.Count > 0)
            {
                cbo_coluna.SelectedIndex = 0;
            }

            CarregarTabela();
        }




        private void cbo_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se escolher "Todos", desativa a caixa de texto do filtro
            if (cbo_filtro.Text == "Todos")
            {
                txt_filtro.Text = "";
                txt_filtro.Enabled = false;
                CarregarTabela();
            }
            else
            {
                txt_filtro.Enabled = true;
                txt_filtro.Focus();
            }
        }



        private void btn_consulta_Click(object sender, EventArgs e)
        {
            CarregarTabela();
        }



        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_filtro.Text = "";
            if (cbo_filtro.Items.Count > 0) cbo_filtro.SelectedIndex = 0;
            if (cbo_coluna.Items.Count > 0) cbo_coluna.SelectedIndex = 0;
            CarregarTabela();
        }





        private void CarregarTabela()
        {
            if (tabela == "") return;

            string coluna = "";
            if (cbo_coluna.SelectedItem != null)
            {
                coluna = cbo_coluna.SelectedItem.ToString();
            }

            string filtro = cbo_filtro.Text;
            string textoFiltro = txt_filtro.Text.Trim();

            // Montagem básica da string SQL
            string sql = "SELECT * FROM " + tabela;

            // Usando IFs normais em vez de switch/case avançado
            if (filtro != "Todos" && textoFiltro != "" && coluna != "")
            {
                if (filtro == "Começa com")
                {
                    sql = "SELECT * FROM " + tabela + " WHERE " + coluna + " LIKE '" + textoFiltro + "%'";
                }
                else if (filtro == "Termina com")
                {
                    sql = "SELECT * FROM " + tabela + " WHERE " + coluna + " LIKE '%" + textoFiltro + "'";
                }
                else if (filtro == "Igual a")
                {
                    sql = "SELECT * FROM " + tabela + " WHERE " + coluna + " = '" + textoFiltro + "'";
                }
            }

            try
            {
                // Conexão e preenchimento da tabela de forma bem tradicional
                SqlConnection conn = new SqlConnection(conexao);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        // Métodos vazios mantidos apenas para não quebrar os eventos do Visual Studio
        private void cbo_coluna_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txt_filtro_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panelPersonalizado3_Paint(object sender, PaintEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}