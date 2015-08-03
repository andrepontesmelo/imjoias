<%@ Control Language="C#" CodeFile="Login.ascx.cs" Inherits="Login_ascx" %>
<table cellspacing="0" cellpadding="0" border="0" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px;">
    <tr style="height: 170px" valign="bottom">
        <td style="height: 170px; width: 250px;" style="border-right: #cc9966 1px solid; border-top: #cc9966 1px solid;	border-left: #cc9966 1px solid;	border-bottom: #cc9966 1px solid; background-color: #ffffcc; width: 260px; text-align: center;">
            <p style="font-family: Sans-Serif; font-weight: bold; font-size: large; text-align: center">
            <asp:Image ID="Chave" runat="server" ImageUrl="chave.gif" Width="16px" />
            Autentica��o de usu�rio</p>
            
            <asp:Login ID="DadosLogin" runat="server" TitleText="" RememberMeText="Lembrar-se de mim da pr�xima vez."
                PasswordLabelText="Senha:" LoginButtonText="Entrar" FailureText="N�o foi poss�vel autentic�-lo no sistema."
                UserNameLabelText="Usu�rio:" PasswordRequiredErrorMessage="A senha do usu�rio � necess�ria."
                UserNameRequiredErrorMessage="Nome de usu�rio � necess�rio." OnAuthenticate="DadosLogin_Authenticate">
                <TextBoxStyle Width="150px" />
            </asp:Login>
        </td>
        <td style="height: 170px;"><asp:Image ID="Image3" runat="server" ImageUrl="escurecendo_horizontal.jpg" width="10" height="160px" ImageAlign="Bottom"/></td>
    </tr>
    <tr valign="top">
        <td style="width: 260px">
            <asp:Image ID="Image1" runat="server" ImageUrl="escurecendo_vertical.jpg" width="250" height="10" ImageAlign="Right" /></td>
        <td>
            <asp:Image ID="Image2" runat="server" ImageUrl="escurecendo_quina.jpg" width="10" height="10" ImageAlign="Top" /></td>
    </tr>
</table>
