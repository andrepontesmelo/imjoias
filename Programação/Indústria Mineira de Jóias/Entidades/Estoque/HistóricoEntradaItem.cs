using Acesso.Comum;
using Entidades.Relacionamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    [Serializable, DbTabela("entradaitem")]
    public class HistóricoEntradaItem : HistóricoRelacionamentoItem
    {
		// Atributos
		[DbRelacionamento(true, "codigo", "entrada")]
		private Entrada entrada;

		public Entrada  Entrada
		{
			get { return entrada; }
			set
			{
				lock (this)
				{
					if (Cadastrado)
						throw new Exception("A entrada de um itementrada não pode ser alterado quando já cadastrado.");

					entrada = value;
				}
			}
		}

        /// <summary>
        /// Constrói um itemsaida a partir de dados já adquiridos.
        /// </summary>
        public HistóricoEntradaItem(Entrada saída, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
            : base(mercadoria, quantidade, data, funcionário, índice)
        {
            this.entrada = saída;
        }
    }
}
