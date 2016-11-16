using Acesso.Comum;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Entidades.Fiscal.Tipo
{
    public class TipoUnidade : DbManipulaçãoSimples
    {
#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        private int id;
        private string nome;
        public static List<TipoUnidade> tipos = null;

#pragma warning restore 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        public TipoUnidade()
        {
        }

        public int Id => id;
        public string Nome => nome;

        public static List<TipoUnidade> Tipos
        {
            get
            {
                if (tipos == null)
                    Carregar();

                return tipos;
            }
        }

        public static TipoUnidade Obter(TipoUnidadeSistema tipoSistema)
        {
            return Obter((int)tipoSistema);
        }

        private static void Carregar()
        {
            tipos = Mapear<TipoUnidade>("select * from tipounidadefiscal order by nome");
        }

        public static TipoUnidade Obter(int tipoUnidade)
        {
            return (from tipo in Tipos where tipo.Id.Equals(tipoUnidade) select tipo).First();
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
