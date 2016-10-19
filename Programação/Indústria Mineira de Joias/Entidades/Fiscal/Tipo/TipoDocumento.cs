using Acesso.Comum;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Entidades.Fiscal.Tipo
{
    public class TipoDocumento : DbManipulaçãoSimples
    {
        private int id;
        private string nome;
        public static List<TipoDocumento> tipos = null;
        private bool entrada;
        private bool saida;

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

        public static IEnumerable<TipoDocumento> TiposEntrada => from tipo in Tipos where tipo.Saída select tipo;
        public static IEnumerable<TipoDocumento> TiposSaída => from tipo in Tipos where tipo.Entrada select tipo;

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
