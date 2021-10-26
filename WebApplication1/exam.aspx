<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="exam.aspx.cs" Inherits="WebApplication1.exam" %>
    <!doctype html>
                        <html>
                            <head>
                                <meta charset='utf-8'>
                                <meta name='viewport' content='width=device-width, initial-scale=1'>
                                <title>Snippet - BBBootstrap</title>
                                <link href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css' rel='stylesheet'>
                                <link href='https://use.fontawesome.com/releases/v5.7.2/css/all.css' rel='stylesheet'>
                                <style>@import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');

* {
    padding: 0;
    margin: 0;
    box-sizing: border-box;
    font-family: 'Poppins', sans-serif
}

body {
    background: teal
}

.wrapper {
    max-width: 600px;
    margin: 80px auto 50px;
    padding: 30px;
    border-radius: 20px;
    background: #c0e2df;
    position: relative;
    min-height: 400px;
    overflow: hidden
}

.wrapper .wrap {
    width: 500px;
    position: absolute;
    left: 50px;
    transition: 0.6s
}

#q2,
#q3 {
    left: 650px
}

.h4 {
    margin: 0
}

label {
    display: block;
    margin-bottom: 15px;
    font-size: 1.2rem;
    cursor: pointer
}

.options {
    position: relative;
    padding-left: 30px
}

.options input {
    opacity: 0
}

.checkmark {
    position: absolute;
    top: 4px;
    left: 3px;
    height: 20px;
    width: 20px;
    background-color: #c0e2df;
    border: 2px solid #444;
    border-radius: 50%
}

.options input:checked~.checkmark:after {
    display: block
}

.options .checkmark:after {
    content: "";
    width: 9px;
    height: 9px;
    display: block;
    background: white;
    position: absolute;
    top: 51%;
    left: 51%;
    border-radius: 50%;
    transform: translate(-50%, -50%) scale(0);
    transition: 300ms ease-in-out 0s
}

.options input[type="radio"]:checked~.checkmark {
    background: #590995;
    border: 2px solid #590995;
    transition: 300ms ease-in-out 0s
}

.options input[type="radio"]:checked~.checkmark:after {
    transform: translate(-50%, -50%) scale(1)
}

.btn.btn-primary {
    background-color: rgb(63, 139, 139);
    border: 1px solid rgb(63, 139, 139)
}

.btn {
    background-color: inherit;
    border: 1px solid rgb(63, 139, 139);
    border-radius: 20px
}

.btn:focus {
    box-shadow: none
}

.btn:hover {
    background-color: teal;
    color: #fff
}

.fa-arrow-right,
.fa-arrow-left {
    transition: 0.2s ease-in all
}

.btn.btn-primary:hover .fa-arrow-right {
    transform: translate(8px)
}

.btn.btn-primary:hover .fa-arrow-left {
    transform: translate(-8px)
}

@media(max-width: 767px) {
    .wrapper {
        margin: 30px 10px;
        height: 420px
    }

    .wrapper .wrap {
        width: 280px;
        left: 15px
    }
}

.switch {
    position: relative;
    display: inline-block;
    width: 60px;
    height: 28px;
    background-color: inherit
}

.switch input {
    opacity: 0;
    width: 0;
    height: 0
}

.slider {
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: #ccc;
    -webkit-transition: .4s;
    transition: .4s
}

.slider:before {
    position: absolute;
    content: "";
    height: 20px;
    width: 20px;
    left: 4px;
    bottom: 4px;
    background-color: #590995;
    -webkit-transition: .4s;
    transition: .4s
}

input:checked+.slider {
    background-color: #000
}

input:focus+.slider {
    box-shadow: 0 0 1px #2196F3
}

input:checked+.slider:before {
    transform: translateX(30px);
    background-color: #fff
}

.slider.round {
    border-radius: 34px
}

.slider.round:before {
    border-radius: 50%
}

