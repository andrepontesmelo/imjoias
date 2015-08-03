using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios.Assistente
{
    [DefaultProperty("PainelAtual")]
	public class AssistenteControle : Apresenta��o.Formul�rios.Assistente.ConjuntoPain�is
	{
		// Constantes
		private const string strPr�ximo = "Pr�ximo";
		private const string strTerminar = "Terminar";

		// Atributos
		private bool mostrandoTerminar = false;

		// Eventos
		public event EventHandler Terminado;

		// Controle
		private System.Windows.Forms.Panel painelInferior;
		private System.Windows.Forms.Button btnPr�ximo;
		private System.Windows.Forms.Button btnAnterior;
		private System.Windows.Forms.Button btnCancelar;
		private System.ComponentModel.IContainer components = null;

		public AssistenteControle()
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
            this.painelInferior = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPr�ximo = new System.Windows.Forms.Button();
            this.painelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // painelInferior
            // 
            this.painelInferior.Controls.Add(this.btnCancelar);
            this.painelInferior.Controls.Add(this.btnAnterior);
            this.painelInferior.Controls.Add(this.btnPr�ximo);
            this.painelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.painelInferior.Location = new System.Drawing.Point(0, 144);
            this.painelInferior.Name = "painelInferior";
            this.painelInferior.Size = new System.Drawing.Size(392, 32);
            this.painelInferior.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(314, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnterior.Enabled = false;
            this.btnAnterior.Location = new System.Drawing.Point(152, 6);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "&Anterior";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPr�ximo
            // 
            this.btnPr�ximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPr�ximo.Location = new System.Drawing.Point(233, 6);
            this.btnPr�ximo.Name = "btnPr�ximo";
            this.btnPr�ximo.Size = new System.Drawing.Size(75, 23);
            this.btnPr�ximo.TabIndex = 0;
            this.btnPr�ximo.Text = "&Pr�ximo";
            this.btnPr�ximo.Click += new System.EventHandler(this.btnPr�ximo_Click);
            // 
            // AssistenteControle
            // 
            this.Controls.Add(this.painelInferior);
            this.Itens = new Apresenta��o.Formul�rios.Assistente.PainelAssistente[0];
            this.Name = "AssistenteControle";
            this.Size = new System.Drawing.Size(392, 176);
            this.Load += new System.EventHandler(this.AssistenteControle_Load);
            this.Mudan�aPainel += new Apresenta��o.Formul�rios.Assistente.ConjuntoPain�is.PainelHandler(this.AssistenteControle_Mudan�aPainel);
            this.painelInferior.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao pressionar "Pr�ximo"
		/// </summary>
		private void btnPr�ximo_Click(object sender, System.EventArgs e)
		{
            PainelAssistente painel;

            try
            {
                painel = Itens[PainelAtual];
            }
            catch (IndexOutOfRangeException)
            {
                PainelAtual = 0;
                return;
            }

            if (!painel.ValidarTransi��o())
                return;

			if (mostrandoTerminar)
				Terminado(this, new EventArgs());
			else
				PainelAtual++;
		}

		/// <summary>
		/// Ocorre ao pressionar "Anterior"
		/// </summary>
		private void btnAnterior_Click(object sender, System.EventArgs e)
		{
			PainelAtual--;
		}

		/// <summary>
		/// Ocorre ao mudar o painel
		/// </summary>
		/// <param name="painel">Painel exibido</param>
		/// <param name="nPainel">N�mero do painel exibido</param>
		private void AssistenteControle_Mudan�aPainel(PainelAssistente painel, int nPainel)
		{
			btnAnterior.Enabled = nPainel > 0;
			btnPr�ximo.Enabled  = Terminado != null || nPainel < Itens.Length - 1;
			
			if (Terminado != null)
			{
				if (nPainel < Itens.Length - 1)
				{
					btnPr�ximo.Text = strPr�ximo;
					mostrandoTerminar = false;
				}
				else
				{
					btnPr�ximo.Text = strTerminar;
					mostrandoTerminar = true;
				}
			}
		}

		/// <summary>
		/// Obt�m tamanho do painel
		/// </summary>
		protected override Size TamanhoPainel
		{
			get
			{
				return new Size(ClientRectangle.Width, ClientRectangle.Height - painelInferior.Height);
			}
		}

		/// <summary>
		/// Permitir usu�rio avan�ar
		/// </summary>
		[Browsable(false),
			DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool PermitirPr�ximo
		{
			get { return btnPr�ximo.Enabled; }
			set { btnPr�ximo.Enabled = value; }
		}

		/// <summary>
		/// Exibe bot�o cancelar
		/// </summary>
		[DefaultValue(true)]
		public bool Cancel�vel
		{
			get { return btnCancelar.Visible; }
			set
            {
                if (!value && btnCancelar.Visible)
                {
                    btnAnterior.Location = btnPr�ximo.Location;
                    btnPr�ximo.Location = btnCancelar.Location;
                }
                else if (value && !btnCancelar.Visible)
                {
                    btnPr�ximo.Location = btnAnterior.Location;
                    btnAnterior.Location = new Point(
                        btnPr�ximo.Left - btnAnterior.Width - btnAnterior.Margin.Right,
                        btnPr�ximo.Top);
                }

                btnCancelar.Visible = value;
            }
		}

        private void AssistenteControle_Load(object sender, EventArgs e)
        {
            PainelAtual = 0;
        }
	}
}

