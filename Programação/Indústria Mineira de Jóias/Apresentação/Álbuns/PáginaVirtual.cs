using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresenta��o.�lbum.Edi��o.�lbuns
{
	/// <summary>
	/// Summary description for P�ginaVirtual.
	/// </summary>
	public class P�ginaVirtual : System.Windows.Forms.UserControl
	{
		private Desenhista.P�ginaInfinita		p�ginaInfinita;
		private Desenhista.ItensImpress�o		itens = Desenhista.ItensImpress�o.Refer�ncia | Desenhista.ItensImpress�o.Foto | Desenhista.ItensImpress�o.Descri��o | Desenhista.ItensImpress�o.Fornecedor;
        private Entidades.�lbum.Foto[] fotos = new Entidades.�lbum.Foto[0];

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public P�ginaVirtual()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			p�ginaInfinita = new Desenhista.P�ginaInfinita(this.Width);
		}

		public Entidades.�lbum.Foto [] Fotos
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
            // P�ginaVirtual
            // 
            this.AutoScroll = true;
            this.Name = "P�ginaVirtual";
            this.Resize += new System.EventHandler(this.P�ginaVirtual_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.P�ginaVirtual_Paint);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Desenha a p�gina no controle
		/// </summary>
		private void P�ginaVirtual_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			p�ginaInfinita.Imprimir(e.Graphics, "Virtual", fotos, itens, 0);
		}

		private void P�ginaVirtual_Resize(object sender, System.EventArgs e)
		{
			p�ginaInfinita.Largura = this.Width;
			this.Invalidate();
		}
	}
}
