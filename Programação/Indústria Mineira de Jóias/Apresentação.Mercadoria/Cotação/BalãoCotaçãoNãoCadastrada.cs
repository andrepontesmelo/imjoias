using System;

namespace Apresentação.Mercadoria.Cotação
{
	/// <summary>
	/// Balão ilustrativo informando que a cotação
	/// não estava cadastrada.s
	/// </summary>
	internal class BalãoCotaçãoNãoCadastrada : BalãoCotação
	{
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;

		public BalãoCotaçãoNãoCadastrada()
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
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 40);
			this.label1.TabIndex = 3;
			this.label1.Text = "A cotação escolhida não encontra-se cadastrada. Certifique-se que sua escolha est" +
				"eja correta.";
			// 
			// BalãoCotaçãoNãoCadastrada
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 78);
			this.Controls.Add(this.label1);
			this.Name = "BalãoCotaçãoNãoCadastrada";
			this.Text = "Cotação não cadastrada!";
			this.Controls.SetChildIndex(this.label1, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
