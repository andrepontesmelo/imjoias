<%@ Page Title="Indústria Mineira de Jóias - Catálogo" Language="C#" MasterPageFile="~/Leiaute.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IMJWeb.Catalogo.Default" %>

<asp:Content ID="PreHeader" ContentPlaceHolderID="prehead" runat="server">
    <meta name="description" content="Catálogo de <%= Visao.Catalogo.Nome.ToLower() %> da Indústria Mineira de Joias" />
</asp:Content>

<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilos/RodapeSubMenu.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Estilos/RodapeProcura.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Estilos/Catalogo.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="<%= ResolveUrl("~/Scripts/jquery.meio.mask.min.js") %>" type="text/javascript" charset="utf-8"></script>
    <script src="Catalogo.js" type="text/javascript"></script>
    <script src="Mercadoria.js" type="text/javascript"></script>
<!--[if IE 6]>
    <script src="Mercadoria-IE6.js" type="text/javascript"></script>
    <script src="Catalogo-IE6.js" type="text/javascript"></script>
<![endif]-->
    <script src="Miniatura.js?v=6" type="text/javascript"></script>
<!--[if IE 6]>
    <script src="Miniatura-IE6.js" type="text/javascript"></script>
<![endif]-->
<!--[if IE 7]>
    <script src="Miniatura-IE7.js" type="text/javascript"></script>
<![endif]-->
</asp:Content>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="server">Catálogo</asp:Content>

<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="server">
    <h3><%= Visao.Catalogo.Nome %></h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Services>
            <%--<asp:ServiceReference Path="~/Catalogo/Mercadoria.svc" />--%>
            <asp:ServiceReference Path="~/Catalogo/Mercadoria.asmx" />
        </Services>
    </asp:ScriptManager>
    <asp:PlaceHolder runat="server" ID="phMercadorias">
        <div class="duasColunas">
            <div class="primeiraMaior" id="colunaMercadoria">
                <h4><%= Visao.Mercadoria.Referencia %></h4>
                <img id="joiaImagem" src="Foto.ashx?ref=<%= Visao.Mercadoria.Referencia.ValorNumerico %>" alt="<%= Visao.Mercadoria.Referencia %>" />
                <ul id="joiaDados">
                    <li id="joiaReferencia"><span>Referência <span id="joiaValorReferencia"><%= Visao.Mercadoria.Referencia%></span></span></li>
                    <li id="joiaDescricao">- <span id="joiaValorDescricao"><%= Visao.Mercadoria.Descricao %></span></li>
                    <% if (User.Identity.IsAuthenticated)
                       { %>
                    <li id="joiaPeso" <%= !Visao.Mercadoria.Peso.HasValue ? "style='display: none'" : "" %>>- <span>Peso <span id="joiaValorPeso"><%= Visao.ObterPesoMercadoria()%></span></span></li>
                    <li id="joiaIndice">- <span>Índice <span id="joiaValorIndice"><%= Visao.ObterIndiceMercadoria()%></span></span></li>
                    <%  } %>
                </ul>
                <a href="<%= GerarParametros(Visao.Catalogo.IDCatalogo, Visao.IndiceMercadoria - 1) %>" id="joiaAnterior" class="navegador">Joia anterior</a>
                <a href="<%= GerarParametros(Visao.Catalogo.IDCatalogo, Visao.IndiceMercadoria + 1) %>" id="joiaPosterior" class="navegador">Próxima joia</a>
            </div>
            <div class="segundaMenor">
                <h4>Catálogo</h4>
                <ul id="listaJoias">
                    <asp:PlaceHolder ID="phListaJoias" runat="server" />
                </ul>
                <asp:PlaceHolder runat="server" ID="phInformativoCadastro">
                    <div id="informativoCadastro">
                        <asp:HyperLink NavigateUrl="~/Cadastro/" runat="server"><strong>Cadastre-se</strong></asp:HyperLink> para ter acesso a todas as joias do catálogo.
                    </div>
                </asp:PlaceHolder>
                <a href="<%= GerarParametrosScrollMiniaturasCima() %>" id="miniaturasCima" class="navegador">Joias anteriores</a>
                <a href="<%= GerarParametrosScrollMiniaturasBaixo() %>" id="miniaturasBaixo" class="navegador">Próximas joias</a>
            </div>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="phSemMercadorias" Visible="false">
        <div class="mensagemCentral"><span>Este catálogo está indisponível no momento.</span></div>
    </asp:PlaceHolder>
    <div id="rodapeSubMenu">
        <div id="rodapeSubMenuEsquerda"></div>
        <div id="rodapeSubMenuCentro">
            <h2>Categorias</h2>
            <ul id="subMenu">
                <asp:Repeater ID="repCatalogo" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="?id=<%# Visao.ObterChave(Container.DataItem) %>" <%# Visao.CatalogoAtual(Container.DataItem) ? "disabled='disabled'" : "" %>>
                                <%# Visao.ObterNome(Container.DataItem) %>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div id="rodapeSubMenuDireita"></div>
    </div>
    <div id="rodapeProcura">
        <div id="procuraEsquerda"></div>
        <div id="procuraCentro">
            <label for="txtReferencia">Encontre pela referência:</label>
            <input class="txtReferencia" id="txtReferencia" type="text" name="ref" />
        </div>
        <div id="procuraDireita"></div>
    </div>
    <script type="text/javascript" defer="defer">
        Catalogo.iniciarEstado(<%= Visao.Catalogo.IDCatalogo %>, <%= Visao.IndiceMercadoria %>, <%= Visao.MercadoriasCatalogo.Count %>);
    </script>
</asp:Content>
