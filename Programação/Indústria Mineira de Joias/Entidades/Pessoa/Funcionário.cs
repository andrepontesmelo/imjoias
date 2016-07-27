using System;
using System.Data;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Privil�gio;
using System.Collections.Generic;

namespace Entidades.Pessoa
{
    [Serializable, DbTransa��o, Cache�vel("ObterPessoaSemCache", "ObterFuncion�rioPorUsu�rioSemCache", "ObterFuncion�rioSemCache")]
	[N�oCopiarCache, Validade(6, 0, 0)]
    public class Funcion�rio : PessoaF�sica
	{
        private TimeSpan tempoAtualiza��oSitua��o = new TimeSpan(0, 1, 00);

		private bool rod�zioAlterado = false;

		protected long? ficha;					
		protected double salario;
		protected string carteiraProfissional;
		protected string carteiraProfissionalSerie;
		protected string reservista;
		protected string reservistaSerie;
		protected string reservistaCategoria;
		protected DateTime dataAdmissao = DateTime.MinValue;
		protected DateTime?	dataSaida = null;
		protected string pis;
		protected string cbo;
		protected string tituloEleitor;
		protected int ramal;
		protected uint rodizio;
		protected string beneficiario;
		protected string beneficiarioParentesco;
		protected string cargo;
		protected string horarioTrabalho;
		protected string intervaloRefeicao;
		protected string horarioSabado;
		protected ulong	empresa;
		protected string empresaNome = null;
		protected string usuario;

        private DateTime �ltimaAtualiza��oSitua��o = DateTime.Now;

        /// <summary>
        /// Permiss�o do funcion�rio.
        /// </summary>
        [DbColuna("privilegios")]
        private Permiss�o privil�gios;

        /// <summary>
        /// Estado do funcion�rio.
        /// </summary>
        private EstadoFuncion�rio contextoEstado;
		
		/// <summary>
		/// Tabela de hor�rio.
		/// </summary>
		[DbAtributo(TipoAtributo.Ignorar)]
		protected TabelaHor�rio tabelaHor�rio = null;

		#region Construtoras
		
		public Funcion�rio() {}
        public Funcion�rio(ulong c�digo) : base(c�digo) { }

		
		#endregion

		#region Propriedades

        /// <summary>
        /// Verifica se o funcion�rio est� atendendo.
        /// </summary>
        /// <remarks>
        /// Esta propriedade realiza consulta no banco de dados.
        /// </remarks>
        public bool EmAtendimento
        {
            get
            {
                return Visita.EmAtendimento(this);
            }
        }

        /// <summary>
        /// Funcion�rio que est� logado no programa.
        /// </summary>
        public static Funcion�rio Funcion�rioAtual
        {
            get
            {
                return ObterFuncion�rioPorUsu�rio
                    (Acesso.Comum.Usu�rios.Usu�rioAtual.Nome);
            }
        }

		public long? Ficha
		{
			get { return ficha; }
            set
            {
                if (value.HasValue && value.Value <= 0)
                    ficha = null;
                else
                    ficha = value;

                DefinirDesatualizado();
            }
		}

		public double Sal�rio
		{
			get { return salario; }
            set { salario = value; DefinirDesatualizado(); }
		}

		public string Sal�rioExtenso
		{
			get { return N�meroExtenso.Transformar((decimal) salario); }
		}

		public string CarteiraProfissional
		{
			get { return carteiraProfissional; }
            set { carteiraProfissional = value; DefinirDesatualizado(); }
		}

		public string CarteiraProfissionalS�rie
		{
			get { return carteiraProfissionalSerie; }
            set { carteiraProfissionalSerie = value; DefinirDesatualizado(); }
		}

		public string Reservista
		{
			get { return reservista; }
            set { reservista = value; DefinirDesatualizado(); }
		}

		public string ReservistaS�rie
		{
			get { return reservistaSerie; }
            set { reservistaSerie = value; DefinirDesatualizado(); }
		}

