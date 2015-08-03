<%@ Page language="c#" Codebehind="atendimentosMensais.aspx.cs" AutoEventWireup="false" Inherits="Relat�rio.Recepcao.atendimentosMensais" %>
<%@ Register TagPrefix="cc1" Namespace="Relat�rio.Graficos" Assembly="relatorio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>atendimentosMensais</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P class="titulo">Atendimentos Mensais <FONT size="3">(�ltimo seis meses /
					<asp:Label id="lblSetor" runat="server">Setor</asp:Label>)</FONT></P>
			<table align="center">
				<tr>
					<td>
						<p class="subtitulo">Pessoas por m�s</p>
					</td>
				</tr>
				<tr>
					<td align="center">
						<cc1:Gr�fico id="gr�fico" runat="server" Plotter="../Graficos/Plotar.aspx" Refer�ncia="epm"></cc1:Gr�fico>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
