<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterOrgRep.aspx.cs" Inherits="CyberCity.RegisterOrgRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="css/GridView.css" rel="stylesheet" />
        <br />
    <br />
    <asp:Panel ID="pnlRegisterOrg" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblRegisterOrg" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/OrgRepAvatar.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Register an Organizational Representative for an Event</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- Select Program --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Right" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:Label ID="lblProgram" runat="server" Text="Select Program"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:DropDownList ID="ddlSelectProgram" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectProgram_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Select Organization --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Right" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblSelectOrg" runat="server" Text="Select Organization"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlSelectOrg" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectOrg_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Select Org Rep --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Right" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblOrgRep" runat="server" Text="Select Organizational Representative"></asp:Label>
                    </div>                   
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlOrgRep" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_OrgRep_SelectedIndexChanged"></asp:DropDownList>
                    </div>                    
                </asp:TableCell>
            </asp:TableRow>
            <%-- Select Event --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Right" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblEvent" runat="server" Text="Select Event"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlEvent" runat="server" CssClass="form-control"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"/>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Error checking labels --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:Label ID="lblProgramError" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:Label ID="lblEventError" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:Label ID="lblOrgError" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:Label ID="lblOrgRepError" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
             <%-- Success Label --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

            <br />
            <hr />
            <br />
        

        <%-- Table to Display Program Schedule --%>
       
            <div class="container">
                <div class="floatLeft">
                    <asp:Label ID="lblSchedule" runat="server" Text="Program Schedule" Font-Size="Large" Font-Underline="True" Font-Bold="True" Visible="false" ></asp:Label>
                    <asp:GridView 
                        runat="server" Width="75%" 
                        ID="programSchedule" 
                        CssClass="Grid" 
                        AlternatingRowStyle-CssClass="alt" 
                        PagerStyle-CssClass="pgr" 
                        CellPadding="6" 
                        BorderColor="Black" 
                        AllowPaging="true" 
                        AutoGenerateColumns="true" 
                        Font-Size="Large">  
                    </asp:GridView>
                </div>
            

        <%-- Gridview for Org Rep Schedule --%>
            
                <div class="floatRight">
                    <asp:Label ID="lblOrgRepSchedule" runat="server" Text="Organization Rep Schedule" Font-Size="Large" Font-Bold="True" Visible="false"></asp:Label>
                    <asp:GridView 
                        ID="orgRepSchedule"
                        runat="server" Width="75%"
                        CssClass="Grid" 
                        AlternatingRowStyle-CssClass="alt" 
                        PagerStyle-CssClass="pgr" 
                        CellPadding="6"
                        DataKeyNames="ID" OnRowDataBound="orgRepSchedule_RowDataBound" 
                        BorderColor="Black" AllowPaging="true" 
                        AutoGenerateColumns="true" 
                        Font-Size="Large" AutoGenerateDeleteButton="true" OnRowDeleting="orgRepSchedule_RowDeleting">
                    </asp:GridView>
                </div>
        </div>    

    </asp:Panel>


</asp:Content>
