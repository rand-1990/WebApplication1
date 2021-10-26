<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InviteByCSV.aspx.cs" Inherits="WebApplication1.InviteByCSV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <form runat="server">
            <asp:Label ID="msg" runat="server" ForeColor="#66FFCC" Font-Size="12pt"></asp:Label>

      <div class="form-row">

           <div class="col-md-3 mb-3">
      <label for="validationServer01">CSV file contain email</label>
      <input type="file" class="form-control is-valid" id="csv_file" placeholder="assiement file" runat="server">
      <div class="valid-feedback">
        csv file
      </div>
    </div>

          </div>
       <center>   <asp:Button ID="send" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="send email" class="form-control"  Height="62px" Width="224px" OnClick="send_Click" /></center>
      
   
   
  
    </form>
</asp:Content>
