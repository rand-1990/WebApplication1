<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="class_join.aspx.cs" Inherits="WebApplication1.class_join" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <asp:Label ID="msg" runat="server" ForeColor="#FF3300" Font-Size="12"></asp:Label>
  <div class="form-row">
    <div class="col-md-4 mb-3">
      <label for="validationServer01">Class Code</label>
      <input type="text" class="form-control is-valid" id="code" placeholder="Class code" runat="server" required>
      <div class="valid-feedback">
        take class code from lecture
      </div>
    </div>
      </div>
      <asp:Button ID="join" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="Join" class="form-control" OnClick="join_Click" Height="62px" Width="224px" />
        </form>

    </div>
</asp:content>
