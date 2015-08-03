<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Relatório.Graficos._Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Default</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../imjoias.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<P class="titulo">Solicitação de Gráfico</P>
		<form method="post" runat="server">
			<asp:panel id="painelTítulo" runat="server">
				<P><STRONG><FONT size="4">Título:
							<asp:Label id="lblTítulo" runat="server">título</asp:Label></FONT></STRONG></P>
				<P>
					<asp:RadioButtonList id="radioTítulo" runat="server" AutoPostBack="True"></asp:RadioButtonList></P>
			</asp:panel><asp:panel id="painelPeríodo" runat="server" Visible="False">
				<P><FONT size="4"><STRONG>Escolha o período:</STRONG></FONT></P>
				<TABLE cellSpacing="10" align="center">
					<TR>
						<TD>Período inicial:</TD>
						<TD>Período final:</TD>
					</TR>
					<TR>
						<TD>
							<asp:Calendar id="períodoInicial" runat="server" ShowGridLines="True" BorderColor="#FFCC66" Font-Names="Verdana"
								Font-Size="8pt" Height="200px" ForeColor="#663399" DayNameFormat="FirstLetter" Width="220px"
								BackColor="#FFFFCC" BorderWidth="1px">
								<TodayDayStyle ForeColor="White" BackColor="#FFCC66"></TodayDayStyle>
								<SelectorStyle BackColor="#FFCC66"></SelectorStyle>
								<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
								<DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle>
								<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
								<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle>
								<OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
							</asp:Calendar></TD>
						<TD>
							<asp:Calendar id="períodoFinal" runat="server" ShowGridLines="True" BorderColor="#FFCC66" Font-Names="Verdana"
								Font-Size="8pt" Height="200px" ForeColor="#663399" DayNameFormat="FirstLetter" Width="220px"
								BackColor="#FFFFCC" BorderWidth="1px">
								<TodayDayStyle ForeColor="White" BackColor="#FFCC66"></TodayDayStyle>
								<SelectorStyle BackColor="#FFCC66"></SelectorStyle>
								<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
								<DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle>
								<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
								<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle>
								<OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
							</asp:Calendar></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="painelSetor" runat="server" Visible="False">
				<P><FONT size="4"><STRONG>Escolha o setor:</STRONG></FONT></P>
				<P>
					<asp:RadioButtonList id="setor" runat="server" AutoPostBack="True"></asp:RadioButtonList></P>
			</asp:panel></form>
		<asp:panel id="painelEnvio" runat="server" Visible="False">
			<FORM action="plotar.aspx" method="get">
				<P><STRONG><FONT size="4">Tamanho:</FONT></STRONG></P>
				<P align="center"><FONT size="4"><INPUT style="WIDTH: 56px; HEIGHT: 22px" type="text" size="4" value="480" name="Largura"><FONT size="1">&nbsp;x</FONT><STRONG>
						</STRONG><INPUT style="WIDTH: 56px; HEIGHT: 22px" type="text" size="4" value="240" name="Altura"></FONT></P>
				<P align="center"><INPUT type=hidden 
value="<% Response.Write(radioTítulo.SelectedValue); %>" name=ref> <INPUT 
type=hidden 
value='<% Response.Write(períodoInicial.SelectedDate.ToString("yyyy-MM-dd")); %>' 
name=periodoInicial> <INPUT type=hidden 
value='<% Response.Write(períodoFinal.SelectedDate.AddDays(1).ToString("yyyy-MM-dd")); %>' 
name=periodoFinal> <INPUT type=hidden 
value="<% Response.Write(setor.SelectedValue); %>" name=setor> <INPUT type="submit" value="Enviar consulta" name="Gerar Gráfico">
				</P>
			</FORM>
		</asp:panel>
	</body>
</HTML>
