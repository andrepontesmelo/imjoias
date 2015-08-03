using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using IMJWeb.Dominio;
using System.IO;
using System.Drawing.Imaging;

namespace IMJWeb.DAO.Db4o.Entidades
{
    public class Foto : IFoto
    {
        public long IDFoto { get; set; }

        private byte[] imagem;

        public Image Imagem
        {
            get
            {
                using (MemoryStream stream = new MemoryStream(imagem))
                {
                    return Image.FromStream(stream);
                }
            }
            set
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (Bitmap novaImagem = new Bitmap(value)) {
                        novaImagem.Save(stream, ImageFormat.Png);
                    }

                    imagem = stream.ToArray();
                }
            }
        }

        public long? IMJ_IDFoto { get; set; }

        public int Largura { get; set; }

        public int Altura { get; set; }

        private IMercadoria mercadoria;

        public IMercadoria Mercadoria
        {
            get { return mercadoria; }
            set
            {
                if (value == mercadoria)
                    return;
                
                if (mercadoria != null)
                    mercadoria.Fotos.Remove(this);

                if (value != null && !value.Fotos.Contains(this))
                    value.Fotos.Add(this);

                this.mercadoria = value;
            }
        }

        public Foto(IMercadoria mercadoria)
        {
            this.Mercadoria = mercadoria;
        }
    }
}
