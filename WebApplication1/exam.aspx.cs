using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class exam : System.Web.UI.Page
    {

        public static string getUserid()
        {
            string verifier = HttpContext.Current.Session["verifier"].ToString();
            string userid = UserMangement.getUserID(verifier).ToString();
            return userid;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            string userid = getUserid();
            var temp_data = ClassesManage.CheckUserIFCompletQuiz(id, userid);
            if (temp_data.Length == 1)
            {
                Response.Redirect("classes_show.aspx");
            }
            string classid = ClassesManage.GetclassidByQuizId(id);
            string verifier = Session["verifier"].ToString();
            var islecture = UserMangement.isStudent(verifier);
            var data = ClassesManage.UserCanAccessToClass(verifier, classid);
            if (!(islecture == true && data.Length == 1))
                Response.Redirect("classes_show.aspx");
            var quetions = ClassesManage.getAllQuestionsfromQUIZ(id,"yes");
            // table_html.InnerHtml = create_table_view(id);
            string html = "<center><p style='font-size:x-large;color:white' id='demo'></p></center>";
            html += "<div class='wrapper'>";
            string ids = "";
            for (int i = 0; i < quetions.Length; i++)
            {
                if (i != 0)
                    //left: 650px
                    html += "<div class='wrap' style='left: 650px' id='q" + (quetions[i][8]) + "'/>";

                else
                    html += "<div class='wrap' style='left: 15px' id='q" + (quetions[i][8]) + "'/>";
                if (ids == "")
                    ids += quetions[i][8];
                else
                    ids += "," + quetions[i][8];
                html += "<div class='text-center pb-4'>";
                html += "<div class='h5 font-weight-bold'><span id = 'number' > </ span > " + (i + 1) + " of " + quetions.Length + " </div>";
                html += "</div>";
                html += "<div class='h4 font-weight-bold'>" + (i + 1) + "." + " " + quetions[i][0] + "</div>";
                html += "<div class='pt-4'>";
                html += "<label class='options'>" + quetions[i][1] + "<input value='1' type='radio' name='r" + quetions[i][8] + "' id='r" + quetions[i][8] + "'/>";
                html += " <span class='checkmark'>";
                html += " </span> ";
                html += "</label>";
                html += "<label class='options'>" + quetions[i][2] + "<input value='2' type='radio' name='r" + quetions[i][8] + "' id='r" + quetions[i][8] + "'/>";
                html += " <span class='checkmark'>";
                html += " </span> ";
                html += "</label>";
                if (quetions[i][9].ToString() == "1")
                {
                    html += "<label class='options'>" + quetions[i][3] + "<input value='3' type='radio' name='r" + quetions[i][8] + "' id='r" + quetions[i][8] + "'/>";
                    html += " <span class='checkmark'>";
                    html += " </span> ";
                    html += "</label>";
                    html += "<label class='options'>" + quetions[i][4] + "<input value='4' type='radio' name='r" + quetions[i][8] + "' id='r" + quetions[i][8] + "'/>";
                    html += " <span class='checkmark'>";
                    html += " </span> ";
                    html += "</label>";
                }
                html += "</div>";
                html += "<div class='d-flex justify-content-end pt-2'>";

                if (i + 1 != quetions.Length)
                {
                    html += " <button value='n" + quetions[i][8] + "' onclick='next(this)' class='btn btn-primary' id='next" + quetions[i + 1][8] + "'>";
                    html += "Next <span class='fas fa-arrow-right'></span> </button> ";
                    html += "<input type='hidden' value='q" + quetions[i + 1][8] + "' id='n" + quetions[i][8] + "'/>";
                }
                if (i != 0)
                {
                    html += "<button  class='btn btn-primary mx-3' id='back1' value='p" + quetions[i][8] + "' onclick='perv(this)'><span class='fas fa-arrow-left pr-1'></span>Previous </button>";
                    html += "<input type='hidden' value='q" + quetions[i - 1][8] + "' id='p" + quetions[i][8] + "'/>";

                }
                html += "</div></div>";
            }
            html += "<input type='hidden' id='all_questions' value='" + ids + "'/>";
            string time = ClassesManage.getEndQuiz(id);
            html += "<input type='hidden' id='end_date' value='" + time + "'/>";
            html += "</div>";
            html += "   <center>      <input type='buuton' onclick='end_exam()' value='end exam' class='btn btn-primary' /></center>";
            html += "<div class='d-flex flex-column align-items-center'>";
            html += "<div class='h3 font-weight-bold text-white'>Go Dark</div> <label class='switch'> <input type = 'checkbox' > <span class='slider round'></span> </label>";
            html += "</div>";
            all_html.InnerHtml = html;
        }
        [WebMethod(true)]

        public static string SendResponse(string quizid, string data,string lat,string lng)
        {
            string[] response = data.Split(',');

            string userid = getUserid();
            var temp_data = ClassesManage.CheckUserIFCompletQuiz(quizid, userid);
            if (temp_data.Length == 1)
            {
                return "-1";
            }
            int num_correct_mcq = 0;
            int num_correct_tf = 0;
            for (int i=0;i<response.Length;i++)
            {
                string[] question_reply = response[i].Split(':');
                string questionid = question_reply[0];
                string answer = question_reply[1];
               string get_quizid=  ClassesManage.getQuizIdByQuestionId(questionid);
                string get_question_type = ClassesManage.getQuestionTypeByQuestionId(questionid);
                if (get_quizid==quizid)
                {
                  string correct=  ClassesManage.GetCorrectChoice(questionid);
                    if (answer == correct)
                    {   if (get_question_type == "1")
                            num_correct_mcq = num_correct_mcq + 1;
                        else
                            num_correct_tf = num_correct_tf + 1;
                    }
                }
            }
            var mark_mcq = Convert.ToDouble(ClassesManage.GetQuizMarkMcq(quizid));
            var mark_tf= Convert.ToDouble(ClassesManage.GetQuizMarkTF(quizid));
            var num_mcq= Convert.ToDouble(ClassesManage.GetQuizNumMcq(quizid));
            var num_tf= Convert.ToDouble(ClassesManage.GetQuizNumTf(quizid));

            //float num_per_mcq = mark_mcq / num_mcq;
            //float num_per_tf = 0;
            //if (num_tf!=0)
            // num_per_tf = mark_tf / num_tf;
            //string mark_mcq_final = (num_correct_mcq * num_per_mcq).ToString();
            //string mark_tf_final = (num_correct_tf * num_per_tf).ToString();
            //float final_mark = (num_correct_mcq * num_per_mcq) + (num_correct_tf * num_per_tf);

            float num_per_mcq = 0;
           // if (num_mcq != 0)
             //   num_per_mcq = (float)mark_mcq / num_mcq;

            string mark_mcq_final = (num_correct_mcq * mark_mcq).ToString();
            float num_per_tf = 0;
           // if (num_tf != 0)
             //   num_per_tf =(float) mark_tf / num_tf;
            string mark_tf_final = (num_correct_tf * mark_tf).ToString();
            var final_mark = (num_correct_mcq * mark_mcq) + (num_correct_tf * mark_tf);

            //int num_question= Int32.Parse(ClassesManage.GetQuizNumQUestion(quizid));
            //float num_mark_per_question = mark / num_question;
            // float final_mark = num_mark_per_question * num_correct;
            ClassesManage.addQuizResultMcqAndTF(quizid, userid, mark_mcq_final, mark_tf_final,lat,lng);
            return final_mark.ToString();

        }
    }
}