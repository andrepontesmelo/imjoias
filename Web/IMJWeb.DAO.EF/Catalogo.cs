using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using IMJWeb.Dominio.Util;
using IMJWeb.Dominio.Especificacao.AcessoUsuario;

namespace IMJWeb.DAO.EF
{
    partial class Catalogo : ICatalogo
    {
        private CacheFraca<long, IList<IMercadoria>> hashMercadoriasUsuario;
        private IValidadorAcessoUsuario<ICatalogo> validadorAcesso;

        /// <summary>
        /// Validador de acesso ao catálogo.
        /// </summary>
        protected IValidadorAcessoUsuario<ICatalogo> ValidadorAcesso
        {
            get
            {
                if (validadorAcesso == null)
                    validadorAcesso = FabricaValidadorAcessoUsuario.Criar<ICatalogo>();

                return validadorAcesso;
            }
        }

        #region ICatalogo Members

        /// <summary>
        /// Verifica se o acesso ao usuário é permitido.
        /// </summary>
        /// <param name="usuario">Usuário cujo acesso será verificado.</param>
        /// <returns>Verdadeiro se usuário pode visualizar o catálogo.</returns>
        public bool PermiteAcesso(IUsuario usuario)
        {
            return ValidadorAcesso.PermiteAcesso(this, usuario);
        }

        /// <summary>
        /// Mercadorias presentes no catálogo.
        /// </summary>
        public IList<IMercadoria> ObterMercadorias(IUsuario usuario)
        {
            return hashMercadoriasUsuario[usuario != null ? usuario.IDUsuario : -1];
        }

        #endregion

        public override string ToString()
        {
            return this.Nome;
        }

        public Catalogo()
        {
            hashMercadoriasUsuario = new CacheFraca<long, IList<IMercadoria>>(idusuario =>
            {
                if (!this.Mercadorias.IsLoaded)
                    this.Mercadorias.Load();

                foreach (var m in Mercadorias)
                    if (!m.Grupos.IsLoaded)
                        m.Grupos.Load();

                var mercadorias = from m in Mercadorias
                                  where m.Grupos.Count == 0
                                  orderby m.DataCriacao descending, m.Referencia ascending
                                  select m; 
                
                if (idusuario == -1)
                    return mercadorias.Where(m => !m.Exclusiva).ToList().ConvertAll<IMercadoria>(m => (IMercadoria)m);

                else
                {
                    ModeloMercadorias modelo = new ModeloMercadorias();

                    var q = from usr in modelo.Usuarios
                            where usr.IDUsuario == idusuario
                            from grp in usr.Grupos
                            from m in grp.Mercadorias
                            where m.Catalogo.IDCatalogo == this.IDCatalogo
                            select m;

                    return mercadorias.Union(q).OrderBy(m => m.Referencia)
                        .OrderByDescending(m => m.DataCriacao)
                        .ToList().ConvertAll<IMercadoria>(m => (IMercadoria)m);
                }
            });
        }
    }
}
