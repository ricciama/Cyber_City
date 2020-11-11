﻿using System;
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
            schedule += "FROM Event INNER JOIN OrgRepRegistration ON Event.EventID = OrgRepRegistration.EventID INNER JOIN ";
            schedule += "OrgRep ON OrgRepRegistration.OrgRepID = OrgRep.OrgRepID INNER JOIN ";
            schedule += "Program ON Event.ProgramID = Program.ProgramID WHERE(OrgRep.UserName = '" + orgRepUsername + "')";

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
                tblCancel.Visible = false;
                tblNotRegistered.Visible = true;

            }

            connect.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}