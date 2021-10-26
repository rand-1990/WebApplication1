<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication1.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

.login-page {
  width: 360px;
  padding: 8% 0 0;
  margin: auto;
}
.form {
  position: relative;
  z-index: 1;
  background: #FFFFFF;
  max-width: 360px;
  margin: 0 auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.form input {
  font-family: "Roboto", sans-serif;
  outline: 0;
  background: #f2f2f2;
  width: 100%;
  border: 0;
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
}
    </style>
    <style>
.loader {
  border: 16px solid #f3f3f3;
  border-radius: 50%;
  border-top: 16px solid blue;
  border-bottom: 16px solid blue;
  width: 120px;
  height: 120px;
  -webkit-animation: spin 2s linear infinite;
  animation: spin 2s linear infinite;
   position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    transform: -webkit-translate(-50%, -50%);
    transform: -moz-translate(-50%, -50%);
    transform: -ms-translate(-50%, -50%);
    color:darkred;
}

@-webkit-keyframes spin {
  0% { -webkit-transform: rotate(0deg); }
  100% { -webkit-transform: rotate(360deg); }
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}
</style>
        <script src="Scripts/sha256.js" type="text/javascript"></script>  
            <script src="Scripts/GenerateSalt.js" type="text/javascript"></script> 
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</head>
<body>
<div class="loader"></div>

 <div class="login-page">
  <div class="form">
     
     

    <form class="login-form" dir="rtl" method="post" id="reg_form" >
      <input type="text" id="username" name="username" placeholder="الاسم"/>
      <input type="text" id="email" name="email" placeholder="البريد الالكتروني"/>
      <input type="password" id="password" name="password" placeholder="كلمة المرور"/>
      <input type="text" id="salt" name="salt" placeholder="الملح"/>
       <input type="text" id="verifier" name="verivier" placeholder="verifier"/>
          <div class="form-group">
        <select id="type" name="type" class="form-control">
            <option value="1">استاذ</option>
            <option value="2">طالب</option>
        </select>
              </div>
        <input type="submit" value="تسجيل" style="background-color: #00FF00" />
      
    </form>
  </div>
</div>
</body>
</html>

    <script type="text/javascript">
        $(document).ready(function () { /* اول مااشغل اريد يولدلي الملح لذلك مصطلح ريدي*/
            document.getElementById('salt').value = makesalt(8); /* قيمة الملح اخذها من الفنكشن ميك سولت طوله8 */
            $('#username').on('input', function (e) {
                //alert(this.value);
              

            });
            $('#email').on('input', function (e) {       /*هذا ايفينت */
                  var email = this.value; /* ديجيب قيم بالجافا سكربت هنا للايميل*/
                var password = document.getElementById('password').value; /* عرف متغير اسمه باسورد رح يجيب قيمته من الفوك*/ 
                var salt = document.getElementById('salt').value;
                if (email != "" && password != "" && salt!= "")
            document.getElementById('verifier').value = sha256(email + password + salt);
            });
            $('#password').on('input', function (e) {
                var password = this.value;
                var  email= document.getElementById('email').value;
                var salt = document.getElementById('salt').value;
                if (email != "" && password != "" && salt!= "")
        document.getElementById('verifier').value = sha256(email + password + salt);  
            });


        //ajax
            $("#reg_form").on("submit", function () {
                event.preventDefault();//refresh the page cancel loading

               // data = "{ 'username': '" + document.getElementById("username").value + "'," + "'email': '" + document.getElementById("email").value + "'," + "'salt': '" + document.getElementById("salt").value + "'," + "'verifier': '" + document.getElementById("verifier").value + "'}",
                 //   console.log(data);
              //  alert("here");
                $.ajax({
                    // السابق جان الشغل بالبراوزر او الكلاينت هسه اريد ادز للسيرفر فحروح على السيرفر من خلال يو ار ال 
                     // اكو فنكشن اسمها رجستر_ حتى اضيف القيم للداتا بيس مع عدم حفظ  الباسورد الصريح  
                  
                     
                    url: '/register.aspx/register_',
                    data: "{ 'username': '" + document.getElementById("username").value + "'," + "'email': '" + document.getElementById("email").value + "'," + "'salt': '" + document.getElementById("salt").value + "'," + "'verifier': '" + document.getElementById("verifier").value+ "',"+ "'type': '" + document.getElementById("type").value+"'}",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',

                    success: function (data) {
                        // alert('insert was performed.');
                   //     alert(data);
                        console.log(data);
                        alert(data.d);
                        if (data.d == "email is registered please use another email")
                            alert("email is registered please use another email");
                        else
                        alert("تم التسجيل بنجاح");
                        console.log(data.status);
                        
                    },
                    error: function (data, status, jqXHR) { alert(jqXHR); }
                });
            });
        });
    </script>