.dark-theme {
    background-color: #222
}</style>
                                <script type='text/javascript' src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>
                                <script type='text/javascript' src='https://stackpath.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.bundle.min.js'></script>
                                <script type='text/javascript'></script>
                            </head>
                            <body oncontextmenu='return false' class='snippet-body'>
                                <div id="all_html" runat="server">
                               <center><p style="font-size:x-large" id="demo"></p></center> 

                            <div class="wrapper">
    <div class="wrap" id="q1">
        <div class="text-center pb-4">
            <div class="h5 font-weight-bold"><span id="number"> </span>1 of 3 </div>
        </div>
        <div class="h4 font-weight-bold"> 1. Who is the Prime Minister of India?</div>
        <div class="pt-4">
            <form> <label class="options">Rahul Gandhi <input type="radio" name="radio"> <span class="checkmark"></span> </label> <label class="options">Indira Gandhi <input type="radio" name="radio"> <span class="checkmark"></span> </label> <label class="options">Narendra Modi <input type="radio" name="radio" id="rd" checked> <span class="checkmark"></span> </label> <label class="options">Ram Nath Kovind <input type="radio" name="radio"> <span class="checkmark"></span> </label> </form>
        </div>
        <div class="d-flex justify-content-end pt-2"> <button value="n1" onclick="next(this)" class="btn btn-primary" id="next1">Next <span class="fas fa-arrow-right"></span> </button> </div>
    </div>
    <div class="wrap" id="q2" style="display:none">
        <div class="text-center pb-4">
            <div class="h5 font-weight-bold"> <span id="number"> </span>2 of 3 </div>
        </div>
        <div class="h4 font-weight-bold"> 2. IPV4 stand's for?</div>
        <div class="pt-4">
            <form> <label class="options">Internet Protocol <input type="radio" name="radio"> <span class="checkmark"></span> </label> <label class="options">Intranet Protocol <input type="radio" name="radio" checked> <span class="checkmark"></span> </label> <label class="options">internet Protocol <input type="radio" name="radio" id="rd"> <span class="checkmark"></span> </label> <label class="options">None of the above <input type="radio" name="radio"> <span class="checkmark"></span> </label> </form>
        </div>
        <div class="d-flex justify-content-end pt-2"> <button  class="btn btn-primary mx-3" id="back1"> <span class="fas fa-arrow-left pr-1"></span>Previous </button> <button class="btn btn-primary" value="n2" onclick="next(this)" id="next2">Next <span class="fas fa-arrow-right"></span> </button> </div>
    </div>
    <div class="wrap" id="q3" style="display:none">
        <div class="text-center pb-4">
            <div class="h5 font-weight-bold"> <span id="number"> </span>3 of 3 </div>
        </div>
        <div class="h4 font-weight-bold"> 3. What is the full form of CSS?</div>
        <div class="pt-4">
            <form> <label class="options">Clarity Style Sheets <input type="radio" name="radio"> <span class="checkmark"></span> </label> <label class="options">Cascading Style Sheets <input type="radio" name="radio"> <span class="checkmark"></span> </label> <label class="options">Confirm Style sheets <input type="radio" name="radio" id="rd" checked> <span class="checkmark"></span> </label> <label class="options">Canvas Style Sheets <input type="radio" name="radio"> <span class="checkmark"></span> </label> </form>
        </div>
        <div class="d-flex justify-content-end pt-2"> <button class="btn btn-primary mx-3" value="b3" onclick="perv(this)" id="back2"> <span class="fas fa-arrow-left pr-2"></span>Previous </button>  </div>
    </div>

</div>
                          <center>      <input type="submit" value="end exam" class="btn btn-primary" /></center>
<div class="d-flex flex-column align-items-center">
    <div class="h3 font-weight-bold text-white">Go Dark</div> <label class="switch"> <input type="checkbox"> <span class="slider round"></span> </label>
</div>
                                    </div>
                                    <script src="plugins/jquery/jquery.min.js"></script>
    <script>
        var getUrlParameter = function getUrlParameter(sParam) {
            var sPageURL = window.location.search.substring(1),
                sURLVariables = sPageURL.split('&'),
                sParameterName,
                i;

            for (i = 0; i < sURLVariables.length; i++) {
                sParameterName = sURLVariables[i].split('=');

                if (sParameterName[0] === sParam) {
                    return typeof sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
                }
            }
            return false;
        };
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {

                window.lat = position.coords.latitude;
                window.lng = position.coords.longitude;
            });
        }
    </script>
