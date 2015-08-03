using System;
using System.Collections;
using Entidades.Relacionamento;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades.Relacionamento.Saída
{
	/// <summary>
	/// Coleção de ItemSaída
	/// Trata-se de um ArrayList personalizado.
	/// Um Entidades.Saída contém um objeto ColeçãoItemSaída
	/// </summary>
	[Serializable]
	public class HistóricoRelacionamentoSaída : HistóricoRelacionamento
	{
        [DbAtributo(TipoAtributo.Ignorar)]
		private Saída saída;

		public Saída Saída
		{
			get { return saída; }
		}

        /// <summary>
		/// Constrói uma coleção de ItemSaída.
		/// </summary>
		/// <param name="saída">Documento de saída original.</param>
		public HistóricoRelacionamentoSaída(Saída saída) : base(saída)
		{
            this.saída 
                = saída;
		}

        protected override string Tabela
        {
            get { return "saidaitem"; }
        }

        protected override string TabelaPai
        {
            get { return "saida"; }
        }

        protected override HistóricoRelacionamentoItem ConstruirItemHistórico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
        {
            return new HistóricoSaídaItem(saída, mercadoria, quantidade, data, funcionário, índice);
        }


	}
}
