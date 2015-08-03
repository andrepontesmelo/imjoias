using System;
using System.Collections;
using Entidades.Relacionamento;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades.Relacionamento.Sa�da
{
	/// <summary>
	/// Cole��o de ItemSa�da
	/// Trata-se de um ArrayList personalizado.
	/// Um Entidades.Sa�da cont�m um objeto Cole��oItemSa�da
	/// </summary>
	[Serializable]
	public class Hist�ricoRelacionamentoSa�da : Hist�ricoRelacionamento
	{
        [DbAtributo(TipoAtributo.Ignorar)]
		private Sa�da sa�da;

		public Sa�da Sa�da
		{
			get { return sa�da; }
		}

        /// <summary>
		/// Constr�i uma cole��o de ItemSa�da.
		/// </summary>
		/// <param name="sa�da">Documento de sa�da original.</param>
		public Hist�ricoRelacionamentoSa�da(Sa�da sa�da) : base(sa�da)
		{
            this.sa�da 
                = sa�da;
		}

        protected override string Tabela
        {
            get { return "saidaitem"; }
        }

        protected override string TabelaPai
        {
            get { return "saida"; }
        }

        protected override Hist�ricoRelacionamentoItem ConstruirItemHist�rico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcion�rio funcion�rio, double �ndice)
        {
            return new Hist�ricoSa�daItem(sa�da, mercadoria, quantidade, data, funcion�rio, �ndice);
        }


	}
}
