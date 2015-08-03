using System;
using Acesso.Comum;
using Entidades.Relacionamento;
using System.Data;

namespace Entidades.Relacionamento.Venda
{
    [Serializable, DbTabela("vendaitem")]
    public class HistóricoVendaItem : HistóricoRelacionamentoItem
	{
        [DbRelacionamento(true, "codigo", "venda")]
        private Venda venda;

		public HistóricoVendaItem(Entidades.Mercadoria.Mercadoria mercadoria, double qtd, Venda venda, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice) : base(mercadoria, qtd, data, funcionário, índice)
		{
            this.venda = venda;
		}
	}
}