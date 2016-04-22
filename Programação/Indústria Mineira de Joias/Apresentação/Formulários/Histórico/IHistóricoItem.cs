using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Apresentação.Formulários.Histórico
{
    public interface IHistóricoItem
    {
        /// <summary>
        /// Momento de registro do item do histórico.
        /// </summary>
        DateTime Registro { get; }

        /// <summary>
        /// Nome do autor do item do histórico.
        /// </summary>
        string Autor { get; }

        /// <summary>
        /// Localização do objeto.
        /// </summary>
        RectangleF Localização { get; set; }

        /// <summary>
        /// Largura do item.
        /// </summary>
        float Largura { get; set; }

        /// <summary>
        /// Altura do item.
        /// </summary>
        float Altura { get; }

        /// <summary>
        /// Posição do item.
        /// </summary>
        PointF Posição { get; set; }

        /// <summary>
        /// Desenha o item de histórico.
        /// </summary>
        void Desenhar(Graphics g);
    }
}
