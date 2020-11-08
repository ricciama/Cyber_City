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
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Username = Session["Username"].ToString();
                String coordinator = "Select StudentFName, StudentLName, ParentFName, ParentLName, ParentEmail, ParentPhone, FORMAT(DOB, 'd') as DOB, Gender, Ethnicity from Student where Username = '" + Username + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(coordinator, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
                    txtUsernme.Text = Username;
                    txtStudentFN.Text = (sqlRead["StudentFName"].ToString());
                    txtStudentLN.Text = (sqlRead["StudentLName"].ToString());
                    txtParentFN.Text = (sqlRead["ParentFName"].ToString());
                    txtParentLN.Text = (sqlRead["ParentLName"].ToString());
                    txtParentEmail.Text = (sqlRead["ParentEmail"].ToString());
                    txtParentPhone.Text = (sqlRead["ParentPhone"].ToString());
                    txtStudentDOB.Text = (sqlRead["DOB"].ToString());
                    ddlGender.SelectedValue = (sqlRead["Gender"].ToString());
                    ddlEthnicity.SelectedValue = (sqlRead["Ethnicity"].ToString());

                }
                sqlRead.Close();
                sqlConnection2.Close();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE Student SET [StudentFName] = @StudentFName, [StudentLName] = @StudentLName, [ParentFName] = @ParentFName, [ParentLName] = @ParentLName, " +
                "[ParentPhone] = @ParentPhone, [DOB] = @DOB, [Gender] = @Gender, [Ethnicity] = @Ethnicity " +
                "WHERE Username = ('" + Session["Username"].ToString() + "')";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@StudentFName", HttpUtility.HtmlEncode(txtStudentFN.Text));
            sqlCommand.Parameters.AddWithValue("@StudentLName", HttpUtility.HtmlEncode(txtStudentLN.Text));
            sqlCommand.Parameters.AddWithValue("@ParentFName", HttpUtility.HtmlEncode(txtParentFN.Text));
            sqlCommand.Parameters.AddWithValue("@ParentLName", HttpUtility.HtmlEncode(txtParentLN.Text));
            sqlCommand.Parameters.AddWithValue("@ParentPhone", HttpUtility.HtmlEncode(txtParentPhone.Text));
            sqlCommand.Parameters.AddWithValue("@DOB", txtStudentDOB.Text);
            sqlCommand.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@Ethnicity", ddlEthnicity.SelectedValue);

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
            msg.To.Add(txtParentEmail.Text);
            msg.Subject = "Password Change " + txtParentFN.Text + ' ' + txtParentLN.Text;
            string emailBody = "Hello, " + txtParentFN.Text;
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