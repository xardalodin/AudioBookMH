namespace AudioBookMH
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.updateButton2 = new System.Windows.Forms.Button();
            this.labelUpdate2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateButton2
            // 
            this.updateButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton2.Location = new System.Drawing.Point(81, 96);
            this.updateButton2.Name = "updateButton2";
            this.updateButton2.Size = new System.Drawing.Size(108, 27);
            this.updateButton2.TabIndex = 0;
            this.updateButton2.Text = "Update";
            this.updateButton2.UseVisualStyleBackColor = true;
            this.updateButton2.Click += new System.EventHandler(this.updateButton2_Click);
            // 
            // labelUpdate2
            // 
            this.labelUpdate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdate2.Location = new System.Drawing.Point(95, 47);
            this.labelUpdate2.Name = "labelUpdate2";
            this.labelUpdate2.Size = new System.Drawing.Size(94, 23);
            this.labelUpdate2.TabIndex = 1;
            this.labelUpdate2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 150);
            this.Controls.Add(this.labelUpdate2);
            this.Controls.Add(this.updateButton2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button updateButton2;
        private System.Windows.Forms.Label labelUpdate2;
    }
}