<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="LV_OneDay" runat="server">
        <LayoutTemplate>
            <table id="Grid" runat="server" class="table table-striped table-bordered table-hover" cellpadding="0" cellspacing="0" style="empty-cells: show;">
                <tr class="head">
                    <th style="width: 10%; text-align: center;">id
                    </th>
                    <th style="width: 8%; text-align: center;">名稱
                    </th>
                    <th style="width: 5%; text-align: center;">庫存
                    </th>
                </tr>
                <tr id="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td style="text-align: center;">
                    <%# Eval("id")%>
                </td>
                <td style="text-align: left;">
                    <%# Eval("name")%>
                </td>
                <td style="text-align: left;">
                    <%# Eval("stock")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
