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
    public partial class RegisterOrgRep : System.Web.UI.Page
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
                GetProgram();
                GetOrganization();
                ddlEvent.Items.Insert(0, new ListItem("No Events Available", "-1"));
                ddlOrgRep.Items.Insert(0, new ListItem("No Organizational Reps Available", "-1"));
                
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


        // selected index change for the program that was picked
        protected void ddlSelectProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            ds2.Clear();
            string ProgramID = ddlSelectProgram.SelectedValue.ToString();
            string ProgramName = ddlSelectProgram.SelectedItem.Text;

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
                ddlEvent.Items.Insert(0, new ListItem("No Events Available", "-1"));

                var firstItem = ddlEvent.Items[0];
                ddlEvent.Items.Clear();
                ddlEvent.Items.Add(firstItem);
                ddlEvent.DataBind();
                lblSchedule.Visible = false;

            }

            // Displays Gridview For Program 
            string schedule = "SELECT Name, Time FROM Event WHERE ProgramID = '" + ProgramID.ToString() + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                if (ProgramID != "-1")
                {
                    lblSchedule.Text = "Event Schedule For " + ddlSelectProgram.SelectedItem.Text;
                    lblSchedule.Visible = true;
                    SqlCommand cmd = new SqlCommand(schedule, con);
                    SqlDataAdapter sched = new SqlDataAdapter(cmd);
                    sched.Fill(ds);
                    programSchedule.DataSource = ds;
                    programSchedule.DataBind();
                    programSchedule.Visible = true;
                    lblSchedule.Visible = true;
                }
                else
                {
                    lblSchedule.Visible = false;
                }


            }
        }


        // retrieves the organization that was picked from dropdown
        private void GetOrganization()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            String orgQuery = "Select OrganizationID, Name from Organization";
            da = new SqlDataAdapter(orgQuery, con);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSelectOrg.DataSource = ds;
                ddlSelectOrg.DataTextField = "Name";
                ddlSelectOrg.DataValueField = "OrganizationID";
                ddlSelectOrg.DataBind();
                ddlSelectOrg.Items.Insert(0, new ListItem("Select Organization", "-1"));
                ddlSelectOrg.SelectedIndex = 0;
            }

        }

        protected void ddlSelectOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.Clear();
            string OrgID;
            string OrgName;
            OrgName = ddlSelectOrg.SelectedItem.Text;
            OrgID = ddlSelectOrg.SelectedValue.ToString();

            if (OrgID != "-1")
            {
                string orgRepQuery = "SELECT OrgRepID, FName + ' ' + LName AS OrganizationalRep, OrganizationID FROM OrgRep WHERE OrganizationID = '" + OrgID.ToString() + "'";
                da = new SqlDataAdapter(orgRepQuery, con);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlOrgRep.DataSource = ds;
                    ddlOrgRep.DataTextField = "OrganizationalRep";
                    ddlOrgRep.DataValueField = "OrgRepID";
                    ddlOrgRep.DataBind();
                    ddlOrgRep.Items.Insert(0, new ListItem("Select Organizational Rep", "-1"));
                    ddlOrgRep.SelectedIndex = 0;
                }
            }
            else
            {
                orgRepSchedule.Visible = false;
                ddlOrgRep.Items.Insert(0, new ListItem("No Organizational Reps Available", "-1"));

                var firstItem = ddlOrgRep.Items[0];
                ddlOrgRep.Items.Clear();
                ddlOrgRep.Items.Add(firstItem);
                ddlOrgRep.DataBind();
                lblOrgRepSchedule.Visible = false;
            }

        }

        // selected index change for which organization that was picked
        protected void ddl_OrgRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection orgRepCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string orgRepID = ddlOrgRep.SelectedValue.ToString();

            string query = "SELECT Event.Name, Event.Time, Event.Location FROM OrgRep INNER JOIN ";
            query += "OrgRepRegistration ON OrgRep.OrgRepID = OrgRepRegistration.OrgRepID INNER JOIN ";
            query += "Event ON OrgRepRegistration.EventID = Event.EventID ";
            query += "WHERE(OrgRepRegistration.OrgRepID = " + ddlOrgRep.SelectedValue + ")";

            DataSet orgRepDS = new DataSet();
            using (orgRepCon)
            {
                if (orgRepID != "-1")
                {
                    lblOrgRepSchedule.Text = "Organization Rep Schedule For " + ddlOrgRep.SelectedItem.Text;
                    SqlCommand repCMD = new SqlCommand(query, orgRepCon);
                    SqlDataAdapter repDA = new SqlDataAdapter(repCMD);
                    repDA.Fill(orgRepDS);
                    orgRepSchedule.DataSource = orgRepDS;
                    orgRepSchedule.DataBind();
                    lblOrgRepSchedule.Visible = true;
                    orgRepSchedule.Visible = true;
                    
                }
                else
                {
                    lblOrgRepSchedule.Visible = false;
                }


            }

        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int counter = 0;

            if (ddlSelectProgram.SelectedValue == "-1")
            {
                lblProgramError.Text = "Please Choose Valid Program";
                lblProgramError.ForeColor = System.Drawing.Color.Red;
                lblProgramError.Font.Bold = true;
                counter++;
            }
            else
            {
                lblProgramError.Visible = false;
            }

            if (ddlEvent.SelectedValue == "-1")
            {
                lblEventError.Text = "Please Choose a Valid Event";
                lblEventError.ForeColor = System.Drawing.Color.Red;
                lblProgramError.Font.Bold = true;
                counter++;
            }
            else
            {
                lblEventError.Visible = false;
            }

            if (ddlSelectOrg.SelectedValue == "-1")
            {
                lblOrgError.Text = "Please Choose a Valid Organization";
                lblOrgError.ForeColor = System.Drawing.Color.Red;
                lblOrgError.Font.Bold = true;
            }
            else
            {
                lblOrgError.Visible = false;
            }

            if (ddlOrgRep.SelectedValue == "-1")
            {
                lblOrgRepError.Text = "Please Choose a Valid Volunteer";
                lblOrgRepError.ForeColor = System.Drawing.Color.Red;
                lblOrgRepError.Font.Bold = true;
                counter++;
            }
            else
            {
                lblOrgRepError.Visible = false;
            }

            if (counter == 0)
            {
                // checks to see if volunteer is already registered for event
                SqlConnection check = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                string bean = "SELECT Count (*) FROM [OrgRepRegistration] WHERE [OrgRepID] = @OrgRepID AND [EventID] = @EventID";
                SqlCommand command = new SqlCommand(bean, check);

                command.Parameters.AddWithValue("@OrgRepID", ddlOrgRep.SelectedValue);
                command.Parameters.AddWithValue("EventID", ddlEvent.SelectedValue);

                check.Open();

                int registerCount = Convert.ToInt32(command.ExecuteScalar());

                check.Close();

                if (registerCount == 0)
                {
                    lblProgramError.Visible = false;
                    lblEventError.Visible = false;
                    lblOrgError.Visible = false;
                    lblOrgRepError.Visible = false;

                    SqlConnection register = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                    string query = "INSERT INTO [OrgRepRegistration] (OrgRepID, EventID) VALUES (@OrgRepID, @EventID)";

                    SqlCommand sqlCommand = new SqlCommand(query, register);

                    register.Open();

                    sqlCommand.Parameters.AddWithValue("@OrgRepID", ddlOrgRep.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@EventID", ddlEvent.SelectedValue);


                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.Dispose();
                    register.Close();

                    lblSuccess.Text = "Successfully Registered For Event";
                    lblSuccess.ForeColor = System.Drawing.Color.Green;
                    lblSuccess.Font.Bold = true;
                }
                else
                {
                    lblSuccess.Text = "Organizational Rep Already Registered For Event!!";
                    lblSuccess.ForeColor = System.Drawing.Color.Red;
                    lblSuccess.Font.Bold = true;
                }
            }
        }
    }
}
