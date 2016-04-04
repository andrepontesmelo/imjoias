using System;
using System.Data;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Exceções;
using Entidades.Configuração;
using Entidades.Privilégio;
using System.Collections.Generic;

namespace Entidades.Financeiro
{
    /// <remarks>
    /// Deve ser manipulado apenas pelo contexto.
    /// </remarks>
	[Serializable, DbTabela("cotacao"), DbTransação]
	public class Cotação : Acesso.Comum.DbManipulaçãoAutomática
	{
		// Atributos
        [DbChavePrimária(false)]
		private DateTime? data;

        [DbChavePrimária(false), DbRelacionamento("código", "moeda")]
        private Moeda moeda;

        private double valor;

        [DbRelacionamento("codigo", "funcionario"), DbColuna("funcionario")]
		private Entidades.Pessoa.Funcionário funcionário;

        #region Propriedades

        public Moeda Moeda
        {
            get { return moeda; }
            set { moeda = value; DefinirDesatualizado();  }
        }

		public double Valor
		{
			get	{ return valor; }
			set
			{
				lock (this)
				{
					valor = value;
                    DefinirDesatualizado();
				}
			}
		}

        public string ValorFormatado
        {
            get
            {
                string formato = DadosGlobais.Instância.Cultura.NumberFormat.CurrencySymbol
                    + " ###,###,##0";

                if (moeda.CasasDecimais > 0)
                {
                    formato += ".";

                    for (byte i = 0; i < moeda.CasasDecimais; i++)
                        formato += "0";
                }

                return Valor.ToString(formato);
            }
        }

		public DateTime? Data
		{
			get	{ return data; }
			set
			{
				if (Cadastrado)
					throw new AlteraçãoChavePrimária(
						this,
						"A data de uma cotação não pode ser alterada, pois ela é chave primária!");

				data = value;
			}
		}

		public Entidades.Pessoa.Funcionário Funcionário
		{
			get { return funcionário; }
			set
			{
				lock (this)
				{
					funcionário = value;
                    DefinirDesatualizado();
				}
			}
		}

		public override string ToString()
		{
			return
                valor.ToString("c", Entidades.Configuração.DadosGlobais.Instância.Cultura)
				+ " funcionário: " + Funcionário.ToString()
				+ " data: " + Data.ToString();
        }

        #endregion

        #region Recuperação de dados

        public class CotaçãoInexistente : ApplicationException
        {
            public CotaçãoInexistente()
                : base("Não há cotação cadastrada no sistema!")
            {
            }
        }

        /// <summary>
		/// Pega a primeira cotação da lista de cotações anteriores
		/// Pode ser uma cotação de outro dia, caso no dia de hoje não exista ainda cotação cadastrada.
		/// </summary>
        /// <exception><c>CotaçãoInexistente</c> Caso não possua cotações cadastradas</exception>
		/// <returns></returns>
		public static Cotação ObterCotaçãoVigente(Moeda moeda)
		{
			Cotação[] anteriores = ObterListaCotaçõesAnteriores(moeda, 1);

			if (anteriores.Length == 0) 
				throw new CotaçãoInexistente();
			else
				return anteriores[0];

		}

		/// <summary>
		/// Cotação vigente em uma data.
		/// é a de registro igual ou imediatamente anterior.
		/// </summary>
		/// <remarks>Não necessarimente do mesmo dia da data.</remarks>
		/// <param name="data">use a outra assinatura para cotação vigente de agora!</param>
        /// <exception><c>CotaçãoInexistente</c> Caso não possua cotações cadastradas</exception>
        /// <returns></returns>
		private static Cotação ObterCotaçãoVigente(Moeda moeda, DateTime data)
		{
			Cotação[] anteriores = ObterListaCotaçõesAnteriores(moeda, data, 1);

			if (anteriores.Length == 0)
				return null;
			else
				return anteriores[0];
		}

        /// <summary>
        /// Cotações de um período específico.
        /// </summary>
        public static Cotação[] ObterCotações(Moeda moeda, DateTime início, DateTime fim)
        {
            return Mapear<Cotação>("SELECT * FROM cotacao WHERE data BETWEEN "
                + DbTransformar(início) + " AND "
                + DbTransformar(fim) +
                " AND moeda = " + DbTransformar(moeda.Código)).ToArray();
        }

