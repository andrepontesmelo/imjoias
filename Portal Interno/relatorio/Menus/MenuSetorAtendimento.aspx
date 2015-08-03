<%@ Page language="c#" Codebehind="MenuSetorAtendimento.aspx.cs" AutoEventWireup="false" Inherits="Relatório.Menus.MenuSetorAtendimento" %>
<%@ Register TagPrefix="cc1" Namespace="SuporteWeb.WebForms" Assembly="SuporteWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MenuSetorAtendimento</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<cc1:Menu id="menuAtendimentos" runat="server" Link="../recepcao/atendimentos.aspx" Título="Atendimentos"
				Descrição="Relatório de atendimentos no último mês" Ícone="../../interface/atendimento.jpg"></cc1:Menu>&nbsp;
			<cc1:Menu id="menuAtendimentosMensais" runat="server" Ícone="../../interface/calendario.gif"
				Descrição="Relatório comparativo de atendimentos nos últimos 6 meses" Título="Atendimentos Mensais"
				Link="../recepcao/atendimentosMensais.aspx"></cc1:Menu>
		</form>
	</body>
</HTML>
