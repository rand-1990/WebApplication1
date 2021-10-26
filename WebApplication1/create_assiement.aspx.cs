using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class create_assiement : System.Web.UI.Page
    {
        
        string id =  "";
        static string verifier;
        public  void showtable(string id)
        {
            var data_current = ClassesManage.getCurrentAssiement(id);
            var data_next = ClassesManage.getNextAssiement(id);
            var data_perv = ClassesManage.getArchiveAssiement(id);
            string table = "<table class='table table-sm'>";
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > Title </th>";

            table += "<th scope = 'col' > File </th>";

            table += "<th scope = col' > Start Date </th>";
            table += "<th scope = col' > End Date </th>";
            table += "<th scope = col' > Answer </th>";
            table += "<th scope = col' > Edit </th>";
            table += "<th scope = col' > Delete </th>";


            table += "</tr>";
            int num = 0;
            for (int i = 0; i < data_current.Length; i++)
            {
                table += "<tr class='table-primary'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data_current[i][0].ToString() + "</td>";
                table += "<td><a target='_blank' href='" + "/uploads/" + data_current[i][1].ToString() + "'>download file</a></td>";
                table += "<td>" + data_current[i][2].ToString() + "</td>";
                table += "<td>" + data_current[i][3].ToString() + "</td>";
                table += "<td><a href='show_answer_assiement.aspx?id=" + data_current[i][6].ToString() + "'>show answer</a></td>";
                table += "<td><a class='btn btn-primary' href='update_assiment.aspx?id=" + data_current[i][6].ToString() + "'> update</a></td>";
                table += "<td><a onclick="+"\"return confirm('Are you sure to delete?')\""+"  class='btn btn-danger' href='delete_assiement.aspx?id=" + data_current[i][6].ToString() + "'>delete</a></td>";

                table += "</tr>";
            }
            for (int i = 0; i < data_next.Length; i++)
            {
                table += "<tr class='table-success'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data_next[i][0].ToString() + "</td>";

                table += "<td><a target='_blank' href='" + "/uploads/" + data_next[i][1].ToString() + "'>download file</a></td>";
                table += "<td>" + data_next[i][2].ToString() + "</td>";
                table += "<td>" + data_next[i][3].ToString() + "</td>";
                table += "<td><a href='show_answer_assiement.aspx?id=" + data_next[i][6].ToString() + "'>show answer</a></td>";
                table += "<td><a class='btn btn-primary' href='update_assiment.aspx?id=" + data_next[i][6].ToString() + "'> update</a></td>";
                table += "<td><a onclick="+"\"return confirm('Are you sure to delete?')\""+" class='btn btn-danger' href='delete_assiement.aspx?id=" + data_next[i][6].ToString() + "'>delete</a></td>";

                table += "</tr>";
            }
            for (int i = 0; i < data_perv.Length; i++)
            {
                table += "<tr class='table-secondary'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data_perv[i][0].ToString() + "</td>";
                table += "<td><a target='_blank' href='" + "/uploads/" + data_perv[i][1].ToString() + "'>download file</a></td>";
                table += "<td>" + data_perv[i][2].ToString() + "</td>";
                table += "<td>" + data_perv[i][3].ToString() + "</td>";
                table += "<td><a href='show_answer_assiement.aspx?id=" + data_perv[i][6].ToString() + "'>show answer</a></td>";
                table += "<td><a class='btn btn-primary' href='update_assiment.aspx?id=" + data_perv[i][6].ToString() + "'> update</a></td>";
                table += "<td><a onclick="+"\"return confirm('Are you sure to delete?')\""+" class='btn btn-danger' href='delete_assiement.aspx?id=" + data_perv[i][6].ToString() + "'>delete</a></td>";

                table += "</tr>";
            }
            table_html.InnerHtml = table;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            verifier = Session["verifier"].ToString();
            var islecture=UserMangement.isLecture(verifier);
            var data=ClassesManage.UserCanAccessToClass(verifier, id);
            if (!(islecture == true && data.Length == 1))
                Response.Redirect("classes_show.aspx");
            showtable(id);

        }

        protected void add_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = assiement_file.PostedFile;
            string file_name = "";
            string classid= Request["id"];
            string assim_caption = assiement_caption.Value;
            string assim_start = assiement_start.Value;
            string assim_end = assiement_end.Value;

            string userid = UserMangement.getUserID(Session["verifier"].ToString()).ToString();
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string result = Path.GetRandomFileName();
                string []names = result.Split('.');
                string []file_names = postedFile.FileName.Split('.');
                file_name = names[0] + "." + file_names[1];
                //Save the File.
                string filePath = Server.MapPath("~/uploads/") + file_name;
                postedFile.SaveAs(filePath);
            }
            ClassesManage.add_assiement(assim_caption, file_name, assim_start, assim_end, classid, userid);
            showtable(classid);
            assiement_caption.Value = "";
            assiement_start.Value = "";
            assiement_end.Value ="";

            //this.Page_Load(null, null);

            msg.Text = "successfully inserted";

        }
    }
}