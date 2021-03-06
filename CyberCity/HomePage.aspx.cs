﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;
using System.Net.Mail;

namespace CyberCity
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblMessageConfirmation.Visible = false;
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString().Equals("V"))
                {
                    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());

                    sc.Open();

                    String sqlQuery = "Select ISNULL(TShirtSize, 'flag') from [Volunteer] where [Username] = @Username";

                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sc);

                    sqlCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                    string TShirtSize = sqlCommand.ExecuteScalar().ToString();

                    if (TShirtSize.Equals("flag"))
                    {
                        sc.Close();
                        Response.Redirect("FirstTimeLoginVolunteer.aspx");
                    }
                    sc.Close();
                }
                if (Session["UserType"].ToString().Equals("OR"))
                {
                    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());

                    sc.Open();

                    String sqlQuery = "Select ISNULL(PhoneNumber, 'flag') from [OrgRep] where [Username] = @Username";

                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sc);

                    sqlCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                    string TShirtSize = sqlCommand.ExecuteScalar().ToString();

                    if (TShirtSize.Equals("flag"))
                    {
                        sc.Close();
                        Response.Redirect("ORFirstTimeLogin.aspx");
                    }
                    sc.Close();
                }
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string schedule = "SELECT name as Name, FORMAT(date, 'd') as Date from Program where date >= GETDATE() ORDER BY date";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                SqlCommand cmd = new SqlCommand(schedule, con);
                SqlDataAdapter sched = new SqlDataAdapter(cmd);
                sched.Fill(ds);
                studentSchedule.DataSource = ds;
                studentSchedule.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void learnMoreHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.jmu.edu/cob/cis/about/cyberday.shtml");
        }

       

        protected void btnSendMessage_Click1(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("cybercityjmu1@gmail.com");
            msg.To.Add("cybercityjmu1@gmail.com");
            msg.Subject = "New Message From " + txtEmail.Text;
            string emailBody = "Subject: Online Question " + "<br/> <br/> ";
            emailBody += txtMessage.Text + "<br/> <br/> ";
            emailBody += "From, <br/> " + txtEmail.Text;
            msg.Body = emailBody;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
            msg.Dispose();

            //txtName.Text = "";
            txtMessage.Text = "";
            //txtSubject.Text = "";
            txtEmail.Text = "";
            tblMessageConfirmation.Visible = true;
        }
    }
}