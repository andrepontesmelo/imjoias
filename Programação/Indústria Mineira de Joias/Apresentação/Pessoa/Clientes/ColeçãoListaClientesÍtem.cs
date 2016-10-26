using System;
using System.Collections;

namespace Apresenta��o.Atendimento.Clientes
{
	/// <summary>
	/// Cole��o de ListaClientes�tem
	/// </summary>
	public class Cole��oListaClientes�tem : ArrayList
	{
		private ListaClientes	listaClientes;
		private EventHandler	�temFechar;
		private EventHandler	�temClick;

		/// <summary>
		/// Constr�i uma cole��o de ListaClientes�tem a partir de um dono ListaClientes
		/// </summary>
		public Cole��oListaClientes�tem(ListaClientes dono) : base()
		{
			this.listaClientes = dono;

			// Prepara tratamento de eventos
			�temFechar = new EventHandler(�tem_Fechar);
			�temClick  = new EventHandler(�tem_Click);
		}

		/// <summary>
		/// Adiciona um �tem � lista de clientes
		/// </summary>
		public void Add(ListaClientes�tem �tem)
		{
			// Insere na lista
			base.Add(�tem);
			base.Sort();

			// Insere no visual da lista
			listaClientes.Controls.Add(�tem);
			
			// Reorganiza dono
			listaClientes.Reorganizar();

			// Trata eventos
			�tem.Fechar += �temFechar;
			�tem.Click += �temClick;
		}

		/// <summary>
		/// Cria um �tem e o adiciona � lista de clientes
		/// </summary>
		/// <param name="visitante">Visitante a ser inserido</param>
		public void Add(Neg�cio.IVisitante visitante)
		{
			ListaClientes�tem �tem;

			�tem = new ListaClientes�tem();
			�tem.Visitante = visitante;

			this.Add(�tem);
		}

		public void Remove(ListaClientes�tem �tem)
		{
			// Remove da lista
			base.Remove(�tem);

			// Remove do visual da lista
			listaClientes.Controls.Remove(�tem);

			// Reorganiza dono
			listaClientes.Reorganizar();

			// Finaliza tratamento de eventos
			((ListaClientes�tem) �tem).Fechar -= �temFechar;
		}

		/// <summary>
		/// Ocorre quando o �tem � fechado
		/// </summary>
		private void �tem_Fechar(object sender, EventArgs e)
		{
			this.Remove((ListaClientes�tem) sender);
		}

		/// <summary>
		/// Ocorre quando o �tem � clicado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void �tem_Click(object sender, EventArgs e)
		{
			listaClientes.�temSelecionado((ListaClientes�tem) sender);
		}
	}
}
