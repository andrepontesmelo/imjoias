using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Apresenta��o.Mercadoria.Bandeja;
using Apresenta��o.Mercadoria.Etiqueta.Impress�o;
using Entidades;
using Report.Layout;
using Entidades.Etiqueta;
using Entidades.Mercadoria;
using Entidades.Privil�gio;

[assembly: ExporBot�o(Permiss�o.Nenhuma, 2, "Etiquetas", true,
    typeof(Apresenta��o.Mercadoria.Etiqueta.Impress�o.Imprimir))]

namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o
{
	public class Imprimir : Apresenta��o.Formul�rios.BaseInferior
	{
		// Atributos
        private Dictionary<string, EtiquetaFormato> hashStringFormato;
		private Aguarde			aguardeImpress�o = null;	// Somente enquanto imprime

		// Delega��es
		private delegate void DMostrarFoto(Image imagem);

		// Formul�rio
		private Apresenta��o.Formul�rios.Quadro quadroSele��o;
		private System.Windows.Forms.Label label1;
		private Apresenta��o.Mercadoria.TxtMercadoria txtRefer�ncia;
		private System.Windows.Forms.Label label2;
		private AMS.TextBox.IntegerTextBox txtQuantidade;
		private System.Windows.Forms.Button cmdNovo;
		private AMS.TextBox.NumericTextBox txtPeso;
		private Apresenta��o.Mercadoria.QuadroFoto quadroMercadoria;
		private System.Windows.Forms.ComboBox cmbFormato;
		private BandejaEtiqueta bandeja;
		private System.Windows.Forms.Label lblPeso;
		private Apresenta��o.Formul�rios.Quadro quadroBandeja;
		private Apresenta��o.Formul�rios.Quadro quadroImpress�o;
		private Apresenta��o.Formul�rios.Op��o op��oImprimir;
		private System.Windows.Forms.PrintDialog printDlg;
		private System.Drawing.Printing.PrintDocument printDoc;
		private System.Windows.Forms.CheckBox chkFormatoAutom�tico;
		private Apresenta��o.Formul�rios.Quadro quadroDica;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblFormato;
        private Op��o op��oEditarEtiquetas;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i a base inferior
		/// </summary>
		public Imprimir()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
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

				this.txtRefer�ncia.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Imprimir));
            this.quadroSele��o = new Apresenta��o.Formul�rios.Quadro();
            this.chkFormatoAutom�tico = new System.Windows.Forms.CheckBox();
            this.txtPeso = new AMS.TextBox.NumericTextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.cmdNovo = new System.Windows.Forms.Button();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.txtQuantidade = new AMS.TextBox.IntegerTextBox();
            this.txtRefer�ncia = new Apresenta��o.Mercadoria.TxtMercadoria();
            this.lblFormato = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quadroMercadoria = new Apresenta��o.Mercadoria.QuadroFoto();
            this.bandeja = new Apresenta��o.Mercadoria.Etiqueta.Impress�o.BandejaEtiqueta();
            this.quadroBandeja = new Apresenta��o.Formul�rios.Quadro();
            this.quadroImpress�o = new Apresenta��o.Formul�rios.Quadro();
            this.op��oEditarEtiquetas = new Apresenta��o.Formul�rios.Op��o();
            this.op��oImprimir = new Apresenta��o.Formul�rios.Op��o();
            this.printDlg = new System.Windows.Forms.PrintDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.quadroDica = new Apresenta��o.Formul�rios.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroSele��o.SuspendLayout();
            this.quadroBandeja.SuspendLayout();
            this.quadroImpress�o.SuspendLayout();
            this.quadroDica.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroDica);
            this.esquerda.Controls.Add(this.quadroImpress�o);
            this.esquerda.Size = new System.Drawing.Size(187, 464);
            this.esquerda.Controls.SetChildIndex(this.quadroImpress�o, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroDica, 0);
            // 
            // quadroSele��o
            // 
            this.quadroSele��o.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroSele��o.bInfDirArredondada = true;
            this.quadroSele��o.bInfEsqArredondada = true;
            this.quadroSele��o.bSupDirArredondada = true;
            this.quadroSele��o.bSupEsqArredondada = true;
            this.quadroSele��o.Controls.Add(this.chkFormatoAutom�tico);
            this.quadroSele��o.Controls.Add(this.txtPeso);
            this.quadroSele��o.Controls.Add(this.lblPeso);
            this.quadroSele��o.Controls.Add(this.cmdNovo);
            this.quadroSele��o.Controls.Add(this.cmbFormato);
            this.quadroSele��o.Controls.Add(this.txtQuantidade);
            this.quadroSele��o.Controls.Add(this.txtRefer�ncia);
            this.quadroSele��o.Controls.Add(this.lblFormato);
            this.quadroSele��o.Controls.Add(this.label1);
            this.quadroSele��o.Controls.Add(this.label2);
            this.quadroSele��o.Cor = System.Drawing.Color.Black;
            this.quadroSele��o.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroSele��o.LetraT�tulo = System.Drawing.Color.White;
            this.quadroSele��o.Location = new System.Drawing.Point(200, 24);
            this.quadroSele��o.MostrarBot�oMinMax = false;
            this.quadroSele��o.Name = "quadroSele��o";
            this.quadroSele��o.Size = new System.Drawing.Size(352, 168);
            this.quadroSele��o.TabIndex = 0;
            this.quadroSele��o.Tamanho = 30;
            this.quadroSele��o.T�tulo = "Etiqueta a ser impressa";
            // 
            // chkFormatoAutom�tico
            // 
            this.chkFormatoAutom�tico.BackColor = System.Drawing.Color.Transparent;
            this.chkFormatoAutom�tico.Checked = true;
            this.chkFormatoAutom�tico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormatoAutom�tico.Location = new System.Drawing.Point(16, 128);
            this.chkFormatoAutom�tico.Name = "chkFormatoAutom�tico";
            this.chkFormatoAutom�tico.Size = new System.Drawing.Size(240, 40);
            this.chkFormatoAutom�tico.TabIndex = 9;
            this.chkFormatoAutom�tico.Text = "Escolher formato automaticamente, conforme escolhas passadas.";
            this.chkFormatoAutom�tico.UseVisualStyleBackColor = false;
            // 
            // txtPeso
            // 
            this.txtPeso.AllowNegative = false;
            this.txtPeso.DigitsInGroup = 0;
            this.txtPeso.Enabled = false;
            this.txtPeso.Flags = 65536;
            this.txtPeso.Location = new System.Drawing.Point(16, 96);
            this.txtPeso.MaxDecimalPlaces = 1;
            this.txtPeso.MaxWholeDigits = 9;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Prefix = "";
            this.txtPeso.RangeMax = 1.7976931348623157E+308;
            this.txtPeso.RangeMin = -1.7976931348623157E+308;
            this.txtPeso.Size = new System.Drawing.Size(152, 20);
            this.txtPeso.TabIndex = 3;
            this.txtPeso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // lblPeso
            // 
            this.lblPeso.Enabled = false;
            this.lblPeso.Location = new System.Drawing.Point(16, 80);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(72, 16);
            this.lblPeso.TabIndex = 2;
            this.lblPeso.Text = "Peso:";
            // 
            // cmdNovo
            // 
            this.cmdNovo.Enabled = false;
            this.cmdNovo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNovo.Location = new System.Drawing.Point(264, 136);
            this.cmdNovo.Name = "cmdNovo";
            this.cmdNovo.Size = new System.Drawing.Size(75, 23);
            this.cmdNovo.TabIndex = 6;
            this.cmdNovo.Text = "&Adicionar";
            this.cmdNovo.Click += new System.EventHandler(this.cmdNovo_Click);
            // 
            // cmbFormato
            // 
            this.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormato.Location = new System.Drawing.Point(187, 55);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(152, 21);
            this.cmbFormato.Sorted = true;
            this.cmbFormato.TabIndex = 8;
            this.cmbFormato.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFormato_KeyUp);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.AllowNegative = false;
            this.txtQuantidade.DigitsInGroup = 0;
            this.txtQuantidade.Flags = 65536;
            this.txtQuantidade.Location = new System.Drawing.Point(187, 96);
            this.txtQuantidade.MaxDecimalPlaces = 0;
            this.txtQuantidade.MaxWholeDigits = 9;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Prefix = "";
            this.txtQuantidade.RangeMax = 1.7976931348623157E+308;
            this.txtQuantidade.RangeMin = -1.7976931348623157E+308;
            this.txtQuantidade.Size = new System.Drawing.Size(152, 20);
            this.txtQuantidade.TabIndex = 5;
            this.txtQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtRefer�ncia
            // 
            this.txtRefer�ncia.ControlePeso = this.txtPeso;
            this.txtRefer�ncia.Location = new System.Drawing.Point(16, 56);
            this.txtRefer�ncia.Name = "txtRefer�ncia";
            this.txtRefer�ncia.Refer�ncia = "";
            this.txtRefer�ncia.Size = new System.Drawing.Size(152, 20);
            this.txtRefer�ncia.TabIndex = 1;
            this.txtRefer�ncia.Refer�nciaConfirmada += new System.EventHandler(this.txtRefer�ncia_Refer�nciaConfirmada);
            this.txtRefer�ncia.Leave += new System.EventHandler(this.txtRefer�ncia_Leave);
            this.txtRefer�ncia.Refer�nciaAlterada += new System.EventHandler(this.txtRefer�ncia_Refer�nciaAlterada);
            this.txtRefer�ncia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(187, 39);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(48, 13);
            this.lblFormato.TabIndex = 7;
            this.lblFormato.Text = "Formato:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refer�ncia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantidade de etiquetas:";
            // 
            // quadroMercadoria
            // 
            this.quadroMercadoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroMercadoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(215)))));
            this.quadroMercadoria.bInfDirArredondada = true;
            this.quadroMercadoria.bInfEsqArredondada = true;
            this.quadroMercadoria.bSupDirArredondada = true;
            this.quadroMercadoria.bSupEsqArredondada = true;
            this.quadroMercadoria.Cor = System.Drawing.Color.Black;
            this.quadroMercadoria.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroMercadoria.LetraT�tulo = System.Drawing.Color.White;
            this.quadroMercadoria.Location = new System.Drawing.Point(568, 24);
            this.quadroMercadoria.MostrarBot�oMinMax = false;
            this.quadroMercadoria.Name = "quadroMercadoria";
            this.quadroMercadoria.Size = new System.Drawing.Size(216, 168);
            this.quadroMercadoria.TabIndex = 11;
            this.quadroMercadoria.Tamanho = 30;
            this.quadroMercadoria.T�tulo = "Mercadoria";
            // 
            // bandeja
            // 
            this.bandeja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bandeja.BackColor = System.Drawing.Color.White;
            this.bandeja.Location = new System.Drawing.Point(1, 24);
            this.bandeja.MostrarBarraFerramentas = true;
            this.bandeja.MostrarPre�o = false;
            this.bandeja.MostrarSele��oTabela = false;
            this.bandeja.MostrarStatus = true;
            this.bandeja.Name = "bandeja";
            this.bandeja.Ordena��oRefer�ncia = false;
            this.bandeja.PermitirSele��oTabela = false;
            this.bandeja.Size = new System.Drawing.Size(582, 207);
            this.bandeja.TabIndex = 6;
            this.bandeja.SaquinhoExclu�do += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandeja_SaquinhoExclu�do);
            this.bandeja.Sele��oMudou += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandeja_Sele��oMudou);
            // 
            // quadroBandeja
            // 
            this.quadroBandeja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroBandeja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroBandeja.bInfDirArredondada = false;
            this.quadroBandeja.bInfEsqArredondada = false;
            this.quadroBandeja.bSupDirArredondada = true;
            this.quadroBandeja.bSupEsqArredondada = true;
            this.quadroBandeja.Controls.Add(this.bandeja);
            this.quadroBandeja.Cor = System.Drawing.Color.Black;
            this.quadroBandeja.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroBandeja.LetraT�tulo = System.Drawing.Color.White;
            this.quadroBandeja.Location = new System.Drawing.Point(200, 208);
            this.quadroBandeja.MostrarBot�oMinMax = false;
            this.quadroBandeja.Name = "quadroBandeja";
            this.quadroBandeja.Size = new System.Drawing.Size(584, 232);
            this.quadroBandeja.TabIndex = 12;
            this.quadroBandeja.Tamanho = 30;
            this.quadroBandeja.T�tulo = "Itens a serem impressos";
            // 
            // quadroImpress�o
            // 
            this.quadroImpress�o.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpress�o.bInfDirArredondada = true;
            this.quadroImpress�o.bInfEsqArredondada = true;
            this.quadroImpress�o.bSupDirArredondada = true;
            this.quadroImpress�o.bSupEsqArredondada = true;
            this.quadroImpress�o.Controls.Add(this.op��oEditarEtiquetas);
            this.quadroImpress�o.Controls.Add(this.op��oImprimir);
            this.quadroImpress�o.Cor = System.Drawing.Color.Black;
            this.quadroImpress�o.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpress�o.LetraT�tulo = System.Drawing.Color.White;
            this.quadroImpress�o.Location = new System.Drawing.Point(7, 139);
            this.quadroImpress�o.MostrarBot�oMinMax = false;
            this.quadroImpress�o.Name = "quadroImpress�o";
            this.quadroImpress�o.Size = new System.Drawing.Size(160, 80);
            this.quadroImpress�o.TabIndex = 1;
            this.quadroImpress�o.Tamanho = 30;
            this.quadroImpress�o.T�tulo = "Impress�o";
            // 
            // op��oEditarEtiquetas
            // 
            this.op��oEditarEtiquetas.BackColor = System.Drawing.Color.Transparent;
            this.op��oEditarEtiquetas.Descri��o = "Editar formatos...";
            this.op��oEditarEtiquetas.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oEditarEtiquetas.Imagem")));
            this.op��oEditarEtiquetas.Location = new System.Drawing.Point(8, 52);
            this.op��oEditarEtiquetas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oEditarEtiquetas.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oEditarEtiquetas.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oEditarEtiquetas.Name = "op��oEditarEtiquetas";
            this.op��oEditarEtiquetas.Size = new System.Drawing.Size(150, 20);
            this.op��oEditarEtiquetas.TabIndex = 2;
            this.op��oEditarEtiquetas.Click += new System.EventHandler(this.op��oEditarEtiquetas_Click);
            // 
            // op��oImprimir
            // 
            this.op��oImprimir.BackColor = System.Drawing.Color.Transparent;
            this.op��oImprimir.Descri��o = "Imprimir";
            this.op��oImprimir.Enabled = false;
            this.op��oImprimir.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oImprimir.Imagem")));
            this.op��oImprimir.Location = new System.Drawing.Point(8, 32);
            this.op��oImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oImprimir.Name = "op��oImprimir";
            this.op��oImprimir.Size = new System.Drawing.Size(150, 24);
            this.op��oImprimir.TabIndex = 1;
            this.op��oImprimir.Click += new System.EventHandler(this.op��oImprimir_Click);
            // 
            // printDlg
            // 
            this.printDlg.AllowPrintToFile = false;
            this.printDlg.AllowSomePages = true;
            this.printDlg.Document = this.printDoc;
            // 
            // printDoc
            // 
            this.printDoc.DocumentName = "Etiquetas";
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            this.printDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDoc_EndPrint);
            // 
            // quadroDica
            // 
            this.quadroDica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroDica.bInfDirArredondada = true;
            this.quadroDica.bInfEsqArredondada = true;
            this.quadroDica.bSupDirArredondada = true;
            this.quadroDica.bSupEsqArredondada = true;
            this.quadroDica.Controls.Add(this.label3);
            this.quadroDica.Cor = System.Drawing.Color.Black;
            this.quadroDica.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDica.LetraT�tulo = System.Drawing.Color.White;
            this.quadroDica.Location = new System.Drawing.Point(7, 13);
            this.quadroDica.MostrarBot�oMinMax = false;
            this.quadroDica.Name = "quadroDica";
            this.quadroDica.Size = new System.Drawing.Size(160, 120);
            this.quadroDica.TabIndex = 2;
            this.quadroDica.Tamanho = 30;
            this.quadroDica.T�tulo = "Dica";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 80);
            this.label3.TabIndex = 1;
            this.label3.Text = "Adicione as refer�ncias que deseja imprimir, sem se preocupar com o formato do pa" +
                "pel. Deixe que o programa organize a impress�o para voc�.";
            // 
            // Imprimir
            // 
            this.Controls.Add(this.quadroBandeja);
            this.Controls.Add(this.quadroSele��o);
            this.Controls.Add(this.quadroMercadoria);
            this.Imagem = Resource.Etiqueta;
            this.Name = "Imprimir";
            this.Size = new System.Drawing.Size(800, 464);
            this.Controls.SetChildIndex(this.quadroMercadoria, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroSele��o, 0);
            this.Controls.SetChildIndex(this.quadroBandeja, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroSele��o.ResumeLayout(false);
            this.quadroSele��o.PerformLayout();
            this.quadroBandeja.ResumeLayout(false);
            this.quadroImpress�o.ResumeLayout(false);
            this.quadroDica.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre quando se clica em novo
		/// </summary>
		private void cmdNovo_Click(object sender, System.EventArgs e)
		{
			Entidades.Mercadoria.Mercadoria mercadoria;
			int quantidadeCerta;

			/* Verificar se os campos est�o preenchidos */

			// Verificar formato
			if (cmbFormato.SelectedItem == null)
			{
				MessageBox.Show(
					this.ParentForm,
					"Formato para etiqueta n�o foi especificado!",
					"Impress�o de etiquetas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);

				cmbFormato.Focus();

				return;
			}

			// Verificar peso
			if (txtPeso.Enabled && txtPeso.Double <= 0)
			{
				MessageBox.Show(
					this.ParentForm,
					"Peso para mercadoria n�o foi especificado corretamente!",
					"Impress�o de etiquetas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);

				txtPeso.Focus();

				return;
			}

			// Verificar quantidade
			try
			{
				quantidadeCerta = int.Parse(txtQuantidade.Text);
			} 
			catch (Exception)
			{	
				MessageBox.Show(
					this.ParentForm,
					"Quantidade de etiquetas n�o foi especificado!",
					"Impress�o de etiquetas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);

				txtQuantidade.Focus();
				
				return;
			}

			Cursor = Cursors.WaitCursor;

#if !DEBUG
			try
#endif
			{
				// Remove no caso de altera��o
				if (cmdNovo.Tag != null)
				{
					SaquinhoEtiqueta saquinho = (SaquinhoEtiqueta) cmdNovo.Tag;
                    bandeja.Remover(saquinho);
				}
				
                // Adiciona nova mercadoria 
				{
                    mercadoria = txtRefer�ncia.Mercadoria;

					if (mercadoria == null)
					{
						mercadoria            = new Entidades.Mercadoria.Mercadoria(txtRefer�ncia.Refer�ncia, Entidades.Tabela.TabelaPadr�o);
						mercadoria.Peso       = (txtPeso.Text.Length == 0 ? 0 : double.Parse(txtPeso.Text));
					}
					else if (txtPeso.Enabled)
						mercadoria.Peso		  = double.Parse(txtPeso.Text);

					// Mapear formato para mercadoria
					if (cmbFormato.Tag != cmbFormato.SelectedItem)
						MapearEtiquetaMercadoria();

					// Inserir na bandeja
					bandeja.Adicionar(
						new SaquinhoEtiqueta(
						mercadoria,
						quantidadeCerta,
						(EtiquetaFormato) cmbFormato.SelectedItem));

                    op��oImprimir.Enabled = bandeja.Count > 0;

					// Reposiocionar cursor
					txtRefer�ncia.Txt.Text = "";
					cmdNovo.Enabled = false;
					
					txtRefer�ncia.Txt.Focus();
				}
			}
#if !DEBUG
			catch
			{
				MessageBox.Show(
					this.ParentForm,
					"Ocorreu um erro ao montar as informa��es da mercadorias. Por favor, reveja os dados fornecidos",
					"Impress�o de etiquetas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
#endif
#if !DEBUG
			finally
#endif
			{
				Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Mapea etiqueta para mercadoria
		/// </summary>
		private void MapearEtiquetaMercadoria()
		{
			EtiquetaFormato    etiqueta;
			EtiquetaMercadoria mapeamento;
			string             refer�ncia;
			int                d�gito;

			Entidades.Mercadoria.Mercadoria.DesmascararRefer�ncia(txtRefer�ncia.Refer�ncia, out refer�ncia, out d�gito);
			etiqueta   = (EtiquetaFormato) cmbFormato.SelectedItem;
			mapeamento = EtiquetaMercadoria.ObterEtiquetaMercadoria(refer�ncia);

			if (mapeamento == null)
			{
				mapeamento = new EtiquetaMercadoria(refer�ncia, etiqueta.Formato, false);
				mapeamento.Cadastrar();
			}
			else
			{
				mapeamento.Formato = etiqueta.Formato;
				mapeamento.Atualizar();
			}
		}

		/// <summary>
		/// Ocorre quando a refer�ncia perde o foco
		/// </summary>
		private void txtRefer�ncia_Leave(object sender, System.EventArgs e)
		{
			PrepararRefer�ncia();
		}
		
		/// <summary>
		/// Prepara dados ap�s preenchimento da refer�ncia
		/// </summary>
        private void PrepararRefer�ncia()
        {
            txtQuantidade.Text = "1";

            if (txtRefer�ncia.Refer�ncia.Length == 16)
            {
                Entidades.Mercadoria.Mercadoria mercadoria;

                mercadoria = txtRefer�ncia.Mercadoria;

                if (mercadoria != null)
                {
                    PrepararMercadoria(mercadoria);
                    cmdNovo.Enabled = true;
                }
                else
                {
                    if (!txtPeso.Enabled)
                        txtPeso.Text = "";

                    lblPeso.Enabled = txtPeso.Enabled = true;
                    cmdNovo.Enabled = false;
                }
            }
            else
            {
                if (!txtPeso.Enabled)
                    txtPeso.Text = "";

                lblPeso.Enabled = txtPeso.Enabled = true;
                cmdNovo.Enabled = false;
            }

            if (!txtPeso.Enabled)
                txtQuantidade.Focus();
            else
                txtPeso.Focus();
        }

        private delegate void PrepararMercadoriaDelegate(Entidades.Mercadoria.Mercadoria mercadoria);

		/// <summary>
		/// Prepara configura��o de etiquetas para mercadoria
		/// </summary>
		/// <param name="mercadoria">Mercadoria entrada</param>
		private void PrepararMercadoria(Entidades.Mercadoria.Mercadoria mercadoria)
		{
            if (cmbFormato.InvokeRequired)
            {
                PrepararMercadoriaDelegate m�todo = new PrepararMercadoriaDelegate(PrepararMercadoria);
                cmbFormato.BeginInvoke(m�todo, mercadoria);
            }
            else
            {

                EtiquetaMercadoria etiqueta;

                if (!mercadoria.DePeso)
                    txtPeso.Text = mercadoria.Peso.ToString();

                lblPeso.Enabled = txtPeso.Enabled = mercadoria.DePeso;

                if (chkFormatoAutom�tico.Checked)
                {
                    // Verificar mapeamento de etiqueta
                    etiqueta = EtiquetaMercadoria.ObterEtiquetaMercadoria(mercadoria.Refer�nciaNum�rica);

                    if (etiqueta != null && cmbFormato.Items.Count > 0)
                    {
                        if ((EtiquetaFormato)cmbFormato.SelectedItem != hashStringFormato[etiqueta.Formato])
                        {
                            if (cmbFormato.SelectedItem != null)
                            {
                                Bal�oEtiquetaMapeada bal�o;

                                bal�o = new Bal�oEtiquetaMapeada();
                                bal�o.ShowBalloon(cmbFormato);

                                ParentForm.Focus();
                            }

                            cmbFormato.Tag = cmbFormato.SelectedItem = hashStringFormato[etiqueta.Formato];
                        }
                    }
                    else
                        cmbFormato.Tag = null;
                }

                quadroMercadoria.MostrarFoto(mercadoria);
            }
		}

		/// <summary>
		/// Ocorre quando se pressiona alguma tecla na caixa de texto
		/// </summary>
		private void txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtRefer�ncia.Txt.Focused && txtRefer�ncia.Txt.Text.Length != txtRefer�ncia.Txt.MaxLength)
					return;

				Control pr�ximo = this.GetNextControl((Control) sender, true);

				while (pr�ximo is Label || pr�ximo is PictureBox)
					pr�ximo = this.GetNextControl(pr�ximo, true);

				TextBox txt     = pr�ximo as TextBox;
				
				pr�ximo.Focus();
				
				if (txt != null)
					txt.SelectAll();
				
				if ((sender.Equals(txtQuantidade))
					&& (txtPeso.Enabled == false))
					cmdNovo.Focus();

			}
		}

		/// <summary>
		/// Ocorre ao alterar a refer�ncia
		/// </summary>
		private void txtRefer�ncia_Refer�nciaAlterada(object sender, System.EventArgs e)
		{
			if (!txtPeso.Enabled)
				txtPeso.Text = "";

			if (cmdNovo.Tag != null)
			{
				cmdNovo.Text = "&Adicionar";
				cmdNovo.Tag = null;
			}

			if (txtRefer�ncia.Txt.Text.Length == txtRefer�ncia.Txt.MaxLength && txtRefer�ncia.Focused)
			{
				Entidades.Mercadoria.Mercadoria mercadoria = txtRefer�ncia.Mercadoria;

				if (mercadoria != null)
					quadroMercadoria.MostrarFoto(mercadoria);
				else
					quadroMercadoria.MostrarLogoIMJ();
			}
			else if (!quadroMercadoria.MostrandoLogo)
				quadroMercadoria.MostrarLogoIMJ();
		}

		/// <summary>
		/// Mostra dados da mercadoria
		/// </summary>
		private void txtRefer�ncia_Refer�nciaConfirmada(object sender, System.EventArgs e)
		{
			PrepararRefer�ncia();
		}

        ///// <summary>
        ///// Ocorre ao redimensionar o controle
        ///// </summary>
        //private void Imprimir_Resize(object sender, System.EventArgs e)
        //{
        //    quadroMercadoria.MostrarFoto();
        //}

        private delegate void CarregarFormatoEtiquetasDelegate();

		/// <summary>
		/// Carrega formato das etiquetas
		/// </summary>
        private void CarregarFormatoEtiquetas()
        {
            AguardeDB.Mostrar();

            try
            {
                if (cmbFormato.InvokeRequired)
                {
                    CarregarFormatoEtiquetasDelegate m�todo = new CarregarFormatoEtiquetasDelegate(CarregarFormatoEtiquetas);
                    cmbFormato.BeginInvoke(m�todo);
                }
                else
                {
                    EtiquetaFormato[] etiquetas = EtiquetaFormato.ObterEtiquetas();

                    cmbFormato.Items.Clear();
                    cmbFormato.Items.AddRange(etiquetas);

                    hashStringFormato = new Dictionary<string, EtiquetaFormato>(StringComparer.Ordinal);

                    foreach (EtiquetaFormato etiqueta in etiquetas)
                        hashStringFormato.Add(etiqueta.Formato, etiqueta);
                }
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }
        
		/// <summary>
		/// Calcula o n�mero de etiquetas para os
		/// formatos selecionados
		/// </summary>
		/// <param name="etiquetas">Formatos de etiquetas selecionados</param>
		public int CalcularN�meroEtiquetas(EtiquetaFormato [] etiquetas)
		{
			int quantidade = 0;

			foreach (SaquinhoEtiqueta saquinho in bandeja)
			{
				for (int i = 0; i < etiquetas.Length; i++)
					if (saquinho.Etiqueta == etiquetas[i])
						quantidade += Convert.ToInt32(saquinho.Quantidade);
			}

			return quantidade;
		}

		/// <summary>
		/// Obt�m formatos de etiquetas a serem impressas
		/// </summary>
		/// <returns>Formatos a serem impressos</returns>
		private EtiquetaFormato [] ObterFormatosBandeja()
		{
			ArrayList etiquetas = new ArrayList();

			foreach (SaquinhoEtiqueta saquinho in bandeja)
				if (!etiquetas.Contains(saquinho.Etiqueta))
					etiquetas.Add(saquinho.Etiqueta);

			return (EtiquetaFormato []) etiquetas.ToArray(typeof(EtiquetaFormato));
		}

		/// <summary>
		/// Ocorre ao solicitar impress�o
		/// </summary>
		private void op��oImprimir_Click(object sender, System.EventArgs e)
		{
			EtiquetaFormato [] etiquetas = ObterFormatosBandeja();

            using (Aguarde aguarde = new Aguarde("Reobtendo configura��o dos formatos", etiquetas.Length))
            {
                aguarde.Abrir();

                foreach (EtiquetaFormato etiqueta in etiquetas)
                {
                    aguarde.Passo("Reobtendo configura��o do formato " + etiqueta.Formato);
                    etiqueta.ReobterInforma��es();
                }

                aguarde.Close();
            }

			using (ImprimirEscolha dlg = new ImprimirEscolha(etiquetas, new ImprimirEscolha.CalcularEtiquetas(CalcularN�meroEtiquetas)))
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ImprimirEtiquetas(dlg.Sele��o, dlg.LayoutEtiquetas);
				}
			}
		}

		/// <summary>
		/// Imprime etiquetas
		/// </summary>
		/// <param name="etiquetas">Etiquetas a serem impressas</param>
		/// <param name="layout">Layout de etiquetas</param>
		private void ImprimirEtiquetas(EtiquetaFormato [] etiquetas, LabelLayout layout)
		{
            ArrayList saquinhosImpressos = new ArrayList();

			int deEtiqueta, at�Etiqueta;	// Sele��o de etiquetas a serem impressas
			int nEtiquetas;					// Total de etiquetas a serem impressas
			int etiquetasP�gina;			// Etiquetas por p�gina
			int iEtiqueta;					// Iterador

			nEtiquetas      = CalcularN�meroEtiquetas(etiquetas);
			etiquetasP�gina = layout.LabelsPerPage;

			printDlg.PrinterSettings.MaximumPage = (int) Math.Ceiling(nEtiquetas / (float) etiquetasP�gina);
			printDlg.PrinterSettings.MinimumPage = 1;
			printDlg.PrinterSettings.DefaultPageSettings.PaperSize = layout.PaperSize;
			printDlg.PrinterSettings.FromPage = 1;
			printDlg.PrinterSettings.ToPage = printDlg.PrinterSettings.MaximumPage;

			if (printDlg.ShowDialog(this.ParentForm) != DialogResult.OK)
			{
				MessageBox.Show(this, "Impress�o cancelada pelo usu�rio", "Impress�o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);	
				return;
			}

			aguardeImpress�o = new Aguarde(
					   "Preparando impress�o...",
					   2 + printDlg.PrinterSettings.ToPage - printDlg.PrinterSettings.FromPage,
					   "Imprimindo etiquetas",
					   "Aguarde enquanto o sistema imprime as etiquetas solicitadas.");

			// Mostrar janela de espera
            aguardeImpress�o.Abrir();
			
			aguardeImpress�o.Tag = 0;			// Usado para numera��o de p�gina

			try
			{
				// Preparar impress�o
				layout.Document = printDoc;
				deEtiqueta      = (printDlg.PrinterSettings.FromPage - 1) * etiquetasP�gina;
				at�Etiqueta     = (printDlg.PrinterSettings.ToPage) * etiquetasP�gina - 1;
				iEtiqueta       = 0;

				// Inserir objetos de impress�o
				layout.Objects = new ArrayList();

				// Atualizando dados
				aguardeImpress�o.Passo("Sincronizando dados com o banco de dados");
				bandeja.AtualizaObjetosInstr�nsecosDosSaquinhos();

				// Formata a impress�o
				aguardeImpress�o.Passo("Formatando dados para impress�o de etiquetas");
 
				foreach (SaquinhoEtiqueta saquinho in bandeja)
				{
					/* Verificar se saquinho cont�m formato a ser
						* impresso. N�o � a melhor implementa��o,
						* por�m o n�mero de formatos � bem pequeno,
						* levando a um pior desempenho caso utilizado
						* busca bin�ria, j� que deve ordenar os itens.
						*/
					for (int i = 0; i < etiquetas.Length; i++)
						if (saquinho.Etiqueta == etiquetas[i])
						{
#if DEBUG
                            if (saquinho.Mercadoria == null)
                                throw new NullReferenceException("Mercadoria de saquinho est� nula!");
#endif
							if (iEtiqueta >= deEtiqueta && iEtiqueta <= at�Etiqueta)
							{
								layout.Objects.Add(
									new RepeatedObject(
									layout.Items[i],
									saquinho.Mercadoria,
									( Convert.ToInt32(saquinho.Quantidade) > at�Etiqueta - iEtiqueta + 1
									? at�Etiqueta - iEtiqueta + 1
									: Convert.ToInt32(saquinho.Quantidade))));

                                saquinho.Impresso = true;

                                if (saquinhosImpressos.Contains(saquinho)) throw new Exception("Lista ja contem o item de etiqueta");
                                saquinhosImpressos.Add(saquinho);
							}
							else if (iEtiqueta <= at�Etiqueta && iEtiqueta + saquinho.Quantidade >= deEtiqueta)
							{
								layout.Objects.Add(
									new RepeatedObject(
									layout.Items[i],
									saquinho.Mercadoria,
									Convert.ToInt32(saquinho.Quantidade) - (deEtiqueta - iEtiqueta) > at�Etiqueta - iEtiqueta + 1
									? at�Etiqueta - iEtiqueta + 1
									: Convert.ToInt32(saquinho.Quantidade) - (deEtiqueta - iEtiqueta)));

                                saquinho.Impresso = true;

                                if (saquinhosImpressos.Contains(saquinho)) throw new Exception("Lista ja contem o item de etiqueta");
                                saquinhosImpressos.Add(saquinho);
							}

							iEtiqueta += Convert.ToInt32(saquinho.Quantidade);
						}
				}

				bool loop;

				do
				{
#if !DEBUG
					try
#endif
				{
					printDoc.Print();

					loop = false;
				}
#if !DEBUG
					catch (Exception e)
					{
						loop = MessageBox.Show(
							this.ParentForm,
							"N�o foi poss�vel imprimir o documento. Verifique se a impressora est� ligada e conectada corretamente ao computador.",
							"Impress�o de etiquetas - " + e.Message,
							MessageBoxButtons.RetryCancel) == DialogResult.Retry;

						if (loop)
						{
							printDlg.AllowSomePages = false;
							printDlg.ShowDialog(this.ParentForm);
						}
					}
#endif
				} while (loop);
			}
			finally
			{
				layout.Dispose();
                aguardeImpress�o.Close();
                aguardeImpress�o.Dispose();
                aguardeImpress�o = null;
			}

            bandeja.FoiImpresso(saquinhosImpressos);

            op��oImprimir.Enabled = true;
		}

		/// <summary>
		/// Ocorre ao iniciar impress�o de p�gina
		/// </summary>
		private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int p�gina = (int) aguardeImpress�o.Tag + 1;

			aguardeImpress�o.Passo("Imprimindo p�gina " + p�gina.ToString());

			aguardeImpress�o.Tag = p�gina;
		}

		/// <summary>
		/// Ocorre ao terminar impress�o
		/// </summary>
		private void printDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			aguardeImpress�o.Close();
			aguardeImpress�o.Dispose();
		}

		/// <summary>
		/// Ocorre ao carregar pela primeira vez.
		/// </summary>
		public override void AoCarregarCompletamente(Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            //if (splash != null)
            //    splash.Mensagem = "Criado ambiente de impress�o";

            printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();

            txtRefer�ncia.Tabela = Tabela.TabelaPadr�o;
            bandeja.Tabela = Tabela.TabelaPadr�o;
		}

        /// <summary>
        /// Ocorre ao exibir formul�rio.
        /// </summary>
        protected override void AoExibir()
        {
            base.AoExibir();

            /* Formato carregado toda vez que exibido para garantir
             * que novos formatos encontram-se na base inferior.
             */

            CarregarFormatoEtiquetas();
        }

		/// <summary>
		/// Ocorre ao soltar uma tecla no cmbFormato
		/// </summary>
		private void cmbFormato_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				cmdNovo.Focus();
		}

		/// <summary>
		/// Ocorre ao pressionar alguma tecla no txtPeso
		/// </summary>
		private void txtPeso_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			char separadorDecimais = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToCharArray()[0];

			if (e.KeyChar == separadorDecimais)
				return;

			switch (e.KeyChar)
			{
				/* Aceitar tanto ponto quanto v�rgula para separa��o de decimais */
				case '.':
				case ',':
					txtPeso.SelectedText = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
					break;
			}
		}

        private void bandeja_SaquinhoExclu�do(Apresenta��o.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            op��oImprimir.Enabled = bandeja.Count > 0;
        }

        private void bandeja_Sele��oMudou(Apresenta��o.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            if (saquinho != null)
            {
                SaquinhoEtiqueta saquinhoCofre;

                /* Garantir que nenhum OnLeave ser executado
                 * depois de alterar os dados.
                 */
                Application.DoEvents();

                saquinhoCofre = (SaquinhoEtiqueta)saquinho;

                txtRefer�ncia.Refer�ncia = saquinho.Mercadoria.Refer�ncia;
                txtPeso.Double = saquinho.Peso;
                txtQuantidade.Int = Convert.ToInt32(saquinho.Quantidade);
                cmbFormato.SelectedItem = saquinhoCofre.Etiqueta;

                cmdNovo.Text = "&Alterar";
                cmdNovo.Enabled = true;
                cmdNovo.Tag = saquinhoCofre;

                PrepararMercadoria(saquinho.Mercadoria);
            }
            else if (cmdNovo.Tag != null)
            {
                cmdNovo.Text = "&Adicionar";
                cmdNovo.Tag = null;
            }
  
        }

        private void op��oEditarEtiquetas_Click(object sender, EventArgs e)
        {
            ListaEtiquetas controle = new ListaEtiquetas();
            Controlador.InserirBaseInferior(controle);
            SubstituirBase(controle);
        }
	}
}

