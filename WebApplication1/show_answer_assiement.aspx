<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="show_answer_assiement.aspx.cs" Inherits="WebApplication1.show_answer_assiement" %>
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

     function save_mark(d) {
         var val = d.value;
         var new_val = val.split("_");
         var text_id = "u" + new_val[0] + "_" + "a" + new_val[1];
         var mark_value = document.getElementById(text_id).value;
             $.ajax({
                 url: '/show_answer_assiement.aspx/SendMark',
                 data: "{'mark': '" + mark_value + "','userid':'" + new_val[0] + "','assiementid':'"+new_val[1]+"'}",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataType: "text",

                 success: function (data) {

                     console.log(data);
                     data = JSON.parse(data);
                    
                     document.getElementById("mark_" + new_val[0]+"_"+new_val[1]).innerText ="mark: "+ data.d;

                 },
                 error: function (data, status, jqXHR) { alert(jqXHR); }
             });
     }
     </script>
    <div id="html_data" runat="server">

    </div>
</asp:Content>
