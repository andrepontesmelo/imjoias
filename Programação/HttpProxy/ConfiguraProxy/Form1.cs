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
		private System.Windows.Forms.GroupBox ConexãoCaixa;
		private System.Windows.Forms.TextBox IpTxt;
		private System.Windows.Forms.Label HostLabel;
		private System.Windows.Forms.Button ConectarBtn;
		private System.Windows.Forms.TextBox LoginTxt;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.TextBox SenhaTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl Tab;
		private System.Windows.Forms.ListBox UsuáriosLista;
		private System.Windows.Forms.GroupBox UsrCaixa;

		private MySql banco= new MySql();
		private Usuario usrAtivo=new Usuario();
		private Relatório meuRelatório=null;
		private System.Windows.Forms.TextBox UsrNomeTxt;
		private System.Windows.Forms.Label UsrNomeLabel;
		private System.Windows.Forms.RadioButton PermiteBtn;
		private System.Windows.Forms.RadioButton NegaBtn;
		private System.Windows.Forms.TabPage tabUsrLista;
		private System.Windows.Forms.TabPage tabUsr;
		private System.Windows.Forms.ListBox RestriçõesLista;
		private System.Windows.Forms.Label infoCaption;
		private System.Windows.Forms.Button RetiraBtn;
		private System.Windows.Forms.Button NovaBtn;
		private System.Windows.Forms.Button AdicionaBtn;
		private System.Windows.Forms.Button ModificaBtn;
		private System.Windows.Forms.Button AlteraBtn;
		private System.Windows.Forms.Button CancelaBtn;
		private System.Windows.Forms.Label infoNenhumUsuário;
		private System.Windows.Forms.TextBox SiteTxt;
		private System.Windows.Forms.Button NovoUsuárioBtn;
		private System.Windows.Forms.GroupBox BotõesCaixa;
		private System.Windows.Forms.Button ModificaUsuárioBtn;
		private System.Windows.Forms.Button ApagarUsuárioBtn;
		private System.Windows.Forms.GroupBox NovasInformaçõesCaixa;
		private System.Windows.Forms.Button UsrCancelaBtn;
		private System.Windows.Forms.Button GravarModificaçõesBtn;
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
			NenhumUsuário();
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
			this.ConexãoCaixa = new System.Windows.Forms.GroupBox();
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
			this.NovasInformaçõesCaixa = new System.Windows.Forms.GroupBox();
			this.GravarModificaçõesBtn = new System.Windows.Forms.Button();
			this.UsrCancelaBtn = new System.Windows.Forms.Button();
			this.BotõesCaixa = new System.Windows.Forms.GroupBox();
			this.ApagarUsuárioBtn = new System.Windows.Forms.Button();
			this.ModificaUsuárioBtn = new System.Windows.Forms.Button();
			this.NovoUsuárioBtn = new System.Windows.Forms.Button();
			this.UsrCaixa = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.NegaBtn = new System.Windows.Forms.RadioButton();
			this.PermiteBtn = new System.Windows.Forms.RadioButton();
			this.UsrNomeLabel = new System.Windows.Forms.Label();
			this.UsrNomeTxt = new System.Windows.Forms.TextBox();
			this.UsuáriosLista = new System.Windows.Forms.ListBox();
			this.tabUsr = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.infoNenhumUsuário = new System.Windows.Forms.Label();
			this.CancelaBtn = new System.Windows.Forms.Button();
			this.AlteraBtn = new System.Windows.Forms.Button();
			this.ModificaBtn = new System.Windows.Forms.Button();
			this.AdicionaBtn = new System.Windows.Forms.Button();
			this.NovaBtn = new System.Windows.Forms.Button();
			this.RetiraBtn = new System.Windows.Forms.Button();
			this.SiteTxt = new System.Windows.Forms.TextBox();
			this.infoCaption = new System.Windows.Forms.Label();
			this.RestriçõesLista = new System.Windows.Forms.ListBox();
			this.RelatoriosTab = new System.Windows.Forms.TabPage();
			this.acessoLog = new System.Windows.Forms.Button();
			this.ConexãoCaixa.SuspendLayout();
			this.Tab.SuspendLayout();
			this.tabUsrLista.SuspendLayout();
			this.IpsCaixa.SuspendLayout();
			this.NovasInformaçõesCaixa.SuspendLayout();
			this.BotõesCaixa.SuspendLayout();
			this.UsrCaixa.SuspendLayout();
			this.tabUsr.SuspendLayout();
			this.RelatoriosTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// ConexãoCaixa
			// 
			this.ConexãoCaixa.Controls.Add(this.label1);
			this.ConexãoCaixa.Controls.Add(this.SenhaTxt);
			this.ConexãoCaixa.Controls.Add(this.LoginLabel);
			this.ConexãoCaixa.Controls.Add(this.LoginTxt);
			this.ConexãoCaixa.Controls.Add(this.ConectarBtn);
			this.ConexãoCaixa.Controls.Add(this.HostLabel);
			this.ConexãoCaixa.Controls.Add(this.IpTxt);
			this.ConexãoCaixa.Location = new System.Drawing.Point(8, 8);
			this.ConexãoCaixa.Name = "ConexãoCaixa";
			this.ConexãoCaixa.Size = new System.Drawing.Size(424, 256);
			this.ConexãoCaixa.TabIndex = 0;
			this.ConexãoCaixa.TabStop = false;
			this.ConexãoCaixa.Text = "Conecte ao MySQL";
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
			this.HostLabel.Text = "Endereço Ip:";
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
			this.tabUsrLista.Controls.Add(this.NovasInformaçõesCaixa);
			this.tabUsrLista.Controls.Add(this.BotõesCaixa);
			this.tabUsrLista.Controls.Add(this.NovoUsuárioBtn);
			this.tabUsrLista.Controls.Add(this.UsrCaixa);
			this.tabUsrLista.Controls.Add(this.UsuáriosLista);
			this.tabUsrLista.Location = new System.Drawing.Point(4, 22);
			this.tabUsrLista.Name = "tabUsrLista";
			this.tabUsrLista.Size = new System.Drawing.Size(416, 230);
			this.tabUsrLista.TabIndex = 0;
			this.tabUsrLista.Text = "Usuários";
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
			this.IpsCaixa.Text = "Lista de Endereços Ips";
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
			// NovasInformaçõesCaixa
			// 
			this.NovasInformaçõesCaixa.Controls.Add(this.GravarModificaçõesBtn);
			this.NovasInformaçõesCaixa.Controls.Add(this.UsrCancelaBtn);
			this.NovasInformaçõesCaixa.Location = new System.Drawing.Point(144, 136);
			this.NovasInformaçõesCaixa.Name = "NovasInformaçõesCaixa";
			this.NovasInformaçõesCaixa.Size = new System.Drawing.Size(152, 56);
			this.NovasInformaçõesCaixa.TabIndex = 11;
			this.NovasInformaçõesCaixa.TabStop = false;
			this.NovasInformaçõesCaixa.Text = "Novas informações";
			this.NovasInformaçõesCaixa.Visible = false;
			// 
			// GravarModificaçõesBtn
			// 
			this.GravarModificaçõesBtn.Location = new System.Drawing.Point(80, 24);
			this.GravarModificaçõesBtn.Name = "GravarModificaçõesBtn";
			this.GravarModificaçõesBtn.Size = new System.Drawing.Size(64, 24);
			this.GravarModificaçõesBtn.TabIndex = 6;
			this.GravarModificaçõesBtn.Text = "Gravar";
			this.GravarModificaçõesBtn.Click += new System.EventHandler(this.GravarModificaçõesBtn_Click);
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
			// BotõesCaixa
			// 
			this.BotõesCaixa.Controls.Add(this.ApagarUsuárioBtn);
			this.BotõesCaixa.Controls.Add(this.ModificaUsuárioBtn);
			this.BotõesCaixa.Location = new System.Drawing.Point(144, 136);
			this.BotõesCaixa.Name = "BotõesCaixa";
			this.BotõesCaixa.Size = new System.Drawing.Size(152, 56);
			this.BotõesCaixa.TabIndex = 8;
			this.BotõesCaixa.TabStop = false;
			this.BotõesCaixa.Text = "Opções para este usuário";
			// 
			// ApagarUsuárioBtn
			// 
			this.ApagarUsuárioBtn.Location = new System.Drawing.Point(80, 24);
			this.ApagarUsuárioBtn.Name = "ApagarUsuárioBtn";
			this.ApagarUsuárioBtn.Size = new System.Drawing.Size(64, 24);
			this.ApagarUsuárioBtn.TabIndex = 10;
			this.ApagarUsuárioBtn.Text = "Remove";
			this.ApagarUsuárioBtn.Click += new System.EventHandler(this.ApagarUsuárioBtn_Click);
			// 
			// ModificaUsuárioBtn
			// 
			this.ModificaUsuárioBtn.Location = new System.Drawing.Point(8, 24);
			this.ModificaUsuárioBtn.Name = "ModificaUsuárioBtn";
			this.ModificaUsuárioBtn.Size = new System.Drawing.Size(64, 24);
			this.ModificaUsuárioBtn.TabIndex = 8;
			this.ModificaUsuárioBtn.Text = "Altera";
			this.ModificaUsuárioBtn.Click += new System.EventHandler(this.ModificaUsuárioBtn_Click);
			// 
			// NovoUsuárioBtn
			// 
			this.NovoUsuárioBtn.Location = new System.Drawing.Point(144, 200);
			this.NovoUsuárioBtn.Name = "NovoUsuárioBtn";
			this.NovoUsuárioBtn.Size = new System.Drawing.Size(264, 24);
			this.NovoUsuárioBtn.TabIndex = 7;
			this.NovoUsuárioBtn.Text = "Adiciona";
			this.NovoUsuárioBtn.Click += new System.EventHandler(this.NovoUsuárioBtn_Click);
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
			this.UsrCaixa.Text = "Selecione um usuário";
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
			// UsuáriosLista
			// 
			this.UsuáriosLista.Location = new System.Drawing.Point(0, 0);
			this.UsuáriosLista.Name = "UsuáriosLista";
			this.UsuáriosLista.Size = new System.Drawing.Size(136, 225);
			this.UsuáriosLista.TabIndex = 0;
			this.UsuáriosLista.SelectedIndexChanged += new System.EventHandler(this.UsuáriosLista_SelectedIndexChanged);
			// 
			// tabUsr
			// 
			this.tabUsr.Controls.Add(this.label3);
			this.tabUsr.Controls.Add(this.infoNenhumUsuário);
			this.tabUsr.Controls.Add(this.CancelaBtn);
			this.tabUsr.Controls.Add(this.AlteraBtn);
			this.tabUsr.Controls.Add(this.ModificaBtn);
			this.tabUsr.Controls.Add(this.AdicionaBtn);
			this.tabUsr.Controls.Add(this.NovaBtn);
			this.tabUsr.Controls.Add(this.RetiraBtn);
			this.tabUsr.Controls.Add(this.SiteTxt);
			this.tabUsr.Controls.Add(this.infoCaption);
			this.tabUsr.Controls.Add(this.RestriçõesLista);
			this.tabUsr.Location = new System.Drawing.Point(4, 22);
			this.tabUsr.Name = "tabUsr";
			this.tabUsr.Size = new System.Drawing.Size(416, 230);
			this.tabUsr.TabIndex = 1;
			this.tabUsr.Text = "Restrições para Usuário";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "Terminação do host: ";
			// 
			// infoNenhumUsuário
			// 
			this.infoNenhumUsuário.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.infoNenhumUsuário.ForeColor = System.Drawing.Color.Red;
			this.infoNenhumUsuário.Location = new System.Drawing.Point(0, 0);
			this.infoNenhumUsuário.Name = "infoNenhumUsuário";
			this.infoNenhumUsuário.Size = new System.Drawing.Size(8, 224);
			this.infoNenhumUsuário.TabIndex = 9;
			this.infoNenhumUsuário.Text = "Nenhum usuário Selecionado na Tab \"Usuários\" !";
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
			this.infoCaption.Text = "Os sites abaixo são os únicos permitidos para este usuário.";
			// 
			// RestriçõesLista
			// 
			this.RestriçõesLista.Location = new System.Drawing.Point(0, 24);
			this.RestriçõesLista.Name = "RestriçõesLista";
			this.RestriçõesLista.Size = new System.Drawing.Size(296, 173);
			this.RestriçõesLista.TabIndex = 0;
			// 
			// RelatoriosTab
			// 
			this.RelatoriosTab.Controls.Add(this.acessoLog);
			this.RelatoriosTab.Location = new System.Drawing.Point(4, 22);
			this.RelatoriosTab.Name = "RelatoriosTab";
			this.RelatoriosTab.Size = new System.Drawing.Size(416, 230);
			this.RelatoriosTab.TabIndex = 2;
			this.RelatoriosTab.Text = "Relatórios";
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
			this.Controls.Add(this.ConexãoCaixa);
			this.MaximizeBox = false;
			this.Name = "Principal";
			this.Text = "Configuração do Servidor Proxy";
			this.ConexãoCaixa.ResumeLayout(false);
			this.Tab.ResumeLayout(false);
			this.tabUsrLista.ResumeLayout(false);
			this.IpsCaixa.ResumeLayout(false);
			this.NovasInformaçõesCaixa.ResumeLayout(false);
			this.BotõesCaixa.ResumeLayout(false);
			this.UsrCaixa.ResumeLayout(false);
			this.tabUsr.ResumeLayout(false);
			this.RelatoriosTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]

		// Aparência		
		static void Main() 
		{
			Application.Run(new Principal());
		}

		private void NenhumUsuário() 
		{
			IpsCaixa.Enabled = false;
			UsrCaixa.Text = "Nenhum Usuário!";
			UsrCaixa.Enabled = false;
			infoCaption.Enabled = false;
			infoNenhumUsuário.Visible = true;
			infoNenhumUsuário.Width = 420;
			BotõesCaixa.Enabled = false;
			UsrNomeTxt.Text = "";
		}
		private void AlgumUsuário() 
		{
			IpsCaixa.Enabled = true;
			NegaBtn.Enabled = true;
			infoCaption.Enabled = true;
			infoNenhumUsuário.Visible = false;
			BotõesCaixa.Enabled = true;
		}


		// Banco de Dados
		private void ConectarBtn_Click(object sender, System.EventArgs e)
		{
			ConectarBtn.Enabled = false;
			banco.Conectar("proxy", IpTxt.Text,LoginTxt.Text,SenhaTxt.Text);
			ConexãoCaixa.Visible = false;
			PreecheUsuários();
			Tab.Visible = true;
		}
		private void PreecheUsuários() 
		{
			UsuáriosLista.Items.Clear();
			ArrayList listaUsuários = banco.LerArrayList("select nome from usuarios");
			foreach (string usrAtual in listaUsuários ) 
				UsuáriosLista.Items.Add(usrAtual);	
		}

		void AdicionaSite(string nomeSite) 
		{
			int linkId=0;
			nomeSite = ((string)(nomeSite.Trim())).ToLower();
			if ( nomeSite.Length == 0 ) 
			{
				MessageBox.Show("Entre com uma link válido!");
			} 
			else 
			{
				//verificação se ja existe
				
				for ( int x=0;x< RestriçõesLista.Items.Count;x++)
				{
					if (((string) RestriçõesLista.Items[x]) == nomeSite ) {
						MessageBox.Show("Este site já está cadastrado para este usuário!");
						return;
					}
				}

				if( banco.ComandoString("select id from links where host like '" + nomeSite  + "'").Length == 0 ) 
					//O site a ser criado nao existe, criando então.
					banco.ComandoString("INSERT INTO `links` (`id`, `host`) VALUES (NULL, '" + nomeSite + "')");
				linkId = banco.ComandoInt("select id from links where host like '" + nomeSite  + "'");
				banco.ComandoString("INSERT INTO `permissao` (`usuarioId`, `linkId`) VALUES (" + usrAtivo.Id.ToString() + "," + linkId.ToString() + ")");
				RestriçõesLista.Items.Add(nomeSite);
				BotõesNormaliza();
			}
		}

		void AbreInformaçõesUsuário() 
		{
			if ( ((string)(UsuáriosLista.Text)).Length == 0 ) 
				NenhumUsuário();
			else 
			{
				usrAtivo.ColetarDados(banco,UsuáriosLista.Text);
				UsrCaixa.Text = "Configurações para " + usrAtivo.Nome;
				tabUsr.Text = "Restrições para " + usrAtivo.Nome;
				UsrNomeTxt.Text = usrAtivo.Nome;
				if (usrAtivo.TipoAcesso == 0) 
				{
					infoCaption.Text = "Os sites abaixo são os únicos permitidos para este usuário.";
					NegaBtn.Checked = true;
				} 
				else 
				{
					PermiteBtn.Checked = true;
					infoCaption.Text = "Os sites abaixo são PROIBIDOS para este usuário.";
				}
				FazListaLinks();
				FazListaIps();
				AlgumUsuário();
								
			}

		}
		void RetiraRestrição (string nomeRestrição) 
		{
			int linkId = banco.ComandoInt("SELECT id FROM links WHERE host = '" + nomeRestrição + "'");
			banco.ComandoString("DELETE FROM `permissao` WHERE  `usuarioId`=" + usrAtivo.Id.ToString() + " AND `linkId` = " + linkId.ToString());
		}

		private void AltereConfiguraçõesUsuário(string NovoNome) 
		{
			usrAtivo.Nome = NovoNome;

			if (NegaBtn.Checked==true)
				usrAtivo.TipoAcesso = 0;
			else
				usrAtivo.TipoAcesso = 1;
			usrAtivo.Gravar(banco);
			NormalizaBotõesUsuários();
			AbreInformaçõesUsuário();		
		}

		private void IncluaUsuário(string novoUsr) 
		{ 
			//Verificação se já existe:
			//TODO: ver tilt do for ( em 2 lugares ) 
			for ( int x=0 ; x < UsuáriosLista.Items.Count ; x++ ) 
			{
				if ( ((string) UsuáriosLista.Items[x]) == novoUsr ) 
				{
					MessageBox.Show("Este usuário já existe!");
					return;
				}
			}
			
			//Pode Incluir o usuário. SQL:
			if ( NegaBtn.Checked == true ) 
				banco.ComandoString("INSERT INTO `usuarios` (`id`, `nome`, `tipoAcesso`) VALUES (NULL, '" + novoUsr + "', 0)");
			else
				banco.ComandoString("INSERT INTO `usuarios` (`id`, `nome`, `tipoAcesso`) VALUES (NULL, '" + novoUsr + "', 1)");
			UsuáriosLista.Items.Add(novoUsr);
			NormalizaBotõesUsuários();
		}


		private string ValidaNovoUsuário() 
		{
			string novoUsr = ((string) UsrNomeTxt.Text.Trim()).ToLower();
			
			//Verificação de nome:
			if (novoUsr.Length == 0) 
			{
				MessageBox.Show("O nome-do-usuário é inválido");
				return null;
			}
			return novoUsr;

		}


		// Controles da lista de usuários
		private void ApagarUsuárioBtn_Click(object sender, System.EventArgs e)
		{
			banco.ComandoString("DELETE FROM `usuarios` WHERE id='" + usrAtivo.Id + "'");
			NenhumUsuário();
			PreecheUsuários();
		}

		private void NormalizaBotõesUsuários() 
		{
			NovasInformaçõesCaixa.Visible = false;
			BotõesCaixa.Visible = true;
			UsrCaixa.Enabled = false;
			UsrNomeTxt.Text = "";
			NovoUsuárioBtn.Visible =true;
			UsuáriosLista.Enabled = true;
		}
		private void ModificaUsuárioBtn_Click(object sender, System.EventArgs e)
		{
			UsuáriosLista.Enabled = false;
			DeAcessoAosBotões();
		}

		private void NovoUsuárioBtn_Click(object sender, System.EventArgs e)
		{
			DeAcessoAosBotões();

		}

		private void UsrCancelaBtn_Click(object sender, System.EventArgs e)
		{
			NormalizaBotõesUsuários();
			AbreInformaçõesUsuário();
		}

		private void GravarModificaçõesBtn_Click(object sender, System.EventArgs e)
		{
			String NovoUsuário = ValidaNovoUsuário();
			if ( NovoUsuário == null ) return;
			//Detecta se é alteração ou inclusão
			if ( UsuáriosLista.Enabled == false ) 
			{
				//Trata-se de uma alteração!
				AltereConfiguraçõesUsuário(NovoUsuário);
			} 
			else 
			{
				//Trata-se de uma inclusão.
				IncluaUsuário(NovoUsuário);
			}
			
		}



		// Controles da lista de links do usuário específico
		private void UsuáriosLista_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			AbreInformaçõesUsuário();
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
			BotõesNormaliza();

		}

		
		private void SiteTxt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13 ) AdicionaSite(SiteTxt.Text  );
		}

		void BotõesNormaliza() 
		{
			SiteTxt.Text = "";
			SiteTxt.Visible = false;
			AdicionaBtn.Visible = false;
			CancelaBtn.Visible = false;
			NovaBtn.Enabled = true;
			RetiraBtn.Enabled = true;
			ModificaBtn.Visible = false;
			AlteraBtn.Enabled = true;
			RestriçõesLista.Enabled = true;
		}
	
		private void RetiraBtn_Click(object sender, System.EventArgs e)
		{
			if ( RestriçõesLista.Text.Length == 0 ) 
				MessageBox.Show("Selecione uma restrição antes!");
			else 
			{
				RetiraRestrição(RestriçõesLista.Text);
				usrAtivo.PegarHosts(banco);
				FazListaLinks();
			}
				

		}

		void FazListaLinks() 
		{
			RestriçõesLista.Items.Clear();
			foreach ( string linkAtual in usrAtivo.Hosts ) 
				RestriçõesLista.Items.Add(linkAtual);
		}

		private void AlteraBtn_Click(object sender, System.EventArgs e)
		{
			if ( RestriçõesLista.Text.Length == 0 ) 
			{
				MessageBox.Show("Selecione um link antes!");
				return;
			}
			RestriçõesLista.Enabled = false;
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
			ModificaSite(RestriçõesLista.Text,((string) (SiteTxt.Text.Trim())).ToLower());
		}
		private void ModificaSite(string anterior,string atual) 
		{
			if ( atual.Length == 0 ) 
			{
				MessageBox.Show("Novo site inválido!");
				return;
			}
			RetiraRestrição(anterior);
			AdicionaSite(atual);
			usrAtivo.PegarHosts(banco);
			FazListaLinks();
		}

		private void DeAcessoAosBotões() 
		{
			if ( UsuáriosLista.Enabled == true) 
			{
				UsrNomeTxt.Text = "";
				NegaBtn.Checked = true;
			}
			NovasInformaçõesCaixa.Visible = true;
			BotõesCaixa.Visible = false;
			UsrCaixa.Enabled = true;
			UsrNomeTxt.Focus();
			NovoUsuárioBtn.Visible =false;
		}



		private void AdicionaIp(string ip) 
		{
			string pessoaDonaDesteIp;

			ip = ((string) (ip.Trim()).ToLower());
			if ( ip.Length == 0 ) return;
			//verificar se não já existe este ip no mysql:
			pessoaDonaDesteIp = banco.ComandoString("SELECT nome FROM usuarios,ips WHERE ips.usuarioId = usuarios.id AND `enderecoIp` = '" + ip + "' LIMIT 1");
			if (pessoaDonaDesteIp.Length > 0 ) 
			{
				MessageBox.Show("Este ip já existe na relação do usuário " + pessoaDonaDesteIp);
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
			if (meuRelatório  == null) meuRelatório = new Relatório(banco);
			meuRelatório.ConstruirLog();
			meuRelatório.Visible = true;
			meuRelatório.Show();
		}

	}



		
}
