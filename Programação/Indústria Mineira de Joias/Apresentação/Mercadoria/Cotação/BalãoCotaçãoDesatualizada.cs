using System.ComponentModel;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Cota��o
{
    internal class Bal�oCota��oDesatualizada : Bal�oCota��o
	{
		private Label label1;
		private IContainer components = null;

		public Bal�oCota��oDesatualizada()
		{
			InitializeComponent();
		}

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
			this.label1.Text = "A cota��o escolhida n�o encontra-se atualizada. Certifique-se que sua escolha est" +
				"eja correta.";
			// 
			// Bal�oCota��oDesatualizada
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 78);
			this.Controls.Add(this.label1);
			this.Name = "Bal�oCota��oDesatualizada";
			this.Text = "Cota��o n�o atual!";
			this.Controls.SetChildIndex(this.label1, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

