using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Acesso.Comum.Cache;

namespace Entidades.Pessoa.Endereço
{
    /// <summary>
    /// Informações acerca de um país.
    /// </summary>
    [Cacheável("ObterPaís"), DbTabela("pais"), NãoCopiarCache]
    public class País : DbManipulaçãoAutomática
    {
        #region Atributos

        /// <summary>
        /// Chave primária.
        /// </summary>
        [DbColuna("codigo"), DbChavePrimária(true)]
        private uint código = 0;

        /// <summary>
        /// Nome do país.
        /// </summary>
        private string nome;

        /// <summary>
        /// Sigla do país.
        /// </summary>
        private string sigla;

        /// <summary>
        /// Número para discagem ao exterior.
        /// </summary>
        private uint? ddi;

        #endregion

        #region Propriedades

        /// <summary>
        /// Chave primária.
        /// </summary>
        public uint Código { get { return código; } }

        /// <summary>
        /// Nome do país.
        /// </summary>
        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Sigla do país.
        /// </summary>
        public string Sigla { get { return sigla; } set { sigla = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Código para ligação telefônica.
        /// </summary>
        public uint? DDI { get { return ddi; } set { ddi = value; DefinirDesatualizado();  } }

        #endregion

        public static implicit operator País(string nome)
        {
            return (País)CacheDb.Instância.ObterEntidade(typeof(País), nome);
        }

        public static País ObterPaís(ulong país)
        {
            return MapearÚnicaLinha<País>("SELECT * FROM pais WHERE codigo = " + DbTransformar(país));
        }

        public static País[] ObterPaíses()
        {
            return Mapear<País>("SELECT * FROM pais").ToArray();
        }

        /// <summary>
        /// Obtém país dado um nome específico, sendo
        /// retornando de uma busca exata.
        /// </summary>
        /// <param name="p">Nome exato do país.</param>
        /// <returns>País encontrado.</returns>
        public static País[] ObterPaíses(string p)
        {
            return Mapear<País>("SELECT * FROM pais WHERE nome LIKE " + DbTransformar(p) + " ORDER BY nome").ToArray();
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
