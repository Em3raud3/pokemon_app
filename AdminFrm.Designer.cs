namespace Software_Project
{
    partial class AdminFrm
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
            this.adminTextBox1 = new System.Windows.Forms.TextBox();
            this.adminListView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeDialog = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // adminTextBox1
            // 
            this.adminTextBox1.Location = new System.Drawing.Point(223, 57);
            this.adminTextBox1.Name = "adminTextBox1";
            this.adminTextBox1.Size = new System.Drawing.Size(307, 22);
            this.adminTextBox1.TabIndex = 5;
            this.adminTextBox1.TextChanged += new System.EventHandler(this.adminTextBox1_TextChanged);
            // 
            // adminListView1
            // 
            this.adminListView1.BackColor = System.Drawing.Color.AliceBlue;
            this.adminListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.adminListView1.FullRowSelect = true;
            this.adminListView1.GridLines = true;
            this.adminListView1.HideSelection = false;
            this.adminListView1.Location = new System.Drawing.Point(2, 85);
            this.adminListView1.MultiSelect = false;
            this.adminListView1.Name = "adminListView1";
            this.adminListView1.Size = new System.Drawing.Size(767, 233);
            this.adminListView1.TabIndex = 6;
            this.adminListView1.UseCompatibleStateImageBehavior = false;
            this.adminListView1.View = System.Windows.Forms.View.Details;
            this.adminListView1.SelectedIndexChanged += new System.EventHandler(this.adminListView1_SelectedIndexChanged);
            this.adminListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.adminListView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Password";
            this.columnHeader2.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.updateButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(383, 13);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(105, 31);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.createButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.createButton.ForeColor = System.Drawing.Color.White;
            this.createButton.Location = new System.Drawing.Point(162, 11);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(104, 33);
            this.createButton.TabIndex = 8;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.deleteButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(494, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(105, 31);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeDialog
            // 
            this.closeDialog.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.closeDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeDialog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeDialog.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.closeDialog.ForeColor = System.Drawing.Color.White;
            this.closeDialog.Location = new System.Drawing.Point(740, -2);
            this.closeDialog.Name = "closeDialog";
            this.closeDialog.Size = new System.Drawing.Size(32, 31);
            this.closeDialog.TabIndex = 20;
            this.closeDialog.Text = "X";
            this.closeDialog.UseVisualStyleBackColor = false;
            this.closeDialog.Click += new System.EventHandler(this.closeDialog_Click);
            // 
            // readButton
            // 
            this.readButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.readButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(272, 12);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(105, 31);
            this.readButton.TabIndex = 21;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.databaseLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.databaseLabel.Location = new System.Drawing.Point(6, 35);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(34, 23);
            this.databaseLabel.TabIndex = 23;
            this.databaseLabel.Text = "DB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Current Database:";
            // 
            // AdminFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(772, 320);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databaseLabel);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.closeDialog);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.adminListView1);
            this.Controls.Add(this.adminTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminFrm";
            this.Load += new System.EventHandler(this.AdminFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox adminTextBox1;
        public System.Windows.Forms.ListView adminListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeDialog;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.Label label1;
    }
}