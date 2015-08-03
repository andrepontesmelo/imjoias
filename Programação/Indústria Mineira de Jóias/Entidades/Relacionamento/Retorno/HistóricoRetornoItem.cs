using System;
using System.Data;
using System.Collections;
using Entidades.Relacionamento;
using Acesso.Comum;

namespace Entidades.Relacionamento.Retorno
{
    /// <summary>
    /// Item da cole��o Cole��oItemRetorno
    /// </summary>
    [Serializable, DbTabela("retornoitem")]
    public class Hist�ricoRetornoItem : Hist�ricoRelacionamentoItem
    {
        // Atributos
        [DbRelacionamento(true, "codigo", "retorno")]
        private Retorno retorno;

        public Hist�ricoRetornoItem(Retorno retorno, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcion�rio funcion�rio, double �ndice)
            : base(mercadoria, quantidade, data, funcion�rio, �ndice)
        {
            this.retorno = retorno;
        }

    }
}
