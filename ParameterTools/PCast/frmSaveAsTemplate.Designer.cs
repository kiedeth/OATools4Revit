namespace OATools.ParameterTools.PCast
{
    partial class frmSaveAsTemplate
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
            this.tbxTemplateName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbxTemplateToWriteInto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxTemplateName
            // 
            this.tbxTemplateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTemplateName.Location = new System.Drawing.Point(71, 87);
            this.tbxTemplateName.Name = "tbxTemplateName";
            this.tbxTemplateName.Size = new System.Drawing.Size(535, 27);
            this.tbxTemplateName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(507, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbxTemplateToWriteInto
            // 
            this.tbxTemplateToWriteInto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTemplateToWriteInto.Location = new System.Drawing.Point(71, 43);
            this.tbxTemplateToWriteInto.Name = "tbxTemplateToWriteInto";
            this.tbxTemplateToWriteInto.Size = new System.Drawing.Size(535, 27);
            this.tbxTemplateToWriteInto.TabIndex = 2;
            // 
            // frmSaveAsTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 199);
            this.Controls.Add(this.tbxTemplateToWriteInto);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxTemplateName);
            this.Name = "frmSaveAsTemplate";
            this.Text = "frmSaveAsTemplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxTemplateName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbxTemplateToWriteInto;
    }
}