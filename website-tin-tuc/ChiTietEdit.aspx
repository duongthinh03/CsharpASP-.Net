<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ChiTietEdit.aspx.cs" Inherits="website_tin_tuc.ChiTietEdit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Sửa bài viết</h1>
    <div id="ndcontent">
        <h4>Chọn danh mục</h4>
        <asp:DropDownList ID="drBanTin" runat="server" Width="400px"></asp:DropDownList>
        <h4>Tiêu đề</h4>
        <asp:TextBox ID="txtTieuDe" runat="server" Width="557px"></asp:TextBox>
        <h4>Nội dung</h4>
        <CKEditor:CKEditorControl ID="txtNoiDung" runat="server"></CKEditor:CKEditorControl>
        <br /><br />
        <asp:Label ID="lblThongBao" runat="server" CssClass="form-message"></asp:Label>
        <br /><br />
        <asp:Button ID="btnUpdate" runat="server" Text="Lưu thay đổi" Width="150" Height="30" OnClick="btnUpdate_Click" />
        <a class="admin-link" href="AdminPosts.aspx">Quay lại quản lý</a>
    </div>
</asp:Content>
