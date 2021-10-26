using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class create_questions : System.Web.UI.Page
    {
        public static string create_table_view(string quiz_id)
        {

            var data = ClassesManage.getAllQuestionsfromQUIZ(quiz_id);
            string table = "<div id='all_table'><table class='table table-sm'>";
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > question </th>";

            table += "<th scope = 'col' > choice1 </th>";
            table += "<th scope = 'col' > choice2 </th>";
            table += "<th scope = 'col' > choice3 </th>";
            table += "<th scope = 'col' > choice4 </th>";
            table += "<th scope = 'col' > right choice </th>";

            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                table += "<tr  class='table-primary' id=r"+data[i][8]+">";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td id='mcq_q_"+data[i][8]+"'>" + data[i][0] + "</td>";
                table += "<td id='mcq_ch1_"+data[i][8]+"'>" + data[i][1] + "</td>";
                table += "<td id='mcq_ch2_" + data[i][8] + "'>" + data[i][2] + "</td>";
                table += "<td id='mcq_ch3_" + data[i][8] + "'>" + data[i][3] + "</td>";
                table += "<td id='mcq_ch4_" + data[i][8] + "'>" + data[i][4] + "</td>";
                table += "<td id='mcq_right_" + data[i][8] + "'>" + data[i][5] + "</td>";
                table += "<td><button class='btn btn-primary' value='" + data[i][8] + "' onclick='deleteq(this)'>delete</button> </td>";
                table += "<td><button type='button' class='btn btn-primary' value='" + data[i][8] + "' onclick='editmcq(this)'>edit</button> </td>";

                table += "</tr>";
            }
           
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > question </th>";

            table += "<th scope = 'col' > choice1 </th>";
            table += "<th scope = 'col' > choice2 </th>";
     
            table += "<th scope = 'col' > right choice </th>";
            var data_tf = ClassesManage.getAllQuestionsTffromQUIZ(quiz_id);
            for (int i = 0; i < data_tf.Length; i++)
            {
                table += "<tr  class='table-primary' id=r" + data_tf[i][6] + ">";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td id='tf_q_" + data_tf[i][6] + "'>" + data_tf[i][0] + "</td>";
                table += "<td id='tf_ch1_" + data_tf[i][6] + "'>" + data_tf[i][1] + "</td>";
                table += "<td id='tf_ch2" + data_tf[i][6] + "'>" + data_tf[i][2] + "</td>";
                table += "<td id='tf_right_" + data_tf[i][6] + "'>" + data_tf[i][3] + "</td>";
                table += "<td><button class='btn btn-primary' value='" + data_tf[i][6] + "' onclick='deleteq(this)'>delete</button> </td>";
                table += "<td><button type='button' class='btn btn-primary' value='" + data_tf[i][6] + "' onclick='edittf(this)'>edit</button> </td>";

                table += "</tr>";
            }
            table += "</table><hr>";
            table += "</table><hr>";
            table += "<table class='table table-sm'>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > question </th>";
            var data_sa = ClassesManage.getAllQuestionsSAfromQUIZ(quiz_id);
            for (int i = 0; i < data_sa.Length; i++)
            {
                table += "<tr  class='table-primary' id=r" + data_sa[i][1] + ">";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td id='sa_q_" + data_sa[i][1] +"'>"+ data_sa[i][0] + "</td>";
      
                table += "<td><button class='btn btn-primary' value='" + data_sa[i][1] + "' onclick='deletesa(this)'>delete</button> </td>";
                table += "<td><button type='button' class='btn btn-primary' value='" + data_sa[i][1] + "' onclick='editsa(this)'>edit</button> </td>";

                table += "</tr>";
            }
            table += "</table></div>";
            return table;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           string  id = Request["id"];
            string classid = ClassesManage.GetclassidByQuizId(id);
            string verifier = Session["verifier"].ToString();
            var islecture = UserMangement.isLecture(verifier);
            var data = ClassesManage.UserCanAccessToClass(verifier, classid);
            if (!(islecture == true && data.Length == 1))
                Response.Redirect("classes_show.aspx");
            table_html.InnerHtml = create_table_view(id);

        }

        protected void add_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (ClassesManage.checkCanAddQuestionMcq(id) == true)
            {
                string userid = UserMangement.getUserID(Session["verifier"].ToString()).ToString();
                string ques = question.Value;
                string ch1 = choice1.Value;
                string ch2 = choice2.Value;
                string ch3 = choice3.Value;
                string ch4 = choice4.Value;
                string right_ch = right_choice.Value;
                ClassesManage.add_questions_mcq_info(ques, ch1, ch2, ch3, ch4, right_ch, id, userid);
                table_html.InnerHtml = create_table_view(id);
                question.Value = "";
                choice1.Value = "";
                choice2.Value = "";
                choice3.Value = "";
                choice4.Value = "";
                right_choice.Value = "";
            }

        }
        protected void add_tf_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (ClassesManage.checkCanAddQuestionTf(id) == true)
            {
                string userid = UserMangement.getUserID(Session["verifier"].ToString()).ToString();
                string ques = question_tf.Value;
                string ch1 = "true";
                string ch2 = "false";
            
                string right_ch = right_tf.Value;
                ClassesManage.add_questions_tf_info(ques, ch1, ch2, right_ch, id, userid);
                table_html.InnerHtml = create_table_view(id);
                question_tf.Value = "";
           

            }

        }
        protected void add_sa_Click(object sender, EventArgs e)
        {

                string id = Request["id"];
            if (ClassesManage.checkCanAddQuestionSA(id) == true)
            {

                string userid = UserMangement.getUserID(Session["verifier"].ToString()).ToString();
                string ques = question_sa.Value;


               // string right_ch = right_tf.Value;
                ClassesManage.add_questions_sa_info(ques, id, userid);
                table_html.InnerHtml = create_table_view(id);
                question_sa.Value = "";
            }

        }
        protected void edit_mcq_question(object sender, EventArgs e)
        {
  
        }
            [WebMethod(true)]

        public static string delete_questions(string id)
        {
            ClassesManage.DeleteQuestion(id);
            return "ok";
        }
        [WebMethod(true)]

        public static string deletesa(string id)
        {
            ClassesManage.DeleteSa(id);
            return "ok";
        }
        [WebMethod(true)]
        public static string update_mcq(string id,string question,string choice1,string choice2,string choice3,string choice4,string right)
        {
            ClassesManage.Update_mcq(id, question, choice1, choice2, choice3, choice4, right); ;
            return "ok";
        }
        [WebMethod(true)]
        public static string update_tf(string id, string question, string right)
        {
            ClassesManage.Update_tf(id, question, right); ;
            return "ok";
        }
        [WebMethod(true)]

        public static string update_sa(string id, string question)
        {
            ClassesManage.Update_sa(id, question); ;
            return "ok";
        }
    }
}