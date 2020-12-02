<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CyberCity.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="AboutStyle.css" rel="stylesheet" />

    <header>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
</header>

    <div class="about-section">
        <div class="inner-container">
            <h1>About Cyber Day</h1>
            <p class="text">
                Do you or your child have an interest in programing?
Cyber Day is an opportunity to engage middle school students in animation
programming and other computer technologies. Students will attend various technology events
lead by our very own JMU Computer Information System students. Students attending this event 
will be matched up with a JMU mentor to guide them through the development process and watch their programming 
knowledge grow from year to year.

            </p>
            <div class="skills">
                <asp:LinkButton runat="server" OnClick="Unnamed_Click"> Contact Us</asp:LinkButton>
                <asp:LinkButton runat="server" OnClick="Unnamed_Click1"> Create Account</asp:LinkButton>
                <asp:LinkButton runat="server" OnClick="Unnamed_Click2"> Login</asp:LinkButton>
            </div>
        </div>
    </div>


</asp:Content>
