<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordinatorAccount.aspx.cs" Inherits="CyberCity.CoordinatorAccount" %>
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
                    <h4>Coordinator Account Creation</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- First and Last name --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorFN" runat="server" placeholder="First Name"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVCoordinatorFN" runat="server" Text = "Required Field" ControlToValidate="txtCoordinatorFN" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorLN" runat="server" placeholder="Last Name"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVCoordinatorLN" runat="server" Text = "Required Field" ControlToValidate="txtCoordinatorLN" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Email and Faculty Position --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVEmail" runat="server" Text = "Required Field" ControlToValidate="txtCoordinatorEmail" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtFacultyPosition" runat="server" placeholder="Faculty Position"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVPosition" runat="server" Text = "Required Field" ControlToValidate="txtFacultyPosition" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Phone and Office --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorPhone" runat="server" width ="238" placeholder="Phone Number (### - ### - ####)"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVCoordinatorPhone" runat="server" Text = "Required Field" ControlToValidate="txtCoordinatorPhone" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCoordinatorOffice" runat="server" placeholder="Office Location"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVCoordinatorOffice" runat="server" Text = "Required Field" ControlToValidate="txtCoordinatorOffice" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <asp:Label ID="lblUserName" runat="server" Text="Username" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtUsernme" runat="server" placeholder="Username"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVUsername" runat="server" Text = "Required Field" ControlToValidate="txtUsernme" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
<%--                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVPassword" runat="server" Text = "Required Field" ControlToValidate="txtPassword" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>--%>
            </asp:TableRow>
            <%--<asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="Label1" runat="server" Text="Re-type Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CVpassword" runat="server" Text="Passwords Must Match" Font-Bold="true" ForeColor="Red" ControlToValidate="txtPassword2" ControlToCompare="txtPassword" SetFocusOnError="true"></asp:CompareValidator>
                       <asp:RequiredFieldValidator ID="RFVPassword2" runat="server" Text = "Required Field" ControlToValidate="txtPassword2" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>--%>
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="tblFeedback" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFeedback" runat="server" Text="Profile Created Successfully!" ForeColor="Green" Visible="false" Font-Bold="true"></asp:Label>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmailSuccess" runat="server" Text="Email Sent to User" ForeColor="Green" Visible="false" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>



</asp:Content>
