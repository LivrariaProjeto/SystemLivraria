using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemLivraria.data.DataSet2TableAdapters;
using SystemLivraria.classes;

namespace SystemLivraria.forms
{
    public partial class frmLogon : Form
    {
        public frmLogon()
        {
            InitializeComponent();

            FormClosed += delegate
            {
                Application.Exit();
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autenticar();

        }
            

        private void frmLogon_Load(object sender, EventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            Autenticar();
        }

        private void Autenticar()
        {
            if (!LOGIN.Enabled)
                return;

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Preencha login e senha.");
                return;
            }

            LOGIN.Enabled = false;
            UseWaitCursor = true;

            try
            {
                var sessao = UsuariosService.Autenticar(
                    textBox1.Text,
                    textBox2.Text);

                if (sessao == null)
                {
                    MessageBox.Show(
                        "Login ou senha incorretos, " +
                        "ou usuário sem acesso ativo.");

                    return;
                }

                var principal = new frmDashboard(
                    sessao.Nivel,
                    sessao.IdUsuario);

                principal.FormClosed += delegate
                {
                    if (principal.SolicitouLogoff)
                    {
                        textBox1.Clear();
                        textBox2.Clear();

                        Show();
                        WindowState = FormWindowState.Normal;
                        Activate();
                        textBox1.Focus();
                    }
                    else
                    {
                        Close();
                    }
                };

                principal.Show();
                textBox2.Clear();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível entrar: " + ex.Message);
            }
            finally
            {
                UseWaitCursor = false;

                if (!IsDisposed)
                    LOGIN.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelPersonalizado2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
