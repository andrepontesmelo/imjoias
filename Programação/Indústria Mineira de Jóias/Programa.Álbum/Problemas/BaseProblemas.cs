using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Programa.Álbum.Problemas
{
	internal class BaseProblemas : Apresentação.Formulários.BaseInferior
	{
		private Apresentação.Formulários.Quadro quadro1;
        private ListaProblemas lista;
		private System.ComponentModel.IContainer components = null;

		public BaseProblemas()
		{
			InitializeComponent();

			this.HandleCreated += new EventHandler(BaseErros_HandleCreated);
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
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.lista = new Programa.Álbum.Problemas.ListaProblemas();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 368);
            // 
            // quadro1
            // 
            this.quadro1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = false;
            this.quadro1.bInfEsqArredondada = false;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.lista);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(200, 16);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(440, 336);
            this.quadro1.TabIndex = 6;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Título";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(0, 24);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(439, 311);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            // 
            // BaseProblemas
            // 
            this.Controls.Add(this.quadro1);
            this.Name = "BaseProblemas";
            this.Size = new System.Drawing.Size(648, 368);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void BaseErros_HandleCreated(object sender, EventArgs e)
		{
			lista.Carregar();
		}
	}
}

