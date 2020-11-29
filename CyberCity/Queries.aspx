<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Queries.aspx.cs" Inherits="CyberCity.Queries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="css/GridView.css" rel="stylesheet" />

    <asp:Panel ID="Panel1" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Width="100%">
        <br />
        <br />
        <div style="text-align:center;">
            <h1>Coordinators!</h1>
            <div style="font-size:medium; font:bold">
                <p>Here, you can select a program and view their respective organizational representatives and volunteers.</p>
                <p>From there, you can view the schedule and roster for each organizational representative as well as the schedule for each volunteer.</p>
            </div>
        </div>

        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">
            <%-- Program, Org rep, and vounteer labels --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class =" form-group">
                        <asp:Label ID="lblProgram" runat="server" Text="Select Program" Font-Size="Medium" Font-Bold="True"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass =" cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblOrgReps" runat="server" Text="Select Organizational Rep" Font-Size="Medium" Font-Bold="True"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblVolunteers" runat="server" Text="Select Volunteers" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Drop down lists --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlOrgRep" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgRep_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlVolunteers" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVolunteers_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
            <%-- Gridviews --%>

            <%-- Gridview for Showing All events --%>
            <asp:Table ID="TblEvents" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                        <div class="form-group">
                            <asp:Label ID="lblAllEvents" runat="server" Text="All Events" Visible="false" Font-Bold="true"></asp:Label>
                        </div>
                        <asp:GridView ID="grdAllEvents"  runat="server" AutoGenerateColumns="true" AllowPaging="true" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"  Width="600px" CellPadding="6"></asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <%-- Gridview for showing org rep schedule --%>
            <asp:Table ID="TblOrgRepSchedule" runat="server" HorizontalAlign="center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top">
                        <div class="form-group">
                            &nbsp;
                            &nbsp;
                            &nbsp;
                            <asp:Label ID="lblOrgRepSched" runat="server" Text="Organizational Rep Schedule" Visible="false" Font-Bold="true"></asp:Label>
                        </div>
                            <asp:GridView ID="grdOrgRepSchedule" runat="server" Width="600px" AutoGenerateColumns="true" AllowPaging="true" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"></asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <%-- Gridview for showing Org rep Roster --%>
            <asp:Table ID="Table3" runat="server" HorizontalAlign="Center" >
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top">
                        <div class="form-group">
                            <asp:Label ID="lblOrgRepRoster" runat="server" Text="Organizational Rep Roster" Visible="false" Font-Bold="true"></asp:Label>
                        </div>
                            <asp:GridView ID="grdOrgRepRoster" runat="server" Width="600px" AutoGenerateColumns="true" AllowPaging="true" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"></asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <%-- Gridview for showing volunteer Schedule --%>
            <asp:Table ID="tblVolunteerSchedule" runat="server" HorizontalAlign="center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top">
                        <div class="form-group">
                            &nbsp;
                            &nbsp;
                            <asp:Label ID="lblVolunteerSched" runat="server" Text="VolunteerSchedule" Visible="false" Font-Bold="true"></asp:Label>
                        </div>
                        <asp:GridView ID="grdVolunteerSchedule" runat="server" Width="600px" AutoGenerateColumns="true" AllowPaging="true" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"></asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
    </asp:Panel>


</asp:Content>
