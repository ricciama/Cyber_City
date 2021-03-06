﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VolunteerAccount.aspx.cs" Inherits="CyberCity.VolunteerAccount" %>


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
                    <img width="100" src="Images/volunteerAvatar.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Volunteer Sign up</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- First and Last name --%>
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
            <%-- Email --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="txtVolunteerEmail" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="RFVUsernme" runat="server" ControlToValidate="txtUsernme" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
<%--                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPassword" runat="server" ControlToValidate="txtPassword" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="tblConfirmation" runat="server" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="confirmationlbl" runat="server" Text="Volunteer Created!" Font-Bold="true" ForeColor="Green" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="lblEmailSuccess" runat="server" Text="Email sent to user" Font-Bold="true" ForeColor="Green" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>


    <%--<asp:Panel ID="volunteerSU" runat="server" HorizontalAlign="Center" BorderColor="#cccccc" BorderStyle="Solid">
        <br />
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            <div class="container-fluid">
              <div class="row">
                 <div class="col-md-6 mx-auto">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <img width="100" src="Images/loginguy.png"/>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4>Volunteer Sign up</h4>
                                </center>
                             </div>
                          </div>

                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>

                          <div class="row">
                             <div class="col-md-6">
                                <label>First Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="txtVolunteerFN" runat="server" placeholder="First Name"></asp:TextBox>
                                </div>
                             </div>
                                <div class="row">
                             <div class="col-md-6">
                                <label>Last Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="txtVolunteerLN" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                             </div>
                         </div>
                              </div>
                           <div class="row">
                             <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="txtVolunteerDOB" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                                </div>
                             </div>
                          
                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                        <asp:ListItem Value ="0" Text="Select Gender"></asp:ListItem>
                                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                        <asp:ListItem Value="Non-Binary" Text="Non-Binary"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                             </div>
                            </div>
                          <div class="row">
                             <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="txtVolunteerPhone" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                </div>
                             </div>
                             <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="txtVolunteerEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                </div>
                             </div>
                          </div>
                       <div class="row">
                           <div class="col-md-6">
                               <label>T-Shirt Size</label>
                               <div class="form-group">
                                   <asp:DropDownList ID="ddlShirtSize" runat="server" CssClass="form-control">
                                        <asp:ListItem Value ="0" Text="Select ShirtSize"></asp:ListItem>
                                        <asp:ListItem Value="X-Small" Text="X-Small"></asp:ListItem>
                                        <asp:ListItem Value="Small" Text="Small"></asp:ListItem>
                                        <asp:ListItem Value="Medium" Text="Medium"></asp:ListItem>
                                       <asp:ListItem Value="Large" Text="Large"></asp:ListItem>
                                       <asp:ListItem Value="X-Large" Text="X-Large"></asp:ListItem>
                                    </asp:DropDownList>
                               </div>
                           </div>
                           <div class="col-md-6">
                               <label>Lunch Ticket</label>
                               <div class="form-group">
                                   <asp:CheckBox ID="chkLunch" runat="server" />
                               </div>
                           </div>
                       </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Organaization Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtOrgName" runat="server" CssClass="form-control" placeholder="Organization Name"></asp:TextBox>
                                </div>
                            </div>

                        </div>





                          <div class="row">
                             <div class="col">
                                <center>
                                   <span class="badge badge-pill badge-info">Login Credentials</span>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col-md-4">
                                 <Label>Username</Label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" ID="txtVolunteerUser" runat="server" placeholder="Username" ReadOnly="True"></asp:TextBox>
                                </div>
                             </div>
                             <div class="col-md-4">
                                <label>Password</label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                </div>
                             </div>
                             <div class="col-md-4">
                                <label>Re-Type Password</label>
                                <div class="form-group">
                                   <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <center>
                                   <div class="form-group">
                                      <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnRegister" runat="server" Text="Register" />
                                   </div>
                                </center>
                             </div>
                          </div>
                       </div>
                    </div>
                    <a href="HomePage.aspx"><< Back to Home</a><br><br>
                 </div>
              </div>
           </div>
           </asp:Panel>
        </asp:Panel>--%>


</asp:Content>
