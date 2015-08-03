using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO.EF
{
    public class CatalogoDAO : BaseDAO<ICatalogo, Catalogo, long>, ICatalogoDAO
    {
        protected override void Anexar(object entidade)
        {
            Modelo.AttachTo("Catalogos", entidade);
        }

        public override ICatalogo Incluir(ICatalogo entidade)
        {
            var ef = entidade.ParaEF();

            Modelo.AddToCatalogos(ef);
            Modelo.SaveChanges();

            return ef;
        }

        public override ICatalogo Obter(long identificador)
        {
            return Modelo.Catalogos.Include("Mercadorias").Include("Mercadorias.Grupos").FirstOrDefault(c => c.IDCatalogo == identificador);
        }

        /// <summary>
        /// Lista os catálogos disponíveis.
        /// </summary>
        /// <returns>Catálogos disponíveis</returns>
        public IEnumerable<ICatalogo> Listar()
        {
            return Modelo.Catalogos.ToList().ConvertAll<ICatalogo>(c => c);
        }

        public IEnumerable<long> ListarAlbunsExclusivos()
        {
            return Modelo.CatalogosExclusivos.Select(c => c.IDAlbum_IMJ);
        }

        /// <summary>
        /// Obtém catálogo a partir do identificador do catálogo local.
        /// </summary>
        /// <param name="idAlbum">Identificador local da IMJ.</param>
        /// <returns>Catálogo.</returns>
        public ICatalogo ObterPorAlbum(long idAlbum)
        {
            var catalogo = Modelo.Catalogos.FirstOrDefault(c => c.IMJ_IDAlbum == idAlbum);

            if (catalogo == null)
                catalogo = (from ce in Modelo.CatalogosExclusivos
                            where ce.IDAlbum_IMJ == idAlbum
                            select ce.Catalogo).FirstOrDefault();

            return catalogo;
        }

        /// <summary>
        /// Obtém as referências de um álbum.
        /// </summary>
        /// <param name="album">Identificador do álbum da IMJ.</param>
        /// <returns>Lista de referências.</returns>
        public IList<string> ObterReferencias(long album)
        {
            var q = from m in Modelo.Mercadorias
                    where m.Catalogo.IMJ_IDAlbum.Value == album
                    select m.Referencia;

            return q.ToArray();
        }
    }
}
