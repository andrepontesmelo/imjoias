using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio.Especificacao.AcessoUsuario;
using Microsoft.Practices.Unity;

namespace IMJWeb.Dominio.Util
{
    public static class FabricaValidadorAcessoUsuario
    {
        /// <summary>
        /// Obtém objeto flyweight para validação de acesso ao usuário.
        /// </summary>
        /// <returns>Objeto para validação de acesso do usuário a um catálogo.</returns>
        public static IValidadorAcessoUsuario<TENTIDADE> Criar<TENTIDADE>()
        {
            return InjecaoDependencia.Resolver<IValidadorAcessoUsuario<TENTIDADE>>(string.Format("ValidadorAcessoUsuario[{0}]", typeof(TENTIDADE).Name));
        }
    }
}
