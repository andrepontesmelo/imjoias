<%@ Page Language="C#" MasterPageFile="~/Interno/Interno.master" CodeFile="Default.aspx.cs" Inherits="Default_aspx" Title="Untitled Page" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="../Interface/Login.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteúdo" Runat="Server">
    &nbsp;<uc1:Login ID="Login1" runat="server" />
</asp:Content>

