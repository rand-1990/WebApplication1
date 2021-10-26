using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class update_assiment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string assiementid = Request["id"];
                string verifier = Session["verifier"].ToString();
                string classid = ClassesManage.getClassIDbyAssiementID(assiementid);
                string all_data = "";
                if (classid == "")
                    Response.Redirect("create_assiement.aspx");
                if (!(UserMangement.isLecture(verifier) && ClassesManage.UserCanAccessToClass(verifier, classid).Length == 1))
                    Response.Redirect("create_assiement.aspx");
                var data = ClassesManage.GetAssiementInfo(assiementid);
                assiement_caption.Value = data[0][0].ToString();
                var dt1 = DateTime.Parse(data[0][1].ToString()).ToString("yyyy-MM-ddThh:mm", System.Globalization.CultureInfo.InvariantCulture);
                
                assiement_start.Value = dt1;
                var dt2 = DateTime.Parse(data[0][2].ToString()).ToString("yyyy-MM-ddThh:mm", System.Globalization.CultureInfo.InvariantCulture);

                assiement_end.Value = dt2;


            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string assiementid = Request["id"];
            string caption = assiement_caption.Value;
            string start =DateTime.Parse(assiement_start.Value).ToString("yyyy-MM-dd HH:mm:ss");
            string end = DateTime.Parse(assiement_end.Value).ToString("yyyy-MM-dd HH:mm:ss"); 
            HttpPostedFile postedFile = assiement_file.PostedFile;
            string file_name = "";
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string result = Path.GetRandomFileName();
                string[] names = result.Split('.');
                string[] file_names = postedFile.FileName.Split('.');
                file_name = names[0] + "." + file_names[1];
                //Save the File.
                string filePath = Server.MapPath("~/uploads/") + file_name;
                postedFile.SaveAs(filePath);
            }
            ClassesManage.update_assienemnt(caption, start, end, assiementid, file_name);
            string classid = ClassesManage.getClassIDbyAssiementID(assiementid);

            Response.Redirect("create_assiement.aspx?id=" + classid);

        }
    }
}