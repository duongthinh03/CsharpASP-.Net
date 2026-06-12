<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AdminPosts.aspx.cs" Inherits="website_tin_tuc.AdminPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Qu&#7843;n l&yacute; b&agrave;i vi&#7871;t</h1>
    <div id="ndcontent">
        <div class="admin-toolbar">
            <a class="admin-button" href="ChiTietAdd.aspx">Th&ecirc;m b&agrave;i vi&#7871;t</a>
            <a class="admin-button secondary" href="BanTinManage.aspx">Qu&#7843;n l&yacute; danh m&#7909;c</a>
        </div>
        <div class="search-panel admin-search">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="search-input" placeholder="Tìm theo tiêu đề, nội dung hoặc danh mục..."></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" CssClass="primary-button" Text="Tìm kiếm" OnClick="btnSearch_Click" />
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
                        <span>Ng&agrave;y &#273;&#259;ng: <%# Eval("ngayDang", "{0:dd/MM/yyyy HH:mm}") %> | L&#432;&#7907;t xem: <%# Eval("lanXem") %> | Danh m&#7909;c: <%# Eval("TenBanTin") %></span>
                    </div>
                    <div class="admin-row-actions">
                        <a class="row-button view" href="chitiet.aspx?idbantin=<%# Eval("IDBanTin") %>&id=<%# Eval("ID") %>">Xem</a>
                        <a class="row-button edit" href="ChiTietEdit.aspx?id=<%# Eval("ID") %>">S&#7917;a</a>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="row-button delete" CommandName="DeletePost" CommandArgument='<%# Eval("ID") %>' OnClientClick="return showDeleteConfirm(this, 'Xóa bài viết này?');">X&oacute;a</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblEmpty" runat="server" CssClass="empty-state" Text="Ch&#432;a c&oacute; b&agrave;i vi&#7871;t n&agrave;o." Visible='<%# rpBaiViet.Items.Count == 0 %>'></asp:Label>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Literal ID="litPager" runat="server"></asp:Literal>
    </div>
</asp:Content>
