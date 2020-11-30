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
                BindGrid();
            }

        }

        private void BindGrid()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string orgRepUsername = Session["Username"].ToString();
            string group = "SELECT StudentRegistration.StudentRegistrationID AS ID, Student.StudentID AS sID, Student.StudentFName + ' ' + Student.StudentLName AS 'Student Name', Student.ParentFName + ' ' + Student.ParentLName AS 'Parent Name', Student.ParentEmail, Student.Gender, Student.UserName ";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void grdOrgStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int srID = Convert.ToInt32(grdOrgStudent.DataKeys[e.RowIndex].Values[0]);
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            //int studentID = Convert.ToInt32(grdOrgStudent.DataKeys[e.RowIndex].Values[1]);

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM StudentRegistration WHERE StudentRegistrationID = @StudentRegistrationID"))
                {
                    cmd.Parameters.AddWithValue("@StudentRegistrationID", srID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
                }

                //if (studentID != -1)
                //{
                //    BindGrid();
                //}
                //else
                //{
                //    grdOrgStudent.Visible = false;
                    
                //}
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

        protected void grdOrgStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdOrgStudent.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
    
}