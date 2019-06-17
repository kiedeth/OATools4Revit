namespace OATools2018.ConvertTextNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertTextNotes));
            this.btnConvertTextNotes = new System.Windows.Forms.Button();
            this.rbtnActiveView = new System.Windows.Forms.RadioButton();
            this.rbtnByProject = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConvertTextNotes
            // 
            this.btnConvertTextNotes.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConvertTextNotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnConvertTextNotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConvertTextNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertTextNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertTextNotes.Location = new System.Drawing.Point(271, 136);
            this.btnConvertTextNotes.Name = "btnConvertTextNotes";
            this.btnConvertTextNotes.Size = new System.Drawing.Size(106, 30);
            this.btnConvertTextNotes.TabIndex = 0;
            this.btnConvertTextNotes.Text = "Process";
            this.btnConvertTextNotes.UseVisualStyleBackColor = true;
            this.btnConvertTextNotes.Click += new System.EventHandler(this.btnConvertTextNotes_Click);
            // 
            // rbtnActiveView
            // 
            this.rbtnActiveView.AllowDrop = true;
            this.rbtnActiveView.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnActiveView.AutoSize = true;
            this.rbtnActiveView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbtnActiveView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rbtnActiveView.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnActiveView.Location = new System.Drawing.Point(69, 66);
            this.rbtnActiveView.Name = "rbtnActiveView";
            this.rbtnActiveView.Size = new System.Drawing.Size(106, 33);
            this.rbtnActiveView.TabIndex = 1;
            this.rbtnActiveView.TabStop = true;
            this.rbtnActiveView.Text = "Active View";
            this.rbtnActiveView.UseVisualStyleBackColor = false;
            // 
            // rbtnByProject
            // 
            this.rbtnByProject.AllowDrop = true;
            this.rbtnByProject.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnByProject.AutoSize = true;
            this.rbtnByProject.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbtnByProject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rbtnByProject.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnByProject.Location = new System.Drawing.Point(216, 66);
            this.rbtnByProject.Name = "rbtnByProject";
            this.rbtnByProject.Size = new System.Drawing.Size(120, 33);
            this.rbtnByProject.TabIndex = 2;
            this.rbtnByProject.TabStop = true;
            this.rbtnByProject.Text = "Entire Project";
            this.rbtnByProject.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "CHANGE ALL TEXT NOTES TO UPPERCASE:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(27, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(407, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // frmConvertTextNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(565, 178);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnByProject);
            this.Controls.Add(this.rbtnActiveView);
            this.Controls.Add(this.btnConvertTextNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConvertTextNotes";
            this.Text = "frmConvertTextNotes";
            this.Load += new System.EventHandler(this.frmConvertTextNotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvertTextNotes;
        private System.Windows.Forms.RadioButton rbtnActiveView;
        private System.Windows.Forms.RadioButton rbtnByProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}