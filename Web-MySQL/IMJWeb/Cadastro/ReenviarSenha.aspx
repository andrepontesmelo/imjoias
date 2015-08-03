<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="ReenviarSenha.aspx.cs" Inherits="IMJWeb.Cadastro.ReenviarSenha" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Titulo" runat="server">
    Reenvio de Senha
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Conteudo" runat="server">
    <h3>Reenvio de Senha</h3>
    <p>
        A senha do(a) usuário(a) <strong><span class="nomeUsuario"><%= Usuario.Nome %></strong></span>
        será novamente gerada aleatoriamente e encaminhada para o e-mail <strong><span><%= Usuario.EMail %></span></strong>.
    </p>
    <p>
        <asp:LinkButton ID="Reenviar" runat="server" Text="Confirmar Reenvio de Senha" OnClick="ConfirmarReenvio" />
    </p>
</asp:Content>
