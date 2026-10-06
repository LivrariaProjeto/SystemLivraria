namespace SystemLivraria.forms
{
    partial class frmConAutores
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPersonalizado2 = new SystemLivraria.classes.PanelPersonalizado();
            this.panelPersonalizado1 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelPersonalizado2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 445);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisar por...";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelPersonalizado2
            // 
            this.panelPersonalizado2.BackColor = System.Drawing.Color.White;
            this.panelPersonalizado2.BorderRadius = 30;
            this.panelPersonalizado2.Controls.Add(this.comboBox1);
            this.panelPersonalizado2.Controls.Add(this.panel2);
            this.panelPersonalizado2.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado2.GradientAngle = 90F;
            this.panelPersonalizado2.GradientBottomColor = System.Drawing.Color.Silver;
            this.panelPersonalizado2.GradientTopColor = System.Drawing.Color.Silver;
            this.panelPersonalizado2.Location = new System.Drawing.Point(0, 40);
            this.panelPersonalizado2.Name = "panelPersonalizado2";
            this.panelPersonalizado2.Size = new System.Drawing.Size(255, 38);
            this.panelPersonalizado2.TabIndex = 0;
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.BackColor = System.Drawing.Color.Turquoise;
            this.panelPersonalizado1.BorderRadius = 20;
            this.panelPersonalizado1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPersonalizado1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.panelPersonalizado1.GradientAngle = 90F;
            this.panelPersonalizado1.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panelPersonalizado1.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panelPersonalizado1.Location = new System.Drawing.Point(298, 20);
            this.panelPersonalizado1.Margin = new System.Windows.Forms.Padding(0);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 15);
            this.panelPersonalizado1.Size = new System.Drawing.Size(709, 457);
            this.panelPersonalizado1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 5);
            this.panel2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(251, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // frmConAutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1027, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPersonalizado1);
            this.Name = "frmConAutores";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Consulta de Autores";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPersonalizado2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private classes.PanelPersonalizado panelPersonalizado1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private classes.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}