using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Relacionamento;

namespace Entidades.Relacionamento.Venda
{
    [Serializable]
    public class HistóricoRelacionamentoDevolução : HistóricoRelacionamento
    {
        private Venda venda;

        public HistóricoRelacionamentoDevolução(Venda pai) : base(pai)
        {
            this.venda = pai;
        }

        protected override string Tabela
        {
            get { return "vendadevolucao"; }
        }

        protected override string TabelaPai
        {
            get { return "venda"; }
        }

        protected override HistóricoRelacionamentoItem ConstruirItemHistórico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
        {
            return new HistóricoDevoluçãoItem(mercadoria, quantidade, venda, data, funcionário, índice);
        }

        protected override SaquinhoRelacionamento ConstuirItemAgrupado(Mercadoria.Mercadoria mercadoria, double quantidade, double índice)
        {
            return new SaquinhoDevolução(venda, mercadoria, quantidade, índice);
        }

        public override HistóricoRelacionamentoItem Relacionar(Mercadoria.Mercadoria m, double quantidade, double índice)
        {
            if (!venda.Cadastrado)
                venda.Cadastrar();
            else
            {
                // Toda vez que a venda é alterada, seu valor vai para nulo.
                //venda.DefinirValorTotalNulo();
                venda.Atualizar();
            }

            return base.Relacionar(m, quantidade, índice);
        }
    }
}
