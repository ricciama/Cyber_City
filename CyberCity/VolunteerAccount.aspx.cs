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
    public partial class VolunteerAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int errorCheck = 0;


            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            // Tests if the username is available
            String sqlQuery3 = "Select Count(1) from [Person] where [Username] = @Username";

            SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

            sqlCommand1.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsernme.Text));

            sqlConnection1.Open();

            int userNameCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

            sqlConnection1.Close();

            if (errorCheck == 0)
            {

                string connectionString;
                SqlConnection cnn;
                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "Insert into [Volunteer] (FName, LName, TShirtSize, DOB, Email, Phone, LunchTicket, Gender) " +
                    "Values (@FirstName, @LastName, @ShirtSize, @DOB, @Email, @Phone, @LunchTicket, @Gender)";

                sqlCommand = new SqlCommand(sql, cnn);

                cnn.Open();


                //Inserts the data from the new student page into the database

                sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtVolunteerFN.Text));
                sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtVolunteerLN.Text));
                sqlCommand.Parameters.AddWithValue("@DOB", HttpUtility.HtmlEncode(txtVolunteerDOB.Text));

                //Converts the lunchTicket checkbox to an integer in order to be stored in the database
                int lunchTicket = 0;
                if (chkLunch.Checked == true)
                {
                    lunchTicket = 1;
                }
                sqlCommand.Parameters.AddWithValue("@LunchTicket", lunchTicket);
                sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtVolunteerPhone.Text));
                sqlCommand.Parameters.AddWithValue("@Gender", HttpUtility.HtmlEncode(ddlGender.SelectedValue));
                sqlCommand.Parameters.AddWithValue("@ShirtSize", HttpUtility.HtmlEncode(ddlShirtSize.SelectedValue));
                sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtVolunteerEmail.Text));

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                cnn.Close();

                SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                sc.Open();

                SqlCommand createUser = new SqlCommand();
                createUser.Connection = sc;
                // INSERT USER RECORD
                createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username, 'V')";
                createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtVolunteerFN.Text)));
                createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtVolunteerLN.Text)));
                createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                createUser.ExecuteNonQuery();

                System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                setPass.Connection = sc;
                // INSERT PASSWORD RECORD AND CONNECT TO USER
                setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(txtPassword.Text)))); // hash entered password
                setPass.ExecuteNonQuery();

                sc.Close();
            }

            // Clears Textboxes
            txtVolunteerFN.Text = null;
            txtVolunteerLN.Text = null;
            txtVolunteerEmail.Text = null;
            txtVolunteerDOB.Text = null;
            txtVolunteerPhone.Text = null;
            txtUsernme.Text = null;
            txtPassword.Text = null;
            txtPassword2.Text = null;
            this.ddlGender.ClearSelection();
            this.ddlShirtSize.ClearSelection();
        }
    }
}