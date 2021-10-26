using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class show_answer_sa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string quizid = Request["id"];
            string verifier = Session["verifier"].ToString();
            string classid = ClassesManage.getClassIDbyQuizID(quizid);

            string all_data = "";
            if (classid == "")
                Response.Redirect("classes_show.aspx");
            if (!(UserMangement.isLecture(verifier) && ClassesManage.UserCanAccessToClass(verifier, classid).Length == 1))
                Response.Redirect("classes_show.aspx");
            var data = ClassesManage.GetAllAnswerQuizSa(quizid);
            if (data.Length == 0)
                html_data.InnerHtml = "<h3>no answer </h3>";
            else
            {
                all_data += "<ul class='list-group'>";

                for (int i = 0; i < data.Length; i++)
                {
                    all_data += " <li class='list-group-item'>";
                    all_data += "<p>username: " + data[i][3] + "</p>";
                    var sa_ids = data[i][1].ToString().Split(',');
                    var dt = data[i][0].ToString().Replace("<#>", "|").Split('|');

                    for (int j=0;j<sa_ids.Length;j++)
                    {
                        all_data += "<ul class='list-group'>";
                        all_data += " <li class='list-group-item'>";
                        all_data += "<p>question:" + ClassesManage.GetSAquestionBYSAID(sa_ids[j]) + "</p>";
                        all_data += "<p>answer:" + dt[j] + "</p>";
                        all_data += "</li>";
                        all_data += "</ul>";

                    }
                    all_data += "mark from " + ClassesManage.GetQuizMarkSA(quizid) + ":<input type='text' id='m" + data[i][2] + "' value='"+ ClassesManage.GetMarkSaByID(quizid,data[i][2].ToString()) + "'/>";
                    all_data += "<button class='btn btn-primary' value='" + data[i][2]  + "' onclick='save_mark(this)'>save mark</button>";

                    //  all_data += "<p>mark: " + data[i][1] + "</p>";
                    all_data += "</li>";
                }
                all_data += "</ul>";
                html_data.InnerHtml = all_data;
            }
        }
        [WebMethod(true)]

        public static string SendMark(string mark, string userid, string quizid)

        {
            double max_mark_sa = ClassesManage.GetMarkSaByQuizId(quizid);
            if (Convert.ToDouble(mark) > max_mark_sa)
                return "mark must equal or less than : " + max_mark_sa;
            string mark_return = ClassesManage.InsertMarkToSa(mark, userid, quizid);
            return mark_return;
        }
    }
}