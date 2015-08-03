using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.Servico.Catalogo
{
    [global::System.Serializable]
    public class AcessoNegadoException : Exception
    {
        public AcessoNegadoException() { }
        public AcessoNegadoException(Referencia referencia) : base(string.Format("Acesso negado à mercadoria {0}.", referencia)) { }
        public AcessoNegadoException(string message) : base(message) { }
        public AcessoNegadoException(string message, Exception inner) : base(message, inner) { }
        protected AcessoNegadoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
