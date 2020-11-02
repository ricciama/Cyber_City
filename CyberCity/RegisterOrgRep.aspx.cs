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
                ddlEvent.Items.Insert(0, "No Events Available");
                ddlOrgRep.Items.Insert(0, "No Organizational Reps Available");
                
            }
            //ProgramSchedule();

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
        protected void ddl_Event_SelectedIndexChanged(object sender, EventArgs e)
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
                    ProgramSchedule();
                }
            }
            else
            {
                programSchedule.Visible = false;
                ddlEvent.Items.Insert(0, "No Events Available");
                ddlEvent.DataBind();
            }

            string schedule = "SELECT Name, Date, Time FROM Event WHERE ProgramID = " + ddlSelectProgram.SelectedValue;
            var adapter = new SqlDataAdapter(schedule, con);
            var dataSet2 = new DataSet();
            adapter.Fill(dataSet2);
            
            programSchedule.DataSource = dataSet2;
            programSchedule.DataBind();
            



        }

        // populate gridview
        public void ProgramSchedule()
        {
            //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            //string ProgramID = ddlSelectProgram.SelectedValue.ToString();
            //string schedule = "SELECT Name, Date, Time FROM Event";
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //using (con)
            //{
            //    //lblSchedule.Visible = true;
            //    SqlCommand cmd = new SqlCommand(schedule, con);
            //    SqlDataAdapter sched = new SqlDataAdapter(cmd);
            //    sched.Fill(ds);
            //    programSchedule.DataSource = ds;
            //    programSchedule.DataBind();

            //}

            programSchedule.DataSource = LoadData();
            programSchedule.DataBind();


        }

        private DataSet LoadData()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string schedule = "SELECT Name, Date, Time FROM Event";
            var adapter = new SqlDataAdapter(schedule, con);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return dataSet;
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

        // selected index change for which organization that was picked
        protected void ddl_OrgRep_SelectedIndexChanged(object sender, EventArgs e)
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
                ddlOrgRep.Items.Insert(0, "No Organizational Reps Available");
                ddlOrgRep.DataBind();
            }

        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
