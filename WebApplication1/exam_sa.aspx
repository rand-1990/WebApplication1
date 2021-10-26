<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="exam_sa.aspx.cs" Inherits="WebApplication1.exam_sa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

    </script>
<script>


    function end_exam() {
        var data = document.getElementById('sa_ids').value;
       var sa_ids = document.getElementById('sa_ids').value;
        data = data.split(",");
        var res = "";
        for (i = 0; i < data.length; i++) {
            if (document.getElementById("q" + data[i]).value == "")
                document.getElementById("q" + data[i]).value = "no answer";
            if (res != "")
                res += "<#>"
            res += document.getElementById("q" + data[i]).value;

            //res += data[i] + ":" + get_selected(rad);
            console.log(res)

        }
        var fmd = new FormData();
        fmd.append("quizid", getUrlParameter("id"));
        fmd.append("data", res);
     
        //
        $.ajax({
            url: '/exam_sa.aspx/SendResponse',
            data: "{'quizid': '" + getUrlParameter("id") + "','data':'" + res + "','sa_ids':'"+sa_ids+"'}",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "text",

            success: function (data) {

                console.log(data);
                data = JSON.parse(data);
                console.log(data);
         

                window.location.href = "classes_show.aspx";
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

</script>
    <form runat="server" style="margin-top: 20px">

        <div runat="server" id="html_data" >


        </div>

        <button type="submit" id="join" onclick="end_exam()" value="End" class="btn btn-primary" >end</button>

    </form>
</asp:Content>
