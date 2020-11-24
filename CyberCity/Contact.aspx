<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CyberCity.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="ContactStyle.css" rel="stylesheet" />
    <a href="Contact.aspx">Contact.aspx</a>

    <div class ="Box">
        <h1>Get in Touch</h1> 
        <p> Want to get in touch? We'd love to hear from you. <br /> Here's how you can reach us...</p>

        <asp:Table runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Image ID="Image1" runat="server" ImageUrl="/Images/ShawnLough.PNG" CssClass="photo1" Height="140px" Width="140px"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:LinkButton ID="lough1" runat="server" OnClick="lough1_Click" ForeColor="White" Font-Size="18px">Shawn Lough</asp:LinkButton>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="codirector" runat="server" Text="Co-Director" CssClass="label" Font-Italic="true" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:LinkButton ID="email" runat="server" OnClick="email_Click" ForeColor="White">loughsr@jmu.edu</asp:LinkButton>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="loughPhone" runat="server" Text="540-568-5660" CssClass="phone"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                     <asp:Image ID="profile2" runat="server" ImageUrl="/Images/TomDillon.png" CssClass="photo1" Height="140px" Width="140px" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:LinkButton ID="dillonLink" runat="server" OnClick="dillonLink_Click" ForeColor="White" Font-Size="18px">Tom Dillon</asp:LinkButton>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="Label1" runat="server" Text="Co-Director" CssClass="label" Font-Italic="true" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" ForeColor="White">dillontw@jmu.edu</asp:LinkButton>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="Label2" runat="server" Text="540-568-3015" CssClass="phone"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div> 
</asp:Content>
