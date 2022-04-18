namespace Software_Project
{
    partial class Dashboard
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentUser = new System.Windows.Forms.Label();
            this.caughtButton = new System.Windows.Forms.Button();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.typeFilterBox = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.favoriteButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.userPageButton = new System.Windows.Forms.Button();
            this.showListButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.type1PicBx = new System.Windows.Forms.PictureBox();
            this.type2PicBx = new System.Windows.Forms.PictureBox();
            this.pokemonPic = new System.Windows.Forms.PictureBox();
            this.descLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.type1PicBx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.type2PicBx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPic)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.AliceBlue;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 376);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(767, 233);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type1";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type2";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 0;
            // 
            // currentUser
            // 
            this.currentUser.AutoSize = true;
            this.currentUser.Location = new System.Drawing.Point(625, 41);
            this.currentUser.Name = "currentUser";
            this.currentUser.Size = new System.Drawing.Size(0, 23);
            this.currentUser.TabIndex = 1;
            this.currentUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // caughtButton
            // 
            this.caughtButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.caughtButton.ForeColor = System.Drawing.Color.White;
            this.caughtButton.Location = new System.Drawing.Point(542, 408);
            this.caughtButton.Name = "caughtButton";
            this.caughtButton.Size = new System.Drawing.Size(108, 42);
            this.caughtButton.TabIndex = 2;
            this.caughtButton.Text = "Caught";
            this.caughtButton.UseVisualStyleBackColor = false;
            this.caughtButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectedLabel.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLabel.ForeColor = System.Drawing.Color.Black;
            this.selectedLabel.Location = new System.Drawing.Point(416, 76);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(0, 32);
            this.selectedLabel.TabIndex = 3;
            this.selectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // typeFilterBox
            // 
            this.typeFilterBox.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.typeFilterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeFilterBox.FormattingEnabled = true;
            this.typeFilterBox.Items.AddRange(new object[] {
            "ALL TYPES",
            "Water",
            "Fire",
            "Grass",
            "Normal",
            "Dragon",
            "Bug",
            "Dark",
            "Electric",
            "Fairy",
            "Fighting",
            "Flying",
            "Ghost",
            "Ground",
            "Ice",
            "Poison",
            "Psychic",
            "Rock",
            "Steel"});
            this.typeFilterBox.Location = new System.Drawing.Point(28, 310);
            this.typeFilterBox.Name = "typeFilterBox";
            this.typeFilterBox.Size = new System.Drawing.Size(121, 31);
            this.typeFilterBox.TabIndex = 5;
            this.typeFilterBox.SelectedIndexChanged += new System.EventHandler(this.typeFilterBox_SelectedIndexChanged);
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.AliceBlue;
            this.searchBox.Location = new System.Drawing.Point(225, 310);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(400, 30);
            this.searchBox.TabIndex = 6;
            this.searchBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // favoriteButton
            // 
            this.favoriteButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.favoriteButton.ForeColor = System.Drawing.Color.White;
            this.favoriteButton.Location = new System.Drawing.Point(656, 408);
            this.favoriteButton.Name = "favoriteButton";
            this.favoriteButton.Size = new System.Drawing.Size(108, 42);
            this.favoriteButton.TabIndex = 10;
            this.favoriteButton.Text = "Favorite";
            this.favoriteButton.UseVisualStyleBackColor = false;
            this.favoriteButton.Click += new System.EventHandler(this.favoriteButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logoutButton.ForeColor = System.Drawing.Color.White;
            this.logoutButton.Location = new System.Drawing.Point(725, 0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(93, 34);
            this.logoutButton.TabIndex = 12;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // userPageButton
            // 
            this.userPageButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.userPageButton.ForeColor = System.Drawing.Color.White;
            this.userPageButton.Location = new System.Drawing.Point(604, -4);
            this.userPageButton.Name = "userPageButton";
            this.userPageButton.Size = new System.Drawing.Size(108, 38);
            this.userPageButton.TabIndex = 13;
            this.userPageButton.Text = "User Page";
            this.userPageButton.UseVisualStyleBackColor = false;
            this.userPageButton.Click += new System.EventHandler(this.userPageButton_Click);
            // 
            // showListButton
            // 
            this.showListButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.showListButton.ForeColor = System.Drawing.Color.White;
            this.showListButton.Location = new System.Drawing.Point(656, 310);
            this.showListButton.Name = "showListButton";
            this.showListButton.Size = new System.Drawing.Size(106, 31);
            this.showListButton.TabIndex = 15;
            this.showListButton.Text = "Show List";
            this.showListButton.UseVisualStyleBackColor = false;
            this.showListButton.Click += new System.EventHandler(this.showListButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(59, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(377, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Search Bar";
            // 
            // type1PicBx
            // 
            this.type1PicBx.BackColor = System.Drawing.Color.Transparent;
            this.type1PicBx.Location = new System.Drawing.Point(422, 121);
            this.type1PicBx.Name = "type1PicBx";
            this.type1PicBx.Size = new System.Drawing.Size(83, 40);
            this.type1PicBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.type1PicBx.TabIndex = 22;
            this.type1PicBx.TabStop = false;
            this.type1PicBx.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // type2PicBx
            // 
            this.type2PicBx.BackColor = System.Drawing.Color.Transparent;
            this.type2PicBx.Location = new System.Drawing.Point(511, 121);
            this.type2PicBx.Name = "type2PicBx";
            this.type2PicBx.Size = new System.Drawing.Size(83, 40);
            this.type2PicBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.type2PicBx.TabIndex = 22;
            this.type2PicBx.TabStop = false;
            this.type2PicBx.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pokemonPic
            // 
            this.pokemonPic.BackColor = System.Drawing.Color.Transparent;
            this.pokemonPic.BackgroundImage = global::Software_Project.Properties.Resources.glow;
            this.pokemonPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pokemonPic.ErrorImage = null;
            this.pokemonPic.InitialImage = null;
            this.pokemonPic.Location = new System.Drawing.Point(225, 41);
            this.pokemonPic.Name = "pokemonPic";
            this.pokemonPic.Size = new System.Drawing.Size(181, 177);
            this.pokemonPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pokemonPic.TabIndex = 23;
            this.pokemonPic.TabStop = false;
            this.pokemonPic.Click += new System.EventHandler(this.pokemonPic_Click);
            // 
            // descLb
            // 
            this.descLb.AutoSize = true;
            this.descLb.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.descLb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.descLb.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLb.ForeColor = System.Drawing.Color.White;
            this.descLb.Location = new System.Drawing.Point(226, 211);
            this.descLb.MaximumSize = new System.Drawing.Size(399, 60);
            this.descLb.MinimumSize = new System.Drawing.Size(399, 60);
            this.descLb.Name = "descLb";
            this.descLb.Size = new System.Drawing.Size(399, 60);
            this.descLb.TabIndex = 25;
            this.descLb.Visible = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(818, 647);
            this.Controls.Add(this.descLb);
            this.Controls.Add(this.type1PicBx);
            this.Controls.Add(this.type2PicBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.showListButton);
            this.Controls.Add(this.userPageButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.favoriteButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.typeFilterBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.caughtButton);
            this.Controls.Add(this.currentUser);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pokemonPic);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.type1PicBx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.type2PicBx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label currentUser;
        private System.Windows.Forms.Button caughtButton;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox typeFilterBox;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button favoriteButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button userPageButton;
        private System.Windows.Forms.Button showListButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.PictureBox type2PicBx;
        private System.Windows.Forms.PictureBox type1PicBx;
        private System.Windows.Forms.PictureBox pokemonPic;
        private System.Windows.Forms.Label descLb;
    }
}