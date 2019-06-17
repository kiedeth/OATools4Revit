namespace OATools2018.CommonTools.MyProject
{
    partial class frmMyProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMyProject));
            this.btnDeleteRefPlanes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCopyProjectInfoFromLink = new System.Windows.Forms.Button();
            this.btnGetLinkedElements = new System.Windows.Forms.Button();
            this.btnCopyWallType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteRefPlanes
            // 
            this.btnDeleteRefPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRefPlanes.Location = new System.Drawing.Point(12, 186);
            this.btnDeleteRefPlanes.Name = "btnDeleteRefPlanes";
            this.btnDeleteRefPlanes.Size = new System.Drawing.Size(430, 38);
            this.btnDeleteRefPlanes.TabIndex = 0;
            this.btnDeleteRefPlanes.Text = "Delete Unused Reference Planes";
            this.btnDeleteRefPlanes.UseVisualStyleBackColor = true;
            this.btnDeleteRefPlanes.Click += new System.EventHandler(this.btnDeleteRefPlanes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(151, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnCopyProjectInfoFromLink
            // 
            this.btnCopyProjectInfoFromLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyProjectInfoFromLink.Location = new System.Drawing.Point(12, 230);
            this.btnCopyProjectInfoFromLink.Name = "btnCopyProjectInfoFromLink";
            this.btnCopyProjectInfoFromLink.Size = new System.Drawing.Size(430, 38);
            this.btnCopyProjectInfoFromLink.TabIndex = 27;
            this.btnCopyProjectInfoFromLink.Text = "Copy the Project Info from a linked model";
            this.btnCopyProjectInfoFromLink.UseVisualStyleBackColor = true;
            this.btnCopyProjectInfoFromLink.Click += new System.EventHandler(this.btnCopyProjectInfoFromLink_Click);
            // 
            // btnGetLinkedElements
            // 
            this.btnGetLinkedElements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetLinkedElements.Location = new System.Drawing.Point(12, 274);
            this.btnGetLinkedElements.Name = "btnGetLinkedElements";
            this.btnGetLinkedElements.Size = new System.Drawing.Size(430, 38);
            this.btnGetLinkedElements.TabIndex = 28;
            this.btnGetLinkedElements.Text = "Show linked elements";
            this.btnGetLinkedElements.UseVisualStyleBackColor = true;
            this.btnGetLinkedElements.Click += new System.EventHandler(this.btnGetLinkedElements_Click);
            // 
            // btnCopyWallType
            // 
            this.btnCopyWallType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyWallType.Location = new System.Drawing.Point(12, 318);
            this.btnCopyWallType.Name = "btnCopyWallType";
            this.btnCopyWallType.Size = new System.Drawing.Size(430, 38);
            this.btnCopyWallType.TabIndex = 29;
            this.btnCopyWallType.Text = "Copy Wall Type From Another Project";
            this.btnCopyWallType.UseVisualStyleBackColor = true;
            this.btnCopyWallType.Click += new System.EventHandler(this.btnCopyWallType_Click);
            // 
            // frmMyProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(454, 744);
            this.Controls.Add(this.btnCopyWallType);
            this.Controls.Add(this.btnGetLinkedElements);
            this.Controls.Add(this.btnCopyProjectInfoFromLink);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDeleteRefPlanes);
            this.Name = "frmMyProject";
            this.Text = "frmMyProject";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteRefPlanes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCopyProjectInfoFromLink;
        private System.Windows.Forms.Button btnGetLinkedElements;
        private System.Windows.Forms.Button btnCopyWallType;
    }
}