using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Servico.Usuario
{
    [global::System.Serializable]
    public class EmailIncorretoException : Exception
    {
        public EmailIncorretoException() : this("E-mail incorreto.") { }
        public EmailIncorretoException(string message) : base(message) { }
        public EmailIncorretoException(string message, Exception inner) : base(message, inner) { }
        protected EmailIncorretoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
