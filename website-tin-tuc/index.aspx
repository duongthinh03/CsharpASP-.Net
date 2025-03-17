<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="website_tin_tuc.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="box-title">Tin mới nhất</h1>
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
