using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa
{
	public class FuncionárioPropriedades : Apresentação.Formulários.JanelaExplicativa
	{
        private Funcionário funcionário;

		private System.Windows.Forms.Label lblFuncionário;
		private System.Windows.Forms.TextBox txtFuncionário;
		private System.Windows.Forms.GroupBox grpEstado;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.RadioButton optDisponível;
		private System.Windows.Forms.RadioButton optAusente;
		private System.Windows.Forms.RadioButton optOcupado;
		private System.Windows.Forms.RadioButton optAtendendo;
		private System.ComponentModel.IContainer components = null;

		public FuncionárioPropriedades(Funcionário funcionário)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            this.funcionário = funcionário;
			txtFuncionário.Text = funcionário.Nome;
			Estado = funcionário.Situação;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FuncionárioPropriedades));
            this.lblFuncionário = new System.Windows.Forms.Label();
            this.txtFuncionário = new System.Windows.Forms.TextBox();
            this.grpEstado = new System.Windows.Forms.GroupBox();
            this.optAtendendo = new System.Windows.Forms.RadioButton();
            this.optOcupado = new System.Windows.Forms.RadioButton();
            this.optAusente = new System.Windows.Forms.RadioButton();
            this.optDisponível = new System.Windows.Forms.RadioButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.grpEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(199, 20);
            this.lblTítulo.Text = "Situação do funcionário";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(218, 32);
            this.lblDescrição.Text = "Atribua aqui a situação atual do funcionário";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // lblFuncionário
            // 
            this.lblFuncionário.AutoSize = true;
            this.lblFuncionário.Location = new System.Drawing.Point(24, 106);
            this.lblFuncionário.Name = "lblFuncionário";
            this.lblFuncionário.Size = new System.Drawing.Size(63, 13);
            this.lblFuncionário.TabIndex = 3;
            this.lblFuncionário.Text = "Funcionáro:";
            // 
            // txtFuncionário
            // 
            this.txtFuncionário.Location = new System.Drawing.Point(24, 120);
            this.txtFuncionário.Name = "txtFuncionário";
            this.txtFuncionário.ReadOnly = true;
            this.txtFuncionário.Size = new System.Drawing.Size(256, 20);
            this.txtFuncionário.TabIndex = 4;
            // 
            // grpEstado
            // 
            this.grpEstado.Controls.Add(this.optAtendendo);
            this.grpEstado.Controls.Add(this.optOcupado);
            this.grpEstado.Controls.Add(this.optAusente);
            this.grpEstado.Controls.Add(this.optDisponível);
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
            // optDisponível
            // 
            this.optDisponível.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optDisponível.Location = new System.Drawing.Point(16, 24);
            this.optDisponível.Name = "optDisponível";
            this.optDisponível.Size = new System.Drawing.Size(104, 24);
            this.optDisponível.TabIndex = 0;
            this.optDisponível.Text = "Disponível";
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
            // FuncionárioPropriedades
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(306, 280);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpEstado);
            this.Controls.Add(this.txtFuncionário);
            this.Controls.Add(this.lblFuncionário);
            this.Name = "FuncionárioPropriedades";
            this.Text = "Situação do funcionário";
            this.Controls.SetChildIndex(this.lblFuncionário, 0);
            this.Controls.SetChildIndex(this.txtFuncionário, 0);
            this.Controls.SetChildIndex(this.grpEstado, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.grpEstado.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public EstadoFuncionário Estado
		{
			get
			{
				if (optDisponível.Checked)
					return EstadoFuncionário.Disponível;

				if (optAusente.Checked)
					return EstadoFuncionário.Ausente;

				if (optOcupado.Checked)
					return EstadoFuncionário.Ocupado;

				if (optAtendendo.Checked)
					return EstadoFuncionário.Atendendo;

				return EstadoFuncionário.Ocupado;
			}
			set
			{
				switch (value)
				{
					case EstadoFuncionário.Disponível:
						optDisponível.Checked = true;
						break;

					case EstadoFuncionário.Ausente:
						optAusente.Checked = true;
						break;

					case EstadoFuncionário.Atendendo:
						optAtendendo.Checked = true;
						break;

					case EstadoFuncionário.Ocupado:
						optOcupado.Checked = true;
						break;
				}

				grpEstado.Enabled = !optAtendendo.Checked;
			}
		}

        private void cmdOK_Click(object sender, EventArgs e)
        {
            funcionário.Situação = Estado;
            DialogResult = DialogResult.OK;
            Close();
        }
	}
}

