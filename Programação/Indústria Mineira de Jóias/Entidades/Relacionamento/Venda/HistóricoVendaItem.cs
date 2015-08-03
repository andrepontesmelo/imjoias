using System;
using Acesso.Comum;
using Entidades.Relacionamento;
using System.Data;

namespace Entidades.Relacionamento.Venda
{
    [Serializable, DbTabela("vendaitem")]
    public class Hist�ricoVendaItem : Hist�ricoRelacionamentoItem
	{
        [DbRelacionamento(true, "codigo", "venda")]
        private Venda venda;

		public Hist�ricoVendaItem(Entidades.Mercadoria.Mercadoria mercadoria, double qtd, Venda venda, DateTime data, Entidades.Pessoa.Funcion�rio funcion�rio, double �ndice) : base(mercadoria, qtd, data, funcion�rio, �ndice)
		{
            this.venda = venda;
		}
	}
}