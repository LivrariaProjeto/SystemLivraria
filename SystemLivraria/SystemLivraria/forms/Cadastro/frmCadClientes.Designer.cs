namespace SystemLivraria.forms
{
    partial class frmCadClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataSet2 = new SystemLivraria.data.DataSet2();
            this.produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtosTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.ProdutosTableAdapter();
            this.lbl_nomeprod = new System.Windows.Forms.Label();
            this.lbl_telefone = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_endereco = new System.Windows.Forms.Label();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clienteTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.ClienteTableAdapter();
            this.lbl_cpf = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_adicionar = new SystemLivraria.classes.ButtonPersonalizado();
            this.btn_limpar = new SystemLivraria.classes.ButtonPersonalizado();
            this.btn_salvar = new SystemLivraria.classes.ButtonPersonalizado();
            this.panelPersonalizado6 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_endereco = new System.Windows.Forms.TextBox();
            this.panelPersonalizado5 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_cpf = new System.Windows.Forms.TextBox();
            this.panelPersonalizado4 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.panelPersonalizado3 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_telefone = new System.Windows.Forms.TextBox();
            this.panelPersonalizado2 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.DataGridView = new SystemLivraria.classes.PanelPersonalizado();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPFCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enderecoCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            this.panelPersonalizado6.SuspendLayout();
            this.panelPersonalizado5.SuspendLayout();
            this.panelPersonalizado4.SuspendLayout();
            this.panelPersonalizado3.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            this.DataGridView.SuspendLayout();
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
            // lbl_nomeprod
            // 
            this.lbl_nomeprod.AutoSize = true;
            this.lbl_nomeprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomeprod.Location = new System.Drawing.Point(38, 73);
            this.lbl_nomeprod.Name = "lbl_nomeprod";
            this.lbl_nomeprod.Size = new System.Drawing.Size(134, 18);
            this.lbl_nomeprod.TabIndex = 6;
            this.lbl_nomeprod.Text = "Nome do Cliente";
            this.lbl_nomeprod.Click += new System.EventHandler(this.lbl__Click);
            // 
            // lbl_telefone
            // 
            this.lbl_telefone.AutoSize = true;
            this.lbl_telefone.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefone.Location = new System.Drawing.Point(521, 73);
            this.lbl_telefone.Name = "lbl_telefone";
            this.lbl_telefone.Size = new System.Drawing.Size(71, 18);
            this.lbl_telefone.TabIndex = 7;
            this.lbl_telefone.Text = "Telefone";
            this.lbl_telefone.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(38, 141);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(48, 18);
            this.lbl_email.TabIndex = 8;
            this.lbl_email.Text = "Email";
            // 
            // lbl_endereco
            // 
            this.lbl_endereco.AutoSize = true;
            this.lbl_endereco.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_endereco.Location = new System.Drawing.Point(521, 143);
            this.lbl_endereco.Name = "lbl_endereco";
            this.lbl_endereco.Size = new System.Drawing.Size(70, 18);
            this.lbl_endereco.TabIndex = 9;
            this.lbl_endereco.Text = "Enderço";
            this.lbl_endereco.Click += new System.EventHandler(this.label3_Click);
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "Cliente";
            this.clienteBindingSource.DataSource = this.dataSet2;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // lbl_cpf
            // 
            this.lbl_cpf.AutoSize = true;
            this.lbl_cpf.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cpf.Location = new System.Drawing.Point(751, 73);
            this.lbl_cpf.Name = "lbl_cpf";
            this.lbl_cpf.Size = new System.Drawing.Size(35, 18);
            this.lbl_cpf.TabIndex = 10;
            this.lbl_cpf.Text = "CPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cadastro de Clientes";
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
            this.btn_adicionar.Location = new System.Drawing.Point(30, 227);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(177, 40);
            this.btn_adicionar.TabIndex = 20;
            this.btn_adicionar.Text = "ADICIONAR";
            this.btn_adicionar.TextColor = System.Drawing.Color.White;
            this.btn_adicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_adicionar.UseVisualStyleBackColor = false;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
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
            this.btn_limpar.Location = new System.Drawing.Point(454, 227);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(177, 40);
            this.btn_limpar.TabIndex = 19;
            this.btn_limpar.Text = "LIMPAR";
            this.btn_limpar.TextColor = System.Drawing.Color.White;
            this.btn_limpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_limpar.UseVisualStyleBackColor = false;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);
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
            this.btn_salvar.Location = new System.Drawing.Point(242, 227);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(177, 40);
            this.btn_salvar.TabIndex = 18;
            this.btn_salvar.Text = "SALVAR";
            this.btn_salvar.TextColor = System.Drawing.Color.White;
            this.btn_salvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_salvar.UseVisualStyleBackColor = false;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // panelPersonalizado6
            // 
            this.panelPersonalizado6.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.BorderRadius = 30;
            this.panelPersonalizado6.Controls.Add(this.panel5);
            this.panelPersonalizado6.Controls.Add(this.txt_endereco);
            this.panelPersonalizado6.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado6.GradientAngle = 90F;
            this.panelPersonalizado6.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.Location = new System.Drawing.Point(509, 164);
            this.panelPersonalizado6.Name = "panelPersonalizado6";
            this.panelPersonalizado6.Size = new System.Drawing.Size(430, 31);
            this.panelPersonalizado6.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(430, 3);
            this.panel5.TabIndex = 1;
            // 
            // txt_endereco
            // 
            this.txt_endereco.BackColor = System.Drawing.Color.Silver;
            this.txt_endereco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_endereco.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_endereco.Location = new System.Drawing.Point(15, 5);
            this.txt_endereco.Name = "txt_endereco";
            this.txt_endereco.Size = new System.Drawing.Size(412, 20);
            this.txt_endereco.TabIndex = 0;
            // 
            // panelPersonalizado5
            // 
            this.panelPersonalizado5.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.BorderRadius = 30;
            this.panelPersonalizado5.Controls.Add(this.panel4);
            this.panelPersonalizado5.Controls.Add(this.txt_cpf);
            this.panelPersonalizado5.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado5.GradientAngle = 90F;
            this.panelPersonalizado5.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.Location = new System.Drawing.Point(739, 96);
            this.panelPersonalizado5.Name = "panelPersonalizado5";
            this.panelPersonalizado5.Size = new System.Drawing.Size(200, 31);
            this.panelPersonalizado5.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 3);
            this.panel4.TabIndex = 1;
            // 
            // txt_cpf
            // 
            this.txt_cpf.BackColor = System.Drawing.Color.Silver;
            this.txt_cpf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cpf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpf.Location = new System.Drawing.Point(15, 5);
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(182, 20);
            this.txt_cpf.TabIndex = 0;
            // 
            // panelPersonalizado4
            // 
            this.panelPersonalizado4.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.BorderRadius = 30;
            this.panelPersonalizado4.Controls.Add(this.panel3);
            this.panelPersonalizado4.Controls.Add(this.txt_email);
            this.panelPersonalizado4.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado4.GradientAngle = 90F;
            this.panelPersonalizado4.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.Location = new System.Drawing.Point(27, 164);
            this.panelPersonalizado4.Name = "panelPersonalizado4";
            this.panelPersonalizado4.Size = new System.Drawing.Size(452, 31);
            this.panelPersonalizado4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(452, 3);
            this.panel3.TabIndex = 1;
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.Silver;
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(15, 5);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(431, 20);
            this.txt_email.TabIndex = 0;
            // 
            // panelPersonalizado3
            // 
            this.panelPersonalizado3.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.BorderRadius = 30;
            this.panelPersonalizado3.Controls.Add(this.panel2);
            this.panelPersonalizado3.Controls.Add(this.txt_telefone);
            this.panelPersonalizado3.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado3.GradientAngle = 90F;
            this.panelPersonalizado3.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.Location = new System.Drawing.Point(509, 96);
            this.panelPersonalizado3.Name = "panelPersonalizado3";
            this.panelPersonalizado3.Size = new System.Drawing.Size(200, 31);
            this.panelPersonalizado3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 3);
            this.panel2.TabIndex = 1;
            // 
            // txt_telefone
            // 
            this.txt_telefone.BackColor = System.Drawing.Color.Silver;
            this.txt_telefone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_telefone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_telefone.Location = new System.Drawing.Point(15, 5);
            this.txt_telefone.Name = "txt_telefone";
            this.txt_telefone.Size = new System.Drawing.Size(182, 20);
            this.txt_telefone.TabIndex = 0;
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
            // DataGridView
            // 
            this.DataGridView.BackColor = System.Drawing.Color.Turquoise;
            this.DataGridView.BorderRadius = 20;
            this.DataGridView.Controls.Add(this.dataGridView1);
            this.DataGridView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.DataGridView.GradientAngle = 90F;
            this.DataGridView.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.DataGridView.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.DataGridView.Location = new System.Drawing.Point(20, 286);
            this.DataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Padding = new System.Windows.Forms.Padding(4, 0, 4, 15);
            this.DataGridView.Size = new System.Drawing.Size(929, 239);
            this.DataGridView.TabIndex = 1;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCliDataGridViewTextBoxColumn,
            this.nomeCliDataGridViewTextBoxColumn,
            this.telCliDataGridViewTextBoxColumn,
            this.cPFCliDataGridViewTextBoxColumn,
            this.emailCliDataGridViewTextBoxColumn,
            this.enderecoCliDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clienteBindingSource;
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
            this.dataGridView1.Size = new System.Drawing.Size(921, 224);
            this.dataGridView1.TabIndex = 0;
            // 
            // idCliDataGridViewTextBoxColumn
            // 
            this.idCliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idCliDataGridViewTextBoxColumn.DataPropertyName = "Id_Cli";
            this.idCliDataGridViewTextBoxColumn.FillWeight = 80F;
            this.idCliDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idCliDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idCliDataGridViewTextBoxColumn.Name = "idCliDataGridViewTextBoxColumn";
            this.idCliDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeCliDataGridViewTextBoxColumn
            // 
            this.nomeCliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeCliDataGridViewTextBoxColumn.DataPropertyName = "Nome_Cli";
            this.nomeCliDataGridViewTextBoxColumn.FillWeight = 150F;
            this.nomeCliDataGridViewTextBoxColumn.HeaderText = "NOME";
            this.nomeCliDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeCliDataGridViewTextBoxColumn.Name = "nomeCliDataGridViewTextBoxColumn";
            this.nomeCliDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telCliDataGridViewTextBoxColumn
            // 
            this.telCliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telCliDataGridViewTextBoxColumn.DataPropertyName = "Tel_Cli";
            this.telCliDataGridViewTextBoxColumn.HeaderText = "TELEFONE";
            this.telCliDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.telCliDataGridViewTextBoxColumn.Name = "telCliDataGridViewTextBoxColumn";
            this.telCliDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cPFCliDataGridViewTextBoxColumn
            // 
            this.cPFCliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPFCliDataGridViewTextBoxColumn.DataPropertyName = "CPF_Cli";
            this.cPFCliDataGridViewTextBoxColumn.HeaderText = "CPF";
            this.cPFCliDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cPFCliDataGridViewTextBoxColumn.Name = "cPFCliDataGridViewTextBoxColumn";
            this.cPFCliDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailCliDataGridViewTextBoxColumn
            // 
            this.emailCliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.emailCliDataGridViewTextBoxColumn.DataPropertyName = "Email_Cli";
            this.emailCliDataGridViewTextBoxColumn.FillWeight = 150F;
            this.emailCliDataGridViewTextBoxColumn.HeaderText = "EMAIL";
            this.emailCliDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailCliDataGridViewTextBoxColumn.Name = "emailCliDataGridViewTextBoxColumn";
            this.emailCliDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // enderecoCliDataGridViewTextBoxColumn
            // 
            this.enderecoCliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.enderecoCliDataGridViewTextBoxColumn.DataPropertyName = "Endereco_Cli";
            this.enderecoCliDataGridViewTextBoxColumn.FillWeight = 150F;
            this.enderecoCliDataGridViewTextBoxColumn.HeaderText = "ENDEREÇO";
            this.enderecoCliDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.enderecoCliDataGridViewTextBoxColumn.Name = "enderecoCliDataGridViewTextBoxColumn";
            this.enderecoCliDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmCadClientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.btn_adicionar);
            this.Controls.Add(this.btn_limpar);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelPersonalizado6);
            this.Controls.Add(this.panelPersonalizado5);
            this.Controls.Add(this.panelPersonalizado4);
            this.Controls.Add(this.panelPersonalizado3);
            this.Controls.Add(this.panelPersonalizado2);
            this.Controls.Add(this.lbl_cpf);
            this.Controls.Add(this.lbl_endereco);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_telefone);
            this.Controls.Add(this.lbl_nomeprod);
            this.Controls.Add(this.DataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCadClientes";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de Clientes";
            this.Load += new System.EventHandler(this.frmCadClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            this.panelPersonalizado6.ResumeLayout(false);
            this.panelPersonalizado6.PerformLayout();
            this.panelPersonalizado5.ResumeLayout(false);
            this.panelPersonalizado5.PerformLayout();
            this.panelPersonalizado4.ResumeLayout(false);
            this.panelPersonalizado4.PerformLayout();
            this.panelPersonalizado3.ResumeLayout(false);
            this.panelPersonalizado3.PerformLayout();
            this.panelPersonalizado2.ResumeLayout(false);
            this.panelPersonalizado2.PerformLayout();
            this.DataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private classes.PanelPersonalizado DataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private data.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource produtosBindingSource;
        private data.DataSet2TableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.Label lbl_nomeprod;
        private System.Windows.Forms.Label lbl_telefone;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_endereco;
        private classes.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Panel panel1;
        private classes.PanelPersonalizado panelPersonalizado3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_telefone;
        private classes.PanelPersonalizado panelPersonalizado4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_email;
        private classes.PanelPersonalizado panelPersonalizado6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_endereco;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private data.DataSet2TableAdapters.ClienteTableAdapter clienteTableAdapter;
        private System.Windows.Forms.Label lbl_cpf;
        private System.Windows.Forms.TextBox txt_cpf;
        private System.Windows.Forms.Panel panel4;
        private classes.PanelPersonalizado panelPersonalizado5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPFCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecoCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private classes.ButtonPersonalizado btn_adicionar;
        private classes.ButtonPersonalizado btn_limpar;
        private classes.ButtonPersonalizado btn_salvar;
    }
}