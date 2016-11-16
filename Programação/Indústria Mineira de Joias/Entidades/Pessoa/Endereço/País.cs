using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Collections.Generic;
using System.Linq;

namespace Entidades.Pessoa.Endereço
{
    [Cacheável("ObterPaís"), DbTabela("pais"), NãoCopiarCache]
    public class País : DbManipulaçãoAutomática
    {
        [DbColuna("codigo"), DbChavePrimária(true)]
        private uint código = 0;
        private string nome;
        private string sigla;
        private uint? ddi;

        public uint Código => código;

        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }
        public string Sigla { get { return sigla; } set { sigla = value; DefinirDesatualizado(); } }
        public uint? DDI { get { return ddi; } set { ddi = value; DefinirDesatualizado();  } }

        private static List<País> paises = null;

        public static implicit operator País(string nome)
        {
            return (País)CacheDb.Instância.ObterEntidade(typeof(País), nome);
        }

        public static País ObterPaís(uint código)
        {
            return (from país in ObterPaíses() where país.Código.Equals(código) select país).First();
        }

        public static List<País> ObterPaíses()
        {
            if (paises == null)
                paises = Mapear<País>("SELECT * FROM pais");

            return paises;
        }

        public static País[] ObterPaíses(string nome)
        {
            return (from país in ObterPaíses() where país.Nome.Equals(nome) select país).ToArray();
        }

        public override string ToString()
        {
            return nome;
        }

        public override bool Equals(object obj)
        {
            if (obj is País)
                return código.Equals(((País)obj).código);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return código.GetHashCode();
        }
    }
}
