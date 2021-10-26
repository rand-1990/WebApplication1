using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class InviteByCSV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_Click(object sender, EventArgs e)
        {

            string classid = Request["id"];
            var class_info = ClassesManage.GetClassInfoByClassid(classid);
            string class_name = class_info[0][0].ToString();
            string class_code= class_info[0][3].ToString();
            HttpPostedFile postedFile = csv_file.PostedFile;
            string file_name = "";


            string userid = UserMangement.getUserID(Session["verifier"].ToString()).ToString();
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string result = Path.GetRandomFileName();
                string[] names = result.Split('.');
                string[] file_names = postedFile.FileName.Split('.');
                file_name = names[0] + "." + file_names[1];
                //Save the File.
                string filePath = Server.MapPath("~/uploads/") + file_name;
                postedFile.SaveAs(filePath);
            }
            var lines = File.ReadAllLines(Server.MapPath("~/uploads/") + file_name);
            for(int i=0;i<lines.Length;i++)
            {
                string email = lines[i];
                string msg = "the code of class: " + class_name + " is : " + class_code;
                UserMangement.sendmailClassCode(email, msg);
            }

        }
    }
}