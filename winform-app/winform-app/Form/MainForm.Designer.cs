namespace winform_app
{
    partial class MainForm
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateFromUrl = new System.Windows.Forms.Button();
            this.richTxtCatalogUrl = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Logs = new System.Windows.Forms.GroupBox();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.rtbQuantity = new System.Windows.Forms.RichTextBox();
            this.productBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.Logs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 532);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 40);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(23, 22);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(776, 452);
            this.dgvProducts.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(118, 532);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 532);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(688, 532);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateFromUrl
            // 
            this.btnCreateFromUrl.Location = new System.Drawing.Point(428, 532);
            this.btnCreateFromUrl.Name = "btnCreateFromUrl";
            this.btnCreateFromUrl.Size = new System.Drawing.Size(100, 40);
            this.btnCreateFromUrl.TabIndex = 5;
            this.btnCreateFromUrl.Text = "CreateFromUrl";
            this.btnCreateFromUrl.UseVisualStyleBackColor = true;
            this.btnCreateFromUrl.Click += new System.EventHandler(this.btnCreateFromUrl_Click);
            // 
            // richTxtCatalogUrl
            // 
            this.richTxtCatalogUrl.Location = new System.Drawing.Point(852, 13);
            this.richTxtCatalogUrl.Name = "richTxtCatalogUrl";
            this.richTxtCatalogUrl.Size = new System.Drawing.Size(445, 196);
            this.richTxtCatalogUrl.TabIndex = 6;
            this.richTxtCatalogUrl.Text = "";
            this.richTxtCatalogUrl.TextChanged += new System.EventHandler(this.richTxtCatalogUrl_TextChanged);
            // 
            // Logs
            // 
            this.Logs.Controls.Add(this.rtbLogs);
            this.Logs.Location = new System.Drawing.Point(852, 242);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(445, 355);
            this.Logs.TabIndex = 7;
            this.Logs.TabStop = false;
            this.Logs.Text = "Logs";
            // 
            // rtbLogs
            // 
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogs.Location = new System.Drawing.Point(3, 16);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(439, 336);
            this.rtbLogs.TabIndex = 7;
            this.rtbLogs.Text = "";
            // 
            // rtbQuantity
            // 
            this.rtbQuantity.Location = new System.Drawing.Point(345, 532);
            this.rtbQuantity.Name = "rtbQuantity";
            this.rtbQuantity.Size = new System.Drawing.Size(77, 40);
            this.rtbQuantity.TabIndex = 8;
            this.rtbQuantity.Text = "";
            // 
            // productBindingSource2
            // 
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataSource = typeof(winform_app.Model.Product);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(winform_app.Model.Product);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 606);
            this.Controls.Add(this.rtbQuantity);
            this.Controls.Add(this.Logs);
            this.Controls.Add(this.richTxtCatalogUrl);
            this.Controls.Add(this.btnCreateFromUrl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnCreate);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.Logs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateFromUrl;
        private System.Windows.Forms.RichTextBox richTxtCatalogUrl;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox Logs;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.RichTextBox rtbQuantity;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.BindingSource productBindingSource2;
    }
}

