using System;
using System.Collections;

namespace Apresentação.Atendimento.Clientes
{
	/// <summary>
	/// Coleção de ListaClientesÍtem
	/// </summary>
	public class ColeçãoListaClientesÍtem : ArrayList
	{
		private ListaClientes	listaClientes;
		private EventHandler	ítemFechar;
		private EventHandler	ítemClick;

		/// <summary>
		/// Constrói uma coleção de ListaClientesÍtem a partir de um dono ListaClientes
		/// </summary>
		public ColeçãoListaClientesÍtem(ListaClientes dono) : base()
		{
			this.listaClientes = dono;

			// Prepara tratamento de eventos
			ítemFechar = new EventHandler(ítem_Fechar);
			ítemClick  = new EventHandler(ítem_Click);
		}

		/// <summary>
		/// Adiciona um ítem à lista de clientes
		/// </summary>
		public void Add(ListaClientesÍtem ítem)
		{
			// Insere na lista
			base.Add(ítem);
			base.Sort();

			// Insere no visual da lista
			listaClientes.Controls.Add(ítem);
			
			// Reorganiza dono
			listaClientes.Reorganizar();

			// Trata eventos
			ítem.Fechar += ítemFechar;
			ítem.Click += ítemClick;
		}

		/// <summary>
		/// Cria um ítem e o adiciona à lista de clientes
		/// </summary>
		/// <param name="visitante">Visitante a ser inserido</param>
		public void Add(Negócio.IVisitante visitante)
		{
			ListaClientesÍtem ítem;

			ítem = new ListaClientesÍtem();
			ítem.Visitante = visitante;

			this.Add(ítem);
		}

		public void Remove(ListaClientesÍtem ítem)
		{
			// Remove da lista
			base.Remove(ítem);

			// Remove do visual da lista
			listaClientes.Controls.Remove(ítem);

			// Reorganiza dono
			listaClientes.Reorganizar();

			// Finaliza tratamento de eventos
			((ListaClientesÍtem) ítem).Fechar -= ítemFechar;
		}

		/// <summary>
		/// Ocorre quando o ítem é fechado
		/// </summary>
		private void ítem_Fechar(object sender, EventArgs e)
		{
			this.Remove((ListaClientesÍtem) sender);
		}

		/// <summary>
		/// Ocorre quando o ítem é clicado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ítem_Click(object sender, EventArgs e)
		{
			listaClientes.ÍtemSelecionado((ListaClientesÍtem) sender);
		}
	}
}
