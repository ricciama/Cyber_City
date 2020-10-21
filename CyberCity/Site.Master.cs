using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberCity
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (Session["UserType"] == null)
            {
                SPMenu.Visible = false;
                volunteerMenu.Visible = false;
                orgRepMenu.Visible = false;
                MainMenu.Visible = true;

            }
            else if (Session["UserType"].ToString() == "S")
            {
                MainMenu.Visible = false;
                volunteerMenu.Visible = false;
                orgRepMenu.Visible = false;
                SPMenu.Visible = true;
                

            }
            else if (Session["UserType"].ToString() == "V")
            {
                MainMenu.Visible = false;
                orgRepMenu.Visible = false;
                SPMenu.Visible = false;
                volunteerMenu.Visible = true;
                
            }
            else if (Session["UserType"].ToString() == "T")
            {
                MainMenu.Visible = false;
                SPMenu.Visible = true;
                volunteerMenu.Visible = false;
                orgRepMenu.Visible = true;
            }
            

            
        }
    }
}