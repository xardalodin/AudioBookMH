namespace OnlineUpdate
{
    partial class OnlineUpdateDownloadForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelDownloadingUpdate = new System.Windows.Forms.Label();
            this.labelDownloadingProgressBar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 139);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(490, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // labelDownloadingUpdate
            // 
            this.labelDownloadingUpdate.AutoSize = true;
            this.labelDownloadingUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownloadingUpdate.Location = new System.Drawing.Point(94, 60);
            this.labelDownloadingUpdate.Name = "labelDownloadingUpdate";
            this.labelDownloadingUpdate.Size = new System.Drawing.Size(333, 37);
            this.labelDownloadingUpdate.TabIndex = 1;
            this.labelDownloadingUpdate.Text = "Downloading Update..";
            // 
            // labelDownloadingProgressBar
            // 
            this.labelDownloadingProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownloadingProgressBar.Location = new System.Drawing.Point(12, 169);
            this.labelDownloadingProgressBar.Name = "labelDownloadingProgressBar";
            this.labelDownloadingProgressBar.Size = new System.Drawing.Size(490, 23);
            this.labelDownloadingProgressBar.TabIndex = 2;
            // 
            // OnlineUpdateDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 196);
            this.Controls.Add(this.labelDownloadingProgressBar);
            this.Controls.Add(this.labelDownloadingUpdate);
            this.Controls.Add(this.progressBar);
            this.Name = "OnlineUpdateDownloadForm";
            this.Text = "OnlineUpdateDownloadForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelDownloadingUpdate;
        private System.Windows.Forms.Label labelDownloadingProgressBar;
    }
}