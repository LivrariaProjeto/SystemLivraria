namespace SystemLivraria.forms.Relatorios
{
    partial class frmRltEstoque
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
            this.estoqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet21 = new SystemLivraria.data.DataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet22 = new SystemLivraria.data.DataSet2();
            this.estoqueTableAdapter1 = new SystemLivraria.data.DataSet2TableAdapters.EstoqueTableAdapter();
            this.db_250064DataSet = new SystemLivraria.db_250064DataSet();
            this.estoqueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueTableAdapter = new SystemLivraria.db_250064DataSetTableAdapters.EstoqueTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_250064DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // estoqueBindingSource
            // 
            this.estoqueBindingSource.DataMember = "Estoque";
            this.estoqueBindingSource.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.dataSet21;
            this.bindingSource1.Position = 0;
            // 
            // dataSet21
            // 
            this.dataSet21.DataSetName = "DataSet2";
            this.dataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.dataSet21.Disposed += new System.EventHandler(this.reportViewer1_Load);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataEstoque";
            reportDataSource1.Value = this.estoqueBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SystemLivraria.forms.Relatorios.ReportEstoque.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(647, 411);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dataSet22
            // 
            this.dataSet22.DataSetName = "DataSet2";
            this.dataSet22.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // estoqueTableAdapter1
            // 
            this.estoqueTableAdapter1.ClearBeforeFill = true;
            // 
            // db_250064DataSet
            // 
            this.db_250064DataSet.DataSetName = "db_250064DataSet";
            this.db_250064DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // estoqueBindingSource1
            // 
            this.estoqueBindingSource1.DataMember = "Estoque";
            this.estoqueBindingSource1.DataSource = this.db_250064DataSet;
            // 
            // estoqueTableAdapter
            // 
            this.estoqueTableAdapter.ClearBeforeFill = true;
            // 
            // frmRltEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 411);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRltEstoque";
            this.Text = "frmRltEstoque";
            this.Load += new System.EventHandler(this.frmRltEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_250064DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private data.DataSet2 dataSet21;
        private data.DataSet2 dataSet22;
        private data.DataSet2TableAdapters.EstoqueTableAdapter estoqueTableAdapter1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource estoqueBindingSource;
        private db_250064DataSet db_250064DataSet;
        private System.Windows.Forms.BindingSource estoqueBindingSource1;
        private db_250064DataSetTableAdapters.EstoqueTableAdapter estoqueTableAdapter;
    }
}