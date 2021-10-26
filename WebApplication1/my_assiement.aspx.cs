using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class my_assiement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string classid = Request["id"];
           string verifier = Session["verifier"].ToString();
            string userid = UserMangement.getUserID(verifier).ToString();
            if (!UserMangement.isStudent(verifier))
                Response.Redirect("classes_show.aspx");
            
            if (ClassesManage.UserCanAccessToClass(verifier,classid).Length==0)
                Response.Redirect("classes_show.aspx");
            string table = "<table class='table table-sm'>";
            table += "<tr>";
            table += "<th scope = 'col' >#</th>";
            table += "<th scope = 'col' > Assignment title </th>";

            table += "<th scope = 'col' >Assignment attachment </th>";

            table += "<th scope = col' >Assignment Start Date </th>";
            table += "<th scope = col' >Assignment End Date </th>";
            table += "<th scope = col' > Student attachment </th>";
            table += "<th scope = col' > Mark </th>";

            table += "</tr>";
            var data = ClassesManage.GetMyAssiemnet(classid, userid);
            int num = 0;
            for(int i=0;i<data.Length;i++)
            {
                table += "<tr class='table-primary'>";
                table += "<td>" + (++num).ToString() + "</td>";
                table += "<td>" + data[i][0].ToString() + "</td>";
                table += "<td><a target='_blank' href='" + "/uploads/" + data[i][1].ToString() + "'>download file</a></td>";
                table += "<td>" + data[i][2].ToString() + "</td>";
                table += "<td>" + data[i][3].ToString() + "</td>";

                table += "<td><a target='_blank' href='/uploads/" + data[i][5].ToString() + "'>show answer</a></td>";
                table += "<td>" + data[i][6].ToString() + "</td>";

            }
            html_data.InnerHtml = table;
        }
    }
}