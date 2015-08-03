using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Programa.Recep��o.Formul�rios.EntradaSa�da
{
	sealed class AtribuirAtendimento : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.Windows.Forms.Label lblFuncion�rio;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.Label lblCLiente;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.ComponentModel.IContainer components = null;
		private Apresenta��o.Pessoa.Consultas.ListViewFuncion�rios lstFuncion�rios;

		public AtribuirAtendimento(string cliente, IEnumerable<Entidades.Pessoa.Funcion�rio> funcion�rios)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Mostrar dados
			txtCliente.Text = cliente;

			lstFuncion�rios.Funcion�rios = funcion�rios;
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
			this.lblFuncion�rio = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.lblCLiente = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.lstFuncion�rios = new Apresenta��o.Pessoa.Consultas.ListViewFuncion�rios();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(121, 22);
			this.lblT�tulo.Text = "Atender cliente";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Text = "Escolha o funcion�rio que atender� o cliente, logo que dispon�vel.";
			// 
			// pic�cone
			// 
			this.pic�cone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Location = new System.Drawing.Point(16, 16);
			this.pic�cone.Name = "pic�cone";
			this.pic�cone.Size = new System.Drawing.Size(38, 57);
			this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			// 
			// lblFuncion�rio
			// 
			this.lblFuncion�rio.AutoSize = true;
			this.lblFuncion�rio.Location = new System.Drawing.Point(32, 146);
			this.lblFuncion�rio.Name = "lblFuncion�rio";
			this.lblFuncion�rio.Size = new System.Drawing.Size(67, 16);
			this.lblFuncion�rio.TabIndex = 7;
			this.lblFuncion�rio.Text = "Funcion�rio:";
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
			// lstFuncion�rios
			// 
			this.lstFuncion�rios.�nfaseSetor = null;
			this.lstFuncion�rios.Funcion�rios = null;
			this.lstFuncion�rios.Location = new System.Drawing.Point(32, 160);
			this.lstFuncion�rios.Name = "lstFuncion�rios";
			this.lstFuncion�rios.Size = new System.Drawing.Size(336, 96);
			this.lstFuncion�rios.TabIndex = 11;
			this.lstFuncion�rios.SelectedIndexChanged += new System.EventHandler(this.lstFuncion�rios_SelectedIndexChanged);
			// 
			// AtribuirAtendimento
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 296);
			this.Controls.Add(this.lstFuncion�rios);
			this.Controls.Add(this.cmdCancelar);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.lblFuncion�rio);
			this.Controls.Add(this.txtCliente);
			this.Controls.Add(this.lblCLiente);
			this.Name = "AtribuirAtendimento";
			this.Text = "Atender Cliente";
			this.Controls.SetChildIndex(this.lblCLiente, 0);
			this.Controls.SetChildIndex(this.txtCliente, 0);
			this.Controls.SetChildIndex(this.lblFuncion�rio, 0);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.Controls.SetChildIndex(this.cmdCancelar, 0);
			this.Controls.SetChildIndex(this.lstFuncion�rios, 0);
			this.ResumeLayout(false);

		}
		#endregion

		private void lstFuncion�rios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = lstFuncion�rios.Funcion�rioSelecionado != null;
		}

		public Entidades.Pessoa.Funcion�rio Funcion�rio
		{
			get
			{
				return lstFuncion�rios.Funcion�rioSelecionado;
			}
		}
	}
}

