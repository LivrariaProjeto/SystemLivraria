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
        public frmMDI()
        {
            InitializeComponent();
        }

        private void editoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is frmCadEditoras)
                {
                    formAberto.Activate();
                    return;
                }
            }

            frmCadEditoras novoForm = new frmCadEditoras
            {
                MdiParent = this
            };
            novoForm.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is frmCadProdutos)
                {
                    formAberto.Activate();
                    return;
                }
            }

            frmCadProdutos novoForm = new frmCadProdutos
            {
                MdiParent = this
            };
            novoForm.Show();
        }

        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is frmCadAutores)
                {
                    formAberto.Activate();
                    return;
                }
            }

            frmCadAutores novoForm = new frmCadAutores
            {
                MdiParent = this
            };
            novoForm.Show();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is frmCadFornecedores)
                {
                    formAberto.Activate();
                    return;
                }
            }

            frmCadFornecedores novoForm = new frmCadFornecedores
            {
                MdiParent = this
            };
            novoForm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is frmCadClientes)
                {
                    formAberto.Activate();
                    return;
                }
            }

            frmCadClientes novoForm = new frmCadClientes
            {
                MdiParent = this
            };
            novoForm.Show();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                if (formAberto is frmCadFuncionarios)
                {
                    formAberto.Activate();
                    return;
                }
            }

            frmCadFuncionarios novoForm = new frmCadFuncionarios
            {
                MdiParent = this
            };
            novoForm.Show();
        }
    }
}


