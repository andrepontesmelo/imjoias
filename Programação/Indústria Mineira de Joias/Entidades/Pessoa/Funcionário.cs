using System;
using System.Data;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Privilégio;
using System.Collections.Generic;

namespace Entidades.Pessoa
{
    [Serializable, DbTransação, Cacheável("ObterPessoaSemCache", "ObterFuncionárioPorUsuárioSemCache", "ObterFuncionárioSemCache")]
	[NãoCopiarCache, Validade(6, 0, 0)]
    public class Funcionário : PessoaFísica
	{
        private TimeSpan tempoAtualizaçãoSituação = new TimeSpan(0, 1, 00);

		private bool rodízioAlterado = false;

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

        private DateTime últimaAtualizaçãoSituação = DateTime.Now;

        /// <summary>
        /// Permissão do funcionário.
        /// </summary>
        [DbColuna("privilegios")]
        private Permissão privilégios;

        /// <summary>
        /// Estado do funcionário.
        /// </summary>
        private EstadoFuncionário contextoEstado;
		
		/// <summary>
		/// Tabela de horário.
		/// </summary>
		[DbAtributo(TipoAtributo.Ignorar)]
		protected TabelaHorário tabelaHorário = null;

		#region Construtoras
		
		public Funcionário() {}
        public Funcionário(ulong código) : base(código) { }

		
		#endregion

		#region Propriedades

        /// <summary>
        /// Verifica se o funcionário está atendendo.
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
        /// Funcionário que está logado no programa.
        /// </summary>
        public static Funcionário FuncionárioAtual
        {
            get
            {
                return ObterFuncionárioPorUsuário
                    (Acesso.Comum.Usuários.UsuárioAtual.Nome);
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

		public double Salário
		{
			get { return salario; }
            set { salario = value; DefinirDesatualizado(); }
		}

		public string SalárioExtenso
		{
			get { return NúmeroExtenso.Transformar((decimal) salario); }
		}

		public string CarteiraProfissional
		{
			get { return carteiraProfissional; }
            set { carteiraProfissional = value; DefinirDesatualizado(); }
		}

		public string CarteiraProfissionalSérie
		{
			get { return carteiraProfissionalSerie; }
            set { carteiraProfissionalSerie = value; DefinirDesatualizado(); }
		}

		public string Reservista
		{
			get { return reservista; }
            set { reservista = value; DefinirDesatualizado(); }
		}

		public string ReservistaSérie
		{
			get { return reservistaSerie; }
            set { reservistaSerie = value; DefinirDesatualizado(); }
		}

		public string ReservistaCategoria
		{
			get { return reservistaCategoria; }
            set { reservistaCategoria = value; DefinirDesatualizado(); }
		}

		public DateTime DataAdmissão
		{
			get { return dataAdmissao; }
            set { dataAdmissao = value; DefinirDesatualizado(); }
		}

		public DateTime? DataSaída
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

		public string TítuloEleitor
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

		public uint Rodízio
		{
			get { return rodizio; }
			set
			{
				rodízioAlterado = rodizio != value;
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

		public string Beneficiário
		{
			get { return beneficiario; }
            set { beneficiario = value; DefinirDesatualizado(); }
		}

		public string BeneficiárioParentesco
		{
			get { return beneficiarioParentesco; }
            set { beneficiarioParentesco = value; DefinirDesatualizado(); }
		}

		public string Usuário
		{
			get { return usuario; }
            set { usuario = value; DefinirDesatualizado(); }
		}

        /// <summary>
        /// Privilégios do funcionário para acesso ao sistema.
        /// </summary>
        public Permissão Privilégios
        {
            get { return privilégios; }
            set { privilégios = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Situação do funcionário na empresa. A alteração deste valor
        /// implica em atualização imediata do banco de dados.
        /// </summary>
        public EstadoFuncionário Situação
        {
            get
            {
                if (DateTime.Now - últimaAtualizaçãoSituação > tempoAtualizaçãoSituação)
                    ObterSituação();

                return contextoEstado;
            }
            set
            {
                contextoEstado = value;

                if (Cadastrado)
                    AtualizarSituação();
            }
        }

		public TabelaHorário TabelaHorário
		{
			get
			{
				if (tabelaHorário == null)
					tabelaHorário = new TabelaHorário(this);

				return tabelaHorário;
			}
		}

        /// <summary>
        /// Carga horária semanal aproximada.
        /// </summary>
        public uint CargaHoráriaSemanal
        {
            get
            {
                return tabelaHorário.CalcularCargaHoráriaSemanal();
            }
        }

		/// <summary>
		/// Constrói uma tabela de horário vazia para ser preenchida na leitura
		/// do banco de dados.
		/// </summary>
		internal void CriarTabelaHorárioVazia()
		{
			tabelaHorário = new TabelaHorário();
		}

		#endregion

		#region Recuperação de Dados

        /// <summary>
        /// Obtém atendentes de um setor específico.
        /// </summary>
        /// <param name="setor">Setor cujos atendentes serão recuperados.</param>
        /// <returns>Vetor de atendentes ordenado pelo rodízio.</returns>
        public static Funcionário[] ObterFuncionários(Setor setor)
        {
            return Mapear<Funcionário>(
                "SELECT * FROM funcionario f JOIN pessoafisica pf ON f.codigo = pf.codigo JOIN pessoa p ON pf.codigo = p.codigo WHERE setor = " + DbTransformar(setor.Código) +
                " AND dataSaida IS NULL ORDER BY rodizio").ToArray();
        }

		/// <summary>
		/// Obtém nomes do banco de dados de funcionários
		/// </summary>
		/// <param name="nomeBase">Nome de base para pesquisa</param>
		/// <param name="limite">Limite de nomes</param>
		/// <returns>Lista de nomes</returns>
        public static new string[] ObterNomes(string nomeBase, int limite)
        {
            IDbConnection conexão;

            conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
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
                         * Pesquisar demais nomes, se necessário
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
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }
        }

        public static List<Pessoa> ObterFuncionários(string nomeBase, int limite)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
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
                     * Pesquisar demais nomes, se necessário
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
        /// Recupera funcionários do banco de dados.
        /// </summary>
        /// <param name="ativos">
        /// Determina se deve recuperar somente
        /// funcionários ativos.
        /// </param>
        /// <param name="ordenarPorRodízio">
        /// Determina se deve ordenar por ordenarPorRodízio.
        /// </param>
        /// <returns></returns>
		public static List<Funcionário> ObterFuncionários(bool ativos, bool ordenarPorRodízio)
		{
			IDbConnection conexão = Conexão;

			lock (conexão)
			{
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.*, pf.*, f.*, e.nome AS empresaNome"
                        + " FROM pessoa p, pessoafisica pf, funcionario f, pessoa e"
                        + " WHERE p.codigo = f.codigo AND f.codigo = pf.codigo"
                        + " AND f.empresa = e.codigo";

                    if (ativos)
                        cmd.CommandText += " AND dataSaida IS NULL";

                    if (ordenarPorRodízio)
                        cmd.CommandText += " ORDER BY rodizio";

                    return Mapear<Entidades.Pessoa.Funcionário>(cmd);
                }
			}
		}

        public static List<Funcionário> ObterFuncionários()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.*, pf.*, f.*, e.nome AS empresaNome"
                        + " FROM pessoa p, pessoafisica pf, funcionario f, pessoa e"
                        + " WHERE p.codigo = f.codigo AND f.codigo = pf.codigo"
                        + " AND f.empresa = e.codigo";

                    return Mapear<Entidades.Pessoa.Funcionário>(cmd);
                }
            }
        }

        /// <summary>
        /// Realiza uma consulta.
        /// Um vendedor é aquela pessoa que tem pelo menos uma venda no banco sendo ela vendedor rs
        /// </summary>
        public static bool ÉVendedor(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT count(*) FROM venda where vendedor=" + DbTransformar(pessoa.Código);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private static SortedSet<ulong> lstCódigosFuncionários = null;

        public static bool ÉFuncionárioOuRepresentante(Entidades.Pessoa.Pessoa pessoa)
        {
            return ÉFuncionário(pessoa) || Representante.ÉRepresentante(pessoa);
        }
        /// <summary>
        /// Verifica se uma pessoa é funcionário.
        /// Desconsidera data demissão.
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static bool ÉFuncionário(Entidades.Pessoa.Pessoa pessoa)
        {
            if (lstCódigosFuncionários == null)
            {
                lstCódigosFuncionários = new SortedSet<ulong>();

                IDbConnection conexão = Conexão;

                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "SELECT codigo FROM funcionario";

                        using (IDataReader leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                lstCódigosFuncionários.Add((ulong)leitor.GetInt64(0));
                            }
                        }
                    }
                }

            }

            return lstCódigosFuncionários.Contains(pessoa.Código);
        }

        /// <summary>
        /// Obtém uma pessoa a partir de um código.
        /// </summary>
        /// <param name="código">Código da pessoa.</param>
        /// <returns>Retorna uma pessoa-física.</returns>
        public new static Funcionário ObterPessoa(ulong código)
        {
            //return Acesso.Comum.Cache.CacheDb.Instância.ObterEntidade(typeof(Funcionário), código) as Funcionário;
            if (hashFuncionários == null)
                ConstruirHashFuncionários();

            Funcionário encontrado = null;
            hashFuncionários.TryGetValue(código, out encontrado);
            return encontrado;
        }

        private static Dictionary<ulong, Funcionário> hashFuncionários = null;
        private static void ConstruirHashFuncionários()
        {
            List<Funcionário> funcionários = ObterFuncionários();
            hashFuncionários = new Dictionary<ulong, Funcionário>(funcionários.Count);
            foreach (Funcionário f in funcionários)
                hashFuncionários[f.Código] = f;
        }


        public static Funcionário ObterPessoa(string nome)
        {
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND p.nome = " + DbTransformar(nome);

            return MapearÚnicaLinha<Funcionário>(comando);
        }

        public new static Funcionário ObterPessoaSemCache(ulong código)
		{
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND p.codigo = " + DbTransformar(código);

            return MapearÚnicaLinha<Funcionário>(comando);
		}

        /// <summary>
        /// Obtém uma pessoa a partir de um código.
        /// </summary>
        /// <param name="código">Código da pessoa.</param>
        /// <returns>Retorna um funcionário.</returns>
        private static Funcionário ObterFuncionário(ulong código)
        {
            return Acesso.Comum.Cache.CacheDb.Instância.ObterEntidade(typeof(Funcionário), código) as Funcionário;
        }

        private static Funcionário ObterFuncionárioSemCache(ulong código)
        {
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND p.codigo = " + DbTransformar(código);

            return MapearÚnicaLinha<Funcionário>(comando);
        }

        /// <summary>
        /// Obtém uma pessoa a partir do usuário.
        /// </summary>
        /// <param name="usuário">Usuário.</param>
        /// <returns>Retorna um funcionário.</returns>
        public static Funcionário ObterFuncionárioPorUsuário(string usuário)
        {
            return Acesso.Comum.Cache.CacheDb.Instância.ObterEntidade(typeof(Funcionário), usuário) as Funcionário;
        }

        public static Funcionário ObterFuncionárioPorUsuárioSemCache(string usuário)
        {
            string comando = "SELECT * FROM pessoa p, pessoafisica pf, funcionario f"
                + " WHERE p.codigo = pf.codigo AND f.codigo = pf.codigo"
                + " AND f.usuario = " + DbTransformar(usuário);

            return MapearÚnicaLinha<Funcionário>(comando);
        }

        /// <summary>
        /// Recupera o nome da empresa.
        /// </summary>
        /// <returns>Nome da empresa.</returns>
        private string RecuperarNomeEmpresa()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT nome FROM pessoa WHERE codigo = " + DbTransformar(empresa);

                    return empresaNome = Convert.ToString(cmd.ExecuteScalar());
                }
            }
        }

		#endregion

		#region Recuperação por cast e cache

		public static implicit operator Funcionário(long código)
		{
			return Funcionário.ObterPessoa(Convert.ToUInt64(código));
		}

        public static implicit operator Funcionário(ulong código)
        {
            return Funcionário.ObterPessoa(código);
        }

		public static implicit operator Funcionário(uint código)
		{
			return Funcionário.ObterPessoa(código);
		}

		public static implicit operator Funcionário(int código)
		{
		    return Funcionário.ObterPessoa(Convert.ToUInt64(código));
        }

        // Não é intuitivo e sugeito a erros:
        //public static implicit operator Funcionário(string nomeUsuário)
        //{
        //    return Funcionário.ObterFuncionárioPorUsuário(nomeUsuário);
        //}

		#endregion

		public static TimeSpan ConverterHorário(string horário, bool primeiro)
		{
			try
			{
				char [] separadores = new char [] { ' ', '-' };

				if (primeiro)
					horário = horário.Substring(0, horário.IndexOfAny(separadores));
				else
					horário = horário.Substring(horário.LastIndexOfAny(separadores));

				return TimeSpan.Parse(horário);
			}
			catch
			{
				return new TimeSpan(0);
			}
		}

		#region Atualização do banco de dados

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		public override void Cadastrar()
		{
			base.Cadastrar();

			if (tabelaHorário != null)
				tabelaHorário.Cadastrar();
		}

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            if (Transacionando)
                base.Cadastrar(cmd);

            AdequarPrivilégios();

            if (Usuário != null && Usuário.Length > 0 && ValidarUsuário(Usuário))
            {
                cmd.CommandText = "INSERT INTO funcionario (codigo, empresa, ficha, salario, " +
                "cargo, carteiraProfissional, carteiraProfissionalSerie, " +
                "reservista, reservistaSerie, reservistaCategoria, " +
                "dataAdmissao, dataSaida, pis, " +
                "cbo, tituloEleitor, ramal, rodizio, " +
                "beneficiario, beneficiarioParentesco, " +
                "usuario, privilegios) VALUES " +
                "(" + DbTransformar(Código) + ", " +
                DbTransformar(Empresa) + ", " +
                DbTransformar(Ficha) + ", " +
                DbTransformar(Salário) + ", " +
                DbTransformar(Cargo) + ", " +
                DbTransformar(CarteiraProfissional) + ", " +
                DbTransformar(CarteiraProfissionalSérie) + ", " +
                DbTransformar(Reservista) + ", " +
                DbTransformar(ReservistaSérie) + ", " +
                DbTransformar(ReservistaCategoria) + ", " +
                DbTransformar(DataAdmissão) + ", " +
                (DataSaída < DataAdmissão ? "NULL, " :
                DbTransformar(DataSaída) + ", ") +
                DbTransformar(PIS) + ", " +
                DbTransformar(CBO) + ", " +
                DbTransformar(TítuloEleitor) + ", " +
                DbTransformar(Ramal) + ", " +
                DbTransformar(Rodízio) + ", " +
                DbTransformar(Beneficiário) + ", " +
                DbTransformar(BeneficiárioParentesco) + ", " +
                DbTransformar(Usuário) + ", " +
                DbTransformar(Convert.ToInt32(Privilégios)) +
                ")";

                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE USER '"
                    + Usuário + "'@'%'";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "CREATE USER '"
                //    + Usuário + "'@'192.168.1.%'";
                //cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT CREATE USER ON *.* TO '"
                //        + Usuário + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT CREATE USER ON *.* TO '"
                        + Usuário + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT RELOAD ON *.* TO '"
                        + Usuário + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT RELOAD ON *.* TO '"
                //    + Usuário + "'@'192.168.1.%' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

//#if DEBUG
//                string tabela = "`imjoias-desenv`";
//#else
                string tabela = "imjoias";
//#endif

                //cmd.CommandText = "GRANT SELECT,INSERT,UPDATE,DELETE,LOCK TABLES,EXECUTE ON " + tabela + ".* TO '"
                //    + Usuário + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT SELECT,INSERT,UPDATE,DELETE,LOCK TABLES,EXECUTE ON " + tabela + ".* TO '"
                    + Usuário + "'@'%'  WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularcomissao TO '"
                //    + Usuário + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularcomissao TO '"
                    + Usuário + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularvendavalortotal TO '"
                //    + Usuário + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT EXECUTE ON PROCEDURE calcularvendavalortotal TO '"
                    + Usuário + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "GRANT EXECUTE ON FUNCTION ranking_mercadoria TO '"
                    + Usuário + "'@'%' WITH GRANT OPTION";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "GRANT EXECUTE ON FUNCTION ranking_mercadoria TO '"
                //    + Usuário + "'@'localhost' WITH GRANT OPTION";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "FLUSH PRIVILEGES";
                cmd.ExecuteNonQuery();
            }
            else if (Usuário != null)
                throw new ApplicationException("Usuário já encontra-se cadastrado!");
        }

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		public override void Atualizar()
		{
			if (rodízioAlterado && Atualizado)
				AtualizarRodízio();
			else
				base.Atualizar();

			if (tabelaHorário != null)
				tabelaHorário.Atualizar();
		}

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		/// <param name="cmd">Comando para atualização.</param>
		protected override void Atualizar(IDbCommand cmd)
		{
			if (Transacionando)
				base.Atualizar(cmd);

            AdequarPrivilégios();

            cmd.CommandText = "UPDATE funcionario SET " +
				"ficha = "				+ DbTransformar(Ficha) + ", " +
				"empresa = "			+ DbTransformar(Empresa) + ", " +
				"cargo = "				+ DbTransformar(Cargo) + ", " +
				"salario = "			+ DbTransformar(Salário) + ", " +
				"carteiraProfissional = " + DbTransformar(CarteiraProfissional) + ", " +
				"carteiraProfissionalSerie = " + DbTransformar(CarteiraProfissionalSérie) + ", " +
				"reservista = "			+ DbTransformar(Reservista) + ", " +
				"reservistaSerie = "	+ DbTransformar(ReservistaSérie) + ", " +
				"reservistaCategoria = " + DbTransformar(ReservistaCategoria) + ", " +
				"dataAdmissao = "		+ DbTransformar(DataAdmissão) + ", " + 
				(DataSaída < DataSaída ? "dataSaida = NULL, " :
				"dataSaida = "			+ DbTransformar(DataSaída) + ", ") + 
				"pis = "				+ DbTransformar(PIS) + ", " +
				"cbo = "				+ DbTransformar(CBO) + ", " +
				"tituloEleitor = "		+ DbTransformar(TítuloEleitor) + ", " +
				"ramal = "				+ DbTransformar(Ramal) + ", " +
				"rodizio = "			+ DbTransformar(Rodízio) + ", " +
				"beneficiario = "		+ DbTransformar(Beneficiário) + ", " +
				"beneficiarioParentesco = " + DbTransformar(BeneficiárioParentesco) + ", " +
				"usuario = "	        + DbTransformar(usuario) + ", " +
                "privilegios = "        + DbTransformar(Convert.ToUInt32(privilégios)) + " " +
				"WHERE codigo = "		+ DbTransformar(Código);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Descadastra entidade no banco de dados.
		/// </summary>
		public override void Descadastrar()
		{
			if (tabelaHorário != null)
				tabelaHorário.Descadastrar();

			base.Descadastrar();
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		protected override void Descadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM funcionario WHERE codigo = " + DbTransformar(Código);
			cmd.ExecuteNonQuery();

			if (Transacionando)
				base.Descadastrar(cmd);
		}

		/// <summary>
		/// Atualiza ordem de ordenarPorRodízio para funcionário.
		/// </summary>
		public void AtualizarRodízio()
		{
			lock (this)
			{
				if (rodízioAlterado)
				{
					IDbConnection conexão;

					conexão = Conexão;

                    lock (conexão)
                    {
                        using (IDbCommand cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = "UPDATE funcionario SET rodizio = " + DbTransformar(Rodízio)
                                + " WHERE codigo = " + DbTransformar(Código);

                            lock (conexão)
                                cmd.ExecuteNonQuery();
                        }
                    }
				}

				rodízioAlterado = false;
			}
		}

        /// <summary>
        /// Atualiza o ramal no banco de dados.
        /// </summary>
        public void AtualizarRamal(int ramal)
        {
            IDbConnection conexão;

            this.ramal = ramal;

            conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "UPDATE funcionario SET ramal = " + DbTransformar(ramal)
                        + " WHERE codigo = " + DbTransformar(codigo);
                    cmd.ExecuteNonQuery();
                }
        }

        /// <summary>
        /// Grava no banco de dados o estado atual do funcionário.
        /// </summary>
        private void AtualizarSituação()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
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
            IDbConnection conexão;
            
            conexão = Usuários.UsuárioAtual.Usuários.Conectar(Usuários.UsuárioAtual.Nome, senhaAnterior);

            try
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SET PASSWORD = PASSWORD('" + novaSenha + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexão.Close();
            }

            Usuários.UsuárioAtual.GerenciadorConexões.AlterarSenha(novaSenha);
        }

        /// <summary>
        /// Verifica os privilégios associados ao funcionário
        /// e atribui aqueles só para interface gráfica.
        /// </summary>
        private void AdequarPrivilégios()
        {
            if ((privilégios & (Permissão.ConsignadoDestravar | Permissão.ConsignadoRetorno | Permissão.ConsignadoSaída)) > 0)
                privilégios |= Permissão.Consignado;
            else
                privilégios &= ~Permissão.Consignado;

            if ((privilégios & (Permissão.VendasDestravar | Permissão.VendasEditar | Permissão.VendasLeitura)) > 0)
                privilégios |= Permissão.Vendas;
            else
                privilégios &= ~Permissão.Vendas;
        }

        /// <summary>
        /// Verifica se o nome do usuário é válido para criação.
        /// </summary>
        public static bool ValidarUsuário(string usuário)
        {
            bool ok = true;
            IDbConnection conexão;

            /* Caso usuário seja igual a "", então ele não terá
             * acesso ao sistema.
             */
            if (usuário.Length == 0)
                return true;

            if (usuário.ToLower() == "root")
                return false;

            foreach (char c in usuário)
                ok &= char.IsLetter(c);

            conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM funcionario WHERE usuario = " + DbTransformar(usuário);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        ok = false;
                }
            }

            return ok;
        }

        #endregion

        /// <summary>
        /// Obtém situação atual do funcionário por meio do banco de dados.
        /// </summary>
        private void ObterSituação()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    object obj;

                    cmd.CommandText = "SELECT contextoEstado FROM funcionario WHERE codigo = " + DbTransformar(codigo);
                    obj = cmd.ExecuteScalar();

                    contextoEstado = (EstadoFuncionário)Enum.ToObject(typeof(EstadoFuncionário), obj);
                }
        }

        public static Funcionário[] ObterFuncionáriosAtendentes()
        {
            return Mapear<Funcionário>(
                "SELECT p.*, pf.*, f.* FROM funcionario f JOIN pessoa p ON f.codigo = p.codigo JOIN pessoafisica pf ON p.codigo = pf.codigo, setor s" +
                " WHERE p.setor = s.codigo AND f.dataSaida IS NULL AND s.atendimento = 1").ToArray();
        }

        public override bool Equals(object obj)
        {
            if (obj is Funcionário)
                return this.codigo == ((Funcionário)obj).codigo || base.Equals(obj);
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return codigo.GetHashCode();
        }

        internal static Funcionário ObterFuncionário(IDataReader leitor, int inicioAtributoPesssoa, int inicioAtributoPessoaFisica)
        {
            Funcionário entidade = new Funcionário();
            entidade.LerAtributos(leitor, inicioAtributoPesssoa, inicioAtributoPessoaFisica);

            return entidade;
        }
    }
}
