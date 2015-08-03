<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="Relatório.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P class="titulo" align="left"><IMG style="WIDTH: 16px; HEIGHT: 30px" height="30" alt="" src="../interface/chavepequena.gif"
					width="16" align="textTop">&nbsp;Acesso restrito</P>
			<P align="center">
				<asp:Label id="lblMensagem" runat="server" Font-Size="Medium">Você está acessando uma área cujo acesso é restrito. Favor identificar o seu nome de usuário e sua senha.</asp:Label></P>
			<P align="center">
				<table style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
					border="0">
					<tr>
						<td>
							<P align="center">Usuário:</P>
						</td>
						<td style="WIDTH: 169px"><input id="usuario" type="text" runat="server" style="WIDTH: 162px; HEIGHT: 22px" size="21"></td>
						<td><asp:RequiredFieldValidator ControlToValidate="usuario" runat="server" ErrorMessage="*" Display="Static" id="RequiredFieldValidator1" /></td>
					</tr>
					<tr>
						<td>Senha:</td>
						<td style="WIDTH: 169px"><input id="senha" type="password" runat="server" style="WIDTH: 163px; HEIGHT: 22px" size="21"></td>
						<td><asp:RequiredFieldValidator ControlToValidate="senha" runat="server" ErrorMessage="*" Display="Static" id="RequiredFieldValidator2" /></td>
					</tr>
				</table>
			</P>
			<P align="center">
				<asp:Button id="cmdEntrar" runat="server" Text="Entrar" BackColor="Cornsilk"></asp:Button></P>
		</form>
	</body>
</HTML>
