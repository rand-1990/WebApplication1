using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1
{

    public static class ClassesManage
    {
        static DataBaseConnection database = new DataBaseConnection();
        private static string assiementid;

        public static void insertClass(string class_name, string class_code, string class_desc, string userid,string color)
        {
            string table_name = "classes";
            string[] columns = { "class_name", "class_code", "description", "user_id","color" };
            string[] values = { class_name, class_code, class_desc, userid,color };
            database.Insert(table_name, columns, values);
        }
        public static void DeleteClass(string classid)
        {
            string table_name = "classes";
            string cond = "id='" + classid + "'";
            database.Delete(table_name,cond);
        }
        public static void UpdateClass(string classid,string class_name,  string class_desc, string color)
        {
            string table_name = "classes";
            string[] columns = { "class_name", "description",  "color" };
            string[] values = { class_name, class_desc, color };
            string cond = "id='" + classid + "'";
            database.Update(table_name, columns, values,cond);
        }
        public static string GetCLassIDByCode(string code)
        {
            string table_name = "classes";
            string[] columns = { "id" };
            string cond = "class_code='" + code + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static object[][] GetClassInfoByClassid(string id)
        {
            string table_name = "classes";
            string[] columns = { "class_name","description","color","class_code" };
            string cond = "id='" + id + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static string GetClassIDBYSubjectID(string id)
        {
            string table_name = "subjects";
            string[] columns = { "classid" };
            string cond = "id='" + id + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static void InsertUsersCLasses(string classid, string userid)
        {
            string table_name = "users_classes";
            string[] columns = { "classid", "userid" };
            string[] values = { classid, userid };
            database.Insert(table_name, columns, values);
        }
 
        public static object[][] GetUserClasses(string verifier)
        {
            string table_name = "classes inner join users_classes on(classes.id=users_classes.classid) inner join users on(users.id=users_classes.userid) ";
            string[] columns = { "classes.id", "class_name", "class_code", "description", "classes.date_inserted","color" };
            string cond = "verifier='" + verifier + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static object[][] UserCanAccessToClass(string verifier, string classid)
        {
            string table_name = "classes inner join users_classes on(classes.id=users_classes.classid) inner join users on(users.id=users_classes.userid) ";
            string[] columns = { "classes.id", "class_name", "class_code", "description", "classes.date_inserted" };
            string cond = "verifier='" + verifier + "' and users_classes.classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static bool add_assiement(string title, string file_path, string startdate, string enddate, string classid, string userid)
        {
            DateTime st = DateTime.Parse(startdate);
            DateTime et = DateTime.Parse(enddate);
            string format = "yyyy-MM-dd HH:mm:ss";
            string table_name = "assiement";
            string[] columns = { "title", "filepath", "start_date", "end_date", "classid", "userid" };
            string[] values = { title, file_path, st.ToString(format), et.ToString(format), classid, userid };
            database.Insert(table_name, columns, values);
            return true;
        }
        public static object[][] getNextAssiement(string classid)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            string dateTime = DateTime.Now.ToString(format);
            string table_name = "assiement";
            string[] columns = { "title", "filepath", "start_date", "end_date", "classid", "userid", "id" };
            string cond = "start_date>'" + dateTime + "' and classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static object[][] getCurrentAssiement(string classid)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            string dateTime = DateTime.Now.ToString(format);
            string table_name = "assiement";
            string[] columns = { "title", "filepath", "start_date", "end_date", "classid", "userid", "id" };
            string cond = "start_date<'" + dateTime + "' and end_date>'" + dateTime + "' and classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static object[][] getArchiveAssiement(string classid)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            string dateTime = DateTime.Now.ToString(format);
            string table_name = "assiement";
            string[] columns = { "title", "filepath", "start_date", "end_date", "classid", "userid", "id" };
            string cond = "start_date<'" + dateTime + "' and end_date<'" + dateTime + "' and classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static object[][] getAssiementByID(string id)
        {
            string format = "yyyy-MM-dd HH:mm:ss";

            string dateTime = DateTime.Now.ToString(format);

            string table_name = "assiement";
            string[] columns = { "title", "filepath", "start_date", "end_date", "classid", "userid", "id" };
            string cond = "start_date<'" + dateTime + "' and end_date>'" + dateTime + "' and id='" + id + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static string userHasAnswer(string userid, string assiementid)
        {
            string table_name = "answer_assiement";
            string[] columns = { "id" };
            string cond = " userid='" + userid + "' and assiementid='" + assiementid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";

        }
        public static int add_answer_asssiement(string title, string filepath, string assiementid, string userid)
        {

            var data = getAssiementByID(assiementid);
            string table_name = "answer_assiement";
            string[] columns = { "answer_title", "answer_file_path", "assiementid", "userid" };
            string[] values = { title, filepath, assiementid, userid };
            if (data.Length == 1)
            {
                string replay = userHasAnswer(userid, assiementid);
                if (replay == "")
                    database.Insert(table_name, columns, values);
                else
                {
                    string format = "yyyy-MM-dd HH:mm:ss";
                    DateTime st = DateTime.Now;

                    string[] columns_updated = { "answer_title", "answer_file_path", "date_answer" };
                    string[] values_updated = { title, filepath, st.ToString(format) };
                    string cond = " id='" + replay + "'";
                    database.Update(table_name, columns_updated, values_updated, cond);
                }
                return 1;
            }
            else
                return 0;


        }
        public static string getClassIDbyAssiementID(string assiementid)
        {
            string format = "yyyy-MM-dd HH:mm:ss";

            string dateTime = DateTime.Now.ToString(format);

            string table_name = "assiement";
            string[] columns = { "classid" };
            string cond =" id='" + assiementid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static object[][] GetAllAnswerAssiement(string assiementid)
        {
            string table_name = "answer_assiement inner join users on(users.id=answer_assiement.userid)";
            string[] columns = { "answer_title", "answer_file_path", "users.username","mark","date_answer","userid", "answer_assiement.assiementid" };
            string cond = "assiementid='" + assiementid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static object[][] GetAssiementInfo(string assiementid)
        {
            string table_name = "assiement" ;
            string[] columns = { "title", "start_date", "end_date" };
            string cond = "id='" + assiementid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static void DeleteAssiement(string assiementid)
        {
            string table_name = "assiement";
            
            string cond = "id='" + assiementid + "'";
            database.Delete(table_name, cond);
        }
        public static void update_assienemnt(string caption,string start,string end,string assiementid,string filename)
        {
            string table_name = "assiement";

            string cond = "id='" + assiementid + "'";

            if (filename == "")
            {
                string[] columns = { "title", "start_date", "end_date" };
                string[] values = { caption, start, end };
                database.Update(table_name, columns, values, cond);

            }
            else
            {
                string[] columns = { "title", "start_date", "end_date","filepath" };
                string[] values = { caption, start, end ,filename};
                database.Update(table_name, columns, values, cond);

            }



        }
        public static string GetMarkAssiementByID(string assiementid,string userid)
        {
            string table_name = "answer_assiement";
            string[] columns = { "mark" };
            string cond = "userid='" + userid + "' and assiementid='" + assiementid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else 
                return "";
        }
        public static string InsertMarkToAssiement(string mark,string userid,string assiementid)
        {
            string table_name = "answer_assiement";
            string[] columns = { "mark" };
            string[] values = { mark };
            string cond = "userid='" + userid + "' and assiementid='" + assiementid + "'";
            database.Update(table_name, columns, values, cond);
            string mark_return = GetMarkAssiementByID(assiementid, userid);
            return mark_return;
        }
        public static string GetMarkSaByID(string quizid,string userid)
        {
            string table_name = "students_quiz_answer";
            string[] columns = { "mark_sa" };
            string cond = "quizid='" + quizid + "' and userid='" + userid + "'";
            var data = database.Select(table_name, columns, cond);
            return data[0][0].ToString();
        }
        public static string InsertMarkToSa(string mark, string userid, string quizid)
        {
            string table_name = "students_quiz_answer";
            string[] columns = { "mark_sa" };
            string[] values = { mark };
            string cond = "userid='" + userid + "' and quizid='" + quizid + "'";
            database.Update(table_name, columns, values, cond);
            string mark_return = GetMarkSaByID(quizid, userid);
            return mark_return;
        }
        public static object[][] GetMyAssiemnet(string classid,string userid)
        {
            string table_name = "assiement left join answer_assiement on (assiement.id=answer_assiement.assiementid and answer_assiement.userid='" + userid+"')";
            string[] columns = { "assiement.title", "assiement.filepath", "assiement.start_date", "assiement.end_date", "answer_assiement.answer_title", "answer_assiement.answer_file_path", "answer_assiement.mark" };
            string cond = "assiement.classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
         }
        public static object[][] GetMyQuiz(string classid, string userid)
        {
            string table_name = "quiz_info left join students_quiz_answer on (quiz_info.id=students_quiz_answer.quizid and students_quiz_answer.userid='" + userid + "')";
            string[] columns = { "quiz_info.quiz_title", "students_quiz_answer.mark_mcq", "quiz_info.mark_mcq", "students_quiz_answer.mark_tf", "quiz_info.mark_tf", "students_quiz_answer.mark_sa", "quiz_info.mark_sa","quiz_info.quiz_mark","quiz_info.num_mcq","quiz_info.num_tf" };
            string cond = "quiz_info.classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static object[][] GETSubjectINFOBySubjectID(string id)
        {
            string table_name = "subjects";
            string[] columns = { "title", "id","videopath" };
            string cond = "id='" + id + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static int add_quiz_info(string title,string num_question,string mark,string start_date,string end_date,string classid,string userid,string num_mcq,string num_sa,string num_tf,string mark_mcq,string mark_sa,string mark_tf,string sa_desc)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime st = DateTime.Parse(start_date);
            DateTime et = DateTime.Parse(start_date).AddMinutes(Convert.ToDouble(end_date));

            string table_name = "quiz_info";
            string[] columns = { "quiz_title", "quiz_numq", "quiz_mark","num_mcq","mark_mcq","num_sa","mark_sa","num_tf","mark_tf", "start_date", "end_date", "classid", "userid","sa_desc" };
            string[] values = { title, num_question, mark,num_mcq,mark_mcq,num_sa,mark_sa,num_tf,mark_tf, st.ToString(format), et.ToString(format), classid, userid,sa_desc };
            database.Insert(table_name, columns, values);
            return 1;

        }
        public static int update_quiz_info(string quizid,string title, string num_question, string mark, string start_date, string end_date, string classid, string userid, string num_mcq, string num_sa, string num_tf, string mark_mcq, string mark_sa, string mark_tf, string sa_desc)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime st = DateTime.Parse(start_date);
            DateTime et = DateTime.Parse(start_date).AddMinutes(Convert.ToDouble(end_date));

            string table_name = "quiz_info";
            string[] columns = { "quiz_title", "quiz_numq", "quiz_mark", "num_mcq", "mark_mcq", "num_sa", "mark_sa", "num_tf", "mark_tf", "start_date", "end_date", "classid", "userid", "sa_desc" };
            string[] values = { title, num_question, mark, num_mcq, mark_mcq, num_sa, mark_sa, num_tf, mark_tf, st.ToString(format), et.ToString(format), classid, userid, sa_desc };
            string cond = "id='" + quizid + "'";
            database.Update(table_name, columns, values,cond);
            return 1;

        }
        public static object[][] getAllQuizInclass(string classid)
        {
            string table_name = "quiz_info";
            string[] columns = { "quiz_title", "quiz_numq", "quiz_mark","num_mcq","mark_mcq","num_tf","mark_tf","num_sa","mark_sa", "start_date", "end_date", "classid", "userid","id","sa_desc" };
            string cond = "classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static int add_questions_mcq_info(string question,string ch1,string ch2,string ch3,string ch4,string right_ch,string quiz_id,string userid)
        {
            string table_name = "questions_info";
            question = AES.Encrypt(question);
            ch1 = AES.Encrypt(ch1);
            ch2 = AES.Encrypt(ch2);
            ch3 = AES.Encrypt(ch3);
            ch4 = AES.Encrypt(ch4);
            right_ch = AES.Encrypt(right_ch);
            string[] columns = { "question", "choice1", "choice2", "choice3", "choice4", "right_choice", "quiz_id", "userid","q_type" };
            string[] values = { question, ch1, ch2, ch3, ch4, right_ch, quiz_id, userid,"1" };
            database.Insert(table_name, columns, values);
            return 1;
        }
        public static int add_questions_tf_info(string question, string ch1, string ch2,string right_ch, string quiz_id, string userid)
        {
            string table_name = "questions_info";
            question = AES.Encrypt(question);
            ch1 = AES.Encrypt(ch1);
            ch2 = AES.Encrypt(ch2);
          
            right_ch = AES.Encrypt(right_ch);
            string[] columns = { "question", "choice1", "choice2", "right_choice", "quiz_id", "userid", "q_type" };
            string[] values = { question, ch1, ch2, right_ch, quiz_id, userid, "2" };
            database.Insert(table_name, columns, values);
            return 1;
        }
        public static int add_questions_sa_info(string question, string quiz_id, string userid)
        {
            question = AES.Encrypt(question);
            string table_name = "sa_questions";
            string[] columns = { "question",  "quiz_id", "userid" };
            string[] values = { question ,quiz_id, userid };
            database.Insert(table_name, columns, values);
            return 1;
        }
        public static string AddAnswerSa(string quiz_id,string user_id,string answer,string sa_ids)
        {
            string table_name = "answer_sa";
            string[] columns = { "answer","sa_ids", "quiz_id", "user_id" };
            string[] values = { answer,sa_ids, quiz_id, user_id };
            database.Insert(table_name, columns, values);
            return "";
        }
        public static object[][] getAllQuestionsfromQUIZ(string quiz_id,string all="")
        {
            string table_name = "questions_info";
            string[] columns = { "question", "choice1", "choice2", "choice3", "choice4", "right_choice", "quiz_id", "userid","id","q_type" };
            string cond = "";
            if (all=="yes")
            cond = "quiz_id='" + quiz_id + "'";
            else
             cond = "quiz_id='" + quiz_id + "' and q_type='1'";

            var data = database.Select(table_name, columns, cond);
            for(int i=0;i<data.Length;i++)
            {
                for (int j = 0; j < 6; j++)
                    data[i][j] = AES.Decrypt(data[i][j].ToString());
            }
            return data;

        }
        public static object[][] getAllQuestionsSafromQUIZ(string quiz_id)
        {
            string table_name = "sa_questions";
            string[] columns = { "question","id"};
            string cond = "";
            cond = "quiz_id='" + quiz_id + "'";
            

            var data = database.Select(table_name, columns, cond);
            for (int i = 0; i < data.Length; i++)
            {
             
                    data[i][0] = AES.Decrypt(data[i][0].ToString());
            }
            return data;

        }

        public static object[][] getAllQuestionsTffromQUIZ(string quiz_id)
        {
            string table_name = "questions_info";
            string[] columns = { "question", "choice1", "choice2", "right_choice", "quiz_id", "userid", "id", "q_type" };
            string cond = "quiz_id='" + quiz_id + "' and q_type='2'";
            var data = database.Select(table_name, columns, cond);
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                    data[i][j] = AES.Decrypt(data[i][j].ToString());
            }
            return data;

        }
        public static object[][] getAllQuestionsSAfromQUIZ(string quiz_id)
        {
            string table_name = "sa_questions";
            string[] columns = { "question","id", "userid" };
            string cond = "quiz_id='" + quiz_id + "'";
            var data = database.Select(table_name, columns, cond);
            for (int i = 0; i < data.Length; i++)
            {
                    data[i][0] = AES.Decrypt(data[i][0].ToString());
            }
            return data;

        }
        public static string getSaDEscFromQuiz(string quiz_id)
        {
            string table_name = "quiz_info";
            string[] columns = { "sa_desc" };
            string cond = "id='" + quiz_id + "'";
            var data = database.Select(table_name, columns, cond);
            return data[0][0].ToString();

        }
        public static int DeleteQuestion(string qid)
        {
            string table_name = "questions_info";
            string cond = " id='" + qid + "'";
            database.Delete(table_name, cond);
            return 1;
        }
        public static int DeleteSubject(string qid)
        {
            string table_name = "subjects";
            string cond = " id='" + qid + "'";
            database.Delete(table_name, cond);
            return 1;
        }
        public static int DeleteSa(string qid)
        {
            string table_name = "sa_questions";
            string cond = " id='" + qid + "'";
            database.Delete(table_name, cond);
            return 1;
        }
        public static int Update_mcq(string id,string question,string ch1,string ch2,string ch3,string ch4,string right)
        {
            string table_name = "questions_info";
            question = AES.Encrypt(question);
            ch1 = AES.Encrypt(ch1);
            ch2 = AES.Encrypt(ch2);
            ch3 = AES.Encrypt(ch3);
            ch4 = AES.Encrypt(ch4);
            right = AES.Encrypt(right);
            string[] columns = { "question", "choice1", "choice2", "choice3", "choice4", "right_choice" };
            string[] values = { question, ch1, ch2, ch3, ch4, right };
            string cond = " id='" + id + "'";
            database.Update(table_name, columns, values, cond) ;
            return 1;
        }
        public static int Update_tf(string id, string question, string right)
        {
            string table_name = "questions_info";
            question = AES.Encrypt(question);
       
            right = AES.Encrypt(right);
            string[] columns = { "question", "right_choice" };
            string[] values = { question, right };
            string cond = " id='" + id + "'";
            database.Update(table_name, columns, values, cond);
            return 1;
        }
        public static int Update_sa(string id, string question)
        {
            string table_name = "sa_questions";
            question = AES.Encrypt(question);

            string[] columns = { "question" };
            string[] values = { question };
            string cond = " id='" + id + "'";
            database.Update(table_name, columns, values, cond);
            return 1;
        }
        public static string GetclassidByQuizId(string quiz_id)
        {
            string table_name = "quiz_info";
            string[] columns = { "classid" };
            string cond = "id='" + quiz_id + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static object[][] getCurrentQuiz(string classid)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            string dateTime = DateTime.Now.ToString(format);
            string table_name = "quiz_info";
            string[] columns = { "quiz_title", "quiz_numq", "quiz_mark", "start_date", "end_date", "classid", "userid", "id" };
            string cond = "start_date<'" + dateTime + "' and end_date>'" + dateTime + "' and classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static string getEndQuiz(string quiz_id)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            string table_name = "quiz_info";
            string[] columns = {"end_date" };
            string cond =  " id='" + quiz_id + "'";
            var data = database.Select(table_name, columns, cond);
            DateTime et = DateTime.Parse(data[0][0].ToString());
            // data[0][0].ToString();
            return et.ToString(format);

        }
        public static string getQuizIdByQuestionId(string questionid)
        {

            string table_name = "questions_info";
            string[] columns = {  "quiz_id" };
            string cond = "id='" + questionid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static string getQuestionTypeByQuestionId(string questionid)
        {

            string table_name = "questions_info";
            string[] columns = { "q_type" };
            string cond = "id='" + questionid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static string GetCorrectChoice(string questionid)
        {
            string table_name = "questions_info";
            string[] columns = { "right_choice" };
            string cond = "id='" + questionid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return AES.Decrypt( data[0][0].ToString()).ToString();
            else
                return "";
        }
        public static string GetQuizMark(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "quiz_mark" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static object[][] GetQuizInfoByID(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "quiz_title", "quiz_numq", "quiz_mark", "sa_desc", "num_sa", "mark_sa","num_tf","mark_tf", "num_mcq","mark_mcq","start_date","end_date" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
            
        }
        public static string GetQuizMarkMcq(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "mark_mcq" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static string GetQuizMarkTF(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "mark_tf" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static string GetQuizMarkSA(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "mark_sa" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static string GetQuizNumMcq(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "num_mcq" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static string GetQuizNumTf(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "num_tf" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static string GetQuizNumQUestion(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "quiz_numq" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static int addQuizResultMcqAndTF(string quizid,string userid,string mark_mcq,string mark_tf,string lat,string long_)
        {
            string table = "students_quiz_answer";
            string[] columns = { "userid","quizid","mark_mcq","mark_tf","lat","long" };
            string []values = { userid, quizid, mark_mcq,mark_tf,lat,long_ };
            database.Insert(table, columns, values);
            return 1;
        }
        public static object[][] CheckUserIFCompletQuiz(string quizid,string userid)
        {
            string table = "students_quiz_answer";
            string[] columns = {  "mark","date_inserted" };
            string cond = "quizid='" + quizid + "' and userid='" + userid + "'";
            var data = database.Select(table, columns, cond);
            return data;
        }
        public static double GetMarkSaByQuizId(string quizid)
        {
            string table = "quiz_info";
            string[] columns = { "mark_sa" };
            string cond = "id='" + quizid + "'";
            var data = database.Select(table, columns, cond);
            return Convert.ToDouble(data[0][0].ToString());
        }
        public static string getClassIDbyQuizID(string quizid)
        {
            string format = "yyyy-MM-dd HH:mm:ss";

            string dateTime = DateTime.Now.ToString(format);

            string table_name = "quiz_info";
            string[] columns = { "classid" };
            string cond = " id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
                return data[0][0].ToString();
            else
                return "";
        }
        public static object[][] GetAllAnswerQuiz(string quizid)
        {
            string table_name = "students_quiz_answer inner join users on(users.id=students_quiz_answer.userid)";
            string[] columns = { "users.username", "mark_mcq","mark_tf","mark_sa" };
            string cond = "quizid='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static string GetSAquestionBYSAID(string sa_id)
        {
            string table_name = "sa_questions";
            string[] columns = { "question"};
            string cond = "id='" + sa_id + "'";
            var data = database.Select(table_name, columns, cond);
        
            return AES.Decrypt(data[0][0].ToString());
        }
        public static object[][] GetAllAnswerQuizSa(string quizid)
        {
            string table_name = "answer_sa inner join users on(users.id=answer_sa.user_id)";
            string[] columns = { "answer","sa_ids","user_id", "users.username",};
            string cond = "quiz_id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static bool checkCanAddQuestionMcq(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "num_mcq" };
            string cond = " id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if(data.Length==1)
            {
                int num_q = Int32.Parse(data[0][0].ToString());
                string tab_name = "questions_info";
                string[] col = { "id" };
                string con = "quiz_id='" + quizid + "' and q_type='1'";
                var dt = database.Select(tab_name, col, con);
                if(dt.Length<num_q)
                {
                    return true;
                }

            }
            return false;
        }
        public static bool checkCanAddQuestionTf(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "num_tf" };
            string cond = " id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
            {
                int num_q = Int32.Parse(data[0][0].ToString());
                string tab_name = "questions_info";
                string[] col = { "id" };
                string con = "quiz_id='" + quizid + "' and q_type='2'";
                var dt = database.Select(tab_name, col, con);
                if (dt.Length < num_q)
                {
                    return true;
                }

            }
            return false;
        }
        public static bool checkCanAddQuestionSA(string quizid)
        {
            string table_name = "quiz_info";
            string[] columns = { "num_sa" };
            string cond = " id='" + quizid + "'";
            var data = database.Select(table_name, columns, cond);
            if (data.Length == 1)
            {
                int num_q = Int32.Parse(data[0][0].ToString());
                string tab_name = "sa_questions";
                string[] col = { "id" };
                string con = "quiz_id='" + quizid + "'";
                var dt = database.Select(tab_name, col, con);
                if (dt.Length < num_q)
                {
                    return true;
                }

            }
            return false;
        }
        public static object[][] getSubjects(string classid)
        {

            string table_name = "subjects";
            string[] columns = { "title", "filepath", "id","videopath" };
            string cond = "classid='" + classid + "'";
            var data = database.Select(table_name, columns, cond);
            return data;
        }
        public static bool add_subjects(string title, string file_path,string classid, string userid,string video_path)
        {

            string table_name = "subjects";
            string[] columns = { "title", "filepath", "classid", "userid","videopath" };
            string[] values = { title, file_path,  classid, userid,video_path };
            database.Insert(table_name, columns, values);
            return true;
        }
        public static bool update_subjects(string title, string file_path, string subject_id,string vide_path)
        {

            string table_name = "subjects";
            if (file_path != "")
            {
                string[] columns = { "title", "filepath","videopath" };
                string[] values = { title, file_path,vide_path };
                string cond = "id='" + subject_id + "'";
                database.Update(table_name, columns, values, cond);

            }
            else if(vide_path!="")
            {

                string[] columns = { "title", "filepath", "videopath" };
                string[] values = { title, null, vide_path };
                string cond = "id='" + subject_id + "'";
                database.Update(table_name, columns, values, cond);


            }
            else
            {
                string[] columns = { "title"};
                string[] values = { title };
                string cond = "id='" + subject_id + "'";
                database.Update(table_name, columns, values, cond);
            }
            return true;

        }
        public static DataTable GetLoc(string quizid)
        {
             DataBaseConnection condb = new DataBaseConnection();

            string cond = "quizid='" + quizid + "'";
            string query = @" select users.username,lat,long from students_quiz_answer inner join users on (users.id=students_quiz_answer.userid) where quizid='"+quizid+"'";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
                value.Fill(dt);
            con.Close();
            return dt;
        }

    }
}