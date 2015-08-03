using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO
{
    public interface IUsuarioDAO : IDAO<IUsuario, long>
    {
        /// <summary>
        /// Obtém usuário a partir de seu login.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <returns>Usuário.</returns>
        IUsuario ObterPorLogin(string login);

        /// <summary>
        /// Lista os usuários cadastrados.
        /// </summary>
        /// <returns>Usuários cadastrados.</returns>
        IEnumerable<IUsuario> Listar();

        /// <summary>
        /// Registra o login do usuário.
        /// </summary>
        /// <param name="usuario">Usuário que efetuou o login.</param>
        void RegistrarLogin(IUsuario usuario);
    }
}
