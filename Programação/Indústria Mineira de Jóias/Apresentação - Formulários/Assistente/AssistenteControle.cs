using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Formulários.Assistente
{
    [DefaultProperty("PainelAtual")]
	public class AssistenteControle : Apresentação.Formulários.Assistente.ConjuntoPainéis
	{
		// Constantes
		private const string strPróximo = "Próximo";
		private const string strTerminar = "Terminar";

		// Atributos
		private bool mostrandoTerminar = false;

		// Eventos
		public event EventHandler Terminado;

		// Controle
		private System.Windows.Forms.Panel painelInferior;
		private System.Windows.Forms.Button btnPróximo;
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
            this.btnPróximo = new System.Windows.Forms.Button();
            this.painelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // painelInferior
            // 
            this.painelInferior.Controls.Add(this.btnCancelar);
            this.painelInferior.Controls.Add(this.btnAnterior);
            this.painelInferior.Controls.Add(this.btnPróximo);
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
            // btnPróximo
            // 
            this.btnPróximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPróximo.Location = new System.Drawing.Point(233, 6);
            this.btnPróximo.Name = "btnPróximo";
            this.btnPróximo.Size = new System.Drawing.Size(75, 23);
            this.btnPróximo.TabIndex = 0;
            this.btnPróximo.Text = "&Próximo";
            this.btnPróximo.Click += new System.EventHandler(this.btnPróximo_Click);
            // 
            // AssistenteControle
            // 
            this.Controls.Add(this.painelInferior);
            this.Itens = new Apresentação.Formulários.Assistente.PainelAssistente[0];
            this.Name = "AssistenteControle";
            this.Size = new System.Drawing.Size(392, 176);
            this.Load += new System.EventHandler(this.AssistenteControle_Load);
            this.MudançaPainel += new Apresentação.Formulários.Assistente.ConjuntoPainéis.PainelHandler(this.AssistenteControle_MudançaPainel);
            this.painelInferior.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao pressionar "Próximo"
		/// </summary>
		private void btnPróximo_Click(object sender, System.EventArgs e)
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

            if (!painel.ValidarTransição())
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
		/// <param name="nPainel">Número do painel exibido</param>
		private void AssistenteControle_MudançaPainel(PainelAssistente painel, int nPainel)
		{
			btnAnterior.Enabled = nPainel > 0;
			btnPróximo.Enabled  = Terminado != null || nPainel < Itens.Length - 1;
			
			if (Terminado != null)
			{
				if (nPainel < Itens.Length - 1)
				{
					btnPróximo.Text = strPróximo;
					mostrandoTerminar = false;
				}
				else
				{
					btnPróximo.Text = strTerminar;
					mostrandoTerminar = true;
				}
			}
		}

		/// <summary>
		/// Obtém tamanho do painel
		/// </summary>
		protected override Size TamanhoPainel
		{
			get
			{
				return new Size(ClientRectangle.Width, ClientRectangle.Height - painelInferior.Height);
			}
		}

		/// <summary>
		/// Permitir usuário avançar
		/// </summary>
		[Browsable(false),
			DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool PermitirPróximo
		{
			get { return btnPróximo.Enabled; }
			set { btnPróximo.Enabled = value; }
		}

		/// <summary>
		/// Exibe botão cancelar
		/// </summary>
		[DefaultValue(true)]
		public bool Cancelável
		{
			get { return btnCancelar.Visible; }
			set
            {
                if (!value && btnCancelar.Visible)
                {
                    btnAnterior.Location = btnPróximo.Location;
                    btnPróximo.Location = btnCancelar.Location;
                }
                else if (value && !btnCancelar.Visible)
                {
                    btnPróximo.Location = btnAnterior.Location;
                    btnAnterior.Location = new Point(
                        btnPróximo.Left - btnAnterior.Width - btnAnterior.Margin.Right,
                        btnPróximo.Top);
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

