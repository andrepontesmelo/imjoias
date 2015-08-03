using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using IMJWeb.Dominio.Especificacao.AcessoUsuario;
using System.Diagnostics;

namespace IMJWeb.DAO.EF.Especificacao
{
    /// <summary>
    /// Implementa a especificação para validação de acesso
    /// ao usuário.
    /// </summary>
    public class ValidadorAcessoUsuarioMercadoria : IValidadorAcessoUsuario<IMercadoria>
    {
        /// <summary>
        /// Verifica se o acesso do usuário a uma entidade é permitido.
        /// </summary>
        /// <param name="entidade">Entidade cujo acesso será verificado.</param>
        /// <param name="usuario">Usuário cujo acesso será verificado.</param>
        /// <returns>Verdadeiro se usuário pode visualizar o catálogo.</returns>
        public bool PermiteAcesso(IMercadoria entidade, IUsuario usuario)
        {
            if (entidade == null)
                throw new ArgumentNullException("entidade");

            if (entidade is Mercadoria)
                return ValidadorAcessoUsuarioMercadoria.PermiteAcesso(entidade.ParaEF(), usuario != null ? usuario.ParaEF() : null);
            else
            {
                using (MercadoriaDAO dao = new MercadoriaDAO())
                {
                    var mercadoria = dao.Obter(entidade.Referencia);
                    
                    return ValidadorAcessoUsuarioMercadoria.PermiteAcesso((Mercadoria)mercadoria, usuario != null ? usuario.ParaEF() : null);
                }
            }

        }

        private static bool PermiteAcesso(Mercadoria mercadoria, Usuario usuario)
        {
            if (!mercadoria.CatalogoReference.IsLoaded)
                mercadoria.CatalogoReference.Load();

            if (!mercadoria.Catalogo.PermiteAcesso(usuario))
            {
                Debug.Print("Negando acesso à mercadoria {0} pois usuário não possui acesso ao catálogo.", mercadoria);
                return false;
            }

            if (mercadoria.Exclusiva && usuario == null)
            {
                Debug.Print("Negando acesso à mercadoria exclusiva {0} para usuário não identificado.", mercadoria);
                return false;
            }

            if (!mercadoria.Grupos.IsLoaded)
                mercadoria.Grupos.Load();

            if (mercadoria.Grupos.Count == 0)
            {
                Debug.Print("Liberando acesso à entidade {0} para o usuário {1} (não há grupos).", mercadoria, usuario); 
                return true;
            }

            if (usuario == null)
            {
                Debug.Print("Negando acesso à entidade {0} para usuário não identificado.", mercadoria);
                return false;
            }

            if (!usuario.Grupos.IsLoaded)
                usuario.Grupos.Load();

            Debug.Print("Verificando acesso à entidade {0} para o usuário {1}.", mercadoria, usuario);

            return mercadoria.Grupos.Select(g => g.IDGrupo).Intersect(usuario.Grupos.Select(g => g.IDGrupo)).Count() > 0;
        }
    }
}
