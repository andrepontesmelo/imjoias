<%@ Page Title="" Language="C#" MasterPageFile="~/Leiaute.Master" AutoEventWireup="true"
    CodeBehind="GerenciarUsuarios.aspx.cs" Inherits="IMJWeb.Cadastro.GerenciarUsuarios"
    EnableViewStateMac="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gerenciar Usuários
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Conteudo" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <fieldset>
        <legend>Gerenciamento de usuários</legend>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridViewUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" DataSourceID="UsuarioDS" ForeColor="Black" GridLines="Vertical"
                    PageSize="50" DataKeyNames="IDUsuario">
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:CommandField CancelText="Cancelar" DeleteText="Excluir" EditText="Editar" InsertText="Inserir"
                            NewText="Novo" SelectText="Escolher" ShowEditButton="True" ShowHeader="True"
                            ShowDeleteButton="true" SortExpression="Administrador" UpdateText="Atualizar" />
                        <asp:BoundField DataField="IDUsuario" HeaderText="#" InsertVisible="False" SortExpression="IDUsuario"
                            ReadOnly="true" />
                        <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
                        <asp:TemplateField HeaderText="Senha">
                            <ItemTemplate>
                                ****
                            </ItemTemplate>
                            <EditItemTemplate>
                                <a href="ReenviarSenha.aspx?login=<%# Eval("Login") %>">Enviar nova senha</a>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                        <asp:BoundField DataField="EMail" HeaderText="E-Mail" SortExpression="EMail" />
                        <asp:BoundField DataField="Tabela" HeaderText="Tabela" SortExpression="Tabela" />
                        <asp:BoundField DataField="IMJ_IDPessoa" HeaderText="Código" SortExpression="IMJ_IDPessoa" />
                        <asp:CheckBoxField DataField="Administrador" HeaderText="Administrador" SortExpression="Administrador" />
                        <asp:BoundField DataField="UltimoAcesso" HeaderText="Último Acesso" SortExpression="UltimoAcesso"
                            ReadOnly="true" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:ObjectDataSource ID="UsuarioDS" runat="server" DataObjectTypeName="IMJWeb.Servico.Usuario.UsuarioTO"
                    DeleteMethod="ExcluirUsuario" InsertMethod="InserirUsuario" SelectMethod="ObterUsuarios"
                    TypeName="IMJWeb.Servico.Usuario.ServicoUsuario" UpdateMethod="AtualizarUsuario"
                    ConflictDetection="OverwriteChanges"></asp:ObjectDataSource>
                <asp:HyperLink runat="server" NavigateUrl="NovoUsuario.aspx" Text="Inserir" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <br />
    <h3>
        Veja também:</h3>
    <ul>
        <li><a href="EdicaoCadastro.aspx">Seus dados cadastrais</a></li>
    </ul>
</asp:Content>
