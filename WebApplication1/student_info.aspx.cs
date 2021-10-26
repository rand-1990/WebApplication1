using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class student_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataBaseConnection condb = new DataBaseConnection();


            int id = UserMangement.getUserID(Session["verifier"].ToString());
            if (!IsPostBack)
            {
                if (UserMangement.check_info_student(id))
                {
                    string verifier = Session["verifier"].ToString();
                    string table_name = "student";
                    string[] columns = { "date_of_birth", "general_specialization", "accurate_specialization", "phone", "address", "identity_ID" };
                    string condition = "user_id='" + id + "'";
                    var data = condb.Select(table_name, columns, condition);
                    DateTime dt = DateTime.Parse(data[0][0].ToString());
                    string dt1 = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    birthdate.Text = dt1;
                    string name = UserMangement.getUsernameByVerifier(verifier);
                    username.Text = name;
                    general_specialization.Text = AES.Decrypt(data[0][1].ToString());
                    Branch.Text = AES.Decrypt(data[0][2].ToString());
                    phone.Text = AES.Decrypt(data[0][3].ToString());
                    address.Text = AES.Decrypt(data[0][4].ToString());
                    identity_ID.Text = AES.Decrypt(data[0][5].ToString());
                        //     general_specialization.Text = data[0][1].ToString();
                       //   accurate_specialization.Text = data[0][2].ToString();
                      //    phone.Text = data[0][3].ToString();
                     //  address.Text = data[0][4].ToString(); ;
                    // identity_ID.Text = data[0][5].ToString(); ;
                }
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            DataBaseConnection condb = new DataBaseConnection();

            if (Session["verifier"].ToString() != "" && UserMangement.isStudent(Session["verifier"].ToString()))
            {
                int id = UserMangement.getUserID(Session["verifier"].ToString());
                string verifier = Session["verifier"].ToString();
                UserMangement.setUsernameByVerifier(verifier, username.Text);

                if (UserMangement.check_info_student(id))
                {
                    //do update
                    string table_name = "student";
                    string[] columns = { "date_of_birth", "general_specialization", "accurate_specialization", "phone", "address", "identity_ID" };
                    string[] values = { birthdate.Text, AES.Encrypt(general_specialization.Text), AES.Encrypt(Branch.Text), AES.Encrypt(phone.Text), AES.Encrypt(address.Text), AES.Encrypt(identity_ID.Text) };
                    string condition = "user_id='" + id + "'";
                    condb.Update(table_name, columns, values, condition);
                }
                else
                {
                    //do insert
                    string table_name = "student";
                    string[] columns = { "user_id", "date_of_birth",  "general_specialization", "accurate_specialization", "phone", "address", "identity_ID" };
                    string[] values = { id.ToString(), birthdate.Text, AES.Encrypt(general_specialization.Text), AES.Encrypt(Branch.Text), AES.Encrypt(phone.Text), AES.Encrypt(address.Text), AES.Encrypt(identity_ID.Text )};
                    condb.Insert(table_name, columns, values);

                }
            }
        }

    }
}





