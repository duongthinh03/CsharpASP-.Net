<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BanTinManage.aspx.cs" Inherits="website_tin_tuc.BanTinManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Qu&#7843;n l&yacute; danh m&#7909;c</h1>
    <div id="ndcontent">
        <div class="admin-toolbar">
            <a class="admin-button secondary" href="AdminPosts.aspx">Qu&#7843;n l&yacute; b&agrave;i vi&#7871;t</a>
        </div>
        <asp:Label ID="lblThongBao" runat="server" CssClass="form-message"></asp:Label>
        <div class="category-add">
            <asp:TextBox ID="txtTenBanTin" runat="server" placeholder="T&ecirc;n danh m&#7909;c m&#7899;i"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="Th&ecirc;m danh m&#7909;c" OnClick="btnAdd_Click" CssClass="primary-button" />
        </div>
        <asp:Repeater ID="rpBanTinManage" runat="server" OnItemCommand="rpBanTinManage_ItemCommand">
            <HeaderTemplate>
                <div class="admin-list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="admin-row">
                    <div class="admin-row-main">
                        <asp:TextBox ID="txtEditTenBanTin" runat="server" Text='<%# Eval("tenBanTin") %>'></asp:TextBox>
                    </div>
                    <div class="admin-row-actions">
                        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="row-button edit" CommandName="UpdateCategory" CommandArgument='<%# Eval("IDBanTin") %>'>L&#432;u</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="row-button delete" CommandName="DeleteCategory" CommandArgument='<%# Eval("IDBanTin") %>' OnClientClick="return showDeleteConfirm(this, 'Xóa danh mục này?');">X&oacute;a</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblEmpty" runat="server" CssClass="empty-state" Text="Ch&#432;a c&oacute; danh m&#7909;c n&agrave;o." Visible='<%# rpBanTinManage.Items.Count == 0 %>'></asp:Label>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
