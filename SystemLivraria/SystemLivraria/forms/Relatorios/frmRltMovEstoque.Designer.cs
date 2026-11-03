namespace SystemLivraria.forms.Relatorios
{
    partial class frmRltMovEstoque
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpt_movestoque = new Microsoft.Reporting.WinForms.ReportViewer();
            this.db_250064DataSet = new SystemLivraria.db_250064DataSet();
            this.estoqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueTableAdapter = new SystemLivraria.db_250064DataSetTableAdapters.EstoqueTableAdapter();
            this.db_250064DataSet2 = new SystemLivraria.db_250064DataSet2();
            this.db250064DataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueTableAdapter1 = new SystemLivraria.db_250064DataSet2TableAdapters.EstoqueTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.db_250064DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_250064DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db250064DataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // rpt_movestoque
            // 
            this.rpt_movestoque.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataEstoque";
            reportDataSource1.Value = this.estoqueBindingSource1;
            this.rpt_movestoque.LocalReport.DataSources.Add(reportDataSource1);
            this.rpt_movestoque.LocalReport.ReportEmbeddedResource = "SystemLivraria.forms.Relatorios.ReportEstoque.rdlc";
            this.rpt_movestoque.Location = new System.Drawing.Point(0, 0);
            this.rpt_movestoque.Name = "rpt_movestoque";
            this.rpt_movestoque.ServerReport.BearerToken = null;
            this.rpt_movestoque.Size = new System.Drawing.Size(647, 411);
            this.rpt_movestoque.TabIndex = 0;
            // 
            // db_250064DataSet
            // 
            this.db_250064DataSet.DataSetName = "db_250064DataSet";
            this.db_250064DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // estoqueBindingSource
            // 
            this.estoqueBindingSource.DataMember = "Estoque";
            this.estoqueBindingSource.DataSource = this.db_250064DataSet;
            // 
            // estoqueTableAdapter
            // 
            this.estoqueTableAdapter.ClearBeforeFill = true;
            // 
            // db_250064DataSet2
            // 
            this.db_250064DataSet2.DataSetName = "db_250064DataSet2";
            this.db_250064DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // db250064DataSet2BindingSource
            // 
            this.db250064DataSet2BindingSource.DataSource = this.db_250064DataSet2;
            this.db250064DataSet2BindingSource.Position = 0;
            // 
            // estoqueBindingSource1
            // 
            this.estoqueBindingSource1.DataMember = "Estoque";
            this.estoqueBindingSource1.DataSource = this.db250064DataSet2BindingSource;
            // 
            // estoqueTableAdapter1
            // 
            this.estoqueTableAdapter1.ClearBeforeFill = true;
            // 
            // frmRltMovEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 411);
            this.Controls.Add(this.rpt_movestoque);
            this.Name = "frmRltMovEstoque";
            this.Text = "frmRltMovEstoque";
            this.Load += new System.EventHandler(this.frmRltMovEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_250064DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_250064DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db250064DataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt_movestoque;
        private db_250064DataSet db_250064DataSet;
        private System.Windows.Forms.BindingSource estoqueBindingSource;
        private db_250064DataSetTableAdapters.EstoqueTableAdapter estoqueTableAdapter;
        private System.Windows.Forms.BindingSource db250064DataSet2BindingSource;
        private db_250064DataSet2 db_250064DataSet2;
        private System.Windows.Forms.BindingSource estoqueBindingSource1;
        private db_250064DataSet2TableAdapters.EstoqueTableAdapter estoqueTableAdapter1;
    }
}