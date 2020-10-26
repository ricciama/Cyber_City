using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberCity
{
    public partial class CreateOrganization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateOrg_Click(object sender, EventArgs e)
        {
     


            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());


            // Tests if the username is available
            String sqlQuery3 = "Select Count(1) from [Organization] where [Name] = @Name";

            SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

            sqlCommand1.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtOrgName.Text));

            sqlConnection1.Open();

            int orgCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

            sqlConnection1.Close();

            if (orgCount == 0)
            {

                string connectionString;
                SqlConnection cnn;
                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "Insert into [Organization] (Address, Name, PrimaryContactName, PhoneNumber, Email) " +
                    "Values (@Address, @Name, @PrimaryContactName, @PhoneNumber, @Email)";

                sqlCommand = new SqlCommand(sql, cnn);

                cnn.Open();


                //Inserts the data from the new student page into the database

                sqlCommand.Parameters.AddWithValue("@Address", HttpUtility.HtmlEncode(txtOrgAddress.Text));
                sqlCommand.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtOrgName.Text));
                sqlCommand.Parameters.AddWithValue("@PrimaryContactName", HttpUtility.HtmlEncode(txtOrgContactName.Text));
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", HttpUtility.HtmlEncode(txtOrgPhone.Text));
                sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtOrgEmail.Text));


                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                cnn.Close();
                tblConfirmation.Visible = true;
            }
        }
    }
}