<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ChiTietEdit.aspx.cs" Inherits="website_tin_tuc.ChiTietEdit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>S&#7917;a b&agrave;i vi&#7871;t</h1>
    <div id="ndcontent" class="editor-form">
        <div class="form-row">
            <label>Danh m&#7909;c</label>
            <asp:DropDownList ID="drBanTin" runat="server"></asp:DropDownList>
        </div>
        <div class="form-row">
            <label>Ti&ecirc;u &#273;&#7873;</label>
            <asp:TextBox ID="txtTieuDe" runat="server"></asp:TextBox>
        </div>
        <div class="form-row">
            <label>N&#7897;i dung</label>
            <div class="editor-shell">
                <CKEditor:CKEditorControl ID="txtNoiDung" runat="server" Width="100%" Height="420px"></CKEditor:CKEditorControl>
            </div>
        </div>
        <asp:Label ID="lblThongBao" runat="server" CssClass="form-message"></asp:Label>
        <div class="form-actions">
            <asp:Button ID="btnUpdate" runat="server" Text="L&#432;u thay &#273;&#7893;i" OnClick="btnUpdate_Click" CssClass="primary-button" />
            <a class="admin-link" href="AdminPosts.aspx">Quay l&#7841;i qu&#7843;n l&yacute;</a>
        </div>
    </div>
</asp:Content>
