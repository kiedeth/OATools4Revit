namespace OATools2018.Revitize
{
    partial class frmCreateAddViewsToSheet
    {
        private ViewsMgr m_data;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateAddViewsToSheet));
            this.GenerateSheetGroupBox = new System.Windows.Forms.GroupBox();
            this.gbSheetData = new System.Windows.Forms.GroupBox();
            this.sheetNameLabel = new System.Windows.Forms.Label();
            this.sheetNameTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.oKButton = new System.Windows.Forms.Button();
            this.gbTitleBlocks = new System.Windows.Forms.GroupBox();
            this.titleBlocksListBox = new System.Windows.Forms.ListBox();
            this.allViewsGroupBox = new System.Windows.Forms.GroupBox();
            this.allViewsTreeView = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GenerateSheetGroupBox.SuspendLayout();
            this.gbSheetData.SuspendLayout();
            this.gbTitleBlocks.SuspendLayout();
            this.allViewsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateSheetGroupBox
            // 
            this.GenerateSheetGroupBox.Controls.Add(this.gbSheetData);
            this.GenerateSheetGroupBox.Controls.Add(this.gbTitleBlocks);
            this.GenerateSheetGroupBox.Controls.Add(this.allViewsGroupBox);
            this.GenerateSheetGroupBox.Location = new System.Drawing.Point(13, 129);
            this.GenerateSheetGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.GenerateSheetGroupBox.Name = "GenerateSheetGroupBox";
            this.GenerateSheetGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.GenerateSheetGroupBox.Size = new System.Drawing.Size(1123, 489);
            this.GenerateSheetGroupBox.TabIndex = 2;
            this.GenerateSheetGroupBox.TabStop = false;
            this.GenerateSheetGroupBox.Text = "Generate Sheet";
            // 
            // gbSheetData
            // 
            this.gbSheetData.Controls.Add(this.sheetNameLabel);
            this.gbSheetData.Controls.Add(this.sheetNameTextBox);
            this.gbSheetData.Controls.Add(this.cancelButton);
            this.gbSheetData.Controls.Add(this.oKButton);
            this.gbSheetData.Location = new System.Drawing.Point(634, 245);
            this.gbSheetData.Name = "gbSheetData";
            this.gbSheetData.Size = new System.Drawing.Size(481, 229);
            this.gbSheetData.TabIndex = 8;
            this.gbSheetData.TabStop = false;
            this.gbSheetData.Text = "Sheet Data";
            // 
            // sheetNameLabel
            // 
            this.sheetNameLabel.AutoSize = true;
            this.sheetNameLabel.Location = new System.Drawing.Point(7, 24);
            this.sheetNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sheetNameLabel.Name = "sheetNameLabel";
            this.sheetNameLabel.Size = new System.Drawing.Size(86, 17);
            this.sheetNameLabel.TabIndex = 5;
            this.sheetNameLabel.Text = "Sheet Name";
            // 
            // sheetNameTextBox
            // 
            this.sheetNameTextBox.Location = new System.Drawing.Point(103, 22);
            this.sheetNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sheetNameTextBox.Name = "sheetNameTextBox";
            this.sheetNameTextBox.Size = new System.Drawing.Size(371, 22);
            this.sheetNameTextBox.TabIndex = 2;
            this.sheetNameTextBox.Text = "DETAILS";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(267, 190);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // oKButton
            // 
            this.oKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.oKButton.Location = new System.Drawing.Point(375, 190);
            this.oKButton.Margin = new System.Windows.Forms.Padding(4);
            this.oKButton.Name = "oKButton";
            this.oKButton.Size = new System.Drawing.Size(100, 28);
            this.oKButton.TabIndex = 3;
            this.oKButton.Text = "&OK";
            this.oKButton.UseVisualStyleBackColor = true;
            this.oKButton.Click += new System.EventHandler(this.oKButton_Click);
            // 
            // gbTitleBlocks
            // 
            this.gbTitleBlocks.Controls.Add(this.titleBlocksListBox);
            this.gbTitleBlocks.Location = new System.Drawing.Point(634, 24);
            this.gbTitleBlocks.Name = "gbTitleBlocks";
            this.gbTitleBlocks.Size = new System.Drawing.Size(481, 215);
            this.gbTitleBlocks.TabIndex = 7;
            this.gbTitleBlocks.TabStop = false;
            this.gbTitleBlocks.Text = "TitleBlocks";
            // 
            // titleBlocksListBox
            // 
            this.titleBlocksListBox.FormattingEnabled = true;
            this.titleBlocksListBox.ItemHeight = 16;
            this.titleBlocksListBox.Location = new System.Drawing.Point(8, 22);
            this.titleBlocksListBox.Margin = new System.Windows.Forms.Padding(4);
            this.titleBlocksListBox.Name = "titleBlocksListBox";
            this.titleBlocksListBox.Size = new System.Drawing.Size(466, 180);
            this.titleBlocksListBox.Sorted = true;
            this.titleBlocksListBox.TabIndex = 6;
            // 
            // allViewsGroupBox
            // 
            this.allViewsGroupBox.Controls.Add(this.allViewsTreeView);
            this.allViewsGroupBox.Location = new System.Drawing.Point(8, 23);
            this.allViewsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.allViewsGroupBox.Name = "allViewsGroupBox";
            this.allViewsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.allViewsGroupBox.Size = new System.Drawing.Size(619, 451);
            this.allViewsGroupBox.TabIndex = 3;
            this.allViewsGroupBox.TabStop = false;
            this.allViewsGroupBox.Text = "Select views to add";
            // 
            // allViewsTreeView
            // 
            this.allViewsTreeView.CheckBoxes = true;
            this.allViewsTreeView.Location = new System.Drawing.Point(8, 23);
            this.allViewsTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.allViewsTreeView.Name = "allViewsTreeView";
            this.allViewsTreeView.Size = new System.Drawing.Size(600, 417);
            this.allViewsTreeView.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(970, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // frmCreateAddViewsToSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 626);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GenerateSheetGroupBox);
            this.Name = "frmCreateAddViewsToSheet";
            this.Text = "frmCreateAddViewsToSheet";
            this.Load += new System.EventHandler(this.frmCreateAddViewsToSheet_Load);
            this.GenerateSheetGroupBox.ResumeLayout(false);
            this.gbSheetData.ResumeLayout(false);
            this.gbSheetData.PerformLayout();
            this.gbTitleBlocks.ResumeLayout(false);
            this.allViewsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GenerateSheetGroupBox;
        private System.Windows.Forms.ListBox titleBlocksListBox;
        private System.Windows.Forms.Label sheetNameLabel;
        private System.Windows.Forms.TextBox sheetNameTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button oKButton;
        private System.Windows.Forms.GroupBox allViewsGroupBox;
        private System.Windows.Forms.TreeView allViewsTreeView;
        private System.Windows.Forms.GroupBox gbSheetData;
        private System.Windows.Forms.GroupBox gbTitleBlocks;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}