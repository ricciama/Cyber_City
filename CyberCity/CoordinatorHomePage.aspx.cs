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
using OfficeOpenXml;
using System.IO;
using System.Windows.Media;
using System.Drawing;



namespace CyberCity
{
    public partial class CoordinatorHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Forces a user to login before accessing this page
            if(Session["UserType"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if(Session["UserType"].ToString() != "C")
            {
                Response.Redirect("HomePage.aspx");
            }


            if (!Page.IsPostBack)
            {
                String sqlQuery2 = "Select ProgramID, Name FROM Program";
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
                                item.Text = sdr["Name"].ToString();
                                item.Value = sdr["ProgramID"].ToString();
                                ddlProgram.Items.Add(item);

                            }
                        }
                        
                        con2.Close();
                    }

                }

                grdOrgRep.DataSource = GetOrgReps();
                grdOrgRep.DataBind();

                grdVolunteer.DataSource = GetVolunteers();
                grdVolunteer.DataBind();
            }

            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString().Equals("V"))
                {
                    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());

                    sc.Open();

                    String sqlQuery = "Select ISNULL(TShirtSize, 'flag') from [Volunteer] where [Username] = @Username";

                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sc);

                    sqlCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                    string TShirtSize = sqlCommand.ExecuteScalar().ToString();

                    if (TShirtSize.Equals("flag"))
                    {
                        sc.Close();
                        Response.Redirect("FirstTimeLoginVolunteer.aspx");
                    }
                    sc.Close();
                }
                if (Session["UserType"].ToString().Equals("OR"))
                {
                    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());

                    sc.Open();

                    String sqlQuery = "Select ISNULL(PhoneNumber, 'flag') from [OrgRep] where [Username] = @Username";

                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sc);

                    sqlCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                    string TShirtSize = sqlCommand.ExecuteScalar().ToString();

                    if (TShirtSize.Equals("flag"))
                    {
                        sc.Close();
                        Response.Redirect("ORFirstTimeLogin.aspx");
                    }
                    sc.Close();
                }
            }

            int check = 0;

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            string schedule = "SELECT name as Name, FORMAT(date, 'd') as Date from Program where date >= GETDATE() ORDER BY date";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                SqlCommand cmd = new SqlCommand(schedule, con);
                SqlDataAdapter sched = new SqlDataAdapter(cmd);
                sched.Fill(ds);
                studentSchedule.DataSource = ds;
                studentSchedule.DataBind();
            }

        }

        // fills hidden gridview with org reps and their events
        public DataTable GetOrgReps()
        {
            string program = "SELECT Event.Name, LTRIM(RIGHT(CONVERT(VARCHAR(20), Event.Time, 100), 7)) AS Time, Event.Location, OrgRep.FName + ' ' + OrgRep.LName AS 'Org Rep Name', OrgRep.PhoneNumber, OrgRep.Email ";
            program += "FROM Event INNER JOIN ";
            program += "OrgRepRegistration ON Event.EventID = OrgRepRegistration.EventID INNER JOIN ";
            program += "OrgRep ON OrgRepRegistration.OrgRepID = OrgRep.OrgRepID ";
            program += "WHERE Event.ProgramID = '" + ddlProgram.SelectedValue + "' ORDER BY Event.Time";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(program, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        var orgReps = new DataTable();
                        da.Fill(orgReps);
                        return orgReps;
                    }
                }
            }
            
        }

        // fills hidden gridview with volunteers and their events
        public DataTable GetVolunteers()
        {
            string program = "SELECT Event.Name, LTRIM(RIGHT(CONVERT(VARCHAR(20), Event.Time, 100), 7)) AS Time, Event.Location, Volunteer.FName + ' ' + Volunteer.Lname AS 'Volunteer Name', Volunteer.Phone ";
            program += "FROM Event INNER JOIN ";
            program += "VolunteerRegistration ON Event.EventID = VolunteerRegistration.EventID INNER JOIN ";
            program += "Volunteer ON VolunteerRegistration.VolunteerID = Volunteer.VolunteerID ";
            program += "WHERE Event.ProgramID = '" + ddlProgram.SelectedValue + "' ORDER BY Event.Time";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(program, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        var volunteers = new DataTable();
                        da.Fill(volunteers);
                        return volunteers;
                    }
                }
            }
        }

        //fills hidden gridview with student Roster
        public DataTable GetStudentRoster()
        {
            string program = "SELECT DISTINCT Student.StudentFName + ' ' + Student.StudentLName AS 'Student Name', Student.ParentFName + ' ' + Student.ParentLName AS 'Parent Name', Student.ParentEmail, Student.ParentPhone, Student.Gender AS 'Student Gender', StudentRegistration.PhotoConsent, StudentRegistration.LunchTicket, Student.UserName ";
            program += "FROM Event INNER JOIN OrgRepRegistration ON Event.EventID = OrgRepregistration.EventID INNER JOIN ";
            program += "OrgRep ON OrgRepRegistration.OrgRepID = OrgRep.OrgRepID INNER JOIN ";
            program += "StudentRegistration ON OrgRep.Code = StudentRegistration.Code INNER JOIN ";
            program += "Student ON StudentRegistration.StudentID = Student.StudentID ";
            program += "WHERE Event.ProgramID = '" + ddlProgram.SelectedValue + "' ORDER BY 'Student Name'";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(program, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        var studentRoster = new DataTable();
                        da.Fill(studentRoster);
                        return studentRoster;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void learnMoreHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.jmu.edu/cob/cis/about/cyberday.shtml");
        }

        // downloads excel file for org rep and volunteers for upcoming events
        protected void btnProgramSchedule_Click(object sender, EventArgs e)
        {
            var orgReps = GetOrgReps();
            var volunteers = GetVolunteers();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            
            //org rep worksheet
            var workSheet = excel.Workbook.Worksheets.Add("Organizational Reps");
            var totalCols = orgReps.Columns.Count;
            var totalRows = orgReps.Rows.Count;

            // sets column width
            workSheet.DefaultColWidth = 23;

            for (var col = 1; col <= totalCols; col++)
            {
                workSheet.Cells[1, col].Value = orgReps.Columns[col - 1].ColumnName;
            }
            for (var row = 1; row <= totalRows; row++)
            {
                for (var col = 0; col < totalCols; col++)
                {
                    workSheet.Cells[row + 1, col + 1].Value = orgReps.Rows[row - 1][col];
                }
            }

            // Select only the header cells
            var headerCells = workSheet.Cells[1, 1, 1, workSheet.Dimension.Columns];

            // Set header text to bold and background purple
            headerCells.Style.Font.Bold = true;
            headerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

            System.Drawing.Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#E0C1F3");
            workSheet.Cells[1, 1, 1, workSheet.Dimension.Columns].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[1, 1, 1, workSheet.Dimension.Columns].Style.Fill.BackgroundColor.SetColor(colFromHex);

            //volunteers worksheet
            var workSheet2 = excel.Workbook.Worksheets.Add("Volunteers");
            var totalCols2 = volunteers.Columns.Count;
            var totalRows2 = volunteers.Rows.Count;

            // sets column width
            workSheet2.DefaultColWidth = 23;

            for (var col = 1; col <= totalCols2; col++)
            {
                workSheet2.Cells[1, col].Value = volunteers.Columns[col - 1].ColumnName;
            }
            for (var row = 1; row <= totalRows2; row++)
            {
                for (var col = 0; col < totalCols2; col++)
                {
                    workSheet2.Cells[row + 1, col + 1].Value = volunteers.Rows[row - 1][col];
                }
            }

            // Select only the header cells
            var headerCells2 = workSheet2.Cells[1, 1, 1, workSheet2.Dimension.Columns];

            // Set header text to bold and background purple
            headerCells2.Style.Font.Bold = true;
            headerCells2.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

            System.Drawing.Color colFromHex2 = System.Drawing.ColorTranslator.FromHtml("#E0C1F3");
            workSheet2.Cells[1, 1, 1, workSheet2.Dimension.Columns].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet2.Cells[1, 1, 1, workSheet2.Dimension.Columns].Style.Fill.BackgroundColor.SetColor(colFromHex2);
            

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Program.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        protected void btnStudentRoster_Click(object sender, EventArgs e)
        {
            var studentRoster = GetStudentRoster();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            //org rep worksheet
            var workSheet = excel.Workbook.Worksheets.Add("Student Roster");
            var totalCols = studentRoster.Columns.Count;
            var totalRows = studentRoster.Rows.Count;

            // sets column width
            workSheet.DefaultColWidth = 23;

            for (var col = 1; col <= totalCols; col++)
            {
                workSheet.Cells[1, col].Value = studentRoster.Columns[col - 1].ColumnName;
            }
            for (var row = 1; row <= totalRows; row++)
            {
                for (var col = 0; col < totalCols; col++)
                {
                    workSheet.Cells[row + 1, col + 1].Value = studentRoster.Rows[row - 1][col];
                    
                }
            }
            // Select only the header cells
            var headerCells = workSheet.Cells[1, 1, 1, workSheet.Dimension.Columns];

            // Set header text to bold and background purple
            headerCells.Style.Font.Bold = true;
            headerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

            System.Drawing.Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#E0C1F3");
            workSheet.Cells[1, 1, 1, workSheet.Dimension.Columns].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[1, 1, 1, workSheet.Dimension.Columns].Style.Fill.BackgroundColor.SetColor(colFromHex);


            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=StudentRoster.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }
   
}