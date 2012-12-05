<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebUserInterface.aspx.cs" Inherits="WebUI.WebUserInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style/style.css" />
    <title>Slice of Pie Web Client</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="fileExplorer"></div>
        <div id="textField">
            <asp:TextBox ID="textArea" TextMode="MultiLine" runat="server" Width="690px" />
        </div>
    </div>
    </form>
</body>
</html>
