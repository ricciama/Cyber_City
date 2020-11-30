<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOrganization.aspx.cs" Inherits="CyberCity.CreateOrganization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="pnlCreateOrg" runat="server"  BorderColor="#cccccc" BorderStyle="Solid" Height="750px">
        <br />
        <br />
        <asp:Table ID="tblCreateOrg" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/OrganizationAvatar.png"/>
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
                       <asp:RequiredFieldValidator ID="RFVtxtOrgName" runat="server" Text = "Required Field" ControlToValidate="txtOrgName" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgAddress" runat="server" placeholder="800 S Main Street Harrisonburg VA 22801"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVtxtOrgAddress" runat="server" Text = "Required Field" ControlToValidate="txtOrgAddress" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <%-- Primary contact name and Phone number--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgContactName" runat="server" placeholder="Primary Contact Name"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVOrgContactName" runat="server" Text = "Required Field" ControlToValidate="txtOrgContactName" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgPhone"  runat="server" width ="238" placeholder="Phone Number (### - ### - ####)"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVEOrgPhone" runat="server" Text = "Required Field" ControlToValidate="txtOrgPhone" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Email --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVOrgEmail" runat="server" Text = "Required Field" ControlToValidate="txtOrgEmail" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
     
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnCreateOrg" runat="server" Text="Create Organization" OnClick="btnCreateOrg_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnPopulate" runat="server" Text="Populate Fields" OnClick="btnPopulate_Click" CausesValidation="false"/>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="confirmationlbl" runat="server" Text="Organization Successfully Created!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID ="tblAddOrgRep" runat="server" HorizontalAlign="Right" CellPadding="50" Visible="false">
            <asp:TableRow>
                <asp:TableCell CssClass="cellPadding">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAddOrgRep" runat="server" Text="Add Organizational Reps &#x2192; " OnClick="btnAddOrgRep_Click" CausesValidation="false"/>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>

</asp:Content>
