using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Mercadoria.Bandeja;
using Apresentação.Mercadoria.Etiqueta.Impressão;
using Entidades;
using Report.Layout;
using Entidades.Etiqueta;
using Entidades.Mercadoria;
using Entidades.Privilégio;

[assembly: ExporBotão(Permissão.Nenhuma, 2, "Etiquetas", true,
    typeof(Apresentação.Mercadoria.Etiqueta.Impressão.Imprimir))]

namespace Apresentação.Mercadoria.Etiqueta.Impressão
{
	public class Imprimir : Apresentação.Formulários.BaseInferior
	{
		// Atributos
        private Dictionary<string, EtiquetaFormato> hashStringFormato;
		private Aguarde			aguardeImpressão = null;	// Somente enquanto imprime

		// Delegações
		private delegate void DMostrarFoto(Image imagem);

		// Formulário
		private Apresentação.Formulários.Quadro quadroSeleção;
		private System.Windows.Forms.Label label1;
		private Apresentação.Mercadoria.TxtMercadoria txtReferência;
		private System.Windows.Forms.Label label2;
		private AMS.TextBox.IntegerTextBox txtQuantidade;
		private System.Windows.Forms.Button cmdNovo;
		private AMS.TextBox.NumericTextBox txtPeso;
		private Apresentação.Mercadoria.QuadroFoto quadroMercadoria;
		private System.Windows.Forms.ComboBox cmbFormato;
		private BandejaEtiqueta bandeja;
		private System.Windows.Forms.Label lblPeso;
		private Apresentação.Formulários.Quadro quadroBandeja;
		private Apresentação.Formulários.Quadro quadroImpressão;
		private Apresentação.Formulários.Opção opçãoImprimir;
		private System.Windows.Forms.PrintDialog printDlg;
		private System.Drawing.Printing.PrintDocument printDoc;
		private System.Windows.Forms.CheckBox chkFormatoAutomático;
		private Apresentação.Formulários.Quadro quadroDica;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblFormato;
        private Opção opçãoEditarEtiquetas;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a base inferior
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

				this.txtReferência.Dispose();
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
            this.quadroSeleção = new Apresentação.Formulários.Quadro();
            this.chkFormatoAutomático = new System.Windows.Forms.CheckBox();
            this.txtPeso = new AMS.TextBox.NumericTextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.cmdNovo = new System.Windows.Forms.Button();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.txtQuantidade = new AMS.TextBox.IntegerTextBox();
            this.txtReferência = new Apresentação.Mercadoria.TxtMercadoria();
            this.lblFormato = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quadroMercadoria = new Apresentação.Mercadoria.QuadroFoto();
            this.bandeja = new Apresentação.Mercadoria.Etiqueta.Impressão.BandejaEtiqueta();
            this.quadroBandeja = new Apresentação.Formulários.Quadro();
            this.quadroImpressão = new Apresentação.Formulários.Quadro();
            this.opçãoEditarEtiquetas = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.printDlg = new System.Windows.Forms.PrintDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.quadroDica = new Apresentação.Formulários.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroSeleção.SuspendLayout();
            this.quadroBandeja.SuspendLayout();
            this.quadroImpressão.SuspendLayout();
            this.quadroDica.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroDica);
            this.esquerda.Controls.Add(this.quadroImpressão);
            this.esquerda.Size = new System.Drawing.Size(187, 464);
            this.esquerda.Controls.SetChildIndex(this.quadroImpressão, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroDica, 0);
            // 
            // quadroSeleção
            // 
            this.quadroSeleção.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroSeleção.bInfDirArredondada = true;
            this.quadroSeleção.bInfEsqArredondada = true;
            this.quadroSeleção.bSupDirArredondada = true;
            this.quadroSeleção.bSupEsqArredondada = true;
            this.quadroSeleção.Controls.Add(this.chkFormatoAutomático);
            this.quadroSeleção.Controls.Add(this.txtPeso);
            this.quadroSeleção.Controls.Add(this.lblPeso);
            this.quadroSeleção.Controls.Add(this.cmdNovo);
            this.quadroSeleção.Controls.Add(this.cmbFormato);
            this.quadroSeleção.Controls.Add(this.txtQuantidade);
            this.quadroSeleção.Controls.Add(this.txtReferência);
            this.quadroSeleção.Controls.Add(this.lblFormato);
            this.quadroSeleção.Controls.Add(this.label1);
            this.quadroSeleção.Controls.Add(this.label2);
            this.quadroSeleção.Cor = System.Drawing.Color.Black;
            this.quadroSeleção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroSeleção.LetraTítulo = System.Drawing.Color.White;
            this.quadroSeleção.Location = new System.Drawing.Point(200, 24);
            this.quadroSeleção.MostrarBotãoMinMax = false;
            this.quadroSeleção.Name = "quadroSeleção";
            this.quadroSeleção.Size = new System.Drawing.Size(352, 168);
            this.quadroSeleção.TabIndex = 0;
            this.quadroSeleção.Tamanho = 30;
            this.quadroSeleção.Título = "Etiqueta a ser impressa";
            // 
            // chkFormatoAutomático
            // 
            this.chkFormatoAutomático.BackColor = System.Drawing.Color.Transparent;
            this.chkFormatoAutomático.Checked = true;
            this.chkFormatoAutomático.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormatoAutomático.Location = new System.Drawing.Point(16, 128);
            this.chkFormatoAutomático.Name = "chkFormatoAutomático";
            this.chkFormatoAutomático.Size = new System.Drawing.Size(240, 40);
            this.chkFormatoAutomático.TabIndex = 9;
            this.chkFormatoAutomático.Text = "Escolher formato automaticamente, conforme escolhas passadas.";
            this.chkFormatoAutomático.UseVisualStyleBackColor = false;
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
            // txtReferência
            // 
            this.txtReferência.ControlePeso = this.txtPeso;
            this.txtReferência.Location = new System.Drawing.Point(16, 56);
            this.txtReferência.Name = "txtReferência";
            this.txtReferência.Referência = "";
            this.txtReferência.Size = new System.Drawing.Size(152, 20);
            this.txtReferência.TabIndex = 1;
            this.txtReferência.ReferênciaConfirmada += new System.EventHandler(this.txtReferência_ReferênciaConfirmada);
            this.txtReferência.Leave += new System.EventHandler(this.txtReferência_Leave);
            this.txtReferência.ReferênciaAlterada += new System.EventHandler(this.txtReferência_ReferênciaAlterada);
            this.txtReferência.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
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
            this.label1.Text = "Referência:";
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
            this.quadroMercadoria.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroMercadoria.LetraTítulo = System.Drawing.Color.White;
            this.quadroMercadoria.Location = new System.Drawing.Point(568, 24);
            this.quadroMercadoria.MostrarBotãoMinMax = false;
            this.quadroMercadoria.Name = "quadroMercadoria";
            this.quadroMercadoria.Size = new System.Drawing.Size(216, 168);
            this.quadroMercadoria.TabIndex = 11;
            this.quadroMercadoria.Tamanho = 30;
            this.quadroMercadoria.Título = "Mercadoria";
            // 
            // bandeja
            // 
            this.bandeja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bandeja.BackColor = System.Drawing.Color.White;
            this.bandeja.Location = new System.Drawing.Point(1, 24);
            this.bandeja.MostrarBarraFerramentas = true;
            this.bandeja.MostrarPreço = false;
            this.bandeja.MostrarSeleçãoTabela = false;
            this.bandeja.MostrarStatus = true;
            this.bandeja.Name = "bandeja";
            this.bandeja.OrdenaçãoReferência = false;
            this.bandeja.PermitirSeleçãoTabela = false;
            this.bandeja.Size = new System.Drawing.Size(582, 207);
            this.bandeja.TabIndex = 6;
            this.bandeja.SaquinhoExcluído += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandeja_SaquinhoExcluído);
            this.bandeja.SeleçãoMudou += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandeja_SeleçãoMudou);
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
            this.quadroBandeja.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroBandeja.LetraTítulo = System.Drawing.Color.White;
            this.quadroBandeja.Location = new System.Drawing.Point(200, 208);
            this.quadroBandeja.MostrarBotãoMinMax = false;
            this.quadroBandeja.Name = "quadroBandeja";
            this.quadroBandeja.Size = new System.Drawing.Size(584, 232);
            this.quadroBandeja.TabIndex = 12;
            this.quadroBandeja.Tamanho = 30;
            this.quadroBandeja.Título = "Itens a serem impressos";
            // 
            // quadroImpressão
            // 
            this.quadroImpressão.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroImpressão.bInfDirArredondada = true;
            this.quadroImpressão.bInfEsqArredondada = true;
            this.quadroImpressão.bSupDirArredondada = true;
            this.quadroImpressão.bSupEsqArredondada = true;
            this.quadroImpressão.Controls.Add(this.opçãoEditarEtiquetas);
            this.quadroImpressão.Controls.Add(this.opçãoImprimir);
            this.quadroImpressão.Cor = System.Drawing.Color.Black;
            this.quadroImpressão.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroImpressão.LetraTítulo = System.Drawing.Color.White;
            this.quadroImpressão.Location = new System.Drawing.Point(7, 139);
            this.quadroImpressão.MostrarBotãoMinMax = false;
            this.quadroImpressão.Name = "quadroImpressão";
            this.quadroImpressão.Size = new System.Drawing.Size(160, 80);
            this.quadroImpressão.TabIndex = 1;
            this.quadroImpressão.Tamanho = 30;
            this.quadroImpressão.Título = "Impressão";
            // 
            // opçãoEditarEtiquetas
            // 
            this.opçãoEditarEtiquetas.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEditarEtiquetas.Descrição = "Editar formatos...";
            this.opçãoEditarEtiquetas.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoEditarEtiquetas.Imagem")));
            this.opçãoEditarEtiquetas.Location = new System.Drawing.Point(8, 52);
            this.opçãoEditarEtiquetas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEditarEtiquetas.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEditarEtiquetas.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEditarEtiquetas.Name = "opçãoEditarEtiquetas";
            this.opçãoEditarEtiquetas.Size = new System.Drawing.Size(150, 20);
            this.opçãoEditarEtiquetas.TabIndex = 2;
            this.opçãoEditarEtiquetas.Click += new System.EventHandler(this.opçãoEditarEtiquetas_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Enabled = false;
            this.opçãoImprimir.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoImprimir.Imagem")));
            this.opçãoImprimir.Location = new System.Drawing.Point(8, 32);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 1;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
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
            this.quadroDica.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDica.LetraTítulo = System.Drawing.Color.White;
            this.quadroDica.Location = new System.Drawing.Point(7, 13);
            this.quadroDica.MostrarBotãoMinMax = false;
            this.quadroDica.Name = "quadroDica";
            this.quadroDica.Size = new System.Drawing.Size(160, 120);
            this.quadroDica.TabIndex = 2;
            this.quadroDica.Tamanho = 30;
            this.quadroDica.Título = "Dica";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 80);
            this.label3.TabIndex = 1;
            this.label3.Text = "Adicione as referências que deseja imprimir, sem se preocupar com o formato do pa" +
                "pel. Deixe que o programa organize a impressão para você.";
            // 
            // Imprimir
            // 
            this.Controls.Add(this.quadroBandeja);
            this.Controls.Add(this.quadroSeleção);
            this.Controls.Add(this.quadroMercadoria);
            this.Imagem = Resource.Etiqueta;
            this.Name = "Imprimir";
            this.Size = new System.Drawing.Size(800, 464);
            this.Controls.SetChildIndex(this.quadroMercadoria, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroSeleção, 0);
            this.Controls.SetChildIndex(this.quadroBandeja, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroSeleção.ResumeLayout(false);
            this.quadroSeleção.PerformLayout();
            this.quadroBandeja.ResumeLayout(false);
            this.quadroImpressão.ResumeLayout(false);
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

			/* Verificar se os campos estão preenchidos */

			// Verificar formato
			if (cmbFormato.SelectedItem == null)
			{
				MessageBox.Show(
					this.ParentForm,
					"Formato para etiqueta não foi especificado!",
					"Impressão de etiquetas",
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
					"Peso para mercadoria não foi especificado corretamente!",
					"Impressão de etiquetas",
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
					"Quantidade de etiquetas não foi especificado!",
					"Impressão de etiquetas",
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
				// Remove no caso de alteração
				if (cmdNovo.Tag != null)
				{
					SaquinhoEtiqueta saquinho = (SaquinhoEtiqueta) cmdNovo.Tag;
                    bandeja.Remover(saquinho);
				}
				
                // Adiciona nova mercadoria 
				{
                    mercadoria = txtReferência.Mercadoria;

					if (mercadoria == null)
					{
						mercadoria            = new Entidades.Mercadoria.Mercadoria(txtReferência.Referência, Entidades.Tabela.TabelaPadrão);
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

                    opçãoImprimir.Enabled = bandeja.Count > 0;

					// Reposiocionar cursor
					txtReferência.Txt.Text = "";
					cmdNovo.Enabled = false;
					
					txtReferência.Txt.Focus();
				}
			}
#if !DEBUG
			catch
			{
				MessageBox.Show(
					this.ParentForm,
					"Ocorreu um erro ao montar as informações da mercadorias. Por favor, reveja os dados fornecidos",
					"Impressão de etiquetas",
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
			string             referência;
			int                dígito;

			Entidades.Mercadoria.Mercadoria.DesmascararReferência(txtReferência.Referência, out referência, out dígito);
			etiqueta   = (EtiquetaFormato) cmbFormato.SelectedItem;
			mapeamento = EtiquetaMercadoria.ObterEtiquetaMercadoria(referência);

			if (mapeamento == null)
			{
				mapeamento = new EtiquetaMercadoria(referência, etiqueta.Formato, false);
				mapeamento.Cadastrar();
			}
			else
			{
				mapeamento.Formato = etiqueta.Formato;
				mapeamento.Atualizar();
			}
		}

		/// <summary>
		/// Ocorre quando a referência perde o foco
		/// </summary>
		private void txtReferência_Leave(object sender, System.EventArgs e)
		{
			PrepararReferência();
		}
		
		/// <summary>
		/// Prepara dados após preenchimento da referência
		/// </summary>
        private void PrepararReferência()
        {
            txtQuantidade.Text = "1";

            if (txtReferência.Referência.Length == 16)
            {
                Entidades.Mercadoria.Mercadoria mercadoria;

                mercadoria = txtReferência.Mercadoria;

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
		/// Prepara configuração de etiquetas para mercadoria
		/// </summary>
		/// <param name="mercadoria">Mercadoria entrada</param>
		private void PrepararMercadoria(Entidades.Mercadoria.Mercadoria mercadoria)
		{
            if (cmbFormato.InvokeRequired)
            {
                PrepararMercadoriaDelegate método = new PrepararMercadoriaDelegate(PrepararMercadoria);
                cmbFormato.BeginInvoke(método, mercadoria);
            }
            else
            {

                EtiquetaMercadoria etiqueta;

                if (!mercadoria.DePeso)
                    txtPeso.Text = mercadoria.Peso.ToString();

                lblPeso.Enabled = txtPeso.Enabled = mercadoria.DePeso;

                if (chkFormatoAutomático.Checked)
                {
                    // Verificar mapeamento de etiqueta
                    etiqueta = EtiquetaMercadoria.ObterEtiquetaMercadoria(mercadoria.ReferênciaNumérica);

                    if (etiqueta != null && cmbFormato.Items.Count > 0)
                    {
                        if ((EtiquetaFormato)cmbFormato.SelectedItem != hashStringFormato[etiqueta.Formato])
                        {
                            if (cmbFormato.SelectedItem != null)
                            {
                                BalãoEtiquetaMapeada balão;

                                balão = new BalãoEtiquetaMapeada();
                                balão.ShowBalloon(cmbFormato);

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
				if (txtReferência.Txt.Focused && txtReferência.Txt.Text.Length != txtReferência.Txt.MaxLength)
					return;

				Control próximo = this.GetNextControl((Control) sender, true);

				while (próximo is Label || próximo is PictureBox)
					próximo = this.GetNextControl(próximo, true);

				TextBox txt     = próximo as TextBox;
				
				próximo.Focus();
				
				if (txt != null)
					txt.SelectAll();
				
				if ((sender.Equals(txtQuantidade))
					&& (txtPeso.Enabled == false))
					cmdNovo.Focus();

			}
		}

		/// <summary>
		/// Ocorre ao alterar a referência
		/// </summary>
		private void txtReferência_ReferênciaAlterada(object sender, System.EventArgs e)
		{
			if (!txtPeso.Enabled)
				txtPeso.Text = "";

			if (cmdNovo.Tag != null)
			{
				cmdNovo.Text = "&Adicionar";
				cmdNovo.Tag = null;
			}

			if (txtReferência.Txt.Text.Length == txtReferência.Txt.MaxLength && txtReferência.Focused)
			{
				Entidades.Mercadoria.Mercadoria mercadoria = txtReferência.Mercadoria;

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
		private void txtReferência_ReferênciaConfirmada(object sender, System.EventArgs e)
		{
			PrepararReferência();
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
                    CarregarFormatoEtiquetasDelegate método = new CarregarFormatoEtiquetasDelegate(CarregarFormatoEtiquetas);
                    cmbFormato.BeginInvoke(método);
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
		/// Calcula o número de etiquetas para os
		/// formatos selecionados
		/// </summary>
		/// <param name="etiquetas">Formatos de etiquetas selecionados</param>
		public int CalcularNúmeroEtiquetas(EtiquetaFormato [] etiquetas)
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
		/// Obtém formatos de etiquetas a serem impressas
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
		/// Ocorre ao solicitar impressão
		/// </summary>
		private void opçãoImprimir_Click(object sender, System.EventArgs e)
		{
			EtiquetaFormato [] etiquetas = ObterFormatosBandeja();

            using (Aguarde aguarde = new Aguarde("Reobtendo configuração dos formatos", etiquetas.Length))
            {
                aguarde.Abrir();

                foreach (EtiquetaFormato etiqueta in etiquetas)
                {
                    aguarde.Passo("Reobtendo configuração do formato " + etiqueta.Formato);
                    etiqueta.ReobterInformações();
                }

                aguarde.Close();
            }

			using (ImprimirEscolha dlg = new ImprimirEscolha(etiquetas, new ImprimirEscolha.CalcularEtiquetas(CalcularNúmeroEtiquetas)))
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ImprimirEtiquetas(dlg.Seleção, dlg.LayoutEtiquetas);
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

			int deEtiqueta, atéEtiqueta;	// Seleção de etiquetas a serem impressas
			int nEtiquetas;					// Total de etiquetas a serem impressas
			int etiquetasPágina;			// Etiquetas por página
			int iEtiqueta;					// Iterador

			nEtiquetas      = CalcularNúmeroEtiquetas(etiquetas);
			etiquetasPágina = layout.LabelsPerPage;

			printDlg.PrinterSettings.MaximumPage = (int) Math.Ceiling(nEtiquetas / (float) etiquetasPágina);
			printDlg.PrinterSettings.MinimumPage = 1;
			printDlg.PrinterSettings.DefaultPageSettings.PaperSize = layout.PaperSize;
			printDlg.PrinterSettings.FromPage = 1;
			printDlg.PrinterSettings.ToPage = printDlg.PrinterSettings.MaximumPage;

			if (printDlg.ShowDialog(this.ParentForm) != DialogResult.OK)
			{
				MessageBox.Show(this, "Impressão cancelada pelo usuário", "Impressão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);	
				return;
			}

			aguardeImpressão = new Aguarde(
					   "Preparando impressão...",
					   2 + printDlg.PrinterSettings.ToPage - printDlg.PrinterSettings.FromPage,
					   "Imprimindo etiquetas",
					   "Aguarde enquanto o sistema imprime as etiquetas solicitadas.");

			// Mostrar janela de espera
            aguardeImpressão.Abrir();
			
			aguardeImpressão.Tag = 0;			// Usado para numeração de página

			try
			{
				// Preparar impressão
				layout.Document = printDoc;
				deEtiqueta      = (printDlg.PrinterSettings.FromPage - 1) * etiquetasPágina;
				atéEtiqueta     = (printDlg.PrinterSettings.ToPage) * etiquetasPágina - 1;
				iEtiqueta       = 0;

				// Inserir objetos de impressão
				layout.Objects = new ArrayList();

				// Atualizando dados
				aguardeImpressão.Passo("Sincronizando dados com o banco de dados");
				bandeja.AtualizaObjetosInstrínsecosDosSaquinhos();

				// Formata a impressão
				aguardeImpressão.Passo("Formatando dados para impressão de etiquetas");
 
				foreach (SaquinhoEtiqueta saquinho in bandeja)
				{
					/* Verificar se saquinho contém formato a ser
						* impresso. Não é a melhor implementação,
						* porém o número de formatos é bem pequeno,
						* levando a um pior desempenho caso utilizado
						* busca binária, já que deve ordenar os itens.
						*/
					for (int i = 0; i < etiquetas.Length; i++)
						if (saquinho.Etiqueta == etiquetas[i])
						{
#if DEBUG
                            if (saquinho.Mercadoria == null)
                                throw new NullReferenceException("Mercadoria de saquinho está nula!");
#endif
							if (iEtiqueta >= deEtiqueta && iEtiqueta <= atéEtiqueta)
							{
								layout.Objects.Add(
									new RepeatedObject(
									layout.Items[i],
									saquinho.Mercadoria,
									( Convert.ToInt32(saquinho.Quantidade) > atéEtiqueta - iEtiqueta + 1
									? atéEtiqueta - iEtiqueta + 1
									: Convert.ToInt32(saquinho.Quantidade))));

                                saquinho.Impresso = true;

                                if (saquinhosImpressos.Contains(saquinho)) throw new Exception("Lista ja contem o item de etiqueta");
                                saquinhosImpressos.Add(saquinho);
							}
							else if (iEtiqueta <= atéEtiqueta && iEtiqueta + saquinho.Quantidade >= deEtiqueta)
							{
								layout.Objects.Add(
									new RepeatedObject(
									layout.Items[i],
									saquinho.Mercadoria,
									Convert.ToInt32(saquinho.Quantidade) - (deEtiqueta - iEtiqueta) > atéEtiqueta - iEtiqueta + 1
									? atéEtiqueta - iEtiqueta + 1
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
							"Não foi possível imprimir o documento. Verifique se a impressora está ligada e conectada corretamente ao computador.",
							"Impressão de etiquetas - " + e.Message,
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
                aguardeImpressão.Close();
                aguardeImpressão.Dispose();
                aguardeImpressão = null;
			}

            bandeja.FoiImpresso(saquinhosImpressos);

            opçãoImprimir.Enabled = true;
		}

		/// <summary>
		/// Ocorre ao iniciar impressão de página
		/// </summary>
		private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int página = (int) aguardeImpressão.Tag + 1;

			aguardeImpressão.Passo("Imprimindo página " + página.ToString());

			aguardeImpressão.Tag = página;
		}

		/// <summary>
		/// Ocorre ao terminar impressão
		/// </summary>
		private void printDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			aguardeImpressão.Close();
			aguardeImpressão.Dispose();
		}

		/// <summary>
		/// Ocorre ao carregar pela primeira vez.
		/// </summary>
		public override void AoCarregarCompletamente(Splash splash)
		{
			base.AoCarregarCompletamente(splash);

            //if (splash != null)
            //    splash.Mensagem = "Criado ambiente de impressão";

            printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();

            txtReferência.Tabela = Tabela.TabelaPadrão;
            bandeja.Tabela = Tabela.TabelaPadrão;
		}

        /// <summary>
        /// Ocorre ao exibir formulário.
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
				/* Aceitar tanto ponto quanto vírgula para separação de decimais */
				case '.':
				case ',':
					txtPeso.SelectedText = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
					break;
			}
		}

        private void bandeja_SaquinhoExcluído(Apresentação.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            opçãoImprimir.Enabled = bandeja.Count > 0;
        }

        private void bandeja_SeleçãoMudou(Apresentação.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            if (saquinho != null)
            {
                SaquinhoEtiqueta saquinhoCofre;

                /* Garantir que nenhum OnLeave ser executado
                 * depois de alterar os dados.
                 */
                Application.DoEvents();

                saquinhoCofre = (SaquinhoEtiqueta)saquinho;

                txtReferência.Referência = saquinho.Mercadoria.Referência;
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

        private void opçãoEditarEtiquetas_Click(object sender, EventArgs e)
        {
            ListaEtiquetas controle = new ListaEtiquetas();
            Controlador.InserirBaseInferior(controle);
            SubstituirBase(controle);
        }
	}
}

