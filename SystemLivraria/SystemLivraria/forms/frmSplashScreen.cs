using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemLivraria.forms;

namespace SystemLivraria
{
    public partial class frmSplashScreen : Form
    {
        private SoundPlayer player;
        private Timer timer;
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            this.Opacity = 1;
            player = new SoundPlayer();
            player.Play();

            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.BackColor = Color.LightGray;
            this.TransparencyKey = Color.LightGray;


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if (this.Opacity <= 0)
            {

                player.Stop();
                this.Hide();
                frmLogon Login = new frmLogon();
                Login.Show();
            }
            else
            {
                timer.Stop();
                frmLogon Login = new frmLogon();
                Login.Show();
                this.Hide();
            }
        }
    }
}
