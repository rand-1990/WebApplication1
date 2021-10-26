<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteClass.aspx.cs" Inherits="WebApplication1.DeleteClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <form runat="server">
    <asp:Label ID="msg" runat="server" ForeColor="#FF3300" Font-Size="12"></asp:Label>
  <div class="form-row">
    <div class="col-md-4 mb-3">
      <label for="validationServer01" id="class_label" runat="server">Class Code</label>
      <input type="password" class="form-control is-valid" id="password" placeholder="" runat="server" required>
      <div class="valid-feedback">
enter password to delete      </div>
    </div>
      </div>
      <asp:Button ID="delete" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="delete" class="form-control"  Height="62px" Width="224px" OnClick="delete_Click" />
      						<asp:Label id="lblError" EnableViewState="False" runat="server" ForeColor="red"></asp:Label><BR>
  
      </form>

</asp:Content>
