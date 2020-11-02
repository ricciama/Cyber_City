using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberCity
{
    public partial class StudentHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void learnMoreHomePage_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            // Used to pull the students ID number

            int studentID = -1;
            string Username = Session["Username"].ToString();
            String student = "Select StudentID from Student where Username = '" + Username + "'";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand2 = new SqlCommand(student, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

            while (sqlRead.Read())
            {
                studentID = Int32.Parse(sqlRead["StudentID"].ToString());

            }
            sqlRead.Close();
            sqlConnection2.Close();

            int codeCheck = 0;

            string code = "SELECT Count(code) as code FROM StudentRegistration where StudentID = " + studentID;
            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand3 = new SqlCommand(code, sqlConnection3);

            sqlConnection3.Open();

            SqlDataReader sqlRead2 = sqlCommand3.ExecuteReader();

            while (sqlRead2.Read())
            {
                codeCheck = Int32.Parse(sqlRead2["code"].ToString());
            }
            sqlRead2.Close();
            sqlConnection3.Close();

            if(codeCheck != 0)
            {
                // Do something about a student already being registered for an event
                tblError.Visible = true;
            }

            int codeExistsCheck = 1;
            string codeExists = "Select Count(code) as CodeCount from OrgRep where code = '" + txtTeacherCode.Text + "'";

            SqlCommand sqlCommand4 = new SqlCommand(codeExists, sqlConnection3);
            sqlConnection3.Open();
            SqlDataReader sqlRead3 = sqlCommand4.ExecuteReader();
            while(sqlRead3.Read())
            {
                codeExistsCheck = Int32.Parse(sqlRead3["CodeCount"].ToString());
            }

            sqlRead3.Close();
            sqlConnection3.Close();


            if(codeCheck == 0)
            {
                // Do something about the code not existing
                tblError.Visible = true;
            }

            // Inserts the information from the survey into the student registration table if the error checks are approved
            if (codeCheck != 0 && codeExistsCheck == 1)
            {
                string connectionString;
                SqlConnection cnn;
                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "INSERT INTO [StudentRegistration] (StudentID, Code, ComputerExperience, InternetAccess, ComputerAccess, " +
                    "FirstTime, LunchTicket, EmergencyContactName, EmergencyContactNumber, EmergContactRelToStudent, Notes, " +
                    "Allergies, PhotoConsent) VALUES (@StudentID, @Code, @ComputerExperience, @InternetAccess, @ComputerAccess, " +
                    "@FirstTime, @LunchTicket, @EmergencyContactName, @EmergencyContactNumber, @EmergContactRelToStudent, @Notes, " +
                    "@Allergies, @PhotoConsent)";

                sqlCommand = new SqlCommand(sql, cnn);

                cnn.Open();

                int lunchTicket = 0;
                int photoConsent = 0;

                sqlCommand.Parameters.AddWithValue("@StudentID", HttpUtility.HtmlEncode(studentID));
                sqlCommand.Parameters.AddWithValue("@Code", HttpUtility.HtmlEncode(txtTeacherCode.Text));
                sqlCommand.Parameters.AddWithValue("@ComputerExperience", HttpUtility.HtmlEncode(ddlCPUExp.SelectedItem.Value));
                sqlCommand.Parameters.AddWithValue("@InternetAccess", HttpUtility.HtmlEncode(ddlInternetAccess.SelectedItem.Value));
                sqlCommand.Parameters.AddWithValue("@ComputerAccess", HttpUtility.HtmlEncode(ddlCPUAccess.SelectedItem.Value));
                sqlCommand.Parameters.AddWithValue("@FirstTime", HttpUtility.HtmlEncode(ddlFirstTime.SelectedItem.Value));
                if (ddlLunchTicket.SelectedItem.Value.Equals("Yes"))
                {
                    lunchTicket = 1;
                }
                sqlCommand.Parameters.AddWithValue("@LunchTicket", HttpUtility.HtmlEncode(lunchTicket));
                sqlCommand.Parameters.AddWithValue("@EmergencyContactName", HttpUtility.HtmlEncode(txtEMName.Text));
                sqlCommand.Parameters.AddWithValue("@EmergencyContactNumber", HttpUtility.HtmlEncode(txtEMNumber.Text));
                sqlCommand.Parameters.AddWithValue("@EmergContactRelToStudent", HttpUtility.HtmlEncode(txtEMRelationship.Text));
                sqlCommand.Parameters.AddWithValue("@Notes", HttpUtility.HtmlEncode(txtMisc.Text));
                sqlCommand.Parameters.AddWithValue("@Allergies", HttpUtility.HtmlEncode(txtAllergies.Text));
                if (ddlPhotoPermission.SelectedItem.Value.Equals("Yes"))
                {
                    photoConsent = 1;
                }
                sqlCommand.Parameters.AddWithValue("@PhotoConsent", HttpUtility.HtmlEncode(photoConsent));

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                cnn.Close();

                lblConfirmation.Visible = true;
            }
        }

        protected void CVError_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Used to pull the students ID number

            int studentID = -1;
            string Username = Session["Username"].ToString();
            String student = "Select StudentID from Student where Username = '" + Username + "'";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand2 = new SqlCommand(student, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

            while (sqlRead.Read())
            {
                studentID = Int32.Parse(sqlRead["StudentID"].ToString());

            }
            sqlRead.Close();
            sqlConnection2.Close();

            int codeCheck = 0;

            string code = "SELECT Count(code) as code FROM StudentRegistration where StudentID = " + studentID;
            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand3 = new SqlCommand(code, sqlConnection3);

            sqlConnection3.Open();

            SqlDataReader sqlRead2 = sqlCommand3.ExecuteReader();

            while (sqlRead2.Read())
            {
                codeCheck = Int32.Parse(sqlRead2["code"].ToString());
            }
            sqlRead2.Close();
            sqlConnection3.Close();

            if (codeCheck != 0)
            {
                // Do something about a student already being registered for an event
                tblError.Visible = true;
                args.IsValid = false;
            }

            int codeExistsCheck = 1;
            string codeExists = "Select Count(code) as CodeCount from OrgRep where code = '" + txtTeacherCode.Text + "'";

            SqlCommand sqlCommand4 = new SqlCommand(codeExists, sqlConnection3);
            sqlConnection3.Open();
            SqlDataReader sqlRead3 = sqlCommand4.ExecuteReader();
            while (sqlRead3.Read())
            {
                codeExistsCheck = Int32.Parse(sqlRead3["CodeCount"].ToString());
            }

            sqlRead3.Close();
            sqlConnection3.Close();


            if (codeCheck == 0)
            {
                args.IsValid = false;
            }

            args.IsValid = true;

        }
    }
}