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
    public partial class VolunteerAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            SqlCommand sqlCommand;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

            cnn = new SqlConnection(connectionString);

            String sql = "Insert into [Volunteer] (FName, LName, TShirtSize, Organization, DOB, Email, Phone, LunchTicket, Gender) " +
                "Values (@FirstName, @LastName, @ShirtSize, @OrgName, @DOB, @Email, @Phone, @LunchTicket, @Gender)";

            sqlCommand = new SqlCommand(sql, cnn);

            cnn.Open();


            //Inserts the data from the new student page into the database

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtVolunteerFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtVolunteerLN.Text));
            sqlCommand.Parameters.AddWithValue("@DOB", HttpUtility.HtmlEncode(txtVolunteerDOB.Text));

            //Converts the lunchTicket checkbox to an integer in order to be stored in the database
            int lunchTicket = 0;
            if (chkLunch.Checked == true)
            {
                lunchTicket = 1;
            }
            sqlCommand.Parameters.AddWithValue("@LunchTicket", lunchTicket);
            sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtVolunteerPhone.Text));
            sqlCommand.Parameters.AddWithValue("@Gender", HttpUtility.HtmlEncode(ddlGender.SelectedValue));
            sqlCommand.Parameters.AddWithValue("@OrgName", HttpUtility.HtmlEncode(txtOrgName.Text));
            sqlCommand.Parameters.AddWithValue("@ShirtSize", HttpUtility.HtmlEncode(ddlShirtSize.SelectedValue));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtVolunteerEmail.Text));

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            cnn.Close();

        }
    }
}