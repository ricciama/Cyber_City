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
    public partial class ORFirstTimeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE OrgRep SET [LunchTicket] = @LunchTicket, [PhoneNumber] = @Phone, [GradesTaught] = @GradesTaught " +
               "WHERE Username = ('" + Session["Username"].ToString() + "')";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtOrgRepPhone.Text));
            String gradesTaught = "";
            if (chkElementary.Checked)
            {
                gradesTaught += "Elementary ";

            }
            if (chkSixth.Checked)
            {
                gradesTaught += "Sixth ";

            }
            if (chkSeventh.Checked)
            {
                gradesTaught += "Seventh ";

            }
            if (chkEight.Checked)
            {
                gradesTaught += "Eighth ";

            }
            if (chkHighSchool.Checked)
            {
                gradesTaught += "High School ";

            }
            if (chkNone.Checked)
            {
                gradesTaught += "None ";

            }
            sqlCommand.Parameters.AddWithValue("@GradesTaught", gradesTaught);

            int lunchTicket = 0;
            if (chbxLunch.Checked == true)
            {
                lunchTicket = 1;
            }
            sqlCommand.Parameters.AddWithValue("@LunchTicket", lunchTicket);

            sqlConnection.Open();

            adapter.UpdateCommand = sqlCommand;
            adapter.UpdateCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            sqlConnection.Close();

            Response.Redirect("HomePage.aspx");
        }
    }
}