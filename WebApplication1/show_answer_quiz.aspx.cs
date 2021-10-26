using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class show_answer_quiz : System.Web.UI.Page
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
            var data = ClassesManage.GetAllAnswerQuiz(quizid);
            if (data.Length == 0)
                html_data.InnerHtml = "<h3>no answer </h3>";
            else
            {
                all_data += "<ul class='list-group'>";

                for (int i = 0; i < data.Length; i++)
                {
                    all_data += " <li class='list-group-item'>";
                    all_data += "<p>username: " + data[i][0] + "</p>";

                    all_data += "<p>mark mcq: " + data[i][1] + "</p>";
                    all_data += "<p>mark tf: " + data[i][2] + "</p>";
                    all_data += "<p>mark sa: " + data[i][3] + "</p>";
                    double final_mark = 0;
                    for (int j = 1; j < 4; j++)
                        if (data[i][j] != DBNull.Value)
                            final_mark += Convert.ToDouble(data[i][j]);
                    all_data += "<p>final mark: " +final_mark.ToString() + "</p>";

                    all_data += "</li>";
                }
                all_data += "</ul>";
                html_data.InnerHtml = all_data;
            }
        }
    }
}