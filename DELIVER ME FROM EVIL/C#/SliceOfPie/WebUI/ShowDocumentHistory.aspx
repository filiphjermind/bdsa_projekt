<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDocumentHistory.aspx.cs" Inherits="WebUI.ShowDocumentHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <table border="1">
            <tr>
                <th>ID</th> <th>Owner</th> <th>File</th> <th>Last changed</th>
            </tr>
            <asp:Label ID="historyRow" runat="server" Text="" />
        </table>
    </div>
    </form>
</body>
</html>
