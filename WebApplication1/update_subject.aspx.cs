using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class update_subject : System.Web.UI.Page
    {
        string verifier = "";
        string subject_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                subject_id = Request["id"];
                string classid = ClassesManage.GetClassIDBYSubjectID(subject_id);
                verifier = Session["verifier"].ToString();
                var islecture = UserMangement.isLecture(verifier);
                var data = ClassesManage.UserCanAccessToClass(verifier, classid);
                if (!(islecture == true && data.Length == 1))
                    Response.Redirect("classes_show.aspx");
                var result = ClassesManage.GETSubjectINFOBySubjectID(subject_id);
                subject_title.Value = result[0][0].ToString();
                id_subject.Value = result[0][1].ToString();
                video_path.Value= result[0][2].ToString();
            }
            //showtable(id);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string id = id_subject.Value;
            string subject = subject_title.Value;
            string classid = ClassesManage.GetClassIDBYSubjectID(id);
            string video = video_path.Value;
            HttpPostedFile postedFile = subject_file.PostedFile;
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
                video = "";
            }
            
            ClassesManage.update_subjects(subject_title.Value, file_name, id,video);
            Response.Redirect("create_subjects.aspx?id="+classid);
        }
    }
}