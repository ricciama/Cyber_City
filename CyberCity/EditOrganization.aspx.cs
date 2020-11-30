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
    public partial class EditOrganization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EditInfo.Visible = false;
               
                String sqlQuery2 = "Select OrganizationID, Name from Organization order by OrganizationID";
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
                                item.Value = sdr["OrganizationID"].ToString();
                                ddlOrgs.Items.Add(item);
                            }
                        }
                        con.Close();
                    }
                }

            }
        }

        protected void editOrg_Click(object sender, EventArgs e)
        {
            string orgID = ddlOrgs.SelectedValue.ToString();
            string connectionString;
            SqlConnection cnn;
            SqlCommand sqlCommand;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

            cnn = new SqlConnection(connectionString);

            String sql = "UPDATE Organization SET [Name] = @Name, [Address] = @Address, [Email] = @Email";
            sql += ", [PrimaryContactName] = @PrimaryContactName, [PhoneNumber] = @PhoneNumber";
            sql += " WHERE OrganizationID = " + orgID + "";

            sqlCommand = new SqlCommand(sql, cnn);

            cnn.Open();


            //Inserts the data from the new student page into the database

            sqlCommand.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtOrgName.Text));
            sqlCommand.Parameters.AddWithValue("@Address", HttpUtility.HtmlEncode(txtOrgAddress.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtOrgEmail.Text));
            sqlCommand.Parameters.AddWithValue("@PrimaryContactName", HttpUtility.HtmlEncode(txtOrgContact.Text));
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", HttpUtility.HtmlEncode(txtOrgPhone.Text));


            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            cnn.Close();
            tblConfirmation.Visible = true;
            ddlOrgs.SelectedIndex = -1;
            EditInfo.Visible = false;

        }
            
             

        
      

        protected void ddlOrgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orgId = ddlOrgs.SelectedValue.ToString();
            int orgIdInt = int.Parse(ddlOrgs.SelectedValue);

            if (orgIdInt != -1)
            {
                EditInfo.Visible = true;
              

                string org = "select Address, Name, PrimaryContactName, Email, PhoneNumber, OrganizationID from Organization ";
                org += "where OrganizationID = " + orgId + "";

                SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(org, sqlConnection3);

                sqlConnection3.Open();

                using (SqlDataReader sqlRead = sqlCommand2.ExecuteReader())
                {
                    while (sqlRead.Read())
                    {
                        txtOrgName.Text = (sqlRead["Name"].ToString());
                        txtOrgAddress.Text = (sqlRead["Address"].ToString());
                        txtOrgContact.Text = (sqlRead["PrimaryContactName"].ToString());
                        txtOrgPhone.Text = (sqlRead["PhoneNumber"].ToString());
                        txtOrgEmail.Text = (sqlRead["Email"].ToString());

                    }
                    sqlRead.Close();
                    sqlConnection3.Close();
                }
            }
            else
            {
                EditInfo.Visible = false;
               
                tblConfirmation.Visible = false;
            }
           
        }
    }
}