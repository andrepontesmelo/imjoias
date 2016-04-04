using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Acesso.Comum.Cache;

namespace Entidades.Pessoa.Endereço
{
    /// <summary>
    /// Estado de um país.
    /// </summary>
    [Cacheável("ObterEstado"), NãoCopiarCache, DbTransação]
    public class Estado : DbManipulaçãoAutomática
    {
        #region Atributos

        /// <summary>
        /// Chave primária.
        /// </summary>
        [DbColuna("codigo"), DbChavePrimária(true)]
        private uint código = 0;

        /// <summary>
        /// Nome do estado.
        /// </summary>
        private string nome;

        /// <summary>
        /// País de origem.
        /// </summary>
        [DbRelacionamento("código", "pais"), DbColuna("pais")]
        private País país;

        /// <summary>
        /// Sigla do estado.
        /// </summary>
        private string sigla;

        /// <summary>
        /// Região do estado.
        /// </summary>
        [DbRelacionamento("código", "regiao")]
        [DbColuna("regiao")]
        private Região região;

        #endregion

        #region Propriedades

        /// <summary>
        /// Código da região.
        /// </summary>
        public uint Código { get { return código; } }

        /// <summary>
        /// Nome do estado.
        /// </summary>
        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Nome do país.
        /// </summary>
        public País País { get { return país; } set { país = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Sigla do estado.
        /// </summary>
        public string Sigla { get { return sigla; } set { sigla = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Região do estado.
        /// </summary>
        public Região Região { get { return região; } set { região = value; DefinirDesatualizado(); } }

        #endregion

        #region Recuperação

        public static implicit operator Estado(uint código)
        {
            return (Estado)CacheDb.Instância.ObterEntidade(typeof(Estado), código);
        }

        private static Dictionary<ulong, Estado> hashEstado = null;

        public static Estado ObterEstado(ulong código)
        {
            if (hashEstado == null)
            {
                hashEstado = new Dictionary<ulong, Estado>();
                Estado[] estados = ObterEstados("");
                foreach (Estado e in estados)
                    hashEstado.Add(e.código, e);
            }

            Estado retorno;
            if (hashEstado.TryGetValue(código, out retorno))
                return retorno;
            else
                return null;

            //return MapearÚnicaLinha<Estado>(
            //    "SELECT * FROM estado WHERE codigo = " + DbTransformar(código));
        }

        public static Estado[] ObterEstados(Região região)
        {
            return Mapear<Estado>(
                "SELECT * FROM estado WHERE regiao = " + DbTransformar(região.Código) + " ORDER BY nome").ToArray();
        }

        public static Estado[] ObterEstados(string chave)
        {
            return Mapear<Estado>(
                "SELECT * FROM estado WHERE nome LIKE '" + chave + "%' OR sigla LIKE " + DbTransformar(chave) + " ORDER BY nome").ToArray();
        }

        /// <summary>
        /// Obtém estados a partir do nome ou da sigla.
        /// </summary>
        /// <param name="chave">Estado a ser procurado.</param>
        /// <param name="exato">Se a procura deve ser exata.</param>
        /// <returns>Estados encontrados.</returns>
        public static Estado[] ObterEstados(string chave, bool exato)
        {
            if (exato)
                return Mapear<Estado>(
                    "SELECT * FROM estado WHERE nome LIKE '" + chave + "' OR sigla LIKE " + DbTransformar(chave) + " ORDER BY nome").ToArray();
            else
                return ObterEstados(chave);
        }

        public static Estado[] ObterEstados(País país)
        {
            return Mapear<Estado>(
                "SELECT * FROM estado WHERE pais = " + DbTransformar(país.Código) + " ORDER BY nome").ToArray();
        }

        #endregion

        public override string ToString()
        {
            return nome;
        }

        public override bool Equals(object obj)
        {
            if (obj is Estado)
                return código.Equals(((Estado)obj).código);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return código.GetHashCode();
        }

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            if (país == null)
                throw new NullReferenceException("O campo país de um estado não pode ser nulo!");

            if (!país.Cadastrado)
                CadastrarEntidade(cmd, país);

            base.Cadastrar(cmd);
        }
    }
}
