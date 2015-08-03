<%@ Page Title="Indústria Mineira de Jóias - Cadastro" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="IMJWeb.Cadastro" %>
<%@ Register src="Controles/LblTextBox.ascx" tagname="LblTextBox" tagprefix="imj" %>

<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Abas.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Estilos/Cadastro.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="Scripts/Abas.js" type="text/javascript" charset="utf-8"></script>
    <script src="Scripts/Comunicacao.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" defer="defer">
        jQuery.comunicar.padrao.raiz = '<%= ResolveUrl("~/") %>';
    </script>
</asp:Content>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="server">
    Cadastro
</asp:Content>

<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="server">
    <p>
        O cadastro é necessário para se ter acesso a todo o catálogo de produtos da Indústria Mineira de Jóias e para efetuar pedidos.
    </p>
    <ul id="abas" style="position:absolute;bottom:0px;left:25%;right:25%;">
        <li>
            <div>
                <span>Pessoa Jurídica</span>
            </div>
            <div class="formulario pj" id="formularioPJ">
                <imj:LblTextBox ID="pjRazaoSocial" Texto="Razão Social" runat="server" />
                <imj:LblTextBox ID="pjLoja" Texto="Loja" runat="server" />
                <imj:LblTextBox ID="pjEndereco" Texto="Endereço" runat="server" />
                <imj:LblTextBox ID="pjBairro" Texto="Bairro" runat="server" />
                <imj:LblTextBox ID="pjCEP" Texto="CEP" runat="server" />
                <imj:LblTextBox ID="pjCidade" Texto="Cidade" runat="server" />
                <imj:LblTextBox ID="pjEstado" Texto="Estado" runat="server" />
                <imj:LblTextBox ID="pjCNPJ" Texto="CNPJ" runat="server" />
                <imj:LblTextBox ID="pjInscEstadual" Texto="Insc. Estadual" runat="server" />
                <imj:LblTextBox ID="pjTelefones" Texto="Telefones" runat="server" />
                <imj:LblTextBox ID="pjEmail" Texto="E-Mail" runat="server" />
                <div class="referencias">
                    <p class="grupo">Referências:</p>
                    <div class="contato">
                        <imj:LblTextBox ID="pjEmpresa1" Texto="Empresa 1" runat="server" />
                        <imj:LblTextBox ID="pjTelEmpresa1" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="pjEmpresa2" Texto="Empresa 2" runat="server" />
                        <imj:LblTextBox ID="pjTelEmpresa2" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="pjEmpresa3" Texto="Empresa 3" runat="server" />
                        <imj:LblTextBox ID="pjTelEmpresa3" Texto="Telefone" runat="server" />
                    </div>
                </div>
                <div class="botoes">
                    <button type="button" class="enviar">Enviar</button>
                </div>
            </div>
        </li>
        <li>
            <div>
                <span>Pessoa Física</span>
            </div>
            <div class="formulario pf">
                <imj:LblTextBox ID="LblTextBox1" Texto="Nome" runat="server" />
                <imj:LblTextBox ID="LblTextBox3" Texto="Endereço" runat="server" />
                <imj:LblTextBox ID="LblTextBox4" Texto="Bairro" runat="server" />
                <imj:LblTextBox ID="LblTextBox5" Texto="CEP" runat="server" />
                <imj:LblTextBox ID="LblTextBox6" Texto="Cidade" runat="server" />
                <imj:LblTextBox ID="LblTextBox7" Texto="Estado" runat="server" />
                <imj:LblTextBox ID="LblTextBox8" Texto="CPF" runat="server" />
                <imj:LblTextBox ID="LblTextBox9" Texto="Identidade" runat="server" />
                <imj:LblTextBox ID="LblTextBox18" Texto="Filiação" runat="server" />
                <imj:LblTextBox ID="LblTextBox2" Texto="Data nasc." runat="server" />
                <imj:LblTextBox ID="LblTextBox10" Texto="Telefones" runat="server" />
                <imj:LblTextBox ID="LblTextBox11" Texto="E-Mail" runat="server" />
                <div class="referencias">
                    <p class="grupo">Referências:</p>
                    <div class="contato">
                        <imj:LblTextBox ID="LblTextBox12" Texto="Empresa 1" runat="server" />
                        <imj:LblTextBox ID="LblTextBox13" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="LblTextBox14" Texto="Empresa 2" runat="server" />
                        <imj:LblTextBox ID="LblTextBox15" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="LblTextBox16" Texto="Empresa 3" runat="server" />
                        <imj:LblTextBox ID="LblTextBox17" Texto="Telefone" runat="server" />
                    </div>
                </div>
                <label>Faço compras em:</label>
                <input type="radio" id="pfEmMeuNome" name="pfComprasEm" value="meu nome" /><label for="pfEmMeuNome">meu nome</label>
                <input type="radio" id="pfPelaEmpresa" name="pfComprasEm" value="nome da minha empresa" /><label for="pfPelaEmpresa">nome da minha empresa</label>
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
