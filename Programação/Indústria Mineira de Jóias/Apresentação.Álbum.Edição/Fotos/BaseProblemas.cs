using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.�lbum.Edi��o.Fotos
{
	public class BaseProblemas : Apresenta��o.Formul�rios.BaseInferior
	{
		private Apresenta��o.Formul�rios.Quadro quadro1;
        private ListaProblemas lista;
        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior1;
        private Apresenta��o.Formul�rios.Quadro quadroExcluir;
        private Apresenta��o.Formul�rios.Op��o optExcluir;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseProblemas));
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.t�tuloBaseInferior1 = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadroExcluir = new Apresenta��o.Formul�rios.Quadro();
            this.optExcluir = new Apresenta��o.Formul�rios.Op��o();
            this.lista = new Apresenta��o.�lbum.Edi��o.Fotos.ListaProblemas();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroExcluir.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroExcluir);
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
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(193, 79);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(431, 270);
            this.quadro1.TabIndex = 6;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "Problemas";
            // 
            // t�tuloBaseInferior1
            // 
            this.t�tuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior1.Descri��o = "Aqui est�o os problemas relatados pelos funcion�rios acerca das fotos.";
            this.t�tuloBaseInferior1.Imagem = null;
            this.t�tuloBaseInferior1.Location = new System.Drawing.Point(205, 3);
            this.t�tuloBaseInferior1.Name = "t�tuloBaseInferior1";
            this.t�tuloBaseInferior1.Size = new System.Drawing.Size(443, 70);
            this.t�tuloBaseInferior1.TabIndex = 7;
            this.t�tuloBaseInferior1.T�tulo = "Relat�rio de problemas";
            // 
            // quadroExcluir
            // 
            this.quadroExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroExcluir.bInfDirArredondada = true;
            this.quadroExcluir.bInfEsqArredondada = true;
            this.quadroExcluir.bSupDirArredondada = true;
            this.quadroExcluir.bSupEsqArredondada = true;
            this.quadroExcluir.Controls.Add(this.optExcluir);
            this.quadroExcluir.Cor = System.Drawing.Color.Black;
            this.quadroExcluir.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroExcluir.LetraT�tulo = System.Drawing.Color.White;
            this.quadroExcluir.Location = new System.Drawing.Point(7, 25);
            this.quadroExcluir.MostrarBot�oMinMax = false;
            this.quadroExcluir.Name = "quadroExcluir";
            this.quadroExcluir.Size = new System.Drawing.Size(160, 76);
            this.quadroExcluir.TabIndex = 0;
            this.quadroExcluir.Tamanho = 30;
            this.quadroExcluir.T�tulo = "Problema selecionado";
            this.quadroExcluir.Visible = false;
            // 
            // optExcluir
            // 
            this.optExcluir.BackColor = System.Drawing.Color.Transparent;
            this.optExcluir.Descri��o = "Excluir";
            this.optExcluir.Imagem = ((System.Drawing.Image)(resources.GetObject("optExcluir.Imagem")));
            this.optExcluir.Location = new System.Drawing.Point(10, 54);
            this.optExcluir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.optExcluir.Name = "optExcluir";
            this.optExcluir.Size = new System.Drawing.Size(150, 24);
            this.optExcluir.TabIndex = 2;
            this.optExcluir.Click += new System.EventHandler(this.optExcluir_Click);
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 24);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(430, 245);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            // 
            // BaseProblemas
            // 
            this.Controls.Add(this.t�tuloBaseInferior1);
            this.Controls.Add(this.quadro1);
            this.Name = "BaseProblemas";
            this.Size = new System.Drawing.Size(648, 368);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadro1, 0);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior1, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroExcluir.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void BaseErros_HandleCreated(object sender, EventArgs e)
		{
			lista.Carregar();
		}

        private void optExcluir_Click(object sender, EventArgs e)
        {
            Entidades.�lbum.ProblemaFoto problema = lista.ItemSelecionado;
            
            if (problema == null)
                throw new NullReferenceException("item nulo");

            lista.Remover(problema);
            problema.ResolverProblema();
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            quadroExcluir.Visible = lista.SelectedItems.Count > 0;
        }
	}
}

