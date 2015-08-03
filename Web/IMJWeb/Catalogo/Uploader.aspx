<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploader.aspx.cs" Inherits="IMJWeb.Catalogo.Uploader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:fileupload ID="Fileupload1" runat="server"></asp:fileupload>
        <table>
            <tr><td>Mercadoria:</td><td><asp:TextBox ID="IDMercadoria" runat="server"></asp:TextBox></td></tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="AoClicar" />
    </div>
    </form>
</body>
</html>
