using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Media;


namespace Software_Project

{
    internal class Controller
    {
        public static string selectedName; //Selected Pokemon's name is saved stored
        public static string selectedID; //Selected Pokemon's ID is stored
        SoundPlayer sound = new SoundPlayer();
        public static Model model = new Model();


        public void adminVerify()
        {
            if (FrmLogin.name == "admin") User_Homepage.AdminButton.Visible = true;
        }
        //---------Login & Registration
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
                clearText();
                new Dashboard().Show();
                FrmLogin.FrmLog.Hide();
            }
            else //User and Pass were not correct
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearText();
                model.closeController();

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
                    clearText();
                    model.closeController();

                }
                else if (FrmRegister.TxtUsername.Text.ToUpper() == "UPDATE" || FrmRegister.TxtUsername.Text.ToUpper() == "DELETE")
                {
                    //Key word names
                    MessageBox.Show("Not Allowed Username!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearText();
                    model.closeController();
                }
                else  ///Creates User
                {
                    string register = "INSERT INTO tbl_users VALUES ('" + FrmRegister.TxtUsername.Text + "','" + FrmRegister.TxtPassword.Text + "')";


                    model.executeNonQueryCommand(model.databaseCommand(register, model.getCon()));
                    model.closeController();
                    clearText();
                    MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else  //Passwords do not match
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearText();
            }
        }
        public void checkbxShowPas() //Check Box on/off 
        {
            if (Application.OpenForms["FrmRegister"] != null)
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
            else
            {
                if (FrmLogin.CkbxShowPas.Checked) FrmLogin.TxtPassword.PasswordChar = '\0';
                else FrmLogin.TxtPassword.PasswordChar = '•';
            }
        }
        //----------------------
        public void clearText() //Resets and Focuses Text
        {
            if (Application.OpenForms["FrmRegister"] != null)
            {
                FrmRegister.TxtUsername.Text = "";
                FrmRegister.TxtPassword.Text = "";
                FrmRegister.TxtComPassword.Text = "";
                FrmRegister.TxtUsername.Focus();
            }
            else if (Application.OpenForms["Dashboard"] != null)
            {
                Dashboard.SelectedLabel.Text = "";
                Dashboard.DescLabel.Text = "";
                Dashboard.DescLabel.Visible = false;

            }
            else if (Application.OpenForms["User_Homepage"] != null)
            {
                User_Homepage.SelectedLabel.Text = "";
                User_Homepage.SelectedLabelID.Text = "";

            }
            else
            {
                FrmLogin.TxtUsername.Text = "";
                FrmLogin.TxtPassword.Text = "";
                FrmLogin.TxtUsername.Focus();
            }
            selectedName = "";
            selectedID = "";
        }
        //------------Show List Methods
        public DataTable nameSearch(string keyword) //Searches Name by string keyword
        {
            try
            {
                model.openController();
                return tableSet(model.databaseAdapter("select * from tbl_users where username like '" + keyword + "%'", model.getCon()));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable showList(string database)
        {
            model.openController();
            if (database.ToUpper() != "UNCAUGHT")
            {
                DataTable table = tableSet(model.databaseAdapter("SELECT * FROM " + database + "", model.getCon()));
                return table;
            }
            else
            {
                DataTable table = tableSet(model.databaseAdapter("SELECT * FROM Pokemon left outer join User_Caught " +
               "on (Pokemon.ID = User_Caught.ID) WHERE User_Caught.ID is NULL", model.getCon()));
                return table;
            }
        }
        public DataTable showList(string database, string user)
        {
            model.openController();
            if (database != "tbl_users")
            {
                DataTable table = tableSet(model.databaseAdapter("SELECT Pokemon.ID, Pokemon.name, Pokemon.Type1, Pokemon.Type2, Pokemon.Desc FROM Pokemon, " +
                    database + " WHERE Pokemon.ID = " + database + ".ID AND " + database + ".username = '" + user + "'", model.getCon()));
                return table;
            }
            else
            {
                DataTable table = tableSet(model.databaseAdapter("SELECT * FROM " + database + " WHERE username like '%" + user + "%'", model.getCon()));
                return table;
            }

        }
        public DataTable showUnCaughtList(string name)
        {
            model.openController();
            DataTable table = tableSet(model.databaseAdapter("SELECT * FROM Pokemon left outer join User_Caught " +
                "on (Pokemon.ID = User_Caught.ID and username = '" + name + "') WHERE User_Caught.ID is NULL"
                , model.getCon()));
            return table;
        }
        //----------------

        //------List View Methods
        public void listViewColumnLock(ColumnWidthChangingEventArgs e)
        {
            if (Dashboard.ListView1.Columns[e.ColumnIndex].ToString() == "ColumnHeader: Text: ")
            {
                e.Cancel = true;
                e.NewWidth = Dashboard.ListView1.Columns[e.ColumnIndex].Width;
            }
        }

        public void listViewSelectChange() //Changes selection when user interacts with display
        {
            sound.Stop();
            if (Application.OpenForms["Dashboard"] != null)
            {
                if (Dashboard.ListView1.SelectedItems.Count > 0)
                {
                    selectedName = Dashboard.ListView1.SelectedItems[0].SubItems[1].Text;
                    selectedID = Dashboard.ListView1.SelectedItems[0].SubItems[0].Text;
                    Dashboard.DescLabel.Text = Dashboard.ListView1.SelectedItems[0].SubItems[4].Text;
                    Dashboard.SelectedLabel.Text = "No." + selectedID + " " + selectedName;
                    Dashboard.DescLabel.Visible = true;
                    imageTypeUpdate();
                    playPokemonCry();
                }
            }
            else if (Application.OpenForms["AdminFrm"] != null)
            {
                if (AdminFrm.AdminListView.SelectedItems.Count > 0)
                {
                    if (AdminFrm.subdataName != "Pokemon") //Used to determine which database and keys are in use
                    {
                        AdminFrm.currentKey = AdminFrm.AdminListView.SelectedItems[0].SubItems[0].Text;
                        AdminFrm.currentKey2 = AdminFrm.AdminListView.SelectedItems[0].SubItems[1].Text;
                    }
                    else
                    {
                        AdminFrm.currentKey2 = AdminFrm.AdminListView.SelectedItems[0].SubItems[0].Text;
                    }
                }

            }
            else if (Application.OpenForms["User_Homepage"] != null)
            {
                if (User_Homepage.ListView1.SelectedItems.Count > 0)
                {
                    selectedID = User_Homepage.ListView1.SelectedItems[0].SubItems[0].Text; //Pokemon ID
                    selectedName = User_Homepage.ListView1.SelectedItems[0].SubItems[1].Text; //Pokemon Name
                    User_Homepage.SelectedLabel.Text = selectedName;
                    User_Homepage.SelectedLabelID.Text = selectedID;
                }

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
        public void listViewChange(DataTable table, string view, string form) //Used to Update List View changes
        {
            if (table != null)
            {
                try
                {
                    if (view == "Pokemon")
                    {

                        foreach (DataRow row in table.Rows)
                        {
                            var items = new string[]
                            {
                            row[0].ToString(),
                            row[1].ToString(),
                            row[2].ToString(),
                            row[3].ToString(),
                            row[4].ToString()
                            };
                            var value = new ListViewItem(items);
                            if (form == "Dashboard") Dashboard.ListView1.Items.Add(value);
                            else if (form == "User_Homepage") User_Homepage.ListView1.Items.Add(value);
                            else AdminFrm.AdminListView.Items.Add(value);
                        }
                    }
                    else
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            var items = new string[]
                            {
                            row[0].ToString(),
                            row[1].ToString()
                            };
                            var value = new ListViewItem(items);
                            if (form == "AdminFrm") AdminFrm.AdminListView.Items.Add(value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //-------

        //---Pokemon Methods
        public void addPokemon(string database) //Adds Pokemon into a database
        {
            model.openController();
            string unqiueIDCheck = "SELECT * FROM " + database + " WHERE ID= '" + selectedID + "' and username= '" + FrmLogin.name + "'";
            if (model.executeReaderCommand(model.databaseCommand(unqiueIDCheck, model.getCon())).Read() == true)
            {
                //Pokemon is already in list
                MessageBox.Show("Pokemon already in list!");
                model.closeController();

            }
            else  ///Places Pokemon in List
            {
                if (selectedID != "")
                {
                    string amountCheck = "SELECT Count(*) FROM User_Favorite WHERE username= '" + FrmLogin.name + "'";
                    if ((database == "User_Favorite") && (Convert.ToInt16(model.databaseCommand(amountCheck, model.getCon()).ExecuteScalar()) < 6))
                    {
                        insertPokemon(database);
                    }
                    else if (database == "User_Caught") insertPokemon(database);

                    else
                    {
                        model.closeController();
                        MessageBox.Show("Only 6 Pokemon can be your favorite!");
                    }
                }
                else
                {
                    model.closeController();
                    MessageBox.Show("No Pokemon Selected!");
                }
            }
        }
        public void insertPokemon(string database) //Inserts Pokemon into a specific database (Used along side AddPokemon() )
        {
            string insertPokemon = "INSERT INTO " + database + " VALUES ('" + FrmLogin.name + "','" + selectedID + "')";
            model.executeNonQueryCommand(model.databaseCommand(insertPokemon, model.getCon()));
            model.closeController();
            MessageBox.Show("Pokemon has been added to list!");
        }
        public void removePokemon(string database) //Remove Pokemon from a database
        {
            model.openController();
            string unqiueIDCheck = "SELECT * FROM " + database + " WHERE ID= '" + selectedID + "' and username= '" + FrmLogin.name + "'";
            if (model.executeReaderCommand(model.databaseCommand(unqiueIDCheck, model.getCon())).Read() == true) //Pokemon is in list
            {
                string deletePokemon = "DELETE FROM " + database + " WHERE ID= '" + selectedID + "' and username= '" + FrmLogin.name + "'";
                model.executeNonQueryCommand(model.databaseCommand(deletePokemon, model.getCon()));
                model.closeController();
                MessageBox.Show("Pokemon has been removed from list!");
            }

            else  ///Pokemon not in list
            {
                MessageBox.Show("Pokemon not in list!");
                model.closeController();
            }

        }
        public DataTable pokemonSearch(string keyword) //Searches Pokemon by string keyword
        {
            try
            {
                model.openController();
                return tableSet(model.databaseAdapter("select * from Pokemon where Name like '" + keyword + "%'", model.getCon()));
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
                if (type == "Water" || type == "Fire" || type == "Grass" || type == "Bug" ||
                    type == "Dark" || type == "Dragon" || type == "Electric" || type == "Fairy"
                    || type == "Fighting" || type == "Flying" || type == "Ghost" || type == "Ground"
                    || type == "Ice" || type == "Normal" || type == "Poison" || type == "Psychic"
                    || type == "Rock" || type == "Steel")
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


        public void imageTypeUpdate() //Updates Type and Pokemon Images
        {
            String[] types = new string[2];
            string type1 = Dashboard.ListView1.SelectedItems[0].SubItems[2].Text;
            string type2 = Dashboard.ListView1.SelectedItems[0].SubItems[3].Text;
            types[0] = type1.ToUpper();
            types[1] = type2.ToUpper();
            Dashboard.PokemonPic.ImageLocation = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + selectedID + ".png";
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] == "WATER")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.waterType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.waterType;
                }
                else if (types[i] == "FIRE")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.fireType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.fireType;
                }
                else if (types[i] == "GRASS")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.grassType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.grassType;
                }
                else if (types[i] == "FLYING")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.flyingType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.flyingType;
                }
                else if (types[i] == "POISON")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.poisonType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.poisonType;
                }
                else if (types[i] == "STEEL")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.steelType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.steelType;
                }
                else if (types[i] == "BUG")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.bugType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.bugType;
                }
                else if (types[i] == "DARK")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.darkType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.darkType;
                }
                else if (types[i] == "ELECTRIC")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.electricType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.electricType;
                }
                else if (types[i] == "DRAGON")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.dragonType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.dragonType;
                }
                else if (types[i] == "FAIRY")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.fairyType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.fairyType;
                }
                else if (types[i] == "FIGHTING")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.fightingType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.fightingType;
                }
                else if (types[i] == "GHOST")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.ghostType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.ghostType;
                }
                else if (types[i] == "GROUND")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.groundType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.groundType;
                }
                else if (types[i] == "ICE")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.iceType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.iceType;
                }
                else if (types[i] == "NORMAL")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.normal;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.normal;
                }
                else if (types[i] == "PSYCHIC")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.psychicType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.psychicType;
                }
                else if (types[i] == "ROCK")
                {
                    if (i == 0) Dashboard.Type1PicBx.Image = Software_Project.Properties.Resources.rockType;
                    else Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.rockType;
                }
                else
                {
                    Dashboard.Type2PicBx.Image = Software_Project.Properties.Resources.Type;
                }

            }

        }

        public void playPokemonCry()
        {
            try
            {
                sound.Stop();
                sound = new SoundPlayer(selectedID + ".wav");
                sound.Play();
            }
            catch (Exception ex) { }
        }
        //----------------------------------------
        public void createFieldInList()
        {
            model.openController();
            string check = "";
            string check2 = "";
            if (AdminFrm.words.Length != 2 || int.TryParse(AdminFrm.words[1], out int i) == false)
            {
                MessageBox.Show("Not in correct format!");
                AdminFrm.AdminTextBox.Text = "";
                AdminFrm.adminRequest = "";
                AdminFrm.currentKey = "";
                AdminFrm.currentKey2 = "";
                model.closeController();
                return;
            }
            else
            {
                check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE username= '" + AdminFrm.words[0] + "' AND ID= '" +
                  AdminFrm.words[1] + "'"; //checks to see if value exists in either favorite or caught list
                check2 = "SELECT * FROM tbl_users WHERE username= '" + AdminFrm.words[0] + "'"; //checks to see if user exists in tbl_users
            }
            if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == false &&
                    model.executeReaderCommand(model.databaseCommand(check2, model.getCon())).Read() == true)
            //Makes sure the update isnt a duplicate
            {
                DialogResult dr = MessageBox.Show("Are you sure?",
                "YOU ARE ABOUT TO UPDATE!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string update = "INSERT INTO " + AdminFrm.databaseName + " VALUES ('" + AdminFrm.words[0] + "','" + AdminFrm.words[1] + "')";
                    model.executeNonQueryCommand(model.databaseCommand(update, model.getCon()));
                    MessageBox.Show("Successfully Updated!");
                    AdminFrm.currentKey = "";
                    AdminFrm.currentKey2 = "";
                }
            }
            else
            {
                MessageBox.Show("Either Already in list or User doesn't exist!");
            }
            model.closeController();
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";
        }
        public void createPokemon()
        {
            model.openController();
            string check = "";
            if (AdminFrm.words.Length < 3 || int.TryParse(AdminFrm.words[0], out int i) == false || stringToType(AdminFrm.words[2]) == false)
            {
                MessageBox.Show("Not in correct format!");
                AdminFrm.AdminTextBox.Text = "";
                AdminFrm.adminRequest = "";
                AdminFrm.currentKey = "";
                AdminFrm.currentKey2 = "";
                model.closeController();
                return;
            }
            else check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE ID= '" + AdminFrm.words[0] + "'";
            if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == false ||
                AdminFrm.words[0] == AdminFrm.currentKey) //Makes sure the update isnt a duplicate
            {

                string create = "";
                try
                {
                    AdminFrm.words[2] = firstCharUpper(AdminFrm.words[2]);
                    if (AdminFrm.words.Length == 4 && stringToType(AdminFrm.words[3]) == true)
                    {
                        AdminFrm.words[3] = firstCharUpper(AdminFrm.words[3]);
                    }
                    if (AdminFrm.words.Length > 5)
                    {
                        for (int x = 5; x < AdminFrm.words.Length; x++)
                        {
                            AdminFrm.words[4] = AdminFrm.words[4] + " " + AdminFrm.words[x];
                        }

                    }
                    if (AdminFrm.words.Length <= 4)
                    {
                        if (AdminFrm.words.Length == 3)
                        {
                            Array.Resize(ref AdminFrm.words, AdminFrm.words.Length + 1);
                            AdminFrm.words[3] = "";
                        }
                        if (AdminFrm.words.Length == 4 && AdminFrm.words[3].ToUpper() == "NULL")
                        {
                            AdminFrm.words[3] = "";
                        }

                        create = "INSERT INTO Pokemon (ID, Name, Type1, Type2) VALUES ('" + AdminFrm.words[0] + "','" + AdminFrm.words[1] + "','" + 
                            AdminFrm.words[2] + "','" + AdminFrm.words[3] + "')";
                    }
                    else
                    {
                        if (AdminFrm.words[3].ToUpper() == "NULL") AdminFrm.words[3] = "";
                        create = "INSERT INTO Pokemon (ID, Name, Type1, Type2) VALUES ('" + AdminFrm.words[0] + "','" + AdminFrm.words[1] + "','" + AdminFrm.words[2] + "','" + AdminFrm.words[3] + "')";
                        model.executeNonQueryCommand(model.databaseCommand(create, model.getCon()));
                        create = "update Pokemon set ID='" + AdminFrm.words[0] + "', Pokemon.Name='" + AdminFrm.words[1] +
                                    "', Pokemon.Type1='" + AdminFrm.words[2] + "', Pokemon.Type2='" + AdminFrm.words[3] + "', Pokemon.Desc='" +
                                    AdminFrm.words[4] + "' WHERE ID= '" + AdminFrm.words[0] + "'";
                    }
                    model.executeNonQueryCommand(model.databaseCommand(create, model.getCon()));
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error");
                    model.closeController();
                    AdminFrm.currentKey = "";
                    AdminFrm.currentKey2 = "";
                    return;
                }
                MessageBox.Show("Successfully Added!");
                AdminFrm.currentKey = "";
                AdminFrm.currentKey2 = "";
            }
            else MessageBox.Show("Already in List");
            model.closeController();
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";

        }
        public void createUser()
        {
            model.openController();
            string check = "";
            if (AdminFrm.words.Length != 3 || AdminFrm.words[1] != AdminFrm.words[2]) //checks User format makes sure length is 2 and password matches confirm pass
            {
                MessageBox.Show("Not in correct format!");
                AdminFrm.AdminTextBox.Text = "";
                AdminFrm.adminRequest = "";
                AdminFrm.currentKey = "";
                AdminFrm.currentKey2 = "";
                model.closeController();
                return;
            }
            else check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE username= '" + AdminFrm.words[0] + "'";
            if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == false)
            //Makes sure the new user isnt a duplicate
            {
                string register = "INSERT INTO tbl_users VALUES ('" + AdminFrm.words[0] + "','" + AdminFrm.words[1] + "')";
                model.executeNonQueryCommand(model.databaseCommand(register, model.getCon()));
                model.closeController();
                MessageBox.Show("Your Account has been Successfully Created", "Registration Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //User has already been created
                MessageBox.Show("User not Unquie!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                model.closeController();
            }
            model.closeController();
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";
        }

        private bool stringToType(string type)
        {
            string[] types = {"WATER", "FIRE", "GRASS", "ELECTRIC", "FLYING",
                "POISON", "STEEL", "BUG", "DARK", "DRAGON", "FAIRY", "FIGHTING",
                "GHOST", "GROUND", "ICE", "NORMAL", "PSYCHIC", "ROCK", "NULL"};
            foreach (string n in types)
            {
                if (type.ToUpper() == n)
                {
                    return true;
                }
            }
            return false;
        }
        private string firstCharUpper(string word)
        {
            word = word.ToLower();
            word = char.ToUpper(word[0]) + word.Substring(1);
            return word;
        }

        public void updateUser()
        {
            if (AdminFrm.AdminListView.SelectedItems.Count > 0 && AdminFrm.databaseName != "")
            {
                model.openController();
                string check = "";
                if (AdminFrm.words.Length != 2) //checks User format makes sure length is 2
                {
                    MessageBox.Show("Not in correct format!");
                    AdminFrm.currentKey = "";
                    AdminFrm.currentKey2 = "";
                    AdminFrm.AdminTextBox.Text = "";
                    AdminFrm.adminRequest = "";
                    model.closeController();
                    return;
                }
                else check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE username= '" + AdminFrm.words[0] + "'";
                if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == false ||
                    AdminFrm.words[0] == AdminFrm.currentKey) //Makes sure the update isnt a duplicate
                {
                    DialogResult dr = MessageBox.Show("Are you sure?",
                    "YOU ARE ABOUT TO UPDATE!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {

                        string update = "update tbl_users set username='" + AdminFrm.words[0] + "', tbl_users.password='" + AdminFrm.words[1]
                                 + "' WHERE username= '" + AdminFrm.currentKey + "'";

                        model.executeNonQueryCommand(model.databaseCommand(update, model.getCon()));
                        MessageBox.Show("Successfully Updated!");
                        AdminFrm.currentKey = "";
                        AdminFrm.currentKey2 = "";
                    }
                }
                else
                {
                    MessageBox.Show("Already in List");
                    AdminFrm.currentKey = "";
                    AdminFrm.currentKey2 = "";
                }
                model.closeController();
            }
            else MessageBox.Show("Nothing selected to update!");
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";
        }

        public void updatePokemon()
        {
            if (AdminFrm.AdminListView.SelectedItems.Count > 0 && AdminFrm.databaseName != "")
            {
                model.openController();
                string check = "";
                if (AdminFrm.words.Length < 3 || int.TryParse(AdminFrm.words[0], out int i) == false || AdminFrm.words.Length < 3 || 
                    stringToType(AdminFrm.words[2]) == false)
                {
                    MessageBox.Show("Not in correct format!");
                    AdminFrm.currentKey = "";
                    AdminFrm.currentKey2 = "";
                    AdminFrm.AdminTextBox.Text = "";
                    AdminFrm.adminRequest = "";
                    model.closeController();
                    return;
                }
                else check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE ID= '" + AdminFrm.words[0] + "'";
                if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == false ||
                    AdminFrm.words[0] == AdminFrm.currentKey) //Makes sure the update isnt a duplicate
                {
                    DialogResult dr = MessageBox.Show("Are you sure?",
                    "YOU ARE ABOUT TO UPDATE!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        string update = "";
                        try
                        {
                            AdminFrm.words[2] = firstCharUpper(AdminFrm.words[2]);
                            if (AdminFrm.words.Length == 4 && stringToType(AdminFrm.words[3]) == true)
                            {
                                AdminFrm.words[3] = firstCharUpper(AdminFrm.words[3]);
                            }
                            if (AdminFrm.words.Length > 5)
                            {
                                for (int x = 5; x < AdminFrm.words.Length; x++)
                                {
                                    AdminFrm.words[4] = AdminFrm.words[4] + " " + AdminFrm.words[x];
                                }
                            }
                            if (AdminFrm.words.Length <= 4)
                            {

                                if (AdminFrm.words.Length == 3)
                                {
                                    Array.Resize(ref AdminFrm.words, AdminFrm.words.Length + 1);
                                    AdminFrm.words[3] = "";

                                }
                                if (AdminFrm.words.Length == 4 && AdminFrm.words[3].ToUpper() == "NULL")
                                {
                                    AdminFrm.words[3] = "";
                                }

                                update = "update Pokemon set ID='" + AdminFrm.words[0] + "', Pokemon.Name='" + AdminFrm.words[1] +
                                        "', Pokemon.Type1='" + AdminFrm.words[2] + "', Pokemon.Type2='" + AdminFrm.words[3] + "' WHERE ID= '"
                                        + AdminFrm.currentKey + "'";
                            }
                            else
                            {
                                if (AdminFrm.words[3].ToUpper() == "NULL") AdminFrm.words[3] = "";
                                update = "update Pokemon set ID='" + AdminFrm.words[0] + "', Pokemon.Name='" + AdminFrm.words[1] +
                                        "', Pokemon.Type1='" + AdminFrm.words[2] + "', Pokemon.Type2='" + AdminFrm.words[3] + "', Pokemon.Desc='" +
                                        AdminFrm.words[4] + "' WHERE ID= '" + AdminFrm.currentKey + "'";
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error");
                            AdminFrm.currentKey = "";
                            AdminFrm.currentKey2 = "";
                            model.closeController();
                            return;
                        }
                        model.executeNonQueryCommand(model.databaseCommand(update, model.getCon()));
                        MessageBox.Show("Successfully Updated!");
                        AdminFrm.currentKey = "";
                        AdminFrm.currentKey2 = "";
                    }
                }
                else MessageBox.Show("Already in List");
                model.closeController();
            }
            else MessageBox.Show("Nothing selected to update!");
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";
        }
        public void updateUserLists()
        {
            if (AdminFrm.AdminListView.SelectedItems.Count > 0 && AdminFrm.databaseName != "")
            {
                model.openController();
                string check = "";
                string check2 = "";
                if (AdminFrm.words.Length != 2 || int.TryParse(AdminFrm.words[1], out int i) == false)
                {
                    MessageBox.Show("Not in correct format!");
                    model.closeController();
                    AdminFrm.currentKey = "";
                    AdminFrm.currentKey2 = "";
                    AdminFrm.AdminTextBox.Text = "";
                    AdminFrm.adminRequest = "";
                    return;
                }
                else
                {
                    check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE username= '" + AdminFrm.words[0] + "' AND ID= '" +
                      AdminFrm.words[1] + "'"; //checks to see if value exists in either favorite or caught list
                    check2 = "SELECT * FROM tbl_users WHERE username= '" + AdminFrm.words[0] + "'"; //checks to see if user exists in tbl_users
                }
                if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == false &&
                    model.executeReaderCommand(model.databaseCommand(check2, model.getCon())).Read() == true)
                //Makes sure the update isnt a duplicate
                {
                    DialogResult dr = MessageBox.Show("Are you sure?",
                    "YOU ARE ABOUT TO UPDATE!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        string delete = "DELETE FROM " + AdminFrm.databaseName + " WHERE username= '" + AdminFrm.currentKey + "' AND ID= '" + AdminFrm.currentKey2 + "'";
                        model.executeNonQueryCommand(model.databaseCommand(delete, model.getCon()));
                        string update = "INSERT INTO " + AdminFrm.databaseName + " VALUES ('" + AdminFrm.words[0] + "','" + AdminFrm.words[1] + "')";
                        model.executeNonQueryCommand(model.databaseCommand(update, model.getCon()));
                        MessageBox.Show("Successfully Updated!");
                        AdminFrm.currentKey = "";
                        AdminFrm.currentKey2 = "";
                    }
                }
                else
                {
                    MessageBox.Show("Either Already in list or User doesn't exist!");
                }
                model.closeController();
            }
            else MessageBox.Show("Nothing selected to update!");
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";
        }
        public void deleteInDatbase()
        {

            if (AdminFrm.AdminListView.SelectedItems.Count > 0 && AdminFrm.databaseName != "")
            {
                model.openController();
                string check = "";
                string deleteUser = "";
                string primaryHeaderKey = "username";
                if (AdminFrm.databaseName == "Pokemon") primaryHeaderKey = "ID";

                if (AdminFrm.databaseName != "User_Caught" && AdminFrm.databaseName != "User_Favorite") check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE " +
                        primaryHeaderKey + "= '" + AdminFrm.currentKey + "'";
                else check = "SELECT * FROM " + AdminFrm.databaseName + " WHERE " + primaryHeaderKey + "= '" + AdminFrm.currentKey + "' AND ID= '" + AdminFrm.currentKey2 + "'";

                if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == true) //Is in list
                {
                    DialogResult dr = MessageBox.Show("Are you sure?",
                      "YOU ARE ABOUT TO DELETE!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (AdminFrm.databaseName == "tbl_users")
                        {
                            deleteUser = "DELETE FROM tbl_users WHERE username= '" + AdminFrm.currentKey + "'";
                            check = "SELECT * FROM User_Favorite where username= '" + AdminFrm.currentKey + "'";
                            if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == true)
                            {
                                String deleteUserInfo = "DELETE FROM User_Favorite where username= '" + AdminFrm.currentKey + "'";
                                model.executeNonQueryCommand(model.databaseCommand(deleteUserInfo, model.getCon()));
                            }
                            check = "SELECT * FROM User_Caught where username= '" + AdminFrm.currentKey + "'";
                            if (model.executeReaderCommand(model.databaseCommand(check, model.getCon())).Read() == true)
                            {
                                String deleteUserInfo = "DELETE FROM User_Caught where username= '" + AdminFrm.currentKey + "'";
                                model.executeNonQueryCommand(model.databaseCommand(deleteUserInfo, model.getCon()));
                            }
                        }
                        else if (AdminFrm.databaseName == "Pokemon") deleteUser = "DELETE FROM Pokemon WHERE ID= '" + AdminFrm.currentKey + "'";

                        else deleteUser = "DELETE FROM " + AdminFrm.databaseName + " WHERE " + primaryHeaderKey + "= '" + AdminFrm.currentKey + "' AND ID= '" + AdminFrm.currentKey2 + "'";

                        model.executeNonQueryCommand(model.databaseCommand(deleteUser, model.getCon()));
                        MessageBox.Show("Removed from list!");
                        AdminFrm.currentKey = "";
                        AdminFrm.currentKey2 = "";
                    }
                }
                else MessageBox.Show("Not in list");
                model.closeController();
            }
            else MessageBox.Show("Nothing Selected!");
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";

        }
        public void readDB()
        {
            AdminFrm.AdminListView.Items.Clear();
            AdminFrm.AdminListView.Columns.Clear();
            if (AdminFrm.words.Length >= 1 && AdminFrm.words[0].ToUpper() == "USER")
            {
                AdminFrm.AdminListView.Columns.Add("Username");
                AdminFrm.AdminListView.Columns.Add("Password");
                AdminFrm.databaseName = "tbl_users";
                AdminFrm.DatabaseLabel.Text = AdminFrm.databaseName;
                if (AdminFrm.words.Length == 2)   // Name Search
                {
                    var table = nameSearch(AdminFrm.words[1]);
                    listViewChange(table, "User", "AdminFrm");
                }
                else  // All users 
                {
                    var table = showList("tbl_users");
                    listViewChange(table, "User", "AdminFrm");
                }

            }
            //--------------------
            else if (AdminFrm.words.Length >= 1 && AdminFrm.words[0].ToUpper() == "POKEMON")
            {
                adminListViewAddPokemonInfo();
                AdminFrm.databaseName = "Pokemon";
                AdminFrm.DatabaseLabel.Text = AdminFrm.databaseName;
                if (AdminFrm.words.Length == 2)  // Pokemon Search
                {
                    var table = pokemonSearch(AdminFrm.words[1]);
                    listViewChange(table, "Pokemon", "AdminFrm");
                }
                else //All Pokemon
                {
                    var table = showList("Pokemon");
                    listViewChange(table, "Pokemon", "AdminFrm");
                }

            }
            //-------------------
            else if (AdminFrm.words.Length == 1 && AdminFrm.words[0].ToUpper() == "CAUGHT")
            {
                AdminFrm.AdminListView.Columns.Add("Username");
                AdminFrm.AdminListView.Columns.Add("ID");
                AdminFrm.databaseName = "User_Caught";
                AdminFrm.DatabaseLabel.Text = AdminFrm.databaseName;
                //--
                var table = showList("User_Caught"); //Show All User_Caught
                listViewChange(table, "User", "AdminFrm");
            }

            //------------------
            else if (AdminFrm.words.Length == 1 && AdminFrm.words[0].ToUpper() == "FAVORITE")
            {
                AdminFrm.databaseName = "User_Favorite";
                AdminFrm.DatabaseLabel.Text = AdminFrm.databaseName;
                AdminFrm.AdminListView.Columns.Add("Username");
                AdminFrm.AdminListView.Columns.Add("ID");
                //--
                var table = showList("User_Favorite");  //Show All Favorite
                listViewChange(table, "User", "AdminFrm");

            }
            else if (AdminFrm.words.Length == 1 && AdminFrm.words[0].ToUpper() == "/HELP")
            {
                MessageBox.Show("READ\n----------\ndatabases: Pokemon, User, Favorite, Caught\nOption for Pokemon & User: 'enter search keyword'" +
                    "\n<database name> <optional keyword>\n----------\nCREATE/UPDATE (MUST BE IN CURRENT DATABASE)\n----------\nPokemon:\n---\n<ID> <NAME> <TYPE1> <OPTIONAL TYPE2 (NULL IF NONE)> " +
                    "<OPTIONAL DESC>\n---\nUser:\n---\n<Username> <Password> <Confirm Password>\n---\nCaught or Favorite:\n---\n" +
                    "<Username> <ID>\n", "MANUAL");
            }
            else
            {
                AdminFrm.databaseName = "";
                AdminFrm.DatabaseLabel.Text = "";
            }
            AdminFrm.subdataName = "";
            AdminFrm.AdminTextBox.Text = "";
            AdminFrm.adminRequest = "";
            AdminFrm.currentKey = "";
            AdminFrm.currentKey2 = "";
        }
        public void adminListViewAddPokemonInfo()
        {
            AdminFrm.AdminListView.Items.Clear();
            AdminFrm.AdminListView.Columns.Clear();
            AdminFrm.AdminListView.Columns.Add("ID");
            AdminFrm.AdminListView.Columns.Add("Name");
            AdminFrm.AdminListView.Columns.Add("Type1");
            AdminFrm.AdminListView.Columns.Add("Type2");
            AdminFrm.AdminListView.Columns.Add("Desc");
        }
        public void subDatabase()
        {
            if (AdminFrm.databaseName == "User_Caught")
            {
                AdminFrm.currentKey2 = "";
                string username = AdminFrm.AdminListView.SelectedItems[0].SubItems[0].Text;
                adminListViewAddPokemonInfo();
                AdminFrm.subdataName = "Pokemon";
                var table = showList("User_Caught", username);
                listViewChange(table, "Pokemon", "AdminFrm");

            }
            else if (AdminFrm.databaseName == "User_Favorite")
            {
                AdminFrm.currentKey2 = "";
                string username = AdminFrm.AdminListView.SelectedItems[0].SubItems[0].Text;
                adminListViewAddPokemonInfo();
                AdminFrm.subdataName = "Pokemon";
                var table = showList("User_Favorite", username);
                listViewChange(table, "Pokemon", "AdminFrm");
            }
        }

        public void createButtonDriver()
        {
            if (AdminFrm.databaseName == "tbl_users")
            {
                createUser();
            }
            else if (AdminFrm.databaseName == "Pokemon")
            {
                createPokemon();
            }
            else createFieldInList();
        }
        public void updateButtonDriver()
        {
            if (AdminFrm.databaseName == "tbl_users")
            {
                updateUser();
            }
            else if (AdminFrm.databaseName == "Pokemon")
            {
                updatePokemon();
            }
            else
            {
                updateUserLists();
            }
        }
    }
}
