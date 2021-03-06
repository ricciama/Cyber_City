﻿using System;
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
    public partial class EditOrgRep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Forces a user to login before accessing this page
            if (Session["UserType"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if (Session["UserType"].ToString() != "C")
            {
                Response.Redirect("HomePage.aspx");
            }

            if (!IsPostBack)
            {
                EditInfo.Visible = false;
                String sqlQuery2 = "Select OrgRepID, FName + ' ' + LName as Name from OrgRep order by OrgRepID";
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
                                item.Value = sdr["OrgRepID"].ToString();
                                ddlOrgReps.Items.Add(item);
                            }
                        }
                        con.Close();
                    }
                }

            }
        }

     
      
        protected void btnCommitEdits_Click(object sender, EventArgs e)
        {
            string orgRepId = ddlOrgReps.SelectedValue.ToString();
            String sqlUpdate = "UPDATE OrgRep SET [FName] = @FirstName, [LName] = @LastName, [Email] = @Email, " +
              "[PhoneNumber] = @Phone, [OrganizationID] = @OrganizationID, [LunchTicket] = @LunchTicket " +
              "WHERE OrgRepID =  " + orgRepId + "";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtOrgRepFN.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtOrgRepLN.Text));            
            sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtOrgRepPhone.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtOrgRepEmail.Text));
            sqlCommand.Parameters.AddWithValue("@OrganizationID", HttpUtility.HtmlEncode(ddlOrgName.SelectedValue));


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
            ddlOrgReps.SelectedIndex = -1;
            tblConfirmation.Visible = true;
        }

        protected void ddlOrgReps_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditInfo.Visible = true;

            String sqlQuery2 = "Select Name, OrganizationID from Organization order by OrganizationID";
            String sqlConnection2 = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;

            ddlOrgName.Items.Clear();
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
                            ddlOrgName.Items.Add(item);
                        }
                    }
                    con.Close();
                }
            }
            string gradeTaught = "";
            string orgRepId = ddlOrgReps.SelectedValue.ToString();
            string orgRep = "select FName, Lname, Email, PhoneNumber, Code, OrganizationID, LunchTicket, GradesTaught from OrgRep ";
            orgRep += "where OrgRepID = " + orgRepId + "";

            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());

            SqlCommand sqlCommand2 = new SqlCommand(orgRep, sqlConnection3);

            sqlConnection3.Open();

            SqlDataReader sqlRead = sqlCommand2.ExecuteReader();


            while (sqlRead.Read())
            {
                txtOrgRepFN.Text = (sqlRead["FName"].ToString());
                txtOrgRepLN.Text = (sqlRead["LName"].ToString());
                txtOrgRepEmail.Text = (sqlRead["Email"].ToString());
                txtOrgRepPhone.Text = (sqlRead["PhoneNumber"].ToString());
                txtCode.Text= (sqlRead["Code"].ToString());
                ddlOrgName.SelectedValue = (sqlRead["OrganizationID"].ToString());
                int lunch = Int32.Parse(sqlRead["LunchTicket"].ToString());
                gradeTaught = (sqlRead["GradesTaught"].ToString());
                
                if (lunch == 1)
                {
                    chkLunch.Checked = true;
                }
                else
                {
                    chkLunch.Checked = false;
                }

               
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
            
            sqlRead.Close();
            sqlConnection3.Close();
        }

     
    }

      
    }
