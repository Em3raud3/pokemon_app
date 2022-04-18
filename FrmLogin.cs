using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            TxtUsername = this.txtUsername;
            TxtPassword = this.txtPassword;
            CkbxShowPas = this.CheckbxShowPas;
            FrmLog = this;
            
            
        }
        //--------------------
        public static CheckBox CkbxShowPas;
        public static TextBox TxtPassword;
        public static TextBox TxtUsername;
        public static string name = "";
        Controller controller = new Controller();
        public static FrmLogin FrmLog;
        //--------------------


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.verifyUserAndPass();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.clearText();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            controller.checkbxShowPas();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
            controller.clearText();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void exitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
