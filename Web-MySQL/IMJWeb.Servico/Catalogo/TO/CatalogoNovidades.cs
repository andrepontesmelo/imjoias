using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using IMJWeb.DAO;
using IMJWeb.Dominio.Util;
using System.Diagnostics;

namespace IMJWeb.Servico.Catalogo.TO
{
    class CatalogoNovidades : ICatalogo
    {
        private static CatalogoNovidades instancia = new CatalogoNovidades();

        public static CatalogoNovidades Instancia { get { return instancia; } }

        private CatalogoNovidades() { }


        private static bool? exibirNovidades;
        private static DateTime ultimaVerificacao;

        /// <summary>
        /// Determina se o catálogo de novidades deve ser exibido.
        /// </summary>
        public static bool ExibirNovidades
        {
            get
            {
                if (exibirNovidades.HasValue && ultimaVerificacao == DateTime.Today)
                    return exibirNovidades.Value;

                int quantidade = CatalogoNovidades.Instancia.ContarMercadorias();

                exibirNovidades = quantidade > 0 && quantidade < 100;

                Debug.Print("Quantidade de novidades: {0}", quantidade);
                Debug.Print("Exibir novidades: {0}", exibirNovidades);

                ultimaVerificacao = DateTime.Today;

                return exibirNovidades.Value;
            }
        }


        #region ICatalogo Members

        public long IDCatalogo
        {
            get { return -1; }
        }

        public string Nome
        {
            get
            {
                return "Novidades";
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public long? IMJ_IDAlbum
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public bool PermiteAcesso(IUsuario usuario)
        {
            if (usuario == null || !ExibirNovidades)
                return false;

            using (IMercadoriaDAO dao = InjecaoDependencia.Resolver<IMercadoriaDAO>())
            {
                var data = dao.ObterDataUltimaAtualizacao();

                if (!data.HasValue)
                    return false;

                if (data.Value < DateTime.Today.AddMonths(-3))
                    return false;

                return true;
            }
        }

        public IList<IMercadoria> ObterMercadorias(IUsuario usuario)
        {
            using (IMercadoriaDAO dao = InjecaoDependencia.Resolver<IMercadoriaDAO>())
            {
                var ultimoAcesso = usuario.UltimoAcesso.GetValueOrDefault();
                var ultimaAtualizacao = dao.ObterDataUltimaAtualizacao().GetValueOrDefault(DateTime.MaxValue);

                ultimaAtualizacao = ultimaAtualizacao.AddDays(-7);

                return dao.ObterMercadoriasAPartirDe(ultimaAtualizacao > ultimoAcesso ? ultimoAcesso : ultimaAtualizacao).Where(m => m.PermiteAcesso(usuario)).ToList();
            }
        }

        #endregion

        public int ContarMercadorias()
        {
            using (IMercadoriaDAO dao = InjecaoDependencia.Resolver<IMercadoriaDAO>())
            {
                var ultimaAtualizacao = dao.ObterDataUltimaAtualizacao().GetValueOrDefault(DateTime.MaxValue);
                ultimaAtualizacao = ultimaAtualizacao.AddDays(-7);

                return dao.ContarMercadoriasAPartirDe(ultimaAtualizacao);
            }
        }
    }
}