		/// <summary>
		/// Cotações de cuja data são imediatamente anteriores a data. 
		/// </summary>
		/// <remarks>caso data é chave, ela será incluida na lista (será a primeira)</remarks>
		/// <param name="data">Ñ USE DateTime.Now via cliente</param>
        public static Cotação[] ObterListaCotaçõesAnteriores(Moeda moeda, DateTime data, int limite)
        {
            return Mapear<Cotação>("SELECT * FROM cotacao where data <= "
                                    + DbTransformar(data)
                                    + " AND moeda = " + DbTransformar(moeda.Código)
                                    + " order by data desc limit "
                                    + limite.ToString()).ToArray();
        }

		/// <summary>
		/// Cotações de cuja data são imediatamente anteriores.
		/// </summary>
        public static Cotação[] ObterListaCotaçõesAnteriores(Moeda moeda, int limite)
        {
            return Mapear<Cotação>("SELECT * FROM cotacao where data <= NOW() "
                + " AND moeda = " + DbTransformar(moeda.Código)
                + " order by data desc limit " + limite.ToString()).ToArray();
        }

		/// <summary>
		/// Obtem somente cotações que datam do dia de hoje.
		/// </summary>
        public static Cotação[] ObterListaCotaçõesDoDia(Moeda moeda)
        {
            return Mapear<Cotação>("SELECT * FROM cotacao where DATE(NOW()) = DATE(data)"
                                    + " AND moeda = " + DbTransformar(moeda.Código)).ToArray();
        }

		/// <summary>
		/// Obtem somente cotações do dia do datetime especificado
		/// </summary>
        public static Cotação[] ObterListaCotaçõesAtéDia(Moeda moeda, DateTime dia)
		{
			IDbConnection conexão;
            List<Cotação> lista = new List<Cotação>();

			conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "(SELECT * FROM cotacao WHERE "
                        + "DATE(data) = DATE(" + DbTransformar(dia) + ")"
                        + " AND moeda = " + DbTransformar(moeda.Código)
                        + " ORDER BY data DESC)"
                        + " UNION (SELECT * FROM cotacao WHERE "
                        + "DATE(data) < DATE(" + DbTransformar(dia) + ")"
                        + " AND moeda = " + DbTransformar(moeda.Código)
                        + " ORDER BY data DESC LIMIT 1)";

                    Mapear<Cotação>(cmd, lista);

                    //if (lista.Count == 0)
                    //{
                    //    cmd.CommandText = "SELECT * FROM cotacao where "
                    //        + "DATE(data) <= DATE(" + DbTransformar(dia) + ")"
                    //        + " AND moeda = " + DbTransformar(moeda.Código)
                    //        + " ORDER BY data DESC LIMIT 1";

                    //    Mapear<Cotação>(cmd, lista);
                    //}
                }

			return lista.ToArray();
		}

		#endregion

		/// <summary>
		/// Compara equivalência com outro objeto.
		/// </summary>
		public override bool Equals(object obj)
		{
			Cotação outro = obj as Cotação;

			return outro != null && 
                ((this.moeda != null && outro.moeda != null && this.moeda.Código == outro.moeda.Código)
                || (this.moeda == null && outro.moeda == null))
                && this.data == outro.data && this.funcionário == outro.funcionário && this.valor == outro.valor;
		}

		/// <summary>
		/// Verifica igualdade entre duas cotações.
		/// </summary>
		public static bool operator == (Cotação a, Cotação b)
		{
            if ((((object) a) == null) && (((object) b) == null)) return true;
            else if (((object) a) == null || ((object) b) == null) return false;
			else return a.Equals(b);
		}

		/// <summary>
		/// Verifica diferença entre duas cotações.
		/// </summary>
		public static bool operator != (Cotação a, Cotação b)
		{
            if (((object) a) == null && (((object) b) == null)) return false;
            else if (((object)a) == null || ((object) b) == null) return true;
            else return !a.Equals(b);
		}

		/// <summary>
		/// Gera um código hash.
		/// </summary>
		public override int GetHashCode()
		{
			return data.GetHashCode() ^ Convert.ToInt32(valor * 1000) ^ Convert.ToInt32(funcionário);
		}

        /// <summary>
        /// Registra nova a cotação no banco de dados, em nome do usuário atual e na data atual.
        /// </summary>
        public static Cotação RegistrarCotação(Moeda moeda, double valor, DateTime data)
        {
            Entidades.Financeiro.Cotação  novaEntidade;

            // Cria nova entidade
            novaEntidade = new Entidades.Financeiro.Cotação();
            novaEntidade.Data = data;
            novaEntidade.Funcionário = Pessoa.Funcionário.FuncionárioAtual.Código;
            novaEntidade.Valor = valor;
            novaEntidade.Moeda = moeda;

            novaEntidade.Cadastrar();

            return novaEntidade;
        }

        /// <summary>
        /// Registra nova a cotação no banco de dados, em nome do usuário atual e na data atual.
        /// </summary>
        public static Cotação RegistrarCotação(Moeda moeda, double valor)
        {
            Entidades.Financeiro.Cotação  novaEntidade;

            // Cria nova entidade
            novaEntidade = new Entidades.Financeiro.Cotação ();
            novaEntidade.Data = DadosGlobais.Instância.HoraDataAtual;
            novaEntidade.Funcionário = Pessoa.Funcionário.FuncionárioAtual.Código;
            novaEntidade.Valor = valor;
            novaEntidade.Moeda = moeda;

            novaEntidade.Cadastrar();

            return novaEntidade;
        }

        public static implicit operator double(Cotação cotação)
        {
            return cotação.valor;
        }

        public static implicit operator Cotação(double valor)
        {
            Cotação cotação = new Cotação();

            cotação.valor = valor;

            return cotação;
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            PermissãoFuncionário.AssegurarPermissão(Permissão.EditarCotação);

            if (moeda.ComponenteDeCusto != null)
            {
                moeda.ComponenteDeCusto.Valor = valor;
                AtualizarEntidade(cmd, moeda.ComponenteDeCusto);
            }

            base.Cadastrar(cmd);
        }

        /// <summary>
        /// Verifica se o valor da cotação está dentro do desvio
        /// padrão dos últimos 15 dias.
        /// </summary>
        /// <param name="moeda">Moeda a ser verificada.</param>
        /// <param name="valor">Valor da cotação a ser verificado.</param>
        /// <returns>Verdadeiro se o valor estiver dentro do desvio padrão.</returns>
        public static bool VerificarValor(Moeda moeda, double valor)
        {
            IDbConnection conexão;
            double média, dp;

            conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT AVG(valor), STDDEV(valor) FROM cotacao "
                        + "WHERE moeda = " + DbTransformar(moeda.Código)
                        + " AND DATEDIFF(NOW(), data) <= 15";

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (leitor.Read() && !leitor.IsDBNull(0) && !leitor.IsDBNull(1))
                            {
                                média = leitor.GetDouble(0);
                                dp = leitor.GetDouble(1);
                            }
                            else
                                return true;
                        }
                        finally
                        {
                            leitor.Close();
                        }
                    }
                }

            return Math.Abs(média - valor) <= dp;
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            PermissãoFuncionário.AssegurarPermissão(Permissão.EditarCotação);

            base.Atualizar(cmd);
        }

        /// <summary>
        /// Calcula a variação percentual da cotação.
        /// </summary>
        /// <returns>Variação percentual entre 0 e 1.</returns>
        public double CalcularVariaçãoPercentual()
        {
            IDbConnection conexão = Conexão;
            double valor;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = string.Format(
                        "SELECT valor FROM cotacao WHERE data < {0} AND moeda = {1} ORDER BY data DESC LIMIT 1",
                        DbTransformar(data), DbTransformar(moeda.Código));
                    valor = Convert.ToDouble(cmd.ExecuteScalar());
                }

            return this.valor / valor - 1.0;
        }
    }
}
