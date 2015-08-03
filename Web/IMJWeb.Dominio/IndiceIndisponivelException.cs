using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio
{
    /// <summary>
    /// Índice de uma mercadoria não está disponível.
    /// </summary>
    [global::System.Serializable]
    public class IndiceIndisponivelException : Exception
    {
        public IndiceIndisponivelException() { }
        public IndiceIndisponivelException(Referencia referencia) : base(string.Format("Índice indisponível para mercadoria {0}.", referencia)) { }
        public IndiceIndisponivelException(Referencia referencia, ITabela tabela) : base(string.Format("Índice indisponível para mercadoria {0} e tabela {1}.", referencia, tabela.IDTabela)) { }
        public IndiceIndisponivelException(string message) : base(message) { }
        public IndiceIndisponivelException(string message, Exception inner) : base(message, inner) { }
        protected IndiceIndisponivelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
