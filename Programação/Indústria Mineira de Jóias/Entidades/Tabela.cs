using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Data;
using Entidades.Configuração;

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
            Tabela[] todasTabelas = ObterTabelas();
            foreach (Tabela t in todasTabelas)
                if (t.Código == código)
                    return t;

            return null;

            //return MapearÚnicaLinha<Tabela>("SELECT * FROM tabela WHERE codigo = " + DbTransformar(código));
        }

        /// <summary>
        /// Obtém todas as tabelas.
        /// </summary>
        public static Tabela[] ObterTabelas()
        {
            if (tabelas == null)
                tabelas = Mapear<Tabela>("SELECT * FROM tabela ORDER BY nome").ToArray();

            return tabelas;
        }

        private static Tabela[] tabelas = null;

        /// <summary>
        /// Obtém todas as tabelas de um setor.
        /// </summary>
        public static Tabela[] ObterTabelas(Setor setor)
        {
            return Mapear<Tabela>("SELECT * FROM tabela WHERE setor = " + DbTransformar(setor.Código)
                + " ORDER BY nome").ToArray();
        }

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
