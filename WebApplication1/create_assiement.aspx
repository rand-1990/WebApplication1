<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create_assiement.aspx.cs" Inherits="WebApplication1.create_assiement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
            <asp:Label ID="msg" runat="server" ForeColor="#66FFCC" Font-Size="12pt"></asp:Label>

      <div class="form-row">
    <div class="col-md-3 mb-3">
      <label for="validationServer01">Assignment Caption</label>
      <input type="text" class="form-control is-valid" id="assiement_caption" placeholder="assiement caption" runat="server" required>
      <div class="valid-feedback">
        detials or title
      </div>
    </div>
           <div class="col-md-3 mb-3">
      <label for="validationServer01">Assignment Attachment</label>
      <input type="file" class="form-control is-valid" id="assiement_file" placeholder="assiement file" runat="server">
      <div class="valid-feedback">
        pdf or word or image
      </div>
    </div>
                 <div class="col-md-3 mb-3">
      <label for="validationServer01">Assignment Start</label>
      <input type="datetime-local" class="form-control is-valid" id="assiement_start" placeholder="assiement start" runat="server">
      <div class="valid-feedback">
        start exam datetime
      </div>
    </div>
                     <div class="col-md-3 mb-3">
      <label for="validationServer01">assignment End</label>
      <input type="datetime-local" class="form-control is-valid" id="assiement_end" placeholder="assiement end" runat="server">
      <div class="valid-feedback">
        end exam datetime
      </div>
    </div>
          </div>
       <center>   <asp:Button ID="join" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="add" class="form-control"  Height="62px" Width="224px" OnClick="add_Click" /></center>
      
    <hr />
        <div id="table_html" runat="server">

        </div>
  
    </form>

</asp:Content>
