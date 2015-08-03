<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true" CodeBehind="NovoUsuario.aspx.cs" Inherits="IMJWeb.Cadastro.NovoUsuario" EnableViewStateMac="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type="text"]
        {
        	width: 70ex
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gerenciar Usuário
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="server">

    <fieldset>
        <legend>Inserir usuário</legend>
        
        <asp:ObjectDataSource ID="UsuarioDS" runat="server" 
            DataObjectTypeName="IMJWeb.Servico.Usuario.UsuarioTO" 
            DeleteMethod="ExcluirUsuario" InsertMethod="InserirUsuario" 
            SelectMethod="ObterUsuarios" TypeName="IMJWeb.Servico.Usuario.ServicoUsuario" 
            UpdateMethod="AtualizarUsuario"></asp:ObjectDataSource>
        
        <asp:DetailsView ID="DetailsViewUsuarios" runat="server" AutoGenerateRows="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="UsuarioDS" ForeColor="Black" GridLines="Vertical" 
            Height="50px" Width="125px">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <Fields>
                <asp:CommandField CancelText="Cancelar" DeleteText="Excluir" EditText="Editar" 
                    InsertText="Inserir" NewText="Novo" SelectText="Escolher" 
                    ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" 
                    UpdateText="Atualizar" />
                <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="EMail" HeaderText="E-Mail" SortExpression="EMail" />
                <asp:BoundField DataField="Tabela" HeaderText="Tabela" SortExpression="Tabela" />
                <asp:BoundField DataField="IMJ_IDPessoa" 
                    HeaderText="Código no sistema da empresa" SortExpression="IMJ_IDPessoa" />
                <asp:CheckBoxField DataField="Administrador" HeaderText="Administrador" 
                    Text="Administrador" />
            </Fields>
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        <br />
        <h3>Legenda</h3>
        <dl>
            <dt>Tabela 1</dt>
            <dd>Varejo</dd>
            
            <dt>Tabela 2</dt>
            <dd>Consignado</dd>
            
            <dt>Tabela 3</dt>
            <dd>Atacado</dd>
            
            <dt>Tabela 4</dt>
            <dd>Alto-Atacado</dd>
        </dl>

    </fieldset>        
    
</asp:Content>
