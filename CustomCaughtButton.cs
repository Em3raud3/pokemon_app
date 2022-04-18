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
    public partial class CustomCaughtButton : Form
    {
        public CustomCaughtButton()
        {
            InitializeComponent();
        }
        Controller controller = new Controller();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Add Button
        {
            controller.addPokemon("User_Caught");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //Remove Button
        {
            controller.removePokemon("User_Caught");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) //Cancel Button
        {
            this.Close();
        }

        private void CustomCaughtButton_Load(object sender, EventArgs e)
        {

        }
    }
}
