using System;
using System.Collections;
using Entidades.Pessoa;

namespace Apresenta��o.Atendimento.Comum
{
	/// <summary>
	/// Cole��o de ListaPessoasItem
	/// </summary>
	public class Cole��oListaPessoasItem : ArrayList
	{
		private ListaPessoas 	listaPessoas;
		private EventHandler	itemFechar;
		private EventHandler	itemClick;
		private EventHandler    itemDuploClick;
		private bool            autoOrdena��o = true;

		/// <summary>
		/// Constr�i uma cole��o de ListaPessoasItem a partir de um dono ListaClientes
		/// </summary>
		public Cole��oListaPessoasItem(ListaPessoas dono) : base()
		{
			this.listaPessoas = dono;

			// Prepara tratamento de eventos
			itemFechar     = new EventHandler(item_Fechar);
			itemClick      = new EventHandler(item_Click);
			itemDuploClick = new EventHandler(item_DuploClick);
		}

		/// <summary>
		/// Adiciona tratamento de eventos ao item da lista de pessoas.
		/// </summary>
		/// <param name="item">Item cujos eventos ser�o tratados.</param>
		private void TratarEventos(ListaPessoasItem item)
		{
			item.Fechar      += itemFechar;
			item.Click       += itemClick;
			item.DoubleClick += itemDuploClick;
		}

		/// <summary>
		/// Remove tratamento de eventos ao item da lista de pessoas.
		/// </summary>
		/// <param name="item">Item cujos eventos ser�o destratados.</param>
		private void DestratarEventos(ListaPessoasItem item)
		{
			item.Fechar      -= itemFechar;
			item.Click       -= itemClick;
			item.DoubleClick -= itemDuploClick;
		}

		/// <summary>
		/// Adiciona um conjunto.
		/// </summary>
		/// <param name="c">Conjunto a ser adicionado.</param>
		public override void AddRange(ICollection c)
		{
			foreach (ListaPessoasItem item in c)
			{
				listaPessoas.Controls.Add(item);
				TratarEventos(item);
			}

			base.AddRange(c);

			if (autoOrdena��o)
				base.Sort();

			listaPessoas.Reorganizar();
		}

		private delegate void AddCallback(ListaPessoasItem item);

		/// <summary>
		/// Adiciona um item � lista de clientes
		/// </summary>
		public void Add(ListaPessoasItem item)
		{
			if (listaPessoas.InvokeRequired)
			{
				AddCallback m�todo = new AddCallback(Add);
				listaPessoas.BeginInvoke(m�todo, new object[] { item });
			}
			else
			{
				// Insere na lista
				base.Add(item);

				if (autoOrdena��o)
					base.Sort();

				// Insere no visual da lista
				listaPessoas.Controls.Add(item);
				TratarEventos(item);

				// Reorganiza dono
				listaPessoas.Reorganizar();

				listaPessoas.DispararPessoaInclu�da(item);
			}
		}


		/// <summary>
		/// Cria um item e o adiciona � lista de pessoas.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio a ser inserido.</param>
		public void Add(Funcion�rio funcion�rio)
		{
			Atendente.ListaFuncion�rioItem item;

			item = new Atendente.ListaFuncion�rioItem(funcion�rio);

			this.Add((ListaPessoasItem) item);
		}

		/// <summary>
		/// Cria um item a partir de uma entidade pessoa e
		/// o adiciona � lista de pessoas.
		/// </summary>
		/// <param name="pessoa">Entidade pessoa.</param>
		public void Add(Entidades.Pessoa.Pessoa pessoa)
		{
			Clientes.ListaEntidadePessoaItem item;

			item = new Clientes.ListaEntidadePessoaItem(pessoa);

			this.Add((ListaPessoasItem) item);
		}

        public void Add(Entidades.Visita visita)
        {
            Atendente.ListaPessoasVisitante item;

            item = new Apresenta��o.Atendimento.Atendente.ListaPessoasVisitante(visita);

            this.Add((ListaPessoasItem) item);
        }

		/// <summary>
		/// Cria um item e o adiciona � lista de pessoas
		/// </summary>
		public void Add(string prim�ria, string secund�ria, string descri��o)
		{
			ListaPessoasItem item;

			item = new ListaPessoasItem(prim�ria, secund�ria, descri��o);
			
			this.Add(item);
		}

		private delegate void RemoveCallback(ListaPessoasItem item);

		/// <summary>
		/// Remove um item da lista de pessoas
		/// </summary>
		/// <param name="item"></param>
		public void Remove(ListaPessoasItem item)
		{
			if (listaPessoas.InvokeRequired)
			{
				RemoveCallback m�todo = new RemoveCallback(Remove);
				listaPessoas.BeginInvoke(m�todo, new object[] { item } );
			}
			else
			{
				// Remove da lista
				base.Remove(item);

				// Remove do visual da lista
				listaPessoas.Controls.Remove(item);
				DestratarEventos(item);

				// Reorganiza dono
				listaPessoas.Reorganizar();
			}
		}

		/// <summary>
		/// Remove um visitante da lista de pessoas.
		/// </summary>
		/// <param name="visitante">Visitante a ser removido.</param>
		public void Remove(Entidades.Pessoa.Pessoa visitante)
		{
			foreach (ListaPessoasItem item in this)
			{
                if (typeof(Clientes.ListaEntidadePessoaItem).IsInstanceOfType(item))
				{
                    if (((Clientes.ListaEntidadePessoaItem)item).Pessoa == visitante)
					{
						Remove(item);
						return;
					}
				}
			}

			throw new ArgumentException("Visitante n�o encontrado.", "visitante");
		}

		/// <summary>
		/// Remove um funcion�rio da lista de pessoas.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio a ser removido.</param>
		public void Remove(Funcion�rio funcion�rio)
		{
			foreach (ListaPessoasItem item in this)
			{
				if (typeof(Atendente.ListaFuncion�rioItem).IsInstanceOfType(item))
				{
					if (((Atendente.ListaFuncion�rioItem) item).Funcion�rio == funcion�rio)
					{
						Remove(item);
						return;
					}
				}
			}

			throw new ArgumentException("Funcion�rio n�o encontrado.", "funcion�rio");
		}

		private delegate void ClearCallback();

		/// <summary>
		/// Limpa a lista.
		/// </summary>
		public override void Clear()
		{
			if (listaPessoas.InvokeRequired)
			{
				ClearCallback m�todo = new ClearCallback(Clear);
				listaPessoas.BeginInvoke(m�todo);
			}
			else
			{
				foreach (ListaPessoasItem item in this)
				{
					listaPessoas.Controls.Remove(item);
					DestratarEventos(item);
				}

				base.Clear();

				listaPessoas.Reorganizar();
			}
		}

		/// <summary>
		/// Ocorre quando o item � fechado.
		/// </summary>
		private void item_Fechar(object sender, EventArgs e)
		{
			this.Remove((ListaPessoasItem) sender);
		}

		/// <summary>
		/// Ocorre quando o item � clicado.
		/// </summary>
		private void item_Click(object sender, EventArgs e)
		{
			listaPessoas.ItemSelecionado((ListaPessoasItem) sender);
		}

		/// <summary>
		/// Ocorre quando o item � duplamente clicado.
		/// </summary>
		private void item_DuploClick(object sender, EventArgs e)
		{
			listaPessoas.ItemDuploClique((ListaPessoasItem) sender);
		}

		/// <summary>
		/// Obt�m item a partir de seu �ndice.
		/// </summary>
		public new ListaPessoasItem this[int idx]
		{
			get
			{
				return (ListaPessoasItem) base[idx];
			}
		}

		/// <summary>
		/// Auto-ordena��o da lista.
		/// </summary>
		public bool AutoOrdena��o
		{
			get { return autoOrdena��o; }
			set
			{
				autoOrdena��o = value;

				if (autoOrdena��o)
					base.Sort();
			}
		}

		/// <summary>
		/// Verifica se cont�m um item.
		/// </summary>
		/// <param name="item">Funcion�rio.</param>
		/// <returns>Se existe o funcion�rio na lista.</returns>
		public bool Contains(Funcion�rio funcion�rio)
		{
			foreach (ListaPessoasItem item in this)
			{
				if (typeof(Atendente.ListaFuncion�rioItem).IsInstanceOfType(item))
				{
					if (((Atendente.ListaFuncion�rioItem) item).Funcion�rio == funcion�rio)
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Verifica se cont�m um item.
		/// </summary>
		/// <param name="item">Visitante.</param>
		/// <returns>Se existe o visitante na lista.</returns>
		public bool Contains(Entidades.Pessoa.Pessoa visitante)
		{
			foreach (ListaPessoasItem item in this)
			{
				if (typeof(Clientes.ListaEntidadePessoaItem).IsInstanceOfType(item))
				{
                    if (((Clientes.ListaEntidadePessoaItem)item).Pessoa == visitante)
						return true;
				}
			}

			return false;
		}
	}
}
