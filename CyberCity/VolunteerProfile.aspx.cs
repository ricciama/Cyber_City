﻿using System;
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
    public partial class VolunteerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Forces a user to login before accessing this page
            if (Session["UserType"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if (Session["UserType"].ToString() != "V")
            {
                Response.Redirect("HomePage.aspx");
            }

            if (!IsPostBack)
            {
                string Username = Session["Username"].ToString();
                String student = "Select FName, LName, TShirtSize, Email, Phone, LunchTicket, Gender from Volunteer where Username = '" + Username + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(student, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
                    txtUsernme.Text = Username;
                    txtVolunteerFN.Text = (sqlRead["FName"].ToString());
                    txtVolunteerLN.Text = (sqlRead["LName"].ToString());
                    txtVolunteerPhone.Text = (sqlRead["Phone"].ToString());
                    ddlShirtSize.SelectedValue = (sqlRead["TShirtSize"].ToString());
                    ddlGender.SelectedValue = (sqlRead["Gender"].ToString());
                    txtVolunteerEmail.Text = (sqlRead["Email"].ToString());
                    int lunch = Int32.Parse(sqlRead["LunchTicket"].ToString());
                    if (lunch == 1)
                    {
                        chkLunch.Checked = true;
                    }
                    else
                    {
                        chkLunch.Checked = false;
                    }
                }
                sqlRead.Close();
                sqlConnection2.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE Volunteer SET [FName] = @FirstName, [LName] = @LastName, [Email] = @Email, " +
                "[LunchTicket] = @LunchTicket, [Phone] = @Phone, [Gender] = @Gender, [TShirtSize] = @TshirtSize " +
                "WHERE Username = ('" + Session["Username"].ToString() + "')";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtVolunteerFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtVolunteerLN.Text));
            sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtVolunteerPhone.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtVolunteerEmail.Text));
            sqlCommand.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);

            int lunchTicket = 0;
            if (chkLunch.Checked == true)
            {
                lunchTicket = 1;
            }
            sqlCommand.Parameters.AddWithValue("@LunchTicket", lunchTicket);
            sqlCommand.Parameters.AddWithValue("@TshirtSize", ddlShirtSize.SelectedValue);

            sqlConnection.Open();

            adapter.UpdateCommand = sqlCommand;
            adapter.UpdateCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            sqlConnection.Close();

            lblPasswordSuccess.Visible = false;
            lblConfirmation.Visible = true;

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

            lblConfirmation.Visible = false;
            lblPasswordSuccess.Visible = true;

            //Sends email to user that they changed their password
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("cybercityjmu1@gmail.com");
            msg.To.Add(txtVolunteerEmail.Text);
            msg.Subject = "Password Change " + txtVolunteerFN.Text + ' ' + txtVolunteerLN.Text;
            string emailBody = "Hello, " + txtVolunteerFN.Text;
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