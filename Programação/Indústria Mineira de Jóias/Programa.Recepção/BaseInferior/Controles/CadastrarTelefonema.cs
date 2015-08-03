using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Entidades.Configuração;

namespace Programa.Recepção.BaseInferior.Controles
{
	/// <summary>
	/// Controle para o cadastro de telefonema.
	/// </summary>
	sealed class CadastrarTelefonema : System.Windows.Forms.UserControl
	{
		public delegate void Comando();
		public event Comando Cancelar;
		public event Comando OK;

		// Designer
		private System.Windows.Forms.GroupBox grpOrigem;
		private System.Windows.Forms.RadioButton optOrigemFuncionário;
		private System.Windows.Forms.RadioButton optOrigemVisitante;
		private System.Windows.Forms.RadioButton optOrigemExterno;
		private System.Windows.Forms.Label lblOrigemNome;
		private System.Windows.Forms.GroupBox grpDestino;
		private System.Windows.Forms.RadioButton optDestinoParticular;
		private System.Windows.Forms.RadioButton optDestinoCliente;
		private System.Windows.Forms.RadioButton optDestinoFuncionário;
		private System.Windows.Forms.Label lblDestinoNome;
		private System.Windows.Forms.GroupBox grpTelefonema;
		private System.Windows.Forms.Label lblOrigemTelefone;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCidade;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.TextBox txtHora;
		private Apresentação.Pessoa.Consultas.TextBoxPessoa txtOrigemNome;
		private Apresentação.Pessoa.Consultas.TextBoxPessoa txtDestinoNome;
		private System.Windows.Forms.Button cmdAgora;
        private Apresentação.Pessoa.TxtTelefone txtTelefone;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CadastrarTelefonema()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.grpOrigem = new System.Windows.Forms.GroupBox();
            this.txtOrigemNome = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.optOrigemExterno = new System.Windows.Forms.RadioButton();
            this.optOrigemVisitante = new System.Windows.Forms.RadioButton();
            this.optOrigemFuncionário = new System.Windows.Forms.RadioButton();
            this.lblOrigemNome = new System.Windows.Forms.Label();
            this.grpDestino = new System.Windows.Forms.GroupBox();
            this.txtDestinoNome = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            this.optDestinoParticular = new System.Windows.Forms.RadioButton();
            this.optDestinoCliente = new System.Windows.Forms.RadioButton();
            this.optDestinoFuncionário = new System.Windows.Forms.RadioButton();
            this.lblDestinoNome = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.grpTelefonema = new System.Windows.Forms.GroupBox();
            this.txtTelefone = new Apresentação.Pessoa.TxtTelefone();
            this.cmdAgora = new System.Windows.Forms.Button();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrigemTelefone = new System.Windows.Forms.Label();
            this.grpOrigem.SuspendLayout();
            this.grpDestino.SuspendLayout();
            this.grpTelefonema.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOrigem
            // 
            this.grpOrigem.Controls.Add(this.txtOrigemNome);
            this.grpOrigem.Controls.Add(this.optOrigemExterno);
            this.grpOrigem.Controls.Add(this.optOrigemVisitante);
            this.grpOrigem.Controls.Add(this.optOrigemFuncionário);
            this.grpOrigem.Controls.Add(this.lblOrigemNome);
            this.grpOrigem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOrigem.Location = new System.Drawing.Point(8, 8);
            this.grpOrigem.Name = "grpOrigem";
            this.grpOrigem.Size = new System.Drawing.Size(344, 96);
            this.grpOrigem.TabIndex = 0;
            this.grpOrigem.TabStop = false;
            this.grpOrigem.Text = "Origem";
            // 
            // txtOrigemNome
            // 
            this.txtOrigemNome.Funcionários = true;
            this.txtOrigemNome.Location = new System.Drawing.Point(16, 40);
            this.txtOrigemNome.MostrarCabeçalho = false;
            this.txtOrigemNome.Name = "txtOrigemNome";
            this.txtOrigemNome.Size = new System.Drawing.Size(312, 20);
            this.txtOrigemNome.TabIndex = 6;
            // 
            // optOrigemExterno
            // 
            this.optOrigemExterno.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optOrigemExterno.Location = new System.Drawing.Point(224, 64);
            this.optOrigemExterno.Name = "optOrigemExterno";
            this.optOrigemExterno.Size = new System.Drawing.Size(104, 24);
            this.optOrigemExterno.TabIndex = 5;
            this.optOrigemExterno.Text = "Ligação a cobrar";
            // 
            // optOrigemVisitante
            // 
            this.optOrigemVisitante.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optOrigemVisitante.Location = new System.Drawing.Point(120, 64);
            this.optOrigemVisitante.Name = "optOrigemVisitante";
            this.optOrigemVisitante.Size = new System.Drawing.Size(104, 24);
            this.optOrigemVisitante.TabIndex = 4;
            this.optOrigemVisitante.Text = "Visitante";
            // 
            // optOrigemFuncionário
            // 
            this.optOrigemFuncionário.Checked = true;
            this.optOrigemFuncionário.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optOrigemFuncionário.Location = new System.Drawing.Point(16, 64);
            this.optOrigemFuncionário.Name = "optOrigemFuncionário";
            this.optOrigemFuncionário.Size = new System.Drawing.Size(104, 24);
            this.optOrigemFuncionário.TabIndex = 3;
            this.optOrigemFuncionário.TabStop = true;
            this.optOrigemFuncionário.Text = "Funcionário";
            this.optOrigemFuncionário.CheckedChanged += new System.EventHandler(this.optOrigemFuncionário_CheckedChanged);
            // 
            // lblOrigemNome
            // 
            this.lblOrigemNome.AutoSize = true;
            this.lblOrigemNome.Location = new System.Drawing.Point(16, 24);
            this.lblOrigemNome.Name = "lblOrigemNome";
            this.lblOrigemNome.Size = new System.Drawing.Size(38, 13);
            this.lblOrigemNome.TabIndex = 1;
            this.lblOrigemNome.Text = "Nome:";
            // 
            // grpDestino
            // 
            this.grpDestino.Controls.Add(this.txtDestinoNome);
            this.grpDestino.Controls.Add(this.optDestinoParticular);
            this.grpDestino.Controls.Add(this.optDestinoCliente);
            this.grpDestino.Controls.Add(this.optDestinoFuncionário);
            this.grpDestino.Controls.Add(this.lblDestinoNome);
            this.grpDestino.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDestino.Location = new System.Drawing.Point(8, 112);
            this.grpDestino.Name = "grpDestino";
            this.grpDestino.Size = new System.Drawing.Size(344, 96);
            this.grpDestino.TabIndex = 6;
            this.grpDestino.TabStop = false;
            this.grpDestino.Text = "Destino";
            // 
            // txtDestinoNome
            // 
            this.txtDestinoNome.Location = new System.Drawing.Point(16, 40);
            this.txtDestinoNome.MostrarCabeçalho = false;
            this.txtDestinoNome.Name = "txtDestinoNome";
            this.txtDestinoNome.Size = new System.Drawing.Size(312, 20);
            this.txtDestinoNome.TabIndex = 12;
            // 
            // optDestinoParticular
            // 
            this.optDestinoParticular.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optDestinoParticular.Location = new System.Drawing.Point(224, 64);
            this.optDestinoParticular.Name = "optDestinoParticular";
            this.optDestinoParticular.Size = new System.Drawing.Size(104, 24);
            this.optDestinoParticular.TabIndex = 11;
            this.optDestinoParticular.Text = "Particular";
            // 
            // optDestinoCliente
            // 
            this.optDestinoCliente.Checked = true;
            this.optDestinoCliente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optDestinoCliente.Location = new System.Drawing.Point(120, 64);
            this.optDestinoCliente.Name = "optDestinoCliente";
            this.optDestinoCliente.Size = new System.Drawing.Size(104, 24);
            this.optDestinoCliente.TabIndex = 10;
            this.optDestinoCliente.TabStop = true;
            this.optDestinoCliente.Text = "Cliente";
            // 
            // optDestinoFuncionário
            // 
            this.optDestinoFuncionário.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optDestinoFuncionário.Location = new System.Drawing.Point(16, 64);
            this.optDestinoFuncionário.Name = "optDestinoFuncionário";
            this.optDestinoFuncionário.Size = new System.Drawing.Size(104, 24);
            this.optDestinoFuncionário.TabIndex = 9;
            this.optDestinoFuncionário.Text = "Funcionário";
            this.optDestinoFuncionário.CheckedChanged += new System.EventHandler(this.optDestinoFuncionário_CheckedChanged);
            // 
            // lblDestinoNome
            // 
            this.lblDestinoNome.AutoSize = true;
            this.lblDestinoNome.Location = new System.Drawing.Point(16, 24);
            this.lblDestinoNome.Name = "lblDestinoNome";
            this.lblDestinoNome.Size = new System.Drawing.Size(38, 13);
            this.lblDestinoNome.TabIndex = 7;
            this.lblDestinoNome.Text = "Nome:";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(280, 344);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 19;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(200, 344);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 20;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // grpTelefonema
            // 
            this.grpTelefonema.Controls.Add(this.txtTelefone);
            this.grpTelefonema.Controls.Add(this.cmdAgora);
            this.grpTelefonema.Controls.Add(this.txtHora);
            this.grpTelefonema.Controls.Add(this.label2);
            this.grpTelefonema.Controls.Add(this.txtCidade);
            this.grpTelefonema.Controls.Add(this.label1);
            this.grpTelefonema.Controls.Add(this.lblOrigemTelefone);
            this.grpTelefonema.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTelefonema.Location = new System.Drawing.Point(8, 216);
            this.grpTelefonema.Name = "grpTelefonema";
            this.grpTelefonema.Size = new System.Drawing.Size(344, 120);
            this.grpTelefonema.TabIndex = 12;
            this.grpTelefonema.TabStop = false;
            this.grpTelefonema.Text = "Telefonema";
            // 
            // txtTelefone
            // 
            this.txtTelefone.BackColor = System.Drawing.Color.White;
            this.txtTelefone.Location = new System.Drawing.Point(16, 40);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(104, 20);
            this.txtTelefone.TabIndex = 20;
            // 
            // cmdAgora
            // 
            this.cmdAgora.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAgora.Location = new System.Drawing.Point(16, 88);
            this.cmdAgora.Name = "cmdAgora";
            this.cmdAgora.Size = new System.Drawing.Size(104, 24);
            this.cmdAgora.TabIndex = 19;
            this.cmdAgora.Text = "Agora";
            this.cmdAgora.Click += new System.EventHandler(this.cmdAgora_Click);
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(136, 88);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(192, 20);
            this.txtHora.TabIndex = 18;
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Hora:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(136, 40);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(192, 20);
            this.txtCidade.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cidade:";
            // 
            // lblOrigemTelefone
            // 
            this.lblOrigemTelefone.AutoSize = true;
            this.lblOrigemTelefone.Location = new System.Drawing.Point(16, 24);
            this.lblOrigemTelefone.Name = "lblOrigemTelefone";
            this.lblOrigemTelefone.Size = new System.Drawing.Size(52, 13);
            this.lblOrigemTelefone.TabIndex = 14;
            this.lblOrigemTelefone.Text = "Telefone:";
            // 
            // CadastrarTelefonema
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpTelefonema);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpDestino);
            this.Controls.Add(this.grpOrigem);
            this.Name = "CadastrarTelefonema";
            this.Size = new System.Drawing.Size(360, 368);
            this.Load += new System.EventHandler(this.CadastrarTelefonema_Load);
            this.grpOrigem.ResumeLayout(false);
            this.grpOrigem.PerformLayout();
            this.grpDestino.ResumeLayout(false);
            this.grpDestino.PerformLayout();
            this.grpTelefonema.ResumeLayout(false);
            this.grpTelefonema.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Cancelar();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			txtOrigemNome.Text = txtOrigemNome.Text.Trim();
			txtTelefone.Text = txtTelefone.Text.Trim();
			txtCidade.Text = txtCidade.Text.Trim();
			txtDestinoNome.Text = txtDestinoNome.Text.Trim();

			//Alteração andré abaixo: o destino pode ser <vazio> sim !  
			// retirei || txtDestinoNome.Text.Length < 1
			if (txtOrigemNome.Text.Length < 1 ||
				txtTelefone.Text.Length < 1 ||
				txtCidade.Text.Length < 1)
				MessageBox.Show("Por favor, preencha corretamente os dados do formulário.",
					"Dados incorretos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			
			else if ( (txtDestinoNome.Text.Length < 1) && 
				( optDestinoParticular.Checked == false )  ) 
			
				MessageBox.Show("Clique em 'Particular' se preferir não entrar com o destino.",
					"Dados incorretos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			else
				OK();
		}

		public void Preparar()
		{
			if (!this.DesignMode)
			{
				//txtDestinoNome.Controle = Recepção.Controle;
			}
			txtOrigemNome.Focus();
			txtOrigemNome.Text = "";
			optOrigemFuncionário.Checked = true;
			txtDestinoNome.Text = "";
			optDestinoCliente.Checked = true;
			txtTelefone.Text = "";
			txtCidade.Text = "Belo Horizonte";
			AtualizaHorário();
		}

		public void AtualizaHorário() 
		{
			txtHora.Text = DateTime.Now.ToString(DadosGlobais.Instância.Cultura);
		}
	
		private void optOrigemFuncionário_CheckedChanged(object sender, System.EventArgs e)
		{
			txtOrigemNome.Funcionários = optOrigemFuncionário.Checked;
		}

		private void optDestinoFuncionário_CheckedChanged(object sender, System.EventArgs e)
		{
			txtDestinoNome.Funcionários = optDestinoFuncionário.Checked;
		}

		private void cmdAgora_Click(object sender, System.EventArgs e)
		{
			AtualizaHorário();
		}

		public Telefonema.TipoOrigem TipoOrigem
		{
			get
			{
				if (optOrigemFuncionário.Checked)
					return Telefonema.TipoOrigem.Funcionário;
				else if (optOrigemVisitante.Checked)
					return Telefonema.TipoOrigem.Visitante;
				else
					return Telefonema.TipoOrigem.Externo;
			}
		}

		public Telefonema.TipoDestino TipoDestino
		{
			get
			{
				if (optDestinoFuncionário.Checked)
					return Telefonema.TipoDestino.Funcionário;
				else if (optDestinoCliente.Checked)
					return Telefonema.TipoDestino.Cliente;
				else
					return Telefonema.TipoDestino.Particular;
			}
		}

		public DateTime Quando
		{
			get
			{
				return DateTime.Parse(txtHora.Text);
			}
		}

		public string Telefone
		{
			get { return txtTelefone.Text; }
		}

		public string Origem
		{
			get { return txtOrigemNome.Text; }
		}
		
		public string Destino
		{
			get { return txtDestinoNome.Text; }
		}

		public string Cidade
		{
			get { return txtCidade.Text; }
		}

        private void CadastrarTelefonema_Load(object sender, EventArgs e)
        {
            Preparar();
        }
	}
}