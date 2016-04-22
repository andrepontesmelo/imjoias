using System;
using System.Data;
using System.Collections; 
using Acesso.Comum;
using Acesso.Comum.Exce��es;
using Entidades.Relacionamento;

namespace Entidades.Relacionamento.Sa�da
{
    /// <summary>
    /// Item da cole��o Cole��oItemSa�da
    /// </summary>
    [Serializable, DbTabela("saidaitem")]
	public class Hist�ricoSa�daItem : Hist�ricoRelacionamentoItem
	{
		// Atributos
		[DbRelacionamento(true, "codigo", "saida")]
		private Sa�da sa�da;

		public Sa�da Sa�da
		{
			get { return sa�da; }
			set
			{
				lock (this)
				{
					if (Cadastrado)
						throw new Exception("A sa�da de um itemsaida n�o pode ser alterado quando j� cadastrado.");

					sa�da = value;
				}
			}
		}

        /// <summary>
        /// Constr�i um itemsaida a partir de dados j� adquiridos.
        /// </summary>
        public Hist�ricoSa�daItem(Sa�da sa�da, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcion�rio funcion�rio, double �ndice)
            : base(mercadoria, quantidade, data, funcion�rio, �ndice)
        {
            this.sa�da = sa�da;
        }
	}
}
