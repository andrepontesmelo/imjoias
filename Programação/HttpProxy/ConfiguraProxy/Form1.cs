using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ConfiguraProxy
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

	public class Principal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox Conex�oCaixa;
		private System.Windows.Forms.TextBox IpTxt;
		private System.Windows.Forms.Label HostLabel;
		private System.Windows.Forms.Button ConectarBtn;
		private System.Windows.Forms.TextBox LoginTxt;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.TextBox SenhaTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl Tab;
		private System.Windows.Forms.ListBox Usu�riosLista;
		private System.Windows.Forms.GroupBox UsrCaixa;

		private MySql banco= new MySql();
		private Usuario usrAtivo=new Usuario();
		private Relat�rio meuRelat�rio=null;
		private System.Windows.Forms.TextBox UsrNomeTxt;
		private System.Windows.Forms.Label UsrNomeLabel;
		private System.Windows.Forms.RadioButton PermiteBtn;
		private System.Windows.Forms.RadioButton NegaBtn;
		private System.Windows.Forms.TabPage tabUsrLista;
		private System.Windows.Forms.TabPage tabUsr;
		private System.Windows.Forms.ListBox Restri��esLista;
		private System.Windows.Forms.Label infoCaption;
		private System.Windows.Forms.Button RetiraBtn;
		private System.Windows.Forms.Button NovaBtn;
		private System.Windows.Forms.Button AdicionaBtn;
		private System.Windows.Forms.Button ModificaBtn;
		private System.Windows.Forms.Button AlteraBtn;
		private System.Windows.Forms.Button CancelaBtn;
		private System.Windows.Forms.Label infoNenhumUsu�rio;
		private System.Windows.Forms.TextBox SiteTxt;
		private System.Windows.Forms.Button NovoUsu�rioBtn;
		private System.Windows.Forms.GroupBox Bot�esCaixa;
		private System.Windows.Forms.Button ModificaUsu�rioBtn;
		private System.Windows.Forms.Button ApagarUsu�rioBtn;
		private System.Windows.Forms.GroupBox NovasInforma��esCaixa;
		private System.Windows.Forms.Button UsrCancelaBtn;
		private System.Windows.Forms.Button GravarModifica��esBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox IpsCaixa;
		private System.Windows.Forms.TextBox ipEntrada;
		private System.Windows.Forms.Button AdicionarIpBtn;
		private System.Windows.Forms.Button RetiraIpBtn;
		private System.Windows.Forms.ListBox UsrIpLista;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage RelatoriosTab;
		private System.Windows.Forms.Button acessoLog;
		private System.ComponentModel.Container components = null;

		public Principal()
		{
			InitializeComponent();
			NenhumUsu�rio();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Conex�oCaixa = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SenhaTxt = new System.Windows.Forms.TextBox();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.LoginTxt = new System.Windows.Forms.TextBox();
			this.ConectarBtn = new System.Windows.Forms.Button();
			this.HostLabel = new System.Windows.Forms.Label();
			this.IpTxt = new System.Windows.Forms.TextBox();
			this.Tab = new System.Windows.Forms.TabControl();
			this.tabUsrLista = new System.Windows.Forms.TabPage();
			this.IpsCaixa = new System.Windows.Forms.GroupBox();
			this.ipEntrada = new System.Windows.Forms.TextBox();
			this.AdicionarIpBtn = new System.Windows.Forms.Button();
			this.RetiraIpBtn = new System.Windows.Forms.Button();
			this.UsrIpLista = new System.Windows.Forms.ListBox();
			this.NovasInforma��esCaixa = new System.Windows.Forms.GroupBox();
			this.GravarModifica��esBtn = new System.Windows.Forms.Button();
			this.UsrCancelaBtn = new System.Windows.Forms.Button();
			this.Bot�esCaixa = new System.Windows.Forms.GroupBox();
			this.ApagarUsu�rioBtn = new System.Windows.Forms.Button();
			this.ModificaUsu�rioBtn = new System.Windows.Forms.Button();
			this.NovoUsu�rioBtn = new System.Windows.Forms.Button();
			this.UsrCaixa = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.NegaBtn = new System.Windows.Forms.RadioButton();
			this.PermiteBtn = new System.Windows.Forms.RadioButton();
			this.UsrNomeLabel = new System.Windows.Forms.Label();
			this.UsrNomeTxt = new System.Windows.Forms.TextBox();
			this.Usu�riosLista = new System.Windows.Forms.ListBox();
			this.tabUsr = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.infoNenhumUsu�rio = new System.Windows.Forms.Label();
			this.CancelaBtn = new System.Windows.Forms.Button();
			this.AlteraBtn = new System.Windows.Forms.Button();
			this.ModificaBtn = new System.Windows.Forms.Button();
			this.AdicionaBtn = new System.Windows.Forms.Button();
			this.NovaBtn = new System.Windows.Forms.Button();
			this.RetiraBtn = new System.Windows.Forms.Button();
			this.SiteTxt = new System.Windows.Forms.TextBox();
			this.infoCaption = new System.Windows.Forms.Label();
			this.Restri��esLista = new System.Windows.Forms.ListBox();
			this.RelatoriosTab = new System.Windows.Forms.TabPage();
			this.acessoLog = new System.Windows.Forms.Button();
			this.Conex�oCaixa.SuspendLayout();
			this.Tab.SuspendLayout();
			this.tabUsrLista.SuspendLayout();
			this.IpsCaixa.SuspendLayout();
			this.NovasInforma��esCaixa.SuspendLayout();
			this.Bot�esCaixa.SuspendLayout();
			this.UsrCaixa.SuspendLayout();
			this.tabUsr.SuspendLayout();
			this.RelatoriosTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// Conex�oCaixa
			// 
			this.Conex�oCaixa.Controls.Add(this.label1);
			this.Conex�oCaixa.Controls.Add(this.SenhaTxt);
			this.Conex�oCaixa.Controls.Add(this.LoginLabel);
			this.Conex�oCaixa.Controls.Add(this.LoginTxt);
			this.Conex�oCaixa.Controls.Add(this.ConectarBtn);
			this.Conex�oCaixa.Controls.Add(this.HostLabel);
			this.Conex�oCaixa.Controls.Add(this.IpTxt);
			this.Conex�oCaixa.Location = new System.Drawing.Point(8, 8);
			this.Conex�oCaixa.Name = "Conex�oCaixa";
			this.Conex�oCaixa.Size = new System.Drawing.Size(424, 256);
			this.Conex�oCaixa.TabIndex = 0;
			this.Conex�oCaixa.TabStop = false;
			this.Conex�oCaixa.Text = "Conecte ao MySQL";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "Senha:";
			// 
			// SenhaTxt
			// 
			this.SenhaTxt.Location = new System.Drawing.Point(40, 184);
			this.SenhaTxt.Name = "SenhaTxt";
			this.SenhaTxt.PasswordChar = '*';
			this.SenhaTxt.Size = new System.Drawing.Size(120, 20);
			this.SenhaTxt.TabIndex = 5;
			this.SenhaTxt.Text = "imj";
			// 
			// LoginLabel
			// 
			this.LoginLabel.Location = new System.Drawing.Point(40, 104);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(80, 16);
			this.LoginLabel.TabIndex = 4;
			this.LoginLabel.Text = "Login:";
			// 
			// LoginTxt
			// 
			this.LoginTxt.Location = new System.Drawing.Point(40, 120);
			this.LoginTxt.Name = "LoginTxt";
			this.LoginTxt.Size = new System.Drawing.Size(120, 20);
			this.LoginTxt.TabIndex = 3;
			this.LoginTxt.Text = "proxy";
			// 
			// ConectarBtn
			// 
			this.ConectarBtn.Location = new System.Drawing.Point(224, 120);
			this.ConectarBtn.Name = "ConectarBtn";
			this.ConectarBtn.Size = new System.Drawing.Size(104, 24);
			this.ConectarBtn.TabIndex = 2;
			this.ConectarBtn.Text = "Conectar";
			this.ConectarBtn.Click += new System.EventHandler(this.ConectarBtn_Click);
			// 
			// HostLabel
			// 
			this.HostLabel.Location = new System.Drawing.Point(40, 40);
			this.HostLabel.Name = "HostLabel";
			this.HostLabel.Size = new System.Drawing.Size(104, 16);
			this.HostLabel.TabIndex = 1;
			this.HostLabel.Text = "Endere�o Ip:";
			// 
			// IpTxt
			// 
			this.IpTxt.Location = new System.Drawing.Point(40, 56);
			this.IpTxt.Name = "IpTxt";
			this.IpTxt.Size = new System.Drawing.Size(120, 20);
			this.IpTxt.TabIndex = 0;
			this.IpTxt.Text = "200.150.44.6";
			// 
			// Tab
			// 
			this.Tab.Controls.Add(this.tabUsrLista);
			this.Tab.Controls.Add(this.tabUsr);
			this.Tab.Controls.Add(this.RelatoriosTab);
			this.Tab.Location = new System.Drawing.Point(8, 8);
			this.Tab.Name = "Tab";
			this.Tab.SelectedIndex = 0;
			this.Tab.Size = new System.Drawing.Size(424, 256);
			this.Tab.TabIndex = 1;
			this.Tab.Visible = false;
			// 
			// tabUsrLista
			// 
			this.tabUsrLista.Controls.Add(this.IpsCaixa);
			this.tabUsrLista.Controls.Add(this.NovasInforma��esCaixa);
			this.tabUsrLista.Controls.Add(this.Bot�esCaixa);
			this.tabUsrLista.Controls.Add(this.NovoUsu�rioBtn);
			this.tabUsrLista.Controls.Add(this.UsrCaixa);
			this.tabUsrLista.Controls.Add(this.Usu�riosLista);
			this.tabUsrLista.Location = new System.Drawing.Point(4, 22);
			this.tabUsrLista.Name = "tabUsrLista";
			this.tabUsrLista.Size = new System.Drawing.Size(416, 230);
			this.tabUsrLista.TabIndex = 0;
			this.tabUsrLista.Text = "Usu�rios";
			// 
			// IpsCaixa
			// 
			this.IpsCaixa.Controls.Add(this.ipEntrada);
			this.IpsCaixa.Controls.Add(this.AdicionarIpBtn);
			this.IpsCaixa.Controls.Add(this.RetiraIpBtn);
			this.IpsCaixa.Controls.Add(this.UsrIpLista);
			this.IpsCaixa.Location = new System.Drawing.Point(304, 8);
			this.IpsCaixa.Name = "IpsCaixa";
			this.IpsCaixa.Size = new System.Drawing.Size(104, 184);
			this.IpsCaixa.TabIndex = 12;
			this.IpsCaixa.TabStop = false;
			this.IpsCaixa.Text = "Lista de Endere�os Ips";
			// 
			// ipEntrada
			// 
			this.ipEntrada.BackColor = System.Drawing.Color.White;
			this.ipEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ipEntrada.Location = new System.Drawing.Point(8, 128);
			this.ipEntrada.Name = "ipEntrada";
			this.ipEntrada.Size = new System.Drawing.Size(88, 20);
			this.ipEntrada.TabIndex = 11;
			this.ipEntrada.Text = "novo ip";
			// 
			// AdicionarIpBtn
			// 
			this.AdicionarIpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AdicionarIpBtn.Location = new System.Drawing.Point(8, 152);
			this.AdicionarIpBtn.Name = "AdicionarIpBtn";
			this.AdicionarIpBtn.Size = new System.Drawing.Size(88, 24);
			this.AdicionarIpBtn.TabIndex = 10;
			this.AdicionarIpBtn.Text = "--> Inclui";
			this.AdicionarIpBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.AdicionarIpBtn.Click += new System.EventHandler(this.AdicionarIpBtn_Click_1);
			// 
			// RetiraIpBtn
			// 
			this.RetiraIpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RetiraIpBtn.ForeColor = System.Drawing.Color.Black;
			this.RetiraIpBtn.Location = new System.Drawing.Point(8, 96);
			this.RetiraIpBtn.Name = "RetiraIpBtn";
			this.RetiraIpBtn.Size = new System.Drawing.Size(88, 24);
			this.RetiraIpBtn.TabIndex = 9;
			this.RetiraIpBtn.Text = "Retira";
			this.RetiraIpBtn.Click += new System.EventHandler(this.RetiraIpBtn_Click);
			// 
			// UsrIpLista
			// 
			this.UsrIpLista.BackColor = System.Drawing.SystemColors.ControlDark;
			this.UsrIpLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.UsrIpLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.UsrIpLista.ForeColor = System.Drawing.Color.Maroon;
			this.UsrIpLista.ItemHeight = 12;
			this.UsrIpLista.Location = new System.Drawing.Point(8, 32);
			this.UsrIpLista.Name = "UsrIpLista";
			this.UsrIpLista.Size = new System.Drawing.Size(88, 60);
			this.UsrIpLista.TabIndex = 6;
			this.UsrIpLista.SelectedIndexChanged += new System.EventHandler(this.UsrIpLista_SelectedIndexChanged);
			// 
			// NovasInforma��esCaixa
			// 
			this.NovasInforma��esCaixa.Controls.Add(this.GravarModifica��esBtn);
			this.NovasInforma��esCaixa.Controls.Add(this.UsrCancelaBtn);
			this.NovasInforma��esCaixa.Location = new System.Drawing.Point(144, 136);
			this.NovasInforma��esCaixa.Name = "NovasInforma��esCaixa";
			this.NovasInforma��esCaixa.Size = new System.Drawing.Size(152, 56);
			this.NovasInforma��esCaixa.TabIndex = 11;
			this.NovasInforma��esCaixa.TabStop = false;
			this.NovasInforma��esCaixa.Text = "Novas informa��es";
			this.NovasInforma��esCaixa.Visible = false;
			// 
			// GravarModifica��esBtn
			// 
			this.GravarModifica��esBtn.Location = new System.Drawing.Point(80, 24);
			this.GravarModifica��esBtn.Name = "GravarModifica��esBtn";
			this.GravarModifica��esBtn.Size = new System.Drawing.Size(64, 24);
			this.GravarModifica��esBtn.TabIndex = 6;
			this.GravarModifica��esBtn.Text = "Gravar";
			this.GravarModifica��esBtn.Click += new System.EventHandler(this.GravarModifica��esBtn_Click);
			// 
			// UsrCancelaBtn
			// 
			this.UsrCancelaBtn.Location = new System.Drawing.Point(8, 24);
			this.UsrCancelaBtn.Name = "UsrCancelaBtn";
			this.UsrCancelaBtn.Size = new System.Drawing.Size(64, 24);
			this.UsrCancelaBtn.TabIndex = 5;
			this.UsrCancelaBtn.Text = "Cancelar";
			this.UsrCancelaBtn.Click += new System.EventHandler(this.UsrCancelaBtn_Click);
			// 
			// Bot�esCaixa
			// 
			this.Bot�esCaixa.Controls.Add(this.ApagarUsu�rioBtn);
			this.Bot�esCaixa.Controls.Add(this.ModificaUsu�rioBtn);
			this.Bot�esCaixa.Location = new System.Drawing.Point(144, 136);
			this.Bot�esCaixa.Name = "Bot�esCaixa";
			this.Bot�esCaixa.Size = new System.Drawing.Size(152, 56);
			this.Bot�esCaixa.TabIndex = 8;
			this.Bot�esCaixa.TabStop = false;
			this.Bot�esCaixa.Text = "Op��es para este usu�rio";
			// 
			// ApagarUsu�rioBtn
			// 
			this.ApagarUsu�rioBtn.Location = new System.Drawing.Point(80, 24);
			this.ApagarUsu�rioBtn.Name = "ApagarUsu�rioBtn";
			this.ApagarUsu�rioBtn.Size = new System.Drawing.Size(64, 24);
			this.ApagarUsu�rioBtn.TabIndex = 10;
			this.ApagarUsu�rioBtn.Text = "Remove";
			this.ApagarUsu�rioBtn.Click += new System.EventHandler(this.ApagarUsu�rioBtn_Click);
			// 
			// ModificaUsu�rioBtn
			// 
			this.ModificaUsu�rioBtn.Location = new System.Drawing.Point(8, 24);
			this.ModificaUsu�rioBtn.Name = "ModificaUsu�rioBtn";
			this.ModificaUsu�rioBtn.Size = new System.Drawing.Size(64, 24);
			this.ModificaUsu�rioBtn.TabIndex = 8;
			this.ModificaUsu�rioBtn.Text = "Altera";
			this.ModificaUsu�rioBtn.Click += new System.EventHandler(this.ModificaUsu�rioBtn_Click);
			// 
			// NovoUsu�rioBtn
			// 
			this.NovoUsu�rioBtn.Location = new System.Drawing.Point(144, 200);
			this.NovoUsu�rioBtn.Name = "NovoUsu�rioBtn";
			this.NovoUsu�rioBtn.Size = new System.Drawing.Size(264, 24);
			this.NovoUsu�rioBtn.TabIndex = 7;
			this.NovoUsu�rioBtn.Text = "Adiciona";
			this.NovoUsu�rioBtn.Click += new System.EventHandler(this.NovoUsu�rioBtn_Click);
			// 
			// UsrCaixa
			// 
			this.UsrCaixa.Controls.Add(this.label2);
			this.UsrCaixa.Controls.Add(this.NegaBtn);
			this.UsrCaixa.Controls.Add(this.PermiteBtn);
			this.UsrCaixa.Controls.Add(this.UsrNomeLabel);
			this.UsrCaixa.Controls.Add(this.UsrNomeTxt);
			this.UsrCaixa.Location = new System.Drawing.Point(144, 8);
			this.UsrCaixa.Name = "UsrCaixa";
			this.UsrCaixa.Size = new System.Drawing.Size(152, 128);
			this.UsrCaixa.TabIndex = 1;
			this.UsrCaixa.TabStop = false;
			this.UsrCaixa.Text = "Selecione um usu�rio";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Purple;
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Tipo da conta:";
			// 
			// NegaBtn
			// 
			this.NegaBtn.Location = new System.Drawing.Point(24, 88);
			this.NegaBtn.Name = "NegaBtn";
			this.NegaBtn.Size = new System.Drawing.Size(120, 16);
			this.NegaBtn.TabIndex = 3;
			this.NegaBtn.Text = "Permitir alguns sites";
			// 
			// PermiteBtn
			// 
			this.PermiteBtn.Location = new System.Drawing.Point(24, 104);
			this.PermiteBtn.Name = "PermiteBtn";
			this.PermiteBtn.Size = new System.Drawing.Size(120, 16);
			this.PermiteBtn.TabIndex = 4;
			this.PermiteBtn.Text = "Proibir alguns sites";
			// 
			// UsrNomeLabel
			// 
			this.UsrNomeLabel.ForeColor = System.Drawing.Color.Purple;
			this.UsrNomeLabel.Location = new System.Drawing.Point(8, 40);
			this.UsrNomeLabel.Name = "UsrNomeLabel";
			this.UsrNomeLabel.Size = new System.Drawing.Size(40, 16);
			this.UsrNomeLabel.TabIndex = 2;
			this.UsrNomeLabel.Text = "Nome:";
			// 
			// UsrNomeTxt
			// 
			this.UsrNomeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UsrNomeTxt.Cursor = System.Windows.Forms.Cursors.No;
			this.UsrNomeTxt.Location = new System.Drawing.Point(48, 40);
			this.UsrNomeTxt.Name = "UsrNomeTxt";
			this.UsrNomeTxt.Size = new System.Drawing.Size(96, 20);
			this.UsrNomeTxt.TabIndex = 1;
			this.UsrNomeTxt.Text = "";
			// 
			// Usu�riosLista
			// 
			this.Usu�riosLista.Location = new System.Drawing.Point(0, 0);
			this.Usu�riosLista.Name = "Usu�riosLista";
			this.Usu�riosLista.Size = new System.Drawing.Size(136, 225);
			this.Usu�riosLista.TabIndex = 0;
			this.Usu�riosLista.SelectedIndexChanged += new System.EventHandler(this.Usu�riosLista_SelectedIndexChanged);
			// 
			// tabUsr
			// 
			this.tabUsr.Controls.Add(this.label3);
			this.tabUsr.Controls.Add(this.infoNenhumUsu�rio);
			this.tabUsr.Controls.Add(this.CancelaBtn);
			this.tabUsr.Controls.Add(this.AlteraBtn);
			this.tabUsr.Controls.Add(this.ModificaBtn);
			this.tabUsr.Controls.Add(this.AdicionaBtn);
			this.tabUsr.Controls.Add(this.NovaBtn);
			this.tabUsr.Controls.Add(this.RetiraBtn);
			this.tabUsr.Controls.Add(this.SiteTxt);
			this.tabUsr.Controls.Add(this.infoCaption);
			this.tabUsr.Controls.Add(this.Restri��esLista);
			this.tabUsr.Location = new System.Drawing.Point(4, 22);
			this.tabUsr.Name = "tabUsr";
			this.tabUsr.Size = new System.Drawing.Size(416, 230);
			this.tabUsr.TabIndex = 1;
			this.tabUsr.Text = "Restri��es para Usu�rio";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "Termina��o do host: ";
			// 
			// infoNenhumUsu�rio
			// 
			this.infoNenhumUsu�rio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.infoNenhumUsu�rio.ForeColor = System.Drawing.Color.Red;
			this.infoNenhumUsu�rio.Location = new System.Drawing.Point(0, 0);
			this.infoNenhumUsu�rio.Name = "infoNenhumUsu�rio";
			this.infoNenhumUsu�rio.Size = new System.Drawing.Size(8, 224);
			this.infoNenhumUsu�rio.TabIndex = 9;
			this.infoNenhumUsu�rio.Text = "Nenhum usu�rio Selecionado na Tab \"Usu�rios\" !";
			// 
			// CancelaBtn
			// 
			this.CancelaBtn.Location = new System.Drawing.Point(312, 136);
			this.CancelaBtn.Name = "CancelaBtn";
			this.CancelaBtn.Size = new System.Drawing.Size(88, 24);
			this.CancelaBtn.TabIndex = 8;
			this.CancelaBtn.Text = "Cancelar";
			this.CancelaBtn.Visible = false;
			this.CancelaBtn.Click += new System.EventHandler(this.CancelaBtn_Click);
			// 
			// AlteraBtn
			// 
			this.AlteraBtn.Location = new System.Drawing.Point(312, 88);
			this.AlteraBtn.Name = "AlteraBtn";
			this.AlteraBtn.Size = new System.Drawing.Size(88, 24);
			this.AlteraBtn.TabIndex = 7;
			this.AlteraBtn.Text = "Altera";
			this.AlteraBtn.Click += new System.EventHandler(this.AlteraBtn_Click);
			// 
			// ModificaBtn
			// 
			this.ModificaBtn.Location = new System.Drawing.Point(312, 168);
			this.ModificaBtn.Name = "ModificaBtn";
			this.ModificaBtn.Size = new System.Drawing.Size(88, 24);
			this.ModificaBtn.TabIndex = 6;
			this.ModificaBtn.Text = "Modifica!";
			this.ModificaBtn.Visible = false;
			this.ModificaBtn.Click += new System.EventHandler(this.ModificaBtn_Click);
			// 
			// AdicionaBtn
			// 
			this.AdicionaBtn.Location = new System.Drawing.Point(312, 200);
			this.AdicionaBtn.Name = "AdicionaBtn";
			this.AdicionaBtn.Size = new System.Drawing.Size(88, 24);
			this.AdicionaBtn.TabIndex = 5;
			this.AdicionaBtn.Text = "Adiciona!";
			this.AdicionaBtn.Visible = false;
			this.AdicionaBtn.Click += new System.EventHandler(this.AdicionaBtn_Click);
			// 
			// NovaBtn
			// 
			this.NovaBtn.Location = new System.Drawing.Point(312, 24);
			this.NovaBtn.Name = "NovaBtn";
			this.NovaBtn.Size = new System.Drawing.Size(88, 24);
			this.NovaBtn.TabIndex = 4;
			this.NovaBtn.Text = "Nova";
			this.NovaBtn.Click += new System.EventHandler(this.NovaBtn_Click);
			// 
			// RetiraBtn
			// 
			this.RetiraBtn.Location = new System.Drawing.Point(312, 56);
			this.RetiraBtn.Name = "RetiraBtn";
			this.RetiraBtn.Size = new System.Drawing.Size(88, 24);
			this.RetiraBtn.TabIndex = 3;
			this.RetiraBtn.Text = "Retira";
			this.RetiraBtn.Click += new System.EventHandler(this.RetiraBtn_Click);
			// 
			// SiteTxt
			// 
			this.SiteTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SiteTxt.Location = new System.Drawing.Point(80, 208);
			this.SiteTxt.Name = "SiteTxt";
			this.SiteTxt.Size = new System.Drawing.Size(216, 20);
			this.SiteTxt.TabIndex = 2;
			this.SiteTxt.Text = "";
			this.SiteTxt.Visible = false;
			this.SiteTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SiteTxt_KeyPress);
			// 
			// infoCaption
			// 
			this.infoCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.infoCaption.Location = new System.Drawing.Point(8, 8);
			this.infoCaption.Name = "infoCaption";
			this.infoCaption.Size = new System.Drawing.Size(368, 16);
			this.infoCaption.TabIndex = 1;
			this.infoCaption.Text = "Os sites abaixo s�o os �nicos permitidos para este usu�rio.";
			// 
			// Restri��esLista
			// 
			this.Restri��esLista.Location = new System.Drawing.Point(0, 24);
			this.Restri��esLista.Name = "Restri��esLista";
			this.Restri��esLista.Size = new System.Drawing.Size(296, 173);
			this.Restri��esLista.TabIndex = 0;
			// 
			// RelatoriosTab
			// 
			this.RelatoriosTab.Controls.Add(this.acessoLog);
			this.RelatoriosTab.Location = new System.Drawing.Point(4, 22);
			this.RelatoriosTab.Name = "RelatoriosTab";
			this.RelatoriosTab.Size = new System.Drawing.Size(416, 230);
			this.RelatoriosTab.TabIndex = 2;
			this.RelatoriosTab.Text = "Relat�rios";
			// 
			// acessoLog
			// 
			this.acessoLog.Location = new System.Drawing.Point(136, 48);
			this.acessoLog.Name = "acessoLog";
			this.acessoLog.Size = new System.Drawing.Size(136, 32);
			this.acessoLog.TabIndex = 0;
			this.acessoLog.Text = "Log dos acessos";
			this.acessoLog.Click += new System.EventHandler(this.acessoLog_Click);
			// 
			// Principal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 270);
			this.Controls.Add(this.Tab);
			this.Controls.Add(this.Conex�oCaixa);
			this.MaximizeBox = false;
			this.Name = "Principal";
			this.Text = "Configura��o do Servidor Proxy";
			this.Conex�oCaixa.ResumeLayout(false);
			this.Tab.ResumeLayout(false);
			this.tabUsrLista.ResumeLayout(false);
			this.IpsCaixa.ResumeLayout(false);
			this.NovasInforma��esCaixa.ResumeLayout(false);
			this.Bot�esCaixa.ResumeLayout(false);
			this.UsrCaixa.ResumeLayout(false);
			this.tabUsr.ResumeLayout(false);
			this.RelatoriosTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]

		// Apar�ncia		
		static void Main() 
		{
			Application.Run(new Principal());
		}

		private void NenhumUsu�rio() 
		{
			IpsCaixa.Enabled = false;
			UsrCaixa.Text = "Nenhum Usu�rio!";
			UsrCaixa.Enabled = false;
			infoCaption.Enabled = false;
			infoNenhumUsu�rio.Visible = true;
			infoNenhumUsu�rio.Width = 420;
			Bot�esCaixa.Enabled = false;
			UsrNomeTxt.Text = "";
		}
		private void AlgumUsu�rio() 
		{
			IpsCaixa.Enabled = true;
			NegaBtn.Enabled = true;
			infoCaption.Enabled = true;
			infoNenhumUsu�rio.Visible = false;
			Bot�esCaixa.Enabled = true;
		}


		// Banco de Dados
		private void ConectarBtn_Click(object sender, System.EventArgs e)
		{
			ConectarBtn.Enabled = false;
			banco.Conectar("proxy", IpTxt.Text,LoginTxt.Text,SenhaTxt.Text);
			Conex�oCaixa.Visible = false;
			PreecheUsu�rios();
			Tab.Visible = true;
		}
		private void PreecheUsu�rios() 
		{
			Usu�riosLista.Items.Clear();
			ArrayList listaUsu�rios = banco.LerArrayList("select nome from usuarios");
			foreach (string usrAtual in listaUsu�rios ) 
				Usu�riosLista.Items.Add(usrAtual);	
		}

		void AdicionaSite(string nomeSite) 
		{
			int linkId=0;
			nomeSite = ((string)(nomeSite.Trim())).ToLower();
			if ( nomeSite.Length == 0 ) 
			{
				MessageBox.Show("Entre com uma link v�lido!");
			} 
			else 
			{
				//verifica��o se ja existe
				
				for ( int x=0;x< Restri��esLista.Items.Count;x++)
				{
					if (((string) Restri��esLista.Items[x]) == nomeSite ) {
						MessageBox.Show("Este site j� est� cadastrado para este usu�rio!");
						return;
					}
				}

				if( banco.ComandoString("select id from links where host like '" + nomeSite  + "'").Length == 0 ) 
					//O site a ser criado nao existe, criando ent�o.
					banco.ComandoString("INSERT INTO `links` (`id`, `host`) VALUES (NULL, '" + nomeSite + "')");
				linkId = banco.ComandoInt("select id from links where host like '" + nomeSite  + "'");
				banco.ComandoString("INSERT INTO `permissao` (`usuarioId`, `linkId`) VALUES (" + usrAtivo.Id.ToString() + "," + linkId.ToString() + ")");
				Restri��esLista.Items.Add(nomeSite);
				Bot�esNormaliza();
			}
		}

		void AbreInforma��esUsu�rio() 
		{
			if ( ((string)(Usu�riosLista.Text)).Length == 0 ) 
				NenhumUsu�rio();
			else 
			{
				usrAtivo.ColetarDados(banco,Usu�riosLista.Text);
				UsrCaixa.Text = "Configura��es para " + usrAtivo.Nome;
				tabUsr.Text = "Restri��es para " + usrAtivo.Nome;
				UsrNomeTxt.Text = usrAtivo.Nome;
				if (usrAtivo.TipoAcesso == 0) 
				{
					infoCaption.Text = "Os sites abaixo s�o os �nicos permitidos para este usu�rio.";
					NegaBtn.Checked = true;
				} 
				else 
				{
					PermiteBtn.Checked = true;
					infoCaption.Text = "Os sites abaixo s�o PROIBIDOS para este usu�rio.";
				}
				FazListaLinks();
				FazListaIps();
				AlgumUsu�rio();
								
			}

		}
		void RetiraRestri��o (string nomeRestri��o) 
		{
			int linkId = banco.ComandoInt("SELECT id FROM links WHERE host = '" + nomeRestri��o + "'");
			banco.ComandoString("DELETE FROM `permissao` WHERE  `usuarioId`=" + usrAtivo.Id.ToString() + " AND `linkId` = " + linkId.ToString());
		}

		private void AltereConfigura��esUsu�rio(string NovoNome) 
		{
			usrAtivo.Nome = NovoNome;

			if (NegaBtn.Checked==true)
				usrAtivo.TipoAcesso = 0;
			else
				usrAtivo.TipoAcesso = 1;
			usrAtivo.Gravar(banco);
			NormalizaBot�esUsu�rios();
			AbreInforma��esUsu�rio();		
		}

		private void IncluaUsu�rio(string novoUsr) 
		{ 
			//Verifica��o se j� existe:
			//TODO: ver tilt do for ( em 2 lugares ) 
			for ( int x=0 ; x < Usu�riosLista.Items.Count ; x++ ) 
			{
				if ( ((string) Usu�riosLista.Items[x]) == novoUsr ) 
				{
					MessageBox.Show("Este usu�rio j� existe!");
					return;
				}
			}
			
			//Pode Incluir o usu�rio. SQL:
			if ( NegaBtn.Checked == true ) 
				banco.ComandoString("INSERT INTO `usuarios` (`id`, `nome`, `tipoAcesso`) VALUES (NULL, '" + novoUsr + "', 0)");
			else
				banco.ComandoString("INSERT INTO `usuarios` (`id`, `nome`, `tipoAcesso`) VALUES (NULL, '" + novoUsr + "', 1)");
			Usu�riosLista.Items.Add(novoUsr);
			NormalizaBot�esUsu�rios();
		}


		private string ValidaNovoUsu�rio() 
		{
			string novoUsr = ((string) UsrNomeTxt.Text.Trim()).ToLower();
			
			//Verifica��o de nome:
			if (novoUsr.Length == 0) 
			{
				MessageBox.Show("O nome-do-usu�rio � inv�lido");
				return null;
			}
			return novoUsr;

		}


		// Controles da lista de usu�rios
		private void ApagarUsu�rioBtn_Click(object sender, System.EventArgs e)
		{
			banco.ComandoString("DELETE FROM `usuarios` WHERE id='" + usrAtivo.Id + "'");
			NenhumUsu�rio();
			PreecheUsu�rios();
		}

		private void NormalizaBot�esUsu�rios() 
		{
			NovasInforma��esCaixa.Visible = false;
			Bot�esCaixa.Visible = true;
			UsrCaixa.Enabled = false;
			UsrNomeTxt.Text = "";
			NovoUsu�rioBtn.Visible =true;
			Usu�riosLista.Enabled = true;
		}
		private void ModificaUsu�rioBtn_Click(object sender, System.EventArgs e)
		{
			Usu�riosLista.Enabled = false;
			DeAcessoAosBot�es();
		}

		private void NovoUsu�rioBtn_Click(object sender, System.EventArgs e)
		{
			DeAcessoAosBot�es();

		}

		private void UsrCancelaBtn_Click(object sender, System.EventArgs e)
		{
			NormalizaBot�esUsu�rios();
			AbreInforma��esUsu�rio();
		}

		private void GravarModifica��esBtn_Click(object sender, System.EventArgs e)
		{
			String NovoUsu�rio = ValidaNovoUsu�rio();
			if ( NovoUsu�rio == null ) return;
			//Detecta se � altera��o ou inclus�o
			if ( Usu�riosLista.Enabled == false ) 
			{
				//Trata-se de uma altera��o!
				AltereConfigura��esUsu�rio(NovoUsu�rio);
			} 
			else 
			{
				//Trata-se de uma inclus�o.
				IncluaUsu�rio(NovoUsu�rio);
			}
			
		}



		// Controles da lista de links do usu�rio espec�fico
		private void Usu�riosLista_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			AbreInforma��esUsu�rio();
		}
		
		private void NovaBtn_Click(object sender, System.EventArgs e)
		{
			SiteTxt.Visible = true;
			SiteTxt.Focus();
			AlteraBtn.Enabled = false;
			AdicionaBtn.Visible = true;
			CancelaBtn.Visible = true;
			NovaBtn.Enabled = false;
			RetiraBtn.Enabled = false;
		}

		private void CancelaBtn_Click(object sender, System.EventArgs e)
		{
			Bot�esNormaliza();

		}

		
		private void SiteTxt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13 ) AdicionaSite(SiteTxt.Text  );
		}

		void Bot�esNormaliza() 
		{
			SiteTxt.Text = "";
			SiteTxt.Visible = false;
			AdicionaBtn.Visible = false;
			CancelaBtn.Visible = false;
			NovaBtn.Enabled = true;
			RetiraBtn.Enabled = true;
			ModificaBtn.Visible = false;
			AlteraBtn.Enabled = true;
			Restri��esLista.Enabled = true;
		}
	
		private void RetiraBtn_Click(object sender, System.EventArgs e)
		{
			if ( Restri��esLista.Text.Length == 0 ) 
				MessageBox.Show("Selecione uma restri��o antes!");
			else 
			{
				RetiraRestri��o(Restri��esLista.Text);
				usrAtivo.PegarHosts(banco);
				FazListaLinks();
			}
				

		}

		void FazListaLinks() 
		{
			Restri��esLista.Items.Clear();
			foreach ( string linkAtual in usrAtivo.Hosts ) 
				Restri��esLista.Items.Add(linkAtual);
		}

		private void AlteraBtn_Click(object sender, System.EventArgs e)
		{
			if ( Restri��esLista.Text.Length == 0 ) 
			{
				MessageBox.Show("Selecione um link antes!");
				return;
			}
			Restri��esLista.Enabled = false;
			NovaBtn.Enabled = false;
			RetiraBtn.Enabled = false;
			AlteraBtn.Enabled = false;
			CancelaBtn.Visible = true;
			ModificaBtn.Visible = true;
			AdicionaBtn.Visible = false;
			SiteTxt.Visible = true;
			SiteTxt.Focus();
		}

		private void ModificaBtn_Click(object sender, System.EventArgs e)
		{
			ModificaSite(Restri��esLista.Text,((string) (SiteTxt.Text.Trim())).ToLower());
		}
		private void ModificaSite(string anterior,string atual) 
		{
			if ( atual.Length == 0 ) 
			{
				MessageBox.Show("Novo site inv�lido!");
				return;
			}
			RetiraRestri��o(anterior);
			AdicionaSite(atual);
			usrAtivo.PegarHosts(banco);
			FazListaLinks();
		}

		private void DeAcessoAosBot�es() 
		{
			if ( Usu�riosLista.Enabled == true) 
			{
				UsrNomeTxt.Text = "";
				NegaBtn.Checked = true;
			}
			NovasInforma��esCaixa.Visible = true;
			Bot�esCaixa.Visible = false;
			UsrCaixa.Enabled = true;
			UsrNomeTxt.Focus();
			NovoUsu�rioBtn.Visible =false;
		}



		private void AdicionaIp(string ip) 
		{
			string pessoaDonaDesteIp;

			ip = ((string) (ip.Trim()).ToLower());
			if ( ip.Length == 0 ) return;
			//verificar se n�o j� existe este ip no mysql:
			pessoaDonaDesteIp = banco.ComandoString("SELECT nome FROM usuarios,ips WHERE ips.usuarioId = usuarios.id AND `enderecoIp` = '" + ip + "' LIMIT 1");
			if (pessoaDonaDesteIp.Length > 0 ) 
			{
				MessageBox.Show("Este ip j� existe na rela��o do usu�rio " + pessoaDonaDesteIp);
				return;
			}
			banco.ComandoString("INSERT INTO `ips` (`enderecoIp`, `usuarioId`) VALUES ('" + ip.ToString() +"','"+ usrAtivo.Id + "')");
            usrAtivo.PegarIps(banco);
			FazListaIps();	

		}
		private void RetiraIp(string ip) 
		{
			banco.ComandoString("DELETE FROM `ips` WHERE `enderecoIp`= '" + UsrIpLista.Text + "' AND `usuarioId`=" + usrAtivo.Id.ToString());
			usrAtivo.PegarIps(banco);
			FazListaIps();
			

		}

		private void AdicionarIpBtn_Click(object sender, System.EventArgs e)
		{
			AdicionaIp(ipEntrada.Text);
		}
		
		private void FazListaIps() 
		{
			ArrayList ips = usrAtivo.Ips; 
			UsrIpLista.Items.Clear();
			foreach( string ipAtual in ips ) 
				UsrIpLista.Items.Add(ipAtual);
			AtualizaControleIps();
		}
		private void AtualizaControleIps() 
		{
			if (UsrIpLista.Text.Length == 0 ) 
			{	
				RetiraIpBtn.Enabled = false;
			} 
			else 
			{
				RetiraIpBtn.Enabled = true;

			}
		}

		private void UsrIpLista_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			AtualizaControleIps();
		}

		private void RetiraIpBtn_Click(object sender, System.EventArgs e)
		{
			RetiraIp(UsrIpLista.Text);
		}

		private void AdicionarIpBtn_Click_1(object sender, System.EventArgs e)
		{
			AdicionaIp( ipEntrada.Text);
		}

		private void AdicionaBtn_Click(object sender, System.EventArgs e)
		{
			AdicionaSite(SiteTxt.Text );
		}

		private void acessoLog_Click(object sender, System.EventArgs e)
		{
			if (meuRelat�rio  == null) meuRelat�rio = new Relat�rio(banco);
			meuRelat�rio.ConstruirLog();
			meuRelat�rio.Visible = true;
			meuRelat�rio.Show();
		}

	}



		
}
