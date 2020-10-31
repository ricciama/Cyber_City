<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterOrgRep.aspx.cs" Inherits="CyberCity.RegisterOrgRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
   
        <br />
    <br />
    <asp:Panel ID="pnlRegisterOrg" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblRegisterOrg" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/loginguy.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Register an Orgsnizational Representative for an Event</h4>              
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
                        
                        <asp:UpdatePanel runat="server" ID="beans">
                            <ContentTemplate>
                                    <asp:DropDownList ID="ddlSelectProgram" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged = "ddl_Event_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSelectOrg" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_OrgRep_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlOrgRep" runat="server" CssClass="form-control"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

            <br />
            <hr />
            <br />

        <%-- Table to Display Program Schedule --%>
        <div class="container">
            <div class="floatLeft">
                <asp:GridView 
                    runat="server" 
                    ID="programSchedule" 
                    AlternatingRowStyle-BackColor="MediumPurple" 
                    BorderColor="Black">         
                </asp:GridView>
            </div>
        </div>      

    </asp:Panel>




</asp:Content>
