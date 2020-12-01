using Microsoft.Ajax.Utilities;
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
    public partial class EditEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                EventTable.Visible = false;
                tblEventInfo.Visible = false;
                tblConfirmation.Visible = false;

                String sqlQuery2 = "Select Name, ProgramID from Program order by ProgramID";
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
                                ddlPrograms.Items.Add(item);
                            }
                        }
                        con.Close();
                    }
                }

            }
        }

     

        protected void ddlPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventTable.Visible = true;
            tblEventInfo.Visible = false;
            tblConfirmation.Visible = false;
            int progIDint = int.Parse(ddlPrograms.SelectedValue);
            string progID = ddlPrograms.SelectedValue.ToString();

            ddlEvents.Items.Clear();
            

            if (progIDint!=-1)
            {
                ddlEvents.Items.Insert(0, new ListItem("Select Event", "-1"));
                String sqlQuery2 = "Select Name, EventID, ProgramID from Event WHERE ProgramID = " + progID + " order by EventID";
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
                                item.Value = sdr["EventID"].ToString();
                               
                                ddlEvents.Items.Add(item);
                            }
                            
                        }
                        con.Close();
                    }
                }
                
                if (ddlEvents.Items.Count == 1)
                {
                    int dummy = -1;
                    ListItem itemNone= new ListItem();
                    itemNone.Text = "No events exist for this program!";
                    itemNone.Value = dummy.ToString();
                    ddlEvents.Items.Add(itemNone);
                }

            }

            else
            {
                EventTable.Visible = false;
                tblEventInfo.Visible = false;

            }
            
        }

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblConfirmation.Visible = false;
            String sqlQuery2 = "Select Name, ProgramID from Program order by ProgramID";
            String sqlConnection2 = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;
            ddlProgram.Items.Clear();

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


            //populate text boxes with relevant event information
            int eventIDint = int.Parse(ddlEvents.SelectedValue);
            if (eventIDint != -1)
            {
                tblEventInfo.Visible = true;
                string eventID = ddlEvents.SelectedValue.ToString();
                string eventString = "select EventID, ProgramID, Name, Time, Location from Event where EventID = " + eventID + "";

                SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(eventString, sqlConnection3);

                sqlConnection3.Open();

                using (SqlDataReader sqlRead = sqlCommand2.ExecuteReader())
                {
                    while (sqlRead.Read())
                    {
                        txtEventName.Text = (sqlRead["Name"].ToString());
                        txtEventTime.Text = (sqlRead["Time"].ToString());
                        txtEventLocation.Text = (sqlRead["Location"].ToString());
                        ddlProgram.SelectedValue= (sqlRead["ProgramID"].ToString());


                    }
                    sqlRead.Close();
                    sqlConnection3.Close();
                }
            }

            else
            {
                tblEventInfo.Visible = false;
            }
        }

        protected void btnEditEvent_Click1(object sender, EventArgs e)
        {
            string eventID = ddlEvents.SelectedValue.ToString();
            string connectionString;
            SqlConnection cnn;
            SqlCommand sqlCommand;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

            cnn = new SqlConnection(connectionString);

            String sql = "UPDATE Event SET [Name] = @Name, [Location] = @Location, [Time] = @Time, [ProgramID] = @ProgramID";
            sql += " WHERE EventID = " + eventID + "";

            sqlCommand = new SqlCommand(sql, cnn);

            cnn.Open();


            //Inserts the data from the new student page into the database

            sqlCommand.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtEventName.Text));
            sqlCommand.Parameters.AddWithValue("@Location", HttpUtility.HtmlEncode(txtEventLocation.Text));
            sqlCommand.Parameters.AddWithValue("@Time", HttpUtility.HtmlEncode(txtEventTime.Text));
            sqlCommand.Parameters.AddWithValue("@ProgramID", HttpUtility.HtmlEncode(ddlProgram.SelectedIndex.ToString()));

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            cnn.Close();
            tblConfirmation.Visible = true;
            ddlEvents.SelectedIndex = -1;
            ddlPrograms.SelectedIndex = -1;
            EventTable.Visible = false;
            tblEventInfo.Visible = false;
           

        }
    }
}