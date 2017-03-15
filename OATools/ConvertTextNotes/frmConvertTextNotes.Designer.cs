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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertTextNotes));
            this.btnConvertTextNotes = new System.Windows.Forms.Button();
            this.rbtnActiveView = new System.Windows.Forms.RadioButton();
            this.rbtnByProject = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConvertTextNotes
            // 
            this.btnConvertTextNotes.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConvertTextNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertTextNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertTextNotes.Location = new System.Drawing.Point(321, 122);
            this.btnConvertTextNotes.Name = "btnConvertTextNotes";
            this.btnConvertTextNotes.Size = new System.Drawing.Size(135, 41);
            this.btnConvertTextNotes.TabIndex = 0;
            this.btnConvertTextNotes.Text = "Process";
            this.btnConvertTextNotes.UseVisualStyleBackColor = true;
            this.btnConvertTextNotes.Click += new System.EventHandler(this.btnConvertTextNotes_Click);
            // 
            // rbtnActiveView
            // 
            this.rbtnActiveView.AutoSize = true;
            this.rbtnActiveView.Font = new System.Drawing.Font("Monospac821 BT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnActiveView.Location = new System.Drawing.Point(17, 52);
            this.rbtnActiveView.Name = "rbtnActiveView";
            this.rbtnActiveView.Size = new System.Drawing.Size(196, 26);
            this.rbtnActiveView.TabIndex = 1;
            this.rbtnActiveView.TabStop = true;
            this.rbtnActiveView.Text = "Active Viewtest";
            this.rbtnActiveView.UseVisualStyleBackColor = true;
            // 
            // rbtnByProject
            // 
            this.rbtnByProject.AutoSize = true;
            this.rbtnByProject.Font = new System.Drawing.Font("Monospac821 BT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnByProject.Location = new System.Drawing.Point(271, 52);
            this.rbtnByProject.Name = "rbtnByProject";
            this.rbtnByProject.Size = new System.Drawing.Size(185, 26);
            this.rbtnByProject.TabIndex = 2;
            this.rbtnByProject.TabStop = true;
            this.rbtnByProject.Text = "Entire Project";
            this.rbtnByProject.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Revit_HEB_SHX", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Convert All Text Notes to uppercase text in the:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(17, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 41);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmConvertTextNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(468, 178);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnByProject);
            this.Controls.Add(this.rbtnActiveView);
            this.Controls.Add(this.btnConvertTextNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConvertTextNotes";
            this.Text = "frmConvertTextNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvertTextNotes;
        private System.Windows.Forms.RadioButton rbtnActiveView;
        private System.Windows.Forms.RadioButton rbtnByProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
    }
}