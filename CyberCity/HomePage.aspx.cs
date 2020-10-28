using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;

namespace CyberCity
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserType"].ToString().Equals("V"))
            {
                SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITYDB"].ConnectionString.ToString());

                sc.Open();

                String sqlQuery = "Select TShirtSize from [Volunteer] where [Username] = @Username";

                SqlCommand sqlCommand1 = new SqlCommand(sqlQuery, sc);

                sqlCommand1.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                string TShirtSize = sqlCommand1.ExecuteScalar().ToString();

                if(!TShirtSize.IsNullOrWhiteSpace())
                {
                    Response.Redirect("FirstTimeLoginVolunteer.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void learnMoreHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.jmu.edu/cob/cis/about/cyberday.shtml");
        }
    }
}