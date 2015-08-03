using System;
using System.Data;
using System.Collections; 
using Acesso.Comum;
using Acesso.Comum.Exceções;
using Entidades.Relacionamento;

namespace Entidades.Pedido
{

	    #region ItemPedido não deveria ser serializável. Porquê ? 
	/*
	 * Se marcamos a serialização, quando a apresentação obtém algum pedido, as referências para seus 
	 * objetos de itemPedido irão juntos. No entanto, ninguem senão o próprio contexto Pedido
	 * precisa dos itens-Pedido. A apresentação não quer saber a saída e retorno de único pedido,
	 * lhe interessa uma saída que seja um somatório de todos seus pedidos interessados.
	 * Isso é feito no método Pedido.ObterAcerto(ArrayList de IPedidos interessados), que 
	 * retorna um ArrayList de Entidades.Acerto. Deve ser evitado a serialização desta classe.
	 * 
	 * porém a linha: pedidosCódigo.Add(pedido.Entidade.Código);
	 * (na bandejaAcerto)
	 * dá erro de não ser serializável, porque ? 
	 */
	#endregion

    /// <summary>
    /// Uma pedido contém vários itempedido.
    /// O itemPedido descreve a saída e o retorno de uma mercadoria.
    /// Portanto, para cada mercadoria relacionada em um pedido existe um itempedido.
    /// A obtenção dos 'itemPedido' e de sua 'mercadoria' é feito na Entidade.Pedido,
    /// que é chamado apenas quando o servidor liga.
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
						throw new Exception("O pedido de um ItemPedido não pode ser alterado quando já cadastrado.");

					pedido = value;
				}
			}
		}

        /// <summary>
        /// Constrói um ItemPedido a partir de dados já adquiridos.
        /// </summary>
        /// <remarks>
        public ItemPedido(Pedido pedido, Mercadoria mercadoria, double quantidade)
            : base(mercadoria, quantidade)
        {
            this.pedido = pedido;
        }

        /// <summary>
        /// Constrói um ItemPedido a partir de dados já adquiridos,
        /// permitindo afirmar que os dados estão no banco de dados.
        /// </summary>
        /// <param name="cadastrado">Se os dados já estão cadastrados no BD.</param>
        public ItemPedido(Pedido pedido, Mercadoria mercadoria, double quantidade, bool cadastrado)
            : this(pedido, mercadoria, quantidade)
        {
            this.cadastrado = this.atualizado = cadastrado;
        }

	}
}
