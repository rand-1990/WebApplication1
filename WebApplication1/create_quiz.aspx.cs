using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class create_quiz : System.Web.UI.Page
    {

        public static string create_table_view(string classid)
        {

            var data = ClassesManage.getAllQuizInclass(classid);
            string table = "<table class='table table-sm'>";
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > Title </th>";

            table += "<th scope = 'col' > Num of questions </th>";
            table += "<th scope = 'col' > Mark </th>";
            table += "<th scope = 'col' > Num of mcq </th>";
            table += "<th scope = 'col' > Mark each mcq</th>";
            table += "<th scope = 'col' > Number T/F </th>";
            table += "<th scope = 'col' > Mark each T/F </th>";
            table += "<th scope = 'col' > Number of Sa </th>";
            table += "<th scope = 'col' > Mark of Sa </th>";
            table += "<th scope = 'col' >Sa details </th>";

            table += "<th scope = col' > Start Date </th>";
            table += "<th scope = col' > End Date </th>";
            table += "<th scope = col' > Create questions </th>";
            table += "<th scope = col' > Show Exam mark </th>";
            table += "<th scope = col' > Show Exam sa </th>";
            table += "<th scope = col' > Update Exam </th>";
            table += "<th scope = col' >  Exam map</th>";


            int num = 0;
             for(int i=0;i<data.Length;i++)
            {
                table += "<tr class='table-primary'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data[i][0] + "</td>";
                table += "<td>" + data[i][1] + "</td>";
                table += "<td>" + data[i][2] + "</td>";
                table += "<td>" + data[i][3] + "</td>";
                table += "<td>" + data[i][4] + "</td>";
                table += "<td>" + data[i][5] + "</td>";
                table += "<td>" + data[i][6] + "</td>";
                table += "<td>" + data[i][7] + "</td>";
                table += "<td>" + data[i][8] + "</td>";
                table += "<td>" + data[i][14] + "</td>";

                table += "<td>" + data[i][9] + "</td>";
                table += "<td>" + data[i][10] + "</td>";

                table += "<td><a href='create_questions.aspx?id="+data[i][13]+"'>create</a></td>";
                //show_answer_quiz
                table += "<td><a href='show_answer_quiz.aspx?id=" + data[i][13] + "'>show</a></td>";
                table += "<td><a href='show_answer_sa.aspx?id=" + data[i][13] + "'>show</a></td>";
                //  table += "<td><a href='update_quiz.aspx?id=" + data[i][13] + "'>show</a></td>";
                table += "<td><a href='update_quiz.aspx?id=" + data[i][13] + "'>Update</a></td>";
                table += "<td><a href='map.aspx?id=" + data[i][13] + "'>go</a></td>";

                table += "</tr>";
            }
            return table;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            string verifier = Session["verifier"].ToString();
            var islecture = UserMangement.isLecture(verifier);
            var data = ClassesManage.UserCanAccessToClass(verifier, id);
            if (!(islecture == true && data.Length == 1))
                Response.Redirect("classes_show.aspx");
            table_html.InnerHtml = create_table_view(id);

        }

        protected void add_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
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
        //    string mark = (Int32.Parse(mark_sa_)+Int32.Parse(mark_mcq_)+Int32.Parse(mark_tf_)).ToString();
            string sa_desc_ = sa_desc.Value;
            if ((Int32.Parse(num_mcq_)) + Int32.Parse(num_sa_) + Int32.Parse(num_tf_) > Int32.Parse(num_questions))
            {
                lblError.Text = "num mcq + num sa + num t/f must be less than number of questions";
                return;
            }
            double final_mark_mcq = Convert.ToDouble(num_mcq.Value) * Convert.ToDouble(mark_mcq.Value);
            double final_mark_tf= Convert.ToDouble(num_tf.Value) * Convert.ToDouble(mark_tf.Value);
            double final_mark_sa = Convert.ToDouble(mark_sa.Value);
            double all_mark = final_mark_mcq + final_mark_sa + final_mark_tf;
            //double entered_mark = Convert.ToDouble(mark);
         /*   if (Int32.Parse(mark_mcq_) + Int32.Parse(mark_sa_) + Int32.Parse(mark_tf_) > Int32.Parse(mark))
            {
                lblError.Text = "mark mcq + mark sa + mark t/f must be less than mark of questions";
                return;
            }*/
            ClassesManage.add_quiz_info(title, num_questions, all_mark.ToString(), start_date, end_date, id, userid,num_mcq_,num_sa_,num_tf_,mark_mcq_,mark_sa_,mark_tf_,sa_desc_);
            table_html.InnerHtml = create_table_view(id);
            quiz_title.Value = "";
            quiz_num.Value = "";
            quiz_start.Value = "";
            quiz_end.Value = "";
            num_mcq.Value = "";
            num_sa.Value = "";
            num_tf.Value = "";
            mark_sa.Value = "";
            mark_tf.Value = "";
            mark_mcq.Value = "";
            sa_desc.Value = "";


        }
    }
}