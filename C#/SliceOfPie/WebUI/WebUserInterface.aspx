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
        <div id="menuBar">
            <asp:Menu ID="mainMenu" runat="server" StaticDisplayLevels="3" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="File"></asp:MenuItem>
                    <asp:MenuItem Text="Document"></asp:MenuItem>
                    <asp:MenuItem Text="User"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </div>
        <div id="fileExplorer"></div>
        <div id="textField">
            <asp:TextBox ID="textArea" TextMode="MultiLine" runat="server" Width="744px" Height="994px"/>
        </div>
    </div>
    </form>
</body>
</html>
