<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrgRepAccount.aspx.cs" Inherits="CyberCity.OrgRepAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="OrgRepAcct" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/OrgRepAvatar.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Organizational Representative Sign up</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- First and Last name --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepFN" runat="server" placeholder="First Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFirstName" runat="server" text ="Required Field" ForeColor="Red" Font-Bold="true" ControlToValidate="txtOrgRepFN" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepLN" runat="server" placeholder="Last Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVLastName" runat="server" text ="Required Field" ForeColor="Red" Font-Bold="true" ControlToValidate="txtOrgRepLN" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- email --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVEmail" runat="server" text ="Required Field" ForeColor="Red" Font-Bold="true" ControlToValidate="txtOrgRepEmail" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Code and Organization --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCode" runat="server" placeholder="Code"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVCode" runat="server" text ="Required Field" ForeColor="Red" Font-Bold="true" ControlToValidate="txtCode" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlOrgName" runat="server" CssClass="form-control">
                            <asp:ListItem Value="-1" Text="Select Organization"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVOrgName" runat="server" text ="Required Field" ForeColor="Red" Font-Bold="true" ControlToValidate="ddlOrgName" SetFocusOnError="true" InitialValue="-1"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="RFVUsernme" runat="server" text ="Required Field" ForeColor="Red" Font-Bold="true" ControlToValidate="txtUsernme" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
<%--                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtPassword" runat="server" text ="Required Field" ForeColor="Red" Font-Bold="true" ControlToValidate="txtPassword" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>--%>
            </asp:TableRow>
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
          <br />
        <asp:Table ID="tblConfirmation" runat="server" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="confirmationlbl" runat="server" Text="Organizational Representative Created!" Font-Bold="true" ForeColor="Green" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmailSuccess" runat="server" Text="Email sent to user" Font-Bold="true" ForeColor="Green" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>

</asp:Content>
