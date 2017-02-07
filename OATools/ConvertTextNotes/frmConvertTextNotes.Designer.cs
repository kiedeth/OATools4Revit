namespace OATools.ConvertTextNotes
{
    partial class frmConvertTextNotes
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
            this.btnConvertTextNotes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConvertTextNotes
            // 
            this.btnConvertTextNotes.Location = new System.Drawing.Point(112, 93);
            this.btnConvertTextNotes.Name = "btnConvertTextNotes";
            this.btnConvertTextNotes.Size = new System.Drawing.Size(192, 50);
            this.btnConvertTextNotes.TabIndex = 0;
            this.btnConvertTextNotes.Text = "button1";
            this.btnConvertTextNotes.UseVisualStyleBackColor = true;
            this.btnConvertTextNotes.Click += new System.EventHandler(this.btnConvertTextNotes_Click);
            // 
            // frmConvertTextNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 520);
            this.Controls.Add(this.btnConvertTextNotes);
            this.Name = "frmConvertTextNotes";
            this.Text = "frmConvertTextNotes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvertTextNotes;
    }
}