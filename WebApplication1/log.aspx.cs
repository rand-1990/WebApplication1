using System;

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
using WebApplication1;

namespace WebApplication1
{
    public partial class log : System.Web.UI.Page
    {


		private RSACrypto rsa = new RSACrypto();
		private RSAParameters param;

		protected void Page_Load(object sender, EventArgs e)
        {
			string path = System.Configuration.ConfigurationSettings.AppSettings["rsaPrivateKeyFilePath"];
			rsa.InitCrypto(path);
			param = rsa.ExportParameters(true);//public key

			if (IsPostBack)
			{
				// Postback
				btnLogin_ServerClick(null, null);
			}
			else
			{
				// Init
			}
		}
		// for embedding in the JavaScript
		public string GetRSA_E()
		{
			return StringHelper.BytesToHexString(param.Exponent);
		}
		// for embedding in the JavaScript
		public string GetRSA_M() //parameters with the keys  
		{
			return StringHelper.BytesToHexString(param.Modulus);
		}

		public string GetRSA_D()
		{
			return StringHelper.BytesToHexString(param.D);
		}
		[WebMethod(true)]
		public static string GetSalt(string email)//داله حتاخذ متغير اسمه ايميل وترجعلي الملح مالته 
		{
			DataBaseConnection condb = new DataBaseConnection(); //object from class dbconnection
			string table_name = "users";
			string []columns = { "salt" };
			string condition = "email='" + email + "'";// "email"=in table ++++ email =var intered
			var data=condb.Select(table_name, columns, condition);

			if (data.Length > 0)
				return data[0][0].ToString().Replace(" ", "");//Replace to  remove space
			else
				return "";
		}
		


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLogin_ServerClick(object sender, System.EventArgs e)
		{
			//decrypte verifier
			string verifier= StringHelper.ASCIIBytesToString(
					rsa.Decrypt(StringHelper.HexStringToBytes(Request.Params["verifier"])));


			if (false == CodeName.Util.ADAuthManager.IsAuthenticated(verifier))//داله اخذت  الفيريفاير كمدخل وراحت للفنكشن الاصلية جوه
			{
				lblError.Text =
					"Authentication failed, please check your email and password.";
				email.Value = "";
				password.Text = "";
				// log the detailed error
			}
			else
			{


		
				Session["verifier"] = verifier;

				DataBaseConnection database = new DataBaseConnection();
				string tablename = "users";
				string[] columns = { "id" };
				string condition = "verifier='" + Session["verifier"].ToString() + "'";
				var reader = database.Select(tablename, columns, condition);
				Session["id"] = reader[0][0];

				Response.Redirect("check.aspx");

			}
		}

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }

    class RSACrypto
	{
		private RSACryptoServiceProvider _sp;

		public RSAParameters ExportParameters(bool includePrivateParameters)
		{
			return _sp.ExportParameters(includePrivateParameters);
		}

		public void InitCrypto(string keyFileName)
		{
			CspParameters cspParams = new CspParameters();
			cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
			// To avoid repeated costly key pair generation
			_sp = new RSACryptoServiceProvider(cspParams);
			string path = keyFileName;
			System.IO.StreamReader reader = new StreamReader(path);
			string data = reader.ReadToEnd();
			_sp.FromXmlString(data);
		}

		public byte[] Encrypt(string txt)
		{
			byte[] result;

			ASCIIEncoding enc = new ASCIIEncoding();
			int numOfChars = enc.GetByteCount(txt);
			byte[] tempArray = enc.GetBytes(txt);
			result = _sp.Encrypt(tempArray, false);

			return result;
		}

		public byte[] Decrypt(byte[] txt)
		{
			byte[] result;

			result = _sp.Decrypt(txt, false);

			return result;
		}
	}

	class StringHelper
	{
		public static byte[] HexStringToBytes(string hex)
		{
			if (hex.Length == 0)
			{
				return new byte[] { 0 };
			}

			if (hex.Length % 2 == 1)
			{
				hex = "0" + hex;
			}

			byte[] result = new byte[hex.Length / 2];

			for (int i = 0; i < hex.Length / 2; i++)
			{
				result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
			}

			return result;
		}

		public static string BytesToHexString(byte[] input)
		{
			StringBuilder hexString = new StringBuilder(64);

			for (int i = 0; i < input.Length; i++)
			{
				hexString.Append(String.Format("{0:X2}", input[i]));
			}
			return hexString.ToString();
		}

		public static string BytesToDecString(byte[] input)
		{
			StringBuilder decString = new StringBuilder(64);

			for (int i = 0; i < input.Length; i++)
			{
				decString.Append(String.Format(i == 0 ? "{0:D3}" : "-{0:D3}", input[i]));
			}
			return decString.ToString();
		}

		// Bytes are string
		public static string ASCIIBytesToString(byte[] input)
		{
			System.Text.ASCIIEncoding enc = new ASCIIEncoding();
			return enc.GetString(input);
		}
		public static string UTF16BytesToString(byte[] input)
		{
			System.Text.UnicodeEncoding enc = new UnicodeEncoding();
			return enc.GetString(input);
		}
		public static string UTF8BytesToString(byte[] input)
		{
			System.Text.UTF8Encoding enc = new UTF8Encoding();
			return enc.GetString(input);
		}

		// Base64
		public static string ToBase64(byte[] input)
		{
			return Convert.ToBase64String(input);
		}

		public static byte[] FromBase64(string base64)
		{
			return Convert.FromBase64String(base64);
		}
	}
}

namespace CodeName.Util
{
	// As an example, Active Directory is used but query details are omitted for clarity.
	public class ADAuthManager
	{
		public static bool IsAuthenticated( string verifier)
		{


			DataBaseConnection condb = new DataBaseConnection();
			string table_name = "users";
			string[] columns = { "verifier" };
			string condition = "verifier='" + verifier + "'";
			var data=condb.Select(table_name, columns, condition);

			if (data.Length==1)
				return true;
			
			else
			{
				return false;
			}
		}


	}
}