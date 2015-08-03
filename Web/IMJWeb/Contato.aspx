<%@ Page Title="Indústria Mineira de Joias - Fale Conosco" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="IMJWeb.Contato" %>
<%@ Register src="Controles/LblTextBox.ascx" tagname="LblTextBox" tagprefix="imj" %>

<asp:Content ID="PreHeader" ContentPlaceHolderID="prehead" runat="server">
    <meta name="description" content="Contato com a Indústria Mineira de Joia" />
</asp:Content>

<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Abas.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Estilos/Formularios.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="Scripts/Abas.js" type="text/javascript" charset="utf-8"></script>
    <script src="Scripts/Comunicacao.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" defer="defer">
        jQuery.comunicar.padrao.raiz = '<%= ResolveUrl("~/") %>';
        jQuery.comunicar.padrao.categoria = 'FaleConosco';
    </script>
</asp:Content>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="server">
    Fale Conosco
</asp:Content>

<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="server">
    
    <ul id="abas" style="position:absolute;bottom:0px;left:25%;right:25%;min-width: 500px;">
        <li>
            <div>
                <span>Fazer Pedidos</span>
            </div>
            <div class="formulario pj" id="formularioPedido">
                <input type="hidden" name="Categoria" value="Pedido" />
                <imj:LblTextBox ID="pedidoNome" Texto="Nome" runat="server" />
                <imj:LblTextBox ID="pedidoEMail" Texto="E-Mail" runat="server" />
                <imj:LblTextBox ID="pedidoTelefone" Texto="Telefone" runat="server" />
                <label for="pedido">Pedido:</label>
                <textarea id="pedido" name="pedido"></textarea>
                <div class="botoes">
                    <button type="button" class="enviar">Enviar</button>
                </div>
            </div>
        </li>
        <li>
            <div>
                <span>Dúvidas</span>
            </div>
            <div class="formulario pj" id="formularioDuvidas">
                <input type="hidden" name="Categoria" value="Duvida" />
                <imj:LblTextBox ID="LblTextBox1" Texto="Nome" runat="server" />
                <imj:LblTextBox ID="LblTextBox2" Texto="E-Mail" runat="server" />
                <imj:LblTextBox ID="LblTextBox3" Texto="Telefone" runat="server" />
                <label for="duvida">Dúvida:</label>
                <textarea id="duvida" name="duvida"></textarea>
                <div class="botoes">
                    <button type="button" class="enviar">Enviar</button>
                </div>
            </div>
        </li>
        <li>
            <div>
                <span>Sugestões</span>
            </div>
            <div class="formulario pj" id="Div2">
                <input type="hidden" name="Categoria" value="Sugestao" />
                <imj:LblTextBox ID="LblTextBox4" Texto="Nome" runat="server" />
                <imj:LblTextBox ID="LblTextBox5" Texto="E-Mail" runat="server" />
                <imj:LblTextBox ID="LblTextBox6" Texto="Telefone" runat="server" />
                <label for="sugestao">Sugestão:</label>
                <textarea id="sugestao" name="sugestao"></textarea>
                <div class="botoes">
                    <button type="button" class="enviar">Enviar</button>
                </div>
            </div>
        </li>        
        <li>
            <div>
                <span>Reclamações</span>
            </div>
            <div class="formulario pj" id="Div3">
                <input type="hidden" name="Categoria" value="Reclamacao" />
                <imj:LblTextBox ID="LblTextBox7" Texto="Nome" runat="server" />
                <imj:LblTextBox ID="LblTextBox8" Texto="E-Mail" runat="server" />
                <imj:LblTextBox ID="LblTextBox9" Texto="Telefone" runat="server" />
                <label for="reclamacao">Reclamação:</label>
                <textarea id="reclamacao" name="reclamacao"></textarea>
                <div class="botoes">
                    <button type="button" class="enviar">Enviar</button>
                </div>
            </div>
        </li>
        <li>
            <div>
                <span>Troca/Devolução</span>
            </div>
            <div class="formulario pj" id="Div4">
                <input type="hidden" name="Categoria" value="TrocaDevolucao" />
                <imj:LblTextBox ID="LblTextBox10" Texto="Nome" runat="server" />
                <imj:LblTextBox ID="LblTextBox11" Texto="E-Mail" runat="server" />
                <imj:LblTextBox ID="LblTextBox12" Texto="Telefone" runat="server" />
                <label for="solicitacao">Solicitação:</label>
                <textarea id="solicitacao" name="solicitacao"></textarea>
                <div class="botoes">
                    <button type="button" class="enviar">Enviar</button>
                </div>
            </div>
        </li>
    </ul>
    
    <script type="text/javascript">
        $(function () { $("#abas").abas(); });
    </script>

</asp:Content>
