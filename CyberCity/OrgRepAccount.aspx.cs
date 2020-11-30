using System;
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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;


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

        // generates random number for password
        private int RandomNumber(int min, int max)
        {
            Random rn = new Random();
            return rn.Next(min, max);
        }

        // generate random string for password
        private string RandomString(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random rd = new Random();
            char value;
            for (int i = 0; i < length; i++)
            {
                value = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65)));
                sb.Append(value);
            }

            return sb.ToString();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // generates random password
            StringBuilder sb = new StringBuilder();
            sb.Append(RandomNumber(10, 199));
            sb.Append(RandomString(7));


            SqlConnection sqlConnection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CYBERCITY"].ConnectionString.ToString());


            // Tests if the username is available
            String sqlQuery3 = "Select Count(1) from [Person] where [Username] = @Username";

            SqlCommand sqlCommand1 = new SqlCommand(sqlQuery3, sqlConnection1);

            sqlCommand1.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsernme.Text));

            sqlConnection1.Open();

            int userNameCount = Convert.ToInt32(sqlCommand1.ExecuteScalar());

            sqlConnection1.Close();

            String sqlQuery4 = "Select Count(1) from [OrgRep] where [Code] = @Code";
            SqlCommand sqlCommand2 = new SqlCommand(sqlQuery4, sqlConnection2);
            sqlCommand2.Parameters.AddWithValue("@Code", HttpUtility.HtmlEncode(txtCode.Text));
            sqlConnection2.Open();
            int codeCount = Convert.ToInt32(sqlCommand2.ExecuteScalar());
            sqlConnection2.Close();

            if (userNameCount == 0 && codeCount == 0)
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
                createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username, @Email, 'OR')";
                createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtOrgRepFN.Text)));
                createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtOrgRepLN.Text)));
                createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(txtOrgRepEmail.Text)));
                createUser.ExecuteNonQuery();

                System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                setPass.Connection = sc;
                // INSERT PASSWORD RECORD AND CONNECT TO USER
                setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(sb.ToString())))); // hash entered password
                setPass.ExecuteNonQuery();

                sc.Close();

                //Sends email to user with login credentials
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("cybercityjmu1@gmail.com");
                msg.To.Add(txtOrgRepEmail.Text);
                msg.Subject = "Cyber Day Credentials For " + txtOrgRepFN.Text + ' ' + txtOrgRepLN.Text;
                string emailBody = "Welcome to CyberDay! You are receiving this email because you have been added as an Organizational Representative for the Cyber Day. <br/><br/> Your Login Credentials can be found below.<br/><br/> Login Details <br/><b> Username:</b> " + txtUsernme.Text + " <br/><b>Password:</b> " + sb.ToString();
                emailBody += "<br/> <br/> Please click the link below to view/edit your profile and change your password if necessary. <br/><br/>Note: it is STRONGLY Encouraged to change your password.";
                emailBody += "<br/><br/><a href='http://cybercity-dev.us-east-1.elasticbeanstalk.com/Login.aspx'>Login Here</a>";
                msg.Body = emailBody;
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(msg);
                msg.Dispose();


                txtCode.Text = "";
                txtOrgRepEmail.Text = "";
                txtOrgRepFN.Text = "";
                txtOrgRepLN.Text = "";
                txtUsernme.Text = "";

                confirmationlbl.Text = "Organizatational Representative Created Sucessfully!";
                confirmationlbl.ForeColor = Color.Green;
                confirmationlbl.Visible = true;
                lblEmailSuccess.Visible = true;

            }
            else if (userNameCount != 0)
            {
                confirmationlbl.Text = "Username already exists please select a new one!";
                confirmationlbl.ForeColor = Color.Red;
                confirmationlbl.Visible = true;
                lblEmailSuccess.Visible = false;
            } else if (codeCount != 0)
            {
                confirmationlbl.Text = "Org Rep Code already exists please select a new one!";
                confirmationlbl.ForeColor = Color.Red;
                confirmationlbl.Visible = true;
                lblEmailSuccess.Visible = false;
            }
           
        }
    }
}