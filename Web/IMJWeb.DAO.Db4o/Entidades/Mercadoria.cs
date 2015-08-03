using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio.Especificacao.AcessoUsuario;
using IMJWeb.Dominio.Util;
using Db4objects.Db4o;
using IMJWeb.Dominio;

namespace IMJWeb.DAO.Db4o.Entidades
{
    public class Mercadoria : IMercadoria
    {
        private readonly LinkedList<IFoto> fotos = new LinkedList<IFoto>();
        private readonly Dictionary<int, IIndice> tabelaIndices = new Dictionary<int, IIndice>();

        [Transient]
        private IValidadorAcessoUsuario<IMercadoria> validadorAcesso;

        /// <summary>
        /// Validador de acesso ao catálogo.
        /// </summary>
        protected IValidadorAcessoUsuario<IMercadoria> ValidadorAcesso
        {
            get
            {
                if (validadorAcesso == null)
                    validadorAcesso = FabricaValidadorAcessoUsuario.Criar<IMercadoria>();

                return validadorAcesso;
            }
        }

        public Referencia Referencia { get; set; }

        public string Descricao { get; set; }

        public decimal? Peso { get; set; }

        public ICollection<IFoto> Fotos
        {
            get { return fotos; }
        }

        public ICollection<IIndice> Indices
        {
            get { return tabelaIndices.Values;  }
        }

        private ICatalogo catalogo;

        public ICatalogo Catalogo
        {
            get { return catalogo; }
            set
            {
                this.catalogo = value;

                if (catalogo != null && catalogo is Catalogo)
                    lock (catalogo)
                    {
                        var c = (Catalogo)catalogo;

                        if (!c.Mercadorias.Contains(this.Referencia))
                            c.Mercadorias.Add(this.Referencia);
                    }
            }
        }

        public bool Exclusiva { get; set; }

        public IFoto ObterFoto(int largura, int altura)
        {
            var fotos = from f in this.fotos
                        let dLargura = f.Largura - largura
                        let dAltura = f.Altura - altura
                        where dLargura >= 0 && dAltura >= 0
                        let criterio = dAltura == 0 ? 0 : 1.0f / (dLargura / (float)dAltura)
                        orderby criterio
                        select f;

            var resultado = fotos.FirstOrDefault();

            if (resultado == null)
                return this.fotos.OrderByDescending(f => f.Largura / f.Altura).FirstOrDefault();
            else
                return resultado;
        }

        public bool PermiteAcesso(IUsuario usuario)
        {
            return ValidadorAcesso.PermiteAcesso(this, usuario);
        }

        public decimal? ObterIndice(IUsuario usuario)
        {
            IIndice indice;

            if (usuario == null || usuario.Tabela == null)
                throw new IndiceIndisponivelException(Referencia);

            if (tabelaIndices.TryGetValue(usuario.Tabela.IDTabela, out indice))
                return indice.Valor;
            else
                throw new IndiceIndisponivelException(Referencia);
        }
    }
}
