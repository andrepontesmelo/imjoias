using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresentação.Álbum.Edição.Álbuns
{
	/// <summary>
	/// Summary description for PáginaVirtual.
	/// </summary>
	public class PáginaVirtual : System.Windows.Forms.UserControl
	{
		private Desenhista.PáginaInfinita		páginaInfinita;
		private Desenhista.ItensImpressão		itens = Desenhista.ItensImpressão.Referência | Desenhista.ItensImpressão.Foto | Desenhista.ItensImpressão.Descrição | Desenhista.ItensImpressão.Fornecedor;
        private Entidades.Álbum.Foto[] fotos = new Entidades.Álbum.Foto[0];

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PáginaVirtual()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			páginaInfinita = new Desenhista.PáginaInfinita(this.Width);
		}

		public Entidades.Álbum.Foto [] Fotos
		{
			get { return fotos; }
			set { fotos = value; }
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
            this.SuspendLayout();
            // 
            // PáginaVirtual
            // 
            this.AutoScroll = true;
            this.Name = "PáginaVirtual";
            this.Resize += new System.EventHandler(this.PáginaVirtual_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PáginaVirtual_Paint);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Desenha a página no controle
		/// </summary>
		private void PáginaVirtual_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			páginaInfinita.Imprimir(e.Graphics, "Virtual", fotos, itens, 0);
		}

		private void PáginaVirtual_Resize(object sender, System.EventArgs e)
		{
			páginaInfinita.Largura = this.Width;
			this.Invalidate();
		}
	}
}
