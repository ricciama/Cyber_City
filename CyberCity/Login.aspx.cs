using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CyberCity
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
            SqlConnection sc2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            sc.Open();
            sc2.Open();

            System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
            findPass.Connection = sc;
            // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
            findPass.CommandText = "select PasswordHash from Pass where Username = @Username";
            findPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));

            SqlDataReader reader = findPass.ExecuteReader(); // create a reader

            if (reader.HasRows) // if the username exists, it will continue
            {
                bool typeTrigger = false;

                while (reader.Read()) // this will read the single record that matches the entered username
                {
                    string storedHash = reader["PasswordHash"].ToString(); // store the database password into this variable

                    if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                    {
                        Session["Username"] = txtUsername.ToString();
                        typeTrigger = true;
                    }
                }

                if (typeTrigger == true)
                {
                    // Pulls the user type
                    String sqlQuery3 = "Select Type from [Person] where [Username] = @Username";

                    SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sc2);

                    sqlCommand1.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));

                    string type = sqlCommand1.ExecuteScalar().ToString();
                    Session["UserType"] = type;
                    Response.Redirect("HomePage.aspx");
                }

                sc.Close();
                sc2.Close();
            }
        }
    }
}