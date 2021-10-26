using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class my_quiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string classid = Request["id"];
            string verifier = Session["verifier"].ToString();
            string userid = UserMangement.getUserID(verifier).ToString();
            if (!UserMangement.isStudent(verifier))
                Response.Redirect("classes_show.aspx");

            if (ClassesManage.UserCanAccessToClass(verifier, classid).Length == 0)
                Response.Redirect("classes_show.aspx");
            string table = "<table class='table table-sm'>";
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' >Exam Title</th>";
            table += "<th scope = 'col' >MCQ Mark</th>";
            table += "<th scope = col' >True/False Mark</th>";
            table += "<th scope = col' >Short answer Mark</th>";
            table += "<th scope = col' >Final Mark</th>";


            table += "</tr>";
            var data = ClassesManage.GetMyQuiz(classid, userid);
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                double mark_mcq = Convert.ToDouble(data[i][2].ToString()) * Convert.ToDouble(data[i][8].ToString());
                double mark_tf = Convert.ToDouble(data[i][4].ToString()) * Convert.ToDouble(data[i][9].ToString());

                table += "<tr class='table-primary'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data[i][0].ToString() + "</td>";
                table += "<td>"+ data[i][1].ToString() +"/"+ mark_mcq.ToString()+ "</td>";
                table += "<td>" + data[i][3].ToString() + "/" + mark_tf.ToString() + "</td>";
                table += "<td>" + data[i][5].ToString() + "/" + data[i][6].ToString() + "</td>";
                if (data[i][1].ToString()=="")
                     data[i][1] = "0";
                if (data[i][3].ToString() == "")
                    data[i][3] = "0";
                if (data[i][5].ToString() == "")
                    data[i][5] = "0";
                table += "<td>" +(Convert.ToDouble( data[i][1].ToString())+ Convert.ToDouble(data[i][3].ToString())+ Convert.ToDouble(data[i][5].ToString())).ToString() + "/" + data[i][7].ToString() + "</td>";

            }
            html_data.InnerHtml = table;
        }
    }
}