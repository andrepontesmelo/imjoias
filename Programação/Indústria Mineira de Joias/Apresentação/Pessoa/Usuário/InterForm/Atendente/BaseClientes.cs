using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Apresenta��o.Atendimento.Clientes;
using Apresenta��o.Atendimento.Comum;

using Neg�cio;
using Neg�cio.Observador;

namespace Apresenta��o.Usu�rio.InterForm.Atendimento
{
	public sealed class BaseClientes : Apresenta��o.Usu�rio.InterForm.BaseUsu�rio
	{
		/// <summary>
		/// Delega��o para adicionar visitante.
		/// </summary>
		private delegate void DVisitante(IVisitante visitante);

		/// <summary>
		/// M�todo para adicionar visitante na fila.
		/// </summary>
		private DVisitante adicionarVisitanteFila;

		// Componentes
		private System.Windows.Forms.ToolTip dica;
		private Apresenta��o.Formul�rios.Quadro quadroFila;
		private Apresenta��o.Atendimento.Comum.ListaPessoas listaFila;
		private Apresenta��o.Formul�rios.Quadro quadroSetor;
		private Apresenta��o.Atendimento.Clientes.ListaVisitantes listaSetor;
		private System.ComponentModel.IContainer components = null;

		public BaseClientes(Entidades.Pessoa.Funcion�rio funcion�rio) : base(funcion�rio)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			adicionarVisitanteFila = new DVisitante(listaFila.Itens.Add);

            //// Adiciona fila de espera.
            //foreach (IVisitante visitante in funcion�rio.FilaEspera)
            //    AdicionarFila(visitante);

			listaSetor.Setor = Entidades.Setor.ObterSetor(funcion�rio.Setor);
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
			this.components = new System.ComponentModel.Container();
			this.quadroFila = new Apresenta��o.Formul�rios.Quadro();
			this.listaFila = new Apresenta��o.Atendimento.Comum.ListaPessoas();
			this.dica = new System.Windows.Forms.ToolTip(this.components);
			this.quadroSetor = new Apresenta��o.Formul�rios.Quadro();
			this.listaSetor = new Apresenta��o.Atendimento.Clientes.ListaVisitantes();
			this.quadroFila.SuspendLayout();
			this.quadroSetor.SuspendLayout();
			this.SuspendLayout();
			// 
			// esquerda
			// 
			
			// 
			// quadroFila
			// 
			this.quadroFila.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.quadroFila.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(231)), ((System.Byte)(202)));
			this.quadroFila.bInfDirArredondada = true;
			this.quadroFila.bInfEsqArredondada = true;
			this.quadroFila.bSupDirArredondada = true;
			this.quadroFila.bSupEsqArredondada = true;
			this.quadroFila.Controls.Add(this.listaFila);
			this.quadroFila.Cor = System.Drawing.Color.Black;
			this.quadroFila.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroFila.LetraT�tulo = System.Drawing.Color.White;
			this.quadroFila.Location = new System.Drawing.Point(200, 96);
			this.quadroFila.MostrarBot�oMinMax = false;
			this.quadroFila.Name = "quadroFila";
			this.quadroFila.Size = new System.Drawing.Size(280, 272);
			this.quadroFila.TabIndex = 8;
			this.quadroFila.Tamanho = 30;
			this.quadroFila.T�tulo = "Fila para atendimento exclusivo";
			this.dica.SetToolTip(this.quadroFila, "A fila para atendimento exclusivo mostra clientes que aguardam por atendimento ex" +
				"clusivo de voc�. Tais clientes se identificaram na recep��o informando que aguar" +
				"dam pelo seu atendimento.");
			// 
			// listaFila
			// 
			this.listaFila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listaFila.AutoColunas = false;
			this.listaFila.AutoOrdena��o = false;
			this.listaFila.AutoScroll = true;
			this.listaFila.Colunas = 1;
			this.listaFila.Location = new System.Drawing.Point(8, 32);
			this.listaFila.Name = "listaFila";
			this.listaFila.Size = new System.Drawing.Size(264, 232);
			this.listaFila.TabIndex = 2;
			// 
			// quadroSetor
			// 
			this.quadroSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.quadroSetor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(231)), ((System.Byte)(202)));
			this.quadroSetor.bInfDirArredondada = true;
			this.quadroSetor.bInfEsqArredondada = true;
			this.quadroSetor.bSupDirArredondada = true;
			this.quadroSetor.bSupEsqArredondada = true;
			this.quadroSetor.Controls.Add(this.listaSetor);
			this.quadroSetor.Cor = System.Drawing.Color.Black;
			this.quadroSetor.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroSetor.LetraT�tulo = System.Drawing.Color.White;
			this.quadroSetor.Location = new System.Drawing.Point(496, 96);
			this.quadroSetor.MostrarBot�oMinMax = false;
			this.quadroSetor.Name = "quadroSetor";
			this.quadroSetor.Size = new System.Drawing.Size(280, 272);
			this.quadroSetor.TabIndex = 9;
			this.quadroSetor.Tamanho = 30;
			this.quadroSetor.T�tulo = "Fila para atendimento no setor";
			// 
			// listaSetor
			// 
			this.listaSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listaSetor.AutoOrdena��o = false;
			this.listaSetor.AutoScroll = true;
			this.listaSetor.Location = new System.Drawing.Point(8, 32);
			this.listaSetor.Name = "listaSetor";
			this.listaSetor.Size = new System.Drawing.Size(264, 232);
			this.listaSetor.TabIndex = 2;
			// 
			// BaseClientes
			// 
			this.Controls.Add(this.quadroSetor);
			this.Controls.Add(this.quadroFila);
			this.Name = "BaseClientes";
			this.Controls.SetChildIndex(this.esquerda, 0);
			this.Controls.SetChildIndex(this.quadroFila, 0);
			this.Controls.SetChildIndex(this.quadroSetor, 0);
			this.quadroFila.ResumeLayout(false);
			this.quadroSetor.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

        ///// <summary>
        ///// Ocorre ao observar uma a��o do funcion�rio atual.
        ///// </summary>
        ///// <param name="a��o">A��o do funcion�rio.</param>
        ///// <param name="dados">Dados da a��o.</param>
        //protected override void AoObservarFuncion�rio(Neg�cio.Observador.A��oFuncion�rio a��o, object dados)
        //{
        //    base.AoObservarFuncion�rio(a��o, dados);

        //    switch (a��o)
        //    {
        //        case A��oFuncion�rio.EnfileirouCliente:
        //            AdicionarFila((IVisitante) dados);
        //            break;

        //        case A��oFuncion�rio.DesenfileirouCliente:
        //            RemoverFila((IVisitante) dados);
        //            break;
        //    }
        //}

		/// <summary>
		/// Adiciona visitante na lista de atendimento exclusivo.
		/// </summary>
		/// <param name="visitante">Visitante na espera.</param>
		private void AdicionarFila(IVisitante visitante)
		{
			listaFila.Invoke(adicionarVisitanteFila, new object [] { visitante });
		}

		/// <summary>
		/// Remove visitante da fila de atendimento exclusivo.
		/// </summary>
		/// <param name="visitante">Visitante a ser removido.</param>
		private void RemoverFila(IVisitante visitante)
		{
			foreach (ListaVisitantesItem item in listaFila.Itens)
				if (item.Visitante == visitante)
				{
					listaFila.Itens.Remove(item);
					return;
				}
		}
	}
}