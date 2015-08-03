using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Servico.Usuario
{
    [global::System.Serializable]
    public class UsuarioNaoEncontradoException : Exception
    {
        public UsuarioNaoEncontradoException() { }
        public UsuarioNaoEncontradoException(string login) : base(string.Format("Usuário \"{0}\" não encontrado.", login)) { }
        public UsuarioNaoEncontradoException(string message, Exception inner) : base(message, inner) { }
        protected UsuarioNaoEncontradoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
