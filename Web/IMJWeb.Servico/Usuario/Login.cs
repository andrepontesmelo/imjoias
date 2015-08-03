using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.DAO;
using IMJWeb.Dominio;
using System.Threading;
using System.Security.Principal;
using IMJWeb.Dominio.Util;
using Microsoft.Practices.Unity;

namespace IMJWeb.Servico.Usuario
{
    /// <summary>
    /// Serviço para efetuação de login do usuário.
    /// </summary>
    public class Login
    {
        [Dependency]
        public IUsuarioDAO UsuarioDAO { get; set; }

        /// <summary>
        /// Efetua login de um usuário.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <param name="senha">Senha fornecida.</param>
        /// <exception cref="IMJWeb.Servico.Usuario.UsuarioNaoEncontradoException">
        /// Login do usuário não encontrado.
        /// </exception>
        /// <exception cref="IMJWeb.Servico.Usuario.SenhaInvalidaException">
        /// Senha fornecida não é válida.
        /// </exception>
        public IUsuario EfetuarLogin(string login, string senha)
        {
            IUsuario usuario = UsuarioDAO.ObterPorLogin(login);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException(login);

            if (!usuario.ValidarSenha(senha))
                throw new SenhaInvalidaException(login);

            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity(login),
                new string[] { });

            return usuario;
        }

        /// <summary>
        /// Obtém o usuário atual.
        /// </summary>
        /// <returns>Usuário atual.</returns>
        [Obsolete("Utilize Session.ObterUsuarioAtual()", true)]
        public IUsuario ObterUsuarioAtual()
        {
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
                return null;

            return UsuarioDAO.ObterPorLogin(Thread.CurrentPrincipal.Identity.Name);
        }
    }
}
