<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="bantin.aspx.cs" Inherits="website_tin_tuc.bantin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rpBanTin" runat="server">
        <ItemTemplate>
            <h1 class="box-title"><%# Eval("tenBanTin") %></h1>
        </ItemTemplate>
    </asp:Repeater>
    <div id="ndcontent">
        <div class="search-panel">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="search-input" placeholder="Tìm trong danh mục này..."></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" CssClass="primary-button" Text="Tìm kiếm" OnClick="btnSearch_Click" />
        </div>
        <ul>
            <asp:Repeater ID="rpChiTiet" runat="server">
                <ItemTemplate>
                    <li>
                        <a href="chitiet.aspx?idbantin=<%# Eval("IDBanTin") %>&id=<%# Eval("ID") %>">
                            <span class="post-title"><%# Eval("TieuDe") %></span>
                            <span class="post-meta">Ngày đăng: <%# Eval("ngayDang", "{0:dd/MM/yyyy}") %> | Lượt xem: <%# Eval("lanXem") %></span>
                            <span class="post-excerpt"><%# GetExcerpt(Eval("noiDung")) %></span>
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblEmpty" runat="server" CssClass="empty-state" Text="Chưa có bài viết trong bản tin này." Visible='<%# rpChiTiet.Items.Count == 0 %>'></asp:Label>
                </FooterTemplate>
            </asp:Repeater>
        </ul>
        <asp:Literal ID="litPager" runat="server"></asp:Literal>

    </div>
</asp:Content>
