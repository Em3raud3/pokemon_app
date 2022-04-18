using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace Software_Project

{
    internal class Model
    {
        private OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");

        public OleDbConnection openController()
        {
            this.con.Open();
            return con;
        }
        public OleDbConnection closeController()
        {
            this.con.Close();
            return con;
        }
        public OleDbCommand databaseCommand(string command, OleDbConnection con)
        {
            OleDbCommand cmd = new OleDbCommand(command, con);
            return cmd;
        }
        public OleDbDataReader executeReaderCommand(OleDbCommand cmd)
        {
            OleDbDataReader dr = cmd.ExecuteReader();
                return dr;
        }
        public void executeNonQueryCommand(OleDbCommand cmd)
        {
            cmd.ExecuteNonQuery();
        }
        public OleDbDataAdapter databaseAdapter(string query, OleDbConnection con)
        {
            OleDbDataAdapter dat = new OleDbDataAdapter(query, con);
            return dat;

        }
        public OleDbConnection getCon()
        {
            return con;
        }

    }

}
