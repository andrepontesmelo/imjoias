using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Pessoa.Endereço;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades.Pessoa
{
    [Serializable, DbTransação, Cacheável("ObterPessoaSemCache")]
	public class PessoaFísica : Pessoa
	{
        public new static readonly int TotalAtributos = 11;

        protected Sexo sexo;
		protected string di;
		protected string diEmissor;
		protected string cpf;
		protected DateTime? nascimento;
		protected EstadoCivil estadoCivil;

        [DbRelacionamento("codigo", "naturalidade")]
        protected Localidade naturalidade;
        private ulong naturalidadeCódigo;

		protected string nomePai;
		protected string nomeMae;

        [DbColuna("profissao")]
        protected string profissão;

        public PessoaFísica() { }

        public PessoaFísica(ulong código) : base(código) { }

		#region Getter/Setter

		public Sexo Sexo
		{
			get { return sexo; }
			set { sexo = value; DefinirDesatualizado(); }
		}

        /// <summary>
        /// Documento de identidade.
        /// </summary>
		public string DI
		{
			get { return di; }
            set { di = value; DefinirDesatualizado();  }
		}

		public string DIEmissor
		{
			get { return diEmissor; }
            set { diEmissor = value; DefinirDesatualizado();  }
		}

		public string CPF
		{
			get { return cpf; }
			set
			{
                if (ValidarCPF(value))
                    cpf = LimparFormataçãoCpf(value);
                else
                {
                    throw new Exception("CPF inválido! Por favor, siga o formato \"ddd.ddd.ddd-dd\", onde \"d\" é um dígito.");
                }

                DefinirDesatualizado();
			}
		}

        public static string Formatar(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static bool ValidarCPF(string cpf)
        {
            if (cpf == null || cpf.Trim().Length == 0)
                return true;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = LimparFormataçãoCpf(cpf);

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static string LimparFormataçãoCpf(string cpf)
        {
            if (cpf == null)
                return null;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            return cpf;
        }

        public DateTime? Nascimento
		{
			get { return nascimento; }
            set { nascimento = value; DefinirDesatualizado(); }
		}

		public EstadoCivil EstadoCivil
		{
			get { return estadoCivil; }
            set { estadoCivil = value; DefinirDesatualizado(); }
		}

		public string EstadoCivilTexto
		{
			get
			{
				switch (estadoCivil)
				{
					case EstadoCivil.Casado:
						return Masculino ? "Casado" : "Casada";

					case EstadoCivil.Solteiro:
						return Masculino ? "Solteiro" : "Solteira";

					case EstadoCivil.Divorciado:
						return Masculino ? "Divorciado" : "Divorciada";

					case EstadoCivil.Viuvo:
						return Masculino ? "Viúvo" : "Viúva";

					default:
						return estadoCivil.ToString();
				}
			}
		}

        public Localidade Naturalidade
        {
            get 
            {
                if (naturalidade == null && naturalidadeCódigo > 0)
                    naturalidade = Localidade.ObterLocalidade(naturalidadeCódigo);
               
                return naturalidade; 
            }

            set { naturalidade = value; DefinirDesatualizado(); }
        }

        public string NaturalidadeCidade
		{
			get { return Naturalidade.Nome; }
		}

		public string NaturalidadeEstado
		{
			get { return Naturalidade.Estado.Nome; }
		}

		public string NaturalidadePaís
		{
			get { return Naturalidade.Estado.País.Nome; }
		}
		
		public string NomePai
		{
			get { return nomePai; }
            set { nomePai = value; DefinirDesatualizado(); }
		}

		public string NomeMãe
		{
			get { return nomeMae; }
            set { nomeMae = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Idade da pessoa
		/// </summary>
		public int? Idade
		{
			get
			{
                if (nascimento.HasValue)
                {
                    int idade = DateTime.Now.Year - nascimento.Value.Year;

                    if (nascimento.Value.Month > DateTime.Now.Month)
                        idade--;
                    else if (nascimento.Value.Month == DateTime.Now.Month &&
                        nascimento.Value.Day > DateTime.Now.Day)
                        idade--;

                    return idade;
                }
                else
                    return null;
			}
		}

		public bool Masculino
		{
            get { return sexo == Sexo.Masculino; }
		}

        public bool Feminino
        {
            get { return sexo == Sexo.Feminino; }
        }

        public string Profissão
        {
            get { return profissão; }
            set { profissão = value; DefinirDesatualizado(); }
        }

		#endregion

		#region Recuperação do banco de dados

		/// <summary>
		/// Obtém pessoa a partir do nome.
		/// </summary>
		/// <param name="nome">Nome da pessoa.</param>
		/// <returns>Vetor de pessoas-física e jurídicas.</returns>
		public static PessoaFísica[] ObterPessoas(string nome)
		{
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * FROM pessoa p JOIN pessoafisica pf");
            sql.Append(" ON p.codigo = pf.codigo");
            sql.Append(" WHERE p.nome LIKE '");
            sql.Append(DbTransformar(nome, false));
            sql.Append("%'");

			return Mapear<PessoaFísica>(sql.ToString()).ToArray();
		}

		/// <summary>
		/// Obtém pessoa física a partir do CPF.
		/// </summary>
		/// <param name="cpf">CPF da pessoa-física.</param>
		/// <returns>Pessoa-física.</returns>
        public static PessoaFísica ObterPessoaPorCPF(string cpf)
        {
            if (cpf == null)
                return null;

            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM pessoa p JOIN pessoafisica pf"
                        + " ON p.codigo = pf.codigo"
                        + " WHERE pf.cpf = " + DbTransformar(LimparFormataçãoCpf(cpf));

                    return MapearÚnicaLinha<PessoaFísica>(cmd);
                }
        }

        /// <summary>
        /// Verifica existência de um CPF cadastrado.
        /// </summary>
        /// <param name="cpf">CPF a ser verificado.</param>
        /// <returns>Se existe um cadastro com este CPF.</returns>
        public static bool VerificarExistênciaCPF(string cpf)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM pessoafisica"
                        + " WHERE cpf = " + DbTransformar(LimparFormataçãoCpf(cpf));

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
        }

		/// <summary>
		/// Obtém pessoa física a partir do DI.
		/// </summary>
		/// <param name="di">DI da pessoa-física.</param>
		/// <returns>Pessoa-física.</returns>
        public static List<Pessoa> ObterPessoasPorRG(string di)
		{
			string comando = "SELECT p.* FROM pessoa p JOIN pessoafisica pf"
				+ " ON p.codigo = pf.codigo"
                + " WHERE  replace(replace(replace(replace(pf.di,'.',''),',',''),'-',''),' ','') LIKE '%" + di + "%'";

			return Mapear<Pessoa>(comando);
		}

		/// <summary>
		/// Obtém uma pessoa a partir de um código.
		/// </summary>
		/// <param name="código">Código da pessoa.</param>
		/// <returns>Retorna uma pessoa-física.</returns>
		public new static PessoaFísica ObterPessoa(ulong código)
		{
            return (PessoaFísica) CacheDb.Instância.ObterEntidade(typeof(PessoaFísica), código);
        }

        public new static PessoaFísica ObterPessoaSemCache(ulong código)
        {
            return Pessoa.ObterPessoaSemCache(código) as PessoaFísica;
        }

        /// <summary>
        /// 07676631602
        /// </summary>
        /// <param name="cpfNãoFormatado"></param>
        /// <returns></returns>
        private static string FormatarCPF(string cpfNãoFormatado)
        {
            string cpfFormatado = cpfNãoFormatado.Replace(".", "").Replace("-", "").Trim();
            
            // Coloca espaços vazios até o final do CPF caso esteja incompleto
            if (cpfFormatado.Length != 11 && cpfFormatado.Length < 11)
                cpfFormatado = cpfFormatado + new String(' ', 11 - cpfFormatado.Length);


            return cpfFormatado.Substring(0, 3) + "." +
                cpfFormatado.Substring(3, 3) + "." + 
                cpfFormatado.Substring(6, 3) + "-" +
                cpfFormatado.Substring(9, 2);
        }
		#endregion

		#region Atualização do banco de dados

		/// <summary>
		/// Cadastra a entidade no banco de dados.
		/// </summary>
		protected override void Cadastrar(IDbCommand cmd)
		{
			if (Transacionando)
				base.Cadastrar(cmd);

            if (naturalidade != null && !naturalidade.Cadastrado && naturalidade.Nome != null && Naturalidade.Nome != null)
                CadastrarEntidade(cmd, naturalidade);
            else if (naturalidade != null && !naturalidade.Cadastrado)
                naturalidade = null;

			cmd.CommandText = "INSERT INTO pessoafisica (codigo, sexo, di, diEmissor, cpf, " +
				"nascimento, estadoCivil, naturalidade, nomePai, nomeMae, profissao) VALUES (" +
				DbTransformar(Código) + ", " +
				DbTransformar(Sexo) + ", " +
				DbTransformar(DI) + ", " +
				DbTransformar(DIEmissor) + ", " +
				DbTransformar(CPF) + ", " + 
				DbTransformar(Nascimento) + ", " +
				DbTransformar(EstadoCivil) + ", " +
				(Naturalidade != null ? DbTransformar(Naturalidade.Código) : DbTransformar((string)null)) + ", " +
				DbTransformar(NomePai) + ", " +
                DbTransformar(NomeMãe) + ", " +
				DbTransformar(Profissão) + ")";

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Atualiza a entidade no banco de dados.
		/// </summary>
		protected override void Atualizar(IDbCommand cmd)
		{
			if (Transacionando)
				base.Atualizar(cmd);

            if (Naturalidade != null && !Naturalidade.Cadastrado && Naturalidade.Nome != null)
                CadastrarEntidade(cmd, Naturalidade);
            else if (naturalidade != null && !naturalidade.Cadastrado)
                naturalidade = null;

			cmd.CommandText = "UPDATE pessoafisica SET " +
				"sexo = " + DbTransformar(Sexo) + ", " +
				"di = " + DbTransformar(DI) + ", " +
				"diEmissor = " + DbTransformar(DIEmissor) + ", " +
				"cpf = " + DbTransformar(CPF) + ", " + 
				"nascimento = " + DbTransformar(Nascimento) + ", " +
				"estadoCivil = " + DbTransformar(EstadoCivil) + ", " +
				"naturalidade = " + (Naturalidade == null ? DbTransformar((string)null) : DbTransformar(Naturalidade.Código)) + ", " +
				"nomePai = " + DbTransformar(NomePai) + ", " +
				"nomeMae = " + DbTransformar(NomeMãe) + ", " +
                "profissao = " + DbTransformar(profissão) + " " +
				"WHERE codigo = " + DbTransformar(Código);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		protected override void Descadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM pessoafisica WHERE codigo = " + DbTransformar(Código);
			cmd.ExecuteNonQuery();

			if (Transacionando)
				base.Descadastrar(cmd);
		}

		#endregion


        /// <summary>
        /// Obtem uma pessoafísica através do resultado de um comando com joins das tabelas pessoa e pessoafisica.
        /// Por enquanto, este método só utilizado para obtenção das pessoas para listagem dos acertos pendentes.
        /// Como nesta tela poucas informações são mostradas, 
        /// por desempenho apenas os atributos mostrados são carregados.
        /// Cada leitura do reader é muito lento.
        /// 
        /// As entidades não são utilizadas em outras telas, nem persistidas em cache, o que seria um problema, do tipo: 
        /// o usuário pode para alterar o cadastro e este estar incompleto.
        /// </summary>
        internal static PessoaFísica Obter(IDataReader leitor, int inicioAtributoPesssoa, int inicioAtributoPessoaFisica)
        {
            PessoaFísica entidade = new PessoaFísica();
            entidade.LerAtributos(leitor, inicioAtributoPesssoa, inicioAtributoPessoaFisica);
            entidade.DefinirCadastrado();
            entidade.DefinirAtualizado();
            return entidade;
        }

        protected virtual void LerAtributos(IDataReader leitor, int inicioAtributoPessoa, int inicioAtributoPessoaFisica)
        {
            base.LerAtributos(leitor, inicioAtributoPessoa);

            codigo = (uint) leitor.GetInt32(inicioAtributoPessoaFisica);

            if (leitor[inicioAtributoPessoaFisica + 1] != DBNull.Value)
                sexo = (Sexo)(new ConversorDbSexo().ConverterDeDB(leitor[inicioAtributoPessoaFisica + 1].ToString()));

            if (leitor[inicioAtributoPessoaFisica + 2] != DBNull.Value)
                di = leitor.GetString(inicioAtributoPessoaFisica + 2);

            if (leitor[inicioAtributoPessoaFisica + 3] != DBNull.Value)
                diEmissor = leitor.GetString(inicioAtributoPessoaFisica + 3);

            if (leitor[inicioAtributoPessoaFisica + 4] != DBNull.Value)
                cpf = leitor.GetString(inicioAtributoPessoaFisica + 4);

            if (leitor[inicioAtributoPessoaFisica + 5] != DBNull.Value)
                nascimento = leitor.GetDateTime(inicioAtributoPessoaFisica + 5);

            if (leitor[inicioAtributoPessoaFisica + 6] != DBNull.Value)
                estadoCivil = (EstadoCivil)new ConversorDbEstadoCivil().ConverterDeDB(leitor[inicioAtributoPessoaFisica + 6]);

            if (leitor[inicioAtributoPessoaFisica + 7] != DBNull.Value)
                nomePai = leitor.GetString(inicioAtributoPessoaFisica + 7);

            if (leitor[inicioAtributoPessoaFisica + 8] != DBNull.Value)
                nomeMae = leitor.GetString(inicioAtributoPessoaFisica + 8);

            if (leitor[inicioAtributoPessoaFisica + 9] != DBNull.Value)
                naturalidadeCódigo = (ulong) leitor.GetInt64(inicioAtributoPessoaFisica + 9);

            if (leitor[inicioAtributoPessoaFisica + 10] != DBNull.Value)
                profissão = leitor.GetString(inicioAtributoPessoaFisica + 10);

        }
    }
}
