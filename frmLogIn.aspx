<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmLogIn.aspx.vb" Inherits="frmLogIn" title="IT Asset Inventory-LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
    <div class="row loginForm">
        <form>
          <div class="col-sm-5">
            <label for="uname"><b>Username</b></label>
            <asp:TextBox Type="Text" ID="txtUserName" placeholder="Enter User Name" runat="server" required></asp:TextBox>
            <label for="psw"><b>Password</b></label>
            <asp:TextBox Type="Text" TextMode="password" ID="txtPassword" placeholder="Enter password" runat="server" required></asp:TextBox>
            <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnLogIn" runat="server" Text="LogIn"/>
          </div>
        </form>
    </div>
</div>
</asp:Content>

