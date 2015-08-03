<%@ Page language="c#" Codebehind="telefonemas.aspx.cs" AutoEventWireup="false" Inherits="Relatório.Recepcao.telefonemas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>telefonemas</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<P class="titulo">
			Últimos telefonemas registrados
		</P>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="WIDTH: 325px; HEIGHT: 280px" cellSpacing="1" cellPadding="1"
				width="325" align="center" border="0">
				<TR>
					<TD align="center" colSpan="1">
						<asp:DataGrid id="dgTelefones" runat="server" CellPadding="3" HorizontalAlign="Center" ForeColor="Blue"
							Font-Names="Arial" BorderColor="#FFC080" BackColor="White">
							<AlternatingItemStyle ForeColor="#330099" BorderColor="White" Width="0px" BackColor="White"></AlternatingItemStyle>
							<ItemStyle ForeColor="#330099"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFC0" BackColor="Maroon"></HeaderStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
			<asp:Label id="lblInfoEspera" runat="server" Width="355px" Height="24px">Listagem dos últimos 20 telefonemas registrados pela recepcionista.</asp:Label>
		</form>
	</BODY>
</HTML>
