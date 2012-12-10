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
            <%--<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false" />
            <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1"
                DynamicHorizontalOffset="0" Font-Names="Verdana" Font-Size="13px"
                ForeColor="White" Orientation="Horizontal"
                StaticSubMenuIndent="10px" Font-Bold="True" Height="30px">

                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="5px" Height="20px" BackColor="#433A4F" />
                <DynamicHoverStyle BackColor="#433A4F" ForeColor="White" Font-Underline="true" />
                <DynamicMenuStyle BackColor="#433A4F" />
                <DynamicSelectedStyle BackColor="#433A4F" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#433A4F" ForeColor="White" Font-Underline="true" />
            </asp:Menu>--%>
            <asp:Button ID="newDocButton" runat="server" OnClick="NewDocument" Text="New Document" />
            <asp:Button ID="saveDocButton" runat="server" OnClick="SaveDocument" Text="Save Document" />
            <asp:Button ID="openDocButton" runat="server" OnClick="OpenDocument" Text="Open Document" />
        </div>
        <div id="fileExplorer">
            <asp:Button ID="button" runat="server" OnClick="Populate" />
            <asp:TreeView ID="FileTree" runat="server" OnSelectedNodeChanged="Click"></asp:TreeView>
        </div>
        <div id="textField">
            <asp:TextBox ID="textArea" TextMode="MultiLine" runat="server" Width="744px" Height="994px" />
        </div>
    </div>
    </form>
</body>
</html>
