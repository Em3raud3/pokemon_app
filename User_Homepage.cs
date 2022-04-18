using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project
{
    public partial class User_Homepage : Form
    {
        public User_Homepage()
        {
            InitializeComponent();
            ListView1 = this.listView1;
            SelectedLabel = this.selectedPokemon;
            SelectedLabelID = this.selectedPokemonID;
            AdminButton = this.adminButton;
            controller.adminVerify();
        }
        //----------------
        public static ListView ListView1;
        public static CustomCaughtButton cusCaughtButton = new CustomCaughtButton();
        public static CustomFavoriteButton cusFavoriteButton = new CustomFavoriteButton();
        public static CustomShowButton cusShowButton = new CustomShowButton();
        public static AdminFrm ADMINFrm = new AdminFrm();
        public static Label SelectedLabelID;
        public static Label SelectedLabel;
        public static Button AdminButton;
        Controller controller = new Controller();
        //----------------
        private void User_Homepage_Load(object sender, EventArgs e)
        {
            var table = controller.showList("User_Favorite", FrmLogin.name);
            controller.listViewChange(table, "Pokemon", "User_Homepage");

        }
        private void favoriteButton_Click(object sender, EventArgs e)
        {
            cusFavoriteButton.ShowDialog();
        }

        private void showCaughtList_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var table = controller.showList("User_Caught", FrmLogin.name);
            controller.listViewChange(table, "Pokemon", "User_Caught");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            controller.listViewSelectChange();

            
        }

        private void searchPageButton_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            listView1.Items.Clear();
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + "1.png";
        }

        private void showListButton_Click(object sender, EventArgs e)
        {
            cusShowButton.ShowDialog();
        }
        private void logoutButton_Click_1(object sender, EventArgs e)
        {
            FrmLogin.FrmLog.Show();
            listView1.Items.Clear();
            this.Close();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            ADMINFrm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            

        }
    }
}
