namespace OATools2018.Sheet_Tools
{
    partial class frmChangeTB
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
            this.lbxNewTB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxNewTB
            // 
            this.lbxNewTB.FormattingEnabled = true;
            this.lbxNewTB.Location = new System.Drawing.Point(44, 58);
            this.lbxNewTB.Name = "lbxNewTB";
            this.lbxNewTB.Size = new System.Drawing.Size(625, 24);
            this.lbxNewTB.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmChangeTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbxNewTB);
            this.Name = "frmChangeTB";
            this.Text = "frmChangeTB";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox lbxNewTB;
        private System.Windows.Forms.Button button1;
    }
}