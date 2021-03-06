﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOrganization.aspx.cs" Inherits="CyberCity.EditOrganization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    
    <br />
    <br />
    <asp:Panel ID="pnlEditOrgRep" runat="server"  BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <br />
        <asp:Table ID="tblEditOrgRep" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/OrganizationAvatar.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Edit Organization</h4>              
                </asp:TableCell>
            </asp:TableRow>
          <asp:TableRow HorizontalAlign="Center">
                 <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:DropDownList ID="ddlOrgs" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgs_SelectedIndexChanged">
                                <asp:ListItem Text="Select Organization" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:TableCell>                       
              </asp:TableRow>
            </asp:Table>
            
            <%-- Name and Adress --%>
           <asp:Table ID="EditInfo" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">  
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgName" runat="server" placeholder="Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVOrgName" runat="server" ControlToValidate="txtOrgName" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgAddress" runat="server" placeholder="Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVOrgAddress" runat="server" ControlToValidate="txtOrgAddress" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>

            <%-- Contact, Phone and email --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgContact" runat="server" placeholder="Primary Contact" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVOrgContact" runat="server" ControlToValidate="txtOrgContact" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtOrgEmail" runat="server" placeholder="Primary Contact Email" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="txtOrgEmail" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtOrgPhone"  runat="server" placeholder="Primary Contact Phone" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVOrgPhone" runat="server" ControlToValidate="txtOrgPhone" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            

            </asp:TableRow>
            
           
                    
          
          
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnCommitEdits" runat="server" Text="Commit Edits" OnClick="editOrg_Click"/>  
                    </div>
                </asp:TableCell>
            </asp:TableRow>
           </asp:Table>  
        <br />
        <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Organization Updated Successfully!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
              
        </asp:Panel>

</asp:Content>