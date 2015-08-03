using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;
using Negócio.Controle;
using Apresentação.Formulários;
using Report.Layout;
using Report.Layout.Simple;

namespace Administração.Formulários
{
	public class FuncionárioAtendimentos : Apresentação.Formulários.JanelaExplicativa
	{
		private System.Windows.Forms.ListView lstAtendimentos;
		private System.Windows.Forms.ColumnHeader colDataHora;
		private System.Windows.Forms.ColumnHeader colCliente;
		private System.Windows.Forms.ColumnHeader colSetor;
		private System.Windows.Forms.Button cmdImprimir;
		private System.Windows.Forms.Button cmdFechar;
		private Report.Layout.SimpleLayout leiaute;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.ComponentModel.IContainer components = null;

		public FuncionárioAtendimentos(IControle controle, Funcionário funcionário, DateTime início, DateTime final)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			this.Text = funcionário.Nome + " [Atendimentos]";

			MostrarDados(controle, funcionário, início, final);

			leiaute.Document.DocumentName = "Relatório de Atendimentos\n" + funcionário.Nome + "\n" + início.ToShortDateString() + " - " + final.ToShortDateString();

			Column colData = new Column(typeof(Visita).GetProperty("Entrada"));
			colData.Label = "Data";
			colData.Format = "{0:dd/MM/yyyy}";
			leiaute.Columns.Add(colData);

			Column colHoraEntrada = new Column(typeof(Visita).GetProperty("Entrada"));
			colHoraEntrada.Label = "Entrada";
			colHoraEntrada.Format = "{0:hh:mm}";
			leiaute.Columns.Add(colHoraEntrada);

			Column colHoraSaída = new Column(typeof(Visita).GetProperty("Saída"));
			colHoraSaída.Label = "Saída";
			colHoraSaída.Format = "{0:hh:mm}";
			leiaute.Columns.Add(colHoraSaída);
			
			Column colCliente = new Column("Cliente", typeof(Visita), "NomesEnumerados");
			leiaute.Columns.Add(colCliente);
			
			leiaute.Columns.Add(new Column("Setor", typeof(Visita), "Setor"));

			leiaute.ChangeFontSize(10);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FuncionárioAtendimentos));
			this.lstAtendimentos = new System.Windows.Forms.ListView();
			this.colDataHora = new System.Windows.Forms.ColumnHeader();
			this.colCliente = new System.Windows.Forms.ColumnHeader();
			this.colSetor = new System.Windows.Forms.ColumnHeader();
			this.cmdImprimir = new System.Windows.Forms.Button();
			this.cmdFechar = new System.Windows.Forms.Button();
			this.leiaute = new Report.Layout.SimpleLayout(this.components);
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(174, 22);
			this.lblTítulo.Text = "Lista de atendimentos";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(674, 48);
			this.lblDescrição.Text = "Lista de atendimentos realizados pelo(a) funcionário(a).";
			// 
			// picÍcone
			// 
			this.picÍcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Location = new System.Drawing.Point(16, 16);
			this.picÍcone.Name = "picÍcone";
			this.picÍcone.Size = new System.Drawing.Size(38, 57);
			this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			// 
			// lstAtendimentos
			// 
			this.lstAtendimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstAtendimentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.colDataHora,
																							  this.colCliente,
																							  this.colSetor});
			this.lstAtendimentos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstAtendimentos.Location = new System.Drawing.Point(8, 96);
			this.lstAtendimentos.Name = "lstAtendimentos";
			this.lstAtendimentos.Size = new System.Drawing.Size(448, 216);
			this.lstAtendimentos.TabIndex = 3;
			this.lstAtendimentos.View = System.Windows.Forms.View.Details;
			// 
			// colDataHora
			// 
			this.colDataHora.Text = "Data e Hora";
			this.colDataHora.Width = 103;
			// 
			// colCliente
			// 
			this.colCliente.Text = "Cliente";
			this.colCliente.Width = 208;
			// 
			// colSetor
			// 
			this.colSetor.Text = "Setor Encaminhado";
			this.colSetor.Width = 117;
			// 
			// cmdImprimir
			// 
			this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
			this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdImprimir.Location = new System.Drawing.Point(8, 320);
			this.cmdImprimir.Name = "cmdImprimir";
			this.cmdImprimir.Size = new System.Drawing.Size(72, 23);
			this.cmdImprimir.TabIndex = 9;
			this.cmdImprimir.Text = "Imprimir";
			this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
			// 
			// cmdFechar
			// 
			this.cmdFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdFechar.Location = new System.Drawing.Point(384, 320);
			this.cmdFechar.Name = "cmdFechar";
			this.cmdFechar.TabIndex = 8;
			this.cmdFechar.Text = "Fechar";
			this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
			// 
			// leiaute
			// 
			this.leiaute.AutoDistributeColumns = true;
			this.leiaute.Document = this.printDocument;
			// 
			// printDialog
			// 
			this.printDialog.Document = this.printDocument;
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.printDocument;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Location = new System.Drawing.Point(342, 18);
			this.printPreviewDialog.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog.Visible = false;
			// 
			// FuncionárioAtendimentos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 350);
			this.Controls.Add(this.cmdImprimir);
			this.Controls.Add(this.cmdFechar);
			this.Controls.Add(this.lstAtendimentos);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "FuncionárioAtendimentos";
			this.ShowInTaskbar = true;
			this.Text = "Atendimentos";
			this.TopMost = false;
			this.Controls.SetChildIndex(this.lstAtendimentos, 0);
			this.Controls.SetChildIndex(this.cmdFechar, 0);
			this.Controls.SetChildIndex(this.cmdImprimir, 0);
			this.ResumeLayout(false);

		}
		#endregion

		public void MostrarDados(IControle controle, Funcionário funcionário, DateTime início, DateTime final)
		{
			ArrayList visitas;
			Aguarde aguarde = new Aguarde(
                "Recuperando informações no banco de dados...",
				2);

			aguarde.Show();
			aguarde.Refresh();

			visitas = controle.ObterAtendimentos(funcionário, início, final);

			aguarde.Passo("Constuindo relatório...");

			foreach (Visita visita in visitas)
			{
				ListViewItem linha = new ListViewItem();

				linha.Text = visita.Entrada.ToString("dd/MM/yyyy hh:mm");
				linha.SubItems.Add(visita.NomesEnumerados);
				linha.SubItems.Add(visita.Setor);

				lstAtendimentos.Items.Add(linha);
			}

			aguarde.Close();
			aguarde.Dispose();

			leiaute.Objects = visitas;
		}

		private void cmdFechar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdImprimir_Click(object sender, System.EventArgs e)
		{
			if (printPreviewDialog.ShowDialog(this) == DialogResult.OK)
			{
				if (printDialog.ShowDialog() == DialogResult.OK)
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
	}
}

