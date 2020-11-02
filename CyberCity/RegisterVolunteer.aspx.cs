using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
namespace CyberCity
{
    public partial class RegisterVolunteer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String sqlQuery2 = "Select VolunteerID, FName + ' '+ Lname as VolunteerName FROM Volunteer";
                String sqlConnection2 = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;

                using (SqlConnection con2 = new SqlConnection(sqlConnection2))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery2))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con2;
                        con2.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                ListItem item = new ListItem();
                                item.Text = sdr["VolunteerName"].ToString();
                                item.Value = sdr["VolunteerID"].ToString();
                                ddlSelectVolunteer.Items.Add(item);
                            }
                        }
                        ddlSelectVolunteer.Items.Insert(0, new ListItem("Select Volunteer", "0"));
                        con2.Close();
                    }

                }
                GetProgram();
                ddlEvent.Items.Insert(0, "No Events Available");
            }
            
        }

        // retrieves the program that was selected from the dropdown 
        private void GetProgram()
        {
            String programQuery = "Select ProgramID, Name from Program";
            da2 = new SqlDataAdapter(programQuery, con);
            da2.Fill(ds2);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlSelectProgram.DataSource = ds2;
                ddlSelectProgram.DataTextField = "Name";
                ddlSelectProgram.DataValueField = "ProgramID";
                ddlSelectProgram.DataBind();
                ddlSelectProgram.Items.Insert(0, new ListItem("Select Program", "-1"));
                ddlSelectProgram.SelectedIndex = 0;

            }

        }

        protected void ddlSelectProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds2.Clear();
            string ProgramID;
            string ProgramName;
            ProgramName = ddlSelectProgram.SelectedItem.Text;
            ProgramID = ddlSelectProgram.SelectedValue.ToString();

            if (ProgramID != "-1")
            {
                string eventQuery = "SELECT EventID, Name, ProgramID FROM Event WHERE ProgramID = '" + ProgramID.ToString() + "'";
                da2 = new SqlDataAdapter(eventQuery, con);
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    ddlEvent.DataSource = ds2;
                    ddlEvent.DataTextField = "Name";
                    ddlEvent.DataValueField = "EventID";
                    ddlEvent.DataBind();
                    ddlEvent.Items.Insert(0, new ListItem("Select Event", "-1"));
                    ddlEvent.SelectedIndex = 0;
                    
                }
            }
            else
            {
                programSchedule.Visible = false;
                ddlEvent.Items.Insert(0, "No Events Available");
                ddlEvent.DataBind();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}