using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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

                txtOrgAddress.Text = "";
                txtOrgContactName.Text = "";
                txtOrgEmail.Text = "";
                txtOrgPhone.Text = "";

                confirmationlbl.Text = "Organization Successfully Created!";
                confirmationlbl.ForeColor = Color.Green;
                tblConfirmation.Visible = true;
                tblAddOrgRep.Visible = true;


            } else if (orgCount != 0)
            {
                confirmationlbl.Text = "Organization already exits!";
                confirmationlbl.ForeColor = Color.Red;
                tblConfirmation.Visible = true;
            }
        }

        protected void btnAddOrgRep_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());


            // Tests if the username is available
            String sqlQuery3 = "Select Count(1) from [Organization] where [Name] = @Name";

            SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

            sqlCommand1.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtOrgName.Text));

            sqlConnection1.Open();

            int orgCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

            sqlConnection1.Close();

            if (orgCount > 0)
            {
                Session["Organization"] = txtOrgName.Text;
                Response.Redirect("OrgRepAccount.aspx");
            } else
            {
                confirmationlbl.Text = "Please create an organization before adding representatives!";
                confirmationlbl.ForeColor = Color.Red;
                tblConfirmation.Visible = true;
            }
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtOrgName.Text = "Harrisonburg Middle School";
            txtOrgEmail.Text = "hburgMiddleSchool@gmail.com";
            txtOrgPhone.Text = "5439647869";
            txtOrgContactName.Text = "Tim Smith";
            txtOrgAddress.Text = "342 East Market Street, Harrisonburg Va, 22801";
        }
    }
}