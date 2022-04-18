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
    public partial class CustomShowButton : Form
    {
        public CustomShowButton()
        {
            InitializeComponent();
        }
        Controller controller = new Controller();

        private void CustomShowButton_Load(object sender, EventArgs e)
        {

        }
        private void showCaughtButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Dashboard"] != null)
            {
                Dashboard.ListView1.Items.Clear();
                var table = controller.showList("User_Caught", FrmLogin.name);
                controller.listViewChange(table, "Pokemon", "Dashboard");
            }
            else
            {

                User_Homepage.ListView1.Items.Clear();
                var table = controller.showList("User_Caught", FrmLogin.name);
                controller.listViewChange(table, "Pokemon", "User_Homepage");

            }
            controller.clearText();
            this.Close();


        }

        private void showFavoriteButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Dashboard"] != null)
            {
                Dashboard.ListView1.Items.Clear();
                var table = controller.showList("User_Favorite", FrmLogin.name);
                controller.listViewChange(table, "Pokemon", "Dashboard");
            }
            else
            {

                User_Homepage.ListView1.Items.Clear();
                var table = controller.showList("User_Favorite", FrmLogin.name);
                controller.listViewChange(table, "Pokemon", "User_Homepage");

            }
            controller.clearText();
            this.Close();
        }

        

        private void closeDialog_Click(object sender, EventArgs e)
        {
            controller.clearText();
            this.Close();
        }

        private void uncaughtListButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Dashboard"] != null)
            {


                Dashboard.ListView1.Items.Clear();
                var table = controller.showUnCaughtList(FrmLogin.name);
                controller.listViewChange(table, "Pokemon", "Dashboard");
            }
            else
            {
                User_Homepage.ListView1.Items.Clear();
                var table = controller.showUnCaughtList(FrmLogin.name);
                controller.listViewChange(table, "Pokemon", "User_Homepage");
            }
            controller.clearText();
            this.Close();
        }
    }
}
