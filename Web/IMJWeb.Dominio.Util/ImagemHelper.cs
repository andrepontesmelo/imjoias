using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IMJWeb.Dominio.Util
{
    public static class ImagemHelper
    {
        /// <summary>
        /// Redimensiona a imagem.
        /// </summary>
        /// <param name="imagemOriginal">Imagem a ser redimensionada.</param>
        /// <param name="largura">Nova largura.</param>
        /// <param name="altura">Nova altura.</param>
        /// <returns>Imagem redimensionada.</returns>
        public static Image Redimensionar(Image imagemOriginal, int largura, int altura)
        {
            Image imagemNova = new Bitmap(largura, altura);

            lock (imagemOriginal)
            {
                using (Graphics g = Graphics.FromImage(imagemNova))
                {
                    g.DrawImage(imagemOriginal, 0, 0, largura, altura);
                }
            }

            return imagemNova;
        }

        /// <summary>
        /// Recorta a imagem.
        /// </summary>
        /// <param name="imagemOriginal">Imagem a ser recortada.</param>
        /// <param name="largura">Largura do recorte.</param>
        /// <param name="altura">Altura do recorte.</param>
        /// <returns>Imagem recortada.</returns>
        public static Image Recortar(Image imagemOriginal, int largura, int altura)
        {
            Image imagemNova = new Bitmap(largura, altura);

            lock (imagemOriginal)
            {
                using (Graphics g = Graphics.FromImage(imagemNova))
                {
                    g.DrawImage(imagemOriginal, new Rectangle(0, 0, largura, altura),
                        (imagemOriginal.Width - largura) / 2, (imagemOriginal.Height - altura) / 2,
                        largura, altura, GraphicsUnit.Pixel);
                }
            }

            return imagemNova;
        }
    }
}
