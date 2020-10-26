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
    public partial class CreateProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateProgram_Click(object sender, EventArgs e)
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
            tblConfirmation.Visible = true;
        }
    }
}