using System;
using System.Collections;
using Entidades.Relacionamento;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades.Relacionamento.Retorno
{
    /// <summary>
    /// Coleção de ItemRetorno
    /// Trata-se de um ArrayList personalizado.
    /// Um Entidades.Retorno contém um objeto ColeçãoItemRetorno
    /// </summary>
    [Serializable]
    public class HistóricoRelacionamentoRetorno : HistóricoRelacionamento
    {
        [DbAtributo(TipoAtributo.Ignorar)]
        private Retorno retorno;

        public Retorno Retorno
        {
            get { return retorno; }
        }

        /// <summary>
        /// Constrói uma coleção de ItemRetorno.
        /// </summary>
        /// <param name="retorno">Documento de retorno original.</param>
        public HistóricoRelacionamentoRetorno(Retorno retorno)
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

        protected override HistóricoRelacionamentoItem ConstruirItemHistórico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
        {
            return new HistóricoRetornoItem(retorno, mercadoria, quantidade, data, funcionário, índice);
        }

        //protected override SaquinhoRelacionamento ConstuirItemAgrupado(Mercadoria mercadoria, double quantidade, double índice)
        //{
        //    return new SaquinhoRelacionamento(mercadoria, quantidade, índice);
        //}
    }
}
