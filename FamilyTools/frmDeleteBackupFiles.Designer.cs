namespace OATools2018.FamilyTools
{
    partial class frmDeleteBackupFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteBackupFiles));
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSetPathToFamily = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tbxStartingDirectory = new System.Windows.Forms.TextBox();
            this.cbxIncludeSubFolders = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxNumberOfFilesSelected = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearchForBackups = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(958, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 35);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(958, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btnSetPathToFamily
            // 
            this.btnSetPathToFamily.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSetPathToFamily.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSetPathToFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPathToFamily.Location = new System.Drawing.Point(342, 118);
            this.btnSetPathToFamily.Name = "btnSetPathToFamily";
            this.btnSetPathToFamily.Size = new System.Drawing.Size(161, 30);
            this.btnSetPathToFamily.TabIndex = 25;
            this.btnSetPathToFamily.Text = "Select Family";
            this.btnSetPathToFamily.UseVisualStyleBackColor = true;
            this.btnSetPathToFamily.Click += new System.EventHandler(this.btnSetPathToFamily_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Your search will start here:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnProcess
            // 
            this.btnProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Location = new System.Drawing.Point(48, 418);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(169, 35);
            this.btnProcess.TabIndex = 31;
            this.btnProcess.Text = "Delete files";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // tbxStartingDirectory
            // 
            this.tbxStartingDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStartingDirectory.Location = new System.Drawing.Point(54, 207);
            this.tbxStartingDirectory.Name = "tbxStartingDirectory";
            this.tbxStartingDirectory.Size = new System.Drawing.Size(870, 22);
            this.tbxStartingDirectory.TabIndex = 32;
            // 
            // cbxIncludeSubFolders
            // 
            this.cbxIncludeSubFolders.AutoSize = true;
            this.cbxIncludeSubFolders.Checked = true;
            this.cbxIncludeSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeSubFolders.FlatAppearance.BorderSize = 3;
            this.cbxIncludeSubFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxIncludeSubFolders.ForeColor = System.Drawing.Color.Black;
            this.cbxIncludeSubFolders.Location = new System.Drawing.Point(48, 253);
            this.cbxIncludeSubFolders.Name = "cbxIncludeSubFolders";
            this.cbxIncludeSubFolders.Size = new System.Drawing.Size(169, 24);
            this.cbxIncludeSubFolders.TabIndex = 33;
            this.cbxIncludeSubFolders.Text = "Include Subfolders";
            this.cbxIncludeSubFolders.UseVisualStyleBackColor = true;
            this.cbxIncludeSubFolders.CheckedChanged += new System.EventHandler(this.cbxIncludeSubFolders_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "1)   Select a Family to start your search at:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(586, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "(Note: This family does not need to be a backup family and it will not be deleted" +
    " unless it is.)";
            // 
            // tbxNumberOfFilesSelected
            // 
            this.tbxNumberOfFilesSelected.Enabled = false;
            this.tbxNumberOfFilesSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNumberOfFilesSelected.Location = new System.Drawing.Point(48, 349);
            this.tbxNumberOfFilesSelected.Name = "tbxNumberOfFilesSelected";
            this.tbxNumberOfFilesSelected.Size = new System.Drawing.Size(66, 30);
            this.tbxNumberOfFilesSelected.TabIndex = 36;
            this.tbxNumberOfFilesSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxNumberOfFilesSelected.TextChanged += new System.EventHandler(this.tbxNumberOfFilesSelected_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "backup files were found to delete.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "2)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "3)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSearchForBackups
            // 
            this.btnSearchForBackups.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSearchForBackups.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearchForBackups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchForBackups.Location = new System.Drawing.Point(48, 308);
            this.btnSearchForBackups.Name = "btnSearchForBackups";
            this.btnSearchForBackups.Size = new System.Drawing.Size(169, 30);
            this.btnSearchForBackups.TabIndex = 41;
            this.btnSearchForBackups.Text = "Scan for backup files";
            this.btnSearchForBackups.UseVisualStyleBackColor = true;
            this.btnSearchForBackups.Click += new System.EventHandler(this.btnSearchForBackups_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "4)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(373, 32);
            this.label8.TabIndex = 43;
            this.label8.Text = "Delete Family backup files";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(370, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 67);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // frmDeleteBackupFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1130, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSearchForBackups);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxNumberOfFilesSelected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxIncludeSubFolders);
            this.Controls.Add(this.tbxStartingDirectory);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSetPathToFamily);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDeleteBackupFiles";
            this.Text = "frmDeleteBackupFiles";
            this.Load += new System.EventHandler(this.frmDeleteBackupFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSetPathToFamily;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox tbxStartingDirectory;
        private System.Windows.Forms.CheckBox cbxIncludeSubFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxNumberOfFilesSelected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearchForBackups;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}