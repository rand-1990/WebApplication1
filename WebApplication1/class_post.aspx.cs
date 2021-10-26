using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class class_post : System.Web.UI.Page
    {
       static DataBaseConnection data = new DataBaseConnection();
        public static string verifier;

         
        protected void Page_Load(object sender, EventArgs e)
        {
            verifier = Session["verifier"].ToString();
            if (!IsPostBack)
            {
                string id = Request["id"];
                var data = ClassesManage.UserCanAccessToClass(Session["verifier"].ToString(), id);
                if (data.Length == 0)
                    Response.Redirect("classes_show.aspx");
                class_title.InnerText = data[0][1].ToString();
                class_code.InnerText ="the code is : "+ data[0][2].ToString();
                class_desc.InnerText = data[0][3].ToString();
                if (UserMangement.isLecture(verifier))
                {
                    assiement.HRef = "create_assiement.aspx?id=" + id;
                    quiz.HRef = "create_quiz.aspx?id=" + id;
                    subject.HRef = "create_subjects.aspx?id=" + id;
                    invite.HRef = "InviteByCSV.aspx?id=" + id;
                }
                else if (UserMangement.isStudent(verifier))
                {
                    assiement.HRef = "assiement_now.aspx?id=" + id;
                    quiz.HRef = "quiz_now.aspx?id=" + id;

                    my_assiement.Visible = true;
                    my_assiement.Style.Add("display", "inline-block");
                    my_assiement.HRef = "my_assiement.aspx?id=" + id;
                    myquiz.HRef = "my_quiz.aspx?id=" + id;
                    myquiz.Style.Add("display", "inline-block");
                    myquiz.Visible = true;
                    subject.HRef = "my_subjects.aspx?id=" + id;
                    invite.Visible = false;

                }

            }
        }
        [WebMethod(true)]

        public static string set_post_to_view(string classid)
        {
            string x;
            string all_post = "";
            var p = get_all_post(classid);
            for (int i = 0; i < p.Length; i++)
            {
                var ele = " <div class='container mt-5'>";
                ele += "<div class='d-flex justify-content-center row'>";
                ele += "<div class='col-md-8'>";
                ele += "<div class='d-flex flex-column comment-section'>";
                ele += "<div class='bg-white p-2'>";
                ele += "<div class='d-flex flex-row user-info'><img class='rounded-circle' src='' width='40'>";
                ele += "<div class='d-flex flex-column justify-content-start ml-2'><span class='d-block font-weight-bold name'>" + p[i][3] + "</span><span class='date text-black-50'>" + p[i][1] + "</span></div>";
                ele += "</div><div class='mt-2'><p class='comment-text'>" + p[i][0] + "</p></div></div>";

                //ele += "<div class='d-flex flex-column justify-content-start ml-2'><span class='d-block font-weight-bold name'>" + p[i][3] + "</span><span   class='date text-black-50'> " + p[i][1] + "</span></div>";
                //ele += "</div><div class='d - block font - weight - bold name','mt-2'><p class='comment-text'>" + p[i][0] + "</p></div></div>";


                var comment = get_all_comment(Int32.Parse(p[i][2].ToString()));
                ele += "<div class=bg-white id=rep" + p[i][2] + ">";
                for (int k = 0; k < comment.Length; k++)
                {
                    //  ele += "<p class='comment-text'>" + comment[k][0] + "</p><span class='d - block font - weight - bold name'>" + comment[k][3] + " </span><span class='date text-black - 50'>" + comment[k][1] + "</span><hr>";
                     ele += "<span class='d - block font - weight - bold name'>" + comment[k][3] + " </span><span class='date text-black - 50'>" + comment[k][1] + "</span> <p class='comment-text'>" + comment[k][0] + "</p><hr>";


                }
                ele += "</div>";
                ele += "<div class='bg-light p-2'>";
                ele += "<div class='d-flex flex-row align-items-start'><img class='rounded-circle' src='https://upload.wikimedia.org/wikipedia/commons/8/81/Logoo2.png' width='40'><textarea class='form-control ml-1 shadow-none textarea' id='r" + p[i][2] + "'></textarea></div>";
                ele += "<div class='mt-2 text-right'><button class='btn btn-primary btn-sm shadow-none' value='" + p[i][2] + "' onclick='SendReply(this)' type='button'>Comment</button></div>";
                //ele += "<div class='mt-2 text-right'><button class='btn btn-primary btn-sm shadow-none' value='" + p[i][2] + "' onclick='SendReply(this)' type='button'>Comment</button><button class='btn btn-outline-primary btn-sm ml-1 shadow-none' type='button'>Cancel</button></div>";

                ele += "</div></div ></div > </div >";
                all_post = ele + all_post;
            }
            return all_post;
        }

        [WebMethod(true)]

        public static string SendComment(string post,string classid)
        {
            string name = class_post.get_username();
            string post_val = insert_post(post,classid);
            post_val += ",'username':'" + name + "'";
            post_val = "{" + post_val + "}";
            return post_val;
        }
        [WebMethod(true)]
        public static string SendReply(string postid, string comment)
        {
            string name = class_post.get_username();
            string post_val = insert_comment(postid, comment);
            post_val += ",'username':'" + name + "'";
            post_val = "{" + post_val + "}";
            return post_val;
        }
        public static string get_username()
        {
            string tablename = "users";
            string[] column = { "username" };
            string cond = "verifier='" + verifier + "'";
            var reader = data.Select(tablename, column, cond);
            return reader[0][0].ToString();
        }
        public static string get_userid()
        {
            DataBaseConnection data = new DataBaseConnection();
            string tablename = "users";
            string[] column = { "id" };
            string cond = "verifier='" + verifier + "'";
            var reader = data.Select(tablename, column, cond);
            return reader[0][0].ToString();
        }
        public static string insert_post(string post,string classid)
        {
            string userid = get_userid();
            string tablename = "[ELearning].[dbo].[post]";
            string[] column = { "post", "type", "userid","classid" };
            string[] values = { post, "2", userid,classid };
            int id = data.Insert(tablename, column, values);
            id = (int)data.GetLastIdNumber(tablename);
            return get_post_json(id);
        }
        public static string insert_comment(string postid, string comment)
        {
            string userid = get_userid();
            string tablename = "[ELearning].[dbo].[comments]";
            string[] column = { "comment_msg", "postid", "comment_userid" };
            string[] values = { comment, postid, userid };
            int id = data.Insert(tablename, column, values);
            id = (int)data.GetLastIdNumber(tablename);
            return get_comment_json(id);
        }
        public static string get_post_json(int postid)
        {
            string tablename = "[ELearning].[dbo].[post]";
            string[] column = { "post", "post_date", "id" };
            string cond = "id='" + postid + "'";
            var reader = data.Select(tablename, column, cond);
            string val = "'id':'" + reader[0][2].ToString() + "','post':'" + reader[0][0].ToString() + "'" + ",'post_date':'" + reader[0][1].ToString() + "'";
            return val;
        }
        public static string get_comment_json(int commentid)
        {
            string tablename = "[ELearning].[dbo].[comments]";
            string[] column = { "comment_msg", "comment_date", "id", "postid" };
            string cond = "id='" + commentid + "'";
            var reader = data.Select(tablename, column, cond);
            string val = "'id':'" + reader[0][2].ToString() + "','comment_msg':'" + reader[0][0].ToString() + "'" + ",'comment_date':'" + reader[0][1].ToString() + "'" + ",'postid':'" + reader[0][3].ToString() + "'";
            return val;
        }
        public static object[][] get_all_post(string classid)
        {
            string tablename = "[ELearning].[dbo].[post] inner join users on(users.id=[ELearning].[dbo].[post].userid)";
            string[] column = { "post", "post_date", "post.id", "username" };
            string cond = "post.type='2' and classid='"+classid+"' order by post.id Asc";
            var dt = data.Select(tablename, column, cond);
            return dt;
        }
        public static object[][] get_all_comment(int postid)
        {
            string tablename = "[ELearning].[dbo].[comments] inner join users on(users.id=[ELearning].[dbo].[comments].comment_userid)";
            string[] column = { "comment_msg", "comment_date", "comment_userid", "username" };
            string cond = "postid='" + postid + "' order by comments.id Asc";
            var dt = data.Select(tablename, column, cond);
            return dt;
        }
    }
}