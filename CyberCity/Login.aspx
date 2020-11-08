<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CyberCity.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/loginStyle.css" rel="stylesheet" />
    
    <div class ="loginbox">
        <asp:Image ID="userLogoin" runat="server" ImageUrl="/Images/loginguy.PNG" CssClass="userPhoto" />
        <h2>Login Here</h2>  
        
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="lblUsername"></asp:Label>
                </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter Username" CssClass="txtUsername"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                     <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="lblPassword"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="***************" CssClass="txtPassword" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="loginbtn" runat="server" Text="Login" CssClass="loginbtn" OnClick="loginbtn_Click"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="lblincorrectLogin" runat="server" Text="" ForeColor="Red" Font-Size="Medium" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password?" Width="150px" CssClass="loginbtn" OnClick="btnForgotPassword_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
     </div>




</asp:Content>
