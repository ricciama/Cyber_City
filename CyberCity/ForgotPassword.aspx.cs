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
using System.Text;
using System.IO;

namespace CyberCity
{
    public partial class ForgotPassword : System.Web.UI.Page
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

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            // generates random password
            StringBuilder sb = new StringBuilder();
            sb.Append(RandomNumber(10, 199));
            sb.Append(RandomString(7));

            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            // sees if username and email is a match
            String sqlQuery3 = "Select Count (*) from [Person] where [Username] = @Username AND [Email] = @Email";

            SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

            sqlCommand1.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlCommand1.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtEmail.Text));

            sqlConnection1.Open();

            int userNameCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

            sqlConnection1.Close();

            if (userNameCount != 0 )
            {
                //updates password
                String sqlUpdate2 = "UPDATE Pass SET [PasswordHash] = @Password WHERE Username = '" + txtUsername.Text +"'";
                SqlDataAdapter da = new SqlDataAdapter();

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
                SqlCommand cmd = new SqlCommand(sqlUpdate2, con);

                cmd.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(sb.ToString())));

                con.Open();

                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();

                cmd.Dispose();

                con.Close();

                //Sends email to user with login credentials
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("cybercityjmu1@gmail.com");
                msg.To.Add(txtEmail.Text);
                msg.Subject = "Reset Password Link";
                string emailBody = "You are receiving this email because you stated you forgot your password for " + txtUsername.Text;
                emailBody += "<br/><br/><b> Your new password is:</b> " + sb.ToString();
                emailBody += "<br/> <br/> Please click the link below to login, view your profile, and change your password. <br/><br/>Note: it is STRONGLY Encouraged to change your password.";
                emailBody += "<br/><br/><a href='http://cybercity-dev.us-east-1.elasticbeanstalk.com/Login.aspx'>Login Here</a>";
                emailBody += "<br/><br/>If you did NOT choose to reset your password, contact Dr. Dillon or Professor Lough <b>immediately</b><br/><br/><b>Dr.Dillon: dillontw@jmu.edu</b></br><b>Professor Lough: loughsr@jmu.edu</b>";
                msg.Body = emailBody;
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(msg);
                msg.Dispose();

                lblIncorrectEmail.Visible = false;
                lblEmailSuccess.Text = "Password Reset Sent to Email";
                lblEmailSuccess.Visible = true;
            }
            else
            {
                lblIncorrectEmail.Text = "Email and username do not match. Please try again.";
                lblIncorrectEmail.Visible = true;
            }



        }
    }
}