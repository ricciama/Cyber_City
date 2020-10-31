using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CyberCity
{
    public partial class CoordinatorProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string Username = Session["Username"].ToString();
                String coordinator = "Select FName, LName, Email, FacultyPosition, PhoneNumber, Office from Coordinator where Username = '" + Username + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(coordinator, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
                    txtCoordinatorFN.Text = (sqlRead["FName"].ToString());
                    txtCoordinatorLN.Text = (sqlRead["LName"].ToString());
                    txtVolunteerEmail.Text = (sqlRead["Email"].ToString());
                    txtFacultyPosition.Text = (sqlRead["FacultyPosition"].ToString());
                    txtCoordinatorPhone.Text = (sqlRead["PhoneNumber"].ToString());
                    txtCoordinatorOffice.Text = (sqlRead["Office"].ToString());
                }
                sqlRead.Close();
                sqlConnection2.Close();
            }

        }

        protected void btnEditCoordinator_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE Coordinator SET [FName] = @FirstName, [LName] = @LastName, [Email] = @Email, [FacultyPosition] = @FacultyPosition, " +
            "[PhoneNumber] = @PhoneNumber, [Office] = @Office " +
            "WHERE Username = ('" + Session["Username"].ToString() + "')";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtCoordinatorFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtCoordinatorLN.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtVolunteerEmail.Text));
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
    }
}