using System;
using System.Collections;
using Entidades.Relacionamento;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades.Pedido
{
	/// <summary>
	/// Coleção de ItemPedido
	/// Trata-se de um ArrayList personalizado.
	/// Um Entidades.Pedido contém um objeto ColeçãoItemPedido
	/// </summary>
	[Serializable]
	public class ColeçãoItemPedido : ColeçãoItemRelacionado
	{
        [DbAtributo(TipoAtributo.Ignorar)]
		private Pedido pedido;

		public Pedido Pedido
		{
			get { return pedido; }
		}

        /// <summary>
		/// Constrói uma coleção de ItemPedido.
		/// </summary>
		/// <param name="pedido">Pedido original.</param>
		public ColeçãoItemPedido(Pedido pedido) : base(pedido)
		{
			this.pedido    = pedido;
		}

		protected override ItemRelacionado ConstruirNovoItem(Mercadoria mercadoria, double quantidade)
		{
			return new ItemPedido(pedido, mercadoria, quantidade);
		}

        /// <summary>
        /// Descadastra vários itemPedido deste pedido,
        /// em consulta única
        /// </summary>
        public override void DescadastrarItens(System.Collections.Generic.List<Saquinho> saquinhos)
        {
            if (saquinhos.Count == 0) return;

            IDbConnection conexão = Conexão;

            string consulta = "delete from itempedido where PEDIDO=" + DbTransformar(pedido.Código);
            bool primeiro = true;

            consulta += " AND (";
            // Constrói a consulta

            foreach (Saquinho s in saquinhos)
            {
                if (!primeiro) consulta += " OR ";

                consulta += " (referencia=" + DbTransformar(s.Mercadoria.ReferênciaNumérica);
                if (s.Mercadoria.DePeso)
                {
                    consulta += " AND peso = " + DbTransformar(s.Mercadoria.Peso);
                    //referencia='10100101121' AND pedido=1
                }

                consulta += ")";
                primeiro = false;
            }

            consulta += ")";

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                lock (conexão)
                {
                    cmd.CommandText = consulta;

                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("A query alterou nenhuma row! \nconsulta: " + consulta.ToString());
                }
            }
        }
        
	}
}
