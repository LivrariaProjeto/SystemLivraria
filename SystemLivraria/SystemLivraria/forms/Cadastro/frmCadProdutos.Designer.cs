namespace SystemLivraria.forms
{
    partial class frmCadProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadProdutos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.CadProduto = new System.Windows.Forms.ToolStripButton();
            this.dataSet2 = new SystemLivraria.data.DataSet2();
            this.produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtosTableAdapter = new SystemLivraria.data.DataSet2TableAdapters.ProdutosTableAdapter();
            this.lbl_nomeprod = new System.Windows.Forms.Label();
            this.lbl_autorprod = new System.Windows.Forms.Label();
            this.lbl_editoraprod = new System.Windows.Forms.Label();
            this.lbl_precoprod = new System.Windows.Forms.Label();
            this.lbl_categoriaprod = new System.Windows.Forms.Label();
            this.panelPersonalizado6 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_preco = new System.Windows.Forms.TextBox();
            this.panelPersonalizado5 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_categoria = new System.Windows.Forms.TextBox();
            this.panelPersonalizado4 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_editora = new System.Windows.Forms.TextBox();
            this.panelPersonalizado3 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_autor = new System.Windows.Forms.TextBox();
            this.panelPersonalizado2 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.panelPersonalizado1 = new SystemLivraria.classes.PanelPersonalizado();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idProDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEdiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoProDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSBNProDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPersonalizado7 = new SystemLivraria.classes.PanelPersonalizado();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_isbn = new System.Windows.Forms.TextBox();
            this.lbl_isbnprod = new System.Windows.Forms.Label();
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
            this.panelPersonalizado7.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Silver;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.CadProduto});
            this.bindingNavigator1.Location = new System.Drawing.Point(20, 20);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(929, 27);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorAddNewItem.Text = "Adicionar novo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 24);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de itens";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorDeleteItem.Text = "Excluir";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primeiro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Mover próximo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // CadProduto
            // 
            this.CadProduto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CadProduto.Image = ((System.Drawing.Image)(resources.GetObject("CadProduto.Image")));
            this.CadProduto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CadProduto.Name = "CadProduto";
            this.CadProduto.Size = new System.Drawing.Size(24, 24);
            this.CadProduto.Text = "Cadastrar Produto";
            this.CadProduto.Click += new System.EventHandler(this.CadProduto_Click);
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
            // lbl_autorprod
            // 
            this.lbl_autorprod.AutoSize = true;
            this.lbl_autorprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_autorprod.Location = new System.Drawing.Point(521, 73);
            this.lbl_autorprod.Name = "lbl_autorprod";
            this.lbl_autorprod.Size = new System.Drawing.Size(47, 18);
            this.lbl_autorprod.TabIndex = 7;
            this.lbl_autorprod.Text = "Autor";
            this.lbl_autorprod.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_editoraprod
            // 
            this.lbl_editoraprod.AutoSize = true;
            this.lbl_editoraprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_editoraprod.Location = new System.Drawing.Point(38, 141);
            this.lbl_editoraprod.Name = "lbl_editoraprod";
            this.lbl_editoraprod.Size = new System.Drawing.Size(59, 18);
            this.lbl_editoraprod.TabIndex = 8;
            this.lbl_editoraprod.Text = "Editora";
            // 
            // lbl_precoprod
            // 
            this.lbl_precoprod.AutoSize = true;
            this.lbl_precoprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_precoprod.Location = new System.Drawing.Point(548, 141);
            this.lbl_precoprod.Name = "lbl_precoprod";
            this.lbl_precoprod.Size = new System.Drawing.Size(51, 18);
            this.lbl_precoprod.TabIndex = 9;
            this.lbl_precoprod.Text = "Preço";
            this.lbl_precoprod.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_categoriaprod
            // 
            this.lbl_categoriaprod.AutoSize = true;
            this.lbl_categoriaprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_categoriaprod.Location = new System.Drawing.Point(318, 141);
            this.lbl_categoriaprod.Name = "lbl_categoriaprod";
            this.lbl_categoriaprod.Size = new System.Drawing.Size(83, 18);
            this.lbl_categoriaprod.TabIndex = 10;
            this.lbl_categoriaprod.Text = "Categoria";
            // 
            // panelPersonalizado6
            // 
            this.panelPersonalizado6.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.BorderRadius = 30;
            this.panelPersonalizado6.Controls.Add(this.panel5);
            this.panelPersonalizado6.Controls.Add(this.txt_preco);
            this.panelPersonalizado6.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado6.GradientAngle = 90F;
            this.panelPersonalizado6.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado6.Location = new System.Drawing.Point(536, 164);
            this.panelPersonalizado6.Name = "panelPersonalizado6";
            this.panelPersonalizado6.Size = new System.Drawing.Size(185, 31);
            this.panelPersonalizado6.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(185, 3);
            this.panel5.TabIndex = 1;
            // 
            // txt_preco
            // 
            this.txt_preco.BackColor = System.Drawing.Color.Silver;
            this.txt_preco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_preco.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_preco.Location = new System.Drawing.Point(15, 5);
            this.txt_preco.Name = "txt_preco";
            this.txt_preco.Size = new System.Drawing.Size(167, 20);
            this.txt_preco.TabIndex = 0;
            // 
            // panelPersonalizado5
            // 
            this.panelPersonalizado5.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.BorderRadius = 30;
            this.panelPersonalizado5.Controls.Add(this.panel4);
            this.panelPersonalizado5.Controls.Add(this.txt_categoria);
            this.panelPersonalizado5.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado5.GradientAngle = 90F;
            this.panelPersonalizado5.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado5.Location = new System.Drawing.Point(306, 164);
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
            // txt_categoria
            // 
            this.txt_categoria.BackColor = System.Drawing.Color.Silver;
            this.txt_categoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_categoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_categoria.Location = new System.Drawing.Point(15, 5);
            this.txt_categoria.Name = "txt_categoria";
            this.txt_categoria.Size = new System.Drawing.Size(182, 20);
            this.txt_categoria.TabIndex = 0;
            // 
            // panelPersonalizado4
            // 
            this.panelPersonalizado4.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado4.BorderRadius = 30;
            this.panelPersonalizado4.Controls.Add(this.panel3);
            this.panelPersonalizado4.Controls.Add(this.txt_editora);
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
            // txt_editora
            // 
            this.txt_editora.BackColor = System.Drawing.Color.Silver;
            this.txt_editora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_editora.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_editora.Location = new System.Drawing.Point(15, 5);
            this.txt_editora.Name = "txt_editora";
            this.txt_editora.Size = new System.Drawing.Size(228, 20);
            this.txt_editora.TabIndex = 0;
            // 
            // panelPersonalizado3
            // 
            this.panelPersonalizado3.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado3.BorderRadius = 30;
            this.panelPersonalizado3.Controls.Add(this.panel2);
            this.panelPersonalizado3.Controls.Add(this.txt_autor);
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
            // txt_autor
            // 
            this.txt_autor.BackColor = System.Drawing.Color.Silver;
            this.txt_autor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_autor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_autor.Location = new System.Drawing.Point(15, 5);
            this.txt_autor.Name = "txt_autor";
            this.txt_autor.Size = new System.Drawing.Size(421, 20);
            this.txt_autor.TabIndex = 0;
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
            this.idProDataGridViewTextBoxColumn,
            this.idAutorDataGridViewTextBoxColumn,
            this.idCatDataGridViewTextBoxColumn,
            this.idEdiDataGridViewTextBoxColumn,
            this.nomeProDataGridViewTextBoxColumn,
            this.precoProDataGridViewTextBoxColumn,
            this.iSBNProDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.produtosBindingSource;
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
            // idProDataGridViewTextBoxColumn
            // 
            this.idProDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idProDataGridViewTextBoxColumn.DataPropertyName = "Id_Pro";
            this.idProDataGridViewTextBoxColumn.HeaderText = "Id_Pro";
            this.idProDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idProDataGridViewTextBoxColumn.Name = "idProDataGridViewTextBoxColumn";
            this.idProDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idAutorDataGridViewTextBoxColumn
            // 
            this.idAutorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idAutorDataGridViewTextBoxColumn.DataPropertyName = "Id_Autor";
            this.idAutorDataGridViewTextBoxColumn.HeaderText = "Id_Autor";
            this.idAutorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idAutorDataGridViewTextBoxColumn.Name = "idAutorDataGridViewTextBoxColumn";
            this.idAutorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCatDataGridViewTextBoxColumn
            // 
            this.idCatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idCatDataGridViewTextBoxColumn.DataPropertyName = "Id_Cat";
            this.idCatDataGridViewTextBoxColumn.HeaderText = "Id_Cat";
            this.idCatDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idCatDataGridViewTextBoxColumn.Name = "idCatDataGridViewTextBoxColumn";
            this.idCatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEdiDataGridViewTextBoxColumn
            // 
            this.idEdiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idEdiDataGridViewTextBoxColumn.DataPropertyName = "Id_Edi";
            this.idEdiDataGridViewTextBoxColumn.HeaderText = "Id_Edi";
            this.idEdiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idEdiDataGridViewTextBoxColumn.Name = "idEdiDataGridViewTextBoxColumn";
            this.idEdiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeProDataGridViewTextBoxColumn
            // 
            this.nomeProDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeProDataGridViewTextBoxColumn.DataPropertyName = "Nome_Pro";
            this.nomeProDataGridViewTextBoxColumn.FillWeight = 150F;
            this.nomeProDataGridViewTextBoxColumn.HeaderText = "Nome_Pro";
            this.nomeProDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeProDataGridViewTextBoxColumn.Name = "nomeProDataGridViewTextBoxColumn";
            this.nomeProDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precoProDataGridViewTextBoxColumn
            // 
            this.precoProDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.precoProDataGridViewTextBoxColumn.DataPropertyName = "Preco_Pro";
            this.precoProDataGridViewTextBoxColumn.FillWeight = 150F;
            this.precoProDataGridViewTextBoxColumn.HeaderText = "Preco_Pro";
            this.precoProDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.precoProDataGridViewTextBoxColumn.Name = "precoProDataGridViewTextBoxColumn";
            this.precoProDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iSBNProDataGridViewTextBoxColumn
            // 
            this.iSBNProDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iSBNProDataGridViewTextBoxColumn.DataPropertyName = "ISBN_Pro";
            this.iSBNProDataGridViewTextBoxColumn.FillWeight = 150F;
            this.iSBNProDataGridViewTextBoxColumn.HeaderText = "ISBN_Pro";
            this.iSBNProDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iSBNProDataGridViewTextBoxColumn.Name = "iSBNProDataGridViewTextBoxColumn";
            this.iSBNProDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panelPersonalizado7
            // 
            this.panelPersonalizado7.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado7.BorderRadius = 30;
            this.panelPersonalizado7.Controls.Add(this.panel6);
            this.panelPersonalizado7.Controls.Add(this.txt_isbn);
            this.panelPersonalizado7.ForeColor = System.Drawing.Color.Black;
            this.panelPersonalizado7.GradientAngle = 90F;
            this.panelPersonalizado7.GradientBottomColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado7.GradientTopColor = System.Drawing.Color.Transparent;
            this.panelPersonalizado7.Location = new System.Drawing.Point(751, 164);
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
            // txt_isbn
            // 
            this.txt_isbn.BackColor = System.Drawing.Color.Silver;
            this.txt_isbn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_isbn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_isbn.Location = new System.Drawing.Point(15, 5);
            this.txt_isbn.Name = "txt_isbn";
            this.txt_isbn.Size = new System.Drawing.Size(179, 20);
            this.txt_isbn.TabIndex = 0;
            // 
            // lbl_isbnprod
            // 
            this.lbl_isbnprod.AutoSize = true;
            this.lbl_isbnprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_isbnprod.Location = new System.Drawing.Point(763, 143);
            this.lbl_isbnprod.Name = "lbl_isbnprod";
            this.lbl_isbnprod.Size = new System.Drawing.Size(40, 18);
            this.lbl_isbnprod.TabIndex = 16;
            this.lbl_isbnprod.Text = "ISBN";
            // 
            // frmCadProdutos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.lbl_isbnprod);
            this.Controls.Add(this.panelPersonalizado7);
            this.Controls.Add(this.panelPersonalizado6);
            this.Controls.Add(this.panelPersonalizado5);
            this.Controls.Add(this.panelPersonalizado4);
            this.Controls.Add(this.panelPersonalizado3);
            this.Controls.Add(this.panelPersonalizado2);
            this.Controls.Add(this.lbl_categoriaprod);
            this.Controls.Add(this.lbl_precoprod);
            this.Controls.Add(this.lbl_editoraprod);
            this.Controls.Add(this.lbl_autorprod);
            this.Controls.Add(this.lbl_nomeprod);
            this.Controls.Add(this.panelPersonalizado1);
            this.Controls.Add(this.bindingNavigator1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCadProdutos";
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
        private System.Windows.Forms.ToolStripButton CadProduto;
        private classes.PanelPersonalizado panelPersonalizado1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private data.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource produtosBindingSource;
        private data.DataSet2TableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEdiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoProDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSBNProDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbl_nomeprod;
        private System.Windows.Forms.Label lbl_autorprod;
        private System.Windows.Forms.Label lbl_editoraprod;
        private System.Windows.Forms.Label lbl_precoprod;
        private System.Windows.Forms.Label lbl_categoriaprod;
        private classes.PanelPersonalizado panelPersonalizado2;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Panel panel1;
        private classes.PanelPersonalizado panelPersonalizado3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_autor;
        private classes.PanelPersonalizado panelPersonalizado4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_editora;
        private classes.PanelPersonalizado panelPersonalizado5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_categoria;
        private classes.PanelPersonalizado panelPersonalizado6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_preco;
        private classes.PanelPersonalizado panelPersonalizado7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txt_isbn;
        private System.Windows.Forms.Label lbl_isbnprod;
    }
}