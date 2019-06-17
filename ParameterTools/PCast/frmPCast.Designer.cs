namespace OATools2018.ParameterTools.PCast
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPCast));
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
            this.btnDeleteTemplate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxParameterSearch = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSharedParameterFilePath = new System.Windows.Forms.TextBox();
            this.btnSetParametersFromFilePath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxParameterFromFileSearch = new System.Windows.Forms.TextBox();
            this.dgvParametersFromFile = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMySet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametersFromFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTemplates
            // 
            this.dgvTemplates.AllowUserToAddRows = false;
            this.dgvTemplates.AllowUserToDeleteRows = false;
            this.dgvTemplates.AllowUserToResizeColumns = false;
            this.dgvTemplates.AllowUserToResizeRows = false;
            this.dgvTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTemplates.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTemplates.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemplates.Location = new System.Drawing.Point(6, 59);
            this.dgvTemplates.MultiSelect = false;
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.ReadOnly = true;
            this.dgvTemplates.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvTemplates.RowHeadersVisible = false;
            this.dgvTemplates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTemplates.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTemplates.RowTemplate.Height = 24;
            this.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplates.Size = new System.Drawing.Size(281, 717);
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
            this.dgvParameters.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvParameters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvParameters.Location = new System.Drawing.Point(299, 122);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParameters.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParameters.RowTemplate.Height = 24;
            this.dgvParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParameters.Size = new System.Drawing.Size(497, 695);
            this.dgvParameters.TabIndex = 1;
            // 
            // tbxTemplateFileLocation
            // 
            this.tbxTemplateFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTemplateFileLocation.Location = new System.Drawing.Point(6, 26);
            this.tbxTemplateFileLocation.Name = "tbxTemplateFileLocation";
            this.tbxTemplateFileLocation.Size = new System.Drawing.Size(607, 27);
            this.tbxTemplateFileLocation.TabIndex = 2;
            this.tbxTemplateFileLocation.TextChanged += new System.EventHandler(this.tbxTemplateFileLocation_TextChanged);
            // 
            // btnSetTemplatePath
            // 
            this.btnSetTemplatePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnAddToMySet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnAddToMySet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddToMySet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.dgvMySet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMySet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvMySet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMySet.Location = new System.Drawing.Point(911, 41);
            this.dgvMySet.Name = "dgvMySet";
            this.dgvMySet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMySet.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMySet.RowTemplate.Height = 24;
            this.dgvMySet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMySet.Size = new System.Drawing.Size(489, 817);
            this.dgvMySet.TabIndex = 7;
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBackup.Location = new System.Drawing.Point(673, 26);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(121, 27);
            this.btnCreateBackup.TabIndex = 8;
            this.btnCreateBackup.Text = "Create Backup";
            this.btnCreateBackup.UseVisualStyleBackColor = true;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // btnSaveAsTemplate
            // 
            this.btnSaveAsTemplate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSaveAsTemplate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSaveAsTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAsTemplate.Location = new System.Drawing.Point(1406, 41);
            this.btnSaveAsTemplate.Name = "btnSaveAsTemplate";
            this.btnSaveAsTemplate.Size = new System.Drawing.Size(168, 35);
            this.btnSaveAsTemplate.TabIndex = 9;
            this.btnSaveAsTemplate.Text = "Save As Template";
            this.btnSaveAsTemplate.UseVisualStyleBackColor = true;
            this.btnSaveAsTemplate.Click += new System.EventHandler(this.btnSaveAsTemplate_Click);
            // 
            // btnClearMySet
            // 
            this.btnClearMySet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClearMySet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClearMySet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearMySet.Location = new System.Drawing.Point(1409, 782);
            this.btnClearMySet.Name = "btnClearMySet";
            this.btnClearMySet.Size = new System.Drawing.Size(165, 35);
            this.btnClearMySet.TabIndex = 12;
            this.btnClearMySet.Text = "CLEAR ALL";
            this.btnClearMySet.UseVisualStyleBackColor = true;
            this.btnClearMySet.Click += new System.EventHandler(this.btnClearMySet_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(1406, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 35);
            this.button3.TabIndex = 13;
            this.button3.Text = "Add To Selected";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(824, 163);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(77, 34);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "NEW >";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAddToFamily
            // 
            this.btnAddToFamily.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnAddToFamily.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddToFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToFamily.Location = new System.Drawing.Point(1406, 120);
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
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(1409, 823);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(167, 35);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Loaded template path:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 858);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDeleteTemplate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbxParameterSearch);
            this.tabPage1.Controls.Add(this.dgvParameters);
            this.tabPage1.Controls.Add(this.dgvTemplates);
            this.tabPage1.Controls.Add(this.tbxTemplateFileLocation);
            this.tabPage1.Controls.Add(this.btnSetTemplatePath);
            this.tabPage1.Controls.Add(this.btnCreateBackup);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 825);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "From pCast Template";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTemplate.Location = new System.Drawing.Point(10, 784);
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(277, 33);
            this.btnDeleteTemplate.TabIndex = 20;
            this.btnDeleteTemplate.Text = "Delete Template";
            this.btnDeleteTemplate.UseVisualStyleBackColor = true;
            this.btnDeleteTemplate.Click += new System.EventHandler(this.btnDeleteTemplate_Click);
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
            this.tbxParameterSearch.TextChanged += new System.EventHandler(this.tbxParameterSearch_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbxSharedParameterFilePath);
            this.tabPage2.Controls.Add(this.btnSetParametersFromFilePath);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbxParameterFromFileSearch);
            this.tabPage2.Controls.Add(this.dgvParametersFromFile);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 825);
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
            this.btnSetParametersFromFilePath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSetParametersFromFilePath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSetParametersFromFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            // tbxParameterFromFileSearch
            // 
            this.tbxParameterFromFileSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxParameterFromFileSearch.Location = new System.Drawing.Point(10, 105);
            this.tbxParameterFromFileSearch.Name = "tbxParameterFromFileSearch";
            this.tbxParameterFromFileSearch.Size = new System.Drawing.Size(347, 27);
            this.tbxParameterFromFileSearch.TabIndex = 8;
            this.tbxParameterFromFileSearch.TextChanged += new System.EventHandler(this.tbxParameterFromFileSearch_TextChanged);
            // 
            // dgvParametersFromFile
            // 
            this.dgvParametersFromFile.AllowUserToAddRows = false;
            this.dgvParametersFromFile.AllowUserToDeleteRows = false;
            this.dgvParametersFromFile.AllowUserToOrderColumns = true;
            this.dgvParametersFromFile.AllowUserToResizeRows = false;
            this.dgvParametersFromFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvParametersFromFile.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvParametersFromFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvParametersFromFile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvParametersFromFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParametersFromFile.Location = new System.Drawing.Point(10, 138);
            this.dgvParametersFromFile.Name = "dgvParametersFromFile";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParametersFromFile.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvParametersFromFile.RowTemplate.Height = 24;
            this.dgvParametersFromFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParametersFromFile.Size = new System.Drawing.Size(786, 726);
            this.dgvParametersFromFile.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1409, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(822, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1579, 879);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClearMySet);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddToFamily);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSaveAsTemplate);
            this.Controls.Add(this.dgvMySet);
            this.Controls.Add(this.btnAddToMySet);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.TextBox tbxParameterFromFileSearch;
        private System.Windows.Forms.Button btnSetParametersFromFilePath;
        private System.Windows.Forms.TextBox tbxSharedParameterFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteTemplate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}