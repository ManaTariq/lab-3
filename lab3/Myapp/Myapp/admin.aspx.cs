using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Myapp
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "lab3";
            string uid = "root";
            string password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection cnn = new MySqlConnection(connectionString);
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM user", cnn);
            MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM data", cnn);

            cnn.Open();
            switch (cnn.State)

            {

                case System.Data.ConnectionState.Open:
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        MySqlDataReader dr = null;
                        dr = cmd1.ExecuteReader();



                        while (dr.Read())
                        {
                           
                            string uname = (string)dr["u_name"];
                            string passw = (string)dr["pass"];
                            string em = (string)dr["email"];
                            


                            string order = string.Format("{0} - {1} - {2}", uname, passw, em);

                            ListBox1.Items.Add(order);
                        }
                        
                        dr.Close();

                        MySqlDataAdapter da1 = new MySqlDataAdapter(cmd3);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MySqlDataReader dr1 = null;
                        dr1 = cmd3.ExecuteReader();



                        while (dr1.Read())
                        {

                            string uname = (string)dr1["name"];
                            string ag = (string)dr1["age"];
                            string g = (string)dr1["gender"];
                            string ed = (string)dr1["edu"];
                            string c = (string)dr1["city"];
                           



                            string order = string.Format("{0} - {1} - {2} - {3} - {4}", uname,ag ,g,ed,c);

                            ListBox2.Items.Add(order);
                        }

                        dr1.Close();

                        cnn.Close();
                        break;
                    }
                case System.Data.ConnectionState.Closed:
                    {

                        // Connection could not be made, throw an error

                        throw new Exception("The database connection state is Closed");
                        break;

                    }

            }
        
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}