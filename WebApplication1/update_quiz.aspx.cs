using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class update_quiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string quizid = Request["id"];
            string verifier = Session["verifier"].ToString();
            string classid = ClassesManage.getClassIDbyQuizID(quizid);
            string all_data = "";
            if (classid == "")
                Response.Redirect("create_quiz.aspx?id="+classid);
            if (!(UserMangement.isLecture(verifier) && ClassesManage.UserCanAccessToClass(verifier, classid).Length == 1))
                Response.Redirect("create_quiz.aspx?id=" + classid);
           
          if (ClassesManage.GetAllAnswerQuiz(quizid).Length>0||ClassesManage.getAllQuestionsfromQUIZ(quizid,"all").Length>0||ClassesManage.getAllQuestionsSAfromQUIZ(quizid).Length>0)
                Response.Redirect("create_quiz.aspx?id=" + classid);

            if (!IsPostBack)
            {
                var data = ClassesManage.GetQuizInfoByID(quizid);
                if (data.Length == 1)
                {
                    quiz_title.Value = data[0][0].ToString();
                    quiz_num.Value = data[0][1].ToString();
                    sa_desc.Value = data[0][3].ToString();
                    num_sa.Value = data[0][4].ToString();
                    mark_sa.Value = data[0][5].ToString();
                    num_tf.Value = data[0][6].ToString();
                    mark_tf.Value = data[0][7].ToString();
                    num_mcq.Value = data[0][8].ToString();
                    mark_mcq.Value = data[0][9].ToString();
                    //for forma html and js
                    var start_forma = DateTime.Parse(data[0][10].ToString()).ToString("yyyy-MM-ddThh:mm", System.Globalization.CultureInfo.InvariantCulture);
                    var start = DateTime.Parse(data[0][10].ToString());
                    var end = DateTime.Parse(data[0][11].ToString());

                    //  var end_forma = DateTime.Parse(data[0][10].ToString()).ToString("yyyy-MM-ddThh:mm", System.Globalization.CultureInfo.InvariantCulture);
                    TimeSpan span = end - start;
                    double totalMinutes = span.TotalMinutes;

                    quiz_start.Value = start_forma;
                    quiz_end.Value = totalMinutes.ToString();
                }
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            string classid = ClassesManage.getClassIDbyQuizID(id);

            string userid = UserMangement.getUserID(Session["verifier"].ToString()).ToString();
            string title = quiz_title.Value;
            string num_questions = quiz_num.Value;

            string start_date = quiz_start.Value;
            string end_date = quiz_end.Value;
            string num_mcq_ = num_mcq.Value;
            string num_sa_ = num_sa.Value;
            string num_tf_ = num_tf.Value;
            string mark_sa_ = mark_sa.Value;
            string mark_tf_ = mark_tf.Value;
            string mark_mcq_ = mark_mcq.Value;
            string mark = (Int32.Parse(mark_sa_) + Int32.Parse(mark_mcq_) + Int32.Parse(mark_tf_)).ToString();
            string sa_desc_ = sa_desc.Value;
            if (Int32.Parse(num_mcq_) + Int32.Parse(num_sa_) + Int32.Parse(num_tf_) > Int32.Parse(num_questions))
            {
                lblError.Text = "num mcq + num sa + num t/f must be less than number of questions";
                return;
            }
            double final_mark_mcq = Convert.ToDouble(num_mcq.Value) * Convert.ToDouble(mark_mcq.Value);
            double final_mark_tf = Convert.ToDouble(num_tf.Value) * Convert.ToDouble(mark_tf.Value);
            double final_mark_sa = Convert.ToDouble(mark_sa.Value);
            double all_mark = final_mark_mcq + final_mark_sa + final_mark_tf;
          /*  if (Int32.Parse(mark_mcq_) + Int32.Parse(mark_sa_) + Int32.Parse(mark_tf_) > Int32.Parse(mark))
            {
                lblError.Text = "mark mcq + mark sa + mark t/f must be less than mark of questions";
                return;
            }*/
            ClassesManage.update_quiz_info(id,title, num_questions, all_mark.ToString(), start_date, end_date, classid, userid, num_mcq_, num_sa_, num_tf_, mark_mcq_, mark_sa_, mark_tf_, sa_desc_);
            Response.Redirect("create_quiz.aspx?id=" + classid);
        }
    }
}