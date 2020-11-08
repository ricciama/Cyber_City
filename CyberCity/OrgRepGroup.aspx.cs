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
    public partial class OrgRepGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int check = 0;

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string studentUsername = Session["Username"].ToString();
            string schedule = "SELECT Event.Name, FORMAT( Program.Date, 'd') as Date, Event.Time, Event.Location " +
                "FROM StudentRegistration INNER JOIN Student ON StudentRegistration.StudentID = Student.StudentID " +
                "INNER JOIN OrgRep ON StudentRegistration.Code = OrgRep.Code INNER JOIN Event INNER JOIN Program " +
                "ON Event.ProgramID = Program.ProgramID INNER JOIN OrgRepRegistration ON Event.EventID = OrgRepRegistration.EventID " +
                "ON OrgRep.OrgRepID = OrgRepRegistration.OrgRepID WHERE(Student.UserName = '" + studentUsername + "')";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                SqlCommand cmd = new SqlCommand(schedule, con);
                SqlDataAdapter sched = new SqlDataAdapter(cmd);
                sched.Fill(ds);
                grdOrgStudent.DataSource = ds;
                grdOrgStudent.DataBind();
            }


            // checks if a student is registerd for a program
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            string sqlCheck = "Select count(*) as count FROM Student INNER JOIN StudentRegistration " +
                "ON Student.StudentID = StudentRegistration.StudentID INNER JOIN OrgRep ON StudentRegistration.Code = OrgRep.Code " +
                "INNER JOIN OrgRepRegistration ON OrgRep.OrgRepID = OrgRepRegistration.OrgRepID INNER JOIN Event " +
                "ON OrgRepRegistration.EventID = Event.EventID WHERE(Student.UserName = '" + studentUsername + "')";

            SqlCommand sqlCommand2 = new SqlCommand(sqlCheck, connect);
            connect.Open();
            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();
            while (sqlRead.Read())
            {
                check = Int32.Parse(sqlRead["count"].ToString());

            }

            if (check == 0)
            {
                //Table1.Visible = false;
                //tblCancel.Visible = false;
                //tblNotRegistered.Visible = true;

            }

            connect.Close();

        }



    }
    
}