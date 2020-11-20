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
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Fills the string program with the session variable if it exists
            string program = null;
            int programID = -1;

            if (Session["Program"] != null)
            {
                program = Session["Program"].ToString();

                String student = "Select ProgramID from Program where Name = '" + program + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(student, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
      
                     programID = Int32.Parse(sqlRead["ProgramID"].ToString());
                }
                sqlRead.Close();
                sqlConnection2.Close();
            }

            //fill Drop down list
            if (!IsPostBack)
            {
                String sqlQuery2 = "Select ProgramID, Name from Program order by ProgramID";
                String sqlConnection2 = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;

                using (SqlConnection con = new SqlConnection(sqlConnection2))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery2))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                ListItem item = new ListItem();
                                item.Text = sdr["Name"].ToString();
                                item.Value = sdr["ProgramID"].ToString();
                                ddlProgram.Items.Add(item);
                            }
                        }
                        con.Close();
                    }
                }
            }

            if(Session["Program"] != null)
            {
                ddlProgram.SelectedIndex = programID + 1;
            }

            Session["Program"] = null;
        }

        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {      

                string connectionString;
                SqlConnection cnn;
                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "Insert into [Event] (Name, Time, Location, ProgramID) " +
                    "Values (@Name, @Time, @Location, @ProgramID)";

                sqlCommand = new SqlCommand(sql, cnn);

                cnn.Open();


                //Inserts the data from the new student page into the database

                sqlCommand.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtEventName.Text));
                sqlCommand.Parameters.AddWithValue("@Time", HttpUtility.HtmlEncode(txtEventTime.Text));
                sqlCommand.Parameters.AddWithValue("@Location", HttpUtility.HtmlEncode(txtEventLocation.Text));
                sqlCommand.Parameters.AddWithValue("@ProgramID", HttpUtility.HtmlEncode(ddlProgram.SelectedItem.Value));


                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                cnn.Close();

                txtEventName.Text = "";
                txtEventLocation.Text = "";
                txtEventTime.Text = "";

                tblConfirmation.Visible = true;

        }
    }
}