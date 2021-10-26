using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class manage_users : System.Web.UI.Page
    {
        DataBaseConnection condb = new DataBaseConnection();
        public void update_grid()
        {
            var data = UserMangement.getAllusers();
            GridView1.DataSource = data;
            GridView1.DataBind();
            up.Visible = false;
        }
        public static string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserMangement.isAdmin(Session["verifier"].ToString()))
                Response.Redirect("check.aspx");
            if (!IsPostBack)
            {
                update_grid();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
         //   GridView1.EditIndex = e.NewEditIndex;
            name.Text = GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            id.Text= GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            up.Visible = true;
            int y = 0;
        }
        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SendMail")
            {
                string email = e.CommandArgument.ToString();
                string rand = RandomString(8);
                string table_name = "users";
                string[] columns = { "email", "username" };
                string condition = "email='" + email + "'";
                var data = condb.Select(table_name, columns, condition);
                string[] columns_update = { "code_email" };
                string[] values_update = { rand };
                condb.Update(table_name, columns_update, values_update, "email='" + email + "'");
                UserMangement.sendmail(email, data[0][1].ToString(), rand);
                msg.InnerText = "be send ";
            }
            if(e.CommandName== "DisableAccount")
            {
                string email = e.CommandArgument.ToString();
                UserMangement.DisableAccount(email);
                msg.InnerText = "be Disable";
            }
            if(e.CommandName== "ActiveAccount")
            {
                string email = e.CommandArgument.ToString();
                UserMangement.ActiveAccount(email);
                msg.InnerText = "be Active";
            }
            // do something
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (password.Text != "" || name.Text != "")
            {
                var data = UserMangement.getUserInfo(id.Text);
                string email = data[0][0].ToString();
                email = email.Replace(" ", "");

                string salt = data[0][1].ToString();
                salt = salt.Replace(" ", "");
                string pass = password.Text;
                string ver = "";
                if(pass!="")
                 ver = ComputeSha256Hash(email + pass + salt);
                UserMangement.Update_user(id.Text, name.Text, ver);
                Response.Redirect("manage_users.aspx");
            }
            else
                Response.Redirect("manage_users.aspx");
            //8572d5e69c5e65cc0cd60f759faef8419447af5ab722fd2d7dc39bd548439c32                                    
        }

        protected void Cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_users.aspx");

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