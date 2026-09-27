namespace SystemLivraria.forms
{
    partial class frmCadFornecedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadFornecedores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdicionar_Fornecedores = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.btnExcluir_Fornecedores = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalvar_Fornecedores = new System.Windows.Forms.ToolStripButton();
            this.dataSet2 = new SystemLivraria.data.DataSet2();
            this.produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtosTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.ProdutosTableAdapter();
            this.lbl_nomeprod = new System.Windows.Forms.Label();
            this.lbl_endereco = new System.Windows.Forms.Label();
            this.lbl_editoraprod = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_telefone = new System.Windows.Forms.Label();
            this.panelPersonalizado6 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.panelPersonalizado5 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_telefone = new System.Windows.Forms.TextBox();
            this.panelPersonalizado4 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_cnpj = new System.Windows.Forms.TextBox();
            this.panelPersonalizado3 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_endereco = new System.Windows.Forms.TextBox();
            this.panelPersonalizado2 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.panelPersonalizado1 = new SystemLivraria.classes.PanelPersonalizado();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idForneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeForneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enderecoForneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNPJForneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telForneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailForneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fornecedoresTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.FornecedoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).BeginInit();
            this.panelPersonalizado6.SuspendLayout();
            this.panelPersonalizado5.SuspendLayout();
            this.panelPersonalizado4.SuspendLayout();
            this.panelPersonalizado3.SuspendLayout();
            this.panelPersonalizado2.SuspendLayout();
            this.panelPersonalizado1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.btnAdicionar_Fornecedores;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Gainsboro;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.btnExcluir_Fornecedores;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnAdicionar_Fornecedores,
            this.btnExcluir_Fornecedores,
            this.btnSalvar_Fornecedores});
            this.bindingNavigator1.Location = new System.Drawing.Point(20, 20);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(929, 25);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnAdicionar_Fornecedores
            // 
            this.btnAdicionar_Fornecedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdicionar_Fornecedores.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar_Fornecedores.Image")));
            this.btnAdicionar_Fornecedores.Name = "btnAdicionar_Fornecedores";
            this.btnAdicionar_Fornecedores.RightToLeftAutoMirrorImage = true;
            this.btnAdicionar_Fornecedores.Size = new System.Drawing.Size(23, 22);
            this.btnAdicionar_Fornecedores.Text = "Adicionar novo";
            this.btnAdicionar_Fornecedores.Click += new System.EventHandler(this.btnAdicionar_Fornecedores_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de itens";
            // 
            // btnExcluir_Fornecedores
            // 
            this.btnExcluir_Fornecedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir_Fornecedores.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir_Fornecedores.Image")));
            this.btnExcluir_Fornecedores.Name = "btnExcluir_Fornecedores";
            this.btnExcluir_Fornecedores.RightToLeftAutoMirrorImage = true;
            this.btnExcluir_Fornecedores.Size = new System.Drawing.Size(23, 22);
            this.btnExcluir_Fornecedores.Text = "Excluir";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primeiro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posição";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posição atual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover próximo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSalvar_Fornecedores
            // 
            this.btnSalvar_Fornecedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalvar_Fornecedores.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar_Fornecedores.Image")));
            this.btnSalvar_Fornecedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar_Fornecedores.Name = "btnSalvar_Fornecedores";
            this.btnSalvar_Fornecedores.Size = new System.Drawing.Size(23, 22);
            this.btnSalvar_Fornecedores.Text = "toolStripButton1";
            this.btnSalvar_Fornecedores.Click += new System.EventHandler(this.btnSalvar_Fornecedores_Click);
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
            this.lbl_nomeprod.Size = new System.Drawing.Size(53, 18);
            this.lbl_nomeprod.TabIndex = 6;
            this.lbl_nomeprod.Text = "Nome";
            this.lbl_nomeprod.Click += new System.EventHandler(this.lbl__Click);
            // 
            // lbl_endereco
            // 
            this.lbl_endereco.AutoSize = true;
            this.lbl_endereco.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_endereco.Location = new System.Drawing.Point(521, 73);
            this.lbl_endereco.Name = "lbl_endereco";
            this.lbl_endereco.Size = new System.Drawing.Size(80, 18);
            this.lbl_endereco.TabIndex = 7;
            this.lbl_endereco.Text = "Endereço";
            this.lbl_endereco.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_editoraprod
            // 
            this.lbl_editoraprod.AutoSize = true;
            this.lbl_editoraprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_editoraprod.Location = new System.Drawing.Point(38, 141);
            this.lbl_editoraprod.Name = "lbl_editoraprod";
            this.lbl_editoraprod.Size = new System.Drawing.Size(46, 18);
            this.lbl_editoraprod.TabIndex = 8;
            this.lbl_editoraprod.Text = "CNPJ";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(607, 143);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(48, 18);
            this.lbl_email.TabIndex = 9;
            this.lbl_email.Text = "Email";
            this.lbl_email.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_telefone
            // 
            this.lbl_telefone.AutoSize = true;
            this.lbl_telefone.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefone.Location = new System.Drawing.Point(318, 141);
            this.lbl_telefone.Name = "lbl_telefone";
            this.lbl_telefone.Size = new System.Drawing.Size(71, 18);
            this.lbl_telefone.TabIndex = 10;
            this.lbl_telefone.Text = "Telefone";
            // 
            // panelPersonalizado6
            // 
            this.panelPersonalizado6.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.BorderRadius = 30;
            this.panelPersonalizado6.Controls.Add(this.panel5);
            this.panelPersonalizado6.Controls.Add(this.txt_email);
            this.panelPersonalizado6.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado6.GradientAngle = 90F;
            this.panelPersonalizado6.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.Location = new System.Drawing.Point(595, 164);
            this.panelPersonalizado6.Name = "panelPersonalizado6";
            this.panelPersonalizado6.Size = new System.Drawing.Size(354, 31);
            this.panelPersonalizado6.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(354, 3);
            this.panel5.TabIndex = 1;
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(15, 5);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(335, 20);
            this.txt_email.TabIndex = 0;
            // 
            // panelPersonalizado5
            // 
            this.panelPersonalizado5.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.BorderRadius = 30;
            this.panelPersonalizado5.Controls.Add(this.panel4);
            this.panelPersonalizado5.Controls.Add(this.txt_telefone);
            this.panelPersonalizado5.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado5.GradientAngle = 90F;
            this.panelPersonalizado5.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.Location = new System.Drawing.Point(303, 164);
            this.panelPersonalizado5.Name = "panelPersonalizado5";
            this.panelPersonalizado5.Size = new System.Drawing.Size(262, 31);
            this.panelPersonalizado5.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(262, 3);
            this.panel4.TabIndex = 1;
            // 
            // txt_telefone
            // 
            this.txt_telefone.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_telefone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_telefone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_telefone.Location = new System.Drawing.Point(15, 5);
            this.txt_telefone.Name = "txt_telefone";
            this.txt_telefone.Size = new System.Drawing.Size(244, 20);
            this.txt_telefone.TabIndex = 0;
            // 
            // panelPersonalizado4
            // 
            this.panelPersonalizado4.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.BorderRadius = 30;
            this.panelPersonalizado4.Controls.Add(this.panel3);
            this.panelPersonalizado4.Controls.Add(this.txt_cnpj);
            this.panelPersonalizado4.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado4.GradientAngle = 90F;
            this.panelPersonalizado4.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.Location = new System.Drawing.Point(27, 164);
            this.panelPersonalizado4.Name = "panelPersonalizado4";
            this.panelPersonalizado4.Size = new System.Drawing.Size(246, 31);
            this.panelPersonalizado4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 3);
            this.panel3.TabIndex = 1;
            // 
            // txt_cnpj
            // 
            this.txt_cnpj.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_cnpj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cnpj.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cnpj.Location = new System.Drawing.Point(15, 5);
            this.txt_cnpj.Name = "txt_cnpj";
            this.txt_cnpj.Size = new System.Drawing.Size(228, 20);
            this.txt_cnpj.TabIndex = 0;
            // 
            // panelPersonalizado3
            // 
            this.panelPersonalizado3.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.BorderRadius = 30;
            this.panelPersonalizado3.Controls.Add(this.panel2);
            this.panelPersonalizado3.Controls.Add(this.txt_endereco);
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
            // txt_endereco
            // 
            this.txt_endereco.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_endereco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_endereco.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_endereco.Location = new System.Drawing.Point(15, 5);
            this.txt_endereco.Name = "txt_endereco";
            this.txt_endereco.Size = new System.Drawing.Size(421, 20);
            this.txt_endereco.TabIndex = 0;
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
            this.txt_nome.BackColor = System.Drawing.Color.Gainsboro;
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
            this.panelPersonalizado1.Location = new System.Drawing.Point(20, 222);
            this.panelPersonalizado1.Margin = new System.Windows.Forms.Padding(0);
            this.panelPersonalizado1.Name = "panelPersonalizado1";
            this.panelPersonalizado1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 15);
            this.panelPersonalizado1.Size = new System.Drawing.Size(929, 303);
            this.panelPersonalizado1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(240)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idForneDataGridViewTextBoxColumn,
            this.nomeForneDataGridViewTextBoxColumn,
            this.enderecoForneDataGridViewTextBoxColumn,
            this.cNPJForneDataGridViewTextBoxColumn,
            this.telForneDataGridViewTextBoxColumn,
            this.emailForneDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fornecedoresBindingSource;
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
            this.dataGridView1.Size = new System.Drawing.Size(921, 288);
            this.dataGridView1.TabIndex = 0;
            // 
            // idForneDataGridViewTextBoxColumn
            // 
            this.idForneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idForneDataGridViewTextBoxColumn.DataPropertyName = "Id_Forne";
            this.idForneDataGridViewTextBoxColumn.FillWeight = 80F;
            this.idForneDataGridViewTextBoxColumn.HeaderText = "Id_Forne";
            this.idForneDataGridViewTextBoxColumn.Name = "idForneDataGridViewTextBoxColumn";
            this.idForneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeForneDataGridViewTextBoxColumn
            // 
            this.nomeForneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeForneDataGridViewTextBoxColumn.DataPropertyName = "Nome_Forne";
            this.nomeForneDataGridViewTextBoxColumn.FillWeight = 150F;
            this.nomeForneDataGridViewTextBoxColumn.HeaderText = "Nome_Forne";
            this.nomeForneDataGridViewTextBoxColumn.Name = "nomeForneDataGridViewTextBoxColumn";
            this.nomeForneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // enderecoForneDataGridViewTextBoxColumn
            // 
            this.enderecoForneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.enderecoForneDataGridViewTextBoxColumn.DataPropertyName = "Endereco_Forne";
            this.enderecoForneDataGridViewTextBoxColumn.FillWeight = 200F;
            this.enderecoForneDataGridViewTextBoxColumn.HeaderText = "Endereco_Forne";
            this.enderecoForneDataGridViewTextBoxColumn.Name = "enderecoForneDataGridViewTextBoxColumn";
            this.enderecoForneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cNPJForneDataGridViewTextBoxColumn
            // 
            this.cNPJForneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cNPJForneDataGridViewTextBoxColumn.DataPropertyName = "CNPJ_Forne";
            this.cNPJForneDataGridViewTextBoxColumn.HeaderText = "CNPJ_Forne";
            this.cNPJForneDataGridViewTextBoxColumn.Name = "cNPJForneDataGridViewTextBoxColumn";
            this.cNPJForneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telForneDataGridViewTextBoxColumn
            // 
            this.telForneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telForneDataGridViewTextBoxColumn.DataPropertyName = "Tel_Forne";
            this.telForneDataGridViewTextBoxColumn.HeaderText = "Tel_Forne";
            this.telForneDataGridViewTextBoxColumn.Name = "telForneDataGridViewTextBoxColumn";
            this.telForneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailForneDataGridViewTextBoxColumn
            // 
            this.emailForneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.emailForneDataGridViewTextBoxColumn.DataPropertyName = "Email_Forne";
            this.emailForneDataGridViewTextBoxColumn.FillWeight = 150F;
            this.emailForneDataGridViewTextBoxColumn.HeaderText = "Email_Forne";
            this.emailForneDataGridViewTextBoxColumn.Name = "emailForneDataGridViewTextBoxColumn";
            this.emailForneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fornecedoresBindingSource
            // 
            this.fornecedoresBindingSource.DataMember = "Fornecedores";
            this.fornecedoresBindingSource.DataSource = this.dataSet2;
            // 
            // fornecedoresTableAdapter
            // 
            this.fornecedoresTableAdapter.ClearBeforeFill = true;
            // 
            // frmCadFornecedores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.panelPersonalizado6);
            this.Controls.Add(this.panelPersonalizado5);
            this.Controls.Add(this.panelPersonalizado4);
            this.Controls.Add(this.panelPersonalizado3);
            this.Controls.Add(this.panelPersonalizado2);
            this.Controls.Add(this.lbl_telefone);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_editoraprod);
            this.Controls.Add(this.lbl_endereco);
            this.Controls.Add(this.lbl_nomeprod);
            this.Controls.Add(this.panelPersonalizado1);
            this.Controls.Add(this.bindingNavigator1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCadFornecedores";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de Fornecedores";
            this.Load += new System.EventHandler(this.frmCadFornecedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).EndInit();
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
            this.panelPersonalizado1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAdicionar_Fornecedores;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton btnExcluir_Fornecedores;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnSalvar_Fornecedores;
        private classes.PanelPersonalizado panelPersonalizado1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private data.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource produtosBindingSource;
        private data.DataSet2TableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.Label lbl_nomeprod;
        private System.Windows.Forms.Label lbl_endereco;
        private System.Windows.Forms.Label lbl_editoraprod;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_telefone;
        private classes.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Panel panel1;
        private classes.PanelPersonalizado panelPersonalizado3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_endereco;
        private classes.PanelPersonalizado panelPersonalizado4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_cnpj;
        private classes.PanelPersonalizado panelPersonalizado5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_telefone;
        private classes.PanelPersonalizado panelPersonalizado6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.BindingSource fornecedoresBindingSource;
        private data.DataSet2TableAdapters.FornecedoresTableAdapter fornecedoresTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idForneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeForneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecoForneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNPJForneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telForneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailForneDataGridViewTextBoxColumn;
    }
}