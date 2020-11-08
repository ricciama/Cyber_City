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
    public partial class Queries : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetProgram();
                ddlOrgRep.Items.Insert(0, new ListItem("No Organizational Reps Available", "-1"));
                ddlVolunteers.Items.Insert(0, new ListItem("No Volunteers Available", "-1"));
            }
        }

        // retrieves the program that was selected from the dropdown 
        private void GetProgram()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            String programQuery = "Select ProgramID, Name from Program";
            SqlDataAdapter da2 = new SqlDataAdapter(programQuery, con);
            DataSet ds = new DataSet();
            
            da2.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlProgram.DataSource = ds;
                ddlProgram.DataTextField = "Name";
                ddlProgram.DataValueField = "ProgramID";
                ddlProgram.DataBind();
                ddlProgram.Items.Insert(0, new ListItem("Select Program", "-1"));
                ddlProgram.SelectedIndex = 0;

            }

        }

        protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            DataSet ds2 = new DataSet();
            ds2.Clear();
            string ProgramID = ddlProgram.SelectedValue.ToString();
            string ProgramName = ddlProgram.SelectedItem.Text;

            if (ProgramID != "-1")
            {
                string orgRepQuery = "SELECT DISTINCT OrgRep.OrgRepID, OrgRep.FName + ' ' + OrgRep.LName AS OrgRepName FROM OrgRep INNER JOIN ";
                orgRepQuery += "OrgRepRegistration ON OrgRep.OrgRepID = OrgRepRegistration.OrgRepID INNER JOIN ";
                orgRepQuery += "Event ON OrgRepRegistration.EventID = Event.EventID INNER JOIN ";
                orgRepQuery += "Program ON Event.ProgramID = Program.ProgramID WHERE (Program.ProgramID = '" + ProgramID.ToString() + "')";

                SqlDataAdapter da2 = new SqlDataAdapter(orgRepQuery, con);
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    ddlOrgRep.DataSource = ds2;
                    ddlOrgRep.DataTextField = "OrgRepName";
                    ddlOrgRep.DataValueField = "OrgRepID";
                    ddlOrgRep.DataBind();
                    ddlOrgRep.Items.Insert(0, new ListItem("Select Organizational Rep", "-1"));
                    ddlOrgRep.SelectedIndex = 0;
                }

                string volunteerQuery = "SELECT DISTINCT Volunteer.VolunteerID, Volunteer.FName + ' ' + Volunteer.Lname AS VolunteerName FROM Volunteer INNER JOIN ";
                volunteerQuery += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
                volunteerQuery += "Event ON VolunteerRegistration.EventID = Event.EventID INNER JOIN ";
                volunteerQuery += "Program ON Event.ProgramID = Program.ProgramID WHERE (Program.ProgramID = '" + ProgramID.ToString() + "')";

                DataSet vDS = new DataSet();
                SqlDataAdapter vDA = new SqlDataAdapter(volunteerQuery, con);
                vDA.Fill(vDS);
                if (vDS.Tables[0].Rows.Count > 0)
                {
                    ddlVolunteers.DataSource = vDS;
                    ddlVolunteers.DataTextField = "VolunteerName";
                    ddlVolunteers.DataValueField = "VolunteerID";
                    ddlVolunteers.DataBind();
                    ddlVolunteers.Items.Insert(0, new ListItem("Select Volunteer", "-1"));
                    ddlVolunteers.SelectedIndex = 0;
                }

            }
            else
            {
                // turns all tables not visible
                grdAllEvents.Visible = false;
                grdOrgRepSchedule.Visible = false;
                grdOrgRepRoster.Visible = false;
                grdVolunteerSchedule.Visible = false;

                // insert into first item for ddl
                ddlOrgRep.Items.Insert(0, new ListItem("No Organizational Reps Available", "-1"));
                ddlVolunteers.Items.Insert(0, new ListItem("No Volunteers Available", "-1"));

                // set first item to variable
                var firstItem = ddlOrgRep.Items[0];
                var firstItemV = ddlVolunteers.Items[0];

                // clear the dropdown and add first item
                ddlOrgRep.Items.Clear();
                ddlOrgRep.Items.Add(firstItem);
                ddlOrgRep.DataBind();

                ddlVolunteers.Items.Clear();
                ddlVolunteers.Items.Add(firstItemV);
                ddlVolunteers.DataBind();

                //turn labels off
                lblAllEvents.Visible = false;
                lblOrgRepSched.Visible = false;
                lblVolunteerSched.Visible = false;
                lblOrgRepRoster.Visible = false;

            }

            // Displays Gridview For Program 
            string schedule = "SELECT Name, Time FROM Event WHERE ProgramID = '" + ProgramID.ToString() + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                if (ProgramID != "-1")
                {
                    lblAllEvents.Text = "Event Schedule For " + ddlProgram.SelectedItem.Text;
                    lblAllEvents.Visible = true;
                    SqlCommand cmd = new SqlCommand(schedule, con);
                    SqlDataAdapter sched = new SqlDataAdapter(cmd);
                    sched.Fill(ds);
                    grdAllEvents.DataSource = ds;
                    grdAllEvents.DataBind();
                    grdAllEvents.Visible = true;
                    lblAllEvents.Visible = true;
                }
                else
                {
                    lblAllEvents.Visible = false;
                }
            }
        }

        protected void ddlOrgRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populate gridview for org rep schedule
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
                    lblOrgRepSched.Text = "Organization Rep Schedule For " + ddlOrgRep.SelectedItem.Text;
                    SqlCommand repCMD = new SqlCommand(query, orgRepCon);
                    SqlDataAdapter repDA = new SqlDataAdapter(repCMD);
                    repDA.Fill(orgRepDS);
                    grdOrgRepSchedule.DataSource = orgRepDS;
                    grdOrgRepSchedule.DataBind();
                    lblOrgRepSched.Visible = true;
                    grdOrgRepSchedule.Visible = true;

                }
                else
                {
                    grdOrgRepSchedule.Visible = false;
                    grdOrgRepRoster.Visible = false;

                    lblOrgRepRoster.Visible = false;
                    lblOrgRepSched.Visible = false;

                    
                }

            }

            SqlConnection omg = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string query2 = "SELECT Student.StudentFName + ' ' + Student.StudentLName AS Student_Name, Student.ParentFName + ' ' + Student.ParentLName AS Parent_Name, Student.ParentEmail, Student.Gender ";
            query2 += "FROM OrgRep INNER JOIN StudentRegistration ON OrgRep.Code = StudentRegistration.Code INNER JOIN ";
            query2 += "Student ON StudentRegistration.StudentID = Student.StudentID WHERE OrgRep.OrgRepID = " + orgRepID.ToString();

            DataSet ords2 = new DataSet();
            using (omg)
            {
                if (orgRepID != "-1")
                {
                    lblOrgRepRoster.Text = "Roster for " + ddlOrgRep.SelectedItem.Text;
                    SqlCommand fart = new SqlCommand(query2, omg);
                    SqlDataAdapter poop = new SqlDataAdapter(fart);
                    poop.Fill(ords2);
                    grdOrgRepRoster.DataSource = ords2;
                    grdOrgRepRoster.DataBind();
                    lblOrgRepRoster.Visible = true;
                    grdOrgRepRoster.Visible = true;
                }
                else
                {
                    lblOrgRepRoster.Visible = false;
                }
            }

                         


        }

        protected void ddlVolunteers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //populate gridview for volunteer schedule
            SqlConnection volCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string volunteerID = ddlVolunteers.SelectedValue.ToString();

            string query = "SELECT Event.Name, Event.Time, Event.Location FROM Volunteer INNER JOIN ";
            query += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
            query += "Event ON VolunteerRegistration.EventID = Event.EventID ";
            query += "WHERE(VolunteerRegistration.VolunteerID = " + ddlVolunteers.SelectedValue + ")";

            DataSet volDS = new DataSet();
            using (volCon)
            {
                if (volunteerID != "-1")
                {
                    lblVolunteerSched.Text = "Volunteer Schedule For " + ddlVolunteers.SelectedItem.Text;
                    SqlCommand volCMD = new SqlCommand(query, volCon);
                    SqlDataAdapter volDA = new SqlDataAdapter(volCMD);
                    volDA.Fill(volDS);
                    grdVolunteerSchedule.DataSource = volDS;
                    grdVolunteerSchedule.DataBind();
                    lblVolunteerSched.Visible = true;
                    grdVolunteerSchedule.Visible = true;
                }
                else
                {
                    grdVolunteerSchedule.Visible = false;
                    lblVolunteerSched.Visible = false;


                }
            }
        }
    }
}