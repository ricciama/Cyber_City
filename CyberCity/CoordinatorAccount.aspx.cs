using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace CyberCity
{
    public partial class CoordinatorAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            // Tests if the username is available
            String sqlQuery3 = "Select Count (*) from [Person] where [Username] = @Username";

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

                String sql = "Insert into [Coordinator] (FName, LName, Email, FacultyPosition, PhoneNumber, Office, UserName) " +
                    "Values (@FName, @LName, @Email, @FacultyPosition, @PhoneNumber, @Office, @UserName)";

                sqlCommand = new SqlCommand(sql, cnn);

                cnn.Open();


                //Inserts the data from the new coordinator page into the database

                sqlCommand.Parameters.AddWithValue("@FName", HttpUtility.HtmlEncode(txtCoordinatorFN.Text));
                sqlCommand.Parameters.AddWithValue("@LName", HttpUtility.HtmlEncode(txtCoordinatorLN.Text));
                sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtCoordinatorEmail.Text));
                sqlCommand.Parameters.AddWithValue("@FacultyPosition", HttpUtility.HtmlEncode(txtFacultyPosition.Text));
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", HttpUtility.HtmlEncode(txtCoordinatorPhone.Text));
                sqlCommand.Parameters.AddWithValue("@Office", HttpUtility.HtmlEncode(txtCoordinatorOffice.Text));
                sqlCommand.Parameters.AddWithValue("@UserName", HttpUtility.HtmlEncode(txtUsernme.Text));

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                cnn.Close();

                SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                sc.Open();

                SqlCommand createUser = new SqlCommand();
                createUser.Connection = sc;
                // INSERT USER RECORD
                createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username, @Email, 'C')";
                createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtCoordinatorFN.Text)));
                createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtCoordinatorLN.Text)));
                createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                createUser.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(txtCoordinatorEmail.Text)));
                createUser.ExecuteNonQuery();

                System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                setPass.Connection = sc;
                // INSERT PASSWORD RECORD AND CONNECT TO USER
                setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(txtPassword.Text)))); // hash entered password
                setPass.ExecuteNonQuery();

                sc.Close();

                lblFeedback.Text = "Coordinator Created Successfully!";
                lblFeedback.ForeColor = Color.Green;
                lblFeedback.Visible = true;

                //Sends email to user with login credentials
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("cybercityjmu1@gmail.com");
                msg.To.Add(txtCoordinatorEmail.Text);
                msg.Subject = "Cyber Day Credentials For " + txtCoordinatorFN.Text + ' ' + txtCoordinatorLN.Text;
                string emailBody = "Welcome to CyberDay! You are receiving this email because you have been added as a coordinator for the Cyber Day Team. <br/> Your Login Credentials can be found below<br/> Login Details < br /> Username: " + txtUsernme.Text + " < br /> Password: " + txtPassword.Text;
                emailBody += "<br/><br/> Please click this link to view/edit your profile and change your password if necessary"; 
                msg.Body = emailBody;
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(msg);
                msg.Dispose();

                lblEmailSuccess.Visible = true;

                txtCoordinatorFN.Text = "";
                txtCoordinatorLN.Text = "";
                txtCoordinatorOffice.Text = "";
                txtCoordinatorPhone.Text = "";
                txtFacultyPosition.Text = "";
                txtUsernme.Text = "";
                txtCoordinatorEmail.Text = "";

            }
            else if (userNameCount != 0)
            {
                lblFeedback.Text = "Username is already taken please enter a different one.";
                lblFeedback.ForeColor = Color.Red;
                lblFeedback.Visible = true;

            }
}
    }
}