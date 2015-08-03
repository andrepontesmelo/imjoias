using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Summary description for Linha.
	/// </summary>
	public class Linha : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Linha()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			// Linha
			// 
			this.Name = "Linha";
			this.Resize += new System.EventHandler(this.LinhaResize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.LinhaPaint);

		}
		#endregion
		Pen caneta1 = new Pen(SystemColors.ControlLightLight);
		Pen caneta2 = new Pen(SystemColors.ControlDarkDark);
		
		void LinhaPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawLine(caneta2, 0, 0, Width, 0);
			e.Graphics.DrawLine(caneta1, 0, 1, Width, 1);
		}
		
		void LinhaResize(object sender, System.EventArgs e)
		{
			this.Height = 2;
		}

	}
}
