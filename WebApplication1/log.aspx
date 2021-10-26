<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="WebApplication1.log" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0//EN" >
<HTML>
  <HEAD>
	    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);



		

.login-page {
  width: 360px;
  padding: 8% 10% 0;
  float:right;
  opacity:0.8;
  
}
.form {
  position: relative;
  z-index: 1;
  background: #FFFFFF;
  max-width: 360px;
 margin-right: 0 auto 100px; 
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.form input {
			    border-style: none;
                border-color: inherit;
                border-width: 0;
                font-family: "Roboto", sans-serif;
                outline: 0;
                background: #f2f2f2;
				width: 227px;
                margin: 0 0 15px;
                padding: 15px;
                box-sizing: border-box;
                font-size: 14px;
}
.form button {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background: #4CAF50;
  width: 100%;
  border: 0;
  padding: 15px;
  color: #FFFFFF;
  font-size: 14px;
  -webkit-transition: all 0.3 ease;
  transition: all 0.3 ease;
  cursor: pointer;
}
.form button:hover,.form button:active,.form button:focus {
  background: #43A047;
}
.form .message {
  margin: 15px 0 0;
  color: #b3b3b3;
  font-size: 12px;
}
.form .message a {
  color: #4CAF50;
  text-decoration: none;
}
.form .register-form {
  display: none;
}
.container {
  position: relative;
  z-index: 1;
  max-width: 300px;
  margin: 0 auto;
}
.container:before, .container:after {
  content: "";
  display: block;
  clear: both;
}
.container .info {
  margin: 50px auto;
  text-align: center;
}
.container .info h1 {
  margin: 0 0 15px;
  padding: 0;
  font-size: 36px;
  font-weight: 300;
  color: #1a1a1a;
}
.container .info span {
  color: #4d4d4d;
  font-size: 12px;
}
.container .info span a {
  color: #000000;
  text-decoration: none;
}
.container .info span .fa {
  color: #EF3B3A;
}
body {
  background: #76b852; /* fallback for old browsers */
  background: -webkit-linear-gradient(right, #76b852, #8DC26F);
  background: -moz-linear-gradient(right, #76b852, #8DC26F);
  background: -o-linear-gradient(right, #76b852, #8DC26F);
  background: linear-gradient(to left, #76b852, #8DC26F);
  font-family: "Roboto", sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;      
  background-image:url('Scripts/2.jpg');
  background-size:100% 150%  ;
  
}
            .auto-style1 {
                width: 100%;
            }
            .auto-style2 {
                width: 631px;
            }
            .auto-style3 {
                text-align: right;
				padding:1%
            }
            .auto-style4 {
                width: 666px;
                text-align: center;
            }
            .auto-style5 {
                text-align: left;
            }
    </style>
		<title>Login</title>
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="Scripts/crypto/BigInt.js"></script>
		<script language="javascript" src="Scripts/crypto/Barrett.js"></script>
		<script language="javascript" src="Scripts/crypto/RSA.js"></script>
	    <script src="Scripts/sha256.js" type="text/javascript"></script>
	      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

		<script language="javascript">
			
				var key;
				function initKey() {  //داله رح تجيبلي المفاتيح من السيرفر
					setMaxDigits(131);
					key = new RSAKeyPair("<%=GetRSA_E()%>", "", "<%=GetRSA_M()%>"); 
					//الداله الاولى تجيبلي مفتاح التشفير  والثانية تجيب الباراميتر ويا المفتاح
				}

				function SetSalt() {
					//console.log(em);
                $.ajax({  //الاجاكس تشتغل ويا الايفينت جوة حنشوف كلما يتغير الايميل يجيبلي الملح مالته
                    url: '/log.aspx/GetSalt',
                    data: "{'email': '" + document.getElementById("email").value+"'}" , //تدز بيانات الايميل
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "text",

                    success: function (data) {
                       
						console.log(data);
						data = JSON.parse(data);
                        console.log(data);

						document.getElementById('salt').value = data.d;
					

                    },
                    error: function (data, status, jqXHR) { alert(jqXHR); }
                });
				}
				function cmdEncrypt() {
					initKey();

		

					return;
				}



				var IsLoginStarted = false;

				function validateForm() {
					lblError.innerHTML = "";

					if (!validateEmail())
						return false;

					if (!validatePassword()) 
						return false;

					if (IsLoginStarted == true) {
						alert('Your request is being processed');
						return false;
					}
					else {
						IsLoginStarted = true;
						document.forms[0].btnLogin.disabled = true;
						startTimer();
						initKey(); //return key from server
                        salt = document.getElementById('salt').value;
                        email = document.getElementById('email').value;
						password = document.getElementById('password').value;
                        sha = sha256(email + password + salt); //sha=verifier
						//حصلت القيم الفوك وحسويلها هاش حتى اطلع الفيريفاير 
						
                        console.log(encryptedString(key,sha))
                        document.getElementById("verifier").value = encryptedString(key,sha); //Encrypt sha with key of RSA 
						document.forms[0].submit(); //go to the server
					}
				}

				function validateEmail() {
					var tempName = document.forms[0].email.value;

					if (isEmpty(tempName)) {
						alert("Please enter your email.");
						document.forms[0].email.focus();
						document.forms[0].email.select();
						return false;
					}
					else {
						return true;
					}
				}
				function validatePassword() {
					var tempName = document.forms[0].password.value;

					if (isEmpty(tempName)) {
						alert("Please enter your password.");
						document.forms[0].password.focus();
						document.forms[0].password.select();
						return false;
					}
					else {
							

						return true;
					}
				}

				function isEmpty(strTextField) {
					if (strTextField == "" || strTextField == null)
						return true;

					var re = /\s/g; // Match any white space including space, tab, form-feed, etc.
					RegExp.multiline = true; // IE support 
					var str = strTextField.replace(re, "");

					if (str.length == 0)
						return true;
					else
						return false;
				}

				function startTimer() {
					var label = document.getElementById('lblMsg');
					label.innerHTML = '<b>Please wait : </b>';

					window.setTimeout('showProgress()', 250);
				}

				function showProgress(n) {
					if (IsLoginStarted) {
						var label = document.getElementById('lblMsg');
						label.innerHTML += '<b>|</b>';

						window.setTimeout('showProgress()', 250);
					}
				}
        </script>
</HEAD>
	<body   >

		<div>

		    <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Font-Bold="True"  Font-Names ="Matura MT Script Capitals" Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="False" ForeColor="Red" Text="Mustansiriyah University Portal"></asp:Label>
 
		            </td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Size="X-Large" ForeColor="Red" NavigateUrl="~/reg.aspx">   Regestration</asp:HyperLink>
                    </td>
                </tr>
            </table>
 
		</div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Kristen ITC" Font-Size="XX-Large" ForeColor="Red" Text="Mustansiriyah University portal enables you learning from anywhere."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Kristen ITC" Font-Size="X-Large" Text="if you dont have an account just"></asp:Label>
                                <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/reg.aspx">click Here</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <br />
		 <div class="login-page">
			 <div>

			     <asp:Label ID="Label1" runat="server" Text="Hello ..." Font-Bold="True" ForeColor="Red" Font-Names="Bernard MT Condensed" Font-Overline="False" Font-Size="XX-Large"></asp:Label>
				 </div>
				 <div>
			     <asp:Label ID="Label2" runat="server" Text=" log in  and   start your education" Font-Bold="True" ForeColor="Red" Font-Names="Bernard MT Condensed" Font-Overline="False" Font-Size="X-Large"></asp:Label>

			 </div>
  <div class="form">
		<form id="Form1" method="post" class="login-form" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td align="right" height="28" nowrap></td>
				</tr>
			</table>
			
		
								
								<input type="text" placeholder="Email"  onchange="SetSalt();" MaxLength="30" id="email" runat="server"></input>
							
							
								<asp:TextBox EnableViewState="False" MaxLength="30" id="password" runat="server" TextMode="Password" placeholder="Password"
										Width="231px"></asp:TextBox>
							
							
									
										<INPUT Type="button" id="btnLogin" Runat="Server" Value="Login" onclick="javascript:validateForm();" NAME="btnLogin" style="color: #000000; background-color: #66FF99">
						
						<asp:Label id="lblMsg" EnableViewState="False" runat="server"></asp:Label><BR>
						<asp:Label id="lblError" EnableViewState="False" runat="server" ForeColor="red"></asp:Label><BR>
						
						<input type="hidden" id="verifier" name="verifier"/> 
						<INPUT type="hidden" id="salt" name="salt">

			
		</form>
	  </div>
			 </div>
	            </td>
            </tr>
        </table>
	</body>
</HTML>

