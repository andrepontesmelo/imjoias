using Entidades.Pessoa;
using Negócio;
using System;
using System.Windows.Forms;


namespace Programa.Recepção.Formulários.EntradaSaída
{
	/// <summary>
	/// Preparar início de atendimento ao cliente.
	/// </summary>
	sealed class IniciarAtendimento : System.Windows.Forms.Form
	{
        private Atendimento atendimento;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTítulo;
		private System.Windows.Forms.Label lblDescrição;
		private System.Windows.Forms.PictureBox picÍcone;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblAtendimento;
		private System.Windows.Forms.Button cmdOK;
		private System.Timers.Timer espera;
		private System.Timers.Timer alarme;
		private System.Windows.Forms.Button cmdAlarme;
        private Button cmdCancelar;
        private Apresentação.Pessoa.Consultas.TextBoxPessoa txtAtendente;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IniciarAtendimento(Atendimento atendimento)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Mostrar dados
			txtCliente.Text = atendimento.Visita.ExtrairNomes();
			txtAtendente.Pessoa = atendimento.Atendente;

            this.atendimento = atendimento;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IniciarAtendimento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTítulo = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.picÍcone = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblAtendimento = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.espera = new System.Timers.Timer();
            this.alarme = new System.Timers.Timer();
            this.cmdAlarme = new System.Windows.Forms.Button();
            this.txtAtendente = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.espera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarme)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblTítulo);
            this.panel1.Controls.Add(this.lblDescrição);
            this.panel1.Controls.Add(this.picÍcone);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 88);
            this.panel1.TabIndex = 1;
            // 
            // lblTítulo
            // 
            this.lblTítulo.AutoSize = true;
            this.lblTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTítulo.Location = new System.Drawing.Point(72, 16);
            this.lblTítulo.Name = "lblTítulo";
            this.lblTítulo.Size = new System.Drawing.Size(165, 20);
            this.lblTítulo.TabIndex = 4;
            this.lblTítulo.Text = "Aguardando cliente";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrição.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrição.Location = new System.Drawing.Point(72, 40);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(288, 32);
            this.lblDescrição.TabIndex = 3;
            this.lblDescrição.Text = "O cliente está sendo aguardado para atendimento. Favor encaminhá-lo.";
            // 
            // picÍcone
            // 
            this.picÍcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            this.picÍcone.Location = new System.Drawing.Point(16, 16);
            this.picÍcone.Name = "picÍcone";
            this.picÍcone.Size = new System.Drawing.Size(40, 59);
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picÍcone.TabIndex = 2;
            this.picÍcone.TabStop = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(16, 104);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCliente.Location = new System.Drawing.Point(18, 120);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(349, 20);
            this.txtCliente.TabIndex = 3;
            // 
            // lblAtendimento
            // 
            this.lblAtendimento.AutoSize = true;
            this.lblAtendimento.Location = new System.Drawing.Point(16, 155);
            this.lblAtendimento.Name = "lblAtendimento";
            this.lblAtendimento.Size = new System.Drawing.Size(59, 13);
            this.lblAtendimento.TabIndex = 4;
            this.lblAtendimento.Text = "Atendente:";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(211, 210);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // espera
            // 
            this.espera.AutoReset = false;
            this.espera.Enabled = true;
            this.espera.Interval = 5000;
            this.espera.SynchronizingObject = this;
            this.espera.Elapsed += new System.Timers.ElapsedEventHandler(this.espera_Elapsed);
            // 
            // alarme
            // 
            this.alarme.Interval = 3000;
            this.alarme.SynchronizingObject = this;
            this.alarme.Elapsed += new System.Timers.ElapsedEventHandler(this.alarme_Elapsed);
            // 
            // cmdAlarme
            // 
            this.cmdAlarme.Image = ((System.Drawing.Image)(resources.GetObject("cmdAlarme.Image")));
            this.cmdAlarme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAlarme.Location = new System.Drawing.Point(18, 210);
            this.cmdAlarme.Name = "cmdAlarme";
            this.cmdAlarme.Size = new System.Drawing.Size(112, 23);
            this.cmdAlarme.TabIndex = 6;
            this.cmdAlarme.Text = "Desligar alarme";
            this.cmdAlarme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAlarme.Visible = false;
            this.cmdAlarme.Click += new System.EventHandler(this.cmdAlarme_Click);
            // 
            // txtAtendente
            // 
            this.txtAtendente.AlturaProposta = 60;
            this.txtAtendente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAtendente.Funcionários = true;
            this.txtAtendente.Location = new System.Drawing.Point(19, 171);
            this.txtAtendente.MostrarCabeçalho = false;
            this.txtAtendente.Name = "txtAtendente";
            this.txtAtendente.Pessoa = null;
            this.txtAtendente.Size = new System.Drawing.Size(348, 20);
            this.txtAtendente.SomenteCadastrado = true;
            this.txtAtendente.TabIndex = 7;
            this.txtAtendente.Selecionado += new System.EventHandler(this.txtAtendente_Selecionado);
            this.txtAtendente.Deselecionado += new System.EventHandler(this.txtAtendente_Deselecionado);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(292, 210);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 8;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // IniciarAtendimento
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(384, 245);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.txtAtendente);
            this.Controls.Add(this.cmdAlarme);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lblAtendimento);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IniciarAtendimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encaminhar atendimento";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.espera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private int batidasAlarme = 0;

		private void alarme_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			batidasAlarme++;

			if (batidasAlarme <= 5)
				for (int i = 0; i <= batidasAlarme; i++)
				{
					Beepador.EsperandoPorAtendimento();
				}
			else
				for (int i = 0; i < 5; i++)
				{
					Beepador.EsperandoPorAtendimentoUrgente();
				}

			if (batidasAlarme > 15)
			{
				alarme.Enabled = false;
				espera.Enabled = true;
			}
		}

		private void espera_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			alarme.Enabled = true;
			cmdAlarme.Visible = true;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			espera.Enabled = false;
			alarme.Enabled = false;
		}

		private void cmdAlarme_Click(object sender, System.EventArgs e)
		{
			alarme.Enabled = false;
			espera.Enabled = false;
			cmdAlarme.Visible = false;
		}

        private void txtAtendente_Deselecionado(object sender, EventArgs e)
        {
            cmdOK.Enabled = false;
        }

        private void txtAtendente_Selecionado(object sender, EventArgs e)
        {
            cmdOK.Enabled = true;
            atendimento.Atendente = txtAtendente.Pessoa as Funcionário;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            espera.Enabled = false;
            alarme.Enabled = false;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

	}
}
