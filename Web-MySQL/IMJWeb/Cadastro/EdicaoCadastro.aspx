<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="EdicaoCadastro.aspx.cs" Inherits="IMJWeb.Cadastro.EdicaoCadastro" EnableViewStateMac="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilos/EdicaoCadastro.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Cadastro
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="server">

    <div class="duasColunas">
        <div class="primeira">
            <p>Mantenha seu cadastro atualizado.</p>
            <fieldset>
                <legend>Contato</legend>
                <p>
                    <label for="email">E-mail:</label>
                    <span id="email"><asp:Literal runat="server" ID="EMail"/></span>
                </p>
            </fieldset>
        </div>
        <div class="segunda">
            <fieldset>
                <legend>Alteração de senha</legend>
                <p>
                    <asp:Label runat="server" AssociatedControlID="SenhaAtual">Senha atual:</asp:Label>
                    <asp:TextBox runat="server" TextMode="Password" ID="SenhaAtual" />
                </p>
                <p>
                    <asp:Label runat="server" AssociatedControlID="NovaSenha">Nova senha:</asp:Label>
                    <asp:TextBox runat="server" TextMode="Password" ID="NovaSenha" />
                </p>
                <p>
                    <asp:Label runat="server" AssociatedControlID="Confirmacao">Confirmação:</asp:Label>
                    <asp:TextBox runat="server" TextMode="Password" ID="Confirmacao" />
                </p>
                <asp:Button runat="server" Text="Alterar" OnClick="AlterarSenha" />
            </fieldset>
        </div>
    </div>
    
</asp:Content>
