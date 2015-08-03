<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="bugs.Relatório" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<IMG style="WIDTH: 160px; HEIGHT: 72px" height="72" alt="" src="Logo.jpg" width="160">&nbsp;
			<DIV style="DISPLAY: inline; FONT-SIZE: large; Z-INDEX: 101; LEFT: 176px; WIDTH: 352px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 56px; HEIGHT: 32px"
				ms_positioning="FlowLayout">Relatório de bugs do sistema</DIV>
			<HR style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 96px; HEIGHT: 8px" width="100%"
				SIZE="8">
			<DIV style="Z-INDEX: 103; LEFT: 16px; WIDTH: 680px; POSITION: absolute; TOP: 112px; HEIGHT: 200px"
				ms_positioning="FlowLayout">
				<table>
					<%
						MostrarLinhas();
					%>
				</table>
			</DIV>
		</form>
	</body>
</HTML>
