<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="CyberCity.StudentHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>--%>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <script src="Scripts/bootstrap.min.js"></script>
    
    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="css/GridView.css" rel="stylesheet" />

<%--    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>--%>

<%--    <style>
        .modal-backdrop.show{
            opacity: 0.5;
        }
    </style>--%>

            
     <div class="jumbotron">
        <div class="box">
            <h2>JMU Presents: CyberCity </h2>
            <p> The JMU mission has always been to educate leaders. <asp:LinkButton ID="learnMoreHomePage" runat="server" OnClick="learnMoreHomePage_Click">Click to Learn More</asp:LinkButton></p>
                    
        </div>
   </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Students - Complete Registration Here</h2>
            <p>
                Now that your account is created, a few steps are needed to complete your profile
                <br />
                1. Click the button below to complete your Cyber Day registration.
                <br />
                2. Fill in information as complete as possible

            </p>           

             <%--Button to Open the Modal--%>
                  <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Student Registration</button>

            <br />
            <br />
            <asp:Label ID="lblConfirmation" runat="server" Text="Student Registered Successfully!" Font-Bold="true" ForeColor="Green" Visible="false"></asp:Label>

                  <%--The Modal--%>
                  <div class="modal" id="myModal">
                    <div class="modal-dialog">
                      <div class="modal-content">
      
                        <%--Modal Header--%>
                        <div class="modal-header">
                          <h4 class="modal-title">Student Registration Survey</h4>
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
        
                        <%--Modal body--%>                  
                        <div class="modal-body">
                            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                                <%--Teacher Code--%>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center" Width="50%">
                                        <asp:Label ID="lblTeacherCode" runat="server" Text="Teacher Code" Font-Bold="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="cellPadding">
                                        <asp:TextBox ID="txtTeacherCode" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVTeacherCode" runat="server" ControlToValidate="txtTeacherCode" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%--Emergency Contact Name--%>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center" Width="50%">
                                        <asp:Label ID="lblEMName" runat="server" Text="Emergency Contact Name" Font-Bold="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="cellPadding">
                                        <asp:TextBox ID="txtEMName" runat="server" CssClass="form-control"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="RFVEMName" runat="server" ControlToValidate="txtEMName" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%--Emergency Contact Phone Number--%>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center" Width="50%">
                                        <asp:Label ID="lblEMNumber" runat="server" Text="Emergency Contact Phone Number" Font-Bold="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="cellPadding">
                                        <asp:TextBox ID="txtEMNumber" runat="server" CssClass="form-control"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="RFVEMNumber" runat="server" ControlToValidate="txtEMNumber" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%--Emergency Contact Relationship--%>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center" Width="50%">
                                        <asp:Label ID="lblEMRelationship" runat="server" Text="Relationship to Emergency Contact" Font-Bold="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="cellPadding">
                                        <asp:TextBox ID="txtEMRelationship" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVEMRelationship" runat="server" ControlToValidate="txtEMRelationship" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- Lunch --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell Width="50%">
                                        <asp:Label ID="lblLunch" runat="server" Text="Would you like a lunch Ticket?" Font-Bold="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <asp:DropDownList ID="ddlLunchTicket" runat="server" CssClass="form-control">
                                            <asp:ListItem Value ="N/A" Text = "Select"></asp:ListItem>
                                            <asp:ListItem Value ="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFVLunch" runat="server" ControlToValidate="ddlLunchTicket" InitialValue="N/A" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell> 
                                </asp:TableRow>
                                <%-- First Time Attending the Event --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell Width="50%">
                                        <asp:Label ID="Label2" runat="server" Text="Is it your first time attending Cyber Day?" Font-Bold="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <asp:DropDownList ID="ddlFirstTime" runat="server" CssClass="form-control">
                                            <asp:ListItem Value ="N/A" Text = "Select"></asp:ListItem>
                                            <asp:ListItem Value ="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RFVFirstTime" runat="server" ControlToValidate="ddlFirstTime" InitialValue="N/A" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell> 
                                </asp:TableRow>
                                <%-- Computer Access --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" Width="50%">
                                        <div class="form-group">
                                            <asp:Label ID="lblCPUAccess" runat="server" Text="Do you have access to a computer?" Font-Bold="True"></asp:Label>
                                        </div>                                      
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlCPUAccess" runat="server" CssClass="form-control">
                                            <asp:ListItem Value ="N/A" Text = "Select"></asp:ListItem>
                                            <asp:ListItem Value ="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFVCPUAccess" runat="server" ControlToValidate="ddlCPUAccess" InitialValue="N/A" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- Internet Access --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" Width="50%">
                                        <div class="form-group">
                                            <asp:Label ID="lblInternetAccess" runat="server" Text="Do you have reliable internet access?" Font-Bold="True"></asp:Label>
                                        </div>                                      
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlInternetAccess" runat="server" CssClass="form-control">
                                            <asp:ListItem Value ="N/A" Text = "Select"></asp:ListItem>
                                            <asp:ListItem Value ="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFVInternetAccess" runat="server" ControlToValidate="ddlInternetAccess" InitialValue="N/A" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- Please Describe your computer experience --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" Width="50%">
                                        <div class="form-group">
                                            <asp:Label ID="lblCPUExp" runat="server" Text="What is your experience with a computer?" Font-Bold="True"></asp:Label>
                                        </div>                                      
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlCPUExp" runat="server" CssClass="form-control">
                                            <asp:ListItem Value ="N/A" Text = "Select"></asp:ListItem>
                                            <asp:ListItem Value ="None" Text="None"></asp:ListItem>
                                            <asp:ListItem Value="Some" Text="Some"></asp:ListItem>
                                            <asp:ListItem Value="Moderate" Text="Moderate"></asp:ListItem>
                                            <asp:ListItem Value="Advanced" Text="Advanced"></asp:ListItem>
                                           <asp:ListItem Value="Expert" Text="Expert"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFVCPUExp" runat="server" ControlToValidate="ddlCPUExp" InitialValue="N/A" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>      
                                <%-- Allergies / Dietary Restrictions --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" Width="50%">
                                        <div class="form-group">
                                            <asp:Label ID="lblAllergies" runat="server" Text="Please list allergies and dietary restrictions to the right:" Font-Bold="True"></asp:Label>
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <asp:TextBox ID="txtAllergies" CssClass="form-control" runat="server" Wrap="true" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- Notes --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" Width="50%">
                                        <div class="form-group">
                                            <asp:Label ID="lblMisc" runat="server" Text="Additional notes and comments to the right:" Font-Bold="True"></asp:Label>
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <asp:TextBox ID="txtMisc" CssClass="form-control" runat="server" Wrap="true" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>  
                                <%-- Photo Permission --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" Width="50%">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Does JMU have permission to take and use photos of your child?" Font-Bold="True"></asp:Label>
                                        </div>                                      
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlPhotoPermission" runat="server" CssClass="form-control">
                                            <asp:ListItem Value ="N/A" Text = "Select"></asp:ListItem>
                                            <asp:ListItem Value ="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFVPhotoPermission" runat="server" ControlToValidate="ddlPhotoPermission" InitialValue="N/A" Text="Required Field" Font-Bold="true" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>                                
                            </asp:Table>
                            <asp:Table ID ="tblError" runat="server" HorizontalAlign="center" Visible="false">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label ID="lblError" runat="server" Text="Teacher code does not exist. Please try again!" ForeColor="Red" Font-Bold="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>
        
                        <%--Modal footer--%>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />           
                        </div>
        
                      </div>
                    </div>
                  </div>

        </div>
        <div class="col-md-4">
            <h2>Upcoming Events</h2>
            <p>
                <asp:GridView 
                    runat="server" 
                    ID="studentSchedule" 
                    BorderColor="Black" Font-Size="Large"
                    Width="350px" 
                    AutoGenerateColumns="true" 
                    AllowPaging="true" CssClass="Grid" 
                    AlternatingRowStyle-CssClass="alt" 
                    PagerStyle-CssClass="pgr" 
                    CellPadding="6">         
                </asp:GridView>
            </p>
         
        </div>
        <div class="col-md-4">
            <h2>About Us</h2>
            <p>
                To learn more about all the great events we have to offer please visit our about page. 
            <p>
                <a class="btn btn-default" href="About.aspx">Learn more &raquo;</a>
                &nbsp;
                <a class="btn btn-default" href="Contact.aspx">Need help? &raquo;</a>
            </p>

        </div>
    </div>


</asp:Content>
