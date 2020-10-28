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
    public partial class FirstTimeLoginVolunteer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE Volunteer SET [LunchTicket] = @LunchTicket, [Phone] = @Phone, [Gender] = @Gender, [TShirtSize] = @TshirtSize " +
                "WHERE Username = ('" + Session["Username"].ToString() + "')";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);
         
            sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtVolunteerPhone.Text));
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

            Response.Redirect("HomePage.aspx");
        }
    }
}