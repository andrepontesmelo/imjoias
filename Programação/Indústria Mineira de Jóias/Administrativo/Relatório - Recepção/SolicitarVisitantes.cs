using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Neg�cio.Controle;

namespace Relat�rio.Recep��o
{
	public class SolicitarVisitantes : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		IAdministra��o controle;

		// Designer
		private System.Windows.Forms.Label lblPer�odoInicial;
		private System.Windows.Forms.DateTimePicker dtIn�cio;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Label lblPer�odoFinal;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.ComponentModel.IContainer components = null;

		public SolicitarVisitantes(IAdministra��o controle)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Introduzir valores iniciais
			dtIn�cio.Value = new DateTime(
				DateTime.Now.Year, DateTime.Now.Month,
				DateTime.Now.Day, 0, 0, 0 , 0);

			dtFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

			dtIn�cio.MaxDate = DateTime.Now;
			dtFinal.MinDate = dtIn�cio.MaxDate;
			dtFinal.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

			this.controle = controle;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SolicitarVisitantes));
			this.lblPer�odoInicial = new System.Windows.Forms.Label();
			this.dtIn�cio = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.lblPer�odoFinal = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(178, 22);
			this.lblT�tulo.Text = "Relat�rio de Visitantes";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Text = "Escolha o per�odo para a construir do relat�rio de visitantes.";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Name = "pic�cone";
			// 
			// lblPer�odoInicial
			// 
			this.lblPer�odoInicial.AutoSize = true;
			this.lblPer�odoInicial.Location = new System.Drawing.Point(24, 106);
			this.lblPer�odoInicial.Name = "lblPer�odoInicial";
			this.lblPer�odoInicial.Size = new System.Drawing.Size(78, 16);
			this.lblPer�odoInicial.TabIndex = 3;
			this.lblPer�odoInicial.Text = "Per�odo inicial:";
			// 
			// dtIn�cio
			// 
			this.dtIn�cio.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, HH:mm";
			this.dtIn�cio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtIn�cio.Location = new System.Drawing.Point(112, 104);
			this.dtIn�cio.MinDate = new System.DateTime(2003, 12, 1, 0, 0, 0, 0);
			this.dtIn�cio.Name = "dtIn�cio";
			this.dtIn�cio.Size = new System.Drawing.Size(248, 20);
			this.dtIn�cio.TabIndex = 4;
			this.dtIn�cio.ValueChanged += new System.EventHandler(this.dtIn�cio_ValueChanged);
			// 
			// dtFinal
			// 
			this.dtFinal.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, HH:mm";
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFinal.Location = new System.Drawing.Point(112, 136);
			this.dtFinal.MinDate = new System.DateTime(2003, 12, 1, 0, 0, 0, 0);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(248, 20);
			this.dtFinal.TabIndex = 6;
			this.dtFinal.ValueChanged += new System.EventHandler(this.dtFinal_ValueChanged);
			// 
			// lblPer�odoFinal
			// 
			this.lblPer�odoFinal.AutoSize = true;
			this.lblPer�odoFinal.Location = new System.Drawing.Point(24, 138);
			this.lblPer�odoFinal.Name = "lblPer�odoFinal";
			this.lblPer�odoFinal.Size = new System.Drawing.Size(70, 16);
			this.lblPer�odoFinal.TabIndex = 5;
			this.lblPer�odoFinal.Text = "Per�odo final:";
			// 
			// cmdOK
			// 
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(304, 168);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 7;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancelar.Location = new System.Drawing.Point(224, 168);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.TabIndex = 8;
			this.cmdCancelar.Text = "Cancelar";
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			// 
			// SolicitarVisitantes
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancelar;
			this.ClientSize = new System.Drawing.Size(392, 200);
			this.Controls.Add(this.cmdCancelar);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.lblPer�odoFinal);
			this.Controls.Add(this.dtIn�cio);
			this.Controls.Add(this.lblPer�odoInicial);
			this.Name = "SolicitarVisitantes";
			this.Text = "Constru��o de relat�rio de visitantes";
			this.TopMost = false;
			this.Controls.SetChildIndex(this.lblPer�odoInicial, 0);
			this.Controls.SetChildIndex(this.dtIn�cio, 0);
			this.Controls.SetChildIndex(this.lblPer�odoFinal, 0);
			this.Controls.SetChildIndex(this.dtFinal, 0);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.Controls.SetChildIndex(this.cmdCancelar, 0);
			this.ResumeLayout(false);

		}
		#endregion

		private void dtIn�cio_ValueChanged(object sender, System.EventArgs e)
		{
			dtFinal.MinDate = dtIn�cio.Value;
		}

		private void dtFinal_ValueChanged(object sender, System.EventArgs e)
		{
			dtIn�cio.MaxDate = dtFinal.Value;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			Relat�rioVisitas relat;

			relat = new Relat�rioVisitas(
				controle,
				dtIn�cio.Value,
				dtFinal.Value,
				"Lista de visitantes do per�odo de " +
				dtIn�cio.Value.ToLongDateString() + ", " +
				dtIn�cio.Value.ToLongTimeString() + " a " + 
				dtFinal.Value.ToLongDateString() + ", " +
				dtFinal.Value.ToLongTimeString());

			relat.Owner = this.Owner;
			relat.Show();
			this.Close();
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}

