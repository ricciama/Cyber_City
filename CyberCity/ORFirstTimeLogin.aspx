<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ORFirstTimeLogin.aspx.cs" Inherits="CyberCity.ORFirstTimeLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/CreatingEntity.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style=" background-color: #450084; height:1500px;">
    <br />
    <br />
    <asp:Panel ID="OrgRepFirstTimeLogin" runat="server" BorderColor="#cccccc" BackColor="White" BorderStyle="Solid" style="width:50%;margin-left:auto;margin-right:auto;">
        <br />
        <br />
        <asp:Table ID="tblOrgRepFirstTimeLogin" runat="server" HorizontalAlign="Center" CellPadding="50" CellSpacing="50">

            <asp:TableRow HorizontalAlign="Center" >
                <asp:TableCell ColumnSpan="2">
                    <img width="100" src="Images/OrgRepAvatar.png"/>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">                    
                    <h4>Organizational Representative First Time Login</h4>              
                </asp:TableCell>
            </asp:TableRow>
            <%-- Phone --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtOrgRepPhone" runat="server"  width ="238" placeholder="Phone Number (### - ### - ####)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPhone" runat="server" Text="Required Field" ForeColor="Red" ControlToValidate="txtOrgRepPhone" Font-Bold="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Lunch --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding">
                    <div class="form-group form-control">
                        <asp:Label ID="lblLunch" runat="server" Text="Lunch?" Font-Bold="True"></asp:Label> &nbsp;                                                                   
                        <asp:CheckBox ID="chbxLunch" runat="server"/>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Grade Taught --%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" CssClass="cellPadding" ColumnSpan="2">
                    <asp:Label ID="lblGrade" runat="server" Text="Grades Taught" ></asp:Label>
                    <div class="form-group">                   
                        <asp:CheckBox ID="chkElementary" runat="server" Text="&nbsp; Elementary"/> &nbsp;
                        <asp:CheckBox ID="chkSixth" runat="server" Text="&nbsp Sixth" /> &nbsp;
                        <asp:CheckBox ID="chkSeventh" runat="server" Text="&nbsp Seventh" /> &nbsp;
                        <asp:CheckBox ID="chkEight" runat="server" Text="&nbsp Eight" /> &nbsp;
                        <asp:CheckBox ID="chkHighSchool" runat="server" Text="&nbsp Highschool" /> &nbsp;
                        <asp:CheckBox ID="chkNone" runat="server" Text="&nbsp None" /> &nbsp;
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <%-- Register Button --%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <div class="form-group">
                         <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnUpdate" runat="server" Text="Update Information" OnClick="btnUpdate_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
          <br />
        <asp:Table ID="tblConfirmation" runat="server" Visible="false" HorizontalAlign="center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="confirmationlbl" runat="server" Text="Organizational Representative Created!" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>
        </div>
    </form>
</body>
</html>
