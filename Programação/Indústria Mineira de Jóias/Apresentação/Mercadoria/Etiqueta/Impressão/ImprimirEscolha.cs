using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Report.Layout;
using Apresenta��o.Formul�rios;
using Entidades.Etiqueta;

namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o
{
	public class ImprimirEscolha : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		// Delega��es
		public delegate int CalcularEtiquetas(EtiquetaFormato [] sele��o);

		// Atributos
		private EtiquetaFormato [] etiquetas;
		private EtiquetaFormato [] sele��o;
		private LabelLayout		   layout = null;
		private CalcularEtiquetas  c�lculo;

		// Formul�rio
		private Apresenta��o.Formul�rios.Assistente.AssistenteControle assistente;
		private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelEscolha;
		private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelImprimir;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox listaFormatos;
		private System.Windows.Forms.Label lblEscolha;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblP�ginas;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblEtiquetas;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i nova janela de sele��o de impress�o
		/// </summary>
		/// <param name="etiquetas">Etiquetas a serem impressas</param>
		public ImprimirEscolha(EtiquetaFormato [] etiquetas, CalcularEtiquetas c�lculo)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			Etiquetas = etiquetas;
			this.c�lculo = c�lculo;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ImprimirEscolha));
			this.assistente = new Apresenta��o.Formul�rios.Assistente.AssistenteControle();
			this.painelEscolha = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
			this.listaFormatos = new System.Windows.Forms.CheckedListBox();
			this.lblEscolha = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.painelImprimir = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
			this.lblP�ginas = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblEtiquetas = new System.Windows.Forms.Label();
			this.assistente.SuspendLayout();
			this.painelEscolha.SuspendLayout();
			this.painelImprimir.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(143, 22);
			this.lblT�tulo.Text = "Imprimir etiquetas";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(336, 48);
			this.lblDescri��o.Text = "Escolha os grupos de etiquetas a serem impressos. Antes da impress�o, certifique-" +
				"se de que o papel est� corretamente colocado na bandeja da impressora.";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Name = "pic�cone";
			// 
			// assistente
			// 
			this.assistente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.assistente.AutoScroll = true;
			this.assistente.Controls.Add(this.painelEscolha);
			this.assistente.Controls.Add(this.painelImprimir);
			this.assistente.Itens = new Apresenta��o.Formul�rios.Assistente.PainelAssistente[] {
																								   this.painelEscolha,
																								   this.painelImprimir};
			this.assistente.Location = new System.Drawing.Point(8, 96);
			this.assistente.Name = "assistente";
			this.assistente.Size = new System.Drawing.Size(400, 240);
			this.assistente.TabIndex = 3;
			this.assistente.Terminado += new System.EventHandler(this.assistente_Terminado);
			// 
			// painelEscolha
			// 
			this.painelEscolha.AutoScroll = true;
			this.painelEscolha.Controls.Add(this.listaFormatos);
			this.painelEscolha.Controls.Add(this.lblEscolha);
			this.painelEscolha.Controls.Add(this.label1);
			this.painelEscolha.Location = new System.Drawing.Point(0, 0);
			this.painelEscolha.Name = "painelEscolha";
			this.painelEscolha.Size = new System.Drawing.Size(400, 208);
			this.painelEscolha.TabIndex = 1;
			this.painelEscolha.ValidandoTransi��o += new System.ComponentModel.CancelEventHandler(this.painelEscolha_ValidandoTransi��o);
			// 
			// listaFormatos
			// 
			this.listaFormatos.CheckOnClick = true;
			this.listaFormatos.Location = new System.Drawing.Point(104, 48);
			this.listaFormatos.Name = "listaFormatos";
			this.listaFormatos.ScrollAlwaysVisible = true;
			this.listaFormatos.Size = new System.Drawing.Size(200, 94);
			this.listaFormatos.Sorted = true;
			this.listaFormatos.TabIndex = 2;
			// 
			// lblEscolha
			// 
			this.lblEscolha.AutoSize = true;
			this.lblEscolha.Location = new System.Drawing.Point(16, 16);
			this.lblEscolha.Name = "lblEscolha";
			this.lblEscolha.Size = new System.Drawing.Size(259, 16);
			this.lblEscolha.TabIndex = 1;
			this.lblEscolha.Text = "Escolha o(s) formato(s) que deseja imprimir agora:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(48, 160);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Somente devem ser impressos os formatos de etiquetas compat�veis, ou seja, aquele" +
				"s que utilizem a mesma folha de impress�o.";
			// 
			// painelImprimir
			// 
			this.painelImprimir.AutoScroll = true;
			this.painelImprimir.Controls.Add(this.lblEtiquetas);
			this.painelImprimir.Controls.Add(this.label6);
			this.painelImprimir.Controls.Add(this.lblP�ginas);
			this.painelImprimir.Controls.Add(this.label5);
			this.painelImprimir.Controls.Add(this.lblTotal);
			this.painelImprimir.Controls.Add(this.label4);
			this.painelImprimir.Controls.Add(this.label3);
			this.painelImprimir.Controls.Add(this.label2);
			this.painelImprimir.Location = new System.Drawing.Point(0, 0);
			this.painelImprimir.Name = "painelImprimir";
			this.painelImprimir.Size = new System.Drawing.Size(400, 208);
			this.painelImprimir.TabIndex = 2;
			this.painelImprimir.Exibido += new System.EventHandler(this.painelImprimir_Exibido);
			// 
			// lblP�ginas
			// 
			this.lblP�ginas.AutoSize = true;
			this.lblP�ginas.Location = new System.Drawing.Point(232, 112);
			this.lblP�ginas.Name = "lblP�ginas";
			this.lblP�ginas.Size = new System.Drawing.Size(57, 16);
			this.lblP�ginas.TabIndex = 5;
			this.lblP�ginas.Text = "lblP�ginas";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(189, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Total de p�ginas a serem impressas:";
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Location = new System.Drawing.Point(232, 96);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(41, 16);
			this.lblTotal.TabIndex = 3;
			this.lblTotal.Text = "lblTotal";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(196, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Total de etiquetas a serem impressas:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(368, 32);
			this.label3.TabIndex = 1;
			this.label3.Text = "Introduza os pap�is na bandeja para iniciar a impress�o dos formatos selecionados" +
				" anteriormente.";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Pronto para imprimir!";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(210, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "Etiquetas a serem impressas por p�gina:";
			// 
			// lblEtiquetas
			// 
			this.lblEtiquetas.AutoSize = true;
			this.lblEtiquetas.Location = new System.Drawing.Point(232, 128);
			this.lblEtiquetas.Name = "lblEtiquetas";
			this.lblEtiquetas.Size = new System.Drawing.Size(63, 16);
			this.lblEtiquetas.TabIndex = 7;
			this.lblEtiquetas.Text = "lblEtiquetas";
			// 
			// ImprimirEscolha
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(418, 344);
			this.Controls.Add(this.assistente);
			this.Name = "ImprimirEscolha";
			this.Text = "Ind�stria Mineira de Joias";
			this.TopMost = false;
			this.Controls.SetChildIndex(this.assistente, 0);
			this.assistente.ResumeLayout(false);
			this.painelEscolha.ResumeLayout(false);
			this.painelImprimir.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Formatos de etiquetas
		/// </summary>
		public EtiquetaFormato [] Etiquetas
		{
			get { return etiquetas; }
			set
			{
				etiquetas = value;

				listaFormatos.Items.Clear();

				foreach (EtiquetaFormato etiqueta in etiquetas)
					listaFormatos.Items.Add(etiqueta);

				listaFormatos.SetItemChecked(0, true);
			}
		}

		/// <summary>
		/// Layout de etiquetas
		/// </summary>
		public LabelLayout LayoutEtiquetas
		{
			get { return layout; }
		}

		/// <summary>
		/// Sele��o de formatos de etiquetas
		/// </summary>
		public EtiquetaFormato [] Sele��o
		{
			get { return sele��o; }
		}

		#endregion

		/// <summary>
		/// Ocorre ao terminar
		/// </summary>
		private void assistente_Terminado(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Ocorre ao sair da escolha
		/// </summary>
		private void painelEscolha_ValidandoTransi��o(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (listaFormatos.CheckedItems.Count < 1)
			{
				MessageBox.Show(
					this.ParentForm,
					"� necess�rio a escolha de pelo menos um formato a ser impresso.",
					"Impress�o de etiquetas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Stop);

				e.Cancel = true;
			}
			else
			{
				sele��o = new EtiquetaFormato[listaFormatos.CheckedItems.Count];

				for (int i = 0; i < sele��o.Length; i++)
					sele��o[i] = (EtiquetaFormato) listaFormatos.CheckedItems[i];

				if (!VerificarCompatibilidade())
				{
					MessageBox.Show(
						this.ParentForm,
						"Os formatos selecionados n�o s�o compat�veis por n�o possu�rem a mesma medida de papel, margens, etiqueta ou espa�amento da mesma. Eles devem ser, portanto, impressos separados.",
						"Impress�o de etiquetas",
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop);

					e.Cancel = true;
				}
			}
		}

		/// <summary>
		/// Verifica compatibilidade da sele��o atual
		/// </summary>
		/// <returns>Compatibilidade dos formatos</returns>
		private bool VerificarCompatibilidade()
		{
			if (sele��o.Length <= 1)
				return true;

			using (Aguarde aguarde = new Aguarde(
									   "Construindo formato para base de compara��o",
									   sele��o.Length,
									   "Verificando compatibilidade",
									   "O sistema est� verificando a compatibilidade dos formatos de etiqueta a serem impressos."))
			{
				bool        compatibilidade = true;
				LabelLayout layout;

				// Construir janela de porcentagem
                aguarde.Abrir();

				aguarde.Passo("Carregando formato " + sele��o[0].Formato);

				layout = new LabelLayout();
				layout.LoadFromXml(sele��o[0].Configura��o, true);

				for (int i = 1; i < sele��o.Length && compatibilidade; i++)
				{
					LabelLayout aux;

					aguarde.Passo("Comparando formato " + sele��o[i].Formato);

					aux = new LabelLayout();
					aux.LoadFromXml(sele��o[i].Configura��o, true);
				
					compatibilidade &= layout.IsCompatible(aux);
				}

				return compatibilidade;
			}
		}

		/// <summary>
		/// Ocorre ao mostrar a tela para imprimir
		/// </summary>
		private void painelImprimir_Exibido(object sender, System.EventArgs e)
		{
			using (Aguarde aguarde = new Aguarde(
                       "Preparando para imprimir",
					   sele��o.Length + 1,
					   "Preparando impress�o de etiquetas",
					   "Aguarde enquanto o sistema prepara a impress�o de etiquetas."))
			{
				int etiquetas, etiquetasP�gina;

                aguarde.Abrir();

				layout = new LabelLayout();

				layout.ImportType(typeof(Entidades.Mercadoria.Mercadoria));

				// Carrega formato inicial
				aguarde.Passo("Carregando formato " + sele��o[0].Formato);
				layout.LoadFromXml(sele��o[0].Configura��o, false);

				// Mescla demais formatos
				for (int i = 1; i <sele��o.Length; i++)
				{
					aguarde.Passo("Mesclando formato " + sele��o[i].Formato);

					layout.MergeFromXml(sele��o[i].Configura��o, false);
				}

				// Calcula n�mero de p�ginas
				aguarde.Passo("Calculando n�mero de p�ginas");

				etiquetas = c�lculo(sele��o);
				etiquetasP�gina = layout.LabelsPerPage;

				lblTotal.Text = etiquetas.ToString();
				lblP�ginas.Text = Math.Ceiling(etiquetas / (float) etiquetasP�gina).ToString();
				lblEtiquetas.Text = etiquetasP�gina.ToString();
			}
		}
	}
}

