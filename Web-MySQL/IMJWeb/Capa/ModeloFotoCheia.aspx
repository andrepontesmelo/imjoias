<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="ModeloFotoCheia.aspx.cs" Inherits="IMJWeb.Capa.ModeloFotoCheia" %>

<asp:Content ID="PreHeader" ContentPlaceHolderID="prehead" runat="server">
    <meta name="description" content="Desde maio de 1964, a empresa se destacou e tornou-se uma tradição no mercado joalheiro com vendas no atacado." />
    <meta name="keywords" content="joia,imj,atacado,pérola,anel,brilhante,aliança,brinco,cordão,crucifixo,gargantilha,pingente,pulseira" lang="pt-br" />
    <meta name="keywords" content="jewels,jewel,brazillian" lang="en-us" />
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Capa-FotoCheia.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="<%= CaminhoTema %>/Capa.css" rel="stylesheet" type="text/css" media="screen" />
<!--[if IE 6]>
    <script src="Capa/ModeloFotoCheia-IE6.js" type="text/javascript"></script>
<![endif]-->
</asp:Content>

<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="server">
    <asp:Image runat="server" ID="ImgCapa" />
    <script type="text/javascript">
        Leiaute.redimensionarConteudo = false;
        Leiaute.capa = {
            objImagem: $("#<%= ImgCapa.ClientID %>"),
            tamanhos: [1024, 800, 700, 550, 0],
            tamanhoAtual: 0,
            nome: "capa-1.jpg"
        };

        $(function () {
            function redimensionar() {
                var altura = $("#conteudo").height();
                var src;

                for (var i = 0; i < Leiaute.capa.tamanhos.length; i++) {
                    var tamanho = Leiaute.capa.tamanhos[i];

                    if (altura > tamanho) {
                        src = '<%= CaminhoTema %>/' + tamanho + '/' + Leiaute.capa.nome;
                        Leiaute.capa.tamanhoAtual = tamanho;
                        break;
                    }
                }

                if (Leiaute.capa.objImagem.attr("src") != src)
                    Leiaute.capa.objImagem.attr("src", src);
            }

            Leiaute.capa.redimensionar = redimensionar;

            Leiaute.capa.objImagem.bind("load", function () {
                if (Leiaute.capa.objImagem.outerWidth() > $("#conteudo").width())
                    $("#conteudo").addClass("curto");
                else
                    $("#conteudo").removeClass("curto");
            });

            redimensionar();
            $("#conteudo").bind("resize", redimensionar);

            if (!jQuery.browser.msie) {
                $("#rodape").css("opacity", .7);
            }
        });
    </script>
    <script type="text/javascript" src="<%= CaminhoTema %>/Capa.js"></script>
</asp:Content>
