using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class send_answer : System.Web.UI.Page
    {
        string id = "";
        static string verifier;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            verifier = Session["verifier"].ToString();
            if (!UserMangement.isStudent(verifier))
                Response.Redirect("classes_show.aspx");
            var data = ClassesManage.getAssiementByID(id);
            if (data.Length == 0)
                Response.Redirect("classes_show.aspx");
            assiement_file.HRef="/uploads/"+data[0][1].ToString();
            assiement_file.InnerText = "download assiement file";
            assiement_title.InnerText = data[0][0].ToString();
            DateTime dt = DateTime.Parse(data[0][3].ToString());
            var stay = dt.Subtract(DateTime.Now);
            time_end.InnerText = "stay " + stay.Hours + " hours , " + stay.Minutes + " minutes , " + stay.Seconds + " seconds";


        }

        protected void add_Click(object sender, EventArgs e)
        {
            id = Request["id"];
            verifier = Session["verifier"].ToString();
            if (!UserMangement.isStudent(verifier))
                Response.Redirect("classes_show.aspx");
            string userid = UserMangement.getUserID(verifier).ToString();
            HttpPostedFile postedFile = assiement_file_upload.PostedFile;
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
            int v=ClassesManage.add_answer_asssiement(assiement_caption.Value, file_name, id, userid);
            if (v == 0)
                msg.Text = "not send time is end";
            else
                msg.Text = "successfully send answer";
        }
    }
}