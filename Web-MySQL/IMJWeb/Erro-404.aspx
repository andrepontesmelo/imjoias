<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="Erro-404.aspx.cs" Inherits="IMJWeb.Erro_404" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Titulo" runat="server">Página não encontrada</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="duasColunas">
        <div class="primeiraMaior">
            <h3>Erro 404 - Página não encontrada</h3>
            <p>O endereço que você visitou não existe.  Pode ser que ele tenha sido removido.</p>
        </div>
        <div class="segundaMenor">
            <h3>Links úteis</h3>
            <ul>
                <li><a href="http://www.imjoias.com.br/">Página inicial</a></li>
                <li><a href="http://www.imjoias.com.br/Empresa/">Sobre a empresa</a></li>
                <li><a href="http://www.imjoias.com.br/Catalogo/">Catálogo de mercadorias</a></li>
                <li><a href="http://www.imjoias.com.br/Contato.aspx">Fale conosco</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
