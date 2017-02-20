namespace OATools.DNotes
{
    partial class frmCreateDNote
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
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxSheet_number = new System.Windows.Forms.TextBox();
            this.tbxDNoteNumber = new System.Windows.Forms.TextBox();
            this.tbxDNoteText = new System.Windows.Forms.TextBox();
            this.dgvNotesFromFile = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotesFromFile)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(936, 941);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 32);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxSheet_number
            // 
            this.tbxSheet_number.Enabled = false;
            this.tbxSheet_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSheet_number.Location = new System.Drawing.Point(384, 72);
            this.tbxSheet_number.Name = "tbxSheet_number";
            this.tbxSheet_number.Size = new System.Drawing.Size(235, 30);
            this.tbxSheet_number.TabIndex = 1;
            this.tbxSheet_number.TextChanged += new System.EventHandler(this.tbxSheet_number_TextChanged);
            // 
            // tbxDNoteNumber
            // 
            this.tbxDNoteNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDNoteNumber.Location = new System.Drawing.Point(444, 36);
            this.tbxDNoteNumber.Name = "tbxDNoteNumber";
            this.tbxDNoteNumber.Size = new System.Drawing.Size(115, 30);
            this.tbxDNoteNumber.TabIndex = 2;
            this.tbxDNoteNumber.TextChanged += new System.EventHandler(this.tbxDNoteNumber_TextChanged);
            // 
            // tbxDNoteText
            // 
            this.tbxDNoteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDNoteText.Location = new System.Drawing.Point(12, 189);
            this.tbxDNoteText.Multiline = true;
            this.tbxDNoteText.Name = "tbxDNoteText";
            this.tbxDNoteText.Size = new System.Drawing.Size(1020, 121);
            this.tbxDNoteText.TabIndex = 3;
            this.tbxDNoteText.TextChanged += new System.EventHandler(this.txbDNoteText_TextChanged);
            // 
            // dgvNotesFromFile
            // 
            this.dgvNotesFromFile.AllowUserToResizeColumns = false;
            this.dgvNotesFromFile.AllowUserToResizeRows = false;
            this.dgvNotesFromFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotesFromFile.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvNotesFromFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotesFromFile.Location = new System.Drawing.Point(12, 316);
            this.dgvNotesFromFile.Name = "dgvNotesFromFile";
            this.dgvNotesFromFile.RowTemplate.Height = 24;
            this.dgvNotesFromFile.Size = new System.Drawing.Size(1020, 619);
            this.dgvNotesFromFile.TabIndex = 4;
            this.dgvNotesFromFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotesFromFile_CellContentClick);
            // 
            // frmCreateDNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 985);
            this.Controls.Add(this.dgvNotesFromFile);
            this.Controls.Add(this.tbxDNoteText);
            this.Controls.Add(this.tbxDNoteNumber);
            this.Controls.Add(this.tbxSheet_number);
            this.Controls.Add(this.btnOK);
            this.Name = "frmCreateDNote";
            this.Text = "frmCreateDNote";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotesFromFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxSheet_number;
        private System.Windows.Forms.TextBox tbxDNoteNumber;
        private System.Windows.Forms.TextBox tbxDNoteText;
        private System.Windows.Forms.DataGridView dgvNotesFromFile;
    }
}