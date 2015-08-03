using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Security;
using IMJWeb.Servico.Catalogo;
using IMJWeb.Dominio.Util;
using IMJWeb.Dominio;
using System.Drawing;
using System.IO;
using System.Security.Permissions;
using System.Web.Services.Protocols;
using IMJWeb.Servico.Catalogo.TO;
using IMJWeb.DAO;
using System.Threading;

namespace IMJWeb.Sincronizacao.Internet
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "https://sincronizacao.imjoias.com.br/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Sincronizador : System.Web.Services.WebService
    {
        [WebMethod]
        public long[] ObterAlbuns()
        {
            using (Catalogos svcCatalogos = InjecaoDependencia.Resolver<Catalogos>())
            {
                return svcCatalogos.ObterAlbuns();
            }
        }

        [WebMethod]
        public void AtualizarMercadoria(string referencia, string descricao, decimal? peso, long album, IndiceTO[] indices)
        {
            using (Mercadorias svcMercadoria = InjecaoDependencia.Resolver<Mercadorias>())
            {
                svcMercadoria.Atualizar(referencia, descricao, peso, album, indices);
            }
        }

        [WebMethod]
        public string[] ObterMercadorias(long album)
        {
            using (ICatalogoDAO dao = InjecaoDependencia.Resolver<ICatalogoDAO>())
            {
                IList<string> referencias = dao.ObterReferencias(album);

                return referencias.ToArray();
            }
        }

        [WebMethod]
        public void RemoverMercadoria(string referencia)
        {
            using (IMercadoriaDAO dao = InjecaoDependencia.Resolver<IMercadoriaDAO>())
            {
                var mercadoria = dao.Obter(referencia);
                dao.Remover(mercadoria);
            }
        }

        [WebMethod]
        public long[] ObterFotos(string referencia)
        {
            using (IMercadoriaDAO dao = InjecaoDependencia.Resolver<IMercadoriaDAO>())
            {
                return dao.ObterFotos(referencia);
            }
        }

        /// <summary>
        /// Grava uma foto de uma mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <param name="imagem">Imagem da mercadoria.</param>
        /// <param name="identificador">Identificador no servidor local.</param>
        [WebMethod]
        public void GravarFoto(string referencia, byte[] imagem, long identificador)
        {
            Referencia objReferencia;
            Image objImagem;

            #region Validação e conversão de parâmtros

            #region Referência

            try
            {
                objReferencia = new Referencia(referencia);
            }
            catch (Exception e)
            {
                throw new ArgumentException(string.Format("Erro interpretando referência {0}.", referencia), "referencia", e);
            }

            #endregion

            #region Imagem

            try
            {
                using (MemoryStream stream = new MemoryStream(imagem))
                {
                    objImagem = Image.FromStream(stream);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Não foi possível processar imagem.", "imagem", e);
            }

            #endregion

            #endregion

            try
            {
                using (Mercadorias servico = InjecaoDependencia.Resolver<Mercadorias>())
                {
                    servico.CadastrarFoto(objReferencia, objImagem, identificador);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível cadastrar foto.", e);
            }
        }
    }
}
