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
    public partial class VolunteerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Username = Session["Username"].ToString();
                String student = "Select FName, LName, TShirtSize, Email, Phone, LunchTicket, DOB, Gender from Volunteer where Username = '" + Username + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(student, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
                    txtVolunteerFN.Text = (sqlRead["FName"].ToString());
                    txtVolunteerLN.Text = (sqlRead["LName"].ToString());
                    txtVolunteerDOB.Text = (sqlRead["DOB"].ToString());
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
            String sqlUpdate = "UPDATE Volunteer SET [FName] = @FirstName, [LName] = @LastName, [DOB] = @DOB, [Email] = @Email, " +
                "[LunchTicket] = @LunchTicket, [Phone] = @Phone, [Gender] = @Gender, [TShirtSize] = @TshirtSize " +
                "WHERE Username = ('" + Session["Username"].ToString() + "')";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtVolunteerFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtVolunteerLN.Text));
            sqlCommand.Parameters.AddWithValue("@DOB", HttpUtility.HtmlEncode(txtVolunteerDOB.Text));
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

        }
    }
}