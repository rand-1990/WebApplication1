using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class lecture_info : System.Web.UI.Page
    {
        static DataBaseConnection condb = new DataBaseConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            
                
                int id = UserMangement.getUserID(Session["verifier"].ToString());
            if (!IsPostBack)
            {
                if (UserMangement.check_info_lecture(id))
                {
                    string verifier = Session["verifier"].ToString();
                    string table_name = "teacher";
                    string[] columns = { "date_of_birth", "certificate", "scientific_title", "general_specialization", "accurate_specialization", "phone", "address", "identity_ID" };
                    string condition = "user_id='" + id + "'";
                    var data = condb.Select(table_name, columns, condition);
                    string name = UserMangement.getUsernameByVerifier(verifier);
                    DateTime dt = DateTime.Parse(data[0][0].ToString());
                    string dt1 = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    birthdate.Text = dt1;
                    certificate.Text = AES.Decrypt(data[0][1].ToString());
                    string[] value_sci =AES.Decrypt( data[0][2].ToString()).Split(' ');
                    username.Text = name;
                    string sci = "";
                    sci = value_sci[0];
                    if(value_sci.Length>1)
                    if (value_sci[1] != " " && value_sci[1] != "" && value_sci[1].Length > 1)
                        sci += " " + value_sci[1];

                    var x=scientific_title.Items.FindByValue(sci);
                    if(x!=null)
                    x.Selected = true;
                    general_specialization.Text =AES.Decrypt( data[0][3].ToString());
                    accurate_specialization.Text =AES.Decrypt( data[0][4].ToString());
                    phone.Text =AES.Decrypt( data[0][5].ToString());
                    address.Text =AES.Decrypt( data[0][6].ToString()) ;
                    identity_ID.Text =AES.Decrypt( data[0][7].ToString()); ;
                }
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (Session["verifier"].ToString() != "" && UserMangement.isLecture(Session["verifier"].ToString()))
            {
                string verifier = Session["verifier"].ToString();
                UserMangement.setUsernameByVerifier(verifier, username.Text);

                int id = UserMangement.getUserID(Session["verifier"].ToString());
                if (UserMangement.check_info_lecture(id))
                {
                    //do update
                 
                    string table_name = "teacher";
                    string[] columns = { "date_of_birth","certificate","scientific_title","general_specialization","accurate_specialization","phone","address","identity_ID" };
                    string[] values = { birthdate.Text,AES.Encrypt( certificate.Text),AES.Encrypt( scientific_title.Value),AES.Encrypt( general_specialization.Text),AES.Encrypt( accurate_specialization.Text),AES.Encrypt( phone.Text),AES.Encrypt( address.Text),AES.Encrypt( identity_ID.Text) };
                    string condition = "user_id='" + id + "'";
                    condb.Update(table_name, columns, values, condition);
                }
                else
                {
                    //do insert
                    var phone_num = AES.Encrypt(phone.Text);
                    var address_ = AES.Encrypt(address.Text);
                    string table_name = "teacher";
                    string[] columns = {"user_id", "date_of_birth", "certificate", "scientific_title", "general_specialization", "accurate_specialization", "phone", "address", "identity_ID" };
                    string[] values = { id.ToString(), birthdate.Text,AES.Encrypt( certificate.Text),AES.Encrypt( scientific_title.Value),AES.Encrypt( general_specialization.Text),AES.Encrypt( accurate_specialization.Text), AES.Encrypt(phone.Text), AES.Encrypt(address.Text),AES.Encrypt( identity_ID.Text) };
                    condb.Insert(table_name, columns, values);

                }
            }
        }
    }
}