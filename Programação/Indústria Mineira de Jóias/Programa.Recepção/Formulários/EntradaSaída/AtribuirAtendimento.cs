using System.Collections.Generic;
using System.Windows.Forms;

namespace Programa.Recepção.Formulários.EntradaSaída
{
	sealed class AtribuirAtendimento : Apresentação.Formulários.JanelaExplicativa
	{
		private System.Windows.Forms.Label lblFuncionário;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.Label lblCLiente;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.ComponentModel.IContainer components = null;
		private Apresentação.Pessoa.Consultas.ListViewFuncionários lstFuncionários;

		public AtribuirAtendimento(string cliente, IEnumerable<Entidades.Pessoa.Funcionário> funcionários)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Mostrar dados
			txtCliente.Text = cliente;

			lstFuncionários.Funcionários = funcionários;
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


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtribuirAtendimento));
            this.lblFuncionário = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.lstFuncionários = new Apresentação.Pessoa.Consultas.ListViewFuncionários();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(131, 20);
            this.lblTítulo.Text = "Atender cliente";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(533, 48);
            this.lblDescrição.Text = "Escolha o funcionário que atenderá o cliente, logo que disponível.";
            // 
            // picÍcone
            // 
            this.picÍcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            this.picÍcone.Location = new System.Drawing.Point(16, 16);
            this.picÍcone.Size = new System.Drawing.Size(40, 59);
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // lblFuncionário
            // 
            this.lblFuncionário.AutoSize = true;
            this.lblFuncionário.Location = new System.Drawing.Point(32, 146);
            this.lblFuncionário.Name = "lblFuncionário";
            this.lblFuncionário.Size = new System.Drawing.Size(65, 13);
            this.lblFuncionário.TabIndex = 7;
            this.lblFuncionário.Text = "Funcionário:";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(35, 112);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(562, 20);
            this.txtCliente.TabIndex = 6;
            // 
            // lblCLiente
            // 
            this.lblCLiente.AutoSize = true;
            this.lblCLiente.Location = new System.Drawing.Point(32, 97);
            this.lblCLiente.Name = "lblCLiente";
            this.lblCLiente.Size = new System.Drawing.Size(42, 13);
            this.lblCLiente.TabIndex = 5;
            this.lblCLiente.Text = "Cliente:";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(525, 436);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(444, 436);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 10;
            this.cmdCancelar.Text = "Cancelar";
            // 
            // lstFuncionários
            // 
            this.lstFuncionários.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFuncionários.ÊnfaseSetor = null;
            this.lstFuncionários.Funcionários = null;
            this.lstFuncionários.Location = new System.Drawing.Point(32, 160);
            this.lstFuncionários.Name = "lstFuncionários";
            this.lstFuncionários.Size = new System.Drawing.Size(565, 270);
            this.lstFuncionários.TabIndex = 11;
            this.lstFuncionários.SelectedIndexChanged += new System.EventHandler(this.lstFuncionários_SelectedIndexChanged);
            // 
            // AtribuirAtendimento
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(621, 468);
            this.Controls.Add(this.lstFuncionários);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lblFuncionário);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCLiente);
            this.Name = "AtribuirAtendimento";
            this.Text = "Atender Cliente";
            this.Controls.SetChildIndex(this.lblCLiente, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.lblFuncionário, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.lstFuncionários, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void lstFuncionários_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = lstFuncionários.FuncionárioSelecionado != null;
		}

		public Entidades.Pessoa.Funcionário Funcionário
		{
			get
			{
				return lstFuncionários.FuncionárioSelecionado;
			}
		}
	}
}

