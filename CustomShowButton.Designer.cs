namespace Software_Project
{
    partial class CustomShowButton
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
            this.showListLabel = new System.Windows.Forms.Label();
            this.showCaughtButton = new System.Windows.Forms.Button();
            this.showFavoriteButton = new System.Windows.Forms.Button();
            this.closeDialog = new System.Windows.Forms.Button();
            this.uncaughtListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showListLabel
            // 
            this.showListLabel.AutoSize = true;
            this.showListLabel.Font = new System.Drawing.Font("Oswald", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showListLabel.Location = new System.Drawing.Point(160, 29);
            this.showListLabel.Name = "showListLabel";
            this.showListLabel.Size = new System.Drawing.Size(133, 41);
            this.showListLabel.TabIndex = 1;
            this.showListLabel.Text = "Show List";
            // 
            // showCaughtButton
            // 
            this.showCaughtButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.showCaughtButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showCaughtButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.showCaughtButton.Location = new System.Drawing.Point(33, 141);
            this.showCaughtButton.Name = "showCaughtButton";
            this.showCaughtButton.Size = new System.Drawing.Size(117, 49);
            this.showCaughtButton.TabIndex = 2;
            this.showCaughtButton.Text = "Show Caught";
            this.showCaughtButton.UseVisualStyleBackColor = false;
            this.showCaughtButton.Click += new System.EventHandler(this.showCaughtButton_Click);
            // 
            // showFavoriteButton
            // 
            this.showFavoriteButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.showFavoriteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFavoriteButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.showFavoriteButton.Location = new System.Drawing.Point(302, 141);
            this.showFavoriteButton.Name = "showFavoriteButton";
            this.showFavoriteButton.Size = new System.Drawing.Size(117, 49);
            this.showFavoriteButton.TabIndex = 2;
            this.showFavoriteButton.Text = "Show Favorite";
            this.showFavoriteButton.UseVisualStyleBackColor = false;
            this.showFavoriteButton.Click += new System.EventHandler(this.showFavoriteButton_Click);
            // 
            // closeDialog
            // 
            this.closeDialog.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.closeDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeDialog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeDialog.ForeColor = System.Drawing.Color.White;
            this.closeDialog.Location = new System.Drawing.Point(422, 0);
            this.closeDialog.Name = "closeDialog";
            this.closeDialog.Size = new System.Drawing.Size(32, 31);
            this.closeDialog.TabIndex = 19;
            this.closeDialog.Text = "X";
            this.closeDialog.UseVisualStyleBackColor = false;
            this.closeDialog.Click += new System.EventHandler(this.closeDialog_Click);
            // 
            // uncaughtListButton
            // 
            this.uncaughtListButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.uncaughtListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uncaughtListButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.uncaughtListButton.Location = new System.Drawing.Point(167, 141);
            this.uncaughtListButton.Name = "uncaughtListButton";
            this.uncaughtListButton.Size = new System.Drawing.Size(117, 49);
            this.uncaughtListButton.TabIndex = 20;
            this.uncaughtListButton.Text = "Show UnCaught";
            this.uncaughtListButton.UseVisualStyleBackColor = false;
            this.uncaughtListButton.Click += new System.EventHandler(this.uncaughtListButton_Click);
            // 
            // CustomShowButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 235);
            this.Controls.Add(this.uncaughtListButton);
            this.Controls.Add(this.closeDialog);
            this.Controls.Add(this.showFavoriteButton);
            this.Controls.Add(this.showCaughtButton);
            this.Controls.Add(this.showListLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomShowButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomShowButton";
            this.Load += new System.EventHandler(this.CustomShowButton_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label showListLabel;
        private System.Windows.Forms.Button showCaughtButton;
        private System.Windows.Forms.Button showFavoriteButton;
        private System.Windows.Forms.Button closeDialog;
        private System.Windows.Forms.Button uncaughtListButton;
    }
}