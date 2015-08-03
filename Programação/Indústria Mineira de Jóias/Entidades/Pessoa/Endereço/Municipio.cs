using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Pessoa.Endereço
{
    public class Municipio : DbManipulaçãoAutomática
    {
        private ulong localidade;

        public ulong Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }
        private ulong codigo;

        public ulong Código
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Municipio()
        { }

        public static Municipio Obter(Localidade localidade)
        {
            return MapearÚnicaLinha<Municipio>("select * from fiscal_municipioibge where localidade = " + DbTransformar(localidade.Código));
        }
    }
}
