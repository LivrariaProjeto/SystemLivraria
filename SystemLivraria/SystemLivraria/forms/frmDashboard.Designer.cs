namespace SystemLivraria.forms
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_relatoriosSubmenu = new System.Windows.Forms.Panel();
            this.btn_rltFluxoFinanceira = new System.Windows.Forms.Button();
            this.btn_rltSaidaFinanceira = new System.Windows.Forms.Button();
            this.btn_rltEntradaFinanceira = new System.Windows.Forms.Button();
            this.btn_rltMovimentoEstoque = new System.Windows.Forms.Button();
            this.btn_rltEstoqueAtual = new System.Windows.Forms.Button();
            this.btn_relatorios = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_Consulta = new System.Windows.Forms.Button();
            this.pnl_cadastroSubmenu = new System.Windows.Forms.Panel();
            this.btn_cadFuncionarios = new System.Windows.Forms.Button();
            this.btn_cadClientes = new System.Windows.Forms.Button();
            this.btn_cadFornecedores = new System.Windows.Forms.Button();
            this.btn_cadEditoras = new System.Windows.Forms.Button();
            this.btn_cadAutores = new System.Windows.Forms.Button();
            this.btn_cadProdutos = new System.Windows.Forms.Button();
            this.btn_cadastro = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_tudo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnl_relatoriosSubmenu.SuspendLayout();
            this.pnl_cadastroSubmenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.pnl_relatoriosSubmenu);
            this.panel1.Controls.Add(this.btn_relatorios);
            this.panel1.Controls.Add(this.btn_excluir);
            this.panel1.Controls.Add(this.btn_Consulta);
            this.panel1.Controls.Add(this.pnl_cadastroSubmenu);
            this.panel1.Controls.Add(this.btn_cadastro);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 1041);
            this.panel1.TabIndex = 0;
            // 
            // pnl_relatoriosSubmenu
            // 
            this.pnl_relatoriosSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(38)))), ((int)(((byte)(66)))));
            this.pnl_relatoriosSubmenu.Controls.Add(this.btn_rltFluxoFinanceira);
            this.pnl_relatoriosSubmenu.Controls.Add(this.btn_rltSaidaFinanceira);
            this.pnl_relatoriosSubmenu.Controls.Add(this.btn_rltEntradaFinanceira);
            this.pnl_relatoriosSubmenu.Controls.Add(this.btn_rltMovimentoEstoque);
            this.pnl_relatoriosSubmenu.Controls.Add(this.btn_rltEstoqueAtual);
            this.pnl_relatoriosSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_relatoriosSubmenu.Location = new System.Drawing.Point(0, 680);
            this.pnl_relatoriosSubmenu.Name = "pnl_relatoriosSubmenu";
            this.pnl_relatoriosSubmenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnl_relatoriosSubmenu.Size = new System.Drawing.Size(300, 280);
            this.pnl_relatoriosSubmenu.TabIndex = 6;
            // 
            // btn_rltFluxoFinanceira
            // 
            this.btn_rltFluxoFinanceira.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_rltFluxoFinanceira.FlatAppearance.BorderSize = 0;
            this.btn_rltFluxoFinanceira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rltFluxoFinanceira.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rltFluxoFinanceira.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_rltFluxoFinanceira.Location = new System.Drawing.Point(0, 220);
            this.btn_rltFluxoFinanceira.Name = "btn_rltFluxoFinanceira";
            this.btn_rltFluxoFinanceira.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_rltFluxoFinanceira.Size = new System.Drawing.Size(300, 55);
            this.btn_rltFluxoFinanceira.TabIndex = 4;
            this.btn_rltFluxoFinanceira.Text = "Fluxo Financeira";
            this.btn_rltFluxoFinanceira.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_rltFluxoFinanceira.UseVisualStyleBackColor = true;
            this.btn_rltFluxoFinanceira.Click += new System.EventHandler(this.btn_rltFluxoFinanceira_Click);
            // 
            // btn_rltSaidaFinanceira
            // 
            this.btn_rltSaidaFinanceira.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_rltSaidaFinanceira.FlatAppearance.BorderSize = 0;
            this.btn_rltSaidaFinanceira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rltSaidaFinanceira.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rltSaidaFinanceira.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_rltSaidaFinanceira.Location = new System.Drawing.Point(0, 165);
            this.btn_rltSaidaFinanceira.Name = "btn_rltSaidaFinanceira";
            this.btn_rltSaidaFinanceira.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_rltSaidaFinanceira.Size = new System.Drawing.Size(300, 55);
            this.btn_rltSaidaFinanceira.TabIndex = 3;
            this.btn_rltSaidaFinanceira.Text = "Saída Financeira";
            this.btn_rltSaidaFinanceira.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_rltSaidaFinanceira.UseVisualStyleBackColor = true;
            this.btn_rltSaidaFinanceira.Click += new System.EventHandler(this.btn_rltSaidaFinanceira_Click);
            // 
            // btn_rltEntradaFinanceira
            // 
            this.btn_rltEntradaFinanceira.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_rltEntradaFinanceira.FlatAppearance.BorderSize = 0;
            this.btn_rltEntradaFinanceira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rltEntradaFinanceira.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rltEntradaFinanceira.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_rltEntradaFinanceira.Location = new System.Drawing.Point(0, 110);
            this.btn_rltEntradaFinanceira.Name = "btn_rltEntradaFinanceira";
            this.btn_rltEntradaFinanceira.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_rltEntradaFinanceira.Size = new System.Drawing.Size(300, 55);
            this.btn_rltEntradaFinanceira.TabIndex = 2;
            this.btn_rltEntradaFinanceira.Text = "Entrada Financeira";
            this.btn_rltEntradaFinanceira.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_rltEntradaFinanceira.UseVisualStyleBackColor = true;
            this.btn_rltEntradaFinanceira.Click += new System.EventHandler(this.btn_rltEntradaFinanceira_Click);
            // 
            // btn_rltMovimentoEstoque
            // 
            this.btn_rltMovimentoEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_rltMovimentoEstoque.FlatAppearance.BorderSize = 0;
            this.btn_rltMovimentoEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rltMovimentoEstoque.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rltMovimentoEstoque.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_rltMovimentoEstoque.Location = new System.Drawing.Point(0, 55);
            this.btn_rltMovimentoEstoque.Name = "btn_rltMovimentoEstoque";
            this.btn_rltMovimentoEstoque.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_rltMovimentoEstoque.Size = new System.Drawing.Size(300, 55);
            this.btn_rltMovimentoEstoque.TabIndex = 1;
            this.btn_rltMovimentoEstoque.Text = "Movimentação do Estoque";
            this.btn_rltMovimentoEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_rltMovimentoEstoque.UseVisualStyleBackColor = true;
            this.btn_rltMovimentoEstoque.Click += new System.EventHandler(this.btn_rltMovimentoEstoque_Click);
            // 
            // btn_rltEstoqueAtual
            // 
            this.btn_rltEstoqueAtual.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_rltEstoqueAtual.FlatAppearance.BorderSize = 0;
            this.btn_rltEstoqueAtual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rltEstoqueAtual.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rltEstoqueAtual.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_rltEstoqueAtual.Location = new System.Drawing.Point(0, 0);
            this.btn_rltEstoqueAtual.Name = "btn_rltEstoqueAtual";
            this.btn_rltEstoqueAtual.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_rltEstoqueAtual.Size = new System.Drawing.Size(300, 55);
            this.btn_rltEstoqueAtual.TabIndex = 0;
            this.btn_rltEstoqueAtual.Text = "Estoque Atual";
            this.btn_rltEstoqueAtual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_rltEstoqueAtual.UseVisualStyleBackColor = true;
            this.btn_rltEstoqueAtual.Click += new System.EventHandler(this.btn_rltEstoqueAtual_Click);
            // 
            // btn_relatorios
            // 
            this.btn_relatorios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_relatorios.FlatAppearance.BorderSize = 0;
            this.btn_relatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_relatorios.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_relatorios.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_relatorios.Location = new System.Drawing.Point(0, 625);
            this.btn_relatorios.Name = "btn_relatorios";
            this.btn_relatorios.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_relatorios.Size = new System.Drawing.Size(300, 55);
            this.btn_relatorios.TabIndex = 5;
            this.btn_relatorios.Text = "RELATÓRIOS";
            this.btn_relatorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_relatorios.UseVisualStyleBackColor = true;
            this.btn_relatorios.Click += new System.EventHandler(this.btn_relatorios_Click);
            // 
            // btn_excluir
            // 
            this.btn_excluir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluir.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excluir.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_excluir.Location = new System.Drawing.Point(0, 570);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_excluir.Size = new System.Drawing.Size(300, 55);
            this.btn_excluir.TabIndex = 4;
            this.btn_excluir.Text = "EXCLUIR";
            this.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Consulta
            // 
            this.btn_Consulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Consulta.FlatAppearance.BorderSize = 0;
            this.btn_Consulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Consulta.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Consulta.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Consulta.Location = new System.Drawing.Point(0, 515);
            this.btn_Consulta.Name = "btn_Consulta";
            this.btn_Consulta.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Consulta.Size = new System.Drawing.Size(300, 55);
            this.btn_Consulta.TabIndex = 3;
            this.btn_Consulta.Text = "CONSULTA";
            this.btn_Consulta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Consulta.UseVisualStyleBackColor = true;
            this.btn_Consulta.Click += new System.EventHandler(this.btn_Consulta_Click);
            // 
            // pnl_cadastroSubmenu
            // 
            this.pnl_cadastroSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(38)))), ((int)(((byte)(66)))));
            this.pnl_cadastroSubmenu.Controls.Add(this.btn_cadFuncionarios);
            this.pnl_cadastroSubmenu.Controls.Add(this.btn_cadClientes);
            this.pnl_cadastroSubmenu.Controls.Add(this.btn_cadFornecedores);
            this.pnl_cadastroSubmenu.Controls.Add(this.btn_cadEditoras);
            this.pnl_cadastroSubmenu.Controls.Add(this.btn_cadAutores);
            this.pnl_cadastroSubmenu.Controls.Add(this.btn_cadProdutos);
            this.pnl_cadastroSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_cadastroSubmenu.Location = new System.Drawing.Point(0, 180);
            this.pnl_cadastroSubmenu.Name = "pnl_cadastroSubmenu";
            this.pnl_cadastroSubmenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnl_cadastroSubmenu.Size = new System.Drawing.Size(300, 335);
            this.pnl_cadastroSubmenu.TabIndex = 2;
            // 
            // btn_cadFuncionarios
            // 
            this.btn_cadFuncionarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadFuncionarios.FlatAppearance.BorderSize = 0;
            this.btn_cadFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadFuncionarios.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadFuncionarios.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cadFuncionarios.Location = new System.Drawing.Point(0, 275);
            this.btn_cadFuncionarios.Name = "btn_cadFuncionarios";
            this.btn_cadFuncionarios.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_cadFuncionarios.Size = new System.Drawing.Size(300, 55);
            this.btn_cadFuncionarios.TabIndex = 6;
            this.btn_cadFuncionarios.Text = "Funcionários";
            this.btn_cadFuncionarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadFuncionarios.UseVisualStyleBackColor = true;
            this.btn_cadFuncionarios.Click += new System.EventHandler(this.btn_cadFuncionarios_Click);
            // 
            // btn_cadClientes
            // 
            this.btn_cadClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadClientes.FlatAppearance.BorderSize = 0;
            this.btn_cadClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadClientes.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadClientes.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cadClientes.Location = new System.Drawing.Point(0, 220);
            this.btn_cadClientes.Name = "btn_cadClientes";
            this.btn_cadClientes.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_cadClientes.Size = new System.Drawing.Size(300, 55);
            this.btn_cadClientes.TabIndex = 4;
            this.btn_cadClientes.Text = "Clientes";
            this.btn_cadClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadClientes.UseVisualStyleBackColor = true;
            this.btn_cadClientes.Click += new System.EventHandler(this.btn_cadClientes_Click);
            // 
            // btn_cadFornecedores
            // 
            this.btn_cadFornecedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadFornecedores.FlatAppearance.BorderSize = 0;
            this.btn_cadFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadFornecedores.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadFornecedores.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cadFornecedores.Location = new System.Drawing.Point(0, 165);
            this.btn_cadFornecedores.Name = "btn_cadFornecedores";
            this.btn_cadFornecedores.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_cadFornecedores.Size = new System.Drawing.Size(300, 55);
            this.btn_cadFornecedores.TabIndex = 3;
            this.btn_cadFornecedores.Text = "Fornecedores";
            this.btn_cadFornecedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadFornecedores.UseVisualStyleBackColor = true;
            this.btn_cadFornecedores.Click += new System.EventHandler(this.btn_cadFornecedores_Click);
            // 
            // btn_cadEditoras
            // 
            this.btn_cadEditoras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadEditoras.FlatAppearance.BorderSize = 0;
            this.btn_cadEditoras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadEditoras.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadEditoras.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cadEditoras.Location = new System.Drawing.Point(0, 110);
            this.btn_cadEditoras.Name = "btn_cadEditoras";
            this.btn_cadEditoras.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_cadEditoras.Size = new System.Drawing.Size(300, 55);
            this.btn_cadEditoras.TabIndex = 2;
            this.btn_cadEditoras.Text = "Editoras";
            this.btn_cadEditoras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadEditoras.UseVisualStyleBackColor = true;
            this.btn_cadEditoras.Click += new System.EventHandler(this.btn_cadEditoras_Click);
            // 
            // btn_cadAutores
            // 
            this.btn_cadAutores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadAutores.FlatAppearance.BorderSize = 0;
            this.btn_cadAutores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadAutores.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadAutores.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cadAutores.Location = new System.Drawing.Point(0, 55);
            this.btn_cadAutores.Name = "btn_cadAutores";
            this.btn_cadAutores.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_cadAutores.Size = new System.Drawing.Size(300, 55);
            this.btn_cadAutores.TabIndex = 1;
            this.btn_cadAutores.Text = "Autores";
            this.btn_cadAutores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadAutores.UseVisualStyleBackColor = true;
            this.btn_cadAutores.Click += new System.EventHandler(this.btn_cadAutores_Click);
            // 
            // btn_cadProdutos
            // 
            this.btn_cadProdutos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadProdutos.FlatAppearance.BorderSize = 0;
            this.btn_cadProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadProdutos.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadProdutos.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cadProdutos.Location = new System.Drawing.Point(0, 0);
            this.btn_cadProdutos.Name = "btn_cadProdutos";
            this.btn_cadProdutos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_cadProdutos.Size = new System.Drawing.Size(300, 55);
            this.btn_cadProdutos.TabIndex = 0;
            this.btn_cadProdutos.Text = "Produtos";
            this.btn_cadProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadProdutos.UseVisualStyleBackColor = true;
            this.btn_cadProdutos.Click += new System.EventHandler(this.btn_cadProdutos_Click);
            // 
            // btn_cadastro
            // 
            this.btn_cadastro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadastro.FlatAppearance.BorderSize = 0;
            this.btn_cadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastro.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadastro.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cadastro.Location = new System.Drawing.Point(0, 125);
            this.btn_cadastro.Name = "btn_cadastro";
            this.btn_cadastro.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_cadastro.Size = new System.Drawing.Size(300, 55);
            this.btn_cadastro.TabIndex = 1;
            this.btn_cadastro.Text = "CADASTRO";
            this.btn_cadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadastro.UseVisualStyleBackColor = true;
            this.btn_cadastro.Click += new System.EventHandler(this.btn_cadastro_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 125);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_tudo
            // 
            this.pnl_tudo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_tudo.Location = new System.Drawing.Point(300, 0);
            this.pnl_tudo.Name = "pnl_tudo";
            this.pnl_tudo.Size = new System.Drawing.Size(1604, 1041);
            this.pnl_tudo.TabIndex = 1;
            this.pnl_tudo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_tudo_Paint);
            // 
            // frmDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnl_tudo);
            this.Controls.Add(this.panel1);
            this.Name = "frmDashboard";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.pnl_relatoriosSubmenu.ResumeLayout(false);
            this.pnl_cadastroSubmenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cadastro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_cadastroSubmenu;
        private System.Windows.Forms.Button btn_cadClientes;
        private System.Windows.Forms.Button btn_cadFornecedores;
        private System.Windows.Forms.Button btn_cadEditoras;
        private System.Windows.Forms.Button btn_cadAutores;
        private System.Windows.Forms.Button btn_cadProdutos;
        private System.Windows.Forms.Button btn_Consulta;
        private System.Windows.Forms.Button btn_cadFuncionarios;
        private System.Windows.Forms.Button btn_relatorios;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Panel pnl_relatoriosSubmenu;
        private System.Windows.Forms.Button btn_rltFluxoFinanceira;
        private System.Windows.Forms.Button btn_rltSaidaFinanceira;
        private System.Windows.Forms.Button btn_rltEntradaFinanceira;
        private System.Windows.Forms.Button btn_rltMovimentoEstoque;
        private System.Windows.Forms.Button btn_rltEstoqueAtual;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_tudo;
    }
}