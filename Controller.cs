﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;


namespace Software_Project

{   
    internal class Controller
    {
        public static Model model = new Model();
        public void verifyUserAndPass() //FrmLogin calls this method to read database for User and Pass Verification
        {
            model.openController();

            string login = "SELECT * FROM tbl_users WHERE username= '" + FrmLogin.TxtUsername.Text + "' and password= '" + FrmLogin.TxtPassword.Text + "'";
            OleDbDataReader dr = model.executeReaderCommand(model.databaseCommand(login, model.getCon()));
            if ((dr.Read() == true) && (dr.GetString(0) == FrmLogin.TxtUsername.Text) && (dr.GetString(1) == FrmLogin.TxtPassword.Text)) //Checks Case Senstivity of login
            {
                //The Form which will appear after loggin in
                FrmLogin.name = FrmLogin.TxtUsername.Text;
                model.closeController();
                new Dashboard().Show();
                FrmLogin.FrmLog.Hide();
            }
            else //User and Pass were not correct
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearText(0);
                model.closeController();

            }
        }


        public void checkbxShowPas(int option) //Check Box on/off 
        {
            if (option == 0)
            {
                if (FrmLogin.CkbxShowPas.Checked)
                {
                    FrmLogin.TxtPassword.PasswordChar = '\0';
                }
                else
                {
                    FrmLogin.TxtPassword.PasswordChar = '•';
                }
            }
            else if(option == 1)
            {
                if (FrmRegister.CkbxShowPas.Checked)
                {
                    FrmRegister.TxtPassword.PasswordChar = '\0';
                    FrmRegister.TxtComPassword.PasswordChar = '\0';
                }
                else
                {
                    FrmRegister.TxtPassword.PasswordChar = '•';
                    FrmRegister.TxtComPassword.PasswordChar = '•';
                }
            }
            
        }
        

        public void clearText(int option) //Resets and Focuses Text
        {
            if (option == 0)
            {
                FrmLogin.TxtUsername.Text = "";
                FrmLogin.TxtPassword.Text = "";
                FrmLogin.TxtUsername.Focus();
            }
            else if(option == 1)
            {
                FrmRegister.TxtUsername.Text = "";
                FrmRegister.TxtPassword.Text = "";
                FrmRegister.TxtComPassword.Text = "";
                FrmRegister.TxtUsername.Focus();
            }
            else if(option == 2)
            {
                Dashboard.selectedID = "";
                Dashboard.selectedName = "";
                Dashboard.SelectedLabel.Text = Dashboard.selectedName;
                Dashboard.SelectedLabelID.Text = Dashboard.selectedID;
            }
            else if(option == 3)
            {
                Dashboard.SelectedLabel.Text = "";
                Dashboard.SelectedLabelID.Text = "";
            }
            else if(option == 4)
            {
                User_Homepage.selectedID = "";
                User_Homepage.selectedName = "";
                User_Homepage.SelectedLabel.Text = User_Homepage.selectedName;
                User_Homepage.SelectedLabelID.Text = User_Homepage.selectedID;
            }
            else if(option == 5)
            {
                User_Homepage.SelectedLabel.Text = "";
                User_Homepage.SelectedLabelID.Text = "";
            }
        }

        public void Registration()
        {
            if (FrmRegister.TxtUsername.Text == "" && FrmRegister.TxtPassword.Text == "" && FrmRegister.TxtComPassword.Text == "") //Blank Fields
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (FrmRegister.TxtPassword.Text == FrmRegister.TxtComPassword.Text) //Condition checks to see if user is Unqiue before creating
            {
                model.openController();
                string unqiueUserCheck = "SELECT * FROM tbl_users WHERE username= '" + FrmRegister.TxtUsername.Text + "'";
                if (model.executeReaderCommand(model.databaseCommand(unqiueUserCheck, model.getCon())).Read() == true)
                {
                    //User has already been created
                    MessageBox.Show("User not Unquie!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearText(1);
                    model.closeController();
                    
                }
                else  ///Creates User
                {
                    string register = "INSERT INTO tbl_users VALUES ('" + FrmRegister.TxtUsername.Text + "','" + FrmRegister.TxtPassword.Text + "')";

                    
                    model.executeNonQueryCommand(model.databaseCommand(register, model.getCon()));
                    model.closeController();
                    clearText(1);
                    MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else  //Passwords do not match
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearText(1);
            }
        }
        public void dashListViewSelectChange() //Changes selection when user interacts with display
        {
            
                if (Dashboard.ListView1.SelectedItems.Count > 0)
                {
                    Dashboard.selectedName = Dashboard.ListView1.SelectedItems[0].SubItems[1].Text;
                    Dashboard.selectedID = Dashboard.ListView1.SelectedItems[0].SubItems[0].Text;
                    Dashboard.SelectedLabel.Text = Dashboard.selectedName;
                    Dashboard.SelectedLabelID.Text = Dashboard.selectedID;
                }
                
            
        }
        public void userHomeSelectChange() //Changes selection when user interacts with display
        {


            if (User_Homepage.ListView1.SelectedItems.Count > 0)
            {
                User_Homepage.selectedName = User_Homepage.ListView1.SelectedItems[0].SubItems[1].Text;
                User_Homepage.selectedID = User_Homepage.ListView1.SelectedItems[0].SubItems[0].Text;
                User_Homepage.SelectedLabel.Text = User_Homepage.selectedName;
                User_Homepage.SelectedLabelID.Text = User_Homepage.selectedID;


            }
        }
            


        public DataTable tableSet(OleDbDataAdapter dat)  //Fills Table Data Set
        {
            var ds = new DataSet();
            dat.Fill(ds);
            DataTable table = ds.Tables[0];
            bool hasRows = table.Rows.GetEnumerator().MoveNext();
            if (hasRows)
            {
                dat.Dispose();
                model.closeController();
                return table;
            }
            dat.Dispose();
            model.closeController();
            return null;
        }
        public void listViewChange(DataTable table, string view) //Used to Update List View changes for Filter
        {
            if (table != null)
            {
                try
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var items = new string[]
                        {
                            row[0].ToString(),
                            row[1].ToString(),
                            row[2].ToString(),
                            row[3].ToString()
                        };
                        var value = new ListViewItem(items);
                        if (view == "Dashboard")
                        {
                            Dashboard.ListView1.Items.Add(value);
                        }
                        else
                        {
                            User_Homepage.ListView1.Items.Add(value);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void addPokemon(string database)
        {
            model.openController();  
            string unqiueIDCheck = "SELECT * FROM " + database + " WHERE ID= '" + Dashboard.selectedID + "' and username= '" + FrmLogin.name + "'";
            if (model.executeReaderCommand(model.databaseCommand(unqiueIDCheck, model.getCon())).Read() == true)
            {
                //Pokemon is already in list
                MessageBox.Show("Pokemon already in list!");
                clearText(3);
                model.closeController();

            }
            else  ///Places Pokemon in List
            {
                if (Dashboard.selectedID != "")
                {
                    string amountCheck = "SELECT Count(*) FROM User_Favorite WHERE username= '" + FrmLogin.name + "'";
                    if ((database == "User_Favorite") && (Convert.ToInt16(model.databaseCommand(amountCheck, model.getCon()).ExecuteScalar()) < 6))
                    {
                        insertPokemon(database);
                    }
                    else if(database == "User_Caught") insertPokemon(database);
                    
                    else
                    {
                        clearText(2);
                        model.closeController();
                        MessageBox.Show("Only 6 Pokemon can be your favorite!");
                    }
                }
                else
                {
                    model.closeController();
                    clearText(3);
                    MessageBox.Show("No Pokemon Selected!");
                }
            }
        }
        public void insertPokemon(string database)
        {
            string insertPokemon = "INSERT INTO " + database + " VALUES ('" + FrmLogin.name + "','" + Dashboard.selectedID + "')";
            model.executeNonQueryCommand(model.databaseCommand(insertPokemon, model.getCon()));
            model.closeController();
            clearText(3);
            MessageBox.Show("Pokemon has been added to list!");
        }
        public void removePokemon(string database)
        {
                model.openController();
                string unqiueIDCheck = "SELECT * FROM " + database + " WHERE ID= '" + Dashboard.selectedID + "' and username= '" + FrmLogin.name + "'";
                if (model.executeReaderCommand(model.databaseCommand(unqiueIDCheck, model.getCon())).Read() == true) //Pokemon is in list
                {
                    string deletePokemon = "DELETE FROM " + database + " WHERE ID= '" + Dashboard.selectedID + "' and username= '" + FrmLogin.name + "'";
                    model.executeNonQueryCommand(model.databaseCommand(deletePokemon, model.getCon()));
                    model.closeController();
                    clearText(3);
                    MessageBox.Show("Pokemon has been removed from list!");
                }

                else  ///Pokemon not in list
                {
                    MessageBox.Show("Pokemon not in caught list");
                    clearText(3);
                    model.closeController();
                }
                
        }
        public DataTable pokemonSearch(string keyword) //Searches Pokemon by string keyword
        {
            try
            {
                model.openController();
                return tableSet(model.databaseAdapter("select * from Pokemon where Name like '%" + keyword + "%'", model.getCon()));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable pokemonTypeFilter(string type) //Filters the List view by type filter
        {
            try
            {
                model.openController();
                if (type == "Water" || type == "Fire" || type == "Grass")
                {
                    return tableSet(model.databaseAdapter("select * from Pokemon where type1='" + type + "' or type2= '" + type + "'", model.getCon()));
                }
                else
                {
                    return tableSet(model.databaseAdapter("select * from Pokemon", model.getCon()));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable showList(string database)
        {
            model.openController();
            DataTable table = tableSet(model.databaseAdapter("SELECT Pokemon.ID, Pokemon.name, Pokemon.Type1, Pokemon.Type2 FROM Pokemon, " +
                database +" WHERE Pokemon.ID = " + database + ".ID AND " + database + ".username = '" + FrmLogin.name + "'", model.getCon()));
            return table;

        }
        public DataTable showUnCaughtList() //In Progress
        {

            model.openController();
            //dat = new OleDbDataAdapter("SELECT Pokemon.ID, Pokemon.name, Pokemon.Type1, Pokemon.Type2 FROM Pokemon, " +
            //    "User_Caught WHERE Pokemon.ID = User_Caught.ID AND User_Caught.username <> '" + frmLogin.name + "'", con);
            DataTable table = tableSet(model.databaseAdapter("SELECT * FROM Pokemon left outer join User_Caught on Pokemon.ID = User_Caught.ID WHERE User_Caught.ID is NULL", model.getCon()));
            return table;
        }
    }
}
