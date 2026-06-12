<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="website_tin_tuc.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Đổi mật khẩu</h1>
    <div id="ndcontent">
        <h4>Mật khẩu hiện tại</h4>
        <asp:TextBox ID="txtOldPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <h4>Mật khẩu mới</h4>
        <asp:TextBox ID="txtNewPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <h4>Nhập lại mật khẩu mới</h4>
        <asp:TextBox ID="txtConfirmPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnChangePassword" runat="server" Text="Đổi mật khẩu" Width="140px" Height="34px" OnClick="btnChangePassword_Click" />
        <br /><br />
        <asp:Label ID="lblThongBao" runat="server" CssClass="form-message"></asp:Label>
    </div>
</asp:Content>
