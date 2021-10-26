using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApplication1
{
    public static class UserMangement
    {
       public static void sendmail(string to_email,string username,string message_random)
        {

            var fromAddress = new MailAddress("rand6101990@gmail.com", "Al-Mustansryah online portal");
            var toAddress = new MailAddress(to_email, username);
            const string fromPassword = "randrand";
            const string subject = "registeration code";
             string body ="welcome to AL-Mustansryah Portal,the code is : "+ message_random;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        public static void sendmailClassCode(string to_email, string msg)
        {
            string username = "invite";
            var fromAddress = new MailAddress("rand6101990@gmail.com", "Al-Mustansryah online portal");
            var toAddress = new MailAddress(to_email, username);
            const string fromPassword = "randrand";
            const string subject = "Invite code to Class";
           

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = msg
            })
            {
                smtp.Send(message);
            }
        }
        static DataBaseConnection condb = new DataBaseConnection();

        public static bool isLecture(string verifier)
        {
            string table_name = "users";
            string[] columns = { "type"};
            string condition = "verifier='" + verifier + "'";
            var data = condb.Select(table_name, columns, condition);
            if (data[0][0].ToString() == "1")
                return true;
            else return false;
        }
        public static int getUserID(string verifier)
        {
            string table_name = "users";
            string[] columns = { "id" };
            string condition = "verifier='" + verifier + "'";
            var data = condb.Select(table_name, columns, condition);
            return Int32.Parse(data[0][0].ToString());
        }
        public static object[][] getUserInfo(string id)
        {
            string table_name = "users";
            string[] columns = { "email","salt" };
            string condition = "id='" + id + "'";
            var data = condb.Select(table_name, columns, condition);
            return data;
        }
        public static object[][] getUserInfoByVerifier(string verifier)
        {
            string table_name = "users";
            string[] columns = { "email", "salt" };
            string condition = "verifier='" + verifier + "'";
            var data = condb.Select(table_name, columns, condition);
            return data;
        }
        public static int getUserifHasAccount(string email)
        {
            string table_name = "users";
            string[] columns = { "id" };
            string condition = "email='" + email + "'";
            var data = condb.Select(table_name, columns, condition);
            return data.Length;
        }
        public static void  Update_user(string id,string username,string verifier="")
        {
            string table_name = "users";
            if (verifier == "")
            {
                string[] columns = { "username" };
                string[] values = { username };
                string cond = "id='" + id + "'";
                condb.Update("users", columns, values, cond);
            }
            else if(verifier!="")
            {
                string[] columns = { "username","verifier" };
                string[] values = { username,verifier };
                string cond = "id='" + id + "'";
                condb.Update("users", columns, values, cond);
            }

          //  return data;
        }
        public static bool check_info_lecture(int id)
        {
            string table_name = "teacher";
            string[] columns = { "user_id" };
            string condition = "user_id='" + id + "'";
            var data = condb.Select(table_name, columns, condition);
            if (data.Length == 1)
                return true;
            else
                return false;
        }




        public static bool isStudent(string verifier)
        {
            string table_name = "users";
            string[] columns = { "type" };
            string condition = "verifier='" + verifier + "'";
            var data = condb.Select(table_name, columns, condition);
            if (data[0][0].ToString() == "2")
                return true;
            else return false;
        }
        public static bool isAdmin(string verifier)
        {
            string table_name = "users";
            string[] columns = { "type" };
            string condition = "verifier='" + verifier + "'";
            var data = condb.Select(table_name, columns, condition);
            if (data[0][0].ToString() == "3")
                return true;
            else return false;
        }
        public static bool check_info_student(int id)
        {
            string table_name = "student";
            string[] columns = { "user_id" };
            string condition = "user_id='" + id + "'";
            var data = condb.Select(table_name, columns, condition);
            if (data.Length == 1)
                return true;
            else
                return false;
        }
        public static bool add_user_login_history(int userid,string type)
        {
            string table_name = "login_history";
            string[] columns = { "userid","type" };
            string[] values = { userid.ToString(),type };
            condb.Insert(table_name, columns, values);
            return true;

        }
        public static SqlDataAdapter getUserHistory()
        {
            string query = "SELECT count(id) as num,CAST(date_login AS DATE) as dt,count(case when type=1 then id end) as num_lec,count(case when type=2 then id end) as num_stu,count(case when type=3 then id end) as num_admin  FROM[ELearning].[dbo].[login_history] as t1  group by CAST(date_login AS DATE) order by dt";

            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value=new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        //chart for users
        public static SqlDataAdapter getUserRegister()
        {
            string query= @"SELECT CAST(date_inserted AS DATE) as dt,count(case when type=1 and email_verify is not null  then id end) as lec_complete,count(case when type=1 and email_verify is  null then id end) as lec_not_complete,
count(case when type = 2 and email_verify is not null  then id end) as stu_complete,count(case when type = 1 and email_verify is null then id end) as stu_not_complete
  FROM users group by date_inserted";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter getExam()
        {
            string query = @"SELECT CAST(date_inserted AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[quiz_info] group by cast(date_inserted as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter getStudentDoExam()
        {
                          string query = @"SELECT CAST(date_inserted AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[students_quiz_answer] group by cast(date_inserted as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter getAssiement()
        {
            string query = @"SELECT CAST(date_insert AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[assiement] group by cast(date_insert as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter getAssiementDo()
        {
            string query = @"SELECT CAST(date_answer AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[answer_assiement] group by cast(date_answer as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter Getclasses()
        {
            string query = @"SELECT CAST(date_inserted AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[classes] group by cast(date_inserted as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter Getclassesjoin()
        {
            string query = @"SELECT CAST(join_date AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[users_classes] group by cast(join_date as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter GetMat()
        {
            string query = @"SELECT CAST(date_inserted AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[subjects] group by cast(date_inserted as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter Getpost()
        {
            string query = @"SELECT CAST(post_date AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[post] group by cast(post_date as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static SqlDataAdapter Getcomment()
        {
            string query = @"SELECT CAST(comment_date AS DATE) as dt,count(id) as num
  FROM [ELearning].[dbo].[comments] group by cast(comment_date as date) order by dt";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter value = new SqlDataAdapter(query, con);
            con.Close();
            return value;
        }
        public static DataSet getAllusers()
        {
            string query = @"SELECT[id]
      ,[username],email,
   
        (case when email_verify = '1' then 'is verfy'  when email_verify is null then 'not verify' end) as verify,
	  (case when type = '2' then 'student'  when type = '1' then 'lecture' end) as type
      FROM[ELearning].[dbo].[users] where type='1' or type='2'";
            var con = condb.GetSqlConnection();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();
            return ds;
        }
        public static void DisableAccount(string email)
        {
            string table_name = "users";
            string[] columns = { "email_verify" };
            string[] values = { "-1" };
            string condition = "email='" + email + "'";
          condb.Update(table_name, columns,values, condition);
        }
        public static void ActiveAccount(string email)
        {
            string table_name = "users";
            string[] columns = { "email_verify" };
            string[] values = { "1" };
            string condition = "email='" + email + "'";
            condb.Update(table_name, columns, values, condition);
        }
        public static string getUsernameByVerifier(string verifier)
        {
            string table_name = "users";
            string[] columns = { "username" };
            string condition = " verifier='" + verifier + "'";
            var res=condb.Select(table_name, columns, condition);
            return res[0][0].ToString();
        }
        public static void setUsernameByVerifier(string verifier,string newUsername)
        {
            string table_name = "users";
            string[] columns = { "username" };
            string []values = { newUsername };
            string condition = " verifier='" + verifier + "'";
            condb.Update(table_name, columns, values, condition);
        }
    }
}