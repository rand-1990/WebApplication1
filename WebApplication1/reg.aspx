<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="WebApplication1.reg" %>
<style>
    body {
                background: url('Scripts/uom.jpg'); no-repeat center center fixed; 
        -webkit-background-size: cover;
        -moz-background-size: cover;
        -o-background-size: cover;
        background-size: cover;

    }
</style>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
<script src="Scripts/sha256.js" type="text/javascript"></script>  
            <script src="Scripts/GenerateSalt.js" type="text/javascript"></script> 

<body>
        <form class="login-form" dir="rtl" method="post" id="reg_form" >

<section class="testimonial py-5" id="testimonial">
    <div class="container">
        <div class="row ">
            <div class="col-md-4 py-5 bg-primary text-white text-center ">
                <div class=" ">
                    <div class="card-body">
                        <img src="http://www.ansonika.com/mavia/img/registration_bg.svg" style="width:30%">
                        <h2 class="py-3">Registration</h2>
                        <p> Register new Account 

</p>
                    </div>
                </div>
            </div>
            <div class="col-md-8 py-5 border">
                <h4 class="pb-4">Please fill with your details</h4>
                <form>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                          <input id="username" name="Full Name" placeholder="Full Name" class="form-control" type="text">
                        </div>
                        <div class="form-group col-md-6">
                          <input type="email" class="form-control" id="email" placeholder="Email">
                        </div>
                      </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <input id="password" type="password" name="Password" placeholder="Password" class="form-control" required="required" type="text">
                            <input type="hidden" id="salt" name="salt" >
                            <input type="hidden" id="verifier" name="verivier" >
                        </div>

                        <div class="form-group col-md-6">
                        <select id="type" name="type" class="form-control">
                           
            <option value="1">Teacher</option>
            <option value="2">Student</option>
        </select>          
                                
                        </div>
                   
                    </div>
                    <div class="form-row">
                        <div class="form-group">
                            <div class="form-group">
                                <div class="form-check">
                                
                                </div>
                              </div>
                    
                          </div>
                    </div>
                    
                    <div class="form-row">
                        <input type="submit" class="btn btn-danger" value="submit" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</section>
            </form>
</body>

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
                        if (data.d == "email is registered please use another email")
                            alert("email is registered please use another email");
                        else
                            alert("تم التسجيل بنجاح");
                        window.location.href = "log.aspx";

                        console.log(data.status);
                        
                    },
                    error: function (data, status, jqXHR) { alert(jqXHR); }
                });
            });
        });
    </script>
