using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negócio.Controle;

namespace Relatório.Recepção
{
	public class SolicitarVisitantes : Apresentação.Formulários.JanelaExplicativa
	{
		IAdministração controle;

		// Designer
		private System.Windows.Forms.Label lblPeríodoInicial;
		private System.Windows.Forms.DateTimePicker dtInício;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Label lblPeríodoFinal;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.ComponentModel.IContainer components = null;

		public SolicitarVisitantes(IAdministração controle)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Introduzir valores iniciais
			dtInício.Value = new DateTime(
				DateTime.Now.Year, DateTime.Now.Month,
				DateTime.Now.Day, 0, 0, 0 , 0);

			dtFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

			dtInício.MaxDate = DateTime.Now;
			dtFinal.MinDate = dtInício.MaxDate;
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
			this.lblPeríodoInicial = new System.Windows.Forms.Label();
			this.dtInício = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.lblPeríodoFinal = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(178, 22);
			this.lblTítulo.Text = "Relatório de Visitantes";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Text = "Escolha o período para a construir do relatório de visitantes.";
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Name = "picÍcone";
			// 
			// lblPeríodoInicial
			// 
			this.lblPeríodoInicial.AutoSize = true;
			this.lblPeríodoInicial.Location = new System.Drawing.Point(24, 106);
			this.lblPeríodoInicial.Name = "lblPeríodoInicial";
			this.lblPeríodoInicial.Size = new System.Drawing.Size(78, 16);
			this.lblPeríodoInicial.TabIndex = 3;
			this.lblPeríodoInicial.Text = "Período inicial:";
			// 
			// dtInício
			// 
			this.dtInício.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, HH:mm";
			this.dtInício.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtInício.Location = new System.Drawing.Point(112, 104);
			this.dtInício.MinDate = new System.DateTime(2003, 12, 1, 0, 0, 0, 0);
			this.dtInício.Name = "dtInício";
			this.dtInício.Size = new System.Drawing.Size(248, 20);
			this.dtInício.TabIndex = 4;
			this.dtInício.ValueChanged += new System.EventHandler(this.dtInício_ValueChanged);
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
			// lblPeríodoFinal
			// 
			this.lblPeríodoFinal.AutoSize = true;
			this.lblPeríodoFinal.Location = new System.Drawing.Point(24, 138);
			this.lblPeríodoFinal.Name = "lblPeríodoFinal";
			this.lblPeríodoFinal.Size = new System.Drawing.Size(70, 16);
			this.lblPeríodoFinal.TabIndex = 5;
			this.lblPeríodoFinal.Text = "Período final:";
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
			this.Controls.Add(this.lblPeríodoFinal);
			this.Controls.Add(this.dtInício);
			this.Controls.Add(this.lblPeríodoInicial);
			this.Name = "SolicitarVisitantes";
			this.Text = "Construção de relatório de visitantes";
			this.TopMost = false;
			this.Controls.SetChildIndex(this.lblPeríodoInicial, 0);
			this.Controls.SetChildIndex(this.dtInício, 0);
			this.Controls.SetChildIndex(this.lblPeríodoFinal, 0);
			this.Controls.SetChildIndex(this.dtFinal, 0);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.Controls.SetChildIndex(this.cmdCancelar, 0);
			this.ResumeLayout(false);

		}
		#endregion

		private void dtInício_ValueChanged(object sender, System.EventArgs e)
		{
			dtFinal.MinDate = dtInício.Value;
		}

		private void dtFinal_ValueChanged(object sender, System.EventArgs e)
		{
			dtInício.MaxDate = dtFinal.Value;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			RelatórioVisitas relat;

			relat = new RelatórioVisitas(
				controle,
				dtInício.Value,
				dtFinal.Value,
				"Lista de visitantes do período de " +
				dtInício.Value.ToLongDateString() + ", " +
				dtInício.Value.ToLongTimeString() + " a " + 
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

