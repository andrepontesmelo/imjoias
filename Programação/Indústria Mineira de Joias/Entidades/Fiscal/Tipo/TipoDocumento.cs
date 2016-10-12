using Acesso.Comum;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Tipo
{
    public class TipoDocumento : DbManipulaçãoSimples
    {
        private int id;
        private string nome;
        public static List<TipoDocumento> tipos = null;

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

        public static List<TipoDocumento> Tipos
        {
            get
            {
                if (tipos == null)
                     Carregar();

                return tipos;
            }
        }

        private static void Carregar()
        {
            tipos = Mapear<TipoDocumento>("select id, nome from tipodocumentofiscal");
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
