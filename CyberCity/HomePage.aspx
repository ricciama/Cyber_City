<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CyberCity._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/GridView.css" rel="stylesheet" />
    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="css/homePageFooter.css" rel="stylesheet" />
    <link rel="stylesheet" href="lib/font-awesome/css/all.css">

    <div class="jumbotron">
        <div class="box">
        <%--<h1>JMU Presents: CyberCity - comment </h1>--%>
        <%--<p>“The JMU mission has always been to educate leaders. Our students exemplify that mission by not only being leaders in their academic studies, but also by leading these visiting young people to promising technology careers.” </p>--%>
            <h2>JMU Presents: Cyber Day</h2>
            <p> The JMU mission has always been to educate leaders. <asp:LinkButton ID="learnMoreHomePage" runat="server" OnClick="learnMoreHomePage_Click">Click to Learn More</asp:LinkButton></p>
            
        
        <%--<p><a href="https://www.jmu.edu/cob/cis/about/cyberday.shtml" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
        </div>
   </div>

    
    <style>

   /* .col-md-4 {
        box-shadow: 0 0 1rem
        0 rgba(100,110,140,.3);
        border-radius: 6px; 
            
       
    }*/
   </style>

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
            <h2>Upcoming Cyber Days</h2>
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



    <!-- footer-->
    <div class="footer">
        <div class="footer-content">
            <div class="footer-section about">
                <h1 class="logo-text">Cyber Day</h1>
                <p>
                    Stay connected with us and all you need to know about JMU on our social media accounts
                </p>
                <div class="contact">
                    
                    <span> <i class="fas fa-phone"></i>&nbsp; 540-568-6211</span>
                    <span><i class="fas fa-envelope"></i> &nbsp; 800 S Main Street, Harrisonburg, VA 22807</span>
                </div>
                <div class="socials">
                    <a href="https://www.facebook.com/jamesmadisonuniversity/"><i class="fab fa-facebook"></i></a>
                    <a href="https://www.instagram.com/jamesmadisonuniversity/?hl=en"><i class="fab fa-instagram"></i></a>
                    <a href="https://twitter.com/JMU?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor"><i class="fab fa-twitter"></i></a>
                    <a href="https://www.youtube.com/channel/UCiaHN4XRxNHjP84tlSAmDyQ"><i class="fab fa-youtube"></i></a>
                </div>
            </div>
            <div class="footer-section links">
                <h2 class="links">Quick Links</h2>
                <br />
                
                <a href="About.aspx">About</a>
                <br />
                <a href="Contact.aspx">Contact</a>
                <br />
                <a href="ParentAccount.aspx">Create Account</a>
                <br />
                <a href="Login.aspx">Login</a>
                    
            </div>
            <div class="footer-section contact-form">
                <h2 >Contact Us</h2>
                <asp:Table runat="server">
                   <%-- <asp:TableRow>
                        <asp:TableCell>
                            <asp:TextBox ID="txtName" runat="server" CssClass="text-input contact-input" placeholder="Full Name"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>--%>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:TextBox ID="txtEmail" runat="server" Width="300px" CssClass="text-input contact-input" placeholder="Email" TextMode="Email"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:TextBox ID="txtMessage" TextMode="MultiLine" Height="120" Width="300px" runat="server" CssClass="text-input contact-input" placeholder="Type message here.."></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        

                        <asp:TableCell>
                             <asp:Button ID="btnSendMessage" runat="server" CssClass="btn1 btn-big contact-btn" Width="80" Text="Send"/>
                        </asp:TableCell>
                    </asp:TableRow>

                    <%-- Brian can you check this --%>
                   <%-- <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="tblMessageConfirmation" runat="server" Text="Message Successfullly Sent!" ForeColor="White" Font-Bold="true"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>--%>

                    

                </asp:Table>

                
                
                
                
            </div>
        </div>

        <div class="footer-bottom">
            &copy; <a href="http://cybercity-dev.us-east-1.elasticbeanstalk.com/HomePage.aspx">cyberday.com</a> | Designed by SCoR Consulting
        </div>
    </div>
    <!-- // footer ->





























    <!-- Footer -->

