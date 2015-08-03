<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="InstrucaoReenvioSenha.aspx.cs" Inherits="IMJWeb.Cadastro.InstrucaoReenvioSenha" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Titulo" runat="server">
    Reenvio de Senha
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="duasColunas">
        <div class="primeira">
            <h3>Reenvio de Senha</h3>
            <p>
                Foi enviado um e-mail com uma nova senha para o endereço <strong><span><%= Usuario.EMail %></span></strong>
                de <strong><span class="nomeUsuario"><%= Usuario.Nome %></span></strong>.
            </p>
            <h3>Orientações a serem passadas para o cliente</h3>
            <p>
                O e-mail foi enviado em nome de <strong><%= HttpUtility.HtmlEncode(IMJWeb.Servico.Comunicacao.Correio.Remetente) %></strong> neste momento.
                Caso o(a) cliente não receba o e-mail, certifique-se que o endereço cadastrado neste sistema está correto para
                <span class="nomeUsuario"><%= Usuario.Nome %></span>.  Caso esteja, peça para que o(a) cliente configure o seu leitor de e-mails para não
                filtrar e-mails provenientes de <%= IMJWeb.Servico.Comunicacao.Correio.Remetente %> como SPAM.
            </p>
            <p>
                Normalmente um e-mail é entregue ao seu destinatário em até dois minutos, mas em casos especiais, é possível que ele
                demore até 4 dias corridos.
            </p>
            <p>
                <asp:HyperLink runat="server" Text="Retornar ao Gerenciamento de Usuários" NavigateUrl="~/Cadastro/GerenciarUsuarios.aspx" />
            </p>
        </div>
        <div class="segunda">
            <h3>O que verificar caso a(o) cliente não receba o e-mail</h3>
            <ul>
                <li>O endereço <span><%= Usuario.EMail %></span> está correto?</li>
                <li>A caixa de entrada está cheia?</li>
                <li>Teria o e-mail caído na caixa de SPAM?</li>
                <li>Procure por e-mails provenientes de <%= HttpUtility.HtmlEncode(IMJWeb.Servico.Comunicacao.Correio.Remetente)%></li>
            </ul>
        </div>
    </div>
</asp:Content>
