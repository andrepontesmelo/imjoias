using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Administra��o.Bases
{
	public class Mercadorias : Apresenta��o.Formul�rios.BaseInferior
	{
		private System.ComponentModel.IContainer components = null;

		public Mercadorias()
		{
			// This call is required by the Windows Form Designer.
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
			// 
			// esquerda
			// 
			this.esquerda.Name = "esquerda";
			// 
			// Mercadorias
			// 
			this.Name = "Mercadorias";
			this.Size = new System.Drawing.Size(472, 296);

		}
		#endregion
	}
}

