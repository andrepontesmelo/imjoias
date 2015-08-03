<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Status-Site.aspx.cs" Inherits="IMJWeb.Status_Site" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Caminho de escrita</td>
                <td><%= IMJWeb.Global.CaminhoEscrita %></td>
            </tr>
            <tr>
                <td>Teste de escrita</td>
                <td><%= TesteDeEscrita %></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
