using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class main_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!UserMangement.isAdmin(Session["verifier"].ToString()))
                Response.Redirect("check.aspx");
                
            
            // load login cahrt
            
            LoginHistoryChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            LoginHistoryChart.Series[0].BorderWidth = 3;

            var value_user_history = UserMangement.getUserHistory();
            DataSet ds = new DataSet();
            value_user_history.Fill(ds);
            LoginHistoryChart.Titles.Add("Users Login History");

            LoginHistoryChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);

            LoginHistoryChart.ChartAreas[0].AxisY.Title = "count login";
            LoginHistoryChart.ChartAreas[0].AxisX.Title = "Date";

            LoginHistoryChart.DataSource = ds;
            LoginHistoryChart.Series[0].XValueMember = "dt";
            LoginHistoryChart.Series[0].YValueMembers = "num_lec";
            LoginHistoryChart.Series[1].XValueMember = "dt";
            LoginHistoryChart.Series[1].YValueMembers = "num_stu";
            LoginHistoryChart.Series[2].XValueMember = "dt";
            LoginHistoryChart.Series[2].YValueMembers = "num_admin";
            LoginHistoryChart.DataBind();



            //for register
            RegisterChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            RegisterChart.Series[0].BorderWidth = 3;
            var value_for_register = UserMangement.getUserRegister();
            DataSet ds2 = new DataSet();
            value_for_register.Fill(ds2);
            RegisterChart.Titles.Add("Users Register History");
            RegisterChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            RegisterChart.ChartAreas[0].AxisY.Title = "count register";
            RegisterChart.ChartAreas[0].AxisX.Title = "Date";
            RegisterChart.DataSource = ds2;
            RegisterChart.Series[0].XValueMember = "dt";
            RegisterChart.Series[0].YValueMembers = "lec_complete";
            RegisterChart.Series[1].XValueMember = "dt";
            RegisterChart.Series[1].YValueMembers = "lec_not_complete";
            RegisterChart.Series[2].XValueMember = "dt";
            RegisterChart.Series[2].YValueMembers = "stu_complete";
            RegisterChart.Series[3].XValueMember = "dt";
            RegisterChart.Series[3].YValueMembers = "stu_not_complete";
            RegisterChart.DataBind();

            //exam chart
            ExamChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            ExamChart.Series[0].BorderWidth = 3;
            var value_for_exam = UserMangement.getExam();
            DataSet ds3 = new DataSet();
            value_for_exam.Fill(ds3);
            ExamChart.Titles.Add("Exam History");
            ExamChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            ExamChart.ChartAreas[0].AxisY.Title = "count Exam";
            ExamChart.ChartAreas[0].AxisX.Title = "Date";
            ExamChart.DataSource = ds3;
            ExamChart.Series[0].XValueMember = "dt";
            ExamChart.Series[0].YValueMembers = "num";
     
            ExamChart.DataBind();
            //student do exam chart

            StudentDoExamChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            StudentDoExamChart.Series[0].BorderWidth = 3;
            var value_for_stuexam = UserMangement.getStudentDoExam();
            DataSet ds4 = new DataSet();
            value_for_stuexam.Fill(ds4);
            StudentDoExamChart.Titles.Add("Student do Exam History");
            StudentDoExamChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            StudentDoExamChart.ChartAreas[0].AxisY.Title = "count student do Exam";
            StudentDoExamChart.ChartAreas[0].AxisX.Title = "Date";
            StudentDoExamChart.DataSource = ds4;
            StudentDoExamChart.Series[0].XValueMember = "dt";
            StudentDoExamChart.Series[0].YValueMembers = "num";

            StudentDoExamChart.DataBind();

            //assiement chart
            assiementChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            assiementChart.Series[0].BorderWidth = 3;
            var value_for_assiement = UserMangement.getAssiement();
            DataSet ds5 = new DataSet();
            value_for_assiement.Fill(ds5);
            assiementChart.Titles.Add("Assiement History");
            assiementChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            assiementChart.ChartAreas[0].AxisY.Title = "count Assiement";
            assiementChart.ChartAreas[0].AxisX.Title = "Date";
            assiementChart.DataSource = ds5;
            assiementChart.Series[0].XValueMember = "dt";
            assiementChart.Series[0].YValueMembers = "num";

            assiementChart.DataBind();


            ///assiement do by student
            assiementDoChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            assiementDoChart.Series[0].BorderWidth = 3;
            var value_for_assiementdo = UserMangement.getAssiementDo();
            DataSet ds6 = new DataSet();
            value_for_assiementdo.Fill(ds6);
            assiementDoChart.Titles.Add("Student do assiement History");
            assiementDoChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            assiementDoChart.ChartAreas[0].AxisY.Title = "count student do assiement";
            assiementDoChart.ChartAreas[0].AxisX.Title = "Date";
            assiementDoChart.DataSource = ds6;
            assiementDoChart.Series[0].XValueMember = "dt";
            assiementDoChart.Series[0].YValueMembers = "num";

            assiementDoChart.DataBind();

            //class chart
            classChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            classChart.Series[0].BorderWidth = 3;
            var value_for_class = UserMangement.Getclasses();
            DataSet ds7 = new DataSet();
            value_for_class.Fill(ds7);
            classChart.Titles.Add("class History");
            classChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            classChart.ChartAreas[0].AxisY.Title = "count class";
            classChart.ChartAreas[0].AxisX.Title = "Date";
            classChart.DataSource = ds7;
            classChart.Series[0].XValueMember = "dt";
            classChart.Series[0].YValueMembers = "num";

            classChart.DataBind();
            //student join class
            classjoinChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            classjoinChart.Series[0].BorderWidth = 3;
            var value_for_classjoin = UserMangement.Getclassesjoin();
            DataSet ds8 = new DataSet();
            value_for_classjoin.Fill(ds8);
            classjoinChart.Titles.Add("class join History");
            classjoinChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            classjoinChart.ChartAreas[0].AxisY.Title = "count student join to class";
            classjoinChart.ChartAreas[0].AxisX.Title = "Date";
            classjoinChart.DataSource = ds8;
            classjoinChart.Series[0].XValueMember = "dt";
            classjoinChart.Series[0].YValueMembers = "num";

            classjoinChart.DataBind();

            //materails
            matChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            matChart.Series[0].BorderWidth = 3;
            var value_for_mat = UserMangement.GetMat();
            DataSet ds9 = new DataSet();
            value_for_mat.Fill(ds9);
            matChart.Titles.Add("materails  History");
            matChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            matChart.ChartAreas[0].AxisY.Title = "count materialss";
            matChart.ChartAreas[0].AxisX.Title = "Date";
            matChart.DataSource = ds9;
            matChart.Series[0].XValueMember = "dt";
            matChart.Series[0].YValueMembers = "num";

            matChart.DataBind();

            //post
            postChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            postChart.Series[0].BorderWidth = 3;
            var value_for_post = UserMangement.Getpost();
            DataSet ds10 = new DataSet();
            value_for_post.Fill(ds10);
            postChart.Titles.Add("post  History");
            postChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            postChart.ChartAreas[0].AxisY.Title = "count post";
            postChart.ChartAreas[0].AxisX.Title = "Date";
            postChart.DataSource = ds10;
            postChart.Series[0].XValueMember = "dt";
            postChart.Series[0].YValueMembers = "num";

            postChart.DataBind();

            //comment chart
            commentChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            commentChart.Series[0].BorderWidth = 3;
            var value_for_comment = UserMangement.Getcomment();
            DataSet ds11 = new DataSet();
            value_for_comment.Fill(ds11);
            commentChart.Titles.Add("comment  History");
            commentChart.Titles[0].Font = new System.Drawing.Font("Arial Black", 18, System.Drawing.FontStyle.Italic);
            commentChart.ChartAreas[0].AxisY.Title = "count comment";
            commentChart.ChartAreas[0].AxisX.Title = "Date";
            commentChart.DataSource = ds11;
            commentChart.Series[0].XValueMember = "dt";
            commentChart.Series[0].YValueMembers = "num";

            commentChart.DataBind();

        }
    }
}