<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParentAccount.aspx.cs" Inherits="CyberCity.ParentAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/StudentCreateAccountSheet.css" rel="stylesheet" />
    <div>
            <div class="header" >
        <h1 > Create Student Account</h1>

        <div class="accountBox">
            <asp:Table ID="accountForm" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                        <h2 class="h2">Personal Information</h2>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:TextBox ID="fistName" runat="server" placeholder=" Gardian First Name" CssClass="firstName" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lastName" runat="server" placeholder=" Gardian Last Name" CssClass="LastName" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                         <asp:TextBox ID="email" runat="server" placeholder="Email" CssClass="email" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="phone" runat="server" placeholder="Phone Number" CssClass="phone" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="StudentfirstName" runat="server" placeholder="Student First Name" CssClass="SFirstName" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="StudentLastName" runat="server" placeholder="Student Last Name" CssClass="SLastName" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:DropDownList ID="schoolddl" runat="server" CssClass="school">
                            <asp:ListItem>Select Your School</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="teacherddl" runat="server" CssClass="teacher">
                            <asp:ListItem>Select Your Teacher</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="center">
                        <h2 class="h2"> Account Information</h2>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table3" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="username" runat="server" placeholder="Username" CssClass="username" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="password" runat="server" placeholder="Password" CssClass="password" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                         <asp:TextBox ID="reenter" runat="server" placeholder="Re-Enter Password" CssClass="reEnter" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="createbutton" runat="server" HorizontalAlign=" center">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Button ID="createAccount" runat="server" Text="Create Account" CssClass="create" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </>
        </div>
    </div>
        </div>
</asp:Content>
