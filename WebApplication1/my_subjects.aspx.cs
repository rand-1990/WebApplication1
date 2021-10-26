using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class my_subjects : System.Web.UI.Page
    {
        static string verifier;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            string classid = Request["id"];
            string verifier = Session["verifier"].ToString();
            string userid = UserMangement.getUserID(verifier).ToString();
            if (!UserMangement.isStudent(verifier))
                Response.Redirect("classes_show.aspx");

            if (ClassesManage.UserCanAccessToClass(verifier, classid).Length == 0)
                Response.Redirect("classes_show.aspx");
            var data_current = ClassesManage.getSubjects(classid);

            string table = "<table class='table table-sm'>";
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > Title </th>";

            table += "<th scope = 'col' > Attachment </th>";



            table += "</tr>";
            int num = 0;
            for (int i = 0; i < data_current.Length; i++)
            {
                table += "<tr class='table-primary'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data_current[i][0].ToString() + "</td>";
                if(data_current[i][1].ToString()=="" && data_current[i][3].ToString()!="")
                    table += "<td><a target='_blank' href='" + data_current[i][3].ToString() + "'>video path</a></td>";
                else
                table += "<td><a target='_blank' href='" + "/uploads/" + data_current[i][1].ToString() + "'>download file</a></td>";

                table += "</tr>";
            }

            html_data.InnerHtml = table;
        }
    }
}