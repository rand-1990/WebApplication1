using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Web.Services;
using Microsoft.Ajax.Utilities;

namespace WebApplication1
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public partial class register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string hashedData = ComputeSha256Hash("a");
            int x = 0;
            //SqlCommand com = new SqlCommand("select * from users", conn);
            //SqlDataReader reader= com.ExecuteReader();
          //  while(reader.Read())
            //{

//            }

        }

          [WebMethod(true)]

        public static string register_(string username,string email,string salt,string verifier,string type)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ELearning;Integrated Security=True");
            conn.Open();
            if(UserMangement.getUserifHasAccount(email)==1)
                return "email is registered please use another email";

            string query ="insert into users(username,email,salt,verifier,type) values('" + username + "','" + email + "','" + salt + "','" + verifier + "','"+type+ "')";
            SqlCommand com = new SqlCommand(query,conn);
            int val=com.ExecuteNonQuery();
            if (val == 1)
                return "{'status':'ok'}";
            else
                return "{'status':'fail'}";

        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}