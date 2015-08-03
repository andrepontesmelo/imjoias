using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IMJWeb.Dominio
{
    /// <summary>
    /// Mercadoria exposta na Internet.
    /// </summary>
    public interface IMercadoria
    {
        /// <summary>
        /// Referência da mercadoria.
        /// </summary>
        Referencia Referencia { get; set; }

        /// <summary>
        /// Descrição da mercadoria.
        /// </summary>
        string Descricao { get; set; }

        /// <summary>
        /// Peso da mercadoria.
        /// </summary>
        decimal? Peso { get; set; }

        /// <summary>
        /// Fotos da mercadoria.
        /// </summary>
        ICollection<IFoto> Fotos { get; }

        /// <summary>
        /// Índices.
        /// </summary>
        ICollection<IIndice> Indices { get; }

        /// <summary>
        /// Catálogo.
        /// </summary>
        ICatalogo Catalogo { get; set; }

        /// <summary>
        /// Determina se a mercadoria é exclusiva para usuários autenticados.
        /// </summary>
        bool Exclusiva { get; set; }

        /// <summary>
        /// Obtém a foto mais apropriada para a largura e altura desejada.
        /// </summary>
        /// <param name="largura">Largura desejada.</param>
        /// <param name="altura">Altura desejada.</param>
        /// <returns>Foto mais apropriada.</returns>
        IFoto ObterFoto(int largura, int altura);

        /// <summary>
        /// Verifica se o acesso ao usuário é permitido.
        /// </summary>
        /// <param name="usuario">Usuário cujo acesso será verificado.</param>
        /// <returns>Verdadeiro se usuário pode visualizar o catálogo.</returns>
        bool PermiteAcesso(IUsuario usuario);

        /// <summary>
        /// Obtém o índice para o usuário.
        /// </summary>
        /// <param name="usuario">Usuário cujo índice será calculado.</param>
        /// <returns>Índice para o tipo de cliente do usuário.</returns>
        /// <remarks>
        /// O valor do índice da mercadoria varia de acordo a região do cliente,
        /// que define seu tipo (varejo, atacado, alto-atacado) e se a mercadoria
        /// é pesada ("de peso") ou não no momento da venda.
        /// </remarks>
        decimal? ObterIndice(IUsuario usuario);
    }
}
