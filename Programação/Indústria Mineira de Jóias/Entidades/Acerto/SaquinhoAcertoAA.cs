using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Acerto
{
    public class SaquinhoAcertoAA : SaquinhoAcerto
    {
        public SaquinhoAcertoAA(Mercadoria.Mercadoria m, double qtd, double peso, double índice)
            : base(m, qtd, peso, índice)
        {

        }

        public override double QtdAcerto
        {
            get { return QtdVenda - QtdDevolvida; }
        }
    }
}
