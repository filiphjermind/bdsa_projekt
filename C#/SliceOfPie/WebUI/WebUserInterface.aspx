<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebUserInterface.aspx.cs" Inherits="WebUI.WebUserInterface" %>

<!DOCTYPE html>

<%--<script runat="server">

    void Button1_Click(object sender, EventArgs e)
    {
        // Do some other processing...

        StringBuilder sb = new StringBuilder();
        sb.Append("<script>");
        sb.Append("window.open('SaveDocumentConfirmation.aspx', '', 'resizable=no, width=500px, height=300px');");
        sb.Append("</scri");
        sb.Append("pt>");

        Page.RegisterStartupScript("test", sb.ToString());
    }

</script>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style/style.css" />
    <title>Slice of Pie Web Client</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="userBar">
            <asp:HiddenField ID="hiddenUsername" runat="server" Value="" />
            <asp:HiddenField ID="hiddenPassword" runat="server" Value="" />
            <label>Username: </label><asp:TextBox ID="userBox" runat="server" />
            <label>Password: </label><asp:TextBox ID="passwordBox" runat="server" TextMode="Password" />
            <asp:Button ID="loginButton" runat="server" OnClick="Login" Text="Login" />
        </div>
        
        <div id="menuBar">
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false" />
            <%--<asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1"
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
            <asp:HiddenField ID="newDocumentHidden" runat="server" Value="empty" />
            <asp:Button ID="newDocButton" runat="server" OnClick="NewDocument" Text="New Document" />
            <asp:Button ID="saveDocButton" runat="server" Text="Save Document" />
            <asp:Button ID="openDocButton" runat="server" OnClick="OpenDocument" Text="Open Document" />
            <asp:Button id="Button1" onclick="Button1_Click" runat="server" Text="Go!" />
            
            <%--<asp:Button ID="showHTMLButton" runat="server" Text="Show HTML" OnClientClick="Encode()" />--%>
        </div>
        <div id="fileBox">
            File: 
            <asp:TextBox ID="fileNameBox" runat="server" Width="700px" />
            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="Save" CssClass="rightButton" />
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteDocument" CssClass="rightButton" />
        </div>
        <div id="fileExplorer">
            <asp:Button ID="button" runat="server" OnClick="Populate" Text="Get Files" />
            <asp:TreeView ID="FileTree" runat="server" OnSelectedNodeChanged="OpenDocumentFromFileTree"></asp:TreeView>
        </div>
        <div id="textField">
            <asp:TextBox ID="textArea" TextMode="MultiLine" runat="server" Width="744px" Height="964px" />
        </div>
    </div>
    </form>
</body>
</html>
