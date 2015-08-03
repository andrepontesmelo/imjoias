using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using IMJWeb.DAO;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System.Threading;
using System.Security.Permissions;
using IMJWeb.Dominio;
using IMJWeb.Servico.Usuario;
using System.Security;
using IMJWeb.Servico.Catalogo.TO;
using System.Diagnostics;

namespace IMJWeb.Servico.Catalogo
{
    public class Catalogos : IDisposable
    {
        [Dependency]
        public ICatalogoDAO CatalogoDAO { get; set; }

        /// <summary>
        /// Lista os catálogos disponíveis para o usuário atual.
        /// </summary>
        /// <returns>Lista de catálogos disponíveis para o usuário atual.</returns>
        public IDictionary<long, string> ListarCatalogos(IUsuario usuario)
        {
            IEnumerable<ICatalogo> catalogos;

            catalogos = CatalogoDAO.Listar();
            catalogos = catalogos.Where(c => c.PermiteAcesso(usuario));

            var dic = catalogos.ToDictionary(c => c.IDCatalogo, c => c.Nome);

            CatalogoNovidades novidades = CatalogoNovidades.Instancia;

            if (novidades.PermiteAcesso(usuario))
                dic.Add(novidades.IDCatalogo, novidades.Nome);

            return dic;
        }

        /// <summary>
        /// Obtém um catálogo a partir de seu identificador.
        /// </summary>
        /// <param name="idCatalogo">Identificador do catálogo.</param>
        /// <returns>Catálogo.</returns>
        public ICatalogo ObterCatalogo(IUsuario usuario, long idCatalogo)
        {
            if (idCatalogo >= 0)
            {
                var catalogo = CatalogoDAO.Obter(idCatalogo);

                if (catalogo == null)
                    throw new NullReferenceException(string.Format("Catálogo {0} não encontrado.", idCatalogo));

                if (!catalogo.PermiteAcesso(usuario))
                    throw new SecurityException("Acesso negado ao catálogo.");

                return catalogo;
            }

            if (idCatalogo == CatalogoNovidades.Instancia.IDCatalogo)
            {
                return CatalogoNovidades.Instancia;
            }

            throw new ArgumentOutOfRangeException("idCatalogo");
        }

        /// <summary>
        /// Obtém os álbuns vinculados aos catálogos.
        /// </summary>
        /// <returns>Álbuns.</returns>
        public long[] ObterAlbuns()
        {
            var catalogos = from c in CatalogoDAO.Listar()
                            where c.IMJ_IDAlbum.HasValue
                            select c.IMJ_IDAlbum.Value;

            var exclusivos = CatalogoDAO.ListarAlbunsExclusivos();

            return catalogos.Union(exclusivos).ToArray();
        }

        #region IDisposable Members

        public void Dispose()
        {
            CatalogoDAO.Dispose();
        }

        #endregion

        public ICatalogo ObterNovidades()
        {
            return CatalogoNovidades.Instancia;
        }
    }
}
