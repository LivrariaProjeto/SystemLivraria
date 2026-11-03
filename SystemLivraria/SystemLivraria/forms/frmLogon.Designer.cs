namespace SystemLivraria.forms
{
    partial class frmLogon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogon));
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelPersonalizado1 = new SystemLivraria.classes.PanelPersonalizado();
            this.LOGIN = new SystemLivraria.classes.ButtonPersonalizado();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPersonalizado3 = new SystemLivraria.classes.PanelPersonalizado();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelPersonalizado2 = new SystemLivraria.classes.PanelPersonalizado();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelPersonalizado1.SuspendLayout();
            this.panelPersonalizado3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPersonalizado2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel.Controls.Add(this.panelPersonalizado1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Location = new System.Drawing.Point(514, 0);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(74, 91, 74, 91);
            this.panel.Size = new System.Drawing.Size(530, 622);
            this.panel.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(74, 91, 74, 91);
            this.panel1.Size = new System.Drawing.Size(516, 622);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 56);
            this.label3.TabIndex = 12;
            this.label3.Text = "BEM-VINDO!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(74, 177);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(368, 354);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado1.BorderRadius = 30;
            this.panelPersonalizado1.Controls.Add(this.LOGIN);
            this.panelPersonalizado1.Controls.Add(this.label2);
            this.panelPersonalizado1.Controls.Add(this.label1);
            this.panelPersonalizado1.Controls.Add(this.panelPersonalizado3);
            this.panelPersonalizado1.Controls.Add(this.panelPersonalizado2);
            this.panelPersonalizado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPersonalizado1.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado1.GradientAngle = 90F;
            this.panelPersonalizado1.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            this.panelPersonalizado1.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            this.panelPersonalizado1.Location = new System.Drawing.Point(74, 91);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Padding = new System.Windows.Forms.Padding(43, 0, 0, 0);
            this.panelPersonalizado1.Size = new System.Drawing.Size(382, 440);
            this.panelPersonalizado1.TabIndex = 1;
            // 
            // LOGIN
            // 
            this.LOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.LOGIN.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.LOGIN.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.LOGIN.BorderRadius = 52;
            this.LOGIN.BorderSize = 0;
            this.LOGIN.FlatAppearance.BorderSize = 0;
            this.LOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOGIN.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGIN.ForeColor = System.Drawing.Color.White;
            this.LOGIN.Location = new System.Drawing.Point(46, 308);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(289, 52);
            this.LOGIN.TabIndex = 15;
            this.LOGIN.Text = "LOGIN";
            this.LOGIN.TextColor = System.Drawing.Color.White;
            this.LOGIN.UseVisualStyleBackColor = false;
            this.LOGIN.Click += new System.EventHandler(this.LOGIN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "SENHA";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "USUÁRIO";
            // 
            // panelPersonalizado3
            // 
            this.panelPersonalizado3.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado3.BorderRadius = 30;
            this.panelPersonalizado3.Controls.Add(this.pictureBox1);
            this.panelPersonalizado3.Controls.Add(this.textBox2);
            this.panelPersonalizado3.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado3.GradientAngle = 90F;
            this.panelPersonalizado3.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(197)))), ((int)(((byte)(195)))));
            this.panelPersonalizado3.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(197)))), ((int)(((byte)(195)))));
            this.panelPersonalizado3.Location = new System.Drawing.Point(46, 191);
            this.panelPersonalizado3.Name = "panelPersonalizado3";
            this.panelPersonalizado3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelPersonalizado3.Size = new System.Drawing.Size(289, 52);
            this.panelPersonalizado3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(197)))), ((int)(((byte)(195)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(59, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panelPersonalizado2
            // 
            this.panelPersonalizado2.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado2.BorderRadius = 30;
            this.panelPersonalizado2.Controls.Add(this.pictureBox4);
            this.panelPersonalizado2.Controls.Add(this.textBox1);
            this.panelPersonalizado2.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado2.GradientAngle = 90F;
            this.panelPersonalizado2.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(197)))), ((int)(((byte)(195)))));
            this.panelPersonalizado2.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(197)))), ((int)(((byte)(195)))));
            this.panelPersonalizado2.Location = new System.Drawing.Point(46, 106);
            this.panelPersonalizado2.Name = "panelPersonalizado2";
            this.panelPersonalizado2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelPersonalizado2.Size = new System.Drawing.Size(289, 52);
            this.panelPersonalizado2.TabIndex = 0;
            this.panelPersonalizado2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPersonalizado2_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(10, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 52);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(197)))), ((int)(((byte)(195)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(59, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(227, 25);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // frmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1044, 622);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLogon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogon_Load);
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelPersonalizado1.ResumeLayout(false);
            this.panelPersonalizado1.PerformLayout();
            this.panelPersonalizado3.ResumeLayout(false);
            this.panelPersonalizado3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPersonalizado2.ResumeLayout(false);
            this.panelPersonalizado2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel;
        private classes.PanelPersonalizado panelPersonalizado1;
        private classes.PanelPersonalizado panelPersonalizado3;
        private classes.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private classes.ButtonPersonalizado LOGIN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}