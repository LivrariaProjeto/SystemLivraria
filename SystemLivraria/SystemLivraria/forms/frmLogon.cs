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

namespace SystemLivraria.forms
{
    public partial class frmLogon : Form
    {
        public frmLogon()
        {
            InitializeComponent();
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

            try
            {
                using (var adapter = new UsuariosTableAdapter())
                {
                    DataTable resultado = adapter.GetDataBy(
                        textBox1.Text.Trim(), textBox2.Text);

                    if (resultado.Rows.Count != 1 ||
                        !Convert.ToBoolean(resultado.Rows[0]["Ativo_usu"]))
                    {
                        MessageBox.Show(
                            "Login ou senha incorretos, ou usuário inativo.");
                        return;
                    }

                    DataRow usuario = resultado.Rows[0];
                    int nivel = Convert.ToInt32(usuario["Id_Permi"]);

                    if (nivel < 1 || nivel > 3)
                    {
                        MessageBox.Show(
                            "Permissão de usuário não reconhecida.");
                        return;
                    }

                    var principal = new frmDashboard(
                        nivel,
                        Convert.ToInt32(usuario["Id_Usu"]));

                    principal.FormClosed += delegate { Close(); };

                    principal.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível entrar: " + ex.Message);
            }
            finally
            {
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
