using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio.Especificacao.AcessoUsuario
{
    /// <summary>
    /// Implementa a especificação para validação de acesso
    /// ao usuário.
    /// </summary>
    public interface IValidadorAcessoUsuario<TENTIDADE>
    {
        /// <summary>
        /// Verifica se o acesso do usuário a uma entidade é permitido.
        /// </summary>
        /// <param name="entidade">Entidade cujo acesso será verificado.</param>
        /// <param name="usuario">Usuário cujo acesso será verificado.</param>
        /// <returns>Verdadeiro se usuário pode visualizar o catálogo.</returns>
        bool PermiteAcesso(TENTIDADE entidade, IUsuario usuario);
    }
}
