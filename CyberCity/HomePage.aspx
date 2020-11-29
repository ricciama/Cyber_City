<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CyberCity._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/GridView.css" rel="stylesheet" />
    <link href="css/CreatingEntity.css" rel="stylesheet" />

    <div class="jumbotron">
        <div class="box">
        <%--<h1>JMU Presents: CyberCity - comment </h1>--%>
        <%--<p>“The JMU mission has always been to educate leaders. Our students exemplify that mission by not only being leaders in their academic studies, but also by leading these visiting young people to promising technology careers.” </p>--%>
            <h2>JMU Presents: Cyber Day</h2>
            <p> The JMU mission has always been to educate leaders. <asp:LinkButton ID="learnMoreHomePage" runat="server" OnClick="learnMoreHomePage_Click">Click to Learn More</asp:LinkButton></p>
            
        
        <%--<p><a href="https://www.jmu.edu/cob/cis/about/cyberday.shtml" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
        </div>
   </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                1. New to the site? Create an account to view your profile.
                <br />
                2. Login to your profile and fill out the registration forms.
                <br />
                3. Already have an account? Click here to log in
            </p>
            <p>
                <a class="btn btn-default" href="Login.aspx"> Click Here &raquo;</a>
            </p>
            
            
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

    <!-- Footer -->

    <style>
    .page-footer {
        background-color: #450084;
    }
    h5{
       color:white;
    }
    </style>
    <hr />
        <footer class="page-footer font-small pt-4">

          <!-- Footer Links -->
          <div class="container-fluid text-center text-md-left">

            <!-- Grid row -->
            <div class="row">

              <!-- Grid column -->
              <div class="col-md-6 mt-md-0 mt-3">

                <!-- Content -->
                <h5 class="text-uppercase">Questions? Send a message here.</h5>
                  <asp:Table ID="Table1" runat="server">
                      <asp:TableRow>
                          <asp:TableCell>
                              <div class="form-group">
                                  <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                              </div>
                          </asp:TableCell>
                           <asp:TableCell>
                              <div class="form-group">
                                  <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
                              </div>
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                         <asp:TableCell ColumnSpan="2">
                             <div class="form-group">
                                 <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox>
                             </div>
                         </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell ColumnSpan="2">
                              <div class="form-group">
                                  <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" placeholder="Type Message here.."></asp:TextBox>
                              </div>
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow HorizontalAlign="Right">
                          <asp:TableCell>
                              <asp:Button ID="btnSendMessage" runat="server" CssClass="btn btn-sm btn-primary" Text="Send" OnClick="btnSendMessage_Click" />
                          </asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>

              </div>
<%--              <!-- Grid column -->

              <hr class="clearfix w-100 d-md-none pb-3">--%>

              <!-- Grid column -->
              <div class="col-md-3 mb-md-0 mb-3">

                <!-- Links -->
                <h5 class="text-uppercase">Quick Links</h5>

                <ul class="list-unstyled">
                  <li>
                    <a href="About.aspx">About Us</a>
                  </li>
                  <li>
                    <a href="Contact.aspx">Contact Us</a>
                  </li>
                  <li>
                    <a href="ParentAccount.aspx">Create New Account</a>
                  </li>
                  <li>
                    <a href="Login.aspx">Have an Account? Log in here</a>
                  </li>
                </ul>

              </div>
              <!-- Grid column -->

              <!-- Grid column -->
              <div class="col-md-3 mb-md-0 mb-3">

                <!-- Links -->
                <h5 class="text-uppercase">Links</h5>

                <ul class="list-unstyled">
                  <li>
                    <a href="#!">Link 1</a>
                  </li>
                  <li>
                    <a href="#!">Link 2</a>
                  </li>
                  <li>
                    <a href="#!">Link 3</a>
                  </li>
                  <li>
                    <a href="#!">Link 4</a>
                  </li>
                </ul>

              </div>
              <!-- Grid column -->

            </div>
            <!-- Grid row -->

          </div>
          <!-- Footer Links -->

          <!-- Copyright -->
          <div class="footer-copyright text-center py-3">© 2020 Copyright:
            <a href="https://mdbootstrap.com/"> MDBootstrap.com</a>
          </div>
          <!-- Copyright -->

        </footer>
        <!-- Footer -->


</asp:Content>
