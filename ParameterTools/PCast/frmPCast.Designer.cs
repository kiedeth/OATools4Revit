namespace OATools.ParameterTools.PCast
{
    partial class frmPCast
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
            this.dgvTemplates = new System.Windows.Forms.DataGridView();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.tbxTemplateFileLocation = new System.Windows.Forms.TextBox();
            this.btnSetTemplatePath = new System.Windows.Forms.Button();
            this.tbxParameterSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddToMySet = new System.Windows.Forms.Button();
            this.dgvMySet = new System.Windows.Forms.DataGridView();
            this.btnSaveAsTemplate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMySet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTemplates
            // 
            this.dgvTemplates.AllowUserToAddRows = false;
            this.dgvTemplates.AllowUserToDeleteRows = false;
            this.dgvTemplates.AllowUserToResizeColumns = false;
            this.dgvTemplates.AllowUserToResizeRows = false;
            this.dgvTemplates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTemplates.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTemplates.Location = new System.Drawing.Point(12, 168);
            this.dgvTemplates.MultiSelect = false;
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.ReadOnly = true;
            this.dgvTemplates.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvTemplates.RowHeadersVisible = false;
            this.dgvTemplates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTemplates.RowTemplate.Height = 24;
            this.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplates.Size = new System.Drawing.Size(303, 690);
            this.dgvTemplates.TabIndex = 0;
            this.dgvTemplates.SelectionChanged += new System.EventHandler(this.dgvTemplates_SelectionChanged);
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.AllowUserToOrderColumns = true;
            this.dgvParameters.AllowUserToResizeRows = false;
            this.dgvParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvParameters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Location = new System.Drawing.Point(333, 168);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowTemplate.Height = 24;
            this.dgvParameters.Size = new System.Drawing.Size(489, 690);
            this.dgvParameters.TabIndex = 1;
            // 
            // tbxTemplateFileLocation
            // 
            this.tbxTemplateFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTemplateFileLocation.Location = new System.Drawing.Point(12, 44);
            this.tbxTemplateFileLocation.Name = "tbxTemplateFileLocation";
            this.tbxTemplateFileLocation.Size = new System.Drawing.Size(712, 27);
            this.tbxTemplateFileLocation.TabIndex = 2;
            // 
            // btnSetTemplatePath
            // 
            this.btnSetTemplatePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetTemplatePath.Location = new System.Drawing.Point(749, 44);
            this.btnSetTemplatePath.Name = "btnSetTemplatePath";
            this.btnSetTemplatePath.Size = new System.Drawing.Size(48, 27);
            this.btnSetTemplatePath.TabIndex = 3;
            this.btnSetTemplatePath.Text = "...";
            this.btnSetTemplatePath.UseVisualStyleBackColor = true;
            this.btnSetTemplatePath.Click += new System.EventHandler(this.btnSetTemplatePath_Click);
            // 
            // tbxParameterSearch
            // 
            this.tbxParameterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxParameterSearch.Location = new System.Drawing.Point(404, 129);
            this.tbxParameterSearch.Name = "tbxParameterSearch";
            this.tbxParameterSearch.Size = new System.Drawing.Size(410, 27);
            this.tbxParameterSearch.TabIndex = 4;
            this.tbxParameterSearch.TextChanged += new System.EventHandler(this.tbxParameterSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search:";
            // 
            // btnAddToMySet
            // 
            this.btnAddToMySet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToMySet.Location = new System.Drawing.Point(830, 500);
            this.btnAddToMySet.Name = "btnAddToMySet";
            this.btnAddToMySet.Size = new System.Drawing.Size(75, 38);
            this.btnAddToMySet.TabIndex = 6;
            this.btnAddToMySet.Text = "ADD >";
            this.btnAddToMySet.UseVisualStyleBackColor = true;
            this.btnAddToMySet.Click += new System.EventHandler(this.btnAddToMySet_Click);
            // 
            // dgvMySet
            // 
            this.dgvMySet.AllowUserToAddRows = false;
            this.dgvMySet.AllowUserToDeleteRows = false;
            this.dgvMySet.AllowUserToOrderColumns = true;
            this.dgvMySet.AllowUserToResizeRows = false;
            this.dgvMySet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMySet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMySet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvMySet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMySet.Location = new System.Drawing.Point(911, 168);
            this.dgvMySet.Name = "dgvMySet";
            this.dgvMySet.RowTemplate.Height = 24;
            this.dgvMySet.Size = new System.Drawing.Size(489, 690);
            this.dgvMySet.TabIndex = 7;
            // 
            // btnSaveAsTemplate
            // 
            this.btnSaveAsTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAsTemplate.Location = new System.Drawing.Point(911, 874);
            this.btnSaveAsTemplate.Name = "btnSaveAsTemplate";
            this.btnSaveAsTemplate.Size = new System.Drawing.Size(141, 38);
            this.btnSaveAsTemplate.TabIndex = 8;
            this.btnSaveAsTemplate.Text = "Save As Template";
            this.btnSaveAsTemplate.UseVisualStyleBackColor = true;
            this.btnSaveAsTemplate.Click += new System.EventHandler(this.btnSaveAsTemplate_Click);
            // 
            // frmPCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1707, 1012);
            this.Controls.Add(this.btnSaveAsTemplate);
            this.Controls.Add(this.dgvMySet);
            this.Controls.Add(this.btnAddToMySet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxParameterSearch);
            this.Controls.Add(this.btnSetTemplatePath);
            this.Controls.Add(this.tbxTemplateFileLocation);
            this.Controls.Add(this.dgvParameters);
            this.Controls.Add(this.dgvTemplates);
            this.Name = "frmPCast";
            this.Text = "frmPCast";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMySet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.TextBox tbxTemplateFileLocation;
        private System.Windows.Forms.Button btnSetTemplatePath;
        private System.Windows.Forms.TextBox tbxParameterSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddToMySet;
        private System.Windows.Forms.DataGridView dgvMySet;
        private System.Windows.Forms.Button btnSaveAsTemplate;
    }
}