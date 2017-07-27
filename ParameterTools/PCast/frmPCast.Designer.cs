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
            this.btnAddToMySet = new System.Windows.Forms.Button();
            this.dgvMySet = new System.Windows.Forms.DataGridView();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.btnSaveAsTemplate = new System.Windows.Forms.Button();
            this.btnClearMySet = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAddToFamily = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxParameterSearch = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSharedParameterFilePath = new System.Windows.Forms.TextBox();
            this.btnSetParametersFromFilePath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvParametersFromFile = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteTemplate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMySet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametersFromFile)).BeginInit();
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
            this.dgvTemplates.Location = new System.Drawing.Point(6, 59);
            this.dgvTemplates.MultiSelect = false;
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.ReadOnly = true;
            this.dgvTemplates.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvTemplates.RowHeadersVisible = false;
            this.dgvTemplates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTemplates.RowTemplate.Height = 24;
            this.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplates.Size = new System.Drawing.Size(281, 770);
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
            this.dgvParameters.Location = new System.Drawing.Point(299, 122);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowTemplate.Height = 24;
            this.dgvParameters.Size = new System.Drawing.Size(497, 736);
            this.dgvParameters.TabIndex = 1;
            // 
            // tbxTemplateFileLocation
            // 
            this.tbxTemplateFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTemplateFileLocation.Location = new System.Drawing.Point(6, 26);
            this.tbxTemplateFileLocation.Name = "tbxTemplateFileLocation";
            this.tbxTemplateFileLocation.Size = new System.Drawing.Size(607, 27);
            this.tbxTemplateFileLocation.TabIndex = 2;
            // 
            // btnSetTemplatePath
            // 
            this.btnSetTemplatePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetTemplatePath.Location = new System.Drawing.Point(619, 26);
            this.btnSetTemplatePath.Name = "btnSetTemplatePath";
            this.btnSetTemplatePath.Size = new System.Drawing.Size(48, 27);
            this.btnSetTemplatePath.TabIndex = 3;
            this.btnSetTemplatePath.Text = "...";
            this.btnSetTemplatePath.UseVisualStyleBackColor = true;
            this.btnSetTemplatePath.Click += new System.EventHandler(this.btnSetTemplatePath_Click);
            // 
            // btnAddToMySet
            // 
            this.btnAddToMySet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToMySet.Location = new System.Drawing.Point(826, 524);
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
            this.dgvMySet.Location = new System.Drawing.Point(911, 135);
            this.dgvMySet.Name = "dgvMySet";
            this.dgvMySet.RowTemplate.Height = 24;
            this.dgvMySet.Size = new System.Drawing.Size(489, 764);
            this.dgvMySet.TabIndex = 7;
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBackup.Location = new System.Drawing.Point(673, 26);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(123, 29);
            this.btnCreateBackup.TabIndex = 8;
            this.btnCreateBackup.Text = "Create Backup";
            this.btnCreateBackup.UseVisualStyleBackColor = true;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // btnSaveAsTemplate
            // 
            this.btnSaveAsTemplate.Location = new System.Drawing.Point(911, 905);
            this.btnSaveAsTemplate.Name = "btnSaveAsTemplate";
            this.btnSaveAsTemplate.Size = new System.Drawing.Size(156, 35);
            this.btnSaveAsTemplate.TabIndex = 9;
            this.btnSaveAsTemplate.Text = "Save As Template";
            this.btnSaveAsTemplate.UseVisualStyleBackColor = true;
            this.btnSaveAsTemplate.Click += new System.EventHandler(this.btnSaveAsTemplate_Click);
            // 
            // btnClearMySet
            // 
            this.btnClearMySet.Location = new System.Drawing.Point(1290, 87);
            this.btnClearMySet.Name = "btnClearMySet";
            this.btnClearMySet.Size = new System.Drawing.Size(108, 42);
            this.btnClearMySet.TabIndex = 12;
            this.btnClearMySet.Text = "CLEAR ALL";
            this.btnClearMySet.UseVisualStyleBackColor = true;
            this.btnClearMySet.Click += new System.EventHandler(this.btnClearMySet_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1073, 905);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 35);
            this.button3.TabIndex = 13;
            this.button3.Text = "Add To Selected";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(911, 87);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(114, 42);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "New Parameter";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAddToFamily
            // 
            this.btnAddToFamily.Location = new System.Drawing.Point(1232, 905);
            this.btnAddToFamily.Name = "btnAddToFamily";
            this.btnAddToFamily.Size = new System.Drawing.Size(168, 35);
            this.btnAddToFamily.TabIndex = 16;
            this.btnAddToFamily.Text = "Add To Family";
            this.btnAddToFamily.UseVisualStyleBackColor = true;
            this.btnAddToFamily.Click += new System.EventHandler(this.btnAddToFamily_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 912);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 35);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Loaded template path:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 893);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDeleteTemplate);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbxParameterSearch);
            this.tabPage1.Controls.Add(this.dgvParameters);
            this.tabPage1.Controls.Add(this.dgvTemplates);
            this.tabPage1.Controls.Add(this.tbxTemplateFileLocation);
            this.tabPage1.Controls.Add(this.btnSetTemplatePath);
            this.tabPage1.Controls.Add(this.btnCreateBackup);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 864);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "From pCast Template";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search All Templates:";
            // 
            // tbxParameterSearch
            // 
            this.tbxParameterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxParameterSearch.Location = new System.Drawing.Point(299, 89);
            this.tbxParameterSearch.Name = "tbxParameterSearch";
            this.tbxParameterSearch.Size = new System.Drawing.Size(497, 27);
            this.tbxParameterSearch.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbxSharedParameterFilePath);
            this.tabPage2.Controls.Add(this.btnSetParametersFromFilePath);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.dgvParametersFromFile);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 864);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "From Shared Parameter File";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Loaded Shared Parameter File Path:";
            // 
            // tbxSharedParameterFilePath
            // 
            this.tbxSharedParameterFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSharedParameterFilePath.Location = new System.Drawing.Point(13, 39);
            this.tbxSharedParameterFilePath.Name = "tbxSharedParameterFilePath";
            this.tbxSharedParameterFilePath.Size = new System.Drawing.Size(718, 27);
            this.tbxSharedParameterFilePath.TabIndex = 11;
            // 
            // btnSetParametersFromFilePath
            // 
            this.btnSetParametersFromFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetParametersFromFilePath.Location = new System.Drawing.Point(737, 39);
            this.btnSetParametersFromFilePath.Name = "btnSetParametersFromFilePath";
            this.btnSetParametersFromFilePath.Size = new System.Drawing.Size(48, 27);
            this.btnSetParametersFromFilePath.TabIndex = 10;
            this.btnSetParametersFromFilePath.Text = "...";
            this.btnSetParametersFromFilePath.UseVisualStyleBackColor = true;
            this.btnSetParametersFromFilePath.Click += new System.EventHandler(this.btnSetParametersFromFilePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 27);
            this.textBox1.TabIndex = 8;
            // 
            // dgvParametersFromFile
            // 
            this.dgvParametersFromFile.AllowUserToAddRows = false;
            this.dgvParametersFromFile.AllowUserToDeleteRows = false;
            this.dgvParametersFromFile.AllowUserToOrderColumns = true;
            this.dgvParametersFromFile.AllowUserToResizeRows = false;
            this.dgvParametersFromFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvParametersFromFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvParametersFromFile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvParametersFromFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParametersFromFile.Location = new System.Drawing.Point(10, 138);
            this.dgvParametersFromFile.Name = "dgvParametersFromFile";
            this.dgvParametersFromFile.RowTemplate.Height = 24;
            this.dgvParametersFromFile.Size = new System.Drawing.Size(786, 726);
            this.dgvParametersFromFile.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 835);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.Location = new System.Drawing.Point(212, 835);
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTemplate.TabIndex = 20;
            this.btnDeleteTemplate.Text = "Delete";
            this.btnDeleteTemplate.UseVisualStyleBackColor = true;
            this.btnDeleteTemplate.Click += new System.EventHandler(this.btnDeleteTemplate_Click);
            // 
            // frmPCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1410, 958);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddToFamily);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClearMySet);
            this.Controls.Add(this.btnSaveAsTemplate);
            this.Controls.Add(this.dgvMySet);
            this.Controls.Add(this.btnAddToMySet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPCast";
            this.Text = "frmPCast";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMySet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametersFromFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.TextBox tbxTemplateFileLocation;
        private System.Windows.Forms.Button btnSetTemplatePath;
        private System.Windows.Forms.Button btnAddToMySet;
        private System.Windows.Forms.DataGridView dgvMySet;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.Button btnSaveAsTemplate;
        private System.Windows.Forms.Button btnClearMySet;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAddToFamily;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvParametersFromFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxParameterSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSetParametersFromFilePath;
        private System.Windows.Forms.TextBox tbxSharedParameterFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteTemplate;
        private System.Windows.Forms.Button button1;
    }
}