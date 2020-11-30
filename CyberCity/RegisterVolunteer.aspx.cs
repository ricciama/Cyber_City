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
            // populates volunteer dropdown list
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

                GetProgram();
                ddlEvent.Items.Insert(0, new ListItem("No Events Available", "-1"));
            }
            
        }

        // retrieves the program that was selected from the dropdown 
        private void GetProgram()
        {
            String programQuery = "Select ProgramID, Name from Program where date >= GETDATE()";
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
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            ds2.Clear();
            string ProgramName = ddlSelectProgram.SelectedItem.Text;
            string ProgramID = ddlSelectProgram.SelectedValue.ToString();

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
            }
          
            // Displays Gridview For Program 
            string schedule = "SELECT Name, CONVERT(varchar, Time, 100) as Time FROM Event WHERE ProgramID = '" + ProgramID.ToString() + "'";
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


        protected void ddlSelectVolunteer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection volCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string volunteerID = ddlSelectVolunteer.SelectedValue.ToString();

            string query = "SELECT VolunteerRegistration.VolunteerRegistrationID AS ID, Event.Name, CONVERT(varchar, Event.Time, 100) as Time, Event.Location FROM Volunteer INNER JOIN ";
            query += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
            query += "Event ON VolunteerRegistration.EventID = Event.EventID INNER JOIN Program on Event.ProgramID = Program.ProgramID ";
            query += "WHERE(VolunteerRegistration.VolunteerID = " + ddlSelectVolunteer.SelectedValue + ") and (Program.ProgramID = " + ddlSelectProgram.SelectedValue +")";

            //string query = "SELECT * FROM Volunteer WHERE VolunteerID = '" + ddlSelectVolunteer.SelectedValue + "'";
            DataSet volDS = new DataSet();
            using (volCon)
            {
                if (volunteerID != "-1")
                {
                    lblVolSchedule.Text = "Volunteer Schedule For " + ddlSelectVolunteer.SelectedItem.Text;
                    SqlCommand volCMD = new SqlCommand(query, volCon);
                    SqlDataAdapter volDA = new SqlDataAdapter(volCMD);
                    volDA.Fill(volDS);
                    volunteerSchedule.DataSource = volDS;
                    volunteerSchedule.DataBind();
                    //volunteerSchedule.Columns[1].Visible = false;
                    lblVolSchedule.Visible = true;
                    volunteerSchedule.Visible = true;
                }
                else
                {
                    volunteerSchedule.Visible = false;
                    lblVolSchedule.Visible = false;
                }
                

            }


        }

        // Inserts records into VolunteerRegistrtion table
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
                lblEventError.Font.Bold = true;
                counter++;
            }
            else
            {
                lblEventError.Visible = false;
            }

            if (ddlSelectVolunteer.SelectedValue == "-1")
            {
                lblVolunteerError.Text = "Please Choose a Valid Volunteer";
                lblVolunteerError.ForeColor = System.Drawing.Color.Red;
                lblVolunteerError.Font.Bold = true;
                counter++;
            }
            else
            {
                lblVolunteerError.Visible = false;
            }

            if(counter == 0)
            {
                // checks to see if volunteer is already registered for event
                SqlConnection check = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                string bean = "SELECT Count (*) FROM [VolunteerRegistration] WHERE [VolunteerID] = @VolunteerID AND [EventID] = @EventID";
                SqlCommand command = new SqlCommand(bean, check);

                command.Parameters.AddWithValue("@VolunteerID", ddlSelectVolunteer.SelectedValue);
                command.Parameters.AddWithValue("EventID", ddlEvent.SelectedValue);

                check.Open();

                int registerCount = Convert.ToInt32(command.ExecuteScalar());

                check.Close();

                if (registerCount == 0)
                {
                    lblProgramError.Visible = false;
                    lblVolunteerError.Visible = false;
                    lblEventError.Visible = false;
                    SqlConnection register = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                    string query = "INSERT INTO [VolunteerRegistration] (VolunteerID, EventID) VALUES (@VolunteerID, @EventID)";

                    SqlCommand sqlCommand = new SqlCommand(query, register);

                    register.Open();

                    sqlCommand.Parameters.AddWithValue("@VolunteerID", ddlSelectVolunteer.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@EventID", ddlEvent.SelectedValue);


                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.Dispose();
                    register.Close();

                    lblSuccess.Text = "Succssfully Registered for an Event";
                    lblSuccess.ForeColor = System.Drawing.Color.Green;
                    lblSuccess.Font.Bold = true;

                    // Rebinds the gridview
                    SqlConnection volCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                    string volunteerID = ddlSelectVolunteer.SelectedValue.ToString();

                    //string queryNew = "SELECT Event.Name, CONVERT(varchar, Event.Time, 100) as Time, Event.Location FROM Volunteer INNER JOIN ";
                    //queryNew += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
                    //queryNew += "Event ON VolunteerRegistration.EventID = Event.EventID ";
                    //queryNew += "WHERE(VolunteerRegistration.VolunteerID = " + ddlSelectVolunteer.SelectedValue + ")";

                    //string query = "SELECT * FROM Volunteer WHERE VolunteerID = '" + ddlSelectVolunteer.SelectedValue + "'";

                    string queryNew = "SELECT VolunteerRegistration.VolunteerRegistrationID AS ID, LTRIM(RIGHT(CONVERT(VARCHAR(20), Event.Time, 100), 7)) as Time, Event.Location FROM Volunteer INNER JOIN ";
                    queryNew += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
                    queryNew += "Event ON VolunteerRegistration.EventID = Event.EventID INNER JOIN Program on Event.ProgramID = Program.ProgramID ";
                    queryNew += "WHERE(VolunteerRegistration.VolunteerID = " + ddlSelectVolunteer.SelectedValue + ") and (Program.ProgramID = " + ddlSelectProgram.SelectedValue + ")";

                    DataSet volDS = new DataSet();
                    using (volCon)
                    {
                        if (volunteerID != "-1")
                        {
                            lblVolSchedule.Text = "Volunteer Schedule For " + ddlSelectVolunteer.SelectedItem.Text;
                            SqlCommand volCMD = new SqlCommand(queryNew, volCon);
                            SqlDataAdapter volDA = new SqlDataAdapter(volCMD);
                            volDA.Fill(volDS);
                            volunteerSchedule.DataSource = volDS;
                            volunteerSchedule.DataBind();
                            //volunteerSchedule.Columns[1].Visible = false;
                            lblVolSchedule.Visible = true;
                            volunteerSchedule.Visible = true;
                        }
                        else
                        {
                            volunteerSchedule.Visible = false;
                            lblVolSchedule.Visible = false;
                        }
                    }


                }
                else
                {
                    lblSuccess.Text = "Volunteer Already Registered For Event!";
                    lblSuccess.ForeColor = System.Drawing.Color.Red;
                    lblSuccess.Font.Bold = true;
                }


                
            }

        }

        protected void volunteerSchedule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int vrID = Convert.ToInt32(volunteerSchedule.DataKeys[e.RowIndex].Values[0]);
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            
            string volunteerID = ddlSelectVolunteer.SelectedValue.ToString();

            string queryNew = "SELECT VolunteerRegistration.VolunteerRegistrationID AS ID, Event.Name, LTRIM(RIGHT(CONVERT(VARCHAR(20), Event.Time, 100), 7)) as Time, Event.Location FROM Volunteer INNER JOIN ";
            queryNew += "VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN ";
            queryNew += "Event ON VolunteerRegistration.EventID = Event.EventID INNER JOIN Program on Event.ProgramID = Program.ProgramID ";
            queryNew += "WHERE(VolunteerRegistration.VolunteerID = " + ddlSelectVolunteer.SelectedValue + ") and (Program.ProgramID = " + ddlSelectProgram.SelectedValue + ")";
            DataSet volDS = new DataSet();

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM VolunteerRegistration WHERE VolunteerRegistrationID = @VolunteerRegistrationID"))
                {
                    cmd.Parameters.AddWithValue("@VolunteerRegistrationID", vrID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                if (volunteerID != "-1")
                {
                    lblVolSchedule.Text = "Volunteer Schedule For " + ddlSelectVolunteer.SelectedItem.Text;
                    SqlCommand volCMD = new SqlCommand(queryNew, con);
                    SqlDataAdapter volDA = new SqlDataAdapter(volCMD);
                    volDA.Fill(volDS);
                    volunteerSchedule.DataSource = volDS;
                    volunteerSchedule.DataBind();
                    //volunteerSchedule.Columns[1].Visible = false;
                    lblVolSchedule.Visible = true;
                    volunteerSchedule.Visible = true;
                }
                else
                {
                    volunteerSchedule.Visible = false;
                    lblVolSchedule.Visible = false;
                }
            }
            
        }

        protected void volunteerSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != volunteerSchedule.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}