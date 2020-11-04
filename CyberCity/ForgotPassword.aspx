<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CyberCity.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <link href="css/loginStyle.css" rel="stylesheet" />
    
    <div class="loginbox">
        <asp:Image ID="userLogoin" runat="server" ImageUrl="/Images/loginguy.PNG" CssClass="userPhoto" />
        <h2>Reset Password</h2>  
        
        <asp:Table ID="tblForgotPassword" runat="server" HorizontalAlign="Center">
            <%-- UserName input --%>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="lblUsername"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="txtUsername"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="Enter Username" ForeColor="Red" Font-Bold="true" ControlToValidate="txtUsername" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <%-- email --%>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="lblUsername"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="txtUsername"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <%-- retype email --%>
            <asp:TableRow>
                <asp:TableCell>
                     <asp:Label ID="lblEmail2" runat="server" Text="Email" CssClass="lblPassword"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail2" runat="server" placeholder="Re-Enter Email" CssClass="txtPassword"></asp:TextBox>
                    <asp:CompareValidator ID="compareEmails" runat="server" ControlToValidate="txtEmail2" ControlToCompare="txtEmail" Text="Emails do not match!" ForeColor="Red" Font-Bold="true"></asp:CompareValidator>
                </asp:TableCell>
            </asp:TableRow>
            <%-- forgot password button --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" Width="150px" CssClass="loginbtn" OnClick="btnResetPassword_Click"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="lblIncorrectEmail" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmailSuccess" runat="server" Text="" ForeColor="Green" Font-Bold="true" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
     </div>

</asp:Content>
