using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string exam_code = Request["id"].ToString();
            if (!this.IsPostBack)
            {
                DataTable dt = ClassesManage.GetLoc(exam_code);
                rptMarkers.DataSource = dt;
                rptMarkers.DataBind();
            }
        }
    
    }
}