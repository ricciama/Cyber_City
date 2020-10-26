using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberCity
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lough1_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.jmu.edu/cob/faculty/all-faculty/lough-shawn.shtml");
        }

        protected void email_Click(object sender, EventArgs e)
        {
            Response.Redirect("mailto:loughsr@jmu.edu?");
        }

        protected void dillonLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.jmu.edu/cob/faculty/all-faculty/dillon-thomas.shtml");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("mailto:dillontw@jmu.edu");
        }
    }
}