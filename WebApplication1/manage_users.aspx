<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="manage_users.aspx.cs" Inherits="WebApplication1.manage_users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <label runat="server" id="msg"></label>
     <form id="form1" runat="server">  
         <div id="up" runat="server">
             <asp:TextBox ID="id" Visible="false" runat="server"></asp:TextBox><br/>
            <label>name</label> <asp:TextBox ID="name" runat="server"></asp:TextBox><br/>
             <label>password</label><asp:TextBox ID="password" runat="server"></asp:TextBox><br/>
             <asp:Button runat="server" ID="update" value="update" OnClick="update_Click" Text="update"/><br/>
             <asp:Button runat="server" ID="Cancle" value="cancle" OnClick="Cancle_Click" Text="cancle"/>

         </div>
            <div>  
                <asp:GridView Width="100%" ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_OnRowCommand" AutoGenerateColumns="false" DataKeyNames="id"    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">  
                    <Columns>  
                        <asp:BoundField DataField="id" HeaderText="id" />  
                        <asp:BoundField DataField="username" HeaderText="username" />  
                        <asp:BoundField DataField="email" HeaderText="email" />  

                        <asp:BoundField DataField="verify" HeaderText="verify" />  
                        <asp:BoundField DataField="type" HeaderText="type" />  
                        <asp:CommandField ShowEditButton="true" />  
                         <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="SendCode" Text="send code" runat="server" CommandArgument='<%# Eval("email") %>' CausesValidation="false" CommandName="SendMail" />
                    <asp:Button ID="DisableAccount" Text="disable account" runat="server" CommandArgument='<%# Eval("email") %>' CausesValidation="false" CommandName="DisableAccount" />
                     <asp:Button ID="Button1" Text="active account" runat="server" CommandArgument='<%# Eval("email") %>' CausesValidation="false" CommandName="ActiveAccount" />

                </ItemTemplate>
            </asp:TemplateField>

                    </Columns>  
                </asp:GridView>  
            </div>  
            <div>  
                <asp:Label ID="lblresult" runat="server"></asp:Label>  
            </div>  
        </form>  
</asp:Content>
