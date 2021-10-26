<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="send_answer.aspx.cs" Inherits="WebApplication1.send_answer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <form runat="server">
            <asp:Label ID="msg" runat="server" ForeColor="#3366FF" Font-Size="12pt"></asp:Label>
      <div id="assiement_info" runat="server">
          <p id="assiement_title" runat="server"></p>
          <p id="time_end" runat="server"></p>

          <a href="#" id="assiement_file" runat="server"></a>
       </div>
      <div class="form-row">
    <div class="col-md-3 mb-3">
      <label for="validationServer01">assiement caption</label>
      <input type="text" class="form-control is-valid" id="assiement_caption" placeholder="assiement caption" runat="server" required>
      <div class="valid-feedback">
        detials or title
      </div>
    </div>
           <div class="col-md-3 mb-3">
      <label for="validationServer01">assiement file</label>
      <input type="file" class="form-control is-valid" id="assiement_file_upload" placeholder="assiement file" runat="server">
      <div class="valid-feedback">
        pdf or word or image
      </div>
    </div>
               
    </div>
       <center>   <asp:Button ID="add" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="send" class="form-control"  Height="62px" Width="224px" OnClick="add_Click" /></center>
      
    <hr />
        <div id="table_html" runat="server">

        </div>
  
    </form>
</asp:Content>
