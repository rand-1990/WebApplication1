using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class show_answer_assiement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string assiementid = Request["id"];
            string verifier = Session["verifier"].ToString();
            string classid = ClassesManage.getClassIDbyAssiementID(assiementid);
            string all_data = "";
            if (classid == "")
                Response.Redirect("classes_show.aspx");
            if (!(UserMangement.isLecture(verifier) && ClassesManage.UserCanAccessToClass(verifier,classid).Length==1))
                Response.Redirect("classes_show.aspx");
            var data = ClassesManage.GetAllAnswerAssiement(assiementid);
            if (data.Length == 0)
                html_data.InnerHtml = "<h3>no answer </h3>";
            else
            {
                all_data += "<ul class='list-group'>";

                for (int i = 0; i < data.Length; i++)
                {
                    all_data += " <li class='list-group-item'>";
                    all_data += "<p>username: " + data[i][2] + "</p>";

                    all_data += "<p>title upload: " + data[i][0] + "</p>";
                    all_data += "<a target='_blank' href=/uploads/" + data[i][1] + ">file upload</a>";
                    all_data += "<p id='mark_"+ data[i][5] + "_" + data[i][6] + "'>mark: " + data[i][3] + "</p>";
                    all_data += "<p>upload date: " + data[i][4] + "</p>";
                    all_data += "<input type='number' class='form-control' placeholder ='enter mark' id='u"+data[i][5]+"_a"+data[i][6]+"'/>";
                    all_data += "<button class='btn btn-primary' value='" + data[i][5] + "_" + data[i][6] + "' onclick='save_mark(this)'>save mark</button>";
                    all_data += "</li>";
                }
                all_data += "</ul>";
                html_data.InnerHtml = all_data;
            }

        }
        [WebMethod(true)]

        public static string SendMark(string mark, string userid, string assiementid)

        {
            string mark_return = ClassesManage.InsertMarkToAssiement(mark, userid, assiementid);
            return mark_return;
        }
        }
    }