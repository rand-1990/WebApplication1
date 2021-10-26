<%@ Page Language="C#"   MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="posts.aspx.cs" Inherits="WebApplication1.posts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    body {
    background: #eee
}

.date {
    font-size: 11px
}

.comment-text {
    font-size: 12px
}

.fs-12 {
    font-size: 12px
}

.shadow-none {
    box-shadow: none
}

.name {
    color: #007bff
}

.cursor:hover {
    color: blue
}

.cursor {
    cursor: pointer
}

.textarea {
    resize: none
}
</style>
    <script src="plugins/jquery/jquery.min.js"></script>

    <script>
        $(function () {
            $.ajax({
                url: '/posts.aspx/set_post_to_view',
                data: "",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "text",

                success: function (data) {

                    console.log(data);
                    data = JSON.parse(data);
                    console.log(data);
               
                    document.getElementById('all').innerHTML = data.d;

                },
                error: function (data, status, jqXHR) { alert(jqXHR); }
            });
        });
        function SendReply(d) {
            $.ajax({
                url: '/posts.aspx/SendReply',
                data: "{'postid': '" + d.value + "','comment':'" + document.getElementById("r"+d.value).value+"'}",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "text",

                success: function (data) {

                    console.log(data);
                    data = JSON.parse(data);
                    console.log(data);
                    data2 = JSON.parse(data.d.replaceAll('\'', "\""));
                    console.log(data2)
                    document.getElementById('rep' + d.value).innerHTML = '<p>' + data2.comment_msg + '</p>' + '<span class="d-block font-weight-bold name">' + data2.username + '</span>' +'<span class="date text-black-50">'+data2.comment_date+'</span>'+'<hr>'+document.getElementById('rep' + d.value).innerHTML

                },
                error: function (data, status, jqXHR) { alert(jqXHR); }
            });
        }
        function SendComment() {
            //console.log(em);
            $.ajax({ 
                url: '/posts.aspx/SendComment',
                data: "{'post': '" + document.getElementById("post_area").value + "'}",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "text",

                success: function (data) {

                    console.log(data);
                    data = JSON.parse(data);
                    console.log(data);
                    alert(data.d)
                    data2 = JSON.parse(data.d.replaceAll('\'',"\""));
                    console.log(data2)
                    document.getElementById('all').innerHTML = make_html_design(data2.post, data2.post_date,data2.username,data2.id) + document.getElementById('all').innerHTML;

                },
                error: function (data, status, jqXHR) { alert(jqXHR); }
            });
        }
        function make_html_design(post, datetime,username,id) {
            var ele = ' <div class="container mt-5">';
            ele += '<div class="d-flex justify-content-center row">';
            ele += '<div class="col-md-8">';
            ele += '<div class="d-flex flex-column comment-section">';
            ele += '<div class="bg-white p-2">';
            ele += '<div class="d-flex flex-row user-info"><img class="rounded-circle" src="" width="40">';
            ele += '<div class="d-flex flex-column justify-content-start ml-2"><span class="d-block font-weight-bold name">'+username+'</span><span class="date text-black-50">'+datetime+'</span></div>';
            ele += '</div><div class="mt-2"><p class="comment-text">' + post + '</p></div></div>'
            ele += '<div class=bg-white id=rep' + id + '></div>';
            ele += '<div class="bg-light p-2">';
            ele += '<div class="d-flex flex-row align-items-start"><img class="rounded-circle" src="https://upload.wikimedia.org/wikipedia/commons/8/81/Logoo2.png" width="40"><textarea class="form-control ml-1 shadow-none textarea" id=r'+id+'></textarea></div>'
            //ele += '<div class="mt-2 text-right"><button class="btn btn-primary btn-sm shadow-none" value=' + id + ' onclick="SendReply(this)" type="button">Comment</button><button class="btn btn-outline-primary btn-sm ml-1 shadow-none" type="button">Cancel</button></div>';
            ele += '<div class="mt-2 text-right"><button class="btn btn-primary btn-sm shadow-none" value=' + id + ' onclick="SendReply(this)" type="button">Comment</button></div>';
            ele += '</div></div ></div > </div >';
            return ele;
            /*   <div class="bg-white">
                    <div class="d-flex flex-row fs-12">
                        <div class="like p-2 cursor"><i class="fa fa-thumbs-o-up"></i><span class="ml-1">Like</span></div>
                        <div class="like p-2 cursor"><i class="fa fa-commenting-o"></i><span class="ml-1">Comment</span></div>
                        <div class="like p-2 cursor"><i class="fa fa-share"></i><span class="ml-1">Share</span></div>
                    </div>
                </div>*/

        }
    </script>
 <div class="form-group green-border-focus">
  <label for="exampleFormControlTextarea5">Post </label>
&nbsp;<textarea class="form-control" id="post_area" name="post_area" rows="3"></textarea>
   <div class="mt-2 text-right"><button class="btn btn-primary btn-sm shadow-none" onclick="SendComment()" type="button">Publish</button></div>
<%--   <div class="mt-2 text-right"><button class="btn btn-primary btn-sm shadow-none" onclick="SendComment()" type="button">Publish</button><button class="btn btn-outline-primary btn-sm ml-1 shadow-none" type="button">Cancel</button></div>--%>

</div>
<div id="all">

</div>



  </asp:content>
