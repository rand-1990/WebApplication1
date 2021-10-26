using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class delete_assiement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string assiementid = Request["id"];
            string verifier = Session["verifier"].ToString();
            string classid = ClassesManage.getClassIDbyAssiementID(assiementid);
            string all_data = "";
            if (classid == "")
                Response.Redirect("create_assiement.aspx");
            if (!(UserMangement.isLecture(verifier) && ClassesManage.UserCanAccessToClass(verifier, classid).Length == 1))
                Response.Redirect("create_assiement.aspx");
            ClassesManage.DeleteAssiement(assiementid);
            Response.Redirect("create_assiement.aspx?id=" + classid);
        }
    }
}