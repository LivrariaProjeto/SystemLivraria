namespace SystemLivraria.forms
{
    partial class frmCadAutores
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadAutores));
            this.dataSet2 = new SystemLivraria.data.DataSet2();
            this.produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtosTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.ProdutosTableAdapter();
            this.lbl_nomeautor = new System.Windows.Forms.Label();
            this.lbl_paisautor = new System.Windows.Forms.Label();
            this.autoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.autoresTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.AutoresTableAdapter();
            this.autoresBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.funcionariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.funcionariosTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.FuncionariosTableAdapter();
            this.panelPersonalizado3 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_pais = new System.Windows.Forms.TextBox();
            this.panelPersonalizado2 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.panelPersonalizado1 = new SystemLivraria.classes.PanelPersonalizado();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idAutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeAutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paisAutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.img_botoes = new System.Windows.Forms.ImageList(this.components);
            this.btn_salvar = new SystemLivraria.classes.ButtonPersonalizado();
            this.btn_limpar = new SystemLivraria.classes.ButtonPersonalizado();
            this.btn_adicionar = new SystemLivraria.classes.ButtonPersonalizado();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoresBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosBindingSource)).BeginInit();
            this.panelPersonalizado3.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            this.panelPersonalizado1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produtosBindingSource
            // 
            this.produtosBindingSource.DataMember = "Produtos";
            this.produtosBindingSource.DataSource = this.dataSet2;
            // 
            // produtosTableAdapter
            // 
            this.produtosTableAdapter.ClearBeforeFill = true;
            // 
            // lbl_nomeautor
            // 
            this.lbl_nomeautor.AutoSize = true;
            this.lbl_nomeautor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomeautor.Location = new System.Drawing.Point(38, 73);
            this.lbl_nomeautor.Name = "lbl_nomeautor";
            this.lbl_nomeautor.Size = new System.Drawing.Size(120, 18);
            this.lbl_nomeautor.TabIndex = 6;
            this.lbl_nomeautor.Text = "Nome do Autor";
            this.lbl_nomeautor.Click += new System.EventHandler(this.lbl__Click);
            // 
            // lbl_paisautor
            // 
            this.lbl_paisautor.AutoSize = true;
            this.lbl_paisautor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paisautor.Location = new System.Drawing.Point(521, 73);
            this.lbl_paisautor.Name = "lbl_paisautor";
            this.lbl_paisautor.Size = new System.Drawing.Size(103, 18);
            this.lbl_paisautor.TabIndex = 7;
            this.lbl_paisautor.Text = "País do Autor";
            this.lbl_paisautor.Click += new System.EventHandler(this.label1_Click);
            // 
            // autoresBindingSource
            // 
            this.autoresBindingSource.DataMember = "Autores";
            this.autoresBindingSource.DataSource = this.dataSet2;
            // 
            // autoresTableAdapter
            // 
            this.autoresTableAdapter.ClearBeforeFill = true;
            // 
            // autoresBindingSource1
            // 
            this.autoresBindingSource1.DataMember = "Autores";
            this.autoresBindingSource1.DataSource = this.dataSet2;
            // 
            // funcionariosBindingSource
            // 
            this.funcionariosBindingSource.DataMember = "Funcionarios";
            this.funcionariosBindingSource.DataSource = this.dataSet2;
            // 
            // funcionariosTableAdapter
            // 
            this.funcionariosTableAdapter.ClearBeforeFill = true;
            // 
            // panelPersonalizado3
            // 
            this.panelPersonalizado3.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.BorderRadius = 30;
            this.panelPersonalizado3.Controls.Add(this.panel2);
            this.panelPersonalizado3.Controls.Add(this.txt_pais);
            this.panelPersonalizado3.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado3.GradientAngle = 90F;
            this.panelPersonalizado3.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.Location = new System.Drawing.Point(509, 96);
            this.panelPersonalizado3.Name = "panelPersonalizado3";
            this.panelPersonalizado3.Size = new System.Drawing.Size(440, 31);
            this.panelPersonalizado3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 3);
            this.panel2.TabIndex = 1;
            // 
            // txt_pais
            // 
            this.txt_pais.BackColor = System.Drawing.Color.Silver;
            this.txt_pais.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pais.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pais.Location = new System.Drawing.Point(15, 5);
            this.txt_pais.Name = "txt_pais";
            this.txt_pais.Size = new System.Drawing.Size(421, 20);
            this.txt_pais.TabIndex = 0;
            this.txt_pais.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // panelPersonalizado2
            // 
            this.panelPersonalizado2.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado2.BorderRadius = 30;
            this.panelPersonalizado2.Controls.Add(this.panel1);
            this.panelPersonalizado2.Controls.Add(this.txt_nome);
            this.panelPersonalizado2.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado2.GradientAngle = 90F;
            this.panelPersonalizado2.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado2.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado2.Location = new System.Drawing.Point(27, 96);
            this.panelPersonalizado2.Name = "panelPersonalizado2";
            this.panelPersonalizado2.Size = new System.Drawing.Size(452, 31);
            this.panelPersonalizado2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 3);
            this.panel1.TabIndex = 1;
            // 
            // txt_nome
            // 
            this.txt_nome.BackColor = System.Drawing.Color.Silver;
            this.txt_nome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nome.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome.Location = new System.Drawing.Point(15, 5);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(431, 20);
            this.txt_nome.TabIndex = 0;
            // 
            // panelPersonalizado1
            // 
            this.panelPersonalizado1.BackColor = System.Drawing.Color.Turquoise;
            this.panelPersonalizado1.BorderRadius = 20;
            this.panelPersonalizado1.Controls.Add(this.dataGridView1);
            this.panelPersonalizado1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.panelPersonalizado1.GradientAngle = 90F;
            this.panelPersonalizado1.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panelPersonalizado1.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panelPersonalizado1.Location = new System.Drawing.Point(20, 218);
            this.panelPersonalizado1.Margin = new System.Windows.Forms.Padding(0);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 15);
            this.panelPersonalizado1.Size = new System.Drawing.Size(929, 307);
            this.panelPersonalizado1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAutorDataGridViewTextBoxColumn,
            this.nomeAutorDataGridViewTextBoxColumn,
            this.paisAutorDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.autoresBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            this.dataGridView1.Location = new System.Drawing.Point(4, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(921, 292);
            this.dataGridView1.TabIndex = 0;
            // 
            // idAutorDataGridViewTextBoxColumn
            // 
            this.idAutorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idAutorDataGridViewTextBoxColumn.DataPropertyName = "Id_Autor";
            this.idAutorDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idAutorDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idAutorDataGridViewTextBoxColumn.Name = "idAutorDataGridViewTextBoxColumn";
            this.idAutorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeAutorDataGridViewTextBoxColumn
            // 
            this.nomeAutorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeAutorDataGridViewTextBoxColumn.DataPropertyName = "Nome_Autor";
            this.nomeAutorDataGridViewTextBoxColumn.FillWeight = 150F;
            this.nomeAutorDataGridViewTextBoxColumn.HeaderText = "NOME";
            this.nomeAutorDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nomeAutorDataGridViewTextBoxColumn.Name = "nomeAutorDataGridViewTextBoxColumn";
            this.nomeAutorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paisAutorDataGridViewTextBoxColumn
            // 
            this.paisAutorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paisAutorDataGridViewTextBoxColumn.DataPropertyName = "Pais_Autor";
            this.paisAutorDataGridViewTextBoxColumn.FillWeight = 150F;
            this.paisAutorDataGridViewTextBoxColumn.HeaderText = "PAÍS";
            this.paisAutorDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.paisAutorDataGridViewTextBoxColumn.Name = "paisAutorDataGridViewTextBoxColumn";
            this.paisAutorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cadastro de Autores";
            // 
            // img_botoes
            // 
            this.img_botoes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_botoes.ImageStream")));
            this.img_botoes.TransparentColor = System.Drawing.Color.Transparent;
            this.img_botoes.Images.SetKeyName(0, "adicionar.png");
            this.img_botoes.Images.SetKeyName(1, "salvar.png");
            // 
            // btn_salvar
            // 
            this.btn_salvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.btn_salvar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.btn_salvar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_salvar.BorderRadius = 40;
            this.btn_salvar.BorderSize = 0;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salvar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvar.ForeColor = System.Drawing.Color.White;
            this.btn_salvar.ImageIndex = 1;
            this.btn_salvar.Location = new System.Drawing.Point(242, 159);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(177, 40);
            this.btn_salvar.TabIndex = 15;
            this.btn_salvar.Text = "SALVAR";
            this.btn_salvar.TextColor = System.Drawing.Color.White;
            this.btn_salvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_salvar.UseVisualStyleBackColor = false;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // btn_limpar
            // 
            this.btn_limpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.btn_limpar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.btn_limpar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_limpar.BorderRadius = 40;
            this.btn_limpar.BorderSize = 0;
            this.btn_limpar.FlatAppearance.BorderSize = 0;
            this.btn_limpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_limpar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpar.ForeColor = System.Drawing.Color.White;
            this.btn_limpar.ImageIndex = 1;
            this.btn_limpar.Location = new System.Drawing.Point(454, 159);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(177, 40);
            this.btn_limpar.TabIndex = 16;
            this.btn_limpar.Text = "LIMPAR";
            this.btn_limpar.TextColor = System.Drawing.Color.White;
            this.btn_limpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_limpar.UseVisualStyleBackColor = false;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.btn_adicionar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.btn_adicionar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_adicionar.BorderRadius = 40;
            this.btn_adicionar.BorderSize = 0;
            this.btn_adicionar.FlatAppearance.BorderSize = 0;
            this.btn_adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.ForeColor = System.Drawing.Color.White;
            this.btn_adicionar.ImageIndex = 1;
            this.btn_adicionar.Location = new System.Drawing.Point(30, 159);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(177, 40);
            this.btn_adicionar.TabIndex = 17;
            this.btn_adicionar.Text = "ADICIONAR";
            this.btn_adicionar.TextColor = System.Drawing.Color.White;
            this.btn_adicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_adicionar.UseVisualStyleBackColor = false;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // frmCadAutores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.btn_adicionar);
            this.Controls.Add(this.btn_limpar);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelPersonalizado3);
            this.Controls.Add(this.panelPersonalizado2);
            this.Controls.Add(this.lbl_paisautor);
            this.Controls.Add(this.lbl_nomeautor);
            this.Controls.Add(this.panelPersonalizado1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCadAutores";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de Autores";
            this.Load += new System.EventHandler(this.frmCadAutores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoresBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosBindingSource)).EndInit();
            this.panelPersonalizado3.ResumeLayout(false);
            this.panelPersonalizado3.PerformLayout();
            this.panelPersonalizado2.ResumeLayout(false);
            this.panelPersonalizado2.PerformLayout();
            this.panelPersonalizado1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private classes.PanelPersonalizado panelPersonalizado1;
        private data.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource produtosBindingSource;
        private data.DataSet2TableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.Label lbl_nomeautor;
        private System.Windows.Forms.Label lbl_paisautor;
        private classes.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Panel panel1;
        private classes.PanelPersonalizado panelPersonalizado3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_pais;
        private System.Windows.Forms.BindingSource autoresBindingSource;
        private data.DataSet2TableAdapters.AutoresTableAdapter autoresTableAdapter;
        private System.Windows.Forms.BindingSource autoresBindingSource1;
        private System.Windows.Forms.BindingSource funcionariosBindingSource;
        private data.DataSet2TableAdapters.FuncionariosTableAdapter funcionariosTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeAutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paisAutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private classes.ButtonPersonalizado btn_salvar;
        private System.Windows.Forms.ImageList img_botoes;
        private classes.ButtonPersonalizado btn_limpar;
        private classes.ButtonPersonalizado btn_adicionar;
    }
}