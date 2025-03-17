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
        <ul>
            <asp:Repeater ID="rpChiTiet" runat="server">
                <ItemTemplate>
                    <li>
                        <a href="chitiet.aspx?idbantin=<%# Eval("IDBanTin") %>>&id=<%# Eval("ID") %>"><%# Eval("TieuDe") %></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

    </div>
</asp:Content>
