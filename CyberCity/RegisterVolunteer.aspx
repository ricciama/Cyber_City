<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterVolunteer.aspx.cs" Inherits="CyberCity.RegisterVolunteer" %>
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
                        <asp:DropDownList ID="ddlSelectProgram" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectProgram_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="ddlSelectProgram" Display="Dynamic" SetFocusOnError="true" Text="*Please Choose a Program"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Select Volunteer --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell HorizontalAlign="Right" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Label ID="lblSelectVolunteer" runat="server" Text="Select Volunteer"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlSelectVolunteer" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectVolunteer_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Text="*Please Select a Volunteer" Display="Dynamic" ControlToValidate="ddlSelectVolunteer" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Text="*Please Select an Event" Display="Dynamic" ControlToValidate="ddlEvent" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
             <%--Error Checking labels --%>
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
                    <asp:Label ID="lblVolunteerError" runat="server" Text=""></asp:Label>
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

        <%-- Gridview for Program Schedule --%>
        <div class="container">
                <div class="floatLeft">
                    <asp:Label ID="lblSchedule" runat="server" Text="Program Schedule" Font-Size="Large" Font-Bold="True" Visible="false" ></asp:Label>
                    <asp:GridView 
                        runat="server" 
                        ID="programSchedule" 
                        AlternatingRowStyle-BackColor="#450084" 
                        BorderColor="Black" 
                        AllowPaging="true" 
                        AutoGenerateColumns="true" 
                        AlternatingRowStyle-ForeColor="White" 
                        Font-Size="Medium">                           
                    </asp:GridView>

                </div>
         
        <%-- Gridview for Volunteer Schedule --%>
            <div class="floatRight">
                <asp:Label ID="lblVolSchedule" runat="server" Text="Volunteer Schedule" Font-Size="Large" Font-Bold="True" Visible="false"></asp:Label>
                <asp:GridView 
                    ID="volunteerSchedule"
                    runat="server" 
                    AlternatingRowStyle-BackColor="#450084" 
                    BorderColor="Black" 
                    AutoGenerateColumns="true"  
                    AlternatingRowStyle-ForeColor="White" 
                    Font-Size="Medium">
                </asp:GridView>
            </div>
        </div>

       </asp:Panel>
</asp:Content>
