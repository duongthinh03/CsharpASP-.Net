<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="chitiet.aspx.cs" Inherits="website_tin_tuc.chitiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Repeater ID="rpBanTin" runat="server">
            <ItemTemplate>
                <h1><%# Eval("tenBanTin") %></h1>
            </ItemTemplate>
        </asp:Repeater>
         <div id="ndcontent">
             <asp:Repeater ID="rpChiTiet" runat="server">
                 <ItemTemplate>
                     <article class="detail-post">
                         <h2 class="detail-title"><%# Eval("TieuDe") %></h2>
                         <div class="detail-meta">
                             <span>Cập nhật: <%# Eval("ngayDang", "{0:dd/MM/yyyy HH:mm}") %></span>
                             <span>Lượt xem: <%# Eval("lanXem") %></span>
                         </div>
                         <div class="detail-body">
                             <%# Eval("noiDung") %>
                         </div>
                     </article>
                 </ItemTemplate>
                 <FooterTemplate>
                     <asp:Label ID="lblEmpty" runat="server" CssClass="empty-state" Text="Không tìm thấy bài viết." Visible='<%# rpChiTiet.Items.Count == 0 %>'></asp:Label>
                 </FooterTemplate>
             </asp:Repeater>
             <h2 class="related-title">Bài viết liên quan</h2>
                 <ul>
                     <asp:Repeater ID="rpRanDom" runat="server">
                         <ItemTemplate>
                             <li>
                                 <a href="chitiet.aspx?idbantin=<%# Eval("IDBanTin") %>&id=<%# Eval("ID") %>">
                                     <span class="post-title"><%# Eval("TieuDe") %></span>
                                     <span class="post-meta">Ngày đăng: <%# Eval("ngayDang", "{0:dd/MM/yyyy}") %> | Lượt xem: <%# Eval("lanXem") %></span>
                                 </a>
                             </li>
                         </ItemTemplate>
                         <FooterTemplate>
                             <asp:Label ID="lblEmpty" runat="server" CssClass="empty-state" Text="Chưa có bài viết liên quan." Visible='<%# rpRanDom.Items.Count == 0 %>'></asp:Label>
                         </FooterTemplate>
                     </asp:Repeater>
                 </ul>
         </div>
</asp:Content>
