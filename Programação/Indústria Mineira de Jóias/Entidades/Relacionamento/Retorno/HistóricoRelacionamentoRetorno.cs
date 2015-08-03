using System;
using System.Collections;
using Entidades.Relacionamento;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades.Relacionamento.Retorno
{
    /// <summary>
    /// Cole��o de ItemRetorno
    /// Trata-se de um ArrayList personalizado.
    /// Um Entidades.Retorno cont�m um objeto Cole��oItemRetorno
    /// </summary>
    [Serializable]
    public class Hist�ricoRelacionamentoRetorno : Hist�ricoRelacionamento
    {
        [DbAtributo(TipoAtributo.Ignorar)]
        private Retorno retorno;

        public Retorno Retorno
        {
            get { return retorno; }
        }

        /// <summary>
        /// Constr�i uma cole��o de ItemRetorno.
        /// </summary>
        /// <param name="retorno">Documento de retorno original.</param>
        public Hist�ricoRelacionamentoRetorno(Retorno retorno)
            : base(retorno)
        {
            this.retorno = retorno;
        }

        protected override string Tabela
        {
            get { return "retornoitem"; }
        }

        protected override string TabelaPai
        {
            get { return "retorno"; }
        }

        protected override Hist�ricoRelacionamentoItem ConstruirItemHist�rico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcion�rio funcion�rio, double �ndice)
        {
            return new Hist�ricoRetornoItem(retorno, mercadoria, quantidade, data, funcion�rio, �ndice);
        }

        //protected override SaquinhoRelacionamento ConstuirItemAgrupado(Mercadoria mercadoria, double quantidade, double �ndice)
        //{
        //    return new SaquinhoRelacionamento(mercadoria, quantidade, �ndice);
        //}
    }
}
