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

            // Inserts the information from the survey into the student registration table

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
}