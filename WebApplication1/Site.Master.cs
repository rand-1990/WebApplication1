using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string type_user()
        {
            DataBaseConnection dataBase = new DataBaseConnection();
            if ( Session["verifier"] == null)
                Response.Redirect("log.aspx");
            if (UserMangement.isLecture(Session["verifier"].ToString()))
                return "1";
            else if (UserMangement.isStudent(Session["verifier"].ToString()))
                return "2";
            else if (UserMangement.isAdmin(Session["verifier"].ToString()))
                return "3";
            else
                return "";

        }
    }
}