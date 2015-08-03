<%@ Page Title="Indústria Mineira de Joias - Empresa" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IMJWeb.Empresa" %>

<asp:Content ID="PreHeader" ContentPlaceHolderID="prehead" runat="server">
    <meta name="description" content="Sobre a Indústria Mineira de Joia" />
</asp:Content>

<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilos/Empresa.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="Empresa.js"></script>
<!--[if IE 6]>
    <script type="text/javascript" src="Empresa-IE6.js"></script>
<![endif]-->
</asp:Content>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="server">
    Empresa
</asp:Content>

<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="colunaPequena">
        <p>
            A Indústria Mineira de Joias emociona a vida das pessoas desde maio de 1964.
            Fundada em Belo Horizonte, por filhos e genro de um ex-garimpeiro, a empresa se
            destacou e tornou-se uma tradição no mercado joalheiro.
        </p>
        <p>
            Sempre fiel a suas origens, a empresa só trabalha com matéria-prima de qualidade
            e se especializou na fabricação de joias em ouro 18 quilates, procurando sempre
            lançar modelos em sintonia com o mercado.
        </p>
    </div>
    <div class="colunaGrande">
        <img class="grande" id="ouro" src="../Imagens/Empresa/Ouro.jpg" alt="Ouro" />
        <div class="dupla">
            <img class="pequena" id="loja1" src="../Imagens/Empresa/Loja1.jpg" alt="Foto da loja" />
            <img class="pequena" id="loja2" src="../Imagens/Empresa/Loja2.jpg" alt="Foto da loja" />
        </div>
    </div>
</asp:Content>
