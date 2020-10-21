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
            String student = "SELECT * FROM [Student] WHERE [Username] = " + Session["Username"].ToString();
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());
            SqlCommand sqlCommand2 = new SqlCommand(student, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

            while (sqlRead.Read())
            {
                txtVolunteerFN.Text = (sqlRead["FirstName"].ToString());
                txtVolunteerLN.Text = (sqlRead["LastName"].ToString());
                txtVolunteerDOB.Text = (sqlRead["DOB"].ToString());
                txtVolunteerPhone.Text = (sqlRead["Phone"].ToString());
                ddlShirtSize.SelectedValue = (sqlRead["ShirtSize"].ToString());
                ddlGender.SelectedValue = (sqlRead["Gender"].ToString());
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
}