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
        ///// <summary>
        ///// Tamanho ideal de um item.
        ///// </summary>
        //private const int tamanhoItemIdeal = 250;			// Pixels

        //// Atributos
        //protected Cole��oListaPessoasItemBusca	itens;
        //private   Point                     posi��oAtual;
        //private   int                       itemTamanho;	// Tamanho do item
        //private   int                       colunaAtual;
        //private   Sinaliza��oCarga          sinaliza��o;
        private   ListaPessoasItemBusca          sele��o;
        //private   bool                      autoColunas = true;

        //// Propriedades
        //private int							colunas					= 2;
        //private int							dist�nciaEntreColunas	= 15;
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

			// Construir atributos
			//itens       = new Cole��oListaPessoasItemBusca(this);
			//sinaliza��o = null;
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
            this.Load += new System.EventHandler(this.ListaPessoasBusca_Load);
            this.MouseEnter += new System.EventHandler(this.ListaPessoasBusca_MouseEnter);
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

        ///// <summary>
        ///// Itens
        ///// </summary>
        //[Browsable(false), ReadOnly(true)]
        //public Cole��oListaPessoasItemBusca Itens
        //{
        //    get { return itens; }
        //}

        ///// <summary>
        ///// N�mero de colunas a mostrar
        ///// </summary>
        //[DefaultValue(2)]
        //public int Colunas
        //{
        //    get { return colunas; }
        //    set
        //    {
        //        colunas = value;
        //        //				Reorganizar();
        //    }
        //}

        ///// <summary>
        ///// Determina se o n�mero de colunas ser� atribu�do automaticamente.
        ///// </summary>
        //[DefaultValue(true), Description("Se verdadeiro, determina o n�mero de colunas automaticamente.")]
        //public bool AutoColunas
        //{
        //    get { return autoColunas; }
        //    set
        //    {
        //        autoColunas = value;

        //        if (value)
        //            Reorganizar();
        //    }
        //}

        ///// <summary>
        ///// Dist�ncia entre colunas
        ///// </summary>
        //[DefaultValue(15)]
        //public int Dist�nciaEntreColunas
        //{
        //    get { return dist�nciaEntreColunas; }
        //    set
        //    {
        //        dist�nciaEntreColunas = value;
        //        Reorganizar();
        //    }
        //}

		#endregion

        public void SelecionarPeloTeclado()
        {
            flow.Select();

            if (flow.Controls.Count > 0)
                ((ListaEntidadePessoaItemBusca) flow.Controls[0]).SelecionarViaTeclado();
        }

        ///// <summary>
        ///// Reorganiza a visualiza��o da lista de clientes
        ///// </summary>
        //internal void Reorganizar()
        //{
        //    int colunas;
            
        //    if (autoColunas)
        //        colunas = (int) Math.Max(1, Math.Floor((double) ClientSize.Width / (double) tamanhoItemIdeal));
        //    else
        //        colunas = this.colunas;

        //    lock (this)
        //    {
        //        // Suspender o layoute
        //        this.SuspendLayout();

        //        // Calcular tamanho dos itens
        //        itemTamanho  = (this.ClientSize.Width - 1) / colunas - (dist�nciaEntreColunas * (colunas - 1)) / 2;
        //        posi��oAtual = new Point(0, 0);
        //        colunaAtual  = 0;

        //        int contador = 0;

        //        foreach (ListaPessoasItemBusca item in itens)
        //        {
        //            Posicionar(item, colunas);
        //            item.TabIndex = contador++;
        //        }

        //        // Reinicia o layout
        //        this.ResumeLayout();
        //    }
        //}

        ///// <param name="item">Item a ser exibido.</param>
        //internal void Posicionar(ListaPessoasItemBusca item, int colunas)
        //{
        //    lock (this)
        //    {
        //        item.Location = posi��oAtual;
        //        item.Width    = itemTamanho;

        //        if (++colunaAtual < colunas)
        //        {
        //            posi��oAtual.X += itemTamanho + dist�nciaEntreColunas;
        //        }
        //        else
        //        {
        //            posi��oAtual.X  = 0;
        //            posi��oAtual.Y += item.Height + dist�nciaEntreColunas;
        //            colunaAtual     = 0;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Ocorre quando a lista � redimensionada
        ///// </summary>
        //private void ListaClientes_Resize(object sender, System.EventArgs e)
        //{
        //    Reorganizar();
        //}

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
		/// Ocorre quando a lista de pessoas � carregada.
		/// </summary>
		private void ListaPessoasBusca_Load(object sender, System.EventArgs e)
		{
            //// Mostrar uma demonstra��o caso em modo design
            //if (DesignMode && itens.Count == 0)
            //{
            //    itens.Add("Aqui pode vir um nome", "Aqui pode vir outro nome", "Aqui pode vir alguma descri��o", null);
            //    itens.Add("Fulano", "Z� Man� da Cunha", "Eis mais uma demonstra��o", null);
            //    itens.Add("Hamlet", "Dom Casmurro", "Iracema", null);
            //}

			//Reorganizar();
		}

        ///// <summary>
        ///// Sinaliza que a lista est� carregando.
        ///// </summary>
        //public void SinalizarCarga()
        //{
        //    AdicionarSinaliza��o(new Sinaliza��oCarga());
        //}

        ///// <summary>
        ///// Sinaliza que a lista est� carregando.
        ///// </summary>
        ///// <param name="descri��o">Descri��o personalizada.</param>
        //public void SinalizarCarga(string descri��o)
        //{
        //    AdicionarSinaliza��o(new Sinaliza��oCarga(descri��o));
        //}

        ///// <summary>
        ///// Sinaliza que a lista est� carregando.
        ///// </summary>
        ///// <param name="t�tulo">T�tulo personalizado.</param>
        ///// <param name="descri��o">Descri��o personalizada.</param>
        //public void SinalizarCarga(string t�tulo, string descri��o)
        //{
        //    AdicionarSinaliza��o(new Sinaliza��oCarga(t�tulo, descri��o));
        //}

        ///// <summary>
        ///// Adiciona sinaliza��o ao controle.
        ///// </summary>
        ///// <param name="sinaliza��o">Sinaliza��o a ser adicionada.</param>
        //private void AdicionarSinaliza��o(Sinaliza��oCarga sinaliza��o)
        //{
        //    lock (this)
        //    {
        //        if (sinaliza��o != null)
        //            Dessinalizar();
			
        //        this.sinaliza��o = sinaliza��o;

        //        this.SuspendLayout();
				
        //        this.Controls.Add(sinaliza��o);

        //        sinaliza��o.Location = new Point(
        //            (ClientSize.Width - sinaliza��o.Width) / 2,
        //            (ClientSize.Height - sinaliza��o.Height) / 2);

        //        sinaliza��o.BringToFront();

        //        this.ResumeLayout();
        //    }
        //}

        ///// <summary>
        ///// Remove sinaliza��o.
        ///// </summary>
        //public void Dessinalizar()
        //{
        //    lock (this)
        //    {
        //        if (sinaliza��o != null)
        //        {
        //            this.SuspendLayout();
        //            this.Controls.Remove(sinaliza��o);
        //            this.ResumeLayout();
					
        //            sinaliza��o.Dispose();

        //            sinaliza��o = null;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Altera mensagem que est� sendo exibida na sinaliza��o.
        ///// </summary>
        ///// <param name="t�tulo">T�tulo da sinaliza��o.</param>
        ///// <param name="descri��o">Descri��o da sinaliza��o.</param>
        //public void Ressinalizar(string t�tulo, string descri��o)
        //{
        //    if (sinaliza��o == null)
        //        throw new NullReferenceException("Ressinalizar s� pode ser chamado quando alguma sinaliza��o for exibida.");

        //    sinaliza��o.T�tulo = t�tulo;
        //    sinaliza��o.Descri��o = descri��o;
        //}

        ///// <summary>
        ///// Auto-ordena��o da lista de itens.
        ///// </summary>
        //[DefaultValue(true)]
        //public bool AutoOrdena��o
        //{
        //    get { return itens.AutoOrdena��o; }
        //    set { itens.AutoOrdena��o = value; }
        //}

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
            //flow.SuspendLayout();
            //flow.Visible = false;
            flow.Controls.AddRange(itens);

            foreach (ListaEntidadePessoaItemBusca i in itens)
            {
                i.Visible = true;
                i.Click += new EventHandler(i_Click);
            }

            //flow.Visible = true;
            //flow.ResumeLayout();
        }

        void i_Click(object sender, EventArgs e)
        {
            if (PessoaSelecionada != null)
                PessoaSelecionada((ListaPessoasItemBusca) sender);
        }

        private void ListaPessoasBusca_MouseEnter(object sender, EventArgs e)
        {
            // Permite scrool com a bolinha do mouse
            flow.Focus();
        }
    }
}
