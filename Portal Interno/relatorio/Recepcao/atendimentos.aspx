<%@ Register TagPrefix="cc1" Namespace="Relat�rio.Graficos" Assembly="relatorio" %>
<%@ Page language="c#" Codebehind="atendimentos.aspx.cs" AutoEventWireup="false" Inherits="Relat�rio.Resumo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Resumo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P class="titulo">
				Atendimentos&nbsp; <FONT size="3">(<asp:Label id="lblPer�odo" runat="server">Per�odo</asp:Label>
					/
					<asp:Label id="lblSetor" runat="server">Setor</asp:Label>)</FONT>
			</P>
			<table border="0" align="center">
				<tr>
					<td>
						<p class="subtitulo">
							Propor��o de atendimento
						</p>
					</td>
					<td>
						<p class="subtitulo">
							Espera por atendimento
						</p>
					</td>
				</tr>
				<tr align=center>
					<td>
						<cc1:Gr�fico id="gr�ficoPA" runat="server" Height="200px" Width="200px" Refer�ncia="pa" Altura="200"
							Largura="200" Plotter="../Graficos/Plotar.aspx"></cc1:Gr�fico><br>
					</td>
					<td>
						<cc1:Gr�fico id="gr�ficoEspera" runat="server" Height="200px" Width="200px" Refer�ncia="mteds"
							Altura="200" Largura="200" Plotter="../Graficos/Plotar.aspx"></cc1:Gr�fico><BR>
					</td>
				</tr>
				<tr align=center>
					<td>
						<cc1:Legenda id="legendaPA" runat="server" Width="200px" Refer�ncia="pa"></cc1:Legenda>
					</td>
				</tr>
			</table>
		</form>
		<P align="center">
			<asp:datagrid id="dataGrid" runat="server" CellPadding="4" BorderStyle="None" BorderWidth="1px"
				BackColor="White" BorderColor="#CC9966" EnableViewState="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid></P>
	</body>
</HTML>
