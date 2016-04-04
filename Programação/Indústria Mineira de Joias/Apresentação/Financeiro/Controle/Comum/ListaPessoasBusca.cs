using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Atendimento.Clientes;

namespace Apresentação.Atendimento.Comum
{
	/// <summary>
	/// Lista de clientes
	/// </summary>
	[Serializable]
	public class ListaPessoasBusca : System.Windows.Forms.UserControl
	{
        private   ListaPessoasItemBusca          seleção;
        private FlowLayoutPanel flow;

		// Eventos
		public delegate void PessoaSelecionadaDelegate(ListaPessoasItemBusca item);
		public event PessoaSelecionadaDelegate PessoaSelecionada;
		public event PessoaSelecionadaDelegate PessoaIncluída;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constrói lista de clientes
		/// </summary>
		public ListaPessoasBusca()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			seleção     = null;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flow
            // 
            this.flow.AutoScroll = true;
            this.flow.BackColor = System.Drawing.Color.Transparent;
            this.flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow.Location = new System.Drawing.Point(0, 0);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(288, 152);
            this.flow.TabIndex = 0;
            // 
            // ListaPessoasBusca
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.flow);
            this.Name = "ListaPessoasBusca";
            this.Size = new System.Drawing.Size(288, 152);
            this.ResumeLayout(false);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Seleção atual.
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ListaPessoasItemBusca Seleção
		{
			get { return seleção; }
		}

		#endregion

        public void SelecionarPeloTeclado()
        {
            flow.Select();

            if (flow.Controls.Count > 0)
                ((ListaEntidadePessoaItemBusca) flow.Controls[0]).SelecionarViaTeclado();
        }

		/// <summary>
		/// Ocorre quando um item é selecionado pelo mouse.
		/// </summary>
		/// <param name="item">Item selecionado</param>
		/// <remarks>Chamado pela coleção</remarks>
		internal void ItemSelecionado(ListaPessoasItemBusca item)
		{
			seleção = item;

			if (PessoaSelecionada != null)
				PessoaSelecionada(item);
		}

		/// <summary>
		/// Ocorre quando um item é clicado duas vezes.
		/// </summary>
		/// <param name="item">Item selecionado.</param>
		/// <remarks>Chamado pela coleção.</remarks>
		internal void ItemDuploClique(ListaPessoasItemBusca item)
		{
			seleção = item;

			if (PessoaSelecionada != null)
				PessoaSelecionada(item);

			OnDoubleClick(new EventArgs());
		}

        public ListaEntidadePessoaItemBusca PrimeiraPessoa
        {
            get
            {
                if (flow.Controls.Count > 0)
                    return (ListaEntidadePessoaItemBusca)flow.Controls[0];
                else
                    return null;
            }
        }

		/// <summary>
		/// Dispara evento de pessoa incluída.
		/// </summary>
		/// <param name="item">Pessoa incluída.</param>
		internal void DispararPessoaIncluída(ListaPessoasItemBusca item)
		{
            flow.Controls.Add(item);

			if (PessoaIncluída != null)
				PessoaIncluída(item);
		}

        internal void Limpar()
        {
            flow.Controls.Clear();
        }

        internal void Adicionar(ListaEntidadePessoaItemBusca[] itens)
        {
            flow.Controls.AddRange(itens);

            foreach (ListaEntidadePessoaItemBusca i in itens)
            {
                i.Visible = true;
                i.Click += new EventHandler(i_Click);
            }
        }

        void i_Click(object sender, EventArgs e)
        {
            if (PessoaSelecionada != null)
                PessoaSelecionada((ListaPessoasItemBusca) sender);
        }

        private void ListaPessoasBusca_MouseEnter(object sender, EventArgs e)
        {
            // Permite scroll com a roda do mouse
            flow.Focus();
        }
    }
}
