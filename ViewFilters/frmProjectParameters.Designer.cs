namespace OATools.ViewFilters
{
    partial class frmProjectParameters
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
            this.dgvProjectParameters = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProjectParameters
            // 
            this.dgvProjectParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjectParameters.Location = new System.Drawing.Point(21, 12);
            this.dgvProjectParameters.Name = "dgvProjectParameters";
            this.dgvProjectParameters.RowTemplate.Height = 24;
            this.dgvProjectParameters.Size = new System.Drawing.Size(804, 592);
            this.dgvProjectParameters.TabIndex = 0;
            // 
            // frmProjectParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 616);
            this.Controls.Add(this.dgvProjectParameters);
            this.Name = "frmProjectParameters";
            this.Text = "frmProjectParameters";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectParameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProjectParameters;
    }
}