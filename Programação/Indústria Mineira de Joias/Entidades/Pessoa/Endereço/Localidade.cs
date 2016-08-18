using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Data;

namespace Entidades.Pessoa.Endereço
{
    /// <summary>
    /// Localidade de um estado: município, distrito, povoado ou
    /// região administrativa.
    /// </summary>
    [Cacheável("ObterLocalidadeSemCache"), NãoCopiarCache, DbTransação]
    public class Localidade : DbManipulaçãoAutomática
    {
        #region Atributos

        /// <summary>
        /// Chave primária.
        /// </summary>
        [DbChavePrimária(true), DbColuna("codigo")]
        private ulong código = 0;

        /// <summary>
        /// Nome da localidade.
        /// </summary>
        private string nome;

        /// <summary>
        /// Estado da localidade.
        /// </summary>
        [DbRelacionamento("código", "estado")]
        private Estado estado;

        /// <summary>
        /// Tipo de localidade.
        /// </summary>
        private TipoLocalidade tipo;

        /// <summary>
        /// Código para ligação telefônica.
        /// </summary>
        private uint? ddd;

        [DbRelacionamento("código", "regiao")]
        [DbColuna("regiao")]
        private Região região;

        #endregion

        #region Propriedades

        /// <summary>
        /// Chave primária.
        /// </summary>
        public ulong Código { get { return código; } }

        /// <summary>
        /// Nome da localidade.
        /// </summary>
        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Estado ao qual a localidade pertence.
        /// </summary>
        public Estado Estado { get { return estado; } set { estado = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Tipo da localidade.
        /// </summary>
        public TipoLocalidade Tipo { get { return tipo; } set { tipo = value; DefinirDesatualizado(); } }
        
        /// <summary>
        /// Código para ligação telefônica.
        /// </summary>
        public uint? DDD { get { return ddd; } set { ddd = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Região da localidade.
        /// </summary>
        public Região Região { get { return região; } set { região = value; } }

        #endregion

        #region Recuperação

        public static implicit operator Localidade(UInt32 código)
        {
            return (Localidade)CacheDb.Instância.ObterEntidade(typeof(Localidade), código);
        }

        public static implicit operator Localidade(ulong código)
        {
            return (Localidade)CacheDb.Instância.ObterEntidade(typeof(Localidade), código);
        }

        public static Localidade ObterLocalidade(ulong código)
        {
            return (Localidade)CacheDb.Instância.ObterEntidade(typeof(Localidade), código);
        }

        public static Localidade ObterLocalidadeSemCache(ulong código)
        {
            return MapearÚnicaLinha<Localidade>(
                "SELECT * FROM localidade WHERE codigo = " + DbTransformar(código));
        }

        public static Localidade ObterLocalidade(Estado estado, string localidade)
        {
            if (estado == null || localidade == null)
                return null;

            return MapearÚnicaLinha<Localidade>(
                "SELECT * FROM localidade WHERE estado = " + DbTransformar(estado.Código) + " AND nome LIKE " + DbTransformar(localidade.Trim()));
        }

        public static Localidade[] ObterLocalidades(Estado estado, Região região)
        {
            return Mapear<Localidade>(
                "SELECT l.* FROM localidade l, estado e WHERE l.estado = e.codigo " +
                "AND (e.regiao = " + DbTransformar(região.Código) +
                " OR l.regiao = " + DbTransformar(região.Código) + 
                " OR l.estado = " + DbTransformar(estado.Código) + ")").ToArray();
        }

        public static Localidade[] ObterLocalidades()
        {
            return Mapear<Localidade>("SELECT * FROM localidade").ToArray();
        }

        public static Localidade[] ObterLocalidades(Região região)
        {
            return Mapear<Localidade>(
                "SELECT l.* FROM localidade l, estado e WHERE l.estado = e.codigo " +
                "AND (e.regiao = " + DbTransformar(região.Código) +
                " OR l.regiao = " + DbTransformar(região.Código) + ")").ToArray();
        }

        public static Localidade[] ObterLocalidades(Estado estado)
        {
            return Mapear<Localidade>(
                "SELECT * FROM localidade WHERE estado = " + DbTransformar(estado.Código) + " ORDER BY nome").ToArray();
        }

        public static Localidade[] ObterLocalidades(País país)
        {
            return Mapear<Localidade>(
                "SELECT l.* FROM localidade l, estado e WHERE l.estado = e.codigo " +
                "AND e.pais = " + DbTransformar(país.Código) + " ORDER BY l.nome").ToArray();
        }

        public static Localidade[] ObterLocalidades(string nome)
        {
            return Mapear<Localidade>(
                "SELECT * FROM localidade WHERE nome LIKE '%" + nome.Replace("'", @"\'").Replace("%", @"\%") + "%' ORDER BY nome").ToArray();
        }

        /// <summary>
        /// Obtém localidades a partir do nome.
        /// </summary>
        /// <param name="nome">Nome a ser procurado.</param>
        /// <param name="exato">Se a procura deve ser pelo nome exato.</param>
        /// <returns>Localidades encontradas.</returns>
        public static Localidade[] ObterLocalidades(string nome, bool exato)
        {
            if (exato)
                return Mapear<Localidade>(
                    "SELECT * FROM localidade WHERE nome LIKE '" + nome.Replace("'", @"\'").Replace("%", @"\%") + "' ORDER BY nome").ToArray();
            else
                return ObterLocalidades(nome);
        }

        public static string[] ObterPrefixo(string prefixo)
        {
            List<string> localidades = new List<string>();

            prefixo = prefixo.Replace("'", @"\'")
                .Replace("\"", "\\\"")
                .Replace("%", @"\%");

            IDataReader leitor = null;
            IDbConnection conexão = Conexão;
            
            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {


                    cmd.CommandText = "SELECT nome FROM localidade WHERE nome LIKE '" + prefixo + "%'";

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                                localidades.Add(leitor.GetString(0));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }

            return localidades.ToArray();
        }

        #endregion

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            /* A verificação abaixo normalmente não é necessária,
             * mas existe um caso especial forçado na localidade.
             * 
             * Durante o cadastro de cliente, se a pessoa digitar
             * rapidamente a localidade e a pesquisa em segundo plano
             * feita pelo TxtLocalidade não for completado até
             * o início do cadastramento no banco de dados, o controle
             * TxtLocalidade realiza cópia tardia da localidade
             * correspondente encontrada no banco de dados por meio de
             * reflexão, alterando o valor de "Cadastrado" após o início
             * do cadastro.
             * -- Júlio, 23/09/2006
             */
            if (Cadastrado)
                return;

            if (estado == null)
                throw new NullReferenceException("O campo estado de uma localidade não pode ser nula.");

            if (!estado.Cadastrado)
                CadastrarEntidade(cmd, estado);

            base.Cadastrar(cmd);
        }

        public override string ToString()
        {
            return nome;
        }

        public override bool Equals(object obj)
        {
            if (obj is Localidade)
                return código.Equals(((Localidade)obj).código);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return código.GetHashCode();
        }

        internal static Localidade Obter(IDataReader leitor, int incioParametrosLocalidade)
        {
            Localidade localidade = new Localidade();

            localidade.código = (ulong) leitor.GetInt64(incioParametrosLocalidade);
            localidade.nome = leitor.GetString(incioParametrosLocalidade + 1);
            localidade.estado = Estado.ObterEstado((ulong) leitor.GetInt64(incioParametrosLocalidade + 2));
            localidade.tipo = (TipoLocalidade) Enum.ToObject(typeof(TipoLocalidade), leitor.GetInt32(incioParametrosLocalidade + 3));
            
            if (!leitor.IsDBNull(incioParametrosLocalidade + 4))
                localidade.ddd = (uint) leitor.GetInt32(incioParametrosLocalidade + 4);

            localidade.região = leitor.IsDBNull(incioParametrosLocalidade + 5) ? null : 
                Região.ObterRegião((uint) leitor.GetInt32(incioParametrosLocalidade + 5));

            return localidade;
        }
    }
}
