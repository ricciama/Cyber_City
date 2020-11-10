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
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                string orgRepUsername = Session["Username"].ToString();
                string group = "SELECT Student.StudentID, Student.StudentFName + ' ' + Student.StudentLName AS 'Student Name', Student.ParentFName + ' ' + Student.ParentLName AS 'Parent Name', Student.ParentEmail, Student.Gender, Student.UserName ";
                group += "FROM OrgRep INNER JOIN StudentRegistration ON OrgRep.Code = StudentRegistration.Code INNER JOIN ";
                group += "Student ON StudentRegistration.StudentID = Student.StudentID ";
                group += "WHERE(OrgRep.UserName = '" + orgRepUsername + "')";


                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(group, con);
                    SqlDataAdapter sched = new SqlDataAdapter(cmd);
                    sched.Fill(ds);
                    grdOrgStudent.DataSource = ds;
                    grdOrgStudent.DataBind();

                    Table1.Visible = true;
                    tblCancel.Visible = false;
                    tblNotRegistered.Visible = false;
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void grdOrgStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentID = (int)e.Keys["StudentID"];


            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string remove = "DELETE FROM StudentRegistration WHERE StudentID = " + studentID;

            using (con)
            {
                SqlCommand cmd2 = new SqlCommand(remove, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
                BindData();

            }
         
        }

        private void BindData()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            string orgRepUsername = Session["Username"].ToString();
            string group = "SELECT Student.StudentID, Student.StudentFName + ' ' + Student.StudentLName AS 'Student Name', Student.ParentFName + ' ' + Student.ParentLName AS 'Parent Name', Student.ParentEmail, Student.Gender, Student.UserName ";
            group += "FROM OrgRep INNER JOIN StudentRegistration ON OrgRep.Code = StudentRegistration.Code INNER JOIN ";
            group += "Student ON StudentRegistration.StudentID = Student.StudentID ";
            group += "WHERE(OrgRep.UserName = '" + orgRepUsername + "')";

            SqlCommand cmd = new SqlCommand(group, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdOrgStudent.DataSource = dt;
            grdOrgStudent.DataBind();
        }

    }
    
}