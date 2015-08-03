using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.IO;
using Entidades.Álbum;

namespace Portal
{
    public partial class ObterFoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Drawing.Image imagem;
            byte[] imagemBytes;
            double peso;

            AcessoBD.AssegurarConectado();
            string referencia = Request.QueryString["ref"];
            Entidades.Mercadoria.Mercadoria m = Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia, Entidades.Tabela.TabelaPadrão);

            if (Request.QueryString["peso"] != null)
            {
                double.TryParse((string) Request.QueryString["peso"], out peso);
                m.Peso = peso;
            }

            Entidades.Álbum.Ícone icone = 
            Entidades.Álbum.Ícone.ObterÍcone(referencia, null);

            if (icone == null)
                return;

            imagemBytes = icone.Dados;

            //Foto[] fotos = 
            //    Entidades.Álbum.Foto.ObterFotos(m);

            //if ((fotos == null) || (fotos.Length == 0)) return;

            //imagem = fotos[0].Imagem;

            //System.System.Drawing.Image imagem = new Bitmap(900, 600);
            //Graphics grafico = Graphics.FromImage(imagem);
            //grafico.Clear(Color.White);

            //// TODO : Utilizar Redimensionar(largura maxima, altura maxima)
            //grafico.DrawString("Ciência da Computação", new Font("arial", 25), Brushes.Black, new PointF(380, 50));
            
            //// Gera Stream
            //MemoryStream stream = new MemoryStream();
            //imagem.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            
            //imageBytes = new Byte[stream.Length];
            //stream.Position = 0;
            //stream.Read(imagemBytes, 0, (int)stream.Length);
            
            // Retorna a imagem
            // string nomeArquivo = "cartazHardCoded";

            Response.ClearHeaders();
            Response.ContentType = "image/jpeg";
            Response.Clear();
            //Response.AppendHeader("Content-Disposition", "attachment;Filename=" + nomeArquivo + ".jpg");
            Response.BinaryWrite(imagemBytes);
        }
    }
}
