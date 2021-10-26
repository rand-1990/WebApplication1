<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="update_subject.aspx.cs" Inherits="WebApplication1.update_subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
            <asp:Label ID="msg" runat="server" ForeColor="#66FFCC" Font-Size="12pt"></asp:Label>

      <div class="form-row">
    <div class="col-md-3 mb-3">
      <label for="validationServer01">subject title</label>
      <input type="text" class="form-control is-valid" id="subject_title" placeholder="subject title"  runat="server" required>
      <div class="valid-feedback">
        detials or title
      </div>
    </div>
           <div class="col-md-3 mb-3">
      <label for="validationServer01">subject file</label>
      <input type="file" class="form-control is-valid" id="subject_file" placeholder="subject file" runat="server">
      <div class="valid-feedback">
        pdf or word or image
      </div>
    </div>
                   <div class="col-md-3 mb-3">
      <label for="validationServer01">Video Path</label>
      <input type="text" class="form-control is-valid" id="video_path" name="video_path" placeholder="video path" runat="server">
      <div class="valid-feedback">
        if has video enter video path
      </div>
          </div>
       <center>   <asp:Button ID="update" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="update" class="form-control"  Height="62px" Width="224px" OnClick="update_Click" /></center>
      
    <hr />
        <div id="table_html" runat="server">

        </div>
  <input type="hidden" id="id_subject" runat="server" />
    </form>

</asp:Content>
