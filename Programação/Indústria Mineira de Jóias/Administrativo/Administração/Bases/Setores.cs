using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negócio;

namespace Administração.Bases
{
	public class Setores : Apresentação.Formulários.BaseInferior
	{
		// Run-time
		private int			_proxChkPos = 0;

		// Designer
		private System.Windows.Forms.GroupBox grpSetores;
		private System.Windows.Forms.Panel painelSetores;
		private Administração.Bases.Setor.InfSetor infSetor;
		private System.ComponentModel.IContainer components = null;

		public Setores()
		{
			ArrayList setores;

			InitializeComponent();

			// Obter setores
			setores = Principal.Controle.ObterSetores();
			setores.Sort();

			foreach (ISetor setor in setores)
				AdicionarSetor(setor);
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
			this.grpSetores = new System.Windows.Forms.GroupBox();
			this.painelSetores = new System.Windows.Forms.Panel();
			this.infSetor = new Administração.Bases.Setor.InfSetor();
			this.grpSetores.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			this.esquerda.Name = "esquerda";
			// 
			// grpSetores
			// 
			this.grpSetores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpSetores.Controls.Add(this.painelSetores);
			this.grpSetores.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpSetores.Location = new System.Drawing.Point(192, 8);
			this.grpSetores.Name = "grpSetores";
			this.grpSetores.Size = new System.Drawing.Size(368, 48);
			this.grpSetores.TabIndex = 6;
			this.grpSetores.TabStop = false;
			this.grpSetores.Text = "Setores";
			// 
			// painelSetores
			// 
			this.painelSetores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.painelSetores.AutoScroll = true;
			this.painelSetores.Location = new System.Drawing.Point(8, 16);
			this.painelSetores.Name = "painelSetores";
			this.painelSetores.Size = new System.Drawing.Size(352, 24);
			this.painelSetores.TabIndex = 0;
			// 
			// infSetor
			// 
			this.infSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.infSetor.Location = new System.Drawing.Point(192, 64);
			this.infSetor.Name = "infSetor";
			this.infSetor.Size = new System.Drawing.Size(368, 224);
			this.infSetor.TabIndex = 7;
			this.infSetor.Visible = false;
			// 
			// Setores
			// 
			this.Controls.Add(this.infSetor);
			this.Controls.Add(this.grpSetores);
			this.Name = "Setores";
			this.Size = new System.Drawing.Size(568, 296);
			this.Controls.SetChildIndex(this.grpSetores, 0);
			this.Controls.SetChildIndex(this.infSetor, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.grpSetores.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Adiciona um setor à lista de setores
		/// </summary>
		/// <param name="setor">Setor a ser adicionado</param>
		private void AdicionarSetor(ISetor setor)
		{
			RadioButton radioSetor;

			if (setor.Dados.Código < 0)
				return;

			// Constrói novo CheckBox
			radioSetor = new RadioButton();
			radioSetor.Text = setor.Dados.Nome;
			radioSetor.Name = "radioSetor" + setor.Dados.Nome;
			radioSetor.Appearance = Appearance.Button;
			radioSetor.FlatStyle = FlatStyle.System;
			radioSetor.Size = new Size(104, 24);
			radioSetor.Location = new Point(_proxChkPos, 0);
			radioSetor.Visible = true;
			radioSetor.Tag = setor.Dados.Código;
			radioSetor.Click += new EventHandler(radioSetor_Click);
			painelSetores.Controls.Add(radioSetor);

			_proxChkPos += radioSetor.Width + 8;
		}

		/// <summary>
		/// Seleção de setor
		/// </summary>
		private void radioSetor_Click(object sender, EventArgs e)
		{
			long	código;
			ISetor	setor;

			this.Cursor = Cursors.WaitCursor;

			código = (long) ((RadioButton) sender).Tag;
			setor  = Principal.Controle.ObterSetor(código);

			// Preparar informações relativas ao setor
			infSetor.Visible = setor.Dados.Atendimento;

			if (infSetor.Visible)
				infSetor.Preparar(código);

			this.Cursor = Cursors.Default;
		}
	}
}

