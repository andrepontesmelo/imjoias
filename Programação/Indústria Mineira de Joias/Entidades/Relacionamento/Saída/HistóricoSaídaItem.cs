using System;
using System.Data;
using System.Collections; 
using Acesso.Comum;
using Acesso.Comum.Exceções;
using Entidades.Relacionamento;

namespace Entidades.Relacionamento.Saída
{
    /// <summary>
    /// Item da coleção ColeçãoItemSaída
    /// </summary>
    [Serializable, DbTabela("saidaitem")]
	public class HistóricoSaídaItem : HistóricoRelacionamentoItem
	{
		// Atributos
		[DbRelacionamento(true, "codigo", "saida")]
		private Saída saída;

		public Saída Saída
		{
			get { return saída; }
			set
			{
				lock (this)
				{
					if (Cadastrado)
						throw new Exception("A saída de um itemsaida não pode ser alterado quando já cadastrado.");

					saída = value;
				}
			}
		}

        /// <summary>
        /// Constrói um itemsaida a partir de dados já adquiridos.
        /// </summary>
        public HistóricoSaídaItem(Saída saída, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
            : base(mercadoria, quantidade, data, funcionário, índice)
        {
            this.saída = saída;
        }
	}
}
