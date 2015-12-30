using System.Collections.Generic;
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
            this.lblFuncion�rio = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.lstFuncion�rios = new Apresenta��o.Pessoa.Consultas.ListViewFuncion�rios();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(131, 20);
            this.lblT�tulo.Text = "Atender cliente";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(533, 48);
            this.lblDescri��o.Text = "Escolha o funcion�rio que atender� o cliente, logo que dispon�vel.";
            // 
            // pic�cone
            // 
            this.pic�cone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            this.pic�cone.Location = new System.Drawing.Point(16, 16);
            this.pic�cone.Size = new System.Drawing.Size(40, 59);
            this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // lblFuncion�rio
            // 
            this.lblFuncion�rio.AutoSize = true;
            this.lblFuncion�rio.Location = new System.Drawing.Point(32, 146);
            this.lblFuncion�rio.Name = "lblFuncion�rio";
            this.lblFuncion�rio.Size = new System.Drawing.Size(65, 13);
            this.lblFuncion�rio.TabIndex = 7;
            this.lblFuncion�rio.Text = "Funcion�rio:";
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
            // lstFuncion�rios
            // 
            this.lstFuncion�rios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFuncion�rios.�nfaseSetor = null;
            this.lstFuncion�rios.Funcion�rios = null;
            this.lstFuncion�rios.Location = new System.Drawing.Point(32, 160);
            this.lstFuncion�rios.Name = "lstFuncion�rios";
            this.lstFuncion�rios.Size = new System.Drawing.Size(565, 270);
            this.lstFuncion�rios.TabIndex = 11;
            this.lstFuncion�rios.SelectedIndexChanged += new System.EventHandler(this.lstFuncion�rios_SelectedIndexChanged);
            // 
            // AtribuirAtendimento
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(621, 468);
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
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

