using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.Servico.Catalogo.TO
{
    public class MercadoriaTO : IMercadoria
    {
        public Referencia Referencia { get; set; }

        public string Descricao { get; set; }

        public decimal? Peso { get; set; }

        ICollection<IFoto> IMercadoria.Fotos
        {
            get { return new IFoto[0]; }
        }

        public ICatalogo Catalogo { get; set; }

        IFoto IMercadoria.ObterFoto(int largura, int altura)
        {
            throw new NotImplementedException();
        }

        bool IMercadoria.PermiteAcesso(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        decimal? IMercadoria.ObterIndice(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public ICollection<IIndice> Indices
        {
            get { return new IIndice[0]; }
        }

        public bool Exclusiva { get; set; }
    }
}
