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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
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
                //Sends email to user with login credentials
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("cybercityjmu1@gmail.com");
                msg.To.Add(txtEmail.Text);
                msg.Subject = "Reset Password Link";
                string emailBody = "You are receiving this email because you stated you forgot your password for " + txtUsername.Text;
                emailBody += "<br/><br/> To reset your password, please click this link.";
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