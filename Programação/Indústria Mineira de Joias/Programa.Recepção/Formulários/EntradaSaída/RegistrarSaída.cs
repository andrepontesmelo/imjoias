
namespace Programa.Recep��o.Formul�rios.EntradaSa�da
{
	sealed class RegistrarSa�da : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.Windows.Forms.Label lblVisitantes;
		private System.Windows.Forms.ListBox lstVisitantes;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.ComponentModel.IContainer components = null;

		public RegistrarSa�da(Entidades.Visita visita)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			foreach (string nome in visita.Nomes)
				lstVisitantes.Items.Add(nome);

			foreach (Entidades.Pessoa.PessoaF�sica pessoa in visita.Pessoas)
				lstVisitantes.Items.Add(pessoa.Nome);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RegistrarSa�da));
			this.lblVisitantes = new System.Windows.Forms.Label();
			this.lstVisitantes = new System.Windows.Forms.ListBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(121, 22);
			this.lblT�tulo.Text = "Registrar sa�da";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(176, 48);
			this.lblDescri��o.Text = "Confirme a sa�da do(s) visitante(s) abaixo:";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Name = "pic�cone";
			// 
			// lblVisitantes
			// 
			this.lblVisitantes.AutoSize = true;
			this.lblVisitantes.Location = new System.Drawing.Point(24, 104);
			this.lblVisitantes.Name = "lblVisitantes";
			this.lblVisitantes.Size = new System.Drawing.Size(174, 16);
			this.lblVisitantes.TabIndex = 3;
			this.lblVisitantes.Text = "Visitantes que deixam a empresa:";
			// 
			// lstVisitantes
			// 
			this.lstVisitantes.IntegralHeight = false;
			this.lstVisitantes.Location = new System.Drawing.Point(24, 120);
			this.lstVisitantes.Name = "lstVisitantes";
			this.lstVisitantes.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.lstVisitantes.Size = new System.Drawing.Size(224, 64);
			this.lstVisitantes.Sorted = true;
			this.lstVisitantes.TabIndex = 4;
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(184, 192);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 0;
			this.cmdOK.Text = "OK";
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancelar.Location = new System.Drawing.Point(104, 192);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.TabIndex = 1;
			this.cmdCancelar.Text = "Cancelar";
			// 
			// RegistrarSa�da
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancelar;
			this.ClientSize = new System.Drawing.Size(266, 224);
			this.Controls.Add(this.cmdCancelar);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.lstVisitantes);
			this.Controls.Add(this.lblVisitantes);
			this.Name = "RegistrarSa�da";
			this.Text = "Registrar sa�da";
			this.Controls.SetChildIndex(this.lblVisitantes, 0);
			this.Controls.SetChildIndex(this.lstVisitantes, 0);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.Controls.SetChildIndex(this.cmdCancelar, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

