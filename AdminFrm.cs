using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Software_Project
{
    public partial class AdminFrm : Form
    {
        public AdminFrm()
        {
            InitializeComponent();
            AdminListView = this.adminListView1;
            AdminTextBox = this.adminTextBox1;
            DatabaseLabel = this.databaseLabel;
        }
        public static ListView AdminListView;
        public static Label DatabaseLabel;
        public static string adminRequest = "";
        public static TextBox AdminTextBox;
        public static string[] words = { };
        public static string databaseName = "";
        public static string subdataName = "";
        public static string currentKey = "";
        public static string currentKey2 = "";
        Model model = new Model();
        Controller controller = new Controller();

        private void AdminFrm_Load(object sender, EventArgs e)
        {
            databaseName = "tbl_users";
            databaseLabel.Text = databaseName;
            var table = controller.showList("tbl_users");
            controller.listViewChange(table, "User", "AdminFrm");
        }

        private void adminTextBox1_TextChanged(object sender, EventArgs e)
        {
            adminRequest = adminTextBox1.Text;
            words = Regex.Split(adminRequest, @"\s+");
            int last = words.Length;
            if (words[last-1].Equals("")) Array.Resize(ref words, last-1);

        }
        
        
        private void createButton_Click(object sender, EventArgs e)
        {
            controller.createButtonDriver();
        }
        private void closeDialog_Click(object sender, EventArgs e)
        {
            adminListView1.Items.Clear();
            this.Close();
        }
        

        private void updateButton_Click(object sender, EventArgs e)
        {
            controller.updateButtonDriver();
        }
        private void readButton_Click(object sender, EventArgs e)
        {

            controller.readDB();
        }

        private void adminListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.listViewSelectChange();

        }

        private void adminListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            controller.subDatabase();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            controller.deleteInDatbase();
        }
    }
}
