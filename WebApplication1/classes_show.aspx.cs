using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class classes_show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
            var data= ClassesManage.GetUserClasses(Session["verifier"].ToString());
            string verifier = Session["verifier"].ToString();

            string value = "";
            int j = -1;
            //    value += "<div class='container'><div class='row'>";

            int len = data.Length;
            while (len % 3 != 0)
                len++;

            for (int i=0;i<len;i++)
            {
                if(i%3==0)
                {
                    if (i != 0)
                        value += "<br><br>";

                    value += "<div class='card-deck'>";
                }

                // value += "<div class='col-sm-3'><div class='card' style='background-color:" + data[i][5]+"' > ";
                // value += "<div class='card h-50'  + data[i][5] + "'></div>";
                if (i >= data.Length)
                {
                    value += "<div class='card' style='visibility: hidden;'> ";
                    value += "</div>";
                }

                else
                {
                    value += "<div class='card'>";
                    value += "<svg class='bd-placeholder-img card-img-top' width ='70%' height='150' xmlns='http://www.w3.org/2000/svg' aria-label='Placeholder: Image cap' preserveAspectRatio='xMidYMid slice' role='img'><title>class color</title><rect width='100%' height='100%' fill='" + data[i][5] + "'/><text x='50%' y='50%' fill='#dee2e6' dy='.3em'></text></svg>";
                    //value += "<svg class='bd-placeholder-img card-img-top' width ='100%' height='200' xmlns='http://www.w3.org/2000/svg' aria-label='Placeholder: Image cap' preserveAspectRatio='xMidYMid slice' role='img'><title>class color</title><rect width='100%' height='100%' fill='" + data[i][5] + "'/><text x='50%' y='50%' fill='#dee2e6' dy='.3em'></text></svg>";

                    value += "<div class='card-body'>";
                    value += "<h5 class='card-title'>" + data[i][1].ToString() + "</h5>";
                    value += "<p class='card-text'>";
                    value += data[i][3].ToString();
                    value += "</p><a href='class_post.aspx?id=" + data[i][0].ToString() + "' class='btn btn-primary'>go</a>";
                    if (UserMangement.isLecture(verifier))
                    {
                        value += "<a href='update_class.aspx?id=" + data[i][0].ToString() + "' class='btn btn-warning'>update</a>";
                        value += "<a onclick=" + "\"return confirm('Are you sure to delete?')\"href='DeleteClass.aspx?id=" + data[i][0].ToString() + "' class='btn btn-danger'>delete</a>";

                    }
                    value += "<br><small> date created:" + data[i][4].ToString() + "</small>";
                    value += "</div></div>";
                }

                if ((i+1)%3==0||(i==len-1))
                    value += "</div>";

            }
            //    value += "</div></div>";

            maindiv.InnerHtml = value;
        }
    }
}