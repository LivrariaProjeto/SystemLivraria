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
            string usuario = textBox1.Text;
            string senha = textBox2.Text;

            UsuariosTableAdapter tableAdap = new UsuariosTableAdapter();

            if (usuario == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                DataTable result = tableAdap.GetDataBy(usuario, senha);
                if (result.Rows.Count > 0)
                {
                    // Captura o nível de permissão (Id_Permi) do usuário logado
                    int nivelPermissao = Convert.ToInt32(result.Rows[0]["Id_Permi"]); //***

                    MessageBox.Show("Login realizado com sucesso!", "LOGIN REALIZADO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abre o MDI passando o nível
                    frmMDI FormPrincipal = new frmMDI(nivelPermissao);
                    this.Hide();
                    FormPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Senha ou Login incorretos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

        }
            

        private void frmLogon_Load(object sender, EventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string senha = textBox2.Text;

            UsuariosTableAdapter tableAdap = new UsuariosTableAdapter();

            if (usuario == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                DataTable result = tableAdap.GetDataBy(usuario, senha);
                if (result.Rows.Count > 0)
                {
                    // Captura o nível de permissão (Id_Permi) do usuário logado
                    int nivelPermissao = Convert.ToInt32(result.Rows[0]["Id_Permi"]);

                    MessageBox.Show("Login realizado com sucesso!", "LOGIN REALIZADO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abre o MDI passando o nível
                    frmMDI FormPrincipal = new frmMDI(nivelPermissao);
                    this.Hide();
                    FormPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Senha ou Login incorretos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
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
