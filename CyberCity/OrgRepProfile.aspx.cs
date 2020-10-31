using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CyberCity
{
    public partial class OrgRepProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string gradeTaught = "";

                string Username = Session["Username"].ToString();
                String coordinator = "Select FName, LName, Email, PhoneNumber, Code, GradesTaught, LunchTicket from OrgRep where Username = '" + Username + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(coordinator, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
                    txtOrgRepFN.Text = (sqlRead["FName"].ToString());
                    txtOrgRepLN.Text = (sqlRead["LName"].ToString());
                    txtOrgRepEmail.Text = (sqlRead["Email"].ToString());
                    txtOrgRepPhone.Text = (sqlRead["PhoneNumber"].ToString());
                    txtCode.Text = (sqlRead["Code"].ToString());
                    gradeTaught = (sqlRead["GradesTaught"].ToString());
                    int lunch = Int32.Parse(sqlRead["LunchTicket"].ToString());

                    if (lunch == 1)
                    {
                        chkLunch.Checked = true;
                    }
                    else
                    {
                        chkLunch.Checked = false;
                    }

                    if (gradeTaught.Contains("Elementary"))
                    {
                        chkElementary.Checked = true;
                    }
                    if (gradeTaught.Contains("Sixth"))
                    {
                        chkSixth.Checked = true;
                    }
                    if (gradeTaught.Contains("Seventh"))
                    {
                        chkSeventh.Checked = true;
                    }
                    if (gradeTaught.Contains("Eighth"))
                    {
                        chkEight.Checked = true;
                    }
                    if (gradeTaught.Contains("High School"))
                    {
                        chkHighSchool.Checked = true;
                    }
                    if (gradeTaught.Contains("None"))
                    {
                        chkNone.Checked = true;
                    }

                }
                sqlRead.Close();
                sqlConnection2.Close();
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string Username = Session["Username"].ToString();
            string gradesTaught = "";
            String sqlUpdate = "UPDATE OrgRep SET FName = @FirstName, LName = @LastName, Email = @Email, " +
              "PhoneNumber = @Phone, GradesTaught = @GradesTaught, Code = @Code, LunchTicket = @LunchTicket " +
              "WHERE Username =  " + Username + "";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtOrgRepFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtOrgRepLN.Text));
            sqlCommand.Parameters.AddWithValue("@Code", HttpUtility.HtmlEncode(txtCode.Text));
            sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtOrgRepPhone.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtOrgRepEmail.Text));

            if (chkElementary.Checked)
            {
                gradesTaught = gradesTaught + " Elementary ";
            }
            if (chkSixth.Checked)
            {
                gradesTaught = gradesTaught + " Sixth ";
            }
            if (chkSeventh.Checked)
            {
                gradesTaught = gradesTaught + " Seventh ";
            }
            if (chkEight.Checked)
            {
                gradesTaught = gradesTaught + " Eighth ";
            }
            if (chkHighSchool.Checked)
            {
                gradesTaught = gradesTaught + " High School ";
            }
            if (chkNone.Checked)
            {
                gradesTaught = gradesTaught + " None ";
            }


            sqlCommand.Parameters.AddWithValue("@GradesTaught", gradesTaught);

            int lunchTicket = 0;
            if (chkLunch.Checked == true)
            {
                lunchTicket = 1;
            }
            sqlCommand.Parameters.AddWithValue("@LunchTicket", lunchTicket);


            sqlConnection.Open();

            adapter.UpdateCommand = sqlCommand;
            adapter.UpdateCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            sqlConnection.Close();

            tblConfirmation.Visible = true;

        }
    }
}