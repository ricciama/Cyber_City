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
                tblDeleteConfirmation.Visible = false;
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
            EditInfo.Visible = true;
            tblDeleteConfirmation.Visible = false;
            string orgId = ddlOrgs.SelectedValue.ToString();
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
                    txtOrgContact.Text=(sqlRead["PrimaryContactName"].ToString());
                    txtOrgPhone.Text = (sqlRead["PhoneNumber"].ToString());
                    txtOrgEmail.Text = (sqlRead["Email"].ToString());

                }
                sqlRead.Close();
                sqlConnection3.Close();
            }

        }
            
             

        
        protected void btnDeleteOrg_Click(object sender, EventArgs e)
        {
            //string orgID = ddlOrgs.SelectedValue.ToString();
            //String sqlUpdate = "DELETE FROM Organization " +
            //  "WHERE OrganizationID =  " + orgID + "";
            //SqlDataAdapter adapter = new SqlDataAdapter();

            //SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            //SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

          
            //sqlConnection.Open();

            //adapter.UpdateCommand = sqlCommand;
            //adapter.UpdateCommand.ExecuteNonQuery();

            //sqlCommand.Dispose();

            //sqlConnection.Close();
            //EditInfo.Visible = false;

            //String sqlQuery2 = "Select OrganizationID, Name from Organization order by OrganizationID";
            //String sqlConnection2 = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;

            //using (SqlConnection con = new SqlConnection(sqlConnection2))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sqlQuery2))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = con;
            //        con.Open();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            while (sdr.Read())
            //            {
            //                ListItem item = new ListItem();
            //                item.Text = sdr["Name"].ToString();
            //                item.Value = sdr["OrganizationID"].ToString();
            //                ddlOrgs.Items.Add(item);
            //            }
            //        }
            //        con.Close();
            //    }
            //}

            //tblDeleteConfirmation.Visible = true;
        }

        protected void ddlOrgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orgId = ddlOrgs.SelectedValue.ToString();
            int orgIdInt = int.Parse(ddlOrgs.SelectedValue);

            if (orgIdInt != -1)
            {
                EditInfo.Visible = true;
                tblDeleteConfirmation.Visible = false;

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
                tblDeleteConfirmation.Visible = false;
                tblConfirmation.Visible = false;
            }
           
        }
    }
}