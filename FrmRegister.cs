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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
            TxtUsername = this.txtUsername;
            TxtPassword = this.txtPassword;
            TxtComPassword = this.txtComPassword;
            frmRegis = this;
            CkbxShowPas = this.checkbxShowPas;

        }
        //-------------------------------
        public static FrmRegister frmRegis;
        public static TextBox TxtPassword;
        public static TextBox TxtUsername;
        public static TextBox TxtComPassword;
        public static CheckBox CkbxShowPas;
        Controller controller = new Controller();
        //-------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            controller.Registration();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            controller.checkbxShowPas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.clearText();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FrmLogin.FrmLog.Show();
            this.Close();
            controller.clearText();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void exitApp_Click(object sender, EventArgs e)
        {
            FrmLogin.FrmLog.Close();
        }
    }
        
    
}
