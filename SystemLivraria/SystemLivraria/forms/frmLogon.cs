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
            //criando um objeto do tipo UsuariosTableAdapter para acessar os dados da tabela de usuários
            //ele possui métodos para preencher um DataTable com os dados da tabela de usuários,
            //como para inserir, atualizar e excluir registros -> o fill, o get, o fillby e o getby
            //cada metodo possui a consulta sql correspondente -> exemplo: o método GetDataBy possui
            //"SELECT * FROM Usuarios WHERE Login_usu = @Login AND Senha_usu = @Senha"
            //o nosso objeto vai executar a consulta sql e retornar os dados da tabela
            //de usuários que correspondem ao login e senha digitados
            // o objeto vai executar o que ele faz (TableAdapter -> liga as tabelas com o codigo c#)
            // mais o método ligado a ele (GetDataBy) e vai retornar os dados da tabela de
            // usuários que correspondem ao login e senha digitados
            UsuariosTableAdapter tableAdap = new UsuariosTableAdapter();
            //o resultado vai vir em forma de DataTable, que é uma tabela em memória 

            if (usuario == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            } 
            else
            {
                DataTable result = tableAdap.GetDataBy(usuario, senha);
                if(result.Rows.Count > 0)//se achar o usuario verifique a senha
                {
                        MessageBox.Show("Login realizado com sucesso!", "    LOGIN REALIZADO!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //shów é o método que possui a classe MessageBox,
                        //que exibe uma caixa de diálogo com uma mensagem para o usuário
                        //o método Show possui vários parâmetros, como o texto da mensagem,
                        //o título da caixa de diálogo, os botões que serão exibidos e o ícone que será exibido
                }
                else
                {
                    MessageBox.Show("Senha ou Login incorretos!", "    ERRO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }   
        }
            

        private void frmLogon_Load(object sender, EventArgs e)
        {

        }

        private void lbl_esqueceu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbl_esqueceu.LinkVisited = true;

            
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://youtu.be/vabnZ9-ex7o",
                UseShellExecute = true
            });
        }
    }
}
