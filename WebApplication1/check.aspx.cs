using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class check : System.Web.UI.Page
    {
        DataBaseConnection condb = new DataBaseConnection();

        public static string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["verifier"].ToString() != "")
                {
                    string table_name = "users";
                    string[] columns = { "verifier", "email_verify", "email", "username", "type","id" };
                    string condition = "verifier='" + Session["verifier"] + "'";
                    var data = condb.Select(table_name, columns, condition);
                    if (data[0][1].ToString() == "1")
                    {
                        UserMangement.add_user_login_history(Int32.Parse(data[0][5].ToString()),data[0][4].ToString());
                        if (data[0][4].ToString() == "1")
                        {
                            Response.Redirect("lecture_info.aspx");
                           
                        }
                        else if (data[0][4].ToString() == "2")
                            Response.Redirect("student_info.aspx");
                        else if (data[0][4].ToString() == "3")
                            Response.Redirect("main_admin.aspx");
                    }
                 //   string rand = RandomString(8);
               //     string[] columns_update = { "code_email" };
                //    string[] values_update = { rand };
                //    condb.Update(table_name, columns_update, values_update, "email='" + data[0][2].ToString() + "'");
                //    UserMangement.sendmail(data[0][2].ToString(), data[0][3].ToString(), rand);

                }
            }
        }
        protected void btn_ServerClick(object sender, System.EventArgs e)
        {
            if (Session["verifier"].ToString() != "")

            {
                string table_name = "users";
                string[] columns = { "code_email", "email_verify", "email", "username", "type" };
                string condition = "verifier='" + Session["verifier"] + "'";
                var data = condb.Select(table_name, columns, condition);
                if (data[0][0].ToString().Replace(" ", "") == code.Text&& data[0][0].ToString().Replace(" ", "") !="")
                {
                    string[] columns_update = { "email_verify" };
                    string[] values_update = { "1" };
                    //اسم الجدول , والعمود الي حيصير عليه ابديت, القيمة المحدثه ,لهذا الايميل 
                    condb.Update(table_name, columns_update, values_update, "email='" + data[0][2].ToString() + "'");
                   
                    if (data[0][4].ToString() == "2")
                    {
                        Response.Redirect("student_info.aspx");

                    }
                    else if (data[0][4].ToString() == "1")
                        Response.Redirect("lecture_info.aspx");

                }
                else
                    lblError.Text = "code error";
                }
            }
        }
    }
