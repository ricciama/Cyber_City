﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrgRepGroup.aspx.cs" Inherits="CyberCity.OrgRepGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="css/GridView.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <br />
    <br />

    <asp:Panel ID="Panel1" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Width="100%">
        <div style="text-align:center;">
            <h1>Organizationl Reps!</h1>
            <p>Here, you can see the list of students that have registered with CyberDay under your respective code. If you wish to remove a student, you can do so here</p>
        </div>
        <br />
        <br />

        <asp:Table ID="Table1" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="center" Visible="false">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:GridView ID="grdOrgStudent" runat="server" 
                        AutoGenerateColumns="true" 
                        AutoGenerateDeleteButton="true" 
                        AllowPaging="true" 
                        CssClass="Grid" 
                        AlternatingRowStyle-CssClass="alt" 
                        PagerStyle-CssClass="pgr" Width="100%" Font-Size="Large" OnRowDeleting="grdOrgStudent_RowDeleting">
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table ID="tblNotRegistered" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="center" Visible="false">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNotRegistered" runat="server" Text="No Students Registered for Organizational Representative" Font-Bold="true" Font-Size="XX-Large"></asp:Label>                                          
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
         <asp:Table ID="tblCancel" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnUpdate" runat="server" Text="Cancel Program Registration" OnClick="btnUpdate_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="cellConfirmation" HorizontalAlign="center" Visible="false">
                    <asp:Label ID="lblConfirmation" runat="server" Text="Registration Cancelled Successfully!" Font-Bold="true" ForeColor="Green" autopostback ="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </asp:Panel>


</asp:Content>
