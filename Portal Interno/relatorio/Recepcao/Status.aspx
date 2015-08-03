<%@ Page language="c#" Codebehind="Status.aspx.cs" AutoEventWireup="false" Inherits="Relatório.Recepcao.Status" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Status</title>
		<meta HTTP-EQUIV="Refresh" CONTENT="60">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<P class="titulo">Visitantes&nbsp;esperando por atendimento</P>
		<DIV align="center" ms_positioning="FlowLayout">
			<TABLE id="Table2" style="WIDTH: 217px; HEIGHT: 180px" cellSpacing="1" cellPadding="1"
				width="217" border="0" align="center">
				<TR>
					<TD align="center" colSpan="1">
						<asp:DataGrid id="dgEspera" runat="server" CellPadding="3" HorizontalAlign="Center" ForeColor="Blue"
							Font-Names="Arial" BorderColor="#FFC080" BackColor="White">
							<AlternatingItemStyle ForeColor="#330099" BorderColor="White" Width="0px" BackColor="White"></AlternatingItemStyle>
							<ItemStyle ForeColor="#330099"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFC0" BackColor="Maroon"></HeaderStyle>
						</asp:DataGrid>
						<asp:Label id="lblInfoEspera" runat="server" Width="355px" Height="24px">lblInfoEspera:  - informações sobre a tabela de espera por atendimentos - </asp:Label></TD>
				</TR>
			</TABLE>
		</DIV>
		<DIV align="justify" ms_positioning="FlowLayout">
			<DIV align="justify" ms_positioning="FlowLayout">
				<P class="titulo">
					Visitantes sendo atendidos</P>
			</DIV>
			<TABLE id="Table3" style="WIDTH: 361px; HEIGHT: 140px" cellSpacing="1" cellPadding="1"
				width="361" align="center" border="0">
				<TR>
					<TD>
						<DIV align="center" ms_positioning="FlowLayout">
							<asp:DataGrid id="dgAtendimentos" runat="server" BackColor="White" BorderColor="#FFC080" Font-Names="Arial"
								ForeColor="Blue" HorizontalAlign="Center" CellPadding="2" Width="136px">
								<AlternatingItemStyle ForeColor="#330099" BorderColor="White" Width="0px" BackColor="White"></AlternatingItemStyle>
								<ItemStyle ForeColor="#330099"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFC0" BackColor="Maroon"></HeaderStyle>
							</asp:DataGrid></DIV>
						<DIV align="center" ms_positioning="FlowLayout">
							<asp:Label id="lblInfoAtendimentos" runat="server" Width="355px" Height="24px">lblInfoAtendimentos:  - informações sobre a tabela de atendimentos - </asp:Label></DIV>
					</TD>
				</TR>
			</TABLE>
			<DIV align="justify" ms_positioning="FlowLayout">
				<DIV align="justify" ms_positioning="FlowLayout">&nbsp;</DIV>
			</DIV>
			<DIV align="justify" ms_positioning="FlowLayout">
				<TABLE id="Table1" style="WIDTH: 713px; HEIGHT: 40px" cellSpacing="0" cellPadding="0" width="713"
					border="0">
					<TR>
					</TR>
				</TABLE>
			</DIV>
			<DIV align="justify" ms_positioning="FlowLayout">&nbsp;</DIV>
			<DIV align="justify" ms_positioning="FlowLayout">
			</DIV>
		</DIV>
	</body>
</HTML>
