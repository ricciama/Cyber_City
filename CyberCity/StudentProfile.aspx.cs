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
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Username = Session["Username"].ToString();
                String coordinator = "Select StudentFName, StudentLName, ParentFName, ParentLName, ParentEmail, ParentPhone, DOB, Gender, Ethnicity from Student where Username = '" + Username + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(coordinator, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
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
    }
}