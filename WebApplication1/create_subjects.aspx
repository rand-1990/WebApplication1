<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create_subjects.aspx.cs" Inherits="WebApplication1.create_subjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
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


         function deletes(d) {
             $.ajax({
                 url: '/create_subjects.aspx/delete_subject',
                 data: "{'id': '" + d.value +  "'}",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataType: "text",

                 success: function (data) {

                     console.log(data);
                     data = JSON.parse(data);
                     console.log(data);
                     if (data.d == "ok")
                         document.getElementById("r" + d.value).remove();
                 },
                 error: function (data, status, jqXHR) { alert(jqXHR); }
             });
     }
     </script>
            <asp:Label ID="msg" runat="server" ForeColor="#66FFCC" Font-Size="12pt"></asp:Label>

      <div class="form-row">
    <div class="col-md-3 mb-3">
      <label for="validationServer01">Material Title</label>
      <input type="text" class="form-control is-valid" id="subject_title" placeholder="subject title" runat="server" required>
      <div class="valid-feedback">
        detials or title
      </div>
    </div>
           <div class="col-md-3 mb-3">
      <label for="validationServer01">Material Attachment</label>
      <input type="file" class="form-control is-valid" id="subject_file" placeholder="subject file" runat="server">
      <div class="valid-feedback">
        Accepts all types of files
      </div>
    </div>
                 <div class="col-md-3 mb-3">
      <label for="validationServer01">Video Path</label>
      <input type="text" class="form-control is-valid" id="video_path" name="video_path" placeholder="video path" runat="server">
      <div class="valid-feedback">
        if has video enter video path
      </div>
    </div>
   
          </div>
       <center>   <asp:Button ID="join" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="add" class="form-control"  Height="62px" Width="224px" OnClick="add_Click" /></center>
      
    <hr />
        <div id="table_html" runat="server">

        </div>
  
    </form>

</asp:Content>
