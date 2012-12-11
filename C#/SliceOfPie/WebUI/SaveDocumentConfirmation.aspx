<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveDocumentConfirmation.aspx.cs" Inherits="WebUI.SaveDocumentConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm save document</title>
    <link rel="stylesheet" type="text/css" href="style/confirmationStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <p>Please enter the path and filename of the document you wish to save.</p>
        <table border="1">
            <tr>
                <td><label class="label">Path: </label></td> <td><asp:TextBox runat="server" ID="pathBox" Width="300px"/></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="confirmSaveButton" runat="server" Text="Save" OnClick="SaveNewDocument" CssClass="button" />
                    <asp:Button ID="cancelSaveButton" runat="server" Text="Cancel" CssClass="button" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
