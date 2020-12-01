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
    public partial class OrgRepSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Forces a user to login before accessing this page
            if (Session["UserType"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if (Session["UserType"].ToString() != "OR")
            {
                Response.Redirect("HomePage.aspx");
            }

            int check = 0;

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string orgRepUsername = Session["Username"].ToString();

            string schedule = "SELECT Event.Name, FORMAT( Program.Date, 'd') as Date, CONVERT(varchar, Event.Time, 100) as Time, Event.Location ";
            schedule += "FROM Event INNER JOIN OrgRepRegistration ON Event.EventID = OrgRepRegistration.EventID INNER JOIN ";
            schedule += "OrgRep ON OrgRepRegistration.OrgRepID = OrgRep.OrgRepID INNER JOIN ";
            schedule += "Program ON Event.ProgramID = Program.ProgramID WHERE(OrgRep.UserName = '" + orgRepUsername + "')";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                SqlCommand cmd = new SqlCommand(schedule, con);
                SqlDataAdapter sched = new SqlDataAdapter(cmd);
                sched.Fill(ds);
                orgRepSchedule.DataSource = ds;
                orgRepSchedule.DataBind();
            }


            // checks if a student is registerd for a program
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            string sqlCheck = "SELECT Count(*) AS count ";
            sqlCheck += "FROM Event INNER JOIN OrgRepRegistration ON Event.EventID = OrgRepRegistration.EventID INNER JOIN ";
            sqlCheck += "OrgRep ON OrgRepRegistration.OrgRepID = OrgRep.OrgRepID INNER JOIN ";
            sqlCheck += "Program ON Event.ProgramID = Program.ProgramID WHERE(OrgRep.UserName = '" + orgRepUsername + "')";

            SqlCommand sqlCommand2 = new SqlCommand(sqlCheck, connect);
            connect.Open();
            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();
            while (sqlRead.Read())
            {
                check = Int32.Parse(sqlRead["count"].ToString());

            }

            orgRepUsername = orgRepUsername.Substring(0, 1).ToUpper() + orgRepUsername.Substring(1);
            lblOrgRepSchedule.Text = orgRepUsername + "'s CyberDay Schedule";
            if (check == 0)
            {
                Table1.Visible = false;
                ScheduleHeader.Visible = false;
                tblNotRegistered.Visible = true;

            }

            connect.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}