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
    public partial class EditProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String sqlQuery2 = "Select ProgramID, Name from Program where date >= GETDATE() order by ProgramID";
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
                                item.Value = sdr["ProgramID"].ToString();
                                ddlProgamNames.Items.Add(item);
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        protected void btnEditProgram_Click(object sender, EventArgs e)
        {
            string progID = ddlProgamNames.SelectedValue.ToString();
            string connectionString;
            SqlConnection cnn;
            SqlCommand sqlCommand;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = WebConfigurationManager.ConnectionStrings["CYBERCITY"].ToString();

            cnn = new SqlConnection(connectionString);

            String sql = "UPDATE Program SET [Name] = @Name, [Date] = @Date";
            sql += " WHERE ProgramID = " + progID + "";

            sqlCommand = new SqlCommand(sql, cnn);

            cnn.Open();


            //Inserts the data from the new student page into the database

            sqlCommand.Parameters.AddWithValue("@Name", HttpUtility.HtmlEncode(txtProgramName.Text));
            sqlCommand.Parameters.AddWithValue("@Date", HttpUtility.HtmlEncode(txtProgramDateTime.Text));

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            cnn.Close();
            tblConfirmation.Visible = true;
        }

       

        protected void ddlProgamNames_SelectedIndexChanged(object sender, EventArgs e)
        {

            int progIDint = int.Parse(ddlProgamNames.SelectedValue);
            if(progIDint!=-1)
            {
                btnEditProgram.Visible = true;
                txtProgramName.Visible = true;
                txtProgramDateTime.Visible = true;
                tblConfirmation.Visible = false;

                string progID = ddlProgamNames.SelectedValue.ToString();


                String sqlQuery2 = "Select ProgramID, Name, Date from Program ";
                sqlQuery2 += "where ProgramID = " + progID + "";

                SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberCity"].ConnectionString.ToString());
                SqlCommand sqlCommand2 = new SqlCommand(sqlQuery2, sqlConnection3);

                sqlConnection3.Open();
                SqlDataReader sqlRead = sqlCommand2.ExecuteReader();

                while (sqlRead.Read())
                {
                    txtProgramName.Text = (sqlRead["Name"].ToString());
                    txtProgramDateTime.Text = (sqlRead["Date"].ToString());
                }
                sqlConnection3.Close();
                sqlRead.Close();

            }
            else
            {
                btnEditProgram.Visible = false;
                txtProgramName.Visible = false;
                txtProgramDateTime.Visible = false;
                tblConfirmation.Visible = false;
            }
          
        }
    }
}