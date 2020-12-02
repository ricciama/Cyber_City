<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordinatorProfile.aspx.cs" Inherits="CyberCity.CoordinatorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="pnlCoordAcct" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblCoordAcct" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/coordinatorAvatar.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Edit Coordinator Profile</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- First and Last name --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorFN" runat="server" placeholder="First Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFN" runat="server" Text="Required Field" ControlToValidate="txtCoordinatorFN" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorLN" runat="server" placeholder="Last Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFLN" runat="server" Text="Required Field" ControlToValidate="txtCoordinatorLN" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Email and Faculty Position --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVEmail" runat="server" Text="Required Field" ControlToValidate="txtCoordinatorEmail" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtFacultyPosition" runat="server" placeholder="Faculty Position"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFacultyPosition" runat="server" Text="Required Field" ControlToValidate="txtFacultyPosition" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Phone and Office --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorPhone" runat="server" placeholder="Contact No" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPhone" runat="server" Text="Required Field" ControlToValidate="txtCoordinatorPhone" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorOffice" runat="server" placeholder="Office Location"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVOffice" runat="server" Text="Required Field" ControlToValidate="txtCoordinatorOffice" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>

            </asp:TableRow>
            <%-- Login credentials Logo --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <span class="badge badge-pill badge-info">Login Credentials</span>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Username and Password --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="lblUserName" runat="server" Text="Username" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtUsernme" runat="server" placeholder="Username" ReadOnly="true"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPassword" runat="server" ControlToValidate="txtPassword" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="Label1" runat="server" Text="Re-type Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPassword2" runat="server" ControlToValidate="txtPassword2" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" Text="Passwords do not match!" ForeColor="Red" Font-Bold="true"></asp:CompareValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnEditCoordinator" runat="server" Text="Update Profile" OnClick="btnEditCoordinator_Click"/>
                    </div>
                </asp:TableCell>
                <asp:TableCell CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Button ID="btnUpdatePassword" runat="server" CssClass="btn btn-primary btn-block btn-lg" Text="Update Password" OnClick="btnUpdatePassword_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="tblFeedback" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFeedback" runat="server" Text="Profile Updated Successfully!" ForeColor="Green" Visible="false" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPasswordSuccess" runat="server" Text="Password Updated Successfully!" ForeColor="Green" Visible="false" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
