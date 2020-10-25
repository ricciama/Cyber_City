<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParentAccount.aspx.cs" Inherits="CyberCity.ParentAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">
            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/loginguy.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Create Student Account</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- Parent First and Last Name --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox ID="txtParentFN" runat="server" CssClass="form-control" placeholder="Guardian First Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox ID="txtParentLN" runat="server" CssClass="form-control" placeholder="Guardian Last Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Student First and Last name --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtStudentFN" runat="server" placeholder="Student First Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtStudentLN" runat="server" placeholder=" Student Last Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Date of Birth and Gender --%>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">               
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtStudentDOB" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                            <div class="form-group">
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                    <asp:ListItem Value ="0" Text="Select Gender"></asp:ListItem>
                                    <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                    <asp:ListItem Value="Non-Binary" Text="Non-Binary"></asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Phone and email --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtParentPhone" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtParentEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Allergies and Ethinicity --%>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlEthnicity" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Text="Select Ethnicity"></asp:ListItem>
                            <asp:ListItem Value="White/Caucasion"></asp:ListItem>
                            <asp:ListItem Value="Hispanic or Latino" Text="Hispanic or Latino"></asp:ListItem>
                            <asp:ListItem Value="Black or African American" Text="Black or African American"></asp:ListItem>
                            <asp:ListItem Value="Native Hawaiian" Text="Native Hawaiian"></asp:ListItem>
                            <asp:ListItem Value="Asian" Text="Asian"></asp:ListItem>
                            <asp:ListItem Value="Middle Eastern / North African" Text="Middle Eastern / North African"></asp:ListItem>
                            <asp:ListItem Value="Other/Prefer not to say" Text="Other/Prefer not to say"></asp:ListItem>
                        </asp:DropDownList>
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
                        <asp:TextBox class="form-control" ID="txtUsernme" runat="server" placeholder="Username"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="Label1" runat="server" Text="Re-type Passowrd" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                </asp:TableCell>
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
    </asp:Panel>
</asp:Content>
