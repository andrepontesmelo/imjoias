using System;
using Entidades.Relacionamento;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Relacionamento.Venda
{
    [Serializable]
	public class HistóricoRelacionamentoVenda : HistóricoRelacionamento 
	{
        private Venda venda;

		public HistóricoRelacionamentoVenda(Venda pai)  : base(pai)
		{
            venda = pai;
        }

        protected override string Tabela
        {
            get { return "vendaitem"; }
        }

        protected override string TabelaPai
        {
            get { return "venda"; }
        }

        protected override HistóricoRelacionamentoItem ConstruirItemHistórico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
        {
            return new HistóricoVendaItem(mercadoria, quantidade, venda, data, funcionário, índice);
        }

        protected override SaquinhoRelacionamento ConstuirItemAgrupado(Mercadoria.Mercadoria mercadoria, double quantidade, double índice)
        {
            return new SaquinhoVenda(venda, mercadoria, quantidade, índice);
        }

        public override HistóricoRelacionamentoItem Relacionar(Mercadoria.Mercadoria m, double quantidade, double índice)
        {
            if (!venda.Cadastrado)
                venda.Cadastrar();
            else
                venda.Atualizar();

            HistóricoRelacionamentoItem resultado = base.Relacionar(m, quantidade, índice);
            
            venda.CalcularValor();

            return resultado;
        }
    }
}