		public string ReservistaCategoria
		{
			get { return reservistaCategoria; }
            set { reservistaCategoria = value; DefinirDesatualizado(); }
		}

		public DateTime DataAdmiss�o
		{
			get { return dataAdmissao; }
            set { dataAdmissao = value; DefinirDesatualizado(); }
		}

		public DateTime? DataSa�da
		{
			get { return dataSaida; }
            set { dataSaida = value; DefinirDesatualizado(); }
		}

		public string PIS
		{
			get { return pis; }
            set { pis = value; DefinirDesatualizado(); }
		}

		public string CBO
		{
			get { return cbo; }
            set { cbo = value; DefinirDesatualizado(); }
		}

		public string T�tuloEleitor
		{
			get { return tituloEleitor; }
            set { tituloEleitor = value; DefinirDesatualizado(); }
		}

		public int Ramal
		{
			get { return ramal; }
            set { ramal = value; DefinirDesatualizado(); }
		}

		public bool Ativo
		{
            get { return dataSaida < DateTime.Now; }
		}

		public uint Rod�zio
		{
			get { return rodizio; }
			set
			{
				rod�zioAlterado = rodizio != value;
				rodizio = value;
			}
		}

		public string EmpresaNome
		{
			get
            {
                if (empresaNome == null)
                    return RecuperarNomeEmpresa();
                else
                    return empresaNome;
            }
            set { empresaNome = value; DefinirDesatualizado(); }
		}

		public ulong Empresa
		{
			get { return empresa; }
            set { empresa = value; DefinirDesatualizado(); }
		}

		public string Cargo
		{
			get { return cargo; }
            set { cargo = value; DefinirDesatualizado(); }
		}

		public string Benefici�rio
		{
			get { return beneficiario; }
            set { beneficiario = value; DefinirDesatualizado(); }
		}

		public string Benefici�rioParentesco
		{
			get { return beneficiarioParentesco; }
            set { beneficiarioParentesco = value; DefinirDesatualizado(); }
		}

		public string Usu�rio
		{
			get { return usuario; }
            set { usuario = value; DefinirDesatualizado(); }
		}

        /// <summary>
        /// Privil�gios do funcion�rio para acesso ao sistema.
        /// </summary>
        public Permiss�o Privil�gios
        {
            get { return privil�gios; }
            set { privil�gios = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Situa��o do funcion�rio na empresa. A altera��o deste valor
        /// implica em atualiza��o imediata do banco de dados.
        /// </summary>
        public EstadoFuncion�rio Situa��o
        {
            get
            {
                if (DateTime.Now - �ltimaAtualiza��oSitua��o > tempoAtualiza��oSitua��o)
                    ObterSitua��o();

                return contextoEstado;
            }
            set
            {
                contextoEstado = value;

                if (Cadastrado)
                    AtualizarSitua��o();
            }
        }

		public TabelaHor�rio TabelaHor�rio
		{
			get
			{
				if (tabelaHor�rio == null)
					tabelaHor�rio = new TabelaHor�rio(this);

				return tabelaHor�rio;
			}
		}

        /// <summary>
        /// Carga hor�ria semanal aproximada.
        /// </summary>
        public uint CargaHor�riaSemanal
        {
            get
            {
                return tabelaHor�rio.CalcularCargaHor�riaSemanal();
            }
        }

		/// <summary>
		/// Constr�i uma tabela de hor�rio vazia para ser preenchida na leitura
		/// do banco de dados.
		/// </summary>
		internal void CriarTabelaHor�rioVazia()
		{
			tabelaHor�rio = new TabelaHor�rio();
		}

		#endregion

		#region Recupera��o de Dados

        /// <summary>
        /// Obt�m atendentes de um setor espec�fico.
        /// </summary>
        /// <param name="setor">Setor cujos atendentes ser�o recuperados.</param>
        /// <returns>Vetor de atendentes ordenado pelo rod�zio.</returns>
        public static Funcion�rio[] ObterFuncion�rios(Setor setor)
        {
            return Mapear<Funcion�rio>(
                "SELECT * FROM funcionario f JOIN pessoafisica pf ON f.codigo = pf.codigo JOIN pessoa p ON pf.codigo = p.codigo WHERE setor = " + DbTransformar(setor.C�digo) +
                " AND dataSaida IS NULL ORDER BY rodizio").ToArray();
        }

		/// <summary>
		/// Obt�m nomes do banco de dados de funcion�rios
		/// </summary>
		/// <param name="nomeBase">Nome de base para pesquisa</param>
		/// <param name="limite">Limite de nomes</param>
		/// <returns>Lista de nomes</returns>
        public static new string[] ObterNomes(string nomeBase, int limite)
        {
            IDbConnection conex�o;

            conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                try
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        IDataReader leitor = null;
                        ArrayList dados = new ArrayList(limite);

                        string tmpNome;

                        // Primeiramente inserir nome base
                        tmpNome = nomeBase.Replace(' ', '%').Replace("%%", "%");

                        cmd.CommandText = "SELECT nome FROM pessoa WHERE nome LIKE '" +
                            tmpNome + "%' ORDER BY nome ASC LIMIT " +
                            limite.ToString();

                        try
                        {
                            using (leitor = cmd.ExecuteReader())
                            {
                                while (leitor.Read())
                                {
                                    dados.Add(leitor.GetString(0));
                                }
                            }
                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();
                        }


                        /*
                         * Pesquisar demais nomes, se necess�rio
                         */
                        if (dados.Count == 0)
                        {
                            ICollection nomes = ExtrairNomes(nomeBase);

                            cmd.CommandText = "SELECT nome FROM pessoa WHERE ";

                            bool primeiro = true;

                            foreach (string parte in nomes)
                            {

                                if (!primeiro)
                                    cmd.CommandText += " OR ";

                                primeiro = false;

                                cmd.CommandText += " nome LIKE '%" + parte + "%' ";
                            }

                            cmd.CommandText += " ORDER BY nome ASC LIMIT " + ((int)(limite - dados.Count)).ToString();

                            try
                            {
                                using (leitor = cmd.ExecuteReader())
                                {
                                    while (leitor.Read())
                                    {
                                        dados.Add(leitor.GetString(0));
                                    }
                                }
                            }
                            finally
                            {
                                if (leitor != null)
                                    leitor.Close();
                            }
                        }


                        return (string[])dados.ToArray(typeof(string));
                    }
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
            }
        }

        public static List<Pessoa> ObterFuncion�rios(string nomeBase, int limite)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    List<Pessoa> dados = new List<Pessoa>(limite);

                    string tmpNome;

                    /***
                     * Primeiramente inserir nome base
                     */
                    tmpNome = DbTransformar(nomeBase).Replace(' ', '%').Replace("%%", "%");

                    cmd.CommandText = "SELECT p.* FROM pessoa p JOIN funcionario f ON p.codigo = f.codigo JOIN pessoafisica pf ON p.codigo = pf.codigo WHERE nome LIKE '" +
                        tmpNome.Substring(1, tmpNome.Length - 2) + "%' AND f.dataSaida IS NULL ORDER BY nome ASC LIMIT " +
                        limite.ToString();

                    Mapear<Entidades.Pessoa.Pessoa>(cmd, dados);



                    /***
                     * Pesquisar demais nomes, se necess�rio
                     */
                    if (dados.Count == 0)
                    {
                        ICollection nomes = ExtrairNomes(nomeBase);

                        cmd.CommandText = "SELECT p.* FROM pessoa p JOIN funcionario f ON p.codigo = f.codigo JOIN pessoafisica pf ON p.codigo = pf.codigo WHERE ";

                        foreach (string parte in nomes)
                        {
                            tmpNome = DbTransformar(parte);
                            cmd.CommandText += "nome LIKE '%" +
                                tmpNome.Substring(1, tmpNome.Length - 2) + "%' OR ";
                        }

                        cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 3, 3)
                            + " AND f.dataSaida IS NULL ORDER BY nome ASC LIMIT " + ((int)(limite - dados.Count)).ToString();

                        Mapear<Entidades.Pessoa.Pessoa>(cmd, dados);
                    }

                    return dados;
                }
            }
        }

        /// <summary>
        /// Recupera funcion�rios do banco de dados.
        /// </summary>
        /// <param name="ativos">
        /// Determina se deve recuperar somente
        /// funcion�rios ativos.
        /// </param>
        /// <param name="ordenarPorRod�zio">
        /// Determina se deve ordenar por ordenarPorRod�zio.
        /// </param>
        /// <returns></returns>
		public static List<Funcion�rio> ObterFuncion�rios(bool ativos, bool ordenarPorRod�zio)
		{
			IDbConnection conex�o = Conex�o;

			lock (conex�o)
			{
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.*, pf.*, f.*, e.nome AS empresaNome"
                        + " FROM pessoa p, pessoafisica pf, funcionario f, pessoa e"
                        + " WHERE p.codigo = f.codigo AND f.codigo = pf.codigo"
                        + " AND f.empresa = e.codigo";

                    if (ativos)
                        cmd.CommandText += " AND dataSaida IS NULL";

                    if (ordenarPorRod�zio)
                        cmd.CommandText += " ORDER BY rodizio";

                    return Mapear<Entidades.Pessoa.Funcion�rio>(cmd);
                }
			}
		}

        public static List<Funcion�rio> ObterFuncion�rios()
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.*, pf.*, f.*, e.nome AS empresaNome"
                        + " FROM pessoa p, pessoafisica pf, funcionario f, pessoa e"
                        + " WHERE p.codigo = f.codigo AND f.codigo = pf.codigo"
                        + " AND f.empresa = e.codigo";

                    return Mapear<Entidades.Pessoa.Funcion�rio>(cmd);
                }
            }
        }

        /// <summary>
        /// Realiza uma consulta.
        /// Um vendedor � aquela pessoa que tem pelo menos uma venda no banco sendo ela vendedor rs
        /// </summary>
        public static bool �Vendedor(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT count(*) FROM venda where vendedor=" + DbTransformar(pessoa.C�digo);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private static SortedSet<ulong> lstC�digosFuncion�rios = null;

        public static bool �Funcion�rioOuRepresentante(Entidades.Pessoa.Pessoa pessoa)
        {
            return �Funcion�rio(pessoa) || Representante.�Representante(pessoa);
        }
        /// <summary>
        /// Verifica se uma pessoa � funcion�rio.
        /// Desconsidera data demiss�o.
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static bool �Funcion�rio(Entidades.Pessoa.Pessoa pessoa)
        {
            if (lstC�digosFuncion�rios == null)
            {
                lstC�digosFuncion�rios = new SortedSet<ulong>();

                IDbConnection conex�o = Conex�o;

                lock (conex�o)
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = "SELECT codigo FROM funcionario";

                        using (IDataReader leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                lstC�digosFuncion�rios.Add((ulong)leitor.GetInt64(0));
                            }
                        }
                    }
                }

            }

            return lstC�digosFuncion�rios.Contains(pessoa.C�digo);
        }

        /// <summary>
        /// Obt�m uma pessoa a partir de um c�digo.
        /// </summary>
        /// <param name="c�digo">C�digo da pessoa.</param>
        /// <returns>Retorna uma pessoa-f�sica.</returns>
        public new static Funcion�rio ObterPessoa(ulong c�digo)
        {
            //return Acesso.Comum.Cache.CacheDb.Inst�ncia.ObterEntidade(typeof(Funcion�rio), c�digo) as Funcion�rio;
            if (hashFuncion�rios == null)
                ConstruirHashFuncion�rios();

            Funcion�rio encontrado = null;
            hashFuncion�rios.TryGetValue(c�digo, out encontrado);
            return encontrado;
        }

        private static Dictionary<ulong, Funcion�rio> hashFuncion�rios = null;
        private static void ConstruirHashFuncion�rios()
        {
            List<Funcion�rio> funcion�rios = ObterFuncion�rios();
            hashFuncion�rios = new Dictionary<ulong, Funcion�rio>(funcion�rios.Count);
            foreach (Funcion�rio f in funcion�rios)
                hashFuncion�rios[f.C�digo] = f;
        }


        public static Funcion�rio ObterPessoa(string nome)
        {
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND p.nome = " + DbTransformar(nome);

            return Mapear�nicaLinha<Funcion�rio>(comando);
        }

        public new static Funcion�rio ObterPessoaSemCache(ulong c�digo)
		{
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND p.codigo = " + DbTransformar(c�digo);

            return Mapear�nicaLinha<Funcion�rio>(comando);
		}

        /// <summary>
        /// Obt�m uma pessoa a partir de um c�digo.
        /// </summary>
        /// <param name="c�digo">C�digo da pessoa.</param>
        /// <returns>Retorna um funcion�rio.</returns>
        private static Funcion�rio ObterFuncion�rio(ulong c�digo)
        {
            return Acesso.Comum.Cache.CacheDb.Inst�ncia.ObterEntidade(typeof(Funcion�rio), c�digo) as Funcion�rio;
        }

        private static Funcion�rio ObterFuncion�rioSemCache(ulong c�digo)
        {
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND p.codigo = " + DbTransformar(c�digo);

            return Mapear�nicaLinha<Funcion�rio>(comando);
        }

        /// <summary>
        /// Obt�m uma pessoa a partir do usu�rio.
        /// </summary>
        /// <param name="usu�rio">Usu�rio.</param>
        /// <returns>Retorna um funcion�rio.</returns>
        public static Funcion�rio ObterFuncion�rioPorUsu�rio(string usu�rio)
        {
            return Acesso.Comum.Cache.CacheDb.Inst�ncia.ObterEntidade(typeof(Funcion�rio), usu�rio) as Funcion�rio;
        }

        public static Funcion�rio ObterFuncion�rioPorUsu�rioSemCache(string usu�rio)
        {
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND f.usuario = " + DbTransformar(usu�rio);

            return Mapear�nicaLinha<Funcion�rio>(comando);
        }

        /// <summary>
        /// Recupera o nome da empresa.
        /// </summary>
        /// <returns>Nome da empresa.</returns>
        private string RecuperarNomeEmpresa()
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT nome FROM pessoa WHERE codigo = " + DbTransformar(empresa);

                    return empresaNome = Convert.ToString(cmd.ExecuteScalar());
                }
            }
        }

		#endregion

		#region Recupera��o por cast e cache

		public static implicit operator Funcion�rio(long c�digo)
		{
			return Funcion�rio.ObterPessoa(Convert.ToUInt64(c�digo));
		}

        public static implicit operator Funcion�rio(ulong c�digo)
        {
            return Funcion�rio.ObterPessoa(c�digo);
        }

		public static implicit operator Funcion�rio(uint c�digo)
		{
			return Funcion�rio.ObterPessoa(c�digo);
		}

		public static implicit operator Funcion�rio(int c�digo)
		{
		    return Funcion�rio.ObterPessoa(Convert.ToUInt64(c�digo));
        }

        // N�o � intuitivo e sugeito a erros:
        //public static implicit operator Funcion�rio(string nomeUsu�rio)
        //{
        //    return Funcion�rio.ObterFuncion�rioPorUsu�rio(nomeUsu�rio);
        //}

		#endregion

		public static TimeSpan ConverterHor�rio(string hor�rio, bool primeiro)
		{
			try
			{
				char [] separadores = new char [] { ' ', '-' };

				if (primeiro)
					hor�rio = hor�rio.Substring(0, hor�rio.IndexOfAny(separadores));
				else
					hor�rio = hor�rio.Substring(hor�rio.LastIndexOfAny(separadores));

				return TimeSpan.Parse(hor�rio);
			}
			catch
			{
				return new TimeSpan(0);
			}
		}

		#region Atualiza��o do banco de dados

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		public override void Cadastrar()
		{
			base.Cadastrar();

			if (tabelaHor�rio != null)
				tabelaHor�rio.Cadastrar();
		}

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            AdequarPrivil�gios();

            if (Usu�rio != null && Usu�rio.Length > 0 && ValidarUsu�rio(Usu�rio))
            {
                cmd.CommandText = "INSERT INTO funcionario (codigo, empresa, ficha, salario, " +
                "cargo, carteiraProfissional, carteiraProfissionalSerie, " +
                "reservista, reservistaSerie, reservistaCategoria, " +
                "dataAdmissao, dataSaida, pis, " +
                "cbo, tituloEleitor, ramal, rodizio, " +
                "beneficiario, beneficiarioParentesco, " +
                "usuario, privilegios) VALUES " +
                "(" + DbTransformar(C�digo) + ", " +
                DbTransformar(Empresa) + ", " +
                DbTransformar(Ficha) + ", " +
                DbTransformar(Sal�rio) + ", " +
                DbTransformar(Cargo) + ", " +
                DbTransformar(CarteiraProfissional) + ", " +
                DbTransformar(CarteiraProfissionalS�rie) + ", " +
                DbTransformar(Reservista) + ", " +
                DbTransformar(ReservistaS�rie) + ", " +
                DbTransformar(ReservistaCategoria) + ", " +
                DbTransformar(DataAdmiss�o) + ", " +
                (DataSa�da < DataAdmiss�o ? "NULL, " :
                DbTransformar(DataSa�da) + ", ") +
                DbTransformar(PIS) + ", " +
                DbTransformar(CBO) + ", " +
                DbTransformar(T�tuloEleitor) + ", " +
                DbTransformar(Ramal) + ", " +
                DbTransformar(Rod�zio) + ", " +
                DbTransformar(Benefici�rio) + ", " +
                DbTransformar(Benefici�rioParentesco) + ", " +
                DbTransformar(Usu�rio) + ", " +
                DbTransformar(Convert.ToInt32(Privil�gios)) +
                ")";

                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE USER '"
                    + Usu�rio + "'@'%'";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "CREATE USER '"
                //    + Usu�rio + "'@'192.168.1.%'";
                //cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT CREATE USER ON *.* TO '"
                //        + Usu�rio + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT CREATE USER ON *.* TO '"
                        + Usu�rio + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT RELOAD ON *.* TO '"
                        + Usu�rio + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT RELOAD ON *.* TO '"
                //    + Usu�rio + "'@'192.168.1.%' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

//#if DEBUG
//                string tabela = "`imjoias-desenv`";
//#else
                string tabela = "imjoias";
//#endif

                //cmd.CommandText = "GRANT SELECT,INSERT,UPDATE,DELETE,LOCK TABLES,EXECUTE ON " + tabela + ".* TO '"
                //    + Usu�rio + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT SELECT,INSERT,UPDATE,DELETE,LOCK TABLES,EXECUTE ON " + tabela + ".* TO '"
                    + Usu�rio + "'@'%'  WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularcomissao TO '"
                //    + Usu�rio + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularcomissao TO '"
                    + Usu�rio + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularvendavalortotal TO '"
                //    + Usu�rio + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularvendavalortotal TO '"
                    + Usu�rio + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT EXECUTE ON FUNCTION ranking_mercadoria TO '"
                    + Usu�rio + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT EXECUTE ON FUNCTION ranking_mercadoria TO '"
                //    + Usu�rio + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "FLUSH PRIVILEGES";
                cmd.ExecuteNonQuery();
            }
            else if (Usu�rio != null)
                throw new ApplicationException("Usu�rio j� encontra-se cadastrado!");
        }

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		public override void Atualizar()
		{
			if (rod�zioAlterado && Atualizado)
				AtualizarRod�zio();
			else
				base.Atualizar();

			if (tabelaHor�rio != null)
				tabelaHor�rio.Atualizar();
		}

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		/// <param name="cmd">Comando para atualiza��o.</param>
		protected override void Atualizar(IDbCommand cmd)
		{
			if (Transacionando)
				base.Atualizar(cmd);

            AdequarPrivil�gios();

            cmd.CommandText = "UPDATE funcionario SET " +
				"ficha = "				+ DbTransformar(Ficha) + ", " +
				"empresa = "			+ DbTransformar(Empresa) + ", " +
				"cargo = "				+ DbTransformar(Cargo) + ", " +
				"salario = "			+ DbTransformar(Sal�rio) + ", " +
				"carteiraProfissional = " + DbTransformar(CarteiraProfissional) + ", " +
				"carteiraProfissionalSerie = " + DbTransformar(CarteiraProfissionalS�rie) + ", " +
				"reservista = "			+ DbTransformar(Reservista) + ", " +
				"reservistaSerie = "	+ DbTransformar(ReservistaS�rie) + ", " +
				"reservistaCategoria = " + DbTransformar(ReservistaCategoria) + ", " +
				"dataAdmissao = "		+ DbTransformar(DataAdmiss�o) + ", " + 
				(DataSa�da < DataSa�da ? "dataSaida = NULL, " :
				"dataSaida = "			+ DbTransformar(DataSa�da) + ", ") + 
				"pis = "				+ DbTransformar(PIS) + ", " +
				"cbo = "				+ DbTransformar(CBO) + ", " +
				"tituloEleitor = "		+ DbTransformar(T�tuloEleitor) + ", " +
				"ramal = "				+ DbTransformar(Ramal) + ", " +
				"rodizio = "			+ DbTransformar(Rod�zio) + ", " +
				"beneficiario = "		+ DbTransformar(Benefici�rio) + ", " +
				"beneficiarioParentesco = " + DbTransformar(Benefici�rioParentesco) + ", " +
				"usuario = "	        + DbTransformar(usuario) + ", " +
                "privilegios = "        + DbTransformar(Convert.ToUInt32(privil�gios)) + " " +
				"WHERE codigo = "		+ DbTransformar(C�digo);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Descadastra entidade no banco de dados.
		/// </summary>
		public override void Descadastrar()
		{
			if (tabelaHor�rio != null)
				tabelaHor�rio.Descadastrar();

			base.Descadastrar();
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		protected override void Descadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM funcionario WHERE codigo = " + DbTransformar(C�digo);
			cmd.ExecuteNonQuery();

			if (Transacionando)
				base.Descadastrar(cmd);
		}

		/// <summary>
		/// Atualiza ordem de ordenarPorRod�zio para funcion�rio.
		/// </summary>
		public void AtualizarRod�zio()
		{
			lock (this)
			{
				if (rod�zioAlterado)
				{
					IDbConnection conex�o;

					conex�o = Conex�o;

                    lock (conex�o)
                    {
                        using (IDbCommand cmd = conex�o.CreateCommand())
                        {
                            cmd.CommandText = "UPDATE funcionario SET rodizio = " + DbTransformar(Rod�zio)
                                + " WHERE codigo = " + DbTransformar(C�digo);

                            lock (conex�o)
                                cmd.ExecuteNonQuery();
                        }
                    }
				}

				rod�zioAlterado = false;
			}
		}

        /// <summary>
        /// Atualiza o ramal no banco de dados.
        /// </summary>
        public void AtualizarRamal(int ramal)
        {
            IDbConnection conex�o;

            this.ramal = ramal;

            conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "UPDATE funcionario SET ramal = " + DbTransformar(ramal)
                        + " WHERE codigo = " + DbTransformar(codigo);
                    cmd.ExecuteNonQuery();
                }
        }

        /// <summary>
        /// Grava no banco de dados o estado atual do funcion�rio.
        /// </summary>
        private void AtualizarSitua��o()
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "UPDATE funcionario SET contextoEstado = " + DbTransformar((uint)contextoEstado)
                        + " WHERE codigo = " + DbTransformar(codigo);
                    cmd.ExecuteNonQuery();
                }
        }

        /// <summary>
        /// Verifica a senha no banco de dados.
        /// </summary>
        public void AlterarSenha(string senhaAnterior, string novaSenha)
        {
            IDbConnection conex�o;
            
            conex�o = Usu�rios.Usu�rioAtual.Usu�rios.Conectar(Usu�rios.Usu�rioAtual.Nome, senhaAnterior);

            try
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SET PASSWORD = PASSWORD('" + novaSenha + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conex�o.Close();
            }

            Usu�rios.Usu�rioAtual.GerenciadorConex�es.AlterarSenha(novaSenha);
        }

        /// <summary>
        /// Verifica os privil�gios associados ao funcion�rio
        /// e atribui aqueles s� para interface gr�fica.
        /// </summary>
        private void AdequarPrivil�gios()
        {
            if ((privil�gios & (Permiss�o.ConsignadoDestravar | Permiss�o.ConsignadoRetorno | Permiss�o.ConsignadoSa�da)) > 0)
                privil�gios |= Permiss�o.Consignado;
            else
                privil�gios &= ~Permiss�o.Consignado;

            if ((privil�gios & (Permiss�o.VendasDestravar | Permiss�o.VendasEditar | Permiss�o.VendasLeitura)) > 0)
                privil�gios |= Permiss�o.Vendas;
            else
                privil�gios &= ~Permiss�o.Vendas;
        }

        /// <summary>
        /// Verifica se o nome do usu�rio � v�lido para cria��o.
        /// </summary>
        public static bool ValidarUsu�rio(string usu�rio)
        {
            bool ok = true;
            IDbConnection conex�o;

            /* Caso usu�rio seja igual a "", ent�o ele n�o ter�
             * acesso ao sistema.
             */
            if (usu�rio.Length == 0)
                return true;

            if (usu�rio.ToLower() == "root")
                return false;

            foreach (char c in usu�rio)
                ok &= char.IsLetter(c);

            conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM funcionario WHERE usuario = " + DbTransformar(usu�rio);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        ok = false;
                }
            }

            return ok;
        }

        #endregion

        /// <summary>
        /// Obt�m situa��o atual do funcion�rio por meio do banco de dados.
        /// </summary>
        private void ObterSitua��o()
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    object obj;

                    cmd.CommandText = "SELECT contextoEstado FROM funcionario WHERE codigo = " + DbTransformar(codigo);
                    obj = cmd.ExecuteScalar();

                    contextoEstado = (EstadoFuncion�rio)Enum.ToObject(typeof(EstadoFuncion�rio), obj);
                }
        }

        public static Funcion�rio[] ObterFuncion�riosAtendentes()
        {
            return Mapear<Funcion�rio>(
                "SELECT p.*, pf.*, f.* FROM funcionario f JOIN pessoa p ON f.codigo = p.codigo JOIN pessoafisica pf ON p.codigo = pf.codigo, setor s" +
                " WHERE p.setor = s.codigo AND f.dataSaida IS NULL AND s.atendimento = 1").ToArray();
        }

        public override bool Equals(object obj)
        {
            if (obj is Funcion�rio)
                return this.codigo == ((Funcion�rio)obj).codigo || base.Equals(obj);
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return codigo.GetHashCode();
        }

        internal static Funcion�rio ObterFuncion�rio(IDataReader leitor, int inicioAtributoPesssoa, int inicioAtributoPessoaFisica)
        {
            Funcion�rio entidade = new Funcion�rio();
            entidade.LerAtributos(leitor, inicioAtributoPesssoa, inicioAtributoPessoaFisica);

            return entidade;
        }
    }
}