<%--    <style>

    a:link{
    font-size:medium;
    color:black; 
    }
    .page-footer {
        background-color: #EDE9E8;
        border: groove;
        box-shadow: 0 0 1rem
        0 rgba(100,110,140,.3);
        border-radius: 6px; 
            
       
    }
    h5{
        font-size:large;
       color:black;
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
                  
                  <asp:Table runat="server" >
                      <asp:TableRow>
                          <asp:TableCell HorizontalAlign="Center">
                              <h5 class=headers> QUESTIONS? SEND A MESSAGE HERE</h5>
                          </asp:TableCell>
                      </asp:TableRow>
                    
                      <asp:TableRow>
                          <asp:TableCell >
                               <asp:TextBox ID="txtName" runat="server" CssClass="FooterFullName" placeholder="Full Name"></asp:TextBox>
                          </asp:TableCell>
                          </asp:TableRow>

                              <asp:TableRow>
                          <asp:TableCell>
                               <asp:TextBox ID="txtEmail" runat="server" CssClass="FooterEmail" placeholder="Email" TextMode="Email"></asp:TextBox>
                          </asp:TableCell>

                         
                      </asp:TableRow>

                      <asp:TableRow>
                          <asp:TableCell>
                              <asp:TextBox ID="txtSubject" runat="server" CssClass="FooterSubject" placeholder="Subject"></asp:TextBox>
                          </asp:TableCell>
                      </asp:TableRow>

                       <asp:TableRow>
                           <asp:TableCell>
                              <asp:TextBox ID="txtMessage" TextMode="MultiLine" Height="120" Width="300px" runat="server" CssClass="FooterMessage" placeholder="Type Message here.."></asp:TextBox>
                          </asp:TableCell>
                      </asp:TableRow>

                      <asp:TableRow>
                          <asp:TableCell>
                                <asp:Button ID="btnSendMessage" runat="server" CssClass="FooterBtn" Text="Send" OnClick="btnSendMessage_Click"  />
                          </asp:TableCell>
                      </asp:TableRow>

                  </asp:Table>--%>
                  
                  <%--<asp:Table ID="tblMessageConfirmation" runat="server" HorizontalAlign="Center">
                      <asp:TableRow>
                          <asp:TableCell>
                              <asp:Label ID="Confirmation" runat="server" Text="Message Successfullly Sent!" ForeColor="Green" Font-Bold="true" CssClass="FooterBtn"></asp:Label>
                          </asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>--%>
                 






                  
       <%--       </div>
            </div>
           </div>
         </footer>--%>










               <%-- <!-- Content -->
                <h5 class="text-uppercase">Questions? Send a message here.</h5>
                  <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                      <asp:TableRow>
                          <asp:TableCell>
                              <div class="form-group">
                                  <asp:TextBox ID="txtName" runat="server" CssClass="form-controls" placeholder="Full Name"></asp:TextBox>
                              </div>
                          </asp:TableCell>
                           <asp:TableCell>
                              <div class="form-group">
                                  <asp:TextBox ID="txtEmail" runat="server" CssClass="form-controls" placeholder="Email" TextMode="Email"></asp:TextBox>
                              </div>
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                         <asp:TableCell ColumnSpan="12">
                             <div class="form-group">
                                 &nbsp;
                                 &nbsp;
                                 <asp:TextBox ID="txtSubject" runat="server" CssClass="form-controls1" placeholder="Subject"></asp:TextBox>
                             </div>
                         </asp:TableCell>
                      </asp:TableRow>

                      <asp:TableRow>
                          <asp:TableCell ColumnSpan="12">
                              <div class="form-group">
                                  <asp:TextBox ID="txtMessage" TextMode="MultiLine" Height="120" runat="server" CssClass="form-controls" placeholder="Type Message here.."></asp:TextBox>
                              </div>
                          </asp:TableCell>
                      </asp:TableRow>


                      <asp:TableRow HorizontalAlign="Right">
                          <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                              <asp:Button ID="btnSendMessage" Width="150" Height="40" runat="server" CssClass="btn btn-sm btn-primary" Text="Send" OnClick="btnSendMessage_Click" />
                          </asp:TableCell>
                      </asp:TableRow>

                    </asp:Table>
                  <asp:Table ID="tblMessageConfirmation" runat="server" HorizontalAlign="Center">
                      <asp:TableRow>
                          <asp:TableCell>
                              <asp:Label ID="Confirmation" runat="server" Text="Message Successfullly Sent!" ForeColor="Green" Font-Bold="true"></asp:Label>
                          </asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>

              </div>
              <!-- Grid column -->

              <hr class="clearfix w-100 d-md-none pb-3">

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
<%--              <div class="col-md-3 mb-md-0 mb-3">

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

           <%-- </div>--%>
            <!-- Grid row -->

    <%--      </div>--%>
          <!-- Footer Links -->

          <!-- Copyright -->
          <%--<div class="footer-copyright text-center py-3">© 2020 Copyright:
            <a href="http://cybercity-dev.us-east-1.elasticbeanstalk.com/HomePage.aspx"> Cyber Day</a>
          </div>--%>
          <!-- Copyright -->

       
        <!-- Footer -->


</asp:Content>
