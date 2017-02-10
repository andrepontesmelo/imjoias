using System.Collections.Generic;

namespace Entidades.Coaf
{
    public class CódigoPep : PessoaExpostaPoliticamente
    {
        private uint codigo;
        private static Dictionary<uint, PessoaExpostaPoliticamente> hash = null;

        public static Dictionary<uint, PessoaExpostaPoliticamente> Hash
        {
            get
            {
                if (hash == null)
                    hash = ObterHash();

                return hash;
            }
        }

        public CódigoPep()
        {
        }

        private static List<CódigoPep> Obter()
        {
            return Mapear<CódigoPep>("select pf.codigo, pep.* from pep join pessoafisica pf on pf.cpf=pep.cpf");
        }

        private static Dictionary<uint, PessoaExpostaPoliticamente> ObterHash()
        {
            var hash = new Dictionary<uint, PessoaExpostaPoliticamente>();

            foreach (var entidade in Obter())
                hash[entidade.codigo] = entidade;

            return hash;
        }

        public static bool PessoaÉPoliticamenteExposta(uint código)
        {
            return Hash.ContainsKey(código);
        }
    }
}
