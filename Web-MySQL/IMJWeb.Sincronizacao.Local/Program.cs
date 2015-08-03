using System;
using System.Collections.Generic;
using System.Text;
using IMJWeb.Sincronizacao.Local.Internet;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Net;
using Entidades.Álbum;
using Acesso.Comum;
using Acesso.MySQL;
using Entidades.Mercadoria;
using Entidades;
using System.Drawing;
using System.Drawing.Imaging;

namespace IMJWeb.Sincronizacao.Local
{
    class Program
    {
        private static Sincronizador sincronizador = new Sincronizador();
        static Dictionary<string, ulong> hashMercadoriaAlbum = new Dictionary<string, ulong>();

        static void Main(string[] args)
        {
            DateTime inicio = DateTime.Now;
            CredentialCache credCache = new CredentialCache();
            NetworkCredential netCred = new NetworkCredential("imjlocal", "lKdS9X");
            credCache.Add(new Uri(sincronizador.Url), "Basic", netCred);
            sincronizador.Credentials = credCache;

            System.Net.ServicePointManager.Expect100Continue = false;

            MySQLUsuários usuários = new MySQLUsuários();
            usuários.EfetuarLogin("imjweb", "45ul45hkhjk8");

            Mercadoria.IniciarCarga();

            sincronizador.Timeout = 1000 * 60 * 10;
            sincronizador.EnableDecompression = true;

            SincronizarTodosAlbuns();

            TimeSpan tempo = DateTime.Now - inicio;

            Console.WriteLine("Sincronizado em {0}", tempo.ToString());
        }

        /// <summary>
        /// Sincroniza todos os álbuns.
        /// </summary>
        private static void SincronizarTodosAlbuns()
        {
            Console.WriteLine("Obtendo álbuns...");

            long[] albuns = sincronizador.ObterAlbuns();

            foreach (var codigo in albuns)
            {
                Console.WriteLine("Iterando por código " + codigo);

                Álbum album = Álbum.ObterÁlbum((ulong)codigo);
                SincronizarAlbum(album);
            }

            foreach (var codigo in albuns)
            {
                Álbum album = Álbum.ObterÁlbum((ulong)codigo);
                RemoverMercadoriasAntigas(album);
            }
        }

        private static void RemoverMercadoriasAntigas(Álbum album)
        {
            Console.WriteLine("\n\nRemovendo mercadorias antigas do álbum " + album.Nome);

            List<string> mercadorias;

            mercadorias = new List<string>(sincronizador.ObterMercadorias((long)album.Código));

            foreach (string mercadoria in mercadorias)
                if (!hashMercadoriaAlbum.ContainsKey(mercadoria))
                {
                    Console.WriteLine("Removendo mercadoria {0}", mercadoria);
                    sincronizador.RemoverMercadoria(mercadoria);
                }
        }

