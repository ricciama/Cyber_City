<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProgram.aspx.cs" Inherits="CyberCity.EditProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="pnlEditProgram" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblEditProgram" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/JmuSeal.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Edit Program</h4>              
                </asp:TableCell>
            </asp:TableRow>
          <%-- Program ddl to select which program to edit--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell CssClass="cellPadding">
                    <div class ="form-group">
                        <asp:DropDownList ID="ddlProgamNames" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProgamNames_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Text ="Select Program to Edit"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </asp:TableCell>
               
            </asp:TableRow>
            <%-- Program Name and Date/Time--%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtProgramName" runat="server" placeholder="Program Name" Visible="false"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtProgramDateTime" runat="server" placeholder="Program Time" Visible="false"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
     
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnEditProgram" runat="server" Text="Edit Program" OnClick="btnEditProgram_Click" Visible="false"/>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
         <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Program Updated!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

</asp:Content>
