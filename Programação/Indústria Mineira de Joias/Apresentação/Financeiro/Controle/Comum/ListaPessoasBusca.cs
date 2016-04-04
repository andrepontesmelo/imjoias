using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Apresenta��o.Atendimento.Clientes;

namespace Apresenta��o.Atendimento.Comum
{
	/// <summary>
	/// Lista de clientes
	/// </summary>
	[Serializable]
	public class ListaPessoasBusca : System.Windows.Forms.UserControl
	{
        private   ListaPessoasItemBusca          sele��o;
        private FlowLayoutPanel flow;

		// Eventos
		public delegate void PessoaSelecionadaDelegate(ListaPessoasItemBusca item);
		public event PessoaSelecionadaDelegate PessoaSelecionada;
		public event PessoaSelecionadaDelegate PessoaInclu�da;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constr�i lista de clientes
		/// </summary>
		public ListaPessoasBusca()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			sele��o     = null;
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
		/// Sele��o atual.
		/// </summary>
		[Browsable(false), ReadOnly(true)]
		public ListaPessoasItemBusca Sele��o
		{
			get { return sele��o; }
		}

		#endregion

        public void SelecionarPeloTeclado()
        {
            flow.Select();

            if (flow.Controls.Count > 0)
                ((ListaEntidadePessoaItemBusca) flow.Controls[0]).SelecionarViaTeclado();
        }

		/// <summary>
		/// Ocorre quando um item � selecionado pelo mouse.
		/// </summary>
		/// <param name="item">Item selecionado</param>
		/// <remarks>Chamado pela cole��o</remarks>
		internal void ItemSelecionado(ListaPessoasItemBusca item)
		{
			sele��o = item;

			if (PessoaSelecionada != null)
				PessoaSelecionada(item);
		}

		/// <summary>
		/// Ocorre quando um item � clicado duas vezes.
		/// </summary>
		/// <param name="item">Item selecionado.</param>
		/// <remarks>Chamado pela cole��o.</remarks>
		internal void ItemDuploClique(ListaPessoasItemBusca item)
		{
			sele��o = item;

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
		/// Dispara evento de pessoa inclu�da.
		/// </summary>
		/// <param name="item">Pessoa inclu�da.</param>
		internal void DispararPessoaInclu�da(ListaPessoasItemBusca item)
		{
            flow.Controls.Add(item);

			if (PessoaInclu�da != null)
				PessoaInclu�da(item);
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
