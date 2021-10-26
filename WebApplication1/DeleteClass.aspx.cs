using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.WebSockets;
using System;
using WebApplication1;
namespace WebApplication1
{
    public partial class DeleteClass : System.Web.UI.Page
    {

		protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            string verifier = Session["verifier"].ToString();
            var islecture = UserMangement.isLecture(verifier);
            var data = ClassesManage.UserCanAccessToClass(verifier, id);
            if (!(islecture == true && data.Length == 1))
                Response.Redirect("classes_show.aspx");
            var data_class = ClassesManage.GetClassInfoByClassid(id);
            class_label.InnerText ="delete class:"+ data_class[0][0].ToString();

		}

        protected void delete_Click(object sender, EventArgs e)
        {
			string verifier = Session["verifier"].ToString();
			var data_user = UserMangement.getUserInfoByVerifier(verifier);
			string compute_verifier = sha256(data_user[0][0].ToString().Replace(" ", "") + password.Value + data_user[0][1].ToString().Replace(" ", ""));
			string classid = Request["id"];

			//decrypte verifier


			if (verifier!= compute_verifier)//داله اخذت  الفيريفاير كمدخل وراحت للفنكشن الاصلية جوه
			{
				lblError.Text =
					"Authentication failed, please check your password.";
				password.Value = "";
				// log the detailed error
			}
			else
			{


				ClassesManage.DeleteClass(classid);
				Response.Redirect("classes_show.aspx");

			}
		}
		static string sha256(string randomString)
		{
			var crypt = new SHA256Managed();
			string hash = String.Empty;
			byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
			foreach (byte theByte in crypto)
			{
				hash += theByte.ToString("x2");
			}
			return hash;
		}

	}

}