using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Acerto
{
    public class SaquinhoAcertoIgualVenda : SaquinhoAcerto
    {
        public SaquinhoAcertoIgualVenda(Mercadoria.Mercadoria m, double qtd, double peso, double �ndice)
            : base(m, qtd, peso, �ndice)
        {
        }

        public override double QtdAcerto
        {
            get { return QtdVenda - QtdDevolvida; }
        }
    }
}
