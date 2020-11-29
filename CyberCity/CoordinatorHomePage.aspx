<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordinatorHomePage.aspx.cs" Inherits="CyberCity.CoordinatorHomePage" %>
<asp:Content ID="CoordinatorHomePage" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/GridView.css" rel="stylesheet" />

    <br />

    <div class='tableauPlaceholder' id='viz1606161827221' style='position: relative; margin: auto; width:50%;'><noscript><a href='#'><img alt=' ' 
        src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Up&#47;UpdatedCoordinatorDashboard&#47;CoordinatorDashboard&#47;1_rss.png' 
        style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' 
        value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='site_root' 
        value='' /><param name='name' value='UpdatedCoordinatorDashboard&#47;CoordinatorDashboard' /><param name='tabs' 
        value='no' /><param name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Up&#47;UpdatedCoordinatorDashboard&#47;CoordinatorDashboard&#47;1.png' /> <param 
        name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /><param 
        name='language' value='en' /><param name='filter' value='publish=yes' /></object></div><script type='text/javascript'>var divElement = document.getElementById('viz1606161827221'); var vizElement = divElement.getElementsByTagName('object')[0];
        if (divElement.offsetWidth > 800) { vizElement.style.width = '1000px'; vizElement.style.height = '827px'; } else if (divElement.offsetWidth > 500) { vizElement.style.width = '1000px'; vizElement.style.height = '827px'; }
        else { vizElement.style.width = '100%'; vizElement.style.height = '1027px'; } var scriptElement = document.createElement('script'); scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js'; vizElement.parentNode.insertBefore(scriptElement, vizElement); </script>

    <div class="row">
        <div class="col-md-4">
            <h2>Download Files</h2>
            <p>
                Click one of the following options to download an excel file:
            <p>
                <asp:Button ID="btnStudentRoster" runat="server" Text="Student Roster" CssClass="btn btn-default"/>
                &nbsp;
                <asp:Button ID="btnProgramSchedule" runat="server" Text="Program Schedule" CssClass="btn btn-default" />
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

</asp:Content>
