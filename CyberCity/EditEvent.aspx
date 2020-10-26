﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="CyberCity.EditEvent" %>
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
                    <h4>Edit an Event</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- Event Name and Time--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEventName" runat="server" placeholder="Event Name"></asp:TextBox>
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
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnEditEvent" runat="server" Text="Create Event" OnClick="btnEditEvent_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>