<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOrgRep.aspx.cs" Inherits="CyberCity.EditOrgRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="css/CreatingEntity.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="pnlEditOrgRep" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblEditOrgRep" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/loginguy.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Edit Organizational Representative</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                 <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">                    
                    <h4>Select Organizational Representative</h4>              
                </asp:TableCell>
            </asp:TableRow>
          <asp:TableRow HorizontalAlign="Center">
                 <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:DropDownList ID="ddlOrgReps" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select Organizational Representitive" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:TableCell>
              <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="editOrgRep" runat="server" Text="Load Organizational Representative to Edit" onclick="editOrgRep_Click"/>  
                        </div>
                    </div>
                </asp:TableCell>
                         
              </asp:TableRow>
            </asp:Table>

    </asp:Panel>
            
            <%-- First and Last name --%>
    <asp:Panel ID="EditInfoPanel" runat="server">
           <asp:Table ID="EditInfo" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">  
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepFN" runat="server" placeholder="First Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepLN" runat="server" placeholder="Last Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Phone and email --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepPhone" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Lunch --%>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <div class="form-group form-control">
                        <asp:Label ID="Label2" runat="server" Text="Lunch?" Font-Bold="True"></asp:Label> &nbsp;                                                                   
                        <asp:CheckBox ID="chkLunch" runat="server"/>
                    </div>
                </asp:TableCell>           
            </asp:TableRow>

            <%-- Code and Organization --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtCode" runat="server" placeholder="Code"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlOrgName" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Text="Select Organization"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </asp:TableCell>

            </asp:TableRow>
            <%-- Grade taught Drop Down --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <asp:Label ID="lblGrade" runat="server" Text="GradeTaught" ></asp:Label>
                    <div class="form-group">                   
                        <asp:CheckBox ID="chkElementary" runat="server" Text="Elementary"/> &nbsp;
                        <asp:CheckBox ID="chkSixth" runat="server" Text="Sixth" /> &nbsp;
                        <asp:CheckBox ID="chkSeventh" runat="server" Text="Seventh" /> &nbsp;
                        <asp:CheckBox ID="chkEight" runat="server" Text="Eight" /> &nbsp;
                        <asp:CheckBox ID="chkHighSchool" runat="server" Text="Highschool" /> &nbsp;
                        <asp:CheckBox ID="chkNone" runat="server" Text="None" /> &nbsp;
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Login credentials Logo --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <span class="badge badge-pill badge-info">Login Credentials</span>
                </asp:TableCell>
            </asp:TableRow>
          
          
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnCommitEdits" runat="server" Text="Commit Edits" onclick="btnCommitEdits_Click" />  
                    </div>
                </asp:TableCell>
            </asp:TableRow>
           </asp:Table>  
        <br />
        <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Profile Updated Successfully!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        </asp:Panel>

</asp:Content>
