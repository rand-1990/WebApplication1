using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class class_join : System.Web.UI.Page
    {
        public static string verifier;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["verifier"].ToString() == null)
                Response.Redirect("log.aspx");

        }

        protected void join_Click(object sender, EventArgs e)
        {
            string code_value = code.Value;
            verifier = Session["verifier"].ToString();
            string classid=ClassesManage.GetCLassIDByCode(code_value);
            if (ClassesManage.UserCanAccessToClass(verifier, classid).Length == 1)
                Response.Redirect("class_post.aspx?id=" + classid);
            if (classid == "")
            {
                msg.Text = "Class not found";
                return;
            }
            string userid = UserMangement.getUserID(verifier).ToString();
            ClassesManage.InsertUsersCLasses(classid, userid);
            Response.Redirect("class_post.aspx?id=" + classid);


        }
    }
}