<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="Modelo-01.aspx.cs" Inherits="IMJWeb.Capa.Modelo_01" %>

<asp:Content ID="PreHeader" ContentPlaceHolderID="prehead" runat="server">
    <meta name="description" content="Desde maio de 1964, a empresa se destacou e tornou-se uma tradição no mercado joalheiro com vendas no atacado." />
    <meta name="keywords" content="joia,imj,atacado,pérola,anel,brilhante,aliança,brinco,cordão,crucifixo,gargantilha,pingente,pulseira" lang="pt-br" />
    <meta name="keywords" content="jewels,jewel,brazillian" lang="en-us" />
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Capa-<%= this.Tema.ToString() %>.css" rel="stylesheet" type="text/css" media="screen" />
<!--[if IE 6]>
    <script src="Capa-IE6.js" type="text/javascript"></script>
<![endif]-->
    <script src="Capa2.js" type="text/javascript" defer="defer"></script>
</asp:Content>

<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="server">
    <div id="plataforma">
        <img id="luz" src="Imagens/Capa/<%= this.Tema.ToString() %>/Luz.jpg" height="100%" width="100%" alt=""/>
    </div>
    <div id="areaJoia">
        <a href="Catalogo/?ref=502.389.01.100">
            <img id="joia" src="Imagens/Capa/50238901100-peq.png" alt="Jóia exposta" title="Anel Ref. 502.389.01.100" />
        </a>
    </div>
    <script type="text/javascript">
        tema = "<%= this.Tema.ToString() %>";
    </script>
</asp:Content>
