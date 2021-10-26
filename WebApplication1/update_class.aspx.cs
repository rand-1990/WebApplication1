using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class update_class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request["id"];
            string verifier = Session["verifier"].ToString();
            var islecture = UserMangement.isLecture(verifier);
            var data = ClassesManage.UserCanAccessToClass(verifier, id);
            if (!(islecture == true && data.Length == 1))
                Response.Redirect("classes_show.aspx");
           var data_class = ClassesManage.GetClassInfoByClassid(id);
            if(!IsPostBack)
            {
                name.Value = data_class[0][0].ToString();
                descr.Value = data_class[0][1].ToString();
                color.Value = data_class[0][2].ToString();
            }


        }

        protected void update_Click(object sender, EventArgs e)
        {
            string classid = Request["id"];

            string name_ = name.Value;
            string desc_ = descr.Value;
            var color_val = color.Value;
            ClassesManage.UpdateClass(classid,name_, desc_, color_val);
            Response.Redirect("classes_show.aspx");

        }
    }
}