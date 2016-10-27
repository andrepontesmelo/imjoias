using Acesso.Comum;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Entidades.Fiscal.Tipo
{
    public class TipoDocumento : DbManipulaçãoSimples
    {
#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        private int id;
        private string nome;
        public static List<TipoDocumento> tipos = null;
        private bool entrada;
        private bool saida;

#pragma warning restore 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        public TipoDocumento(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public TipoDocumento()
        {
        }

        public int Id => id;
        public string Nome => nome;
        public bool Entrada => entrada;
        public bool Saída => saida;

        public static List<TipoDocumento> Tipos
        {
            get
            {
                if (tipos == null)
                     Carregar();

                return tipos;
            }
        }

        public static IEnumerable<TipoDocumento> TiposEntrada => from tipo in Tipos where tipo.Entrada select tipo;
        public static IEnumerable<TipoDocumento> TiposSaída => from tipo in Tipos where tipo.Saída select tipo;

        public static TipoDocumento Obter(int código)
        {
            var tipos = from tipo in Tipos where tipo.Id.Equals(código) select tipo;
            return tipos.FirstOrDefault<TipoDocumento>();
        }

        private static void Carregar()
        {
            tipos = Mapear<TipoDocumento>("select * from tipodocumentofiscal order by nome");
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
