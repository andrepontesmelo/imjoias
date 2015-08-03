using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace IMJWeb.DAO.EF
{
    partial class Foto : IFoto
    {
        private Image fotoImagem;

        Image IFoto.Imagem
        {
            get
            {
                lock (this)
                {
                    if (fotoImagem == null)
                    {
                        using (var stream = new MemoryStream(this.Imagem))
                        {
                            fotoImagem = Image.FromStream(stream);
                        }
                    }

                    return fotoImagem;
                }
            }
            set
            {
                lock (this)
                {
                    fotoImagem = value;

                    try
                    {
                        using (var stream = new MemoryStream())
                        {
                            value.Save(stream, ImageFormat.Png);
                            this.Imagem = stream.ToArray();
                        }
                    }
                    catch
                    {
                        using (Bitmap bmp = new Bitmap(value))
                        {
                            using (var stream = new MemoryStream())
                            {
                                value.Save(stream, ImageFormat.Png);
                                this.Imagem = stream.ToArray();
                            }
                        }
                    }
                }
            }
        }
    }
}
