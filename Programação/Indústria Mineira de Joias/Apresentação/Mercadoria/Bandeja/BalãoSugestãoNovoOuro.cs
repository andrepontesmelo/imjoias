using System.ComponentModel;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Bandeja
{
    public class Bal�oSugest�oNovoOuro : Balloon.NET.BalloonWindow
	{
		private Label label1;
		private IContainer components = null;

		public Bal�oSugest�oNovoOuro()
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
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Uma nova cota��o foi cadastrada";
			
			// 
			// Bal�oSugest�oNovoOuro
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 102);
			this.Controls.Add(this.label1);
			this.Name = "Bal�oSugest�oNovoOuro";
			this.ResumeLayout(false);

		}
		#endregion
	}
}

