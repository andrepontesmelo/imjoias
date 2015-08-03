using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AtribuirAtendimento));
			this.lblFuncionário = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.lblCLiente = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.lstFuncionários = new Apresentação.Pessoa.Consultas.ListViewFuncionários();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(121, 22);
			this.lblTítulo.Text = "Atender cliente";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Text = "Escolha o funcionário que atenderá o cliente, logo que disponível.";
			// 
			// picÍcone
			// 
			this.picÍcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Location = new System.Drawing.Point(16, 16);
			this.picÍcone.Name = "picÍcone";
			this.picÍcone.Size = new System.Drawing.Size(38, 57);
			this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			// 
			// lblFuncionário
			// 
			this.lblFuncionário.AutoSize = true;
			this.lblFuncionário.Location = new System.Drawing.Point(32, 146);
			this.lblFuncionário.Name = "lblFuncionário";
			this.lblFuncionário.Size = new System.Drawing.Size(67, 16);
			this.lblFuncionário.TabIndex = 7;
			this.lblFuncionário.Text = "Funcionário:";
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(104, 112);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.ReadOnly = true;
			this.txtCliente.Size = new System.Drawing.Size(264, 20);
			this.txtCliente.TabIndex = 6;
			this.txtCliente.Text = "";
			// 
			// lblCLiente
			// 
			this.lblCLiente.AutoSize = true;
			this.lblCLiente.Location = new System.Drawing.Point(32, 114);
			this.lblCLiente.Name = "lblCLiente";
			this.lblCLiente.Size = new System.Drawing.Size(43, 16);
			this.lblCLiente.TabIndex = 5;
			this.lblCLiente.Text = "Cliente:";
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Enabled = false;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(296, 264);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 9;
			this.cmdOK.Text = "OK";
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancelar.Location = new System.Drawing.Point(208, 264);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.TabIndex = 10;
			this.cmdCancelar.Text = "Cancelar";
			// 
			// lstFuncionários
			// 
			this.lstFuncionários.ÊnfaseSetor = null;
			this.lstFuncionários.Funcionários = null;
			this.lstFuncionários.Location = new System.Drawing.Point(32, 160);
			this.lstFuncionários.Name = "lstFuncionários";
			this.lstFuncionários.Size = new System.Drawing.Size(336, 96);
			this.lstFuncionários.TabIndex = 11;
			this.lstFuncionários.SelectedIndexChanged += new System.EventHandler(this.lstFuncionários_SelectedIndexChanged);
			// 
			// AtribuirAtendimento
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 296);
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
			this.ResumeLayout(false);

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

