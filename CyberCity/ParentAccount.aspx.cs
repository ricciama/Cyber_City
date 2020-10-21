using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberCity
{
    public partial class ParentAccount : System.Web.UI.Page
    {
        public object WebConfigurationMagager { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

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

                String sql = "Insert into [Student] (StudentFName, StudentLName, ParentFName, ParentLName, ParentEmail, ParentPhone, DOB, Gender, Ethnicity, Username) " +
                    "Values (@StudentFName, @StudentLName, @ParentFName, @ParentLName, @ParentEmail, @ParentPhone, @DOB, @Gender, @Ethnicity, @Username)";

                sqlCommand = new SqlCommand(sql, cnn);

                cnn.Open();


                //Inserts the data from the new student page into the database

                sqlCommand.Parameters.AddWithValue("@StudentFName", HttpUtility.HtmlEncode(txtStudentFN.Text));
                sqlCommand.Parameters.AddWithValue("@StudentLName", HttpUtility.HtmlEncode(txtStudentLN.Text));
                sqlCommand.Parameters.AddWithValue("@ParentFName", HttpUtility.HtmlEncode(txtParentFN.Text));
                sqlCommand.Parameters.AddWithValue("@ParentLName", HttpUtility.HtmlEncode(txtParentLN.Text));
                sqlCommand.Parameters.AddWithValue("@ParentEmail", HttpUtility.HtmlEncode(txtParentEmail.Text));
                sqlCommand.Parameters.AddWithValue("@ParentPhone", HttpUtility.HtmlEncode(txtParentPhone.Text));
                sqlCommand.Parameters.AddWithValue("@DOB", HttpUtility.HtmlEncode(txtStudentDOB.Text));
                sqlCommand.Parameters.AddWithValue("@Gender", HttpUtility.HtmlEncode(ddlGender.SelectedValue));
                sqlCommand.Parameters.AddWithValue("@Ethnicity", HttpUtility.HtmlEncode(ddlEthnicity.SelectedValue));
                sqlCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsernme.Text));


                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                cnn.Close();

                SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                sc.Open();

                SqlCommand createUser = new SqlCommand();
                createUser.Connection = sc;
                // INSERT USER RECORD
                createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username, 'V')";
                createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtStudentFN.Text)));
                createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtStudentLN.Text)));
                createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                createUser.ExecuteNonQuery();

                System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                setPass.Connection = sc;
                // INSERT PASSWORD RECORD AND CONNECT TO USER
                setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsernme.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(txtPassword.Text)))); // hash entered password
                setPass.ExecuteNonQuery();

                sc.Close();
            }
        }
    }
}