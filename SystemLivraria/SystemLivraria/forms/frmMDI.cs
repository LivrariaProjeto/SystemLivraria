using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemLivraria.forms
{
    public partial class frmMDI : Form
    {
        private int nivelUsuario;

        public frmMDI()
        {
            InitializeComponent();
            nivelUsuario = 3; // Padrão caso abra direto
            AplicarPermissoes();
        }

        public frmMDI(int nivel)
        {
            InitializeComponent();
            nivelUsuario = nivel;
            AplicarPermissoes();
        }

        private void AplicarPermissoes()
        {
            // Nível 1: Funcionário
            // - Consulta: só o estoque
            // - Cadastro: só cadastra produto, autor, editora e cliente
            if (nivelUsuario == 1)
            {
                if (funcionáriosToolStripMenuItem != null) funcionáriosToolStripMenuItem.Visible = false;
                if (fornecedoresToolStripMenuItem != null) fornecedoresToolStripMenuItem.Visible = false;
                // Ocultar menus de relatórios ou financeiro se existirem no seu MDI
            }
            // Nível 2: Gerente
            // - Consulta: estoque, vendas e compras
            // - Cadastro: produtos, autores, editoras, clientes e funcionários
            // - Relatório: venda, compra, estoque (sem financeiro)
            else if (nivelUsuario == 2)
            {
                if (fornecedoresToolStripMenuItem != null) fornecedoresToolStripMenuItem.Visible = false;
                // Ocultar financeiro / relatórios financeiros se houver
            }
            // Nível 3: Chefe (Acesso total)
            else if (nivelUsuario == 3)
            {
                // Tudo visível
            }
        }

        private void editoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadEditoras>();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadProdutos>();
        }

        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadAutores>();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validação extra de segurança por nível
            if (nivelUsuario == 1 || nivelUsuario == 2)
            {
                MessageBox.Show("Acesso negado para este nível!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AbrirFormulario<frmCadFornecedores>();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCadClientes>();
        }

        private void excluirProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmExcluirProdutos>();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nivelUsuario == 1)
            {
                MessageBox.Show("Acesso negado para funcionários!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AbrirFormulario<frmCadFuncionarios>();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Passa o nível atual do usuário ao abrir a tela de consulta
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is frmConsulta)
                {
                    formAberto.Activate();
                    return;
                }
            }

            frmConsulta novoForm = new frmConsulta(nivelUsuario)
            {
                MdiParent = this
            };
            novoForm.Show();
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is T)
                {
                    formAberto.Activate();
                    return;
                }
            }

            T novoForm = new T
            {
                MdiParent = this
            };
            novoForm.Show();
        }

        private void frmMDI_Load(object sender, EventArgs e) { }

        private void estoqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
    }
}