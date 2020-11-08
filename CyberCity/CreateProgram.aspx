<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateProgram.aspx.cs" Inherits="CyberCity.CreateProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

         <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="pnlCreateProgram" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblCreateProgram" runat="server" CellPadding="50" CellSpacing="50" HorizontalAlign="Center">
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/loginguy.png"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Create a Program</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- Event Name and Date/Time--%>
            <asp:TableRow CssClass="cellPadding" HorizontalAlign="Center">
                <asp:TableCell CssClass="cellPadding" HorizontalAlign="Center">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtProgramName" runat="server" placeholder="Program Name"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVProgramName" runat="server" Text = "Required Field" ControlToValidate="txtProgramName" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell CssClass="cellPadding" HorizontalAlign="Center">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtProgramDateTime" runat="server" placeholder="Program Time" TextMode="Date"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RFVProgramDateTime" runat="server" Text = "Required Field" ControlToValidate="txtProgramDateTime" SetFocusOnError="true" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CVDate" runat="server" Text="Please select a future date" ForeColor="Red" Font-Bold="true" ControlToValidate="txtProgramDateTime" OnServerValidate="CVDate_ServerValidate"></asp:CustomValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnCreateProgram" runat="server" Text="Create Program" OnClick="btnCreateProgram_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
         <br />
        <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="confirmationlbl" runat="server" Text="Program Successfully Created!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID ="tblAddEvents" runat="server" HorizontalAlign="Right" CellPadding="50">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="1">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAddEvents" runat="server" CausesValidation="true" Text="Add Events -> " OnClick="btnAddEvents_Click"/>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        &nbsp;
        <br />
    </asp:Panel>
</asp:Content>
