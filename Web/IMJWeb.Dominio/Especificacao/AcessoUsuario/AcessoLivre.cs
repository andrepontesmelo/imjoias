using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace IMJWeb.Dominio.Especificacao.AcessoUsuario
{
    /// <summary>
    /// Permite acesso livre a uma entidade.
    /// </summary>
    /// <typeparam name="TENTIDADE">Entidade cujo acesso será livre.</typeparam>
    public class AcessoLivre<TENTIDADE> : IValidadorAcessoUsuario<TENTIDADE>
    {
        public bool PermiteAcesso(TENTIDADE entidade, IUsuario usuario)
        {
            Debug.Print("Liberando acesso à entidade {0} para o usuário {1} (acesso livre).", entidade, usuario);

            return true;
        }
    }
}
