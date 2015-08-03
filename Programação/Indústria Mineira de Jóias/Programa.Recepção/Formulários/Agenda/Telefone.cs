using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Programa.Recepção.Formulários.Agenda
{
	sealed class Telefone : Apresentação.Formulários.JanelaExplicativa
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.GroupBox grpTelefone;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblFixo;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.ComboBox txtEstado;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCidade;
		private System.Windows.Forms.Label label5;
        private Apresentação.Pessoa.TxtTelefone txtCelular;
        private Apresentação.Pessoa.TxtTelefone txtFixo;
        private Apresentação.Pessoa.TxtTelefone txtOutro;
		private System.ComponentModel.IContainer components = null;

		public Telefone()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Telefone));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.grpTelefone = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFixo = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.txtEstado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutro = new Apresentação.Pessoa.TxtTelefone();
            this.txtFixo = new Apresentação.Pessoa.TxtTelefone();
            this.txtCelular = new Apresentação.Pessoa.TxtTelefone();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.grpTelefone.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(167, 20);
            this.lblTítulo.Text = "Agenda de telefone";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(226, 48);
            this.lblDescrição.Text = "Preencha os dados abaixo a ser registrado na agenda de telefones.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(24, 120);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(264, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // grpTelefone
            // 
            this.grpTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTelefone.Controls.Add(this.txtOutro);
            this.grpTelefone.Controls.Add(this.txtFixo);
            this.grpTelefone.Controls.Add(this.txtCelular);
            this.grpTelefone.Controls.Add(this.label4);
            this.grpTelefone.Controls.Add(this.label3);
            this.grpTelefone.Controls.Add(this.lblFixo);
            this.grpTelefone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTelefone.Location = new System.Drawing.Point(24, 152);
            this.grpTelefone.Name = "grpTelefone";
            this.grpTelefone.Size = new System.Drawing.Size(264, 104);
            this.grpTelefone.TabIndex = 2;
            this.grpTelefone.TabStop = false;
            this.grpTelefone.Text = "Telefones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Outro:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Celular:";
            // 
            // lblFixo
            // 
            this.lblFixo.AutoSize = true;
            this.lblFixo.Location = new System.Drawing.Point(16, 24);
            this.lblFixo.Name = "lblFixo";
            this.lblFixo.Size = new System.Drawing.Size(29, 13);
            this.lblFixo.TabIndex = 2;
            this.lblFixo.Text = "Fixo:";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(232, 312);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(152, 312);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 6;
            this.cmdCancelar.Text = "Cancelar";
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstado.ItemHeight = 13;
            this.txtEstado.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.txtEstado.Location = new System.Drawing.Point(240, 280);
            this.txtEstado.MaxLength = 2;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(48, 21);
            this.txtEstado.TabIndex = 6;
            this.txtEstado.Text = "MG";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Estado:";
            // 
            // txtCidade
            // 
            this.txtCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCidade.Location = new System.Drawing.Point(24, 280);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(208, 20);
            this.txtCidade.TabIndex = 7;
            this.txtCidade.Text = "Belo Horizonte";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cidade:";
            // 
            // txtOutro
            // 
            this.txtOutro.BackColor = System.Drawing.Color.White;
            this.txtOutro.Location = new System.Drawing.Point(80, 72);
            this.txtOutro.Name = "txtOutro";
            this.txtOutro.Size = new System.Drawing.Size(168, 20);
            this.txtOutro.TabIndex = 4;
            // 
            // txtFixo
            // 
            this.txtFixo.BackColor = System.Drawing.Color.White;
            this.txtFixo.Location = new System.Drawing.Point(80, 24);
            this.txtFixo.Name = "txtFixo";
            this.txtFixo.Size = new System.Drawing.Size(168, 20);
            this.txtFixo.TabIndex = 2;
            // 
            // txtCelular
            // 
            this.txtCelular.BackColor = System.Drawing.Color.White;
            this.txtCelular.Location = new System.Drawing.Point(80, 48);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(168, 20);
            this.txtCelular.TabIndex = 3;
            // 
            // Telefone
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(314, 344);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpTelefone);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Name = "Telefone";
            this.Text = "Agenda de telefone";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.grpTelefone, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCidade, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.grpTelefone.ResumeLayout(false);
            this.grpTelefone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void txtNome_TextChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = txtNome.Text.Trim().Length > 0;
		}


		public string Nome
		{
			get { return txtNome.Text; }
			set { txtNome.Text = value; }
		}

		public string TelFixo
		{
			get { return txtFixo.Text; }
			set { txtFixo.Text = value; }
		}

		public string TelCelular
		{
			get { return txtCelular.Text; }
			set { txtCelular.Text = value; }
		}

		public string TelOutro
		{
			get { return txtOutro.Text; }
			set { txtOutro.Text = value; }
		}

		public string Cidade
		{
			get { return txtCidade.Text; }
			set { txtCidade.Text = value; }
		}

		public string Estado
		{
			get { return txtEstado.Text; }
			set { txtEstado.Text = value; }
		}
	}
}

