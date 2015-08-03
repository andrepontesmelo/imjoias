using System;
using System.Data;
using System.Collections;
using Entidades.Relacionamento;
using Acesso.Comum;

namespace Entidades.Relacionamento.Retorno
{
    /// <summary>
    /// Item da coleção ColeçãoItemRetorno
    /// </summary>
    [Serializable, DbTabela("retornoitem")]
    public class HistóricoRetornoItem : HistóricoRelacionamentoItem
    {
        // Atributos
        [DbRelacionamento(true, "codigo", "retorno")]
        private Retorno retorno;

        public HistóricoRetornoItem(Retorno retorno, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
            : base(mercadoria, quantidade, data, funcionário, índice)
        {
            this.retorno = retorno;
        }

    }
}
