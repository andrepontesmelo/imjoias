using System.Collections.Generic;

namespace Entidades.Coaf
{
    public class HashPessoaExpostaPoliticamente 
    {
        private static Dictionary<string, PessoaExpostaPoliticamente> hash = null;

        public static Dictionary<string, PessoaExpostaPoliticamente> Hash
        {
            get
            {
                if (hash == null)
                    hash = ObterHash();

                return hash;
            }
        }

        public HashPessoaExpostaPoliticamente()
        {
        }

        public static PessoaExpostaPoliticamente ObterPessoa(string cpf)
        {
            if (cpf == null)
                return null;

            Hash.TryGetValue(cpf, out PessoaExpostaPoliticamente pessoa);
            return pessoa; 
        }

        private static Dictionary<string, PessoaExpostaPoliticamente> ObterHash()
        {
            var hash = new Dictionary<string, PessoaExpostaPoliticamente>();

            foreach (var entidade in PessoaExpostaPoliticamente.Obter())
                hash[entidade.Cpf] = entidade;

            return hash;
        }

        public static bool PessoaÉPoliticamenteExposta(string cpf)
        {
            if (cpf == null)
                return false;

            return Hash.ContainsKey(cpf);
        }
    }
}