        /// <summary>
        /// Sincroniza um álbum específico.
        /// </summary>
        /// <param name="album">Álbum a ser sincronizado.</param>
        private static void SincronizarAlbum(Álbum album)
        {
            Console.WriteLine("\n\nSincronizando álbum " + album.Nome);

            //List<string> mercadorias;
            List<Foto> fotos = album.Fotos.ExtrairElementos();
            Tabela[] tabelas = Tabela.ObterTabelas();
            Dictionary<string, double?> hashMercadoriaPeso = new Dictionary<string, double?>();
            int cnt = 0, total = fotos.Count;

            //mercadorias = new List<string>(sincronizador.ObterMercadorias((long)album.Código));

            //foreach (Foto foto in fotos)
            //{
            //    Mercadoria mercadoria = foto.ObterMercadoria();
            //    mercadorias.Remove(foto.ReferênciaNumérica + mercadoria.Dígito);
            //}

            foreach (Foto foto in fotos)
            {
                try
                {
                    Mercadoria mercadoria = foto.ObterMercadoria();

                    if (mercadoria.ForaDeLinha)
                    {
                        Console.WriteLine("Ignorando mercadoria fora de linha {0}", mercadoria.Referência);
                        continue;
                    }

                    List<IndiceTO> indices = new List<IndiceTO>(tabelas.Length);
                    double? peso;

                    if (hashMercadoriaAlbum.ContainsKey(mercadoria.ReferênciaNumérica + mercadoria.Dígito))
                    {
                        cnt++;
                        continue;
                    }

                    #region Cálculo do peso e verificação se todas as fotos da mesma mercadoria têm o mesmo peso

                    mercadoria.Peso = foto.Peso.GetValueOrDefault(mercadoria.Peso);

                    if (!hashMercadoriaPeso.TryGetValue(mercadoria.ReferênciaNumérica, out peso))
                    {
                        peso = mercadoria.Peso;
                        hashMercadoriaPeso.Add(mercadoria.ReferênciaNumérica, peso);
                    }
                    else if (!peso.HasValue)
                    {
                        peso = null;
                    }
                    else if (peso.Value != mercadoria.Peso)
                    {
                        peso = null;
                        hashMercadoriaPeso[mercadoria.ReferênciaNumérica] = null;
                    }

                    #endregion

                    #region Cálculo das tabelas

                    foreach (Tabela tabela in tabelas)
                    {
                        mercadoria.TabelaPreço = tabela;
                        indices.Add(new IndiceTO()
                        {
                            IDTabela = (int)tabela.Código,
                            Valor = (decimal)mercadoria.Índice
                        });
                    }

                    #endregion

                    cnt++;

                    int tentativa = 0;
                    bool ok;

                    do
                    {
                        ok = true;

                        Console.WriteLine("Atualizando mercadoria {0} ({1}/{2})", mercadoria.Referência, cnt, total);

                        try
                        {
                            sincronizador.AtualizarMercadoria(
                                mercadoria.Referência,
                                string.IsNullOrEmpty(foto.Descrição) ? mercadoria.Descrição : foto.Descrição,
                                foto.Peso.HasValue ? (decimal)foto.Peso : (decimal?)null,
                                (long)album.Código,
                                indices.ToArray());

                            try
                            {
                                hashMercadoriaAlbum.Add(mercadoria.ReferênciaNumérica + mercadoria.Dígito, album.Código);
                            }
                            catch (ArgumentException)
                            {
                                // Caso seja repetição...
                            }

                            long[] fotosExistentes = sincronizador.ObterFotos(mercadoria.Referência);

                            if (Array.IndexOf<long>(fotosExistentes, foto.Código) < 0)
                            {
                                try
                                {
                                    byte[] novaImagem;
                                    using (DbFoto dbfoto = foto.Imagem)
                                    {
                                        if (dbfoto.Vetor.Length > 1024 * 1024)
                                        {
                                            Console.WriteLine("Reduzindo imagem de {0} kb", dbfoto.Vetor.Length / 1024);

                                            try
                                            {
                                                //using (Bitmap bmp = new Bitmap(foto.Imagem))
                                                //{
                                                //    using (MemoryStream stream = new MemoryStream())
                                                //    {
                                                //        bmp.Save(stream, ImageFormat.Jpeg);
                                                //        novaImagem = stream.ToArray();
                                                //    }
                                                //}
                                                Image imagemMenor = Redimensionar(foto.Imagem, 608, 471);

                                                using (DbFoto dbFotoMenor = imagemMenor)
                                                    novaImagem = dbFotoMenor.Vetor;

                                                Console.WriteLine("Imagem convertida em {0} kb", novaImagem.Length / 1024);

                                                if (novaImagem.Length > dbfoto.Vetor.Length)
                                                {
                                                    Console.WriteLine("Voltando atrás...");
                                                    novaImagem = dbfoto.Vetor;
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.ToString());

                                                Console.WriteLine("Usando imagem original, devido à exceção.");

                                                novaImagem = dbfoto.Vetor;
                                            }
                                        }
                                        else
                                            novaImagem = dbfoto.Vetor;
                                    }

                                    Console.WriteLine("Gravando foto {0} da mercadoria {1} ({2} kb)", foto.Código, mercadoria.Referência, novaImagem.Length / 1024);
                                    sincronizador.GravarFoto(mercadoria.Referência, novaImagem, foto.Código);
                                }
                                catch (WebException)
                                {
                                    Console.Error.WriteLine("Não foi possível gravar foto para mercadoria " + mercadoria.Referência + ".");
                                    throw;
                                }
                                catch (Exception e)
                                {
                                    Console.Error.WriteLine("Não foi possível gravar foto para mercadoria " + mercadoria.Referência + ", portanto ela será excluída.");
                                    Console.Error.WriteLine(e.ToString());
                                    sincronizador.RemoverMercadoria(mercadoria.Referência);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            ok = false;
                            Console.Error.WriteLine(e.ToString());
                            Console.WriteLine("Aguardando 10 segundos para tentar novamente.");
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                        }
                    } while (!ok && tentativa++ < 10);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Redimensiona a imagem.
        /// </summary>
        /// <param name="imagemOriginal">Imagem a ser redimensionada.</param>
        /// <param name="largura">Nova largura.</param>
        /// <param name="altura">Nova altura.</param>
        /// <returns>Imagem redimensionada.</returns>
        public static Image Redimensionar(Image imagemOriginal, int largura, int altura)
        {
            if (largura > altura)
                altura = (int)Math.Round(largura * imagemOriginal.Height / (float)imagemOriginal.Width);
            else
                largura = (int)Math.Round(altura * imagemOriginal.Width / (float)imagemOriginal.Height);

            Image imagemNova = new Bitmap(largura, altura);

            using (Graphics g = Graphics.FromImage(imagemNova))
            {
                g.DrawImage(imagemOriginal, 0, 0, largura, altura);
            }

            return imagemNova;
        }
    }
}
