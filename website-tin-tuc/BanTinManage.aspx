<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BanTinManage.aspx.cs" Inherits="website_tin_tuc.BanTinManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Quản lý danh mục</h1>
    <div id="ndcontent">
        <div class="admin-actions">
            <a class="admin-button secondary" href="AdminPosts.aspx">Quản lý bài viết</a>
        </div>
        <asp:Label ID="lblThongBao" runat="server" CssClass="form-message"></asp:Label>
        <div class="category-add">
            <asp:TextBox ID="txtTenBanTin" runat="server" Width="320px" placeholder="Tên danh mục mới"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="Thêm danh mục" Width="140px" Height="34px" OnClick="btnAdd_Click" />
        </div>
        <asp:Repeater ID="rpBanTinManage" runat="server" OnItemCommand="rpBanTinManage_ItemCommand">
            <HeaderTemplate>
                <div class="admin-list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="admin-row">
                    <div class="admin-row-main">
                        <asp:TextBox ID="txtEditTenBanTin" runat="server" Text='<%# Eval("tenBanTin") %>' Width="320px"></asp:TextBox>
                    </div>
                    <div class="admin-row-actions">
                        <asp:LinkButton ID="btnUpdate" runat="server" CommandName="UpdateCategory" CommandArgument='<%# Eval("IDBanTin") %>'>Lưu</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteCategory" CommandArgument='<%# Eval("IDBanTin") %>' OnClientClick="return confirm('Bạn chắc chắn muốn xóa danh mục này?');">Xóa</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblEmpty" runat="server" CssClass="empty-state" Text="Chưa có danh mục nào." Visible='<%# rpBanTinManage.Items.Count == 0 %>'></asp:Label>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
