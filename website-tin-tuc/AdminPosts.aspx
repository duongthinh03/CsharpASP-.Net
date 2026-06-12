<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AdminPosts.aspx.cs" Inherits="website_tin_tuc.AdminPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Quản lý bài viết</h1>
    <div id="ndcontent">
        <div class="admin-actions">
            <a class="admin-button" href="ChiTietAdd.aspx">Thêm bài viết</a>
            <a class="admin-button secondary" href="BanTinManage.aspx">Quản lý danh mục</a>
        </div>
        <asp:Label ID="lblThongBao" runat="server" CssClass="form-message"></asp:Label>
        <asp:Repeater ID="rpBaiViet" runat="server" OnItemCommand="rpBaiViet_ItemCommand">
            <HeaderTemplate>
                <div class="admin-list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="admin-row">
                    <div class="admin-row-main">
                        <strong><%# Eval("TieuDe") %></strong>
                        <span>Ngày đăng: <%# Eval("ngayDang", "{0:dd/MM/yyyy HH:mm}") %> | Lượt xem: <%# Eval("lanXem") %> | Danh mục: <%# Eval("TenBanTin") %></span>
                    </div>
                    <div class="admin-row-actions">
                        <a href="ChiTietEdit.aspx?id=<%# Eval("ID") %>">Sửa</a>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeletePost" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Bạn chắc chắn muốn xóa bài viết này?');">Xóa</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblEmpty" runat="server" CssClass="empty-state" Text="Chưa có bài viết nào." Visible='<%# rpBaiViet.Items.Count == 0 %>'></asp:Label>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
