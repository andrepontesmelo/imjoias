using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio
{
    /// <summary>
    /// Catálogo de mercadorias exposto na Internet.
    /// </summary>
    public interface ICatalogo
    {
        /// <summary>
        /// Identificador do catálogo.
        /// </summary>
        long IDCatalogo { get; }

        /// <summary>
        /// Descrição do catálogo.
        /// </summary>
        string Nome { get; set;  }

        /// <summary>
        /// Identificador do álbum no sistema da IMJ.
        /// </summary>
        long? IMJ_IDAlbum { get; set; }

        /// <summary>
        /// Verifica se o acesso ao usuário é permitido.
        /// </summary>
        /// <param name="usuario">Usuário cujo acesso será verificado.</param>
        /// <returns>Verdadeiro se usuário pode visualizar o catálogo.</returns>
        bool PermiteAcesso(IUsuario usuario);

        /// <summary>
        /// Mercadorias presentes no catálogo.
        /// </summary>
        IList<IMercadoria> ObterMercadorias(IUsuario usuario);
    }
}
