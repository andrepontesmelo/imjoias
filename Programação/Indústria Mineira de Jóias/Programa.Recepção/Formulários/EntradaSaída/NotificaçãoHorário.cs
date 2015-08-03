using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Programa.Recepção.Formulários.EntradaSaída
{
	sealed class NotificaçãoHorário : Apresentação.Formulários.Notificação
	{
		// Atributo
		private Entidades.Pessoa.Funcionário funcionário;

		// Evento
		public delegate void DAtribuirAusência(Entidades.Pessoa.Funcionário funcionário);
		public event DAtribuirAusência AtribuirAusência;

		// Designer
		private System.Windows.Forms.Label lblFuncionário;
		private System.Windows.Forms.Label lblHorário;
		private System.Windows.Forms.PictureBox picFoto;
		private System.Windows.Forms.Button btnAtribuirAusência;
		private System.ComponentModel.IContainer components = null;

		public NotificaçãoHorário(Entidades.Pessoa.Funcionário funcionário)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			lblFuncionário.Text = funcionário.Nome;
			lblHorário.Text = "Horário de trabalho: " + funcionário.TabelaHorário.ObterHorárioAtual();

            //if (funcionário.Foto != null)
            //    picFoto.Image = funcionário.Foto;

			this.funcionário = funcionário;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NotificaçãoHorário));
			this.picFoto = new System.Windows.Forms.PictureBox();
			this.lblFuncionário = new System.Windows.Forms.Label();
			this.lblHorário = new System.Windows.Forms.Label();
			this.btnAtribuirAusência = new System.Windows.Forms.Button();
			this.quadro.SuspendLayout();
			this.SuspendLayout();
			// 
			// quadro
			// 
			this.quadro.Controls.Add(this.btnAtribuirAusência);
			this.quadro.Controls.Add(this.lblFuncionário);
			this.quadro.Controls.Add(this.picFoto);
			this.quadro.Controls.Add(this.lblHorário);
			this.quadro.Name = "quadro";
			this.quadro.Título = "Horário de trabalho";
			this.quadro.Controls.SetChildIndex(this.lblHorário, 0);
			this.quadro.Controls.SetChildIndex(this.picFoto, 0);
			this.quadro.Controls.SetChildIndex(this.lblFuncionário, 0);
			this.quadro.Controls.SetChildIndex(this.btnAtribuirAusência, 0);
			// 
			// picFoto
			// 
			this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
			this.picFoto.Location = new System.Drawing.Point(8, 32);
			this.picFoto.Name = "picFoto";
			this.picFoto.Size = new System.Drawing.Size(60, 80);
			this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picFoto.TabIndex = 2;
			this.picFoto.TabStop = false;
			// 
			// lblFuncionário
			// 
			this.lblFuncionário.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFuncionário.Location = new System.Drawing.Point(80, 32);
			this.lblFuncionário.Name = "lblFuncionário";
			this.lblFuncionário.Size = new System.Drawing.Size(200, 16);
			this.lblFuncionário.TabIndex = 3;
			this.lblFuncionário.Text = "Nome do funcionário";
			// 
			// lblHorário
			// 
			this.lblHorário.BackColor = System.Drawing.Color.Transparent;
			this.lblHorário.Location = new System.Drawing.Point(80, 48);
			this.lblHorário.Name = "lblHorário";
			this.lblHorário.Size = new System.Drawing.Size(200, 32);
			this.lblHorário.TabIndex = 4;
			this.lblHorário.Text = "Horário de trabalho expirou.";
			// 
			// btnAtribuirAusência
			// 
			this.btnAtribuirAusência.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAtribuirAusência.Location = new System.Drawing.Point(144, 88);
			this.btnAtribuirAusência.Name = "btnAtribuirAusência";
			this.btnAtribuirAusência.Size = new System.Drawing.Size(104, 23);
			this.btnAtribuirAusência.TabIndex = 5;
			this.btnAtribuirAusência.Text = "Atribuir ausência";
			this.btnAtribuirAusência.Click += new System.EventHandler(this.btnAtribuirAusência_Click);
			// 
			// NotificaçãoHorário
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 120);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "NotificaçãoHorário";
			this.Título = "Horário de trabalho";
			this.quadro.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre quando o usuário clica em atribuir ausência.
		/// </summary>
		private void btnAtribuirAusência_Click(object sender, System.EventArgs e)
		{
			AtribuirAusência(funcionário);
			this.Close();
		}
	}
}

