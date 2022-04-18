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
    public partial class CustomFavoriteButton : Form
    {
        public CustomFavoriteButton()
        {
            InitializeComponent();
        }
        Controller controller = new Controller();
        private void CustomFavoriteButton_Load(object sender, EventArgs e)
        {
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            controller.addPokemon("User_Favorite");
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            controller.removePokemon("User_Favorite");
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
