using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["verifier"]!=null) // if has a log in 
            {
                DataBaseConnection database = new DataBaseConnection();
                string tablename = "users";
                string[] columns = { "type" };
                string condition = "verifier='" + Session["verifier"].ToString() + "'";
                var reader = database.Select(tablename, columns, condition);
                if(reader.Length==1)
                {
                    
                    if (reader[0][0].ToString() != "1")
                        Response.Redirect("default.aspx");
                        //go out
                }
            }
            else
                Response.Redirect("log.aspx");

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
     
        protected void Add_Class(object sender, EventArgs e)
        {
            string name = Request.Params["name"];
            string desc = Request.Params["descr"];
            var color_val = color.Value;
            string userId = Session["id"].ToString();
            string code = RandomString(10);
            ClassesManage.insertClass(name, code, desc, userId,color_val);
            string class_id = ClassesManage.GetCLassIDByCode(code);
            ClassesManage.InsertUsersCLasses(class_id, userId);
            lab.Text = "Inserted Successfully with code=" + code ;
        }

   
    }
}