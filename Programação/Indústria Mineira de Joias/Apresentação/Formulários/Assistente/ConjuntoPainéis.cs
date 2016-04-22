using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresentação.Formulários.Assistente
{
	/// <summary>
	/// Summary description for ConjuntoPainéis.
	/// </summary>
	[Serializable]
    [DefaultProperty("PainelAtual")]
	public class ConjuntoPainéis : System.Windows.Forms.UserControl
	{
		// Atributos
		private int					painelAtual;
		private PainelAssistente []	painéis = new PainelAssistente[0];
		private bool				ignorarRedimensionamento = false;
		private EventHandler		handlerPainelResize;

		// Eventos
		public delegate void PainelHandler(PainelAssistente painel, int nPainel);
		public event PainelHandler MudançaPainel;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConjuntoPainéis()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			handlerPainelResize = new EventHandler(painel_Resize);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ConjuntoPainéis
			// 
			this.Name = "ConjuntoPainéis";
		}
		#endregion

		/// <summary>
		/// Painel em exibição
		/// </summary>
		[DefaultValue(0)]
		public int PainelAtual
		{
			get { return painelAtual; }
			set
			{
                if (value >= painéis.Length || value < 0)
                    return;

                if (painéis.Length > 0)
                {
                    painéis[painelAtual].Hide();

                    painelAtual = value;

                    painéis[painelAtual].Show();

                    if (MudançaPainel != null)
                        MudançaPainel(painéis[painelAtual], painelAtual);
                }
			}
		}

		/// <summary>
		/// Adiciona novo painel
		/// </summary>
		/// <returns>Novo painel</returns>
		private void AdicionarPainel(PainelAssistente painel)
		{
			this.Controls.Add(painel);

			painel.Visible  = false;
			painel.Location = new Point(0, 0);
			painel.Dock     = DockStyle.None;
			painel.Anchor   = AnchorStyles.Top | AnchorStyles.Left;
			painel.Size     = TamanhoPainel;
			painel.AutoScroll = true;
			painel.Resize  += handlerPainelResize;
		}

		/// <summary>
		/// Remove um painel
		/// </summary>
		/// <param name="painel">Painel a ser removido</param>
		private void RemoverPainel(PainelAssistente painel)
		{
			this.Controls.Remove(painel);

			painel.Resize -= handlerPainelResize;
			
			if (painel.Visible)
				PainelAtual = 0;
		}

		/// <summary>
		/// Ocorre ao mudar o tamanho do controle
		/// </summary>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged (e);

			ignorarRedimensionamento = true;

			foreach (PainelAssistente painel in painéis)
				painel.Size = TamanhoPainel;

			ignorarRedimensionamento = false;
		}

		/// <summary>
		/// Conjunto de painéis
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PainelAssistente [] Itens
		{
			get { return painéis; }
			set
			{
				foreach (PainelAssistente painel in painéis)
					RemoverPainel(painel);

				painéis = value;

				foreach (PainelAssistente painel in painéis)
					AdicionarPainel(painel);

				painelAtual = 0;
				
				if (painéis.Length > 0)
					painéis[0].Show();

				if (MudançaPainel != null)
					MudançaPainel(painéis[painelAtual], painelAtual);
			}
		}

		/// <summary>
		/// Tamanho do painel
		/// </summary>
		protected virtual Size TamanhoPainel
		{
			get { return ClientRectangle.Size; }
		}

		/// <summary>
		/// Ocorre quando um painel é redimensionado
		/// </summary>
		private void painel_Resize(object sender, EventArgs e)
		{
			if (!ignorarRedimensionamento)
			{
				ignorarRedimensionamento = true;

				((PainelAssistente) sender).Size = TamanhoPainel;

				ignorarRedimensionamento = false;
			}
		}

		/// <summary>
		/// Ocorre ao redimensionar o controle
		/// </summary>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);

			ignorarRedimensionamento = true;

			foreach (PainelAssistente painel in painéis)
				painel.Size = TamanhoPainel;

			ignorarRedimensionamento = false;
		}

	}
}
