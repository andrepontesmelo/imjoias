using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades;
using Negócio;

namespace Apresentação.Usuário.Agendamentos
{
	/// <summary>
	/// Balão para despertador.
	/// </summary>
	sealed class DespertadorBalão : Balloon.NET.BalloonWindow
	{
		// Atributos
		private Agendamento agendamento;
		private bool usuárioAlterou = false;	// Se usuário pediu p/ adiar

		// Eventos
		public delegate void DAgendamento(Agendamento agendamento);
		public event DAgendamento AlterarAgendamento;

		// Componentes
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnLembrarMaisTarde;
		private System.Windows.Forms.Label txtInfo;
		private System.Windows.Forms.GroupBox borda;
		private System.Windows.Forms.Label txtHoraDespertar;
		private System.Windows.Forms.Timer alarme;
		private System.ComponentModel.IContainer components;

		public Agendamento Entidade
		{
			get { return agendamento; }
		}
		public bool UsuárioAlterou 
		{
			get { return usuárioAlterou; }
		}

		public DespertadorBalão(Agendamento agendamentoParaMostrar)
		{
			InitializeComponent();

			if (this.DesignMode == true)
				return;

			borda.Text = "Compromisso para " + agendamentoParaMostrar.Data.ToLongDateString() + " " + agendamentoParaMostrar.Data.ToString("HH:mm");
			txtInfo.Text = agendamentoParaMostrar.Descrição;
			txtHoraDespertar.Text = agendamentoParaMostrar.Alarme.ToString("HH:mm");

			this.agendamento = agendamentoParaMostrar;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			Soar();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DespertadorBalão));
			this.btnFechar = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnLembrarMaisTarde = new System.Windows.Forms.Button();
			this.borda = new System.Windows.Forms.GroupBox();
			this.txtInfo = new System.Windows.Forms.Label();
			this.txtHoraDespertar = new System.Windows.Forms.Label();
			this.alarme = new System.Windows.Forms.Timer(this.components);
			this.borda.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnFechar
			// 
			this.btnFechar.BackColor = System.Drawing.SystemColors.Info;
			this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnFechar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnFechar.Location = new System.Drawing.Point(472, 0);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(20, 20);
			this.btnFechar.TabIndex = 0;
			this.btnFechar.Text = "x";
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// btnLembrarMaisTarde
			// 
			this.btnLembrarMaisTarde.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnLembrarMaisTarde.Location = new System.Drawing.Point(416, 48);
			this.btnLembrarMaisTarde.Name = "btnLembrarMaisTarde";
			this.btnLembrarMaisTarde.Size = new System.Drawing.Size(72, 32);
			this.btnLembrarMaisTarde.TabIndex = 3;
			this.btnLembrarMaisTarde.Text = "Lembrar mais tarde";
			this.btnLembrarMaisTarde.Click += new System.EventHandler(this.btnLembrarMaisTarde_Click);
			// 
			// borda
			// 
			this.borda.Controls.Add(this.txtInfo);
			this.borda.Location = new System.Drawing.Point(40, 8);
			this.borda.Name = "borda";
			this.borda.Size = new System.Drawing.Size(368, 72);
			this.borda.TabIndex = 6;
			this.borda.TabStop = false;
			this.borda.Text = "Comrpomisso para 21/12/04 21:23";
			// 
			// txtInfo
			// 
			this.txtInfo.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.txtInfo.Location = new System.Drawing.Point(8, 16);
			this.txtInfo.Name = "txtInfo";
			this.txtInfo.Size = new System.Drawing.Size(352, 48);
			this.txtInfo.TabIndex = 0;
			this.txtInfo.Text = "txtInfo";
			// 
			// txtHoraDespertar
			// 
			this.txtHoraDespertar.AutoSize = true;
			this.txtHoraDespertar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHoraDespertar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.txtHoraDespertar.ForeColor = System.Drawing.Color.Black;
			this.txtHoraDespertar.Location = new System.Drawing.Point(0, 40);
			this.txtHoraDespertar.Name = "txtHoraDespertar";
			this.txtHoraDespertar.Size = new System.Drawing.Size(35, 19);
			this.txtHoraDespertar.TabIndex = 7;
			this.txtHoraDespertar.Text = "12:48";
			this.txtHoraDespertar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// alarme
			// 
			this.alarme.Enabled = true;
			this.alarme.Interval = 10000;
			this.alarme.Tick += new System.EventHandler(this.alarme_Tick);
			// 
			// DespertadorBalão
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(496, 86);
			this.Controls.Add(this.txtHoraDespertar);
			this.Controls.Add(this.borda);
			this.Controls.Add(this.btnLembrarMaisTarde);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnFechar);
			this.Name = "DespertadorBalão";
			this.Text = "AvisoDespertador";
			this.borda.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnFechar_Click(object sender, System.EventArgs e)
		{
			alarme.Stop();
			
			// Dispara evento Closed(), O dispose é feito na base inferior.
			this.Close();
		}

		private void btnLembrarMaisTarde_Click(object sender, System.EventArgs e)
		{
			alarme.Stop();

			// Isto serve para a baseInferior não cancelar o lembre deste agendamento
			usuárioAlterou = true;
			AlterarAgendamento(agendamento);

			this.Close();
		}

		private void alarme_Tick(object sender, System.EventArgs e)
		{
			Soar();
		}

		private void Soar() 
		{
			txtInfo.ForeColor = System.Drawing.Color.Red;
			txtInfo.Refresh();
			
			Beepador.Despertador();

			txtInfo.ForeColor = System.Drawing.Color.DarkOliveGreen;
		}
	}
}
