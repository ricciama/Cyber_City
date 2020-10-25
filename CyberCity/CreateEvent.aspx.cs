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
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill Drop down list
            if (!IsPostBack)
            {
                String sqlQuery2 = "Select ProgramID, Name from Program order by ProgramID";
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
                                ddlProgram.Items.Add(item);
                            }
                        }
                        con.Close();
                    }
                }

            }
        }

            protected void btnCreateEvent_Click(object sender, EventArgs e)
            {

            }
        }
    }