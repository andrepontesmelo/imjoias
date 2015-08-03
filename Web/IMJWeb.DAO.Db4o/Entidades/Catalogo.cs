using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio.Especificacao.AcessoUsuario;
using IMJWeb.Dominio.Util;
using IMJWeb.Dominio;
using Db4objects.Db4o;

namespace IMJWeb.DAO.Db4o.Entidades
{
    public class Catalogo : ICatalogo
    {
        [Transient]
        private readonly IValidadorAcessoUsuario<ICatalogo> validadorAcesso;
        private readonly List<Referencia> mercadorias;

        /// <summary>
        /// Validador de acesso ao catálogo.
        /// </summary>
        protected IValidadorAcessoUsuario<ICatalogo> ValidadorAcesso
        {
            get
            {
                return validadorAcesso;
            }
        }

        public Catalogo()
        {
            validadorAcesso = FabricaValidadorAcessoUsuario.Criar<ICatalogo>();
            mercadorias = new List<Referencia>();
        }

        public long IDCatalogo { get; set; }

        public string Nome { get; set; }

        public long? IMJ_IDAlbum { get; set; }

        public List<Referencia> Mercadorias { get { return mercadorias; } }

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
            throw new NotImplementedException();
        }
    }
}
