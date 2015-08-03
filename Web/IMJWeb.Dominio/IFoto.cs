using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IMJWeb.Dominio
{
    public interface IFoto
    {
        /// <summary>
        /// Referência da mercadoria.
        /// </summary>
        IMercadoria Mercadoria { get; }

        /// <summary>
        /// Identificador da foto.
        /// </summary>
        long IDFoto { get; set; }

        /// <summary>
        /// Foto da mercadoria.
        /// </summary>
        Image Imagem { get; set; }

        /// <summary>
        /// Identificador da foto no sistema da IMJ.
        /// </summary>
        long? IMJ_IDFoto { get; set; }

        /// <summary>
        /// Largura da imagem.
        /// </summary>
        int Largura { get; set; }

        /// <summary>
        /// Altura da imagem.
        /// </summary>
        int Altura { get; set; }
    }
}
