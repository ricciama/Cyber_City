using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberCity
{
    public partial class EditVolunteer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (!IsPostBack)
                {
                    EditInfo.Visible = false;
                    String sqlQuery2 = "Select VolunteerID, FName + ' ' + LName as Name from Volunteer order by VolunteerID";
                    String sqlConnection2 = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(sqlConnection2))
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlQuery2))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Name"].ToString();
                                    item.Value = sdr["VolunteerID"].ToString();
                                    ddlVolunteers.Items.Add(item);
                                }
                            }
                            con.Close();
                        }
                    }

                }
            }

        protected void ddlVolunteers_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditInfo.Visible = true;           
          
            string volunteerID = ddlVolunteers.SelectedValue.ToString();
            string volunteer = "select FName, Lname, Email, Phone, Gender, UserName, LunchTicket, TShirtSize from Volunteer ";
            volunteer += "where VolunteerID = " + volunteerID + "";

            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            SqlCommand sqlCommand2 = new SqlCommand(volunteer, sqlConnection3);

            sqlConnection3.Open();

            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();


            while (sqlRead.Read())
            {
                txtVolunteerFN.Text = (sqlRead["FName"].ToString());
                txtVolunteerLN.Text = (sqlRead["LName"].ToString());
                txtVolunteerEmail.Text = (sqlRead["Email"].ToString());
                txtVolunteerPhone.Text = (sqlRead["Phone"].ToString());
                ddlShirtSize.SelectedValue = (sqlRead["TShirtSize"].ToString());
                ddlGender.SelectedValue = (sqlRead["Gender"].ToString());
                txtUserName.Text= (sqlRead["UserName"].ToString());
                int lunch = Int32.Parse(sqlRead["LunchTicket"].ToString());


                if (lunch == 1)
                {
                    chkLunch.Checked = true;
                }
                else
                {
                    chkLunch.Checked = false;
                }


            }
          

            sqlRead.Close();
            sqlConnection3.Close();
        }

        protected void btnCommitEdits_Click(object sender, EventArgs e)
        {
            string volunteerID = ddlVolunteers.SelectedValue.ToString();
            String sqlUpdate = "UPDATE Volunteer SET [FName] = @FirstName, [LName] = @LastName, [Email] = @Email, " +
              "[Phone] = @Phone, [Gender] = @Gender, [LunchTicket] = @LunchTicket, [TShirtSize] = @TShirtSize  " +
              "WHERE VolunteerID =  " + volunteerID + "";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtVolunteerFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtVolunteerLN.Text));
            sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtVolunteerPhone.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtVolunteerEmail.Text));
            sqlCommand.Parameters.AddWithValue("@Gender", HttpUtility.HtmlEncode(ddlGender.SelectedValue));
            sqlCommand.Parameters.AddWithValue("@TShirtSize", HttpUtility.HtmlEncode(ddlShirtSize.SelectedValue));


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
            EditInfo.Visible = false;
            ddlVolunteers.SelectedIndex = -1;
            tblConfirmation.Visible = true;
        }
    }
}