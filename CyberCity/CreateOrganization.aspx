<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOrganization.aspx.cs" Inherits="CyberCity.CreateOrganization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="pnlCreateOrg" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblCreateOrg" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/loginguy.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Create an Organization</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- Organization Name and Address--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgName" runat="server" placeholder="Organization Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgAddress" runat="server" placeholder="800 S Main Street Harrisonburg VA 22801"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <%-- Primary contact name and Phone number--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgContactName" runat="server" placeholder="Primary Contact Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgPhone" runat="server" placeholder="Phone Number" TextMode="Number"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Email --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
     
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnCreateOrg" runat="server" Text="Create Program" OnClick="btnCreateOrg_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

</asp:Content>
