<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WebUI.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Slice of Pie | Sign up</title>
    <link rel="stylesheet" type="text/css" href="style/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="signupMain">
        <table border="0">
            <tr>
                <td><label> Full Name: </label></td>
                <td><asp:TextBox ID="fullNameSB" runat="server" /></td>
            </tr>
            <tr>
                <td><label> Username: </label></td>
                <td><asp:TextBox ID="usernameSB" runat="server" /></td>
            </tr>
            <tr>
                <td><label> Password: </label></td>
                <td><asp:TextBox ID="passwordSB" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td><label> Re-type password: </label></td>
                <td><asp:TextBox ID="retypePasswordSB" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="signupConfirmButton" runat="server" OnClick="SignUp" Text="Sign Up" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
