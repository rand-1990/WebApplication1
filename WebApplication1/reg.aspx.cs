using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]

        public static string register_(string username, string email, string salt, string verifier, string type)
        {   
            if(UserMangement.getUserifHasAccount(email)>0)
                return "email is registered please use another email";

            DataBaseConnection db = new DataBaseConnection();
            string[] columns = { "username", "email", "salt", "verifier", "type" };
            string []values = { username, email, salt, verifier, type };
            db.Insert("users", columns, values);
            return "{'status':'ok'}";
           

        }
      
    }
}