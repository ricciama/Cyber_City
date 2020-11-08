<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="CyberCity.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />

        <asp:Table ID="ProgramTable" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">
            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/loginguy.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Edit an Event</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">                 
                 <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:DropDownList ID="ddlPrograms" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPrograms_SelectedIndexChanged" >
                                <asp:ListItem Text="Select Program" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table ID="EventTable" runat="server"  HorizontalAlign="Center" CellPadding="50" CellSpacing="50">
             <asp:TableRow HorizontalAlign="Center">                 
                 <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:DropDownList ID="ddlEvents" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged" >
                                <asp:ListItem Text="Select Event" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table ID="tblEventInfo" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            
            <%-- Event Name and Time--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEventName" runat="server" placeholder="Event Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
                  <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtDate" runat="server" placeholder="Event Date" ></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEventTime" runat="server" placeholder="Event Time" TextMode="Time"></asp:TextBox>
                    </div>
                </asp:TableCell>
                
            </asp:TableRow>
            <%-- Location and Program --%>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">               
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEventLocation" runat="server" placeholder="Location - Ex: Hartman Hall 1207"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control">

                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
     
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnEditEvent" runat="server" Text="Commit Edits" onclick="btnEditEvent_Click1" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
         <br />
         <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Event Updated!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
