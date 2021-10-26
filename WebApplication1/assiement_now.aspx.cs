using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class assiement_now : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string classid = Request["id"];
            if (!UserMangement.isStudent(Session["verifier"].ToString()))
                Response.Redirect("classes_show.aspx");
           var data= ClassesManage.getCurrentAssiement(classid);
            string all_data = "";
            for(int i=0;i<data.Length;i++)
            {
                all_data += "<div class=card>";
                all_data += "<h5 class='card-header'>Assiement</h5>";
                all_data += " <div class='card-body'>";
                all_data += " <h5 class='card-title'>"+data[i][0]+"</h5>";
                all_data += "<p class='card-text'>start in "+data[i][2]+" end in "+data[i][3]+"</p>";
                all_data += "<a target='_blank' href ='send_answer.aspx?id=" + data[i][6]+"' class='btn btn-primary'>Go To</a>"; 
                all_data += " </div></div>";
            }
            html_data.InnerHtml = all_data;
        }
    }
}