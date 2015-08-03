using Acesso.Comum;
using Entidades.Relacionamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    [Serializable]
    public class HistóricoRelacionamentoEntrada : HistóricoRelacionamento
    {
        [DbAtributo(TipoAtributo.Ignorar)]
		private Entrada entrada;

		public Entrada Entrada
		{
			get { return entrada; }
		}

        /// <summary>
		/// Constrói uma coleção de ItemSaída.
		/// </summary>
		/// <param name="saída">Documento de saída original.</param>
		public HistóricoRelacionamentoEntrada(Entrada entrada) : base(entrada)
		{
            this.entrada = entrada;
		}

        protected override string Tabela
        {
            get { return "entradaitem"; }
        }

        protected override string TabelaPai
        {
            get { return "entrada"; }
        }

        protected override HistóricoRelacionamentoItem ConstruirItemHistórico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
        {
            return new HistóricoEntradaItem(entrada, mercadoria, quantidade, data, funcionário, índice);
        }
    }
}
