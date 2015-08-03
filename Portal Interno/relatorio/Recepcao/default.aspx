<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="Relatório.Recepção._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form runat="server">
			<div class="titulo">Relatório de Visitantes
			</div>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:label id="lblTítulo" runat="server" Visible="False" Font-Bold="True" EnableViewState="False">Título</asp:label></DIV>
			<DIV align="center"><asp:label id="lblResumo" runat="server" Visible="False" EnableViewState="False">Resumo</asp:label></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:datagrid id="dataGrid" runat="server" Visible="False" CellPadding="4" BorderStyle="None"
					BorderWidth="1px" BackColor="White" BorderColor="#CC9966" EnableViewState="False">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFC0"></PagerStyle>
				</asp:datagrid></DIV>
			<div id="consulta">
				<P>Por favor, entre com o período desejado:
				</P>
				<DIV align="center">
					<table cellSpacing="10" align="center" id="Table1">
						<tr style="FONT-WEIGHT: bolder">
							<td style="WIDTH: 211px">Período inicial:</td>
							<td>Período final:</td>
						</tr>
						<tr>
							<td style="WIDTH: 211px"><asp:calendar id="períodoInicial" runat="server" BorderWidth="1px" BackColor="#FFFFCC" BorderColor="#FFCC66"
									ShowGridLines="True" Font-Names="Verdana" Font-Size="8pt" Height="200px" ForeColor="#663399" DayNameFormat="FirstLetter"
									Width="220px">
									<TodayDayStyle ForeColor="White" BackColor="#FFCC66"></TodayDayStyle>
									<SelectorStyle BackColor="#FFCC66"></SelectorStyle>
									<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
									<DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle>
									<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
									<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle>
									<OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
								</asp:calendar></td>
							<td><asp:calendar id="períodoFinal" runat="server" BorderWidth="1px" BackColor="#FFFFCC" BorderColor="#FFCC66"
									ShowGridLines="True" Font-Names="Verdana" Font-Size="8pt" Height="200px" ForeColor="#663399"
									DayNameFormat="FirstLetter" Width="220px">
									<TodayDayStyle ForeColor="White" BackColor="#FFCC66"></TodayDayStyle>
									<SelectorStyle BackColor="#FFCC66"></SelectorStyle>
									<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
									<DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle>
									<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
									<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle>
									<OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
								</asp:calendar></td>
						</tr>
						<tr>
							<td style="WIDTH: 211px"><STRONG>Setor:</STRONG>
							</td>
						</tr>
						<tr>
							<td style="WIDTH: 211px"><asp:dropdownlist id="cmbSetor" runat="server" Width="100%"></asp:dropdownlist></td>
							<td>
								<DIV align="center"><asp:Button id="cmdGerarRelatório" runat="server" Text="Gerar relatório"></asp:Button></DIV>
							</td>
						</tr>
					</table>
				</DIV>
			</div>
		</form>
	</body>
</HTML>
