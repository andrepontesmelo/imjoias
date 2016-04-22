using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Apresentação.Atendimento.Clientes;
using Apresentação.Atendimento.Comum;

using Negócio;
using Negócio.Observador;

namespace Apresentação.Usuário.InterForm.Atendimento
{
	public sealed class BaseClientes : Apresentação.Usuário.InterForm.BaseUsuário
	{
		/// <summary>
		/// Delegação para adicionar visitante.
		/// </summary>
		private delegate void DVisitante(IVisitante visitante);

		/// <summary>
		/// Método para adicionar visitante na fila.
		/// </summary>
		private DVisitante adicionarVisitanteFila;

		// Componentes
		private System.Windows.Forms.ToolTip dica;
		private Apresentação.Formulários.Quadro quadroFila;
		private Apresentação.Atendimento.Comum.ListaPessoas listaFila;
		private Apresentação.Formulários.Quadro quadroSetor;
		private Apresentação.Atendimento.Clientes.ListaVisitantes listaSetor;
		private System.ComponentModel.IContainer components = null;

		public BaseClientes(Entidades.Pessoa.Funcionário funcionário) : base(funcionário)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			adicionarVisitanteFila = new DVisitante(listaFila.Itens.Add);

            //// Adiciona fila de espera.
            //foreach (IVisitante visitante in funcionário.FilaEspera)
            //    AdicionarFila(visitante);

			listaSetor.Setor = Entidades.Setor.ObterSetor(funcionário.Setor);
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
			this.quadroFila = new Apresentação.Formulários.Quadro();
			this.listaFila = new Apresentação.Atendimento.Comum.ListaPessoas();
			this.dica = new System.Windows.Forms.ToolTip(this.components);
			this.quadroSetor = new Apresentação.Formulários.Quadro();
			this.listaSetor = new Apresentação.Atendimento.Clientes.ListaVisitantes();
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
			this.quadroFila.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroFila.LetraTítulo = System.Drawing.Color.White;
			this.quadroFila.Location = new System.Drawing.Point(200, 96);
			this.quadroFila.MostrarBotãoMinMax = false;
			this.quadroFila.Name = "quadroFila";
			this.quadroFila.Size = new System.Drawing.Size(280, 272);
			this.quadroFila.TabIndex = 8;
			this.quadroFila.Tamanho = 30;
			this.quadroFila.Título = "Fila para atendimento exclusivo";
			this.dica.SetToolTip(this.quadroFila, "A fila para atendimento exclusivo mostra clientes que aguardam por atendimento ex" +
				"clusivo de você. Tais clientes se identificaram na recepção informando que aguar" +
				"dam pelo seu atendimento.");
			// 
			// listaFila
			// 
			this.listaFila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listaFila.AutoColunas = false;
			this.listaFila.AutoOrdenação = false;
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
			this.quadroSetor.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadroSetor.LetraTítulo = System.Drawing.Color.White;
			this.quadroSetor.Location = new System.Drawing.Point(496, 96);
			this.quadroSetor.MostrarBotãoMinMax = false;
			this.quadroSetor.Name = "quadroSetor";
			this.quadroSetor.Size = new System.Drawing.Size(280, 272);
			this.quadroSetor.TabIndex = 9;
			this.quadroSetor.Tamanho = 30;
			this.quadroSetor.Título = "Fila para atendimento no setor";
			// 
			// listaSetor
			// 
			this.listaSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listaSetor.AutoOrdenação = false;
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
        ///// Ocorre ao observar uma ação do funcionário atual.
        ///// </summary>
        ///// <param name="ação">Ação do funcionário.</param>
        ///// <param name="dados">Dados da ação.</param>
        //protected override void AoObservarFuncionário(Negócio.Observador.AçãoFuncionário ação, object dados)
        //{
        //    base.AoObservarFuncionário(ação, dados);

        //    switch (ação)
        //    {
        //        case AçãoFuncionário.EnfileirouCliente:
        //            AdicionarFila((IVisitante) dados);
        //            break;

        //        case AçãoFuncionário.DesenfileirouCliente:
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