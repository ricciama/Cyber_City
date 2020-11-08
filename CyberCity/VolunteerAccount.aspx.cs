using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;

namespace CyberCity
{
    public partial class VolunteerAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // generates random number for password
        private int RandomNumber(int min, int max)
        {
            Random rn = new Random();
            return rn.Next(min, max);
        }

        // generate random string for password
        private string RandomString(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random rd = new Random();
            char value;
            for (int i = 0; i < length; i++)
            {
                value = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65)));
                sb.Append(value);
            }

            return sb.ToString();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // generates random password
            StringBuilder sb = new StringBuilder();
            sb.Append(RandomNumber(10, 199));
            sb.Append(RandomString(7));


            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            // Tests if the username is available
            String sqlQuery3 = "Select Count(*) from [Person] where [Username] = @Username";

            SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

            sqlCommand1.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsernme.Text));

            sqlConnection1.Open();

            int userNameCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

            sqlConnection1.Close();

            if (userNameCount == 0)
            {

                string connectionString;
                SqlConnection cnn;
                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "Insert into [Volunteer] (FName, LName, Email, Username) " +
                    "Values (@FirstName, @LastName, @Email, @Username)";

                sqlCommand = new SqlCommand(sql, cnn);

                cnn.Open();


                //Inserts the data from the new student page into the database

                sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtVolunteerFN.Text));
                sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtVolunteerLN.Text));
                sqlCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsernme.Text));
                sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtVolunteerEmail.Text));

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                cnn.Close();

                SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                sc.Open();

                SqlCommand createUser = new SqlCommand();
                createUser.Connection = sc;
                // INSERT USER RECORD
                createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username, @Email, 'V')";
                createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtVolunteerFN.Text)));
                createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtVolunteerLN.Text)));
                createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                createUser.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(txtVolunteerEmail.Text)));
                createUser.ExecuteNonQuery();

                System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                setPass.Connection = sc;
                // INSERT PASSWORD RECORD AND CONNECT TO USER
                setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(sb.ToString())))); // hash entered password
                setPass.ExecuteNonQuery();

                sc.Close();

                //Sends email to user with login credentials
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("cybercityjmu1@gmail.com");
                msg.To.Add(txtVolunteerEmail.Text);
                msg.Subject = "Cyber Day Credentials For " + txtVolunteerFN.Text + ' ' + txtVolunteerLN.Text;
                string emailBody = "Welcome to CyberDay! You are receiving this email because you have been added as a Volunteer for the Cyber Day. <br /> <br /> Your Login Credentials can be found below<br/> Login Details <br /> Username: " + txtUsernme.Text + " <br /> Password: " + sb.ToString();
                emailBody += "<br /> <br /> Please click this link to view/edit your profile and change your password if necessary";
                msg.Body = emailBody;
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(msg);
                msg.Dispose();


                // Clears Textboxes
                txtVolunteerFN.Text = null;
                txtVolunteerLN.Text = null;
                txtVolunteerEmail.Text = null;
                txtUsernme.Text = null;
                

                confirmationlbl.Text = "Volunteer Created Successfully!";
                confirmationlbl.ForeColor = Color.Green;
                confirmationlbl.Visible = true;
                lblEmailSuccess.Visible = true;

            } else if (userNameCount != 0)
            {
                confirmationlbl.Text = "Username already exists please select a new one!";
                confirmationlbl.ForeColor = Color.Red;
                tblConfirmation.Visible = true;
                confirmationlbl.Visible = true;
            }

        }

    }
}