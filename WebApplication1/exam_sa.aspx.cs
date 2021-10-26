using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class exam_sa : System.Web.UI.Page
    {
        public static string getUserid()
        {
            string verifier = HttpContext.Current.Session["verifier"].ToString();
            string userid = UserMangement.getUserID(verifier).ToString();
            return userid;
        }
        protected void Page_Load(object sender, EventArgs e)
        {    if (!IsPostBack)
            {
                string id = Request["id"];
                string userid = getUserid();
                var temp_data = ClassesManage.CheckUserIFCompletQuiz(id, userid);
                if (temp_data.Length == 1)
                {
                    //    Response.Redirect("classes_show.aspx");
                }
                string classid = ClassesManage.GetclassidByQuizId(id);
                string verifier = Session["verifier"].ToString();
                var islecture = UserMangement.isStudent(verifier);
                var data = ClassesManage.UserCanAccessToClass(verifier, classid);
                if (!(islecture == true && data.Length == 1))
                    Response.Redirect("classes_show.aspx");
                var questions = ClassesManage.getAllQuestionsSAfromQUIZ(id);
                if(questions.Length==0)
                    Response.Redirect("classes_show.aspx");

                string ele = "";
                string ids = "";
                ele += "<center><h1>" + ClassesManage.getSaDEscFromQuiz(id) + "</h1></center>";
                for (int i = 0; i < questions.Length; i++)
                {
                    ele += "<h3>" + questions[i][0] + "</h3>";
                    ele += "<textarea type='text' class='form-control' runat='server' rows=8 cols=100 ID='q" + questions[i][1] + "'></textarea><br>";
                   // ele += "<input runat='server' type='file' class='form-control' ID='f" + questions[i][1] + "'/>";
                    ele += "<hr>";
                    if (ids != "")
                        ids = ids + "," + questions[i][1].ToString();
                    else
                        ids = questions[i][1].ToString();

                }
                ele += "<input  type = 'hidden' ID = 'num_sa' value='" + questions.Length + "'/>";

                ele += "<input  type='hidden' ID='sa_ids' value='" + ids + "'/>";
                html_data.InnerHtml = ele;
            }
        }

        protected void join_Click(object sender, EventArgs e)
        {
            // var num_question = num_sa;
            //var ids = sa_ids.Value.Split(',');

        }
        [WebMethod(true)]

        public static string SendResponse(string quizid, string data,string sa_ids)
        {

            var dt = data.Replace("<#>", "|").Split('|');
            var sa_ids_val = sa_ids.Split(',');
            var userid = getUserid();
            ClassesManage.AddAnswerSa(quizid, userid, data, sa_ids);
            return "ok";

                }  
    }
}