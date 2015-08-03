using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO.EF
{
    class AdaptadorColecaoIndice : AdaptadorColecao<IIndice, Indice>
    {
        private Mercadoria mercadoria;

        public AdaptadorColecaoIndice(Mercadoria mercadoria) : base(mercadoria.Indices)
        {
            this.mercadoria = mercadoria;
        }

        public override void Add(IIndice item)
        {
            if (item is Indice)
                base.Add(item);
            else
            {
                Indice indice = new Indice()
                {
                    IDTabela = item.IDTabela,
                    Valor = item.Valor,
                    Referencia = mercadoria.Referencia,
                    Mercadoria = mercadoria
                };

                Colecao.Add(indice);
            }
        }

        public override bool Remove(IIndice item)
        {
            throw new NotImplementedException();
        }
    }
}
