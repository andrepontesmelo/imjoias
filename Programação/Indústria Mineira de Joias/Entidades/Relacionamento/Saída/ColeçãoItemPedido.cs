using System;
using System.Collections;
using Entidades.Relacionamento;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades.Pedido
{
	/// <summary>
	/// Cole��o de ItemPedido
	/// Trata-se de um ArrayList personalizado.
	/// Um Entidades.Pedido cont�m um objeto Cole��oItemPedido
	/// </summary>
	[Serializable]
	public class Cole��oItemPedido : Cole��oItemRelacionado
	{
        [DbAtributo(TipoAtributo.Ignorar)]
		private Pedido pedido;

		public Pedido Pedido
		{
			get { return pedido; }
		}

        /// <summary>
		/// Constr�i uma cole��o de ItemPedido.
		/// </summary>
		/// <param name="pedido">Pedido original.</param>
		public Cole��oItemPedido(Pedido pedido) : base(pedido)
		{
			this.pedido    = pedido;
		}

		protected override ItemRelacionado ConstruirNovoItem(Mercadoria mercadoria, double quantidade)
		{
			return new ItemPedido(pedido, mercadoria, quantidade);
		}

        /// <summary>
        /// Descadastra v�rios itemPedido deste pedido,
        /// em consulta �nica
        /// </summary>
        public override void DescadastrarItens(System.Collections.Generic.List<Saquinho> saquinhos)
        {
            if (saquinhos.Count == 0) return;

            IDbConnection conex�o = Conex�o;

            string consulta = "delete from itempedido where PEDIDO=" + DbTransformar(pedido.C�digo);
            bool primeiro = true;

            consulta += " AND (";
            // Constr�i a consulta

            foreach (Saquinho s in saquinhos)
            {
                if (!primeiro) consulta += " OR ";

                consulta += " (referencia=" + DbTransformar(s.Mercadoria.Refer�nciaNum�rica);
                if (s.Mercadoria.DePeso)
                {
                    consulta += " AND peso = " + DbTransformar(s.Mercadoria.Peso);
                    //referencia='10100101121' AND pedido=1
                }

                consulta += ")";
                primeiro = false;
            }

            consulta += ")";

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                lock (conex�o)
                {
                    cmd.CommandText = consulta;

                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("A query alterou nenhuma row! \nconsulta: " + consulta.ToString());
                }
            }
        }
        
	}
}
