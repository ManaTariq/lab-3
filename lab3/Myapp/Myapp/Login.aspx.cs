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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "lab3";
            string uid = "root";
            string password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection cnn = new MySqlConnection(connectionString);
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM  user WHERE u_name = '" + TextBox1.Text + "' and pass = '" + TextBox2.Text + "'", cnn);
            cnn.Open();
            switch (cnn.State)

            {

                case System.Data.ConnectionState.Open:
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        MySqlDataReader dr = null;
                        dr = cmd2.ExecuteReader();
                        if (dr.Read())
                        {
                            if (TextBox1.Text.ToString() == dr["u_name"].ToString() && TextBox2.Text.ToString() == dr["pass"].ToString())
                            {
                                if (TextBox1.Text.ToString() == "admin" && TextBox2.Text.ToString() == "1111")
                                {
                                    Response.Redirect("admin.aspx");

                                }
                                else {
                                    Response.Redirect("Data.aspx");

                                }
                            }


                            else if (TextBox1.Text.ToString() != dr["name"].ToString() || TextBox2.Text.ToString() != dr["password"].ToString())
                            {
                                Response.Write("<script>alert('login not successful');</script>");
                            }

                        }



                        dr.Close();
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
    }
}