using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Servico.Usuario
{
    [global::System.Serializable]
    public class SenhaInvalidaException : Exception
    {
        public string LoginUsuario { get; set; }

        public SenhaInvalidaException() { }
        public SenhaInvalidaException(string loginUsuario)
            : base(string.Format("Senha inválida para usuário \"{0}\".", loginUsuario))
        {
            this.LoginUsuario = loginUsuario;
        }
        public SenhaInvalidaException(string message, Exception inner) : base(message, inner) { }
        protected SenhaInvalidaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
