using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio
{
    [global::System.Serializable]
    public class ReferenciaIncorretaException : Exception
    {
        public ReferenciaIncorretaException() : base("Referência incorreta.") { }
        public ReferenciaIncorretaException(string referencia) : base(string.Format("Referência \"{0}\" incorreta.", referencia)) { }
        public ReferenciaIncorretaException(string message, Exception inner) : base(message, inner) { }
        protected ReferenciaIncorretaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
