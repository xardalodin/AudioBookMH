namespace AudioBookMH
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DeleteButtton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.listViewNames = new System.Windows.Forms.ListView();
            this.nameListview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrentTimeListview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePlaying = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumberOfFilesListview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.updateBtn);
            this.splitContainer1.Panel1.Controls.Add(this.DeleteButtton);
            this.splitContainer1.Panel1.Controls.Add(this.PlayButton);
            this.splitContainer1.Panel1.Controls.Add(this.NewButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewNames);
            this.splitContainer1.Size = new System.Drawing.Size(815, 231);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 0;
            // 
            // DeleteButtton
            // 
            this.DeleteButtton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButtton.Location = new System.Drawing.Point(34, 110);
            this.DeleteButtton.Name = "DeleteButtton";
            this.DeleteButtton.Size = new System.Drawing.Size(137, 43);
            this.DeleteButtton.TabIndex = 2;
            this.DeleteButtton.Text = "Delete";
            this.DeleteButtton.UseVisualStyleBackColor = true;
            this.DeleteButtton.Click += new System.EventHandler(this.DeleteButtton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.Location = new System.Drawing.Point(34, 61);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(137, 43);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NewButton.Location = new System.Drawing.Point(34, 12);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(137, 43);
            this.NewButton.TabIndex = 0;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // listViewNames
            // 
            this.listViewNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameListview,
            this.CurrentTimeListview,
            this.filePlaying,
            this.NumberOfFilesListview});
            this.listViewNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNames.Location = new System.Drawing.Point(0, 0);
            this.listViewNames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listViewNames.Name = "listViewNames";
            this.listViewNames.Size = new System.Drawing.Size(605, 231);
            this.listViewNames.TabIndex = 0;
            this.listViewNames.UseCompatibleStateImageBehavior = false;
            this.listViewNames.View = System.Windows.Forms.View.Details;
            // 
            // nameListview
            // 
            this.nameListview.Text = "Name";
            this.nameListview.Width = 150;
            // 
            // CurrentTimeListview
            // 
            this.CurrentTimeListview.Text = "CurrentTime";
            this.CurrentTimeListview.Width = 150;
            // 
            // filePlaying
            // 
            this.filePlaying.Text = "File Playing";
            this.filePlaying.Width = 150;
            // 
            // NumberOfFilesListview
            // 
            this.NumberOfFilesListview.Text = "Number Of Files";
            this.NumberOfFilesListview.Width = 150;
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(34, 159);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(137, 43);
            this.updateBtn.TabIndex = 3;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 231);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button DeleteButtton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.ListView listViewNames;
        private System.Windows.Forms.ColumnHeader nameListview;
        private System.Windows.Forms.ColumnHeader CurrentTimeListview;
        private System.Windows.Forms.ColumnHeader filePlaying;
        private System.Windows.Forms.ColumnHeader NumberOfFilesListview;
        private System.Windows.Forms.Button updateBtn;
    }
}

