using System;
using System.Text;
using Entidades.Relacionamento;
using System.Data;
using Acesso.Comum;

namespace Entidades.Relacionamento.Venda
{
    [Serializable]
    [DbTabela("vendadevolucao")]
    public class HistóricoDevoluçãoItem : HistóricoRelacionamentoItem
    {
        [DbRelacionamento(true, "codigo", "venda")]
        private Venda venda;

        public HistóricoDevoluçãoItem(Entidades.Mercadoria.Mercadoria mercadoria, double qtd, Venda venda, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice) : base(mercadoria, qtd, data, funcionário, índice)
        {
            this.venda = venda;    
        }

    }
}
