﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrgRepSchedule.aspx.cs" Inherits="CyberCity.OrgRepSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="css/GridView.css" rel="stylesheet" />
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                        <asp:GridView 
                            runat="server" 
                            ID="orgRepSchedule" 
                            BorderColor="Black" Font-Size="Large"
                            Width="600px" 
                            AutoGenerateColumns="true" 
                            AllowPaging="true" CssClass="Grid" 
                            AlternatingRowStyle-CssClass="alt" 
                            PagerStyle-CssClass="pgr" 
                            CellPadding="6">         
                        </asp:GridView>                      
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="tblNotRegistered" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="center" Visible="false">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNotRegistered" runat="server" Text="Organizational Representative is not registered for any programs!" Font-Bold="true" Font-Size="XX-Large"></asp:Label>                                          
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
