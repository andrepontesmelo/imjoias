using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios.Assistente
{
	/// <summary>
	/// Summary description for ConjuntoPain�is.
	/// </summary>
	[Serializable]
    [DefaultProperty("PainelAtual")]
	public class ConjuntoPain�is : System.Windows.Forms.UserControl
	{
		// Atributos
		private int					painelAtual;
		private PainelAssistente []	pain�is = new PainelAssistente[0];
		private bool				ignorarRedimensionamento = false;
		private EventHandler		handlerPainelResize;

		// Eventos
		public delegate void PainelHandler(PainelAssistente painel, int nPainel);
		public event PainelHandler Mudan�aPainel;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConjuntoPain�is()
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
			// ConjuntoPain�is
			// 
			this.Name = "ConjuntoPain�is";
		}
		#endregion

		/// <summary>
		/// Painel em exibi��o
		/// </summary>
		[DefaultValue(0)]
		public int PainelAtual
		{
			get { return painelAtual; }
			set
			{
                if (value >= pain�is.Length || value < 0)
                    return;

                if (pain�is.Length > 0)
                {
                    pain�is[painelAtual].Hide();

                    painelAtual = value;

                    pain�is[painelAtual].Show();

                    if (Mudan�aPainel != null)
                        Mudan�aPainel(pain�is[painelAtual], painelAtual);
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

			foreach (PainelAssistente painel in pain�is)
				painel.Size = TamanhoPainel;

			ignorarRedimensionamento = false;
		}

		/// <summary>
		/// Conjunto de pain�is
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PainelAssistente [] Itens
		{
			get { return pain�is; }
			set
			{
				foreach (PainelAssistente painel in pain�is)
					RemoverPainel(painel);

				pain�is = value;

				foreach (PainelAssistente painel in pain�is)
					AdicionarPainel(painel);

				painelAtual = 0;
				
				if (pain�is.Length > 0)
					pain�is[0].Show();

				if (Mudan�aPainel != null)
					Mudan�aPainel(pain�is[painelAtual], painelAtual);
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
		/// Ocorre quando um painel � redimensionado
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

			foreach (PainelAssistente painel in pain�is)
				painel.Size = TamanhoPainel;

			ignorarRedimensionamento = false;
		}

	}
}
