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
                        ddlSelectVolunteer.Items.Insert(0, new ListItem("Select Volunteer", "-1"));
                        con2.Close();
                    }

                }

                //String sqlQuery2 = "Select VolunteerID, FName + ' '+ Lname as VolunteerName FROM Volunteer";
                //SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());
                //sqlConnection2.Open();

                //DataTable dt = new DataTable();
                //SqlDataAdapter da = new SqlDataAdapter(sqlQuery2, sqlConnection2);
                //da.Fill(dt);

                //ddlSelectVolunteer.DataSource = dt;
                //ddlSelectVolunteer.DataTextField = "VolunteerName";
                //ddlSelectVolunteer.DataValueField = "VolunteerID";
                //ddlSelectVolunteer.DataBind();
                //sqlConnection2.Close();

                GetProgram();
                ProgramSchedule();
                //VolunteerSchedule();
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

        public void ProgramSchedule()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string ProgramID = ddlSelectProgram.SelectedValue.ToString();
            string schedule = "SELECT Name, Date, Time FROM Event";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                //lblSchedule.Visible = true;
                SqlCommand cmd = new SqlCommand(schedule, con);
                SqlDataAdapter sched = new SqlDataAdapter(cmd);
                sched.Fill(ds);
                programSchedule.DataSource = ds;
                programSchedule.DataBind();

            }
            
        }

        //public void VolunteerSchedule()
        //{
        //    SqlConnection volCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
        //    string volunteerID = ddlSelectVolunteer.SelectedValue.ToString();
        //    string query = "SELECT Event.Name, Event.Date, Event.Time, Event.Location FROM Volunteer INNER JOIN ";
        //    query += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
        //    query += "Event ON VolunteerRegistration.EventID = Event.EventID ";
        //    query += "WHERE(VolunteerRegistration.VolunteerID = 1)";

        //    DataSet volDS = new DataSet();
        //    DataTable volDT = new DataTable();
        //    using (volCon)
        //    {
        //        SqlCommand volCMD = new SqlCommand(query, volCon);
        //        SqlDataAdapter volDA = new SqlDataAdapter(volCMD);
        //        volDA.Fill(volDS);
        //        volunteerSchedule.DataSource = volDS;
        //        volunteerSchedule.DataBind();
        //    }


        //}

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

        protected void ddlSelectVolunteer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection volCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            volCon.Open();
            string volunteerID = ddlSelectVolunteer.SelectedValue.ToString();

            //string query = "SELECT Event.Name, Event.Date, Event.Time, Event.Location FROM Volunteer INNER JOIN ";
            //query += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
            //query += "Event ON VolunteerRegistration.EventID = Event.EventID ";
            //query += "WHERE(VolunteerRegistration.VolunteerID = " + ddlSelectVolunteer.SelectedValue + ")";

            string query = "SELECT * FROM Volunteer WHERE VolunteerID = '" + ddlSelectVolunteer.SelectedValue + "'";



            SqlCommand volCMD = new SqlCommand(query, volCon);
            SqlDataAdapter volDA = new SqlDataAdapter(volCMD);
            DataSet volDS = new DataSet();
            volDA.Fill(volDS, "Volunteer");
            volunteerSchedule.DataMember = "Volunteer";
            volunteerSchedule.DataSource = volDS;
            volunteerSchedule.DataBind();
            volCon.Close();

        }
    }
}