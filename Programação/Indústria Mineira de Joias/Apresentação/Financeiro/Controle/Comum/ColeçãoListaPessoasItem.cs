using System;
using System.Collections;
using Entidades.Pessoa;

namespace Apresentação.Atendimento.Comum
{
	/// <summary>
	/// Coleção de ListaPessoasItem
	/// </summary>
	public class ColeçãoListaPessoasItem : ArrayList
	{
		private ListaPessoas 	listaPessoas;
		private EventHandler	itemFechar;
		private EventHandler	itemClick;
		private EventHandler    itemDuploClick;
		private bool            autoOrdenação = true;

		/// <summary>
		/// Constrói uma coleção de ListaPessoasItem a partir de um dono ListaClientes
		/// </summary>
		public ColeçãoListaPessoasItem(ListaPessoas dono) : base()
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
		/// <param name="item">Item cujos eventos serão tratados.</param>
		private void TratarEventos(ListaPessoasItem item)
		{
			item.Fechar      += itemFechar;
			item.Click       += itemClick;
			item.DoubleClick += itemDuploClick;
		}

		/// <summary>
		/// Remove tratamento de eventos ao item da lista de pessoas.
		/// </summary>
		/// <param name="item">Item cujos eventos serão destratados.</param>
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

			if (autoOrdenação)
				base.Sort();

			listaPessoas.Reorganizar();
		}

		private delegate void AddCallback(ListaPessoasItem item);

		/// <summary>
		/// Adiciona um item à lista de clientes
		/// </summary>
		public void Add(ListaPessoasItem item)
		{
			if (listaPessoas.InvokeRequired)
			{
				AddCallback método = new AddCallback(Add);
				listaPessoas.BeginInvoke(método, new object[] { item });
			}
			else
			{
				// Insere na lista
				base.Add(item);

				if (autoOrdenação)
					base.Sort();

				// Insere no visual da lista
				listaPessoas.Controls.Add(item);
				TratarEventos(item);

				// Reorganiza dono
				listaPessoas.Reorganizar();

				listaPessoas.DispararPessoaIncluída(item);
			}
		}


		/// <summary>
		/// Cria um item e o adiciona à lista de pessoas.
		/// </summary>
		/// <param name="funcionário">Funcionário a ser inserido.</param>
		public void Add(Funcionário funcionário)
		{
			Atendente.ListaFuncionárioItem item;

			item = new Atendente.ListaFuncionárioItem(funcionário);

			this.Add((ListaPessoasItem) item);
		}

		/// <summary>
		/// Cria um item a partir de uma entidade pessoa e
		/// o adiciona à lista de pessoas.
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

            item = new Apresentação.Atendimento.Atendente.ListaPessoasVisitante(visita);

            this.Add((ListaPessoasItem) item);
        }

		/// <summary>
		/// Cria um item e o adiciona à lista de pessoas
		/// </summary>
		public void Add(string primária, string secundária, string descrição)
		{
			ListaPessoasItem item;

			item = new ListaPessoasItem(primária, secundária, descrição);
			
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
				RemoveCallback método = new RemoveCallback(Remove);
				listaPessoas.BeginInvoke(método, new object[] { item } );
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

			throw new ArgumentException("Visitante não encontrado.", "visitante");
		}

		/// <summary>
		/// Remove um funcionário da lista de pessoas.
		/// </summary>
		/// <param name="funcionário">Funcionário a ser removido.</param>
		public void Remove(Funcionário funcionário)
		{
			foreach (ListaPessoasItem item in this)
			{
				if (typeof(Atendente.ListaFuncionárioItem).IsInstanceOfType(item))
				{
					if (((Atendente.ListaFuncionárioItem) item).Funcionário == funcionário)
					{
						Remove(item);
						return;
					}
				}
			}

			throw new ArgumentException("Funcionário não encontrado.", "funcionário");
		}

		private delegate void ClearCallback();

		/// <summary>
		/// Limpa a lista.
		/// </summary>
		public override void Clear()
		{
			if (listaPessoas.InvokeRequired)
			{
				ClearCallback método = new ClearCallback(Clear);
				listaPessoas.BeginInvoke(método);
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
		/// Ocorre quando o item é fechado.
		/// </summary>
		private void item_Fechar(object sender, EventArgs e)
		{
			this.Remove((ListaPessoasItem) sender);
		}

		/// <summary>
		/// Ocorre quando o item é clicado.
		/// </summary>
		private void item_Click(object sender, EventArgs e)
		{
			listaPessoas.ItemSelecionado((ListaPessoasItem) sender);
		}

		/// <summary>
		/// Ocorre quando o item é duplamente clicado.
		/// </summary>
		private void item_DuploClick(object sender, EventArgs e)
		{
			listaPessoas.ItemDuploClique((ListaPessoasItem) sender);
		}

		/// <summary>
		/// Obtém item a partir de seu índice.
		/// </summary>
		public new ListaPessoasItem this[int idx]
		{
			get
			{
				return (ListaPessoasItem) base[idx];
			}
		}

		/// <summary>
		/// Auto-ordenação da lista.
		/// </summary>
		public bool AutoOrdenação
		{
			get { return autoOrdenação; }
			set
			{
				autoOrdenação = value;

				if (autoOrdenação)
					base.Sort();
			}
		}

		/// <summary>
		/// Verifica se contém um item.
		/// </summary>
		/// <param name="item">Funcionário.</param>
		/// <returns>Se existe o funcionário na lista.</returns>
		public bool Contains(Funcionário funcionário)
		{
			foreach (ListaPessoasItem item in this)
			{
				if (typeof(Atendente.ListaFuncionárioItem).IsInstanceOfType(item))
				{
					if (((Atendente.ListaFuncionárioItem) item).Funcionário == funcionário)
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Verifica se contém um item.
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
