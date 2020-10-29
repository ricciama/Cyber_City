<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="CyberCity.StudentHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>--%>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <script src="Scripts/bootstrap.min.js"></script>
    
    <link href="css/CreatingEntity.css" rel="stylesheet" />


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
                1. Click the button below to complete student survey.
                <br />
                2. Fill in information as complete as possible
            </p>           

             <%--Button to Open the Modal--%>
                  <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Student Survey</button>

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
                                <%-- Age and Grade --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtAge" CssClass="form-control" runat="server" placeholder="Age" ></asp:TextBox>
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlGrade" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0" Text="Select Grade"></asp:ListItem>
                                            </asp:DropDownList>
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
                                <%-- Computer Access --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                                        <div class="form-group">
                                            <asp:Label ID="lblCPUAccess" runat="server" CssClass="form-control" Text="Do you have access to a computer?" Font-Bold="True"></asp:Label>
                                        </div>                                      
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <div class="form-group">
                                            <asp:RadioButton ID="rdYes" CssClass="form-control" runat="server" Text="Yes" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                                        <div class="form-group">
                                            <asp:RadioButton ID="rdNo" CssClass="form-control" runat="server" Text="No" />
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- Please Describe your computer experience --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <div class="form-group">
                                            <asp:Label ID="lblCPUExp" runat="server" Text="Please Describe Your Computer Experience." Font-Bold="True"></asp:Label>
                                        </div>
                                    </asp:TableCell>
                                    </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <asp:TextBox ID="txtCPUExp" CssClass="form-control" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- Allergies --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <div class="form-group">
                                            <asp:Label ID="lblAllergies" runat="server" Text="Please List Any Allergies You Have." Font-Bold="True"></asp:Label>
                                        </div>
                                    </asp:TableCell>
                                    </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <asp:TextBox ID="txtAllergies" CssClass="form-control" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- Dietary Restrictions --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <div class="form-group">
                                            <asp:Label ID="lblDiet" runat="server" Text="Please List Any Dietary Restrictions You May Have" Font-Bold="True"></asp:Label>
                                        </div>
                                    </asp:TableCell>
                                    </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <asp:TextBox ID="txtDiet" CssClass="form-control" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <%-- ANYTHING else --%>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <div class="form-group">
                                            <asp:Label ID="lblMisc" runat="server" Text="Is There Anything Else You Would Like Us to Know?" Font-Bold="True"></asp:Label>
                                        </div>
                                    </asp:TableCell>
                                    </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                                        <asp:TextBox ID="txtMisc" CssClass="form-control" runat="server"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>                             
                            </asp:Table>
                        </div>
        
                        <%--Modal footer--%>
                        <div class="modal-footer">
                            <asp:Button ID="btnSave" CssClass="btn btn-success" data-dismiss="modal" runat="server" Text="Save" OnClick="btnSave_Click" />
                          
                        </div>
        
                      </div>
                    </div>
                  </div>


        </div>
        <div class="col-md-4">
            <h2>Upcoming Events</h2>
            <p>
                Connection to DB for furture evetns...
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
