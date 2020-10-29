using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberCity
{
    public partial class StudentHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void learnMoreHomePage_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            SqlCommand sqlCommand;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

            cnn = new SqlConnection(connectionString);

            String sql = "Insert into [StudentRegistration] (StudentID, Code, InternetAccess) " +
                "Values (@Name, @Date, @Time, @Location, @ProgramID)";

            sqlCommand = new SqlCommand(sql, cnn);

            cnn.Open();


            //Inserts the data from the new student page into the database

            //sqlCommand.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtEventName.Text));
            //sqlCommand.Parameters.AddWithValue("@Date", HttpUtility.HtmlEncode(txtEventDate.Text));
            //sqlCommand.Parameters.AddWithValue("@Time", HttpUtility.HtmlEncode(txtEventTime.Text));
            //sqlCommand.Parameters.AddWithValue("@Location", HttpUtility.HtmlEncode(txtEventLocation.Text));
            //sqlCommand.Parameters.AddWithValue("@ProgramID", HttpUtility.HtmlEncode(ddlProgram.SelectedItem.Value));


            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            cnn.Close();
        }
    }
}