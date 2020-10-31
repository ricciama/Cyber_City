﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace CyberCity
{
    public partial class OrgRepAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Fills the string program with the session variable if it exists
            string organization = null;
            int organizationID = -1;

            if (Session["Organization"] != null)
            {
                organization = Session["Organization"].ToString();

                String student = "Select OrganizationID from Organization where Name = '" + organization + "'";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(student, sqlConnection2);

                sqlConnection2.Open();

                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {

                    organizationID = Int32.Parse(sqlRead["OrganizationID"].ToString());
                }
                sqlRead.Close();
                sqlConnection2.Close();
            }



            //fill Drop down list
            if (!Page.IsPostBack)
            {
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
                                ddlOrgName.Items.Add(item);
                            }
                        }
                        con.Close();
                    }
                }
            }

            if (Session["Organization"] != null)
            {
                ddlOrgName.SelectedIndex = organizationID + 1;
            }

            Session["Organization"] = null;
        }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int errorCheck = 0;


        SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());


        // Tests if the username is available
        String sqlQuery3 = "Select Count(1) from [Person] where [Username] = @Username";

        SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

        sqlCommand1.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsernme.Text));

        sqlConnection1.Open();

        int userNameCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

        sqlConnection1.Close();

        if (errorCheck == 0)
        {

            string connectionString;
            SqlConnection cnn;
            SqlCommand sqlCommand;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

            cnn = new SqlConnection(connectionString);

            String sql = "Insert into [OrgRep] (FName, LName, Email, OrganizationID, Code, Username) " +
                "Values (@FName, @LName, @Email, @OrganizationID, @Code, @Username)";

            sqlCommand = new SqlCommand(sql, cnn);

            cnn.Open();


            //Inserts the data from the new student page into the database

            sqlCommand.Parameters.AddWithValue("@FName", HttpUtility.HtmlEncode(txtOrgRepFN.Text));
            sqlCommand.Parameters.AddWithValue("@LName", HttpUtility.HtmlEncode(txtOrgRepLN.Text));
            sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtOrgRepEmail.Text));
            sqlCommand.Parameters.AddWithValue("@OrganizationID", HttpUtility.HtmlEncode(ddlOrgName.SelectedItem.Value));
            sqlCommand.Parameters.AddWithValue("@Code", HttpUtility.HtmlEncode(txtCode.Text));
            sqlCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsernme.Text));

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            cnn.Close();

            SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            sc.Open();

            SqlCommand createUser = new SqlCommand();
            createUser.Connection = sc;
            // INSERT USER RECORD
            createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username, 'OR')";
            createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtOrgRepFN.Text)));
            createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtOrgRepLN.Text)));
            createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
            createUser.ExecuteNonQuery();

            System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
            setPass.Connection = sc;
            // INSERT PASSWORD RECORD AND CONNECT TO USER
            setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
            setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
            setPass.Parameters.Add(new SqlParameter("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(txtPassword.Text)))); // hash entered password
            setPass.ExecuteNonQuery();

                txtCode.Text = "";
                txtOrgRepEmail.Text = "";
                txtOrgRepFN.Text = "";
                txtOrgRepLN.Text = "";
                txtUsernme.Text = "";

            sc.Close();

                confirmationlbl.Text = "Organizatational Representative Created Sucessfully!";
                confirmationlbl.ForeColor = Color.Green;
                confirmationlbl.Visible = true;

            } else if (errorCheck != 0)
            {
                confirmationlbl.Text = "Username already exists please select a new one!";
                confirmationlbl.ForeColor = Color.Red;
                confirmationlbl.Visible = true;
            }
           
        }
    }
}