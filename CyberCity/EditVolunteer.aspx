<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditVolunteer.aspx.cs" Inherits="CyberCity.EditVolunteer" %>
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
                    <img width="100" src="Images/OrgRepAvatar.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Edit Volunteer</h4>              
                </asp:TableCell>
            </asp:TableRow>
          <asp:TableRow HorizontalAlign="Center">
                 <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div >
                        <div class="form-group">
                            <asp:DropDownList ID="ddlVolunteers" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlVolunteers_SelectedIndexChanged" >
                                <asp:ListItem Text="Select Volunteer" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:TableCell>
             
                         
              </asp:TableRow>
            </asp:Table>

            
            <%-- First and Last name --%>
   
           <asp:Table ID="EditInfo" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">  
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerFN" runat="server" placeholder="First Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFirstName" runat="server" ControlToValidate="txtVolunteerFN" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerLN" runat="server" placeholder="Last Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVLastName" runat="server" ControlToValidate="txtVolunteerLN" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Phone and email --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerPhone" runat="server" placeholder="Contact No" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPhone" runat="server" ControlToValidate="txtVolunteerPhone" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="txtVolunteerEmail" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
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

            <%-- Shirt Size and Gender --%>
            <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlShirtSize" runat="server" CssClass="form-control">
                            <asp:ListItem Value="-1" Text="Select Shirt Size"></asp:ListItem>
                            <asp:ListItem Value="X-Small" Text="X-Small"></asp:ListItem>
                             <asp:ListItem Value="Small" Text="Small"></asp:ListItem>
                             <asp:ListItem Value="Medium" Text="Medium"></asp:ListItem>
                             <asp:ListItem Value="Large" Text="Large"></asp:ListItem>
                             <asp:ListItem Value="X-Large" Text="X-Large"></asp:ListItem>
                         </asp:DropDownList>
                    </div>
                </asp:TableCell>
                 <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                            <asp:ListItem Value="-1" Text="Select Gender"></asp:ListItem>
                             <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                             <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                             <asp:ListItem Value="Non-Binary" Text="Non-Binary"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                   <asp:TableCell>
                       <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtUserName" runat="server" placeholder="UserName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVUserName" runat="server" ControlToValidate="txtUserName" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                   </asp:TableCell>
               </asp:TableRow>
                
          
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnCommitEdits" runat="server" Text="Commit Edits" OnClick="btnCommitEdits_Click" />  
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
