using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;
using Ind�stria_Mineira_de_J�ias.An�liseEstat�stica;
using Apresenta��o.Formul�rios;
using Report.Layout;
using Report.Layout.Simple;

namespace Administra��o.Formul�rios
{
	public class Funcion�rioTelefonemas : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private Apresenta��o.Formul�rios.Quadro quadroCrescimento;
		private Apresenta��o.Formul�rios.Quadro quadroPropor��o;
		private Estat�stica.Gr�fico gr�ficoCrescimento;
		private Estat�stica.Gr�fico gr�ficoPropor��o;
		private Apresenta��o.Formul�rios.Quadro quadroLista;
		private System.Windows.Forms.ListView lstTelefonemas;
		private System.Windows.Forms.ColumnHeader colData;
		private System.Windows.Forms.ColumnHeader colTelefone;
		private System.Windows.Forms.ColumnHeader colOrigem;
		private System.Windows.Forms.ColumnHeader colDestino;
		private System.Windows.Forms.ColumnHeader colCidade;
		private System.Windows.Forms.ColumnHeader colTOrigem;
		private System.Windows.Forms.ColumnHeader colTDestino;
		private Estat�stica.Legenda legenda;
		private System.Drawing.Printing.PrintDocument impress�o;
		private Report.Layout.SimpleLayout leiaute;
		private System.Windows.Forms.Button cmdFechar;
		private System.Windows.Forms.Button cmdImprimir;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.ComponentModel.IContainer components = null;

		public Funcion�rioTelefonemas(Funcion�rio funcion�rio, DateTime in�cio, DateTime final)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			MostrarDados(funcion�rio, in�cio, final);
			
			leiaute.Document.DocumentName = "Relat�rio de Telefonemas\n" + funcion�rio.Nome + "\n" + in�cio.ToShortDateString() + " - " + final.ToShortDateString();
			leiaute.Columns.Add(new Column("Data", typeof(Telefonema), "Data"));
			leiaute.Columns.Add(new Column("Hora", typeof(Telefonema), "Hora"));
			leiaute.Columns.Add(new Column("Telefone", typeof(Telefonema), "Telefone"));
			leiaute.Columns.Add(new Column("De", typeof(Telefonema), "De"));
			leiaute.Columns.Add(new Column("Para", typeof(Telefonema), "Para"));
			leiaute.Columns.Add(new Column("Cidade", typeof(Telefonema), "Cidade"));
			leiaute.ChangeFontSize(10);
		}

		private void MostrarDados(Funcion�rio funcion�rio, DateTime in�cio, DateTime final)
		{
			/*
			ArrayList telefonemas;
			double [] crescimento;
			double [] propor��o;
			Aguarde aguarde;

			aguarde = new Aguarde(
				"Recuperando e gerando estat�sticas dos telefonemas...", 2);
			aguarde.Show();
			aguarde.Refresh();

			Principal.Controle.Estat�sticaFuncion�rios.ObterTelefonemas(
				in�cio, final, funcion�rio.C�digo,
				out telefonemas, out crescimento,
				out propor��o);

			this.Text = funcion�rio.Nome + " [Telefonemas]";
			lblDescri��o.Text = "Lista de telefonemas realizado pelo funcion�rio " + funcion�rio.Nome + ".";

			// Construir lista
			aguarde.Passo("Construindo relat�rio...");

			foreach (Telefonema telefonema in telefonemas)
			{
				ListViewItem linha;

				linha = new ListViewItem();
				linha.Text = telefonema.Quando.ToString("dd/MM/yyyy hh:mm:ss");
				linha.SubItems.Add(telefonema.Telefone);
				linha.SubItems.Add(telefonema.Cidade);
				linha.SubItems.Add(telefonema.Origem == null ? funcion�rio.Nome : telefonema.Origem);
				linha.SubItems.Add(telefonema.TOrigem.ToString());
				linha.SubItems.Add(telefonema.Destino == null ? funcion�rio.Nome : telefonema.Destino);
				linha.SubItems.Add(telefonema.TDestino.ToString());

				lstTelefonemas.Items.Add(linha);
			}

			gr�ficoCrescimento.Vetor�nico = crescimento;
			Estat�stica.LegendaValoresX.Data(
				gr�ficoCrescimento,
				in�cio);

			gr�ficoPropor��o.Vetor�nico = propor��o;
			gr�ficoPropor��o.Legendas = new string[2]
				{ funcion�rio.PrimeiroNome, "Outros" };

			leiaute.Objects = telefonemas;

			aguarde.Close();
			aguarde.Dispose();
			*/
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Funcion�rioTelefonemas));
			this.quadroCrescimento = new Apresenta��o.Formul�rios.Quadro();
			this.gr�ficoCrescimento = new Estat�stica.Gr�fico();
			this.quadroPropor��o = new Apresenta��o.Formul�rios.Quadro();
			this.legenda = new Estat�stica.Legenda();
			this.gr�ficoPropor��o = new Estat�stica.Gr�fico();
			this.quadroLista = new Apresenta��o.Formul�rios.Quadro();
			this.lstTelefonemas = new System.Windows.Forms.ListView();
			this.colData = new System.Windows.Forms.ColumnHeader();
			this.colTelefone = new System.Windows.Forms.ColumnHeader();
			this.colCidade = new System.Windows.Forms.ColumnHeader();
			this.colOrigem = new System.Windows.Forms.ColumnHeader();
			this.colTOrigem = new System.Windows.Forms.ColumnHeader();
			this.colDestino = new System.Windows.Forms.ColumnHeader();
			this.colTDestino = new System.Windows.Forms.ColumnHeader();
			this.impress�o = new System.Drawing.Printing.PrintDocument();
			this.leiaute = new Report.Layout.SimpleLayout(this.components);
			this.cmdFechar = new System.Windows.Forms.Button();
			this.cmdImprimir = new System.Windows.Forms.Button();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.quadroCrescimento.SuspendLayout();
			this.quadroPropor��o.SuspendLayout();
			this.quadroLista.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(170, 22);
			this.lblT�tulo.Text = "Lista de Telefonemas";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(1928, 48);
			this.lblDescri��o.Text = "Lista de telefonemas realizado pelo funcion�rio.";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Name = "pic�cone";
			// 
			// quadroCrescimento
			// 
			this.quadroCrescimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroCrescimento.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroCrescimento.bInfDirArredondada = true;
			this.quadroCrescimento.bInfEsqArredondada = true;
			this.quadroCrescimento.bSupDirArredondada = true;
			this.quadroCrescimento.bSupEsqArredondada = true;
			this.quadroCrescimento.Controls.Add(this.gr�ficoCrescimento);
			this.quadroCrescimento.Cor = System.Drawing.Color.Black;
			this.quadroCrescimento.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroCrescimento.LetraT�tulo = System.Drawing.Color.White;
			this.quadroCrescimento.Location = new System.Drawing.Point(8, 288);
			this.quadroCrescimento.Name = "quadroCrescimento";
			this.quadroCrescimento.Size = new System.Drawing.Size(304, 128);
			this.quadroCrescimento.TabIndex = 3;
			this.quadroCrescimento.Tamanho = 30;
			this.quadroCrescimento.T�tulo = "Crescimento de telefonemas";
			// 
			// gr�ficoCrescimento
			// 
			this.gr�ficoCrescimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoCrescimento.BackColor = System.Drawing.Color.Transparent;
			this.gr�ficoCrescimento.Dados = null;
			this.gr�ficoCrescimento.EixoX = "Dias";
			this.gr�ficoCrescimento.EixoY = "Telefonemas";
			this.gr�ficoCrescimento.EstiloDesenho = Estat�stica.Estilo.Linhas;
			this.gr�ficoCrescimento.For�arEscritaValoresX = false;
			this.gr�ficoCrescimento.FundoCor = System.Drawing.Color.Transparent;
			this.gr�ficoCrescimento.GapHorizontal = 0;
			this.gr�ficoCrescimento.GapVertical = 20;
			this.gr�ficoCrescimento.GradeHorizontal = true;
			this.gr�ficoCrescimento.GradeVertical = true;
			this.gr�ficoCrescimento.Legendas = null;
			this.gr�ficoCrescimento.Location = new System.Drawing.Point(0, 24);
			this.gr�ficoCrescimento.MaxX = -1;
			this.gr�ficoCrescimento.MaxY = 2;
			this.gr�ficoCrescimento.MinX = 0;
			this.gr�ficoCrescimento.MinY = 0;
			this.gr�ficoCrescimento.Name = "gr�ficoCrescimento";
			this.gr�ficoCrescimento.Size = new System.Drawing.Size(304, 104);
			this.gr�ficoCrescimento.TabIndex = 1;
			this.gr�ficoCrescimento.ValoresX = true;
			this.gr�ficoCrescimento.ValoresY = true;
			this.gr�ficoCrescimento.V�rticeTamanho = 5F;
			this.gr�ficoCrescimento.Vetor�nico = null;
			// 
			// quadroPropor��o
			// 
			this.quadroPropor��o.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.quadroPropor��o.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroPropor��o.bInfDirArredondada = true;
			this.quadroPropor��o.bInfEsqArredondada = true;
			this.quadroPropor��o.bSupDirArredondada = true;
			this.quadroPropor��o.bSupEsqArredondada = true;
			this.quadroPropor��o.Controls.Add(this.legenda);
			this.quadroPropor��o.Controls.Add(this.gr�ficoPropor��o);
			this.quadroPropor��o.Cor = System.Drawing.Color.Black;
			this.quadroPropor��o.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroPropor��o.LetraT�tulo = System.Drawing.Color.White;
			this.quadroPropor��o.Location = new System.Drawing.Point(320, 288);
			this.quadroPropor��o.Name = "quadroPropor��o";
			this.quadroPropor��o.Size = new System.Drawing.Size(248, 128);
			this.quadroPropor��o.TabIndex = 4;
			this.quadroPropor��o.Tamanho = 30;
			this.quadroPropor��o.T�tulo = "Propor��o de telefonemas";
			// 
			// legenda
			// 
			this.legenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.legenda.AutoSize = true;
			this.legenda.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legenda.Colunas = 1;
			this.legenda.Distanciamento = 2;
			this.legenda.Espa�amento = 5;
			this.legenda.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legenda.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.Gr�fico = this.gr�ficoPropor��o;
			this.legenda.Location = new System.Drawing.Point(8, 88);
			this.legenda.Name = "legenda";
			this.legenda.QuadradoTamanho = 4;
			this.legenda.Size = new System.Drawing.Size(72, 32);
			this.legenda.TabIndex = 2;
			// 
			// gr�ficoPropor��o
			// 
			this.gr�ficoPropor��o.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�ficoPropor��o.BackColor = System.Drawing.Color.Transparent;
			this.gr�ficoPropor��o.Dados = null;
			this.gr�ficoPropor��o.EixoX = "Eixo X";
			this.gr�ficoPropor��o.EixoY = "Eixo Y";
			this.gr�ficoPropor��o.EstiloDesenho = Estat�stica.Estilo.Pizza;
			this.gr�ficoPropor��o.For�arEscritaValoresX = false;
			this.gr�ficoPropor��o.FundoCor = System.Drawing.Color.Transparent;
			this.gr�ficoPropor��o.GapHorizontal = 0;
			this.gr�ficoPropor��o.GapVertical = 20;
			this.gr�ficoPropor��o.GradeHorizontal = true;
			this.gr�ficoPropor��o.GradeVertical = true;
			this.gr�ficoPropor��o.Legendas = null;
			this.gr�ficoPropor��o.Location = new System.Drawing.Point(72, 24);
			this.gr�ficoPropor��o.MaxX = -1;
			this.gr�ficoPropor��o.MaxY = 0;
			this.gr�ficoPropor��o.MinX = 0;
			this.gr�ficoPropor��o.MinY = 0;
			this.gr�ficoPropor��o.Name = "gr�ficoPropor��o";
			this.gr�ficoPropor��o.Size = new System.Drawing.Size(176, 104);
			this.gr�ficoPropor��o.TabIndex = 1;
			this.gr�ficoPropor��o.ValoresX = true;
			this.gr�ficoPropor��o.ValoresY = true;
			this.gr�ficoPropor��o.V�rticeTamanho = 5F;
			this.gr�ficoPropor��o.Vetor�nico = null;
			// 
			// quadroLista
			// 
			this.quadroLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroLista.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroLista.bInfDirArredondada = true;
			this.quadroLista.bInfEsqArredondada = true;
			this.quadroLista.bSupDirArredondada = true;
			this.quadroLista.bSupEsqArredondada = true;
			this.quadroLista.Controls.Add(this.lstTelefonemas);
			this.quadroLista.Cor = System.Drawing.Color.Black;
			this.quadroLista.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroLista.LetraT�tulo = System.Drawing.Color.White;
			this.quadroLista.Location = new System.Drawing.Point(8, 96);
			this.quadroLista.Name = "quadroLista";
			this.quadroLista.Size = new System.Drawing.Size(558, 184);
			this.quadroLista.TabIndex = 5;
			this.quadroLista.Tamanho = 30;
			this.quadroLista.T�tulo = "Lista de Telefonemas";
			// 
			// lstTelefonemas
			// 
			this.lstTelefonemas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstTelefonemas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.colData,
																							 this.colTelefone,
																							 this.colCidade,
																							 this.colOrigem,
																							 this.colTOrigem,
																							 this.colDestino,
																							 this.colTDestino});
			this.lstTelefonemas.FullRowSelect = true;
			this.lstTelefonemas.GridLines = true;
			this.lstTelefonemas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstTelefonemas.HideSelection = false;
			this.lstTelefonemas.Location = new System.Drawing.Point(8, 32);
			this.lstTelefonemas.Name = "lstTelefonemas";
			this.lstTelefonemas.Size = new System.Drawing.Size(542, 144);
			this.lstTelefonemas.TabIndex = 1;
			this.lstTelefonemas.View = System.Windows.Forms.View.Details;
			// 
			// colData
			// 
			this.colData.Text = "Data e Hora";
			this.colData.Width = 127;
			// 
			// colTelefone
			// 
			this.colTelefone.Text = "Telefone";
			this.colTelefone.Width = 87;
			// 
			// colCidade
			// 
			this.colCidade.Text = "Cidade";
			this.colCidade.Width = 82;
			// 
			// colOrigem
			// 
			this.colOrigem.Text = "Origem";
			this.colOrigem.Width = 73;
			// 
			// colTOrigem
			// 
			this.colTOrigem.Text = "Descri��o Origem";
			this.colTOrigem.Width = 34;
			// 
			// colDestino
			// 
			this.colDestino.Text = "Destino";
			this.colDestino.Width = 79;
			// 
			// colTDestino
			// 
			this.colTDestino.Text = "Descri��o Destino";
			this.colTDestino.Width = 34;
			// 
			// impress�o
			// 
			this.impress�o.DocumentName = "Lista de Telefonemas";
			// 
			// leiaute
			// 
			this.leiaute.AutoDistributeColumns = true;
			this.leiaute.Document = this.impress�o;
			// 
			// cmdFechar
			// 
			this.cmdFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdFechar.Location = new System.Drawing.Point(488, 424);
			this.cmdFechar.Name = "cmdFechar";
			this.cmdFechar.TabIndex = 6;
			this.cmdFechar.Text = "Fechar";
			this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
			// 
			// cmdImprimir
			// 
			this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
			this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdImprimir.Location = new System.Drawing.Point(16, 424);
			this.cmdImprimir.Name = "cmdImprimir";
			this.cmdImprimir.Size = new System.Drawing.Size(72, 23);
			this.cmdImprimir.TabIndex = 7;
			this.cmdImprimir.Text = "Imprimir";
			this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
			// 
			// printDialog
			// 
			this.printDialog.AllowPrintToFile = false;
			this.printDialog.Document = this.impress�o;
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.impress�o;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Location = new System.Drawing.Point(332, 15);
			this.printPreviewDialog.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog.Visible = false;
			// 
			// Funcion�rioTelefonemas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 454);
			this.Controls.Add(this.cmdImprimir);
			this.Controls.Add(this.cmdFechar);
			this.Controls.Add(this.quadroLista);
			this.Controls.Add(this.quadroPropor��o);
			this.Controls.Add(this.quadroCrescimento);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "Funcion�rioTelefonemas";
			this.ShowInTaskbar = true;
			this.Text = "Telefonemas";
			this.TopMost = false;
			this.Controls.SetChildIndex(this.quadroCrescimento, 0);
			this.Controls.SetChildIndex(this.quadroPropor��o, 0);
			this.Controls.SetChildIndex(this.quadroLista, 0);
			this.Controls.SetChildIndex(this.cmdFechar, 0);
			this.Controls.SetChildIndex(this.cmdImprimir, 0);
			this.quadroCrescimento.ResumeLayout(false);
			this.quadroPropor��o.ResumeLayout(false);
			this.quadroLista.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdImprimir_Click(object sender, System.EventArgs e)
		{
			if (printPreviewDialog.ShowDialog(this) == DialogResult.OK)
			{
				if (printDialog.ShowDialog(this) == DialogResult.OK)
				{
					try
					{
						leiaute.Print();
					}
					catch (Exception erro)
					{
//						Erro.Mostrar(this, erro);
					}
				}
			}
		}

		private void cmdFechar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}

