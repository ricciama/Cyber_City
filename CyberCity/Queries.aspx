<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Queries.aspx.cs" Inherits="CyberCity.Queries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <asp:Panel ID="Panel1" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Width="100%">
        <br />
        <br />
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
            <%-- Gridviews --%>

            <%-- Gridview for Showing All events --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblAllEvents" runat="server" Text="All Events" Visible="false" Font-Bold="true"></asp:Label>
                        <asp:GridView ID="grdAllEvents" runat="server" AlternatingRowStyle-BackColor="#450084" BorderColor="Black" AlternatingRowStyle-ForeColor="White" Font-Size="Medium"></asp:GridView>
                    </div>
                </asp:TableCell>
            
            <%-- Gridview for showing org rep schedule --%>
            
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblOrgRepSched" runat="server" Text="Organizational Rep Schedule" Visible="false" Font-Bold="true"></asp:Label>
                        <asp:GridView ID="grdOrgRepSchedule" runat="server" AlternatingRowStyle-BackColor="#450084" BorderColor="Black" AlternatingRowStyle-ForeColor="White" Font-Size="Medium"></asp:GridView>
                    </div>
                </asp:TableCell>
            
            <%-- Gridview for showing volunteer Schedule --%>
            
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblVolunteerSched" runat="server" Text="VolunteerSchedule" Visible="false" Font-Bold="true"></asp:Label>
                        <asp:GridView ID="grdVolunteerSchedule" runat="server" AlternatingRowStyle-BackColor="#450084" BorderColor="Black" AlternatingRowStyle-ForeColor="White" Font-Size="Medium" ></asp:GridView>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
           
                <%-- Gridview for showing Org rep Roster --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="3">
                    <div class="form-group">
                        <asp:Label ID="lblOrgRepRoster" runat="server" Text="Organizational Rep Roster" Visible="false" Font-Bold="true"></asp:Label>
                        <asp:GridView ID="grdOrgRepRoster" runat="server" AlternatingRowStyle-BackColor="#450084" BorderColor="Black" AlternatingRowStyle-ForeColor="White" Font-Size="Medium"></asp:GridView>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            



        </asp:Table>

    </asp:Panel>


</asp:Content>
