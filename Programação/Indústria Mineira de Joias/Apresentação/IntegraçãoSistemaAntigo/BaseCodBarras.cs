using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo
{
	public class BaseCodBarras : Apresentação.Formulários.BaseInferior
	{
		private System.Windows.Forms.Button btnInicio;
		private Apresentação.Formulários.Quadro quadroArquivo;
		private System.Windows.Forms.TextBox txtArquivoMapeia;
		private System.Windows.Forms.Button btnProcurar;
		private System.ComponentModel.IContainer components = null;

		public BaseCodBarras()
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
			this.btnInicio = new System.Windows.Forms.Button();
			this.quadroArquivo = new Apresentação.Formulários.Quadro();
			this.btnProcurar = new System.Windows.Forms.Button();
			this.txtArquivoMapeia = new System.Windows.Forms.TextBox();
			this.quadroArquivo.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			// 
			// btnInicio
			// 
			this.btnInicio.Location = new System.Drawing.Point(272, 224);
			this.btnInicio.Name = "btnInicio";
			this.btnInicio.Size = new System.Drawing.Size(80, 24);
			this.btnInicio.TabIndex = 6;
			this.btnInicio.Text = "Iniciar";
			this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
			// 
			// quadroArquivo
			// 
			this.quadroArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroArquivo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.quadroArquivo.bInfDirArredondada = true;
			this.quadroArquivo.bInfEsqArredondada = true;
			this.quadroArquivo.bSupDirArredondada = true;
			this.quadroArquivo.bSupEsqArredondada = true;
			this.quadroArquivo.Controls.Add(this.btnProcurar);
			this.quadroArquivo.Controls.Add(this.txtArquivoMapeia);
			this.quadroArquivo.Cor = System.Drawing.Color.Black;
			this.quadroArquivo.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroArquivo.LetraTítulo = System.Drawing.Color.White;
			this.quadroArquivo.Location = new System.Drawing.Point(192, 32);
			this.quadroArquivo.Name = "quadroArquivo";
			this.quadroArquivo.Size = new System.Drawing.Size(352, 88);
			this.quadroArquivo.TabIndex = 7;
			this.quadroArquivo.Tamanho = 30;
			this.quadroArquivo.Título = "Escolha o local para gravar o dbf";
			// 
			// btnProcurar
			// 
			this.btnProcurar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.btnProcurar.Location = new System.Drawing.Point(8, 64);
			this.btnProcurar.Name = "btnProcurar";
			this.btnProcurar.Size = new System.Drawing.Size(32, 16);
			this.btnProcurar.TabIndex = 2;
			this.btnProcurar.Text = "...";
			this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
			// 
			// txtArquivoMapeia
			// 
			this.txtArquivoMapeia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtArquivoMapeia.Location = new System.Drawing.Point(8, 40);
			this.txtArquivoMapeia.Name = "txtArquivoMapeia";
			this.txtArquivoMapeia.Size = new System.Drawing.Size(336, 20);
			this.txtArquivoMapeia.TabIndex = 1;
			this.txtArquivoMapeia.Text = "c:\\mapeia.dbf";
			// 
			// BaseCodBarras
			// 
			this.Controls.Add(this.quadroArquivo);
			this.Controls.Add(this.btnInicio);
			this.Name = "BaseCodBarras";
			this.Size = new System.Drawing.Size(560, 296);
			this.Controls.SetChildIndex(this.btnInicio, 0);
			this.Controls.SetChildIndex(this.quadroArquivo, 0);
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.quadroArquivo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnProcurar_Click(object sender, System.EventArgs e)
		{
			using (System.Windows.Forms.SaveFileDialog dlgGrava = new SaveFileDialog())
			{
				dlgGrava.FileName = @"c:\mapeia.dbf";
				dlgGrava.OverwritePrompt = false;
				dlgGrava.DefaultExt = "dbf";
				if (dlgGrava.ShowDialog() == DialogResult.OK)
				{
					txtArquivoMapeia.Text = dlgGrava.FileName;

				}
				dlgGrava.Dispose();
			}
		}

		private void btnInicio_Click(object sender, System.EventArgs e)
		{
            //fachadaFácil = (Negócio.Fachada.IIntegraçãoSistemaAntigo) Fachada;
            //fachadaFácil = ;
            UseWaitCursor = true;
            btnInicio.Enabled = false;

			//new Controles.CodBarras((Negócio.Fachada.IIntegraçãoSistemaAntigo) Fachada, txtArquivoMapeia.Text).Transpor();
            new Controles.CodBarras(txtArquivoMapeia.Text).Transpor();
            UseWaitCursor = false;

            btnInicio.Enabled = true;
			System.Windows.Forms.MessageBox.Show(this, "Operação bem sucedida", "fim", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}

