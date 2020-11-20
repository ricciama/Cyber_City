<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="CyberCity.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblEvent" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/loginguy.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Create an Event</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- Event Name and Time--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEventName" runat="server" placeholder="Event Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVEventName" runat="server" Text = "Required Field" ControlToValidate="txtEventName" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEventTime" runat="server" placeholder="Event Time" TextMode="Time"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVtxtEventTime" runat="server" Text = "Required Field" ControlToValidate="txtEventTime" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Location and Program --%>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">               
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEventLocation" runat="server" placeholder="Location Ex: Hartman Hall 1207" Width="250"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVtxtEventLocation" runat="server" Text = "Required Field" ControlToValidate="txtEventLocation" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select Program" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RFVddlProgram" runat="server" Text = "Required Field" ControlToValidate="ddlProgram" InitialValue="-1" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
     
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnCreateEvent" runat="server" Text="Create Event" OnClick="btnCreateEvent_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
          <br />
        <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="confirmationlbl" runat="server" Text="Event Successfully Created!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>

</asp:Content>
