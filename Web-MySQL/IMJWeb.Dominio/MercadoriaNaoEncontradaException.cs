using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio
{
    [global::System.Serializable]
    public class MercadoriaNaoEncontradaException : Exception
    {
        public MercadoriaNaoEncontradaException() { }
        public MercadoriaNaoEncontradaException(long idMercadoria) : base(string.Format("Mercadoria de identificador {0} não encontrada.", idMercadoria)) { }
        public MercadoriaNaoEncontradaException(Referencia referencia) : base(string.Format("Mercadoria de referência {0} não encontrada.", referencia.ValorFormatado)) { }
        public MercadoriaNaoEncontradaException(string message) : base(message) { }
        public MercadoriaNaoEncontradaException(string message, Exception inner) : base(message, inner) { }
        protected MercadoriaNaoEncontradaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
