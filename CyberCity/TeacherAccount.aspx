<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherAccount.aspx.cs" Inherits="CyberCity.TeacherAccount" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div class="jumbotron">
        <h1>Teachers! Create New Account</h1>
        <p class="lead">Create an account to ...... </p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div>
        <asp:Table ID="teacherAccount" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTeacherFN" runat="server" Text="First Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtTeacherFN" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTeacherLN" runat="server" Text="Last Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtTeacherLN" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </div>
</asp:Content>
