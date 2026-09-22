namespace SystemLivraria.forms
{
    partial class frmCadFuncionarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadFuncionarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataSet2 = new SystemLivraria.data.DataSet2();
            this.produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtosTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.ProdutosTableAdapter();
            this.lbl_nomeprod = new System.Windows.Forms.Label();
            this.lbl_cpf = new System.Windows.Forms.Label();
            this.lbl_cargo = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_dataadmissao = new System.Windows.Forms.Label();
            this.panelPersonalizado6 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.panelPersonalizado5 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_dataadmissao = new System.Windows.Forms.TextBox();
            this.panelPersonalizado4 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_cargo = new System.Windows.Forms.TextBox();
            this.panelPersonalizado3 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_cpf = new System.Windows.Forms.TextBox();
            this.panelPersonalizado2 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.panelPersonalizado1 = new SystemLivraria.classes.PanelPersonalizado();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idFunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeFunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPFFunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoFunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telFunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAdmissaoFunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailFunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelPersonalizado7 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_telefone = new System.Windows.Forms.TextBox();
            this.lbl_telefone = new System.Windows.Forms.Label();
            this.funcionariosTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.FuncionariosTableAdapter();
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
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosBindingSource)).BeginInit();
            this.panelPersonalizado7.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Gainsboro;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
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
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripButton1});
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
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Adicionar novo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de itens";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Excluir";
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
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
            // lbl_cpf
            // 
            this.lbl_cpf.AutoSize = true;
            this.lbl_cpf.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cpf.Location = new System.Drawing.Point(521, 73);
            this.lbl_cpf.Name = "lbl_cpf";
            this.lbl_cpf.Size = new System.Drawing.Size(35, 18);
            this.lbl_cpf.TabIndex = 7;
            this.lbl_cpf.Text = "CPF";
            this.lbl_cpf.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_cargo
            // 
            this.lbl_cargo.AutoSize = true;
            this.lbl_cargo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cargo.Location = new System.Drawing.Point(38, 141);
            this.lbl_cargo.Name = "lbl_cargo";
            this.lbl_cargo.Size = new System.Drawing.Size(55, 18);
            this.lbl_cargo.TabIndex = 8;
            this.lbl_cargo.Text = "Cargo";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(595, 141);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(48, 18);
            this.lbl_email.TabIndex = 9;
            this.lbl_email.Text = "Email";
            this.lbl_email.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_dataadmissao
            // 
            this.lbl_dataadmissao.AutoSize = true;
            this.lbl_dataadmissao.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dataadmissao.Location = new System.Drawing.Point(366, 141);
            this.lbl_dataadmissao.Name = "lbl_dataadmissao";
            this.lbl_dataadmissao.Size = new System.Drawing.Size(142, 18);
            this.lbl_dataadmissao.TabIndex = 10;
            this.lbl_dataadmissao.Text = "Data de Admissão";
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
            this.panelPersonalizado6.Location = new System.Drawing.Point(583, 164);
            this.panelPersonalizado6.Name = "panelPersonalizado6";
            this.panelPersonalizado6.Size = new System.Drawing.Size(366, 31);
            this.panelPersonalizado6.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(366, 3);
            this.panel5.TabIndex = 1;
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(15, 5);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(394, 20);
            this.txt_email.TabIndex = 0;
            // 
            // panelPersonalizado5
            // 
            this.panelPersonalizado5.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.BorderRadius = 30;
            this.panelPersonalizado5.Controls.Add(this.panel4);
            this.panelPersonalizado5.Controls.Add(this.txt_dataadmissao);
            this.panelPersonalizado5.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado5.GradientAngle = 90F;
            this.panelPersonalizado5.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.Location = new System.Drawing.Point(354, 164);
            this.panelPersonalizado5.Name = "panelPersonalizado5";
            this.panelPersonalizado5.Size = new System.Drawing.Size(199, 31);
            this.panelPersonalizado5.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(199, 3);
            this.panel4.TabIndex = 1;
            // 
            // txt_dataadmissao
            // 
            this.txt_dataadmissao.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_dataadmissao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dataadmissao.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dataadmissao.Location = new System.Drawing.Point(15, 5);
            this.txt_dataadmissao.Name = "txt_dataadmissao";
            this.txt_dataadmissao.Size = new System.Drawing.Size(182, 20);
            this.txt_dataadmissao.TabIndex = 0;
            // 
            // panelPersonalizado4
            // 
            this.panelPersonalizado4.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.BorderRadius = 30;
            this.panelPersonalizado4.Controls.Add(this.panel3);
            this.panelPersonalizado4.Controls.Add(this.txt_cargo);
            this.panelPersonalizado4.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado4.GradientAngle = 90F;
            this.panelPersonalizado4.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.Location = new System.Drawing.Point(27, 164);
            this.panelPersonalizado4.Name = "panelPersonalizado4";
            this.panelPersonalizado4.Size = new System.Drawing.Size(297, 31);
            this.panelPersonalizado4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 3);
            this.panel3.TabIndex = 1;
            // 
            // txt_cargo
            // 
            this.txt_cargo.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_cargo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cargo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cargo.Location = new System.Drawing.Point(15, 5);
            this.txt_cargo.Name = "txt_cargo";
            this.txt_cargo.Size = new System.Drawing.Size(228, 20);
            this.txt_cargo.TabIndex = 0;
            // 
            // panelPersonalizado3
            // 
            this.panelPersonalizado3.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.BorderRadius = 30;
            this.panelPersonalizado3.Controls.Add(this.panel2);
            this.panelPersonalizado3.Controls.Add(this.txt_cpf);
            this.panelPersonalizado3.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado3.GradientAngle = 90F;
            this.panelPersonalizado3.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.Location = new System.Drawing.Point(509, 96);
            this.panelPersonalizado3.Name = "panelPersonalizado3";
            this.panelPersonalizado3.Size = new System.Drawing.Size(212, 31);
            this.panelPersonalizado3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 3);
            this.panel2.TabIndex = 1;
            // 
            // txt_cpf
            // 
            this.txt_cpf.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_cpf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cpf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpf.Location = new System.Drawing.Point(15, 5);
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(194, 20);
            this.txt_cpf.TabIndex = 0;
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
            this.idFunciDataGridViewTextBoxColumn,
            this.nomeFunciDataGridViewTextBoxColumn,
            this.cPFFunciDataGridViewTextBoxColumn,
            this.cargoFunciDataGridViewTextBoxColumn,
            this.telFunciDataGridViewTextBoxColumn,
            this.dataAdmissaoFunciDataGridViewTextBoxColumn,
            this.emailFunciDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.funcionariosBindingSource;
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
            // idFunciDataGridViewTextBoxColumn
            // 
            this.idFunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idFunciDataGridViewTextBoxColumn.DataPropertyName = "Id_Funci";
            this.idFunciDataGridViewTextBoxColumn.FillWeight = 80F;
            this.idFunciDataGridViewTextBoxColumn.HeaderText = "Id_Funci";
            this.idFunciDataGridViewTextBoxColumn.Name = "idFunciDataGridViewTextBoxColumn";
            this.idFunciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeFunciDataGridViewTextBoxColumn
            // 
            this.nomeFunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeFunciDataGridViewTextBoxColumn.DataPropertyName = "Nome_Funci";
            this.nomeFunciDataGridViewTextBoxColumn.FillWeight = 150F;
            this.nomeFunciDataGridViewTextBoxColumn.HeaderText = "Nome_Funci";
            this.nomeFunciDataGridViewTextBoxColumn.Name = "nomeFunciDataGridViewTextBoxColumn";
            this.nomeFunciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cPFFunciDataGridViewTextBoxColumn
            // 
            this.cPFFunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPFFunciDataGridViewTextBoxColumn.DataPropertyName = "CPF_Funci";
            this.cPFFunciDataGridViewTextBoxColumn.HeaderText = "CPF_Funci";
            this.cPFFunciDataGridViewTextBoxColumn.Name = "cPFFunciDataGridViewTextBoxColumn";
            this.cPFFunciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cargoFunciDataGridViewTextBoxColumn
            // 
            this.cargoFunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cargoFunciDataGridViewTextBoxColumn.DataPropertyName = "Cargo_Funci";
            this.cargoFunciDataGridViewTextBoxColumn.HeaderText = "Cargo_Funci";
            this.cargoFunciDataGridViewTextBoxColumn.Name = "cargoFunciDataGridViewTextBoxColumn";
            this.cargoFunciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telFunciDataGridViewTextBoxColumn
            // 
            this.telFunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telFunciDataGridViewTextBoxColumn.DataPropertyName = "Tel_Funci";
            this.telFunciDataGridViewTextBoxColumn.HeaderText = "Tel_Funci";
            this.telFunciDataGridViewTextBoxColumn.Name = "telFunciDataGridViewTextBoxColumn";
            this.telFunciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataAdmissaoFunciDataGridViewTextBoxColumn
            // 
            this.dataAdmissaoFunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataAdmissaoFunciDataGridViewTextBoxColumn.DataPropertyName = "DataAdmissao_Funci";
            this.dataAdmissaoFunciDataGridViewTextBoxColumn.FillWeight = 120F;
            this.dataAdmissaoFunciDataGridViewTextBoxColumn.HeaderText = "DataAdmissao_Funci";
            this.dataAdmissaoFunciDataGridViewTextBoxColumn.Name = "dataAdmissaoFunciDataGridViewTextBoxColumn";
            this.dataAdmissaoFunciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailFunciDataGridViewTextBoxColumn
            // 
            this.emailFunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.emailFunciDataGridViewTextBoxColumn.DataPropertyName = "Email_Funci";
            this.emailFunciDataGridViewTextBoxColumn.FillWeight = 150F;
            this.emailFunciDataGridViewTextBoxColumn.HeaderText = "Email_Funci";
            this.emailFunciDataGridViewTextBoxColumn.Name = "emailFunciDataGridViewTextBoxColumn";
            this.emailFunciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // funcionariosBindingSource
            // 
            this.funcionariosBindingSource.DataMember = "Funcionarios";
            this.funcionariosBindingSource.DataSource = this.dataSet2;
            // 
            // panelPersonalizado7
            // 
            this.panelPersonalizado7.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado7.BorderRadius = 30;
            this.panelPersonalizado7.Controls.Add(this.panel6);
            this.panelPersonalizado7.Controls.Add(this.txt_telefone);
            this.panelPersonalizado7.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado7.GradientAngle = 90F;
            this.panelPersonalizado7.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado7.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado7.Location = new System.Drawing.Point(751, 94);
            this.panelPersonalizado7.Name = "panelPersonalizado7";
            this.panelPersonalizado7.Size = new System.Drawing.Size(198, 31);
            this.panelPersonalizado7.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(198, 3);
            this.panel6.TabIndex = 1;
            // 
            // txt_telefone
            // 
            this.txt_telefone.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_telefone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_telefone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_telefone.Location = new System.Drawing.Point(15, 5);
            this.txt_telefone.Name = "txt_telefone";
            this.txt_telefone.Size = new System.Drawing.Size(179, 20);
            this.txt_telefone.TabIndex = 0;
            // 
            // lbl_telefone
            // 
            this.lbl_telefone.AutoSize = true;
            this.lbl_telefone.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefone.Location = new System.Drawing.Point(763, 73);
            this.lbl_telefone.Name = "lbl_telefone";
            this.lbl_telefone.Size = new System.Drawing.Size(71, 18);
            this.lbl_telefone.TabIndex = 16;
            this.lbl_telefone.Text = "Telefone";
            // 
            // funcionariosTableAdapter
            // 
            this.funcionariosTableAdapter.ClearBeforeFill = true;
            // 
            // frmCadFuncionarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.lbl_telefone);
            this.Controls.Add(this.panelPersonalizado7);
            this.Controls.Add(this.panelPersonalizado6);
            this.Controls.Add(this.panelPersonalizado5);
            this.Controls.Add(this.panelPersonalizado4);
            this.Controls.Add(this.panelPersonalizado3);
            this.Controls.Add(this.panelPersonalizado2);
            this.Controls.Add(this.lbl_dataadmissao);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_cargo);
            this.Controls.Add(this.lbl_cpf);
            this.Controls.Add(this.lbl_nomeprod);
            this.Controls.Add(this.panelPersonalizado1);
            this.Controls.Add(this.bindingNavigator1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCadFuncionarios";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de Produtos";
            this.Load += new System.EventHandler(this.frmCadProdutos_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosBindingSource)).EndInit();
            this.panelPersonalizado7.ResumeLayout(false);
            this.panelPersonalizado7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private classes.PanelPersonalizado panelPersonalizado1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private data.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource produtosBindingSource;
        private data.DataSet2TableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.Label lbl_nomeprod;
        private System.Windows.Forms.Label lbl_cpf;
        private System.Windows.Forms.Label lbl_cargo;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_dataadmissao;
        private classes.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Panel panel1;
        private classes.PanelPersonalizado panelPersonalizado3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_cpf;
        private classes.PanelPersonalizado panelPersonalizado4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_cargo;
        private classes.PanelPersonalizado panelPersonalizado5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_dataadmissao;
        private classes.PanelPersonalizado panelPersonalizado6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_email;
        private classes.PanelPersonalizado panelPersonalizado7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txt_telefone;
        private System.Windows.Forms.Label lbl_telefone;
        private System.Windows.Forms.BindingSource funcionariosBindingSource;
        private data.DataSet2TableAdapters.FuncionariosTableAdapter funcionariosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFunciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeFunciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPFFunciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoFunciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telFunciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataAdmissaoFunciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailFunciDataGridViewTextBoxColumn;
    }
}