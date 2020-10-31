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
    public partial class RegisterOrgRep : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            //populate pogram drop down
            if (!Page.IsPostBack)
            {
                //String sqlQuery2 = "Select ProgramID, Name from Program";
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
                //                item.Value = sdr["ProgramID"].ToString();
                //                ddlSelectProgram.Items.Add(item);
                //            }
                //        }
                //        con.Close();
                //    }
                //}
                //ddlSelectProgram.Items.Insert(0, new ListItem("Select Program", "0"));

                GetProgram();
                GetOrganization();
                
                
            
            }

            //// populate organization drop down
            //if (!Page.IsPostBack)
            //{
            //    String orgQuery = "Select OrganizationID, Name from Organization";
            //    String orgSql = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;

            //    using (SqlConnection con = new SqlConnection(orgSql))
            //    {
            //        using (SqlCommand cmd = new SqlCommand(orgQuery))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = con;
            //            con.Open();
            //            using (SqlDataReader sdr = cmd.ExecuteReader())
            //            {
            //                while (sdr.Read())
            //                {
            //                    ListItem item = new ListItem();
            //                    item.Text = sdr["Name"].ToString();
            //                    item.Value = sdr["OrganizationID"].ToString();
            //                    ddlSelectOrg.Items.Add(item);
            //                }
            //            }
            //            con.Close();
            //        }
            //    }
            //    ddlSelectOrg.Items.Insert(0, new ListItem("Select Organization", "0"));
            //}

            //// populate org rep drop down
            //int organization = Int32.Parse(ddlSelectOrg.SelectedValue);

            //if (!Page.IsPostBack)
            //{
            //    String orgQuery = "SELECT OrgRep.OrgRepID, OrgRep.FName + ' ' + OrgRep.LName as OrganizationlRep FROM Organization INNER JOIN OrgRep ON Organization.OrganizationID = OrgRep.OrganizationID WHERE OrgRep.OrganizationID = " + organization;
            //    String orgSql = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString;

            //    using (SqlConnection con = new SqlConnection(orgSql))
            //    {
            //        using (SqlCommand cmd = new SqlCommand(orgQuery))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = con;
            //            con.Open();
            //            using (SqlDataReader sdr = cmd.ExecuteReader())
            //            {
            //                while (sdr.Read())
            //                {
            //                    ListItem item = new ListItem();
            //                    item.Text = sdr["Name"].ToString();
            //                    item.Value = sdr["OrgRepID"].ToString();
            //                    ddlSelectOrg.Items.Add(item);
            //                }
            //            }
            //            con.Close();
            //        }
            //    }
            //    ddlSelectOrg.Items.Insert(0, new ListItem("Select Organization", "0"));
            //}



        }
        private void GetProgram()
        {
            String programQuery = "Select ProgramID, Name from Program";
            da2 = new SqlDataAdapter(programQuery, con);
            da2.Fill(ds2);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                ddlSelectProgram.DataSource = ds2;
                ddlSelectProgram.DataTextField = "Name";
                ddlSelectProgram.DataValueField = "ProgramID";
                ddlSelectProgram.DataBind();
                ddlSelectProgram.Items.Insert(0, new ListItem("Select Program", "-1"));
                ddlSelectProgram.SelectedIndex = 0;
            }




        }

        protected void ddl_Event_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds2.Clear();
            string ProgramID;
            string ProgramName;
            ProgramName = ddlSelectProgram.SelectedItem.Text;
            ProgramID = ddlSelectProgram.SelectedValue.ToString();

            if (ProgramID != "-1")
            {
                string eventQuery = "SELECT EventID, Name, ProgramID FROM Event WHERE ProgramID = '" + ProgramID.ToString() + "'";
                da2 = new SqlDataAdapter(eventQuery, con);
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    ddlEvent.DataSource = ds2;
                    ddlEvent.DataTextField = "Name";
                    ddlEvent.DataValueField = "EventID";
                    ddlEvent.DataBind();
                    ddlEvent.Items.Insert(0, new ListItem("Select Event", "-1"));
                    ddlEvent.SelectedIndex = 0;
                }
            }
            else
            {
                ddlEvent.Items.Insert(0, "No Events Available");
                ddlEvent.DataBind();
            }
        }

        private void GetOrganization()
        {
            String orgQuery = "Select OrganizationID, Name from Organization";

            da = new SqlDataAdapter(orgQuery, con);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSelectOrg.DataSource = ds;
                ddlSelectOrg.DataTextField = "Name";
                ddlSelectOrg.DataValueField = "OrganizationID";
                ddlSelectOrg.DataBind();
                ddlSelectOrg.Items.Insert(0, new ListItem("Select Organization", "-1"));
                ddlSelectOrg.SelectedIndex = 0;
            }


        }

        protected void ddl_OrgRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.Clear();
            string OrgID;
            string OrgName;
            OrgName = ddlSelectOrg.SelectedItem.Text;
            OrgID = ddlSelectOrg.SelectedValue.ToString();



            if (OrgID != "-1")
            {
                string orgRepQuery = "SELECT OrgRepID, FName + ' ' + LName AS OrganizationalRep, OrganizationID FROM OrgRep WHERE OrganizationID = '" + OrgID.ToString() + "'";
                da = new SqlDataAdapter(orgRepQuery, con);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlOrgRep.DataSource = ds;
                    ddlOrgRep.DataTextField = "OrganizationalRep";
                    ddlOrgRep.DataValueField = "OrgRepID";
                    ddlOrgRep.DataBind();
                    ddlOrgRep.Items.Insert(0, new ListItem("Select Organizational Rep", "-1"));
                    ddlOrgRep.SelectedIndex = 0;
                }
            }
            else
            {
                ddlOrgRep.Items.Insert(0, "No Organizational Reps Available");
                ddlOrgRep.DataBind();
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}