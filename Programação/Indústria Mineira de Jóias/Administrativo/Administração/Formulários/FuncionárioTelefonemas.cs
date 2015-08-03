using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;
using Indústria_Mineira_de_Jóias.AnáliseEstatística;
using Apresentação.Formulários;
using Report.Layout;
using Report.Layout.Simple;

namespace Administração.Formulários
{
	public class FuncionárioTelefonemas : Apresentação.Formulários.JanelaExplicativa
	{
		private Apresentação.Formulários.Quadro quadroCrescimento;
		private Apresentação.Formulários.Quadro quadroProporção;
		private Estatística.Gráfico gráficoCrescimento;
		private Estatística.Gráfico gráficoProporção;
		private Apresentação.Formulários.Quadro quadroLista;
		private System.Windows.Forms.ListView lstTelefonemas;
		private System.Windows.Forms.ColumnHeader colData;
		private System.Windows.Forms.ColumnHeader colTelefone;
		private System.Windows.Forms.ColumnHeader colOrigem;
		private System.Windows.Forms.ColumnHeader colDestino;
		private System.Windows.Forms.ColumnHeader colCidade;
		private System.Windows.Forms.ColumnHeader colTOrigem;
		private System.Windows.Forms.ColumnHeader colTDestino;
		private Estatística.Legenda legenda;
		private System.Drawing.Printing.PrintDocument impressão;
		private Report.Layout.SimpleLayout leiaute;
		private System.Windows.Forms.Button cmdFechar;
		private System.Windows.Forms.Button cmdImprimir;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.ComponentModel.IContainer components = null;

		public FuncionárioTelefonemas(Funcionário funcionário, DateTime início, DateTime final)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			MostrarDados(funcionário, início, final);
			
			leiaute.Document.DocumentName = "Relatório de Telefonemas\n" + funcionário.Nome + "\n" + início.ToShortDateString() + " - " + final.ToShortDateString();
			leiaute.Columns.Add(new Column("Data", typeof(Telefonema), "Data"));
			leiaute.Columns.Add(new Column("Hora", typeof(Telefonema), "Hora"));
			leiaute.Columns.Add(new Column("Telefone", typeof(Telefonema), "Telefone"));
			leiaute.Columns.Add(new Column("De", typeof(Telefonema), "De"));
			leiaute.Columns.Add(new Column("Para", typeof(Telefonema), "Para"));
			leiaute.Columns.Add(new Column("Cidade", typeof(Telefonema), "Cidade"));
			leiaute.ChangeFontSize(10);
		}

		private void MostrarDados(Funcionário funcionário, DateTime início, DateTime final)
		{
			/*
			ArrayList telefonemas;
			double [] crescimento;
			double [] proporção;
			Aguarde aguarde;

			aguarde = new Aguarde(
				"Recuperando e gerando estatísticas dos telefonemas...", 2);
			aguarde.Show();
			aguarde.Refresh();

			Principal.Controle.EstatísticaFuncionários.ObterTelefonemas(
				início, final, funcionário.Código,
				out telefonemas, out crescimento,
				out proporção);

			this.Text = funcionário.Nome + " [Telefonemas]";
			lblDescrição.Text = "Lista de telefonemas realizado pelo funcionário " + funcionário.Nome + ".";

			// Construir lista
			aguarde.Passo("Construindo relatório...");

			foreach (Telefonema telefonema in telefonemas)
			{
				ListViewItem linha;

				linha = new ListViewItem();
				linha.Text = telefonema.Quando.ToString("dd/MM/yyyy hh:mm:ss");
				linha.SubItems.Add(telefonema.Telefone);
				linha.SubItems.Add(telefonema.Cidade);
				linha.SubItems.Add(telefonema.Origem == null ? funcionário.Nome : telefonema.Origem);
				linha.SubItems.Add(telefonema.TOrigem.ToString());
				linha.SubItems.Add(telefonema.Destino == null ? funcionário.Nome : telefonema.Destino);
				linha.SubItems.Add(telefonema.TDestino.ToString());

				lstTelefonemas.Items.Add(linha);
			}

			gráficoCrescimento.VetorÚnico = crescimento;
			Estatística.LegendaValoresX.Data(
				gráficoCrescimento,
				início);

			gráficoProporção.VetorÚnico = proporção;
			gráficoProporção.Legendas = new string[2]
				{ funcionário.PrimeiroNome, "Outros" };

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FuncionárioTelefonemas));
			this.quadroCrescimento = new Apresentação.Formulários.Quadro();
			this.gráficoCrescimento = new Estatística.Gráfico();
			this.quadroProporção = new Apresentação.Formulários.Quadro();
			this.legenda = new Estatística.Legenda();
			this.gráficoProporção = new Estatística.Gráfico();
			this.quadroLista = new Apresentação.Formulários.Quadro();
			this.lstTelefonemas = new System.Windows.Forms.ListView();
			this.colData = new System.Windows.Forms.ColumnHeader();
			this.colTelefone = new System.Windows.Forms.ColumnHeader();
			this.colCidade = new System.Windows.Forms.ColumnHeader();
			this.colOrigem = new System.Windows.Forms.ColumnHeader();
			this.colTOrigem = new System.Windows.Forms.ColumnHeader();
			this.colDestino = new System.Windows.Forms.ColumnHeader();
			this.colTDestino = new System.Windows.Forms.ColumnHeader();
			this.impressão = new System.Drawing.Printing.PrintDocument();
			this.leiaute = new Report.Layout.SimpleLayout(this.components);
			this.cmdFechar = new System.Windows.Forms.Button();
			this.cmdImprimir = new System.Windows.Forms.Button();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.quadroCrescimento.SuspendLayout();
			this.quadroProporção.SuspendLayout();
			this.quadroLista.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(170, 22);
			this.lblTítulo.Text = "Lista de Telefonemas";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(1928, 48);
			this.lblDescrição.Text = "Lista de telefonemas realizado pelo funcionário.";
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Name = "picÍcone";
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
			this.quadroCrescimento.Controls.Add(this.gráficoCrescimento);
			this.quadroCrescimento.Cor = System.Drawing.Color.Black;
			this.quadroCrescimento.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroCrescimento.LetraTítulo = System.Drawing.Color.White;
			this.quadroCrescimento.Location = new System.Drawing.Point(8, 288);
			this.quadroCrescimento.Name = "quadroCrescimento";
			this.quadroCrescimento.Size = new System.Drawing.Size(304, 128);
			this.quadroCrescimento.TabIndex = 3;
			this.quadroCrescimento.Tamanho = 30;
			this.quadroCrescimento.Título = "Crescimento de telefonemas";
			// 
			// gráficoCrescimento
			// 
			this.gráficoCrescimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoCrescimento.BackColor = System.Drawing.Color.Transparent;
			this.gráficoCrescimento.Dados = null;
			this.gráficoCrescimento.EixoX = "Dias";
			this.gráficoCrescimento.EixoY = "Telefonemas";
			this.gráficoCrescimento.EstiloDesenho = Estatística.Estilo.Linhas;
			this.gráficoCrescimento.ForçarEscritaValoresX = false;
			this.gráficoCrescimento.FundoCor = System.Drawing.Color.Transparent;
			this.gráficoCrescimento.GapHorizontal = 0;
			this.gráficoCrescimento.GapVertical = 20;
			this.gráficoCrescimento.GradeHorizontal = true;
			this.gráficoCrescimento.GradeVertical = true;
			this.gráficoCrescimento.Legendas = null;
			this.gráficoCrescimento.Location = new System.Drawing.Point(0, 24);
			this.gráficoCrescimento.MaxX = -1;
			this.gráficoCrescimento.MaxY = 2;
			this.gráficoCrescimento.MinX = 0;
			this.gráficoCrescimento.MinY = 0;
			this.gráficoCrescimento.Name = "gráficoCrescimento";
			this.gráficoCrescimento.Size = new System.Drawing.Size(304, 104);
			this.gráficoCrescimento.TabIndex = 1;
			this.gráficoCrescimento.ValoresX = true;
			this.gráficoCrescimento.ValoresY = true;
			this.gráficoCrescimento.VérticeTamanho = 5F;
			this.gráficoCrescimento.VetorÚnico = null;
			// 
			// quadroProporção
			// 
			this.quadroProporção.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.quadroProporção.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroProporção.bInfDirArredondada = true;
			this.quadroProporção.bInfEsqArredondada = true;
			this.quadroProporção.bSupDirArredondada = true;
			this.quadroProporção.bSupEsqArredondada = true;
			this.quadroProporção.Controls.Add(this.legenda);
			this.quadroProporção.Controls.Add(this.gráficoProporção);
			this.quadroProporção.Cor = System.Drawing.Color.Black;
			this.quadroProporção.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroProporção.LetraTítulo = System.Drawing.Color.White;
			this.quadroProporção.Location = new System.Drawing.Point(320, 288);
			this.quadroProporção.Name = "quadroProporção";
			this.quadroProporção.Size = new System.Drawing.Size(248, 128);
			this.quadroProporção.TabIndex = 4;
			this.quadroProporção.Tamanho = 30;
			this.quadroProporção.Título = "Proporção de telefonemas";
			// 
			// legenda
			// 
			this.legenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.legenda.AutoSize = true;
			this.legenda.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legenda.Colunas = 1;
			this.legenda.Distanciamento = 2;
			this.legenda.Espaçamento = 5;
			this.legenda.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legenda.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.Gráfico = this.gráficoProporção;
			this.legenda.Location = new System.Drawing.Point(8, 88);
			this.legenda.Name = "legenda";
			this.legenda.QuadradoTamanho = 4;
			this.legenda.Size = new System.Drawing.Size(72, 32);
			this.legenda.TabIndex = 2;
			// 
			// gráficoProporção
			// 
			this.gráficoProporção.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráficoProporção.BackColor = System.Drawing.Color.Transparent;
			this.gráficoProporção.Dados = null;
			this.gráficoProporção.EixoX = "Eixo X";
			this.gráficoProporção.EixoY = "Eixo Y";
			this.gráficoProporção.EstiloDesenho = Estatística.Estilo.Pizza;
			this.gráficoProporção.ForçarEscritaValoresX = false;
			this.gráficoProporção.FundoCor = System.Drawing.Color.Transparent;
			this.gráficoProporção.GapHorizontal = 0;
			this.gráficoProporção.GapVertical = 20;
			this.gráficoProporção.GradeHorizontal = true;
			this.gráficoProporção.GradeVertical = true;
			this.gráficoProporção.Legendas = null;
			this.gráficoProporção.Location = new System.Drawing.Point(72, 24);
			this.gráficoProporção.MaxX = -1;
			this.gráficoProporção.MaxY = 0;
			this.gráficoProporção.MinX = 0;
			this.gráficoProporção.MinY = 0;
			this.gráficoProporção.Name = "gráficoProporção";
			this.gráficoProporção.Size = new System.Drawing.Size(176, 104);
			this.gráficoProporção.TabIndex = 1;
			this.gráficoProporção.ValoresX = true;
			this.gráficoProporção.ValoresY = true;
			this.gráficoProporção.VérticeTamanho = 5F;
			this.gráficoProporção.VetorÚnico = null;
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
			this.quadroLista.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroLista.LetraTítulo = System.Drawing.Color.White;
			this.quadroLista.Location = new System.Drawing.Point(8, 96);
			this.quadroLista.Name = "quadroLista";
			this.quadroLista.Size = new System.Drawing.Size(558, 184);
			this.quadroLista.TabIndex = 5;
			this.quadroLista.Tamanho = 30;
			this.quadroLista.Título = "Lista de Telefonemas";
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
			this.colTOrigem.Text = "Descrição Origem";
			this.colTOrigem.Width = 34;
			// 
			// colDestino
			// 
			this.colDestino.Text = "Destino";
			this.colDestino.Width = 79;
			// 
			// colTDestino
			// 
			this.colTDestino.Text = "Descrição Destino";
			this.colTDestino.Width = 34;
			// 
			// impressão
			// 
			this.impressão.DocumentName = "Lista de Telefonemas";
			// 
			// leiaute
			// 
			this.leiaute.AutoDistributeColumns = true;
			this.leiaute.Document = this.impressão;
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
			this.printDialog.Document = this.impressão;
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.impressão;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Location = new System.Drawing.Point(332, 15);
			this.printPreviewDialog.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog.Visible = false;
			// 
			// FuncionárioTelefonemas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 454);
			this.Controls.Add(this.cmdImprimir);
			this.Controls.Add(this.cmdFechar);
			this.Controls.Add(this.quadroLista);
			this.Controls.Add(this.quadroProporção);
			this.Controls.Add(this.quadroCrescimento);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "FuncionárioTelefonemas";
			this.ShowInTaskbar = true;
			this.Text = "Telefonemas";
			this.TopMost = false;
			this.Controls.SetChildIndex(this.quadroCrescimento, 0);
			this.Controls.SetChildIndex(this.quadroProporção, 0);
			this.Controls.SetChildIndex(this.quadroLista, 0);
			this.Controls.SetChildIndex(this.cmdFechar, 0);
			this.Controls.SetChildIndex(this.cmdImprimir, 0);
			this.quadroCrescimento.ResumeLayout(false);
			this.quadroProporção.ResumeLayout(false);
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

