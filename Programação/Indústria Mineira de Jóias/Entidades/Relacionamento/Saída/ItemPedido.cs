using System;
using System.Data;
using System.Collections; 
using Acesso.Comum;
using Acesso.Comum.Exce��es;
using Entidades.Relacionamento;

namespace Entidades.Pedido
{

	    #region ItemPedido n�o deveria ser serializ�vel. Porqu� ? 
	/*
	 * Se marcamos a serializa��o, quando a apresenta��o obt�m algum pedido, as refer�ncias para seus 
	 * objetos de itemPedido ir�o juntos. No entanto, ninguem sen�o o pr�prio contexto Pedido
	 * precisa dos itens-Pedido. A apresenta��o n�o quer saber a sa�da e retorno de �nico pedido,
	 * lhe interessa uma sa�da que seja um somat�rio de todos seus pedidos interessados.
	 * Isso � feito no m�todo Pedido.ObterAcerto(ArrayList de IPedidos interessados), que 
	 * retorna um ArrayList de Entidades.Acerto. Deve ser evitado a serializa��o desta classe.
	 * 
	 * por�m a linha: pedidosC�digo.Add(pedido.Entidade.C�digo);
	 * (na bandejaAcerto)
	 * d� erro de n�o ser serializ�vel, porque ? 
	 */
	#endregion

    /// <summary>
    /// Uma pedido cont�m v�rios itempedido.
    /// O itemPedido descreve a sa�da e o retorno de uma mercadoria.
    /// Portanto, para cada mercadoria relacionada em um pedido existe um itempedido.
    /// A obten��o dos 'itemPedido' e de sua 'mercadoria' � feito na Entidade.Pedido,
    /// que � chamado apenas quando o servidor liga.
    /// </summary>
	[Serializable]
	public class ItemPedido : ItemRelacionado
	{
		// Atributos
		[DbRelacionamento(true, "codigo", "pedido")]
		private Pedido pedido;

		public Pedido Pedido
		{
			get { return pedido; }
			set
			{
				lock (this)
				{
					if (cadastrado)
						throw new Exception("O pedido de um ItemPedido n�o pode ser alterado quando j� cadastrado.");

					pedido = value;
				}
			}
		}

        /// <summary>
        /// Constr�i um ItemPedido a partir de dados j� adquiridos.
        /// </summary>
        /// <remarks>
        public ItemPedido(Pedido pedido, Mercadoria mercadoria, double quantidade)
            : base(mercadoria, quantidade)
        {
            this.pedido = pedido;
        }

        /// <summary>
        /// Constr�i um ItemPedido a partir de dados j� adquiridos,
        /// permitindo afirmar que os dados est�o no banco de dados.
        /// </summary>
        /// <param name="cadastrado">Se os dados j� est�o cadastrados no BD.</param>
        public ItemPedido(Pedido pedido, Mercadoria mercadoria, double quantidade, bool cadastrado)
            : this(pedido, mercadoria, quantidade)
        {
            this.cadastrado = this.atualizado = cadastrado;
        }

	}
}
