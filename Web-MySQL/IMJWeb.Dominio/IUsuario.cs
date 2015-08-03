using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio
{
    /// <summary>
    /// Usuário do sistema.
    /// </summary>
    public interface IUsuario
    {
        /// <summary>
        /// Identificador do usuário.
        /// </summary>
        long IDUsuario { get; }

        /// <summary>
        /// Código do usuário para acesso ao sistema.
        /// </summary>
        string Login { get; }
        
        /// <summary>
        /// Senha do usuário.
        /// </summary>
        string Senha { set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        string Nome { get; }

        /// <summary>
        /// E-Mail do usuário.
        /// </summary>
        string EMail { get; }

        /// <summary>
        /// Tabela do usuário.
        /// </summary>
        ITabela Tabela { get; }

        /// <summary>
        /// Identificador do cliente no sistema da IMJ.
        /// </summary>
        long? IMJ_IDPessoa { get; }

        /// <summary>
        /// Verifica se a senha do usuário está correta.
        /// </summary>
        /// <param name="senha">Senha a ser verificada.</param>
        /// <returns>Verdadeiro se a senha estiver correta.</returns>
        bool ValidarSenha(string senha);

        /// <summary>
        /// Determina se o usuário é administrador.
        /// </summary>
        bool Administrador { get; }

        /// <summary>
        /// Último acesso do usuário.
        /// </summary>
        DateTime? UltimoAcesso { get; set; }
    }
}
