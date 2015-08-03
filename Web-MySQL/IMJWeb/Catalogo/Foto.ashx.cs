using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using IMJWeb.Servico.Catalogo;
using IMJWeb.Dominio.Util;
using IMJWeb.Dominio;
using IMJWeb.Sessao;
using System.Web.SessionState;

namespace IMJWeb.Catalogo
{
    /// <summary>
    /// Envia a imagem de uma mercadoria.
    /// </summary>
    public class Foto : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            DefinirPoliticaCache(context);

            // Extarir parâmetros da imagem.
            string referencia = context.Request["ref"];
            string strFormato = context.Request["formato"];
            string strLargura = context.Request["largura"];
            string strAltura = context.Request["altura"];
            ImageFormat formato = ImageFormat.Jpeg;
            bool recortar = context.Request["recortar"] != null;

            if (string.IsNullOrEmpty(referencia))
                throw new ArgumentNullException("referencia");

            if (string.IsNullOrEmpty(strLargura))
                strLargura = "608"; // throw new ArgumentNullException("largura");

            if (string.IsNullOrEmpty(strAltura))
                strAltura = "471"; // throw new ArgumentNullException("altura");      

            if (!string.IsNullOrEmpty(strFormato))
            {
                switch (strFormato.ToLowerInvariant())
                {
                    case "gif":
                        formato = ImageFormat.Gif;
                        break;

                    case "jpeg":
                        formato = ImageFormat.Jpeg;
                        break;

                    case "png":
                        formato = ImageFormat.Png;
                        break;

                    default:
                        throw new ArgumentException("formato");
                }
            }

            if (formato == ImageFormat.Png && context.Request.Browser.IsBrowser("IE") && context.Request.Browser.MajorVersion == 6)
                formato = ImageFormat.Jpeg;

            Processar(context, referencia, formato, int.Parse(strLargura), int.Parse(strAltura), recortar);
        }

        /// <summary>
        /// Processa mercadoria a partir de seu identificador.
        /// </summary>
        /// <param name="context">Contexto da requisição.</param>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <param name="formato">Formato da imagem.</param>
        /// <param name="largura">Largura desejada para a imagem.</param>
        /// <param name="altura">Altura desejada para a imagem.</param>
        private void Processar(HttpContext context, string referencia, ImageFormat formato, int largura, int altura, bool recortar)
        {
            if (largura <= 16)
                throw new ArgumentException("Largura muito pequena", "largura");

            if (altura <= 16)
                throw new ArgumentException("Largura muito pequena", "largura");

            try
            {
                using (Mercadorias svc = InjecaoDependencia.Resolver<Mercadorias>())
                {
                    var mercadoria = svc.ObterMercadoria(context.Session.ObterUsuarioAtual(), referencia);

                    if (mercadoria == null)
                        ResponderNaoEncontrada(context);
                    else
                    {
                        var foto = svc.ObterFoto(mercadoria, largura, altura);

                        if (foto == null)
                            ResponderNaoEncontrada(context);
                        else
                        {
                            Image imagem;

                            if (recortar)
                                imagem = ImagemHelper.Recortar(foto.Imagem, largura, altura);
                            else
                            {
                                Image imgOriginal = foto.Imagem;

                                lock (imgOriginal)
                                    imagem = new Bitmap(imgOriginal);
                            }

                            ResponderImagem(context, imagem, formato);

                            if (recortar)
                                svc.ContabilizarHitMiniatura(referencia);
                        }
                    }
                }
            }
            catch (AcessoNegadoException)
            {
                ResponderNaoEncontrada(context);
            }
        }

        /// <summary>
        /// Escreve a resposta em JPEG da imagem.
        /// </summary>
        /// <param name="imagem">Imagem a ser enviada na resposta.</param>
        private static void ResponderImagem(HttpContext context, Image imagem, ImageFormat formato)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Verificar navegador...
                if (context.Request.Browser.Browser == "IE" && context.Request.Browser.MajorVersion <= 6)
                {
                    // ...e enviar como JPEG, visto que PNG não é suportado.
                    if (formato == ImageFormat.Png)
                        formato = ImageFormat.Jpeg;
                }

                if (formato != ImageFormat.Png && imagem.RawFormat != ImageFormat.Jpeg)
                {
                    // Remover transparência.
                    using (Bitmap novaImagem = new Bitmap(imagem.Width, imagem.Height))
                    {
                        using (Graphics g = Graphics.FromImage(novaImagem))
                        {
                            g.Clear(Color.White);
                            g.DrawImage(imagem, 0, 0, novaImagem.Width, novaImagem.Height);
                        }

                        novaImagem.Save(stream, formato);
                    }
                }
                else
                    imagem.Save(stream, formato);

                if (formato == ImageFormat.Jpeg)
                    context.Response.ContentType = "image/jpeg";

                else if (formato == ImageFormat.Gif)
                    context.Response.ContentType = "image/gif";

                else if (formato == ImageFormat.Png)
                    context.Response.ContentType = "image/png";

                else
                    throw new NotSupportedException();

                context.Response.BinaryWrite(stream.ToArray());
            }
        }

        /// <summary>
        /// Define a política de cache para respostas de foto de mercadorias.
        /// </summary>
        private static void DefinirPoliticaCache(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetExpires(DateTime.Now.AddDays(7));
            context.Response.Cache.SetValidUntilExpires(true);
        }

        /// <summary>
        /// Responde ao cliente que a foto não foi encontrada.
        /// </summary>
        private static void ResponderNaoEncontrada(HttpContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.StatusDescription = "A foto requisitada não foi encontrada.";
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}