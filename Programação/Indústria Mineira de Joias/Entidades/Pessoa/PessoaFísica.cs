using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Pessoa.Endere�o;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades.Pessoa
{
    [Serializable, DbTransa��o, Cache�vel("ObterPessoaSemCache")]
	public class PessoaF�sica : Pessoa
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
        private ulong naturalidadeC�digo;

		protected string nomePai;
		protected string nomeMae;

        [DbColuna("profissao")]
        protected string profiss�o;

        public PessoaF�sica() { }

        public PessoaF�sica(ulong c�digo) : base(c�digo) { }

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
                    cpf = LimparFormata��oCpf(value);
                else
                {
                    throw new Exception("CPF inv�lido! Por favor, siga o formato \"ddd.ddd.ddd-dd\", onde \"d\" � um d�gito.");
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

            cpf = LimparFormata��oCpf(cpf);

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

        public static string LimparFormata��oCpf(string cpf)
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
						return Masculino ? "Vi�vo" : "Vi�va";

					default:
						return estadoCivil.ToString();
				}
			}
		}

        public Localidade Naturalidade
        {
            get 
            {
                if (naturalidade == null && naturalidadeC�digo > 0)
                    naturalidade = Localidade.ObterLocalidade(naturalidadeC�digo);
               
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

		public string NaturalidadePa�s
		{
			get { return Naturalidade.Estado.Pa�s.Nome; }
		}
		
		public string NomePai
		{
			get { return nomePai; }
            set { nomePai = value; DefinirDesatualizado(); }
		}

		public string NomeM�e
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

        public string Profiss�o
        {
            get { return profiss�o; }
            set { profiss�o = value; DefinirDesatualizado(); }
        }

		#endregion

		#region Recupera��o do banco de dados

		/// <summary>
		/// Obt�m pessoa a partir do nome.
		/// </summary>
		/// <param name="nome">Nome da pessoa.</param>
		/// <returns>Vetor de pessoas-f�sica e jur�dicas.</returns>
		public static PessoaF�sica[] ObterPessoas(string nome)
		{
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * FROM pessoa p JOIN pessoafisica pf");
            sql.Append(" ON p.codigo = pf.codigo");
            sql.Append(" WHERE p.nome LIKE '");
            sql.Append(DbTransformar(nome, false));
            sql.Append("%'");

			return Mapear<PessoaF�sica>(sql.ToString()).ToArray();
		}

		/// <summary>
		/// Obt�m pessoa f�sica a partir do CPF.
		/// </summary>
		/// <param name="cpf">CPF da pessoa-f�sica.</param>
		/// <returns>Pessoa-f�sica.</returns>
        public static PessoaF�sica ObterPessoaPorCPF(string cpf)
        {
            if (cpf == null)
                return null;

            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM pessoa p JOIN pessoafisica pf"
                        + " ON p.codigo = pf.codigo"
                        + " WHERE pf.cpf = " + DbTransformar(LimparFormata��oCpf(cpf));

                    return Mapear�nicaLinha<PessoaF�sica>(cmd);
                }
        }

        /// <summary>
        /// Verifica exist�ncia de um CPF cadastrado.
        /// </summary>
        /// <param name="cpf">CPF a ser verificado.</param>
        /// <returns>Se existe um cadastro com este CPF.</returns>
        public static bool VerificarExist�nciaCPF(string cpf)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM pessoafisica"
                        + " WHERE cpf = " + DbTransformar(LimparFormata��oCpf(cpf));

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
        }

		/// <summary>
		/// Obt�m pessoa f�sica a partir do DI.
		/// </summary>
		/// <param name="di">DI da pessoa-f�sica.</param>
		/// <returns>Pessoa-f�sica.</returns>
        public static List<Pessoa> ObterPessoasPorRG(string di)
		{
			string comando = "SELECT p.* FROM pessoa p JOIN pessoafisica pf"
				+ " ON p.codigo = pf.codigo"
                + " WHERE  replace(replace(replace(replace(pf.di,'.',''),',',''),'-',''),' ','') LIKE '%" + di + "%'";

			return Mapear<Pessoa>(comando);
		}

		/// <summary>
		/// Obt�m uma pessoa a partir de um c�digo.
		/// </summary>
		/// <param name="c�digo">C�digo da pessoa.</param>
		/// <returns>Retorna uma pessoa-f�sica.</returns>
		public new static PessoaF�sica ObterPessoa(ulong c�digo)
		{
            return (PessoaF�sica) CacheDb.Inst�ncia.ObterEntidade(typeof(PessoaF�sica), c�digo);
        }

        public new static PessoaF�sica ObterPessoaSemCache(ulong c�digo)
        {
            return Pessoa.ObterPessoaSemCache(c�digo) as PessoaF�sica;
        }

        /// <summary>
        /// 07676631602
        /// </summary>
        /// <param name="cpfN�oFormatado"></param>
        /// <returns></returns>
        private static string FormatarCPF(string cpfN�oFormatado)
        {
            string cpfFormatado = cpfN�oFormatado.Replace(".", "").Replace("-", "").Trim();
            
            // Coloca espa�os vazios at� o final do CPF caso esteja incompleto
            if (cpfFormatado.Length != 11 && cpfFormatado.Length < 11)
                cpfFormatado = cpfFormatado + new String(' ', 11 - cpfFormatado.Length);


            return cpfFormatado.Substring(0, 3) + "." +
                cpfFormatado.Substring(3, 3) + "." + 
                cpfFormatado.Substring(6, 3) + "-" +
                cpfFormatado.Substring(9, 2);
        }
		#endregion

		#region Atualiza��o do banco de dados

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
				DbTransformar(C�digo) + ", " +
				DbTransformar(Sexo) + ", " +
				DbTransformar(DI) + ", " +
				DbTransformar(DIEmissor) + ", " +
				DbTransformar(CPF) + ", " + 
				DbTransformar(Nascimento) + ", " +
				DbTransformar(EstadoCivil) + ", " +
				(Naturalidade != null ? DbTransformar(Naturalidade.C�digo) : DbTransformar((string)null)) + ", " +
				DbTransformar(NomePai) + ", " +
                DbTransformar(NomeM�e) + ", " +
				DbTransformar(Profiss�o) + ")";

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
				"naturalidade = " + (Naturalidade == null ? DbTransformar((string)null) : DbTransformar(Naturalidade.C�digo)) + ", " +
				"nomePai = " + DbTransformar(NomePai) + ", " +
				"nomeMae = " + DbTransformar(NomeM�e) + ", " +
                "profissao = " + DbTransformar(profiss�o) + " " +
				"WHERE codigo = " + DbTransformar(C�digo);

			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Descadastra a entidade no banco de dados.
		/// </summary>
		protected override void Descadastrar(IDbCommand cmd)
		{
			cmd.CommandText = "DELETE FROM pessoafisica WHERE codigo = " + DbTransformar(C�digo);
			cmd.ExecuteNonQuery();

			if (Transacionando)
				base.Descadastrar(cmd);
		}

		#endregion


        /// <summary>
        /// Obtem uma pessoaf�sica atrav�s do resultado de um comando com joins das tabelas pessoa e pessoafisica.
        /// Por enquanto, este m�todo s� utilizado para obten��o das pessoas para listagem dos acertos pendentes.
        /// Como nesta tela poucas informa��es s�o mostradas, 
        /// por desempenho apenas os atributos mostrados s�o carregados.
        /// Cada leitura do reader � muito lento.
        /// 
        /// As entidades n�o s�o utilizadas em outras telas, nem persistidas em cache, o que seria um problema, do tipo: 
        /// o usu�rio pode para alterar o cadastro e este estar incompleto.
        /// </summary>
        internal static PessoaF�sica Obter(IDataReader leitor, int inicioAtributoPesssoa, int inicioAtributoPessoaFisica)
        {
            PessoaF�sica entidade = new PessoaF�sica();
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
                naturalidadeC�digo = (ulong) leitor.GetInt64(inicioAtributoPessoaFisica + 9);

            if (leitor[inicioAtributoPessoaFisica + 10] != DBNull.Value)
                profiss�o = leitor.GetString(inicioAtributoPessoaFisica + 10);

        }
    }
}
