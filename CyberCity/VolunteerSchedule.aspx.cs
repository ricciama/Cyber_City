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
    public partial class VolunteerSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int check = 0;

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string volunteerUsername = Session["Username"].ToString();

            string schedule = "SELECT Event.Name as 'Event Name', Event.Time, Event.Location FROM Volunteer " +
                "INNER JOIN VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN Event ON VolunteerRegistration.EventID = Event.EventID " +
                "WHERE(Volunteer.UserName = '" + volunteerUsername + "')";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                SqlCommand cmd = new SqlCommand(schedule, con);
                SqlDataAdapter sched = new SqlDataAdapter(cmd);
                sched.Fill(ds);
                volunteerSchedule.DataSource = ds;
                volunteerSchedule.DataBind();
            }

            // checks if a volunteer is registerd for a program
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            string sqlCheck = "SELECT count(*) as count FROM Volunteer " +
            "INNER JOIN VolunteerRegistration ON Volunteer.VolunteerID = VolunteerRegistration.VolunteerID INNER JOIN Event ON VolunteerRegistration.EventID = Event.EventID " +
           "WHERE(Volunteer.UserName = '" + volunteerUsername + "')";

            SqlCommand sqlCommand2 = new SqlCommand(sqlCheck, connect);
            connect.Open();
            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();
            while (sqlRead.Read())
            {
                check = Int32.Parse(sqlRead["count"].ToString());

            }

            if (check == 0)
            {
                Table1.Visible = false;
                tblNotRegistered.Visible = true;

            }

            connect.Close();


        }
    }
}