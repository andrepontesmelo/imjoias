using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Configuração
{
    public class CacheChaves
    {
        private static CacheChaves instância;

        public static CacheChaves Instância
        {
            get
            {
                if (instância == null)
                    instância = new CacheChaves();

                return instância;
            }
        }

        private CacheChaves()
        {

        }

        private SortedDictionary<string, object> todosValoresBd;

        public SortedDictionary<string, object> TodosValoresBd
        {
            get { return todosValoresBd; }
            set { todosValoresBd = value; }
        }


    }
}
