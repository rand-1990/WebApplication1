using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class create_subjects : System.Web.UI.Page
    {

        string id = "";
        static string verifier;
        public void showtable(string id)
        {
            var data_current = ClassesManage.getSubjects(id);

            string table = "<table class='table table-sm'>";
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > Title </th>";

            table += "<th scope = 'col' > File or Video path</th>";



            table += "</tr>";
            int num = 0;
            for (int i = 0; i < data_current.Length; i++)
            {
                table += "<tr class='table-primary' id='r"+data_current[i][2]+"'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data_current[i][0].ToString() + "</td>";
                if(data_current[i][1].ToString()=="" && data_current[i][3].ToString()!="")
                    table += "<td><a target='_blank' href='"  + data_current[i][3].ToString() + "'>Video path</a></td>";
                else
                table += "<td><a target='_blank' href='" + "/uploads/" + data_current[i][1].ToString() + "'>Download Attachment</a></td>";
                table += "<td>" + "<a href = 'update_subject.aspx?id=" + data_current[i][2].ToString() + "' class='btn btn-primary'>Edit</a>" + "</td>";
                table += "<td><button type='button' class='btn btn-primary' value='" + data_current[i][2] + "' onclick='deletes(this)'>Delete</button> </td>";
                table += "</tr>";
            }
     
            table_html.InnerHtml = table;
        }
        [WebMethod(true)]

        public static string delete_subject(string id)
        {
            ClassesManage.DeleteSubject(id);
            return "ok";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            verifier = Session["verifier"].ToString();
            var islecture = UserMangement.isLecture(verifier);
            var data = ClassesManage.UserCanAccessToClass(verifier, id);
            if (!(islecture == true && data.Length == 1))
                Response.Redirect("classes_show.aspx");
            showtable(id);
        }

        protected void add_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = subject_file.PostedFile;
            string file_name = "";
            string video = video_path.Value;
            string sub_title = subject_title.Value;

            string classid = Request["id"];
            string userid = UserMangement.getUserID(Session["verifier"].ToString()).ToString();
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
            ClassesManage.add_subjects(sub_title, file_name, classid, userid,video);
            video_path.Value = "";
            subject_title.Value = "";

            showtable(classid);
            //this.Page_Load(null, null);

            msg.Text = "successfully inserted";
        }
    }
}