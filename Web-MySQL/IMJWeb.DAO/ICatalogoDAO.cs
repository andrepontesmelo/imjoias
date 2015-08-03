using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO
{
    public interface ICatalogoDAO : IDAO<ICatalogo, long>
    {
        /// <summary>
        /// Lista os catálogos disponíveis.
        /// </summary>
        /// <returns>Catálogos disponíveis</returns>
        IEnumerable<ICatalogo> Listar();

        /// <summary>
        /// Obtém catálogo a partir do identificador do catálogo local.
        /// </summary>
        /// <param name="identificadorIMJ">Identificador local da IMJ.</param>
        /// <returns>Catálogo.</returns>
        ICatalogo ObterPorAlbum(long identificadorIMJ);

        /// <summary>
        /// Obtém as referências de um álbum.
        /// </summary>
        /// <param name="album">Identificador do álbum da IMJ.</param>
        /// <returns>Lista de referências.</returns>
        IList<string> ObterReferencias(long album);

        /// <summary>
        /// Obtém os álbuns exclusivos para usuários autenticados.
        /// </summary>
        /// <returns>Lista de álbuns exclusivos.</returns>
        IEnumerable<long> ListarAlbunsExclusivos();
    }
}
