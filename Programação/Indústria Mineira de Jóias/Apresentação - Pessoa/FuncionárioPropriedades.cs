using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa
{
	public class Funcion�rioPropriedades : Apresenta��o.Formul�rios.JanelaExplicativa
	{
        private Funcion�rio funcion�rio;

		private System.Windows.Forms.Label lblFuncion�rio;
		private System.Windows.Forms.TextBox txtFuncion�rio;
		private System.Windows.Forms.GroupBox grpEstado;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.RadioButton optDispon�vel;
		private System.Windows.Forms.RadioButton optAusente;
		private System.Windows.Forms.RadioButton optOcupado;
		private System.Windows.Forms.RadioButton optAtendendo;
		private System.ComponentModel.IContainer components = null;

		public Funcion�rioPropriedades(Funcion�rio funcion�rio)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            this.funcion�rio = funcion�rio;
			txtFuncion�rio.Text = funcion�rio.Nome;
			Estado = funcion�rio.Situa��o;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Funcion�rioPropriedades));
            this.lblFuncion�rio = new System.Windows.Forms.Label();
            this.txtFuncion�rio = new System.Windows.Forms.TextBox();
            this.grpEstado = new System.Windows.Forms.GroupBox();
            this.optAtendendo = new System.Windows.Forms.RadioButton();
            this.optOcupado = new System.Windows.Forms.RadioButton();
            this.optAusente = new System.Windows.Forms.RadioButton();
            this.optDispon�vel = new System.Windows.Forms.RadioButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.grpEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(199, 20);
            this.lblT�tulo.Text = "Situa��o do funcion�rio";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(218, 32);
            this.lblDescri��o.Text = "Atribua aqui a situa��o atual do funcion�rio";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // lblFuncion�rio
            // 
            this.lblFuncion�rio.AutoSize = true;
            this.lblFuncion�rio.Location = new System.Drawing.Point(24, 106);
            this.lblFuncion�rio.Name = "lblFuncion�rio";
            this.lblFuncion�rio.Size = new System.Drawing.Size(63, 13);
            this.lblFuncion�rio.TabIndex = 3;
            this.lblFuncion�rio.Text = "Funcion�ro:";
            // 
            // txtFuncion�rio
            // 
            this.txtFuncion�rio.Location = new System.Drawing.Point(24, 120);
            this.txtFuncion�rio.Name = "txtFuncion�rio";
            this.txtFuncion�rio.ReadOnly = true;
            this.txtFuncion�rio.Size = new System.Drawing.Size(256, 20);
            this.txtFuncion�rio.TabIndex = 4;
            // 
            // grpEstado
            // 
            this.grpEstado.Controls.Add(this.optAtendendo);
            this.grpEstado.Controls.Add(this.optOcupado);
            this.grpEstado.Controls.Add(this.optAusente);
            this.grpEstado.Controls.Add(this.optDispon�vel);
            this.grpEstado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEstado.Location = new System.Drawing.Point(24, 152);
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Size = new System.Drawing.Size(256, 80);
            this.grpEstado.TabIndex = 0;
            this.grpEstado.TabStop = false;
            this.grpEstado.Text = "Estado";
            // 
            // optAtendendo
            // 
            this.optAtendendo.Enabled = false;
            this.optAtendendo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAtendendo.Location = new System.Drawing.Point(120, 48);
            this.optAtendendo.Name = "optAtendendo";
            this.optAtendendo.Size = new System.Drawing.Size(104, 24);
            this.optAtendendo.TabIndex = 3;
            this.optAtendendo.Text = "Atendendo";
            // 
            // optOcupado
            // 
            this.optOcupado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optOcupado.Location = new System.Drawing.Point(120, 24);
            this.optOcupado.Name = "optOcupado";
            this.optOcupado.Size = new System.Drawing.Size(104, 24);
            this.optOcupado.TabIndex = 2;
            this.optOcupado.Text = "Ocupado";
            // 
            // optAusente
            // 
            this.optAusente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAusente.Location = new System.Drawing.Point(16, 48);
            this.optAusente.Name = "optAusente";
            this.optAusente.Size = new System.Drawing.Size(104, 24);
            this.optAusente.TabIndex = 1;
            this.optAusente.Text = "Ausente";
            // 
            // optDispon�vel
            // 
            this.optDispon�vel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optDispon�vel.Location = new System.Drawing.Point(16, 24);
            this.optDispon�vel.Name = "optDispon�vel";
            this.optDispon�vel.Size = new System.Drawing.Size(104, 24);
            this.optDispon�vel.TabIndex = 0;
            this.optDispon�vel.Text = "Dispon�vel";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(216, 248);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(128, 248);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 7;
            this.cmdCancelar.Text = "Cancelar";
            // 
            // Funcion�rioPropriedades
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(306, 280);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpEstado);
            this.Controls.Add(this.txtFuncion�rio);
            this.Controls.Add(this.lblFuncion�rio);
            this.Name = "Funcion�rioPropriedades";
            this.Text = "Situa��o do funcion�rio";
            this.Controls.SetChildIndex(this.lblFuncion�rio, 0);
            this.Controls.SetChildIndex(this.txtFuncion�rio, 0);
            this.Controls.SetChildIndex(this.grpEstado, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.grpEstado.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public EstadoFuncion�rio Estado
		{
			get
			{
				if (optDispon�vel.Checked)
					return EstadoFuncion�rio.Dispon�vel;

				if (optAusente.Checked)
					return EstadoFuncion�rio.Ausente;

				if (optOcupado.Checked)
					return EstadoFuncion�rio.Ocupado;

				if (optAtendendo.Checked)
					return EstadoFuncion�rio.Atendendo;

				return EstadoFuncion�rio.Ocupado;
			}
			set
			{
				switch (value)
				{
					case EstadoFuncion�rio.Dispon�vel:
						optDispon�vel.Checked = true;
						break;

					case EstadoFuncion�rio.Ausente:
						optAusente.Checked = true;
						break;

					case EstadoFuncion�rio.Atendendo:
						optAtendendo.Checked = true;
						break;

					case EstadoFuncion�rio.Ocupado:
						optOcupado.Checked = true;
						break;
				}

				grpEstado.Enabled = !optAtendendo.Checked;
			}
		}

        private void cmdOK_Click(object sender, EventArgs e)
        {
            funcion�rio.Situa��o = Estado;
            DialogResult = DialogResult.OK;
            Close();
        }
	}
}