<script>
  
    function next(t) {
        var q = t.value;
        var nx = q.substring(1);
        var next_ = document.getElementById("n" + nx).value;
        //console.log(q);
        //console.log(nx)
     //   document.getElementById("q"+nx).style.display = "none";
        document.getElementById(next_).style.left = "15px";;
        document.getElementById("q" + nx).style.left = "-650px";

        var num = parseInt(nx);
     //   for (i = 1; i <= num; i++)
       //     document.getElementById("q" + i).style.left = "-650px";;

     //   num = num + 1;
     //   var next_div = "q" + num;
     //   console.log(next_div);
   ////     document.getElementById(next_div).style.display = "block";
       // document.getElementById(next_div).style.left = "15px";

      
    }
    function perv(t) {
        var q = t.value;
        var pv = q.substring(1);
        var perv_ = document.getElementById("p" + pv).value;
        //console.log(q);
        //console.log(nx)
        //   document.getElementById("q"+nx).style.display = "none";
        document.getElementById(perv_).style.left = "15px";;
        document.getElementById("q" + pv).style.left = "650px";
      // var num = parseInt(nx);
    }
    function uncheck() {
        var rad = document.getElementById('rd')
        rad.removeAttribute('checked')
    }
    function end_exam() {
        var data = document.getElementById('all_questions').value;
        data = data.split(",");
        var res = "";
        for (i = 0; i < data.length; i++) {
            if (res != "")
                res += ","
            var rad = document.getElementsByName("r" + data[i]);

            res += data[i] + ":" + get_selected(rad);
            console.log(res)

        }
    
      
        data = "{'quizid': '" + getUrlParameter("id") + "','data':'" + res + "','lat':'" + window.lat + "','lng':'" + window.lng + "'}",
            console.log(data);
        $.ajax({
            url: '/exam.aspx/SendResponse',
            data: "{'quizid': '" + getUrlParameter("id") + "','data':'" + res + "','lat':'" + window.lat + "','lng':'" +window.lng+ "'}",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "text",

            success: function (data) {

                console.log(data);
                data = JSON.parse(data);
                console.log(data);
                if (data.d != "-1")
                    alert("mark is :" + data.d+" continue to sa");

                window.location.href = "exam_sa.aspx?id=" + getUrlParameter("id") ;
            },
            error: function (data, status, jqXHR) { alert(jqXHR); }
        });
   
    }
    function get_selected(radios) {

        for (var i = 0, length = radios.length; i < length; i++) {
            if (radios[i].checked) {
                // do whatever you want with the checked radio
                return (radios[i].value);

                // only one radio can be logically checked, don't check the rest
                // break;
            }
        }
        return "0";
    }
    document.addEventListener('DOMContentLoaded', function () {
        const main = document.querySelector('body')
        const toggleSwitch = document.querySelector('.slider')
        toggleSwitch.addEventListener('click', () => {
            main.classList.toggle('dark-theme')
        })
    })
</script>
                                <script>
                                    // Set the date we're counting down to
                                    var dt = document.getElementById('end_date').value;
                                    var countDownDate = new Date(dt).getTime();

                                    // Update the count down every 1 second
                                    var x = setInterval(function () {

                                        // Get today's date and time
                                        var now = new Date().getTime();

                                        // Find the distance between now and the count down date
                                        var distance = countDownDate - now;

                                        // Time calculations for days, hours, minutes and seconds
                                        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                                        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                                        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                                        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                                        // Display the result in the element with id="demo"
                                        document.getElementById("demo").innerHTML =  hours + "h "
                                            + minutes + "m " + seconds + "s ";

                                        // If the count down is finished, write some text
                                        if (distance < 0) {
                                            end_exam();
                                            clearInterval(x);
                                            document.getElementById("demo").innerHTML = "EXPIRED";
                                        }
                                    }, 1000);
</script>

                            </body>
                        </html>