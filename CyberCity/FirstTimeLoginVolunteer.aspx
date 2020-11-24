<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstTimeLoginVolunteer.aspx.cs" Inherits="CyberCity.FirstTimeLoginVolunteer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                        <h4>First Time Volunteer Login</h4>              
                    </asp:TableCell>
                </asp:TableRow>
                <%-- Gender and Phone --%>
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
                                    <asp:RequiredFieldValidator ID="RFVGender" runat="server" ControlToValidate="ddlGender" InitialValue="0" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtVolunteerPhone" runat="server" placeholder="Phone Number" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVPhone" runat="server" Text="Required Field" Font-Bold="true" ForeColor="Red" ControlToValidate="txtVolunteerPhone" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <%-- Shirt size and Lunch --%>
                <asp:TableRow HorizontalAlign="Center" CssClass="cellPadding">
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
                                  <asp:RequiredFieldValidator ID="RFVShirtSize" runat="server" ControlToValidate="ddlShirtSize" InitialValue="0" Text="Required Field" ForeColor="Red" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                        <div class="form-group form-control">
                            <asp:Label ID="Label1" runat="server" Text="Lunch?"></asp:Label>&nbsp;
                            <asp:CheckBox ID="chkLunch" runat="server"/>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <%-- Update Button --%>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <div class="form-group">
                             <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnUpdate" runat="server" Text="Update Information" OnClick="btnUpdate_Click" />
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        </div>
    </form>
</body>
</html>
