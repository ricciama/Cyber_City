<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CyberCity._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>JMU Presents: CyberCity- </h1>
        <p>“The JMU mission has always been to educate leaders. Our students exemplify that mission by not only being leaders in their academic studies, but also by leading these visiting young people to promising technology careers.” </p>
        
        <p><a href="https://www.jmu.edu/cob/cis/about/cyberday.shtml" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
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
