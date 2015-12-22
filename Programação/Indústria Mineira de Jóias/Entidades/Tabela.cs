using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Configuração;
using System.Collections.Generic;

namespace Entidades
{
    /// <summary>
    /// Tabela de preços.
    /// </summary>
    [Cacheável("ObterTabela"), NãoCopiarCache]
    public class Tabela : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'
        
        [DbChavePrimária(true), DbColuna("codigo")]
        private uint código;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        private string nome;

        [DbRelacionamento("código", "moeda")]
        private Moeda moeda;

        [DbRelacionamento("codigo", "setor")]
        private Setor setor;

        #region Propriedades

        /// <summary>
        /// Código da tabela.
        /// </summary>
        public uint Código { get { return código; } }

        /// <summary>
        /// Nome da tabela.
        /// </summary>
        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Moeda a ser utilizada.
        /// </summary>
        public Moeda Moeda { get { return moeda; } set { moeda = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Setor que a utiliza.
        /// </summary>
        public Setor Setor { get { return setor; } set { setor = value; DefinirDesatualizado(); } }

        #endregion

        /// <summary>
        /// Obtém a tabela especificada.
        /// </summary>
        public static Tabela ObterTabela(uint código)
        {
            // Busca linear - apenas 6 registros.
            List<Tabela> todasTabelas = ObterTabelas();
            foreach (Tabela t in todasTabelas)
                if (t.Código == código)
                    return t;

            return null;
        }

        /// <summary>
        /// Obtém todas as tabelas.
        /// </summary>
        public static List<Tabela> ObterTabelas()
        {
            if (tabelas == null)
                tabelas = Mapear<Tabela>("SELECT * FROM tabela ORDER BY nome");

            return tabelas;
        }

        private static List<Tabela> tabelas = null;

        /// <summary>
        /// Obtém todas as tabelas de um setor.
        /// </summary>
        public static List<Tabela> ObterTabelas(Setor setor)
        {
            if (hashSetorTabelas == null)
                CriarHashSetorTabelas();

            List<Tabela> tabelas = null;

            if (!hashSetorTabelas.TryGetValue(setor, out tabelas))
            {
                tabelas = new List<Tabela>();
                hashSetorTabelas.Add(setor, tabelas);
            }
            
            return tabelas;
        }

        private static void CriarHashSetorTabelas()
        {
            hashSetorTabelas = new Dictionary<Setor, List<Tabela>>();
            List<Tabela> todas = ObterTabelas();

            foreach (Tabela t in todas)
            {
                List<Tabela> listaDesteSetor;
                if (!hashSetorTabelas.TryGetValue(t.Setor, out listaDesteSetor))
                {
                    listaDesteSetor = new List<Tabela>();
                    hashSetorTabelas.Add(t.Setor, listaDesteSetor);
                }

                listaDesteSetor.Add(t);
            }
        }

        private static Dictionary<Setor, List<Tabela>> hashSetorTabelas = null;

        /// <summary>
        /// Obtém a primeira de um setor.
        /// </summary>
        public static Tabela ObterPrimeiraTabela(Setor setor)
        {
            return MapearÚnicaLinha<Tabela>("SELECT * FROM tabela WHERE setor = " + DbTransformar(setor.Código)
                + " LIMIT 1");
        }

        public override string ToString()
        {
            return Nome;
        }

        public static Tabela TabelaPadrão
        {
            get
            {
                return (Tabela)CacheDb.Instância.ObterEntidade(typeof(Tabela), DadosGlobais.Instância.TabelaPadrão);
            }
        }
    }
}
