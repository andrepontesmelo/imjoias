using System;
using System.Data;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Exce��es;
using Entidades.Configura��o;
using Entidades.Privil�gio;
using System.Collections.Generic;

namespace Entidades.Financeiro
{
    /// <remarks>
    /// Deve ser manipulado apenas pelo contexto.
    /// </remarks>
	[Serializable, DbTabela("cotacao"), DbTransa��o]
	public class Cota��o : Acesso.Comum.DbManipula��oAutom�tica
	{
		// Atributos
        [DbChavePrim�ria(false)]
		private DateTime? data;

        [DbChavePrim�ria(false), DbRelacionamento("c�digo", "moeda")]
        private Moeda moeda;

        private double valor;

        [DbRelacionamento("codigo", "funcionario"), DbColuna("funcionario")]
		private Entidades.Pessoa.Funcion�rio funcion�rio;

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
                string formato = DadosGlobais.Inst�ncia.Cultura.NumberFormat.CurrencySymbol
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
					throw new Altera��oChavePrim�ria(
						this,
						"A data de uma cota��o n�o pode ser alterada, pois ela � chave prim�ria!");

				data = value;
			}
		}

		public Entidades.Pessoa.Funcion�rio Funcion�rio
		{
			get { return funcion�rio; }
			set
			{
				lock (this)
				{
					funcion�rio = value;
                    DefinirDesatualizado();
				}
			}
		}

		public override string ToString()
		{
			return
                valor.ToString("c", Entidades.Configura��o.DadosGlobais.Inst�ncia.Cultura)
				+ " funcion�rio: " + Funcion�rio.ToString()
				+ " data: " + Data.ToString();
        }

        #endregion

        #region Recupera��o de dados

        public class Cota��oInexistente : ApplicationException
        {
            public Cota��oInexistente()
                : base("N�o h� cota��o cadastrada no sistema!")
            {
            }
        }

        /// <summary>
		/// Pega a primeira cota��o da lista de cota��es anteriores
		/// Pode ser uma cota��o de outro dia, caso no dia de hoje n�o exista ainda cota��o cadastrada.
		/// </summary>
        /// <exception><c>Cota��oInexistente</c> Caso n�o possua cota��es cadastradas</exception>
		/// <returns></returns>
		public static Cota��o ObterCota��oVigente(Moeda moeda)
		{
			Cota��o[] anteriores = ObterListaCota��esAnteriores(moeda, 1);

			if (anteriores.Length == 0) 
				throw new Cota��oInexistente();
			else
				return anteriores[0];

		}

		/// <summary>
		/// Cota��o vigente em uma data.
		/// � a de registro igual ou imediatamente anterior.
		/// </summary>
		/// <remarks>N�o necessarimente do mesmo dia da data.</remarks>
		/// <param name="data">use a outra assinatura para cota��o vigente de agora!</param>
        /// <exception><c>Cota��oInexistente</c> Caso n�o possua cota��es cadastradas</exception>
        /// <returns></returns>
		private static Cota��o ObterCota��oVigente(Moeda moeda, DateTime data)
		{
			Cota��o[] anteriores = ObterListaCota��esAnteriores(moeda, data, 1);

			if (anteriores.Length == 0)
				return null;
			else
				return anteriores[0];
		}

        /// <summary>
        /// Cota��es de um per�odo espec�fico.
        /// </summary>
        public static Cota��o[] ObterCota��es(Moeda moeda, DateTime in�cio, DateTime fim)
        {
            return Mapear<Cota��o>("SELECT * FROM cotacao WHERE data BETWEEN "
                + DbTransformar(in�cio) + " AND "
                + DbTransformar(fim) +
                " AND moeda = " + DbTransformar(moeda.C�digo)).ToArray();
        }

		/// <summary>
		/// Cota��es de cuja data s�o imediatamente anteriores a data. 
		/// </summary>
		/// <remarks>caso data � chave, ela ser� incluida na lista (ser� a primeira)</remarks>
		/// <param name="data">� USE DateTime.Now via cliente</param>
        public static Cota��o[] ObterListaCota��esAnteriores(Moeda moeda, DateTime data, int limite)
        {
            return Mapear<Cota��o>("SELECT * FROM cotacao where data <= "
                                    + DbTransformar(data)
                                    + " AND moeda = " + DbTransformar(moeda.C�digo)
                                    + " order by data desc limit "
                                    + limite.ToString()).ToArray();
        }

		/// <summary>
		/// Cota��es de cuja data s�o imediatamente anteriores.
		/// </summary>
        public static Cota��o[] ObterListaCota��esAnteriores(Moeda moeda, int limite)
        {
            return Mapear<Cota��o>("SELECT * FROM cotacao where data <= NOW() "
                + " AND moeda = " + DbTransformar(moeda.C�digo)
                + " order by data desc limit " + limite.ToString()).ToArray();
        }

		/// <summary>
		/// Obtem somente cota��es que datam do dia de hoje.
		/// </summary>
        public static Cota��o[] ObterListaCota��esDoDia(Moeda moeda)
        {
            return Mapear<Cota��o>("SELECT * FROM cotacao where DATE(NOW()) = DATE(data)"
                                    + " AND moeda = " + DbTransformar(moeda.C�digo)).ToArray();
        }

		/// <summary>
		/// Obtem somente cota��es do dia do datetime especificado
		/// </summary>
        public static Cota��o[] ObterListaCota��esAt�Dia(Moeda moeda, DateTime dia)
		{
			IDbConnection conex�o;
            List<Cota��o> lista = new List<Cota��o>();

			conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "(SELECT * FROM cotacao WHERE "
                        + "DATE(data) = DATE(" + DbTransformar(dia) + ")"
                        + " AND moeda = " + DbTransformar(moeda.C�digo)
                        + " ORDER BY data DESC)"
                        + " UNION (SELECT * FROM cotacao WHERE "
                        + "DATE(data) < DATE(" + DbTransformar(dia) + ")"
                        + " AND moeda = " + DbTransformar(moeda.C�digo)
                        + " ORDER BY data DESC LIMIT 1)";

                    Mapear<Cota��o>(cmd, lista);

                    //if (lista.Count == 0)
                    //{
                    //    cmd.CommandText = "SELECT * FROM cotacao where "
                    //        + "DATE(data) <= DATE(" + DbTransformar(dia) + ")"
                    //        + " AND moeda = " + DbTransformar(moeda.C�digo)
                    //        + " ORDER BY data DESC LIMIT 1";

                    //    Mapear<Cota��o>(cmd, lista);
                    //}
                }

			return lista.ToArray();
		}

		#endregion

		/// <summary>
		/// Compara equival�ncia com outro objeto.
		/// </summary>
		public override bool Equals(object obj)
		{
			Cota��o outro = obj as Cota��o;

			return outro != null && 
                ((this.moeda != null && outro.moeda != null && this.moeda.C�digo == outro.moeda.C�digo)
                || (this.moeda == null && outro.moeda == null))
                && this.data == outro.data && this.funcion�rio == outro.funcion�rio && this.valor == outro.valor;
		}

		/// <summary>
		/// Verifica igualdade entre duas cota��es.
		/// </summary>
		public static bool operator == (Cota��o a, Cota��o b)
		{
            if ((((object) a) == null) && (((object) b) == null)) return true;
            else if (((object) a) == null || ((object) b) == null) return false;
			else return a.Equals(b);
		}

		/// <summary>
		/// Verifica diferen�a entre duas cota��es.
		/// </summary>
		public static bool operator != (Cota��o a, Cota��o b)
		{
            if (((object) a) == null && (((object) b) == null)) return false;
            else if (((object)a) == null || ((object) b) == null) return true;
            else return !a.Equals(b);
		}

		/// <summary>
		/// Gera um c�digo hash.
		/// </summary>
		public override int GetHashCode()
		{
			return data.GetHashCode() ^ Convert.ToInt32(valor * 1000) ^ Convert.ToInt32(funcion�rio);
		}

        /// <summary>
        /// Registra nova a cota��o no banco de dados, em nome do usu�rio atual e na data atual.
        /// </summary>
        public static Cota��o RegistrarCota��o(Moeda moeda, double valor, DateTime data)
        {
            Entidades.Financeiro.Cota��o  novaEntidade;

            // Cria nova entidade
            novaEntidade = new Entidades.Financeiro.Cota��o();
            novaEntidade.Data = data;
            novaEntidade.Funcion�rio = Pessoa.Funcion�rio.Funcion�rioAtual.C�digo;
            novaEntidade.Valor = valor;
            novaEntidade.Moeda = moeda;

            novaEntidade.Cadastrar();

            return novaEntidade;
        }

        /// <summary>
        /// Registra nova a cota��o no banco de dados, em nome do usu�rio atual e na data atual.
        /// </summary>
        public static Cota��o RegistrarCota��o(Moeda moeda, double valor)
        {
            Entidades.Financeiro.Cota��o  novaEntidade;

            // Cria nova entidade
            novaEntidade = new Entidades.Financeiro.Cota��o ();
            novaEntidade.Data = DadosGlobais.Inst�ncia.HoraDataAtual;
            novaEntidade.Funcion�rio = Pessoa.Funcion�rio.Funcion�rioAtual.C�digo;
            novaEntidade.Valor = valor;
            novaEntidade.Moeda = moeda;

            novaEntidade.Cadastrar();

            return novaEntidade;
        }

        public static implicit operator double(Cota��o cota��o)
        {
            return cota��o.valor;
        }

        public static implicit operator Cota��o(double valor)
        {
            Cota��o cota��o = new Cota��o();

            cota��o.valor = valor;

            return cota��o;
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            Permiss�oFuncion�rio.AssegurarPermiss�o(Permiss�o.EditarCota��o);

            if (moeda.ComponenteDeCusto != null)
            {
                moeda.ComponenteDeCusto.Valor = valor;
                AtualizarEntidade(cmd, moeda.ComponenteDeCusto);
            }

            base.Cadastrar(cmd);
        }

        /// <summary>
        /// Verifica se o valor da cota��o est� dentro do desvio
        /// padr�o dos �ltimos 15 dias.
        /// </summary>
        /// <param name="moeda">Moeda a ser verificada.</param>
        /// <param name="valor">Valor da cota��o a ser verificado.</param>
        /// <returns>Verdadeiro se o valor estiver dentro do desvio padr�o.</returns>
        public static bool VerificarValor(Moeda moeda, double valor)
        {
            IDbConnection conex�o;
            double m�dia, dp;

            conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT AVG(valor), STDDEV(valor) FROM cotacao "
                        + "WHERE moeda = " + DbTransformar(moeda.C�digo)
                        + " AND DATEDIFF(NOW(), data) <= 15";

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (leitor.Read() && !leitor.IsDBNull(0) && !leitor.IsDBNull(1))
                            {
                                m�dia = leitor.GetDouble(0);
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

            return Math.Abs(m�dia - valor) <= dp;
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            Permiss�oFuncion�rio.AssegurarPermiss�o(Permiss�o.EditarCota��o);

            base.Atualizar(cmd);
        }

        /// <summary>
        /// Calcula a varia��o percentual da cota��o.
        /// </summary>
        /// <returns>Varia��o percentual entre 0 e 1.</returns>
        public double CalcularVaria��oPercentual()
        {
            IDbConnection conex�o = Conex�o;
            double valor;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = string.Format(
                        "SELECT valor FROM cotacao WHERE data < {0} AND moeda = {1} ORDER BY data DESC LIMIT 1",
                        DbTransformar(data), DbTransformar(moeda.C�digo));
                    valor = Convert.ToDouble(cmd.ExecuteScalar());
                }

            return this.valor / valor - 1.0;
        }
    }
}
