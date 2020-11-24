<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VolunteerProfile.aspx.cs" Inherits="CyberCity.VolunteerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="css/CreatingEntity.css" rel="stylesheet" /> 
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server" BorderColor="#cccccc" BorderStyle="Solid">
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
                    <h4>Edit Volunteer Information</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- First and Last name --%>
            <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
                <asp:TableCell  HorizontalAlign="Center" CssClass="cellPadding">                    
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerFN" runat="server" placeholder="First Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">             
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerLN" runat="server" placeholder="Last Name"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Gender --%>
            <asp:TableRow HorizontalAlign="Center">
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
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerPhone" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                    </div>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">                   
                        <asp:TextBox CssClass="form-control" ID="txtVolunteerEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Shirt size and Lunch --%>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
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
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group form-control">
                        <asp:Label ID="Label2" runat="server" Text="Lunch?" Font-Bold="True"></asp:Label> &nbsp;                                                                   
                        <asp:CheckBox ID="chkLunch" runat="server"/>
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
                        <asp:TextBox class="form-control" ID="txtUsernme" runat="server" placeholder="Username" ReadOnly="true"></asp:TextBox>
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
                    <asp:Label ID="Label1" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox ID="txtPassword2" CssClass="form-control" runat="server" placeholder="Re-Enter Password" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" Text="Passwords do not match!" ForeColor="Red" Font-Bold="true"></asp:CompareValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
                    </div>
                </asp:TableCell>
                <asp:TableCell CssClass="cellPadding">
                    <div class="form-group">
                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnUpdatePassword" runat="server" Text="Update Password" OnClick="btnUpdatePassword_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="tblConfirmation" runat="server" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblConfirmation" runat="server" Text="Profile Updated Successfully!" Font-Bold="true" ForeColor="Green" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <div class="form-group">
                        <asp:Label ID="lblPasswordSuccess" runat="server" Text="Password Updated Successfully!" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
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

