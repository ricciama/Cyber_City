using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Net;
using System.Net.Mail;

namespace CyberCity
{
    public partial class CoordinatorProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Forces a user to login before accessing this page
            if (Session["UserType"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if (Session["UserType"].ToString() != "C")
            {
                Response.Redirect("HomePage.aspx");
            }

            if (!IsPostBack)
            {
                string Username = Session["Username"].ToString();
                String coordinator = "Select FName, LName, Email, FacultyPosition, PhoneNumber, Office, UserName from Coordinator where Username = '" + Username + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(coordinator, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
                    txtCoordinatorFN.Text = (sqlRead["FName"].ToString());
                    txtCoordinatorLN.Text = (sqlRead["LName"].ToString());
                    txtCoordinatorEmail.Text = (sqlRead["Email"].ToString());
                    txtFacultyPosition.Text = (sqlRead["FacultyPosition"].ToString());
                    txtCoordinatorPhone.Text = (sqlRead["PhoneNumber"].ToString());
                    txtCoordinatorOffice.Text = (sqlRead["Office"].ToString());
                    txtUsernme.Text = (sqlRead["UserName"].ToString());
                }
                sqlRead.Close();
                sqlConnection2.Close();
            }

        }

        protected void btnEditCoordinator_Click(object sender, EventArgs e)
        {
            // Updates coordinator table
            String sqlUpdate = "UPDATE Coordinator SET [FName] = @FirstName, [LName] = @LastName, [Email] = @Email, [FacultyPosition] = @FacultyPosition, " +
            "[PhoneNumber] = @PhoneNumber, [Office] = @Office " +
            "WHERE Username = ('" + Session["Username"].ToString() + "')";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtCoordinatorFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtCoordinatorLN.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtCoordinatorEmail.Text));
            sqlCommand.Parameters.AddWithValue("@FacultyPosition", HttpUtility.HtmlEncode(txtFacultyPosition.Text));
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", HttpUtility.HtmlEncode(txtCoordinatorPhone.Text));
            sqlCommand.Parameters.AddWithValue("@Office", txtCoordinatorOffice.Text);

            sqlConnection.Open();

            adapter.UpdateCommand = sqlCommand;
            adapter.UpdateCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            sqlConnection.Close();

            lblFeedback.Visible = true;


        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            //updates password
            String sqlUpdate2 = "UPDATE Pass SET [PasswordHash] = @Password WHERE Username = ('" + Session["Username"].ToString() + "')";
            SqlDataAdapter da = new SqlDataAdapter();

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
            SqlCommand cmd = new SqlCommand(sqlUpdate2, con);

            cmd.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(txtPassword.Text)));

            con.Open();

            da.UpdateCommand = cmd;
            da.UpdateCommand.ExecuteNonQuery();

            cmd.Dispose();

            con.Close();

            lblPasswordSuccess.Visible = true;

            //Sends email to user that they changed their password
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("cybercityjmu1@gmail.com");
            msg.To.Add(txtCoordinatorEmail.Text);
            msg.Subject = "Password Change " + txtCoordinatorFN.Text + ' ' + txtCoordinatorLN.Text;
            string emailBody = "Hello, " + txtCoordinatorFN.Text;
            emailBody += "<br/><br/> You are receiving this email because you have changed your password. If this was not you, please contact Dr. Tom Dillon or Professor Shawn Lough immediately.";
            emailBody += "<br/><br/><b/>Dr. Dillon's Email: dillontx@jmu.edu<br/><b/>Professor Lough's Email: loughsr@jmu.edu";
            msg.Body = emailBody;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
            msg.Dispose();
        }
    }
}