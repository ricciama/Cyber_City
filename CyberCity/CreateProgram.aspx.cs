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
    public partial class CreateProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnCreateProgram_Click(object sender, EventArgs e)
        {

            DateTime dtSuppliedDate = DateTime.Parse(txtProgramDateTime.Text);
            bool dateTest = dtSuppliedDate > DateTime.Today;

            if (dateTest)
            {

                SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());

                // Tests if the username is available
                String sqlQuery3 = "Select Count(1) from [Program] where [Name] = @Name";

                SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

                sqlCommand1.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtProgramName.Text));

                sqlConnection1.Open();

                int programCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

                sqlConnection1.Close();

                if (programCount == 0)
                {

                    string connectionString;
                    SqlConnection cnn;
                    SqlCommand sqlCommand;
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

                    cnn = new SqlConnection(connectionString);

                    String sql = "Insert into [Program] (Name, Date) " +
                        "Values (@Name, @Date)";

                    sqlCommand = new SqlCommand(sql, cnn);

                    cnn.Open();


                    //Inserts the data from the new student page into the database

                    sqlCommand.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtProgramName.Text));
                    sqlCommand.Parameters.AddWithValue("@Date", HttpUtility.HtmlEncode(txtProgramDateTime.Text));

                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.Dispose();
                    cnn.Close();

                    confirmationlbl.Text = "Program Created Successfully!";
                    confirmationlbl.ForeColor = Color.Green;
                    tblConfirmation.Visible = true;
                }
                else if (programCount != 0)
                {
                    confirmationlbl.Text = "Program name already exits please choose a different name!";
                    confirmationlbl.ForeColor = Color.Red;
                    tblConfirmation.Visible = true;
                }
            }
        }

        protected void btnAddEvents_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());

            // Tests if the username is available
            String sqlQuery3 = "Select Count(1) from [Program] where [Name] = @Name";

            SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

            sqlCommand1.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtProgramName.Text));

            sqlConnection1.Open();

            int orgCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

            sqlConnection1.Close();

            if (orgCount > 0)
            {
                Session["Program"] = txtProgramName.Text;
                Response.Redirect("CreateEvent.aspx");
            }
            else
            {
                confirmationlbl.Text = "Please create a program before adding events!";
                confirmationlbl.ForeColor = Color.Red;
                tblConfirmation.Visible = true;
            }
        }

        protected void CVDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dtSuppliedDate = DateTime.Parse(txtProgramDateTime.Text);
            args.IsValid = dtSuppliedDate > DateTime.Today;
        }
    }
}