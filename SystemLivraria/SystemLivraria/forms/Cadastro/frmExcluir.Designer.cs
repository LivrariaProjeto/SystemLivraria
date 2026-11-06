namespace SystemLivraria.forms
{
    partial class frmExcluir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_busca = new System.Windows.Forms.Label();
            this.txt_busca = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_total = new System.Windows.Forms.Label();
            this.cbTabelas = new System.Windows.Forms.ComboBox();
            this.btn_cancelar = new SystemLivraria.classes.ButtonPersonalizado();
            this.buttonPersonalizado1 = new SystemLivraria.classes.ButtonPersonalizado();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(24, 18);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(146, 23);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Excluir Produto";
            // 
            // lbl_busca
            // 
            this.lbl_busca.AutoSize = true;
            this.lbl_busca.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_busca.Location = new System.Drawing.Point(25, 62);
            this.lbl_busca.Name = "lbl_busca";
            this.lbl_busca.Size = new System.Drawing.Size(57, 18);
            this.lbl_busca.TabIndex = 1;
            this.lbl_busca.Text = "Buscar";
            // 
            // txt_busca
            // 
            this.txt_busca.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_busca.Location = new System.Drawing.Point(95, 58);
            this.txt_busca.Name = "txt_busca";
            this.txt_busca.Size = new System.Drawing.Size(360, 27);
            this.txt_busca.TabIndex = 2;
            this.txt_busca.TextChanged += new System.EventHandler(this.txt_busca_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 100);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(913, 360);
            this.dataGridView1.TabIndex = 3;
            // 
            // lbl_total
            // 
            this.lbl_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(25, 490);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(86, 17);
            this.lbl_total.TabIndex = 4;
            this.lbl_total.Text = "0 produto(s)";
            // 
            // cbTabelas
            // 
            this.cbTabelas.FormattingEnabled = true;
            this.cbTabelas.Location = new System.Drawing.Point(461, 62);
            this.cbTabelas.Name = "cbTabelas";
            this.cbTabelas.Size = new System.Drawing.Size(360, 21);
            this.cbTabelas.TabIndex = 7;
            this.cbTabelas.Text = "Selecionar tabela";
            this.cbTabelas.SelectedIndexChanged += new System.EventHandler(this.cbTabelas_SelectedIndexChanged_1);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.BackgroundColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.BorderColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_cancelar.BorderRadius = 40;
            this.btn_cancelar.BorderSize = 3;
            this.btn_cancelar.FlatAppearance.BorderSize = 0;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_cancelar.Location = new System.Drawing.Point(671, 480);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(130, 43);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // buttonPersonalizado1
            // 
            this.buttonPersonalizado1.BackColor = System.Drawing.Color.Red;
            this.buttonPersonalizado1.BackgroundColor = System.Drawing.Color.Red;
            this.buttonPersonalizado1.BorderColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonPersonalizado1.BorderRadius = 40;
            this.buttonPersonalizado1.BorderSize = 0;
            this.buttonPersonalizado1.FlatAppearance.BorderSize = 0;
            this.buttonPersonalizado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPersonalizado1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPersonalizado1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonPersonalizado1.Location = new System.Drawing.Point(811, 480);
            this.buttonPersonalizado1.Name = "buttonPersonalizado1";
            this.buttonPersonalizado1.Size = new System.Drawing.Size(130, 43);
            this.buttonPersonalizado1.TabIndex = 9;
            this.buttonPersonalizado1.Text = "Excluir";
            this.buttonPersonalizado1.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonPersonalizado1.UseVisualStyleBackColor = false;
            this.buttonPersonalizado1.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // frmExcluir
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.cbTabelas);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_busca);
            this.Controls.Add(this.lbl_busca);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.buttonPersonalizado1);
            this.Name = "frmExcluir";
            this.Text = "Excluir Produtos";
            this.Load += new System.EventHandler(this.frmExcluirProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_busca;
        private System.Windows.Forms.TextBox txt_busca;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.ComboBox cbTabelas;
        private classes.ButtonPersonalizado btn_cancelar;
        private classes.ButtonPersonalizado buttonPersonalizado1;
    }
}
