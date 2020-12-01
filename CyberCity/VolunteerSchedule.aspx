<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VolunteerSchedule.aspx.cs" Inherits="CyberCity.VolunteerSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="ScheduleHeader" runat="server" CellPadding="75" CellSpacing="75" HorizontalAlign ="Center">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="lblVolunteerSchedule" runat="server" Text="" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign ="Center">
                    <asp:Label ID="lblScheduleHelper" runat ="server" Text ="This is your Volunteer Schedule for CyberDay, if you have any questions feel free to contact us!" Font-Size="Large"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                        <asp:GridView 
                            runat="server" 
                            ID="volunteerSchedule" 
                            AlternatingRowStyle-BackColor="MediumPurple" 
                            BorderColor="Black" Font-Size="Large" HeaderStyle-CssClass="text-center"
                            Width="600px" RowStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                            >         
                        </asp:GridView>                      
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="tblNotRegistered" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="center" Visible="false">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNotRegistered" runat="server" Text="Volunteer is currently not registered for any programs!" Font-Bold="true" Font-Size="XX-Large"></asp:Label>                                          
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
