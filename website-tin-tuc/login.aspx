<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="website_tin_tuc.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Đăng nhập hệ thống </h1>
            <div id="ndcontent">
                <h4>Tên đăng nhập</h4>
                <asp:TextBox ID="txtUserName" Width="300" Height="20" runat="server"></asp:TextBox>
                <h4>Mật khẩu</h4>
                <asp:TextBox ID="txtPassWord" Width="300" Height="20" TextMode="PassWord" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" Height="37px" OnClick="btnLogin_Click" Width="126px" />
                <h4>
                    <asp:Label ID="lblThongBao" runat="server"></asp:Label>
                </h4>

            </div>
</asp:Content>
