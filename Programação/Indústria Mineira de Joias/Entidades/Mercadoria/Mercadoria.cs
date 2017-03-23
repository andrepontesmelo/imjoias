using Acesso.Comum;
using Acesso.Comum.Cache;
using Acesso.Comum.Exce��es;
using Entidades.�lbum;
using Entidades.Configura��o;
using Entidades.Financeiro;
using Entidades.Fiscal.Tipo;
using Entidades.Moedas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace Entidades.Mercadoria
{
    /// <summary>
    /// Mercadoria.
    /// </summary>
    /// 
    /// <remarks>
    /// Sempre que alterar um valor da chave prim�ria,
    /// tais como "refer�ncia" e "peso", deve-se garantir
    /// controle de concorr�ncia, visto que tal entidade
    /// � utilizada por outras entidades como chave prim�ria.
    /// 
    /// Uma altera��o destes valores pode gerar inconsist�ncia
    /// em outras entidades.
    /// </remarks>
    [Serializable]
    [Cache�vel("ObterMercadoriaComCache"), Validade(6, 0, 0)]
	public class Mercadoria : DbManipula��o, IDisposable, ICloneable
	{
        private static readonly int TAMANHO_REFER�NCIA = 11;
        private static readonly int TAMANHO_REFER�NCIA_RASTRE�VEL = 8;

        /// <summary>
        /// Campos compartilhados.
        /// </summary>
        private IMercadoriaCampos campos;

        /// <summary>
        /// Tabela de pre�os.
        /// </summary>
        private Tabela tabela = null;

        // Campo necess�rio para servir ao DbRelacionamento.
        private string referencia;

        /// <summary>
        /// Mercadorias de peso possuem peso personalizados.
        /// </summary>
		private double? peso;
        private double? coeficiente;

        ///// <summary>
        ///// Mercadorias de peso possuem imagens individuais.
        ///// </summary>
        private DbFoto icone;

      
		[NonSerialized]
		private �lbum.Anima��o		anima��o;

        private double? ranking;

		#region Construtoras

        protected Mercadoria() { }

        public Mercadoria(string refer�nciaFormatada, Tabela tabela)
        {
            string refer�ncia;
            int d�gito;

            DesmascararRefer�ncia(refer�nciaFormatada, out refer�ncia, out d�gito);

            campos = new MercadoriaCamposLeve(refer�ncia, d�gito, null, null, null);

            this.referencia = campos.Refer�nciaNum�rica;
            this.peso = campos.PesoOriginal;
            this.tabela = tabela;
        }

        public Mercadoria(string refer�ncia, byte d�gito, Tabela tabela)
        {
            campos = new MercadoriaCamposLeve(refer�ncia, d�gito, null, null, null);
            this.referencia = campos.Refer�nciaNum�rica;
            this.peso = campos.PesoOriginal;
            this.tabela = tabela;
        }

        public Mercadoria(string refer�ncia, byte d�gito, double peso, Tabela tabela)
        {
            campos = new MercadoriaCamposLeve(refer�ncia, d�gito, null, null, peso);
            this.referencia = campos.Refer�nciaNum�rica;
            this.peso = peso;
            this.tabela = tabela;
        }

        public Mercadoria(string refer�ncia, byte d�gito, double peso, double �ndice)
        {
            campos = new MercadoriaCamposLeve(refer�ncia, d�gito, null, null, peso);
            this.referencia = campos.Refer�nciaNum�rica;
            this.peso = peso;
            this.�ndice = �ndice;
        }

        /// <summary>
		/// Constr�i uma mercadoria, sem obter do BD
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia num�rica</param>
		/// <param name="d�gito">D�gito verificador</param>
		public Mercadoria(string refer�ncia, byte d�gito, bool? foraDeLinha, bool dePeso, double peso, Tabela tabela)
		{
#if DEBUG
            if (!ValidarRefer�nciaNum�rica(refer�ncia))
                throw new ArgumentException("Refer�ncia com tamanho errado.");
#endif

            campos = new MercadoriaCamposLeve(refer�ncia, d�gito, foraDeLinha, dePeso, peso);

            this.referencia = campos.Refer�nciaNum�rica;

            if (dePeso)
                this.peso = peso;
            else
                this.peso = campos.PesoOriginal;

            this.tabela = tabela;
		}

        public Mercadoria(string refer�ncia, int d�gito, bool foraDeLinha, bool dePeso,
            double peso, double �ndice, string descri��o, string faixa, int? grupo,
            int teor)
        {
            campos = new MercadoriaCampos(refer�ncia, d�gito, foraDeLinha, dePeso,
                peso, descri��o, faixa, grupo, teor);
            
            this.referencia = refer�ncia;
            this.peso = peso;
            this.�ndice = �ndice;
        }

        public static bool ValidarRefer�nciaNum�rica(string refer�nciaNum�rica)
        {
            return refer�nciaNum�rica.Length == TAMANHO_REFER�NCIA;
        }
		
		/// <summary>
		/// Constr�i uma mercadoria, n�o obtem do BD.
		/// </summary>
		internal Mercadoria(IMercadoriaCampos campos, double? peso, Tabela tabela)
		{
            if (campos == null)
                throw new ArgumentNullException("campos");

            this.campos = campos;
            this.referencia = campos.Refer�nciaNum�rica;
            this.peso = peso;
            this.tabela = tabela;
        }

		/// <summary>
		/// Constr�i uma mercadoria, n�o obt�m do BD
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia formatada</param>
		internal Mercadoria(IMercadoriaCampos campos, Tabela tabela) : this(campos, campos.PesoOriginal, tabela)
		{
        }
		
		#endregion

		#region Propriedades

        /// <summary>
        /// Ranking da mercadoria.
        /// </summary>
        public double Ranking
        {
            get
            {
                try
                {
                    if (ranking.HasValue)
                        return ranking.Value;

                    using (IDbCommand cmd = Conex�o.CreateCommand())
                    {
                        cmd.CommandText = string.Format(
                            "SELECT ranking_mercadoria({0}, {1})",
                            Refer�nciaNum�rica, Peso);

                        object resultado = cmd.ExecuteScalar();

                        if (resultado is DBNull || resultado == null)
                            ranking = 0;
                        else
                            ranking = Convert.ToDouble(resultado);
                    }

                    return ranking.Value;
                }
                catch
                {
                    return 0;
                }
            }
        }

		public string Refer�ncia => campos.Refer�ncia; 
		public int D�gito => campos.D�gito;
		public string Refer�nciaNum�rica => campos.Refer�nciaNum�rica;
		public string Descri��o => campos.Descri��o;
		public int Teor => campos.Teor;
        public int CFOP => campos.CFOP;
        public int TipoUnidadeComercialC�digo => campos.TipoUnidadeComercial;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(TipoUnidadeComercialC�digo);
        public string Classifica��oFiscal => campos.Classifica��oFiscal;

		/// <summary>
		/// Peso da mercadoria
		/// </summary>
		public double Peso
		{
			get { return peso.HasValue ? peso.Value : campos.PesoOriginal; }
			set
            {
                peso = value;
            }
		}

        public string PesoFormatado
        {
            get { return FormatarPeso(Peso); }
        }

        public string Faixa => campos.Faixa;
        public int? Grupo => campos.Grupo;

		/// <summary>
		/// Coeficiente da mercadoria. S� � igual ao �ndice para mercadorias de pe�a.
		/// </summary>
		public double Coeficiente
		{
            get
            {
                if (!coeficiente.HasValue && campos.Coeficientes == null)
                    throw new Exception("A mercadoria " + Refer�ncia + " n�o tem �ndice calculado no banco. ");

                return coeficiente.HasValue ? coeficiente.Value : campos.Coeficientes[tabela];
            }
            set
            {
                coeficiente = value;
            }
		}

        /// <summary>
		/// �ndice da mercadoria. 
		/// </summary>
		public double �ndice
		{
			get
			{
                return Entidades.Mercadoria.�ndice.Calcular(Coeficiente, Peso, DePeso);
			}
            set
            {
                if (DePeso)
                    Coeficiente = value / Peso;
                else
                    Coeficiente = value;
            }
		}

        public double �ndiceArredondado
        {
            get
            {
                return Entidades.Mercadoria.�ndice.Calcular(Coeficiente, Peso, DePeso, true);
            }
        }

		public bool DePeso => campos.DePeso;
        public bool DePesoManual => MercadoriaDePesoManual.PesoManual(campos.Refer�nciaNum�rica);
        public bool ForaDeLinha => campos.ForaDeLinha;

		/// <summary>
		/// Foto da mercadoria
		/// </summary>
		public Image Foto
		{
			get
			{
				// Obtem primeiro frame da anima��o.
                if (Anima��o != null)
                    return Anima��o.Foto;

                else if (!anima��oJ�Obtida)
                {
                    CarregarAnima��o();
                    return Foto;
                }
                else
                    return null;
			}
		}

        public Tabela TabelaPre�o { get { return tabela; } set { tabela = value; } }


		/// <summary>
		/// Informa � propriedade Anima��o se ela obt�m ou n�o, 
		/// no caso de ser nulo.
		/// Porque Anima��o=Nulo pode ser: 
		/// 1) n�o buscou ainda ou 2) j� buscou mas n�o existe
		/// </summary>
		private bool anima��oJ�Obtida = false;
		
		/// <summary>
		/// Obt�m a anima��o.
		/// Caso n�o tenha sido buscada ainda, � buscada no Bd.
		/// � nulo caso n�o exista anima��o
		/// </summary>
		public Anima��o Anima��o
		{
			get
			{
                lock (this)
                {
                    if (!anima��oJ�Obtida)
                    {
                        // Carregar do banco de dados
                        anima��o = �lbum.Anima��o.ObterAnima��o(this);
                        anima��oJ�Obtida = true;
                    }
                }
				
				return anima��o;
			}
		}

        //// N�o � necess�rio fazer uma consulta para ver se o �cone realmente n�o existe
        //private bool �coneJ�Obtido = false;

		/// <summary>
		/// �cone da mercadoria
		/// </summary>
		public Image �cone
		{
			get
			{
                if (icone == null)
                {
                    �cone �coneEmCache = Cache�cones.Inst�ncia.Obter(this);

                    if (�coneEmCache != null)
                        icone = new DbFoto(�coneEmCache.Dados);
                }

                return icone;
			}
		}

        /// <summary>
        /// Determina se a foto j� foi carregada do banco de dados.
        /// </summary>
        public bool FotoObtida
        {
            get { return anima��oJ�Obtida; }
        }

		#endregion

		#region Formata��o das refer�ncias

		/// <summary>
		/// Mascara a refer�ncia conforme formato 000.000.00.000-0
		/// </summary>
		/// <param name="refer�nciaNum�rica">Refer�ncia num�rica, sem formata��o</param>
		/// <param name="d�gito">D�gito verificador</param>
		/// <returns>Refer�ncia formatada</returns>
		public static string MascararRefer�ncia(string refer�nciaNum�rica, int d�gito)
		{
			string refer�ncia;

            if (refer�nciaNum�rica.Length < TAMANHO_REFER�NCIA)
                return refer�nciaNum�rica;

			refer�ncia = refer�nciaNum�rica.Substring(0, 3) + '.' +
				refer�nciaNum�rica.Substring(3, 3) + '.' +
				refer�nciaNum�rica.Substring(6, 2) + '.' +
				refer�nciaNum�rica.Substring(8);
			
			if (d�gito >= 0)
				refer�ncia += '-' + d�gito.ToString();

			return refer�ncia;
		}

        public static string MascararRefer�ncia(string refer�nciaNum�ricaSemDigito, bool adicionarD�gito)
        {
            if (adicionarD�gito)
                return MascararRefer�ncia(refer�nciaNum�ricaSemDigito, 
                    ObterD�gito(refer�nciaNum�ricaSemDigito));
            else
                return MascararRefer�ncia(refer�nciaNum�ricaSemDigito);
        }
                
        /// <summary>
        /// Mascara a refer�ncia conforme formato 000.000.00.000
        /// </summary>
        /// <param name="refer�nciaNum�rica">Refer�ncia num�rica, sem formata��o</param>
        /// <returns>Refer�ncia formatada</returns>
        public static string MascararRefer�ncia(string refer�nciaNum�rica)
        {
            string refer�ncia;

            if (refer�nciaNum�rica.Length < TAMANHO_REFER�NCIA)
                return refer�nciaNum�rica;

            refer�ncia = refer�nciaNum�rica.Substring(0, 3) + '.' +
                refer�nciaNum�rica.Substring(3, 3) + '.' +
                refer�nciaNum�rica.Substring(6, 2) + '.' +
                refer�nciaNum�rica.Substring(8);

            return refer�ncia;
        }

		/// <summary>
		/// Desmascara refer�ncias retornando apenas os n�meros
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia formatada</param>
		/// <param name="refer�nciaNum�rica">Refer�ncia num�rica, sem d�gito verificador</param>
		/// <param name="d�gito">D�gito verificador</param>
		public static void DesmascararRefer�ncia(string refer�ncia, out string refer�nciaNum�rica, out int d�gito)
		{
			// Introduz valores padr�es
			refer�nciaNum�rica = "";
			d�gito             = -1;

			// A refer�ncia pode ser inv�lida, ex: ao obter Acerto.
			if (refer�ncia == null)
				return;

			// Desmascara refer�ncia
			for (int i = 0; i < refer�ncia.Length; i++)
				if (char.IsDigit(refer�ncia[i]))
					refer�nciaNum�rica += refer�ncia[i];
				else if (refer�ncia[i] == '-')				// D�gito verificador
				{
					if (i + 1 < refer�ncia.Length && char.IsDigit(refer�ncia[i + 1]))
						d�gito = int.Parse(refer�ncia.Substring(i + 1));
					break;
				}
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			if (anima��o != null)
			{
                anima��o.Dispose();
			}

            //if (icone != null)
            //{
            //    icone.Dispose();
            //    icone = null;
            //    �coneJ�Obtido = false;
            //}
		}

		~Mercadoria()
		{
			Dispose();
		}

		#endregion

		#region Recupera��o de dados

        /// <summary>
        /// Encapsula campos de mercadoria em objetos do tipo Mercadoria.
        /// </summary>
        /// <param name="campos">Campos a serem encapsulados.</param>
        /// <returns>Vetor de Mercadoria que encapsula os campos.</returns>
        private static Mercadoria[] Encapsular(IMercadoriaCampos[] campos, Tabela tabela)
        {
            Mercadoria[] mercadorias = new Mercadoria[campos.Length];

            for (int i = 0; i < campos.Length; i++)
                mercadorias[i] = new Mercadoria(campos[i], tabela);

            return mercadorias;
        }

        /// <summary>
        /// Obt�m vetor de mercadorias.
        /// </summary>
        /// <param name="prefixo">Prefixo da refer�ncia</param>
        /// <param name="limite">Limite de refer�ncias</param>
        /// <returns>Vetor de mercadorias do tipo Entidade.Mercadoria</returns>
        /// <remarks>
        /// N�o s�o retornadas mercadorias fora de linha.
        /// </remarks>
        public static Mercadoria[] ObterMercadorias(string prefixo, int limite, Tabela tabela)
        {
            return ObterMercadorias(prefixo, limite, tabela, false);
        }

        public static Mercadoria[] ObterMercadorias(string prefixo, int limite, Tabela tabela, bool somenteComFotos)
		{
            IMercadoriaCampos[] campos;

            campos = MercadoriaCampos.ObterMercadorias(prefixo, limite, somenteComFotos);

            return Encapsular(campos, tabela);
		}


        /// <summary>
        /// Obt�m mercadoria
        /// </summary>
        /// <param name="refer�ncia">Refer�ncia formatada da mercadoria</param>
        public static Mercadoria ObterMercadoria(string refer�ncia, Tabela tabela)
        {
            return CacheDb.Inst�ncia.ObterEntidade(typeof(Mercadoria), refer�ncia, tabela) as Mercadoria;
        }

        public static Mercadoria ObterMercadoria(string refer�ncia)
        {
            if (refer�ncia.Length > TAMANHO_REFER�NCIA)
            {
                var refer�nciaSemD�gito = refer�ncia.Substring(0, TAMANHO_REFER�NCIA);
                string d�gito = refer�ncia.Substring(TAMANHO_REFER�NCIA, 1);

                var mercadoria = ObterMercadoria(refer�nciaSemD�gito, Tabela.TabelaPadr�o);

                if (mercadoria == null)
                    return null;

                return (mercadoria.D�gito.ToString().Equals(d�gito) ? mercadoria : null);
            }

            return ObterMercadoria(refer�ncia, Tabela.TabelaPadr�o);
        }

        /// <summary>
        /// Carrega uma mercadoria do banco de dados com o peso especificado.
        /// </summary>
        public static Mercadoria ObterMercadoria(string refer�ncia, double peso, Tabela tabela)
        {
            Mercadoria mercadoria;

            mercadoria = Acesso.Comum.Cache.CacheDb.Inst�ncia.ObterEntidade(typeof(Mercadoria), refer�ncia, tabela) as Mercadoria;
            
            if (mercadoria != null)
                mercadoria.Peso = peso;
#if DEBUG
            else
                Console.WriteLine("Mercadoria de refer�ncia {0} n�o encontrada!", refer�ncia);
#endif

            return mercadoria;
        }

		public static Mercadoria ObterMercadoriaComCache(string refer�ncia, Tabela tabela)
		{
            MercadoriaCampos campos = MercadoriaCampos.ObterMercadoria(refer�ncia);

            if (campos != null)
                return new Mercadoria(campos, tabela);
            else
                return null;
		}


		/// <summary>
		/// Obt�m mercadoria
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia num�rica da mercadoria</param>
		/// <returns>Mercadoria</returns>
		public static Mercadoria ObterMercadoriaSemD�gito(string refer�ncia, Tabela tabela)
		{
            MercadoriaCampos campos = MercadoriaCampos.ObterMercadoriaSemD�gito(refer�ncia);

            if (campos != null)
                return new Mercadoria(campos, tabela);
            else
                return null;
		}

		/// <summary>
		/// N�o cria outro objeto, mas atualiza as propriedades com o banco de dados.
		/// � �til no AtualizaObjetosIntr�nsecos() do Entidades.Saquinho.Saquinho.
		/// </summary>
		public void ReobterInforma��es()
		{
			Mercadoria fresca;
			
			fresca = ObterMercadoria(Refer�ncia, tabela);

			if (fresca != null)
                campos = fresca.campos;
		}

		/// <summary>
		/// Verifica se determinada refer�ncia est� cadastrada
		/// no banco de dados
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia formatada a ser verificada</param>
		/// <returns>Se a refer�ncia est� cadastrada</returns>
        public static bool VerificarExist�ncia(string refer�nciaFormatada)
        {
            return VerificarExist�ncia(refer�nciaFormatada, true);
        }

		/// <summary>
		/// Verifica se determinada refer�ncia est� cadastrada
		/// no banco de dados
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia formatada a ser verificada</param>
		/// <returns>Se a refer�ncia est� cadastrada</returns>
        public static bool VerificarExist�ncia(string refer�nciaFormatada, bool usarCache)
        {
            string refer�nciaNum�rica;
            int d�gito;

            DesmascararRefer�ncia(refer�nciaFormatada, out refer�nciaNum�rica, out d�gito);

            if (!usarCache)
            {
                IDbConnection conex�o;

                conex�o = Conex�o;

                lock (conex�o)
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM mercadoria"
                            + " WHERE referencia = " + DbTransformar(refer�nciaNum�rica)
                            + " AND digito = " + DbTransformar(d�gito);

                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }

            int d�gitoCorreto = ObterD�gito(refer�nciaNum�rica);
            return d�gito == d�gitoCorreto;
        }

		/// <summary>
		/// Recupera a primeira refer�ncia pr�xima
		/// � refer�ncia chave.
		/// </summary>
		/// <param name="chave">Chave a ser recuperada</param>
		/// <returns>Refer�ncia</returns>
		public static string ObterRefer�nciaPr�xima(string chave)
		{
            if (MercadoriaCampos.�rvoreCarregada)
            {
                MercadoriaCampos campos = MercadoriaCampos.ObterRefer�nciaPr�xima(chave);

                if (campos != null)
                    return campos.Refer�ncia;
                else
                    return null;
            }
            else
            {
                IDbConnection conex�o = Conex�o;

                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT referencia, digito"
                        + " FROM mercadoria"
                        + " WHERE referencia LIKE '" + chave + "%'"
                        + " AND foradelinha = 0 LIMIT 1";

                    lock (conex�o)
                    {
                        IDataReader leitor = null;

                        try
                        {
                            string refer�ncia;
                            int d�gito;

                            using (leitor = cmd.ExecuteReader())
                            {

                                if (!leitor.Read())
                                    return null;

                                refer�ncia = leitor.GetString(0);
                                d�gito = Convert.ToInt32(leitor.GetValue(1));
                            }

                            return MascararRefer�ncia(refer�ncia, d�gito);
                        }
                        finally
                        {
                            if (leitor != null && !leitor.IsClosed)
                                leitor.Close();
                        }
                    }
                }
            }
		}

		#endregion

		#region Compara��o

		/// <summary>
		/// Gera um c�digo hash.
		/// </summary>
		public override int GetHashCode()
		{
			int hash, contador;

			hash = contador = 0;

			foreach (char c in Refer�nciaNum�rica)
			{
				hash    ^= c << contador;
				contador = (contador + 8) % (8 * 4);
			}
            
            try
            {
                hash ^= Convert.ToInt32(Peso * 1000);
            }
            catch
            {
                hash = ~hash;
            }

			return hash;
		}

		/// <summary>
		/// Verifica equival�ncia com outro objeto.
		/// </summary>
		public override bool Equals(object obj)
		{
			Mercadoria outra = obj as Mercadoria;

            return outra != null && this.Refer�nciaNum�rica == outra.Refer�nciaNum�rica
                && this.Peso == outra.Peso && this.D�gito == outra.D�gito
                && this.Descri��o == outra.Descri��o && this.Teor == outra.Teor
                && this.Faixa == outra.Faixa
                && this.Grupo == outra.Grupo && this.coeficiente == outra.coeficiente
                && this.DePeso == outra.DePeso && this.ForaDeLinha == outra.ForaDeLinha;
		}
		
		/// <summary>
		/// Compara igualdade entre duas mercadorias.
		/// </summary>
		public static bool operator == (Mercadoria a, Mercadoria b)
		{
			if (((object) a) == null || ((object) b) == null)
				return ((object) a) == ((object) b);

			return a.Equals(b);
		}

		/// <summary>
		/// Compara diferen�a entre duas mercadorias.
		/// </summary>
		public static bool operator != (Mercadoria a, Mercadoria b)
		{
			return !(a == b);
		}

		#endregion

		#region ICloneable Members

		/// <summary>
		/// Realiza uma c�pia profunda do objeto
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
            Mercadoria clonada = new Mercadoria(campos, tabela);

            clonada.peso = peso;

            clonada.coeficiente = coeficiente;

			return clonada;
		}

		#endregion

        #region C�digo de barras
        
        public string Codificar()
        {
            int c�digo;
            double pesoPr�tico = DePeso ? Peso : 0;

            c�digo = ObterC�digoMapeamento();

            /* Caso o c�digo n�o seja encontrado no banco de dados,
             * ser� criado um novo para ele.
             */
            if (c�digo < 0)
                c�digo = GerarC�digoMapeamento();

            if (pesoPr�tico >= 90)
            {
                return string.Format("9{0:0000}{1:000}", Math.Floor(pesoPr�tico * 10), c�digo);
            }
            else
            {
                if (c�digo <= 999)
                    return string.Format("{0:000}{1:000}", Math.Floor(pesoPr�tico * 10), c�digo);
                else if (c�digo <= 100999)
                    return string.Format("{0:000}{1:00000}", Math.Floor(pesoPr�tico * 10), c�digo - 1000);
            }

            throw new NotSupportedException("N�o � poss�vel codificar todas as etiquetas necess�rias. O sistema est� saturado, necessitando reciclagem de mapeamentos de c�digo de barras!");
        }

        /// <summary>
        /// Obt�m do banco de dados o c�digo mapeado da mercadoria
        /// </summary>
        /// <returns>C�digo de mapeamento</returns>
        /// <remarks>Caso n�o encontre, retorna -1</remarks>
        private int ObterC�digoMapeamento()
        {
            double pesoPr�tico = DePeso ? Peso : 0;

            int c�digo;

            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    object obj;

                    cmd.CommandText = "SELECT codigo FROM mercadoriamapeamento "
                        + "WHERE referencia = '" + Refer�nciaNum�rica + "' "
                        + "AND peso = '" + pesoPr�tico.ToString(NumberFormatInfo.InvariantInfo) + "'";

                    obj = cmd.ExecuteScalar();

                    if (obj == null || obj == DBNull.Value)
                        c�digo = -1;
                    else
                        c�digo = Convert.ToInt32(obj);
                }
            }

            return c�digo;
        }

        /// <summary>
        /// Gera o c�digo de mapeamento, cadastrando-o no banco de dados
        /// </summary>
        /// <param name="refer�ncia">Refer�ncia a ser mapeada</param>
        /// <param name="peso">Peso da mercadoria</param>
        /// <returns>C�digo de mapeamento</returns>
        private int GerarC�digoMapeamento()
        {
            double pesoPr�tico = DePeso ? peso.Value : 0;
            int c�digo;

            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbTransaction transa��o = conex�o.BeginTransaction())
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        object obj;

                        cmd.Transaction = transa��o;

                        // Obter c�digo obsoleto
                        cmd.CommandText = "SELECT codigo FROM mercadoriamapeamento "
                            + "WHERE obsoleto = 1 "
                            + "AND peso = '" + pesoPr�tico.ToString(NumberFormatInfo.InvariantInfo) + "' "
                            + "LIMIT 1";

                        obj = cmd.ExecuteScalar();

                        if (obj != null && obj != DBNull.Value)
                        {
                            c�digo = Convert.ToInt32(obj);

                            cmd.CommandText = "UPDATE mercadoriamapeamento SET obsoleto = 0, "
                                + "referencia = '" + Refer�nciaNum�rica + "', "
                                + "peso = '" + pesoPr�tico.ToString(NumberFormatInfo.InvariantInfo) + "' "
                                + "WHERE codigo = '" + c�digo + "'";

                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "SELECT MAX(codigo) FROM mercadoriamapeamento "
                                + "WHERE peso = '" + pesoPr�tico.ToString(NumberFormatInfo.InvariantInfo) + "'";

                            obj = cmd.ExecuteScalar();

                            if (obj == DBNull.Value || obj == null)
                                c�digo = 0;
                            else
                                c�digo = Convert.ToInt32(obj) + 1;

                            cmd.CommandText = "INSERT INTO mercadoriamapeamento (codigo, peso, referencia) "
                                + "VALUES ('" + c�digo + "', '" + pesoPr�tico.ToString(NumberFormatInfo.InvariantInfo)
                                + "', '" + Refer�nciaNum�rica + "')";

                            cmd.ExecuteNonQuery();
                        }

                        transa��o.Commit();
                    }
                }
            }

            return c�digo;
        }

        /// <summary>
        /// Interpreta o c�digo de barras
        /// </summary>
        /// <param name="c�digo">C�digo de barras</param>
        /// <param name="mapC�digo">C�digo de mapeamento</param>
        /// <param name="mapPeso">Peso de mapeamento</param>
        public static void Interpretar(string c�digo, out int mapC�digo, out double mapPeso)
        {
            checked
            {
                switch (c�digo.Length)
                {
                    case 6:
                        mapC�digo = int.Parse(c�digo.Substring(3));
                        mapPeso = double.Parse(c�digo.Substring(0, 3)) / 10d;
                        break;

                    case 8:
                        if (c�digo.StartsWith("9"))
                        {
                            mapC�digo = int.Parse(c�digo.Substring(5));
                            mapPeso = double.Parse(c�digo.Substring(1, 4)) / 10d + 90;
                        }
                        else
                        {
                            mapC�digo = int.Parse(c�digo.Substring(3)) + 1000;
                            mapPeso = double.Parse(c�digo.Substring(0, 3)) / 10d;
                        }
                        break;

                    default:
                        throw new C�digoBarrasInv�lido();
                }
            }
        }

        /// <summary>
        /// Interpreta o c�digo de barras
        /// </summary>
        /// <param name="c�digo">C�digo de barras</param>
        /// <returns>Mercadoria mapeada</returns>
        public static Mercadoria Interpretar(string c�digo, Tabela tabela)
        {
            int mapC�digo;
            double mapPeso;
            string refer�ncia;

            Interpretar(c�digo, out mapC�digo, out mapPeso);

            refer�ncia = ObterRefer�nciaMapeada(mapC�digo, mapPeso);

            if (refer�ncia != null)
            {
                Mercadoria mercadoria;

                mercadoria = ObterMercadoriaSemD�gito(refer�ncia, tabela);

                if (mapPeso > 0)
                {
                    if (!mercadoria.DePeso)
                        throw new C�digoBarrasInv�lido("C�digo de barras cont�m peso para uma mercadoria que n�o � pesada!");
                        //throw new Exception("C�digo de barras cont�m peso para uma mercadoria que n�o � pesada!");

                    mercadoria.Peso = mapPeso;
                }

                return mercadoria;
            }
            else
                throw new C�digoBarrasInv�lido("C�digo de barras incorreto!");
                //throw new Exception("C�digo de barras incorreto!");
        }

        /// <summary>
        /// Obt�m refer�ncia mapeada
        /// </summary>
        /// <param name="c�digo">C�digo do mapeamento</param>
        /// <param name="peso">Peso do mapeamento</param>
        /// <returns>Refer�ncia mapeada</returns>
        private static string ObterRefer�nciaMapeada(int c�digo, double peso)
        {
            string refer�ncia;
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    object obj;

                    cmd.CommandText = "SELECT referencia FROM mercadoriamapeamento "
                        + "WHERE codigo = '" + c�digo.ToString() + "' "
                        + "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
                        + "AND obsoleto = 0";

                    obj = cmd.ExecuteScalar();

                    if (obj == DBNull.Value || obj == null)
                        return null;

                    refer�ncia = Convert.ToString(obj);
                }
            }

            return refer�ncia;
        }

        #endregion

        public static string FormatarPeso(double p, bool mostrarUnidade)
        {
            if (mostrarUnidade && p > 1000)
            {
                p /= 1000;
                return p.ToString("0", DadosGlobais.Inst�ncia.Cultura.NumberFormat) + " kg e " + p.ToString("0.00", DadosGlobais.Inst�ncia.Cultura.NumberFormat) + " g";
            }
            else
                return p.ToString("0.00", DadosGlobais.Inst�ncia.Cultura.NumberFormat) + (mostrarUnidade? " g" : "");
        }

        public static string FormatarPeso(double p)
        {
            return FormatarPeso(p, true);
        }

        public static string Formatar�ndice(double i)
        {
            return i.ToString("###,##0.00", DadosGlobais.Inst�ncia.Cultura.NumberFormat);
        }

		/// <summary>
		/// For�a a mercadoria como cadastrada.
		/// </summary>
		/// 
		/// <remarks>
		/// Este m�todo dever� ser utilizado somente
		/// quando a recupera��o da mercadoria do banco
		/// de dados ocorre em outra entidade.
		/// </remarks>
		internal void For�arCadastrada()
		{
			if (this.Cadastrado)
				throw new Exce��oEntidade(this, "N�o se pode for�ar o cadastro de uma entidade j� cadastrada.");

            DefinirCadastrado();
            DefinirAtualizado();

            if (campos is MercadoriaCampos)
                ((MercadoriaCampos)campos).For�arCadastrada();
		}

        /// <summary>
        /// Calcula pre�o da mercadoria, dado uma cota��o.
        /// </summary>
        /// <param name="cota��o">Cota��o a ser utilizada.</param>
        /// <returns>Pre�o da mercadoria.</returns>
        public Pre�o CalcularPre�o(Cota��o cota��o)
        {
            return new Pre�o(this, cota��o);
        }

        /// <summary>
        /// Calcula pre�o da mercadoria, utilizando a cota��o
        /// vigente cadastrada no banco de dados.
        /// </summary>
        /// <param name="ouro">Ouro a ser considerado.</param>
        /// <returns>Pre�o da mercadoria.</returns>
        public Pre�o CalcularPre�o(Moeda ouro)
        {
            return new Pre�o(this, ouro);
        }
        
		#region Atualiza��o do banco de dados

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        /// <remarks>
        /// O implementador dever� atribuir o valor
        /// verdadeiro para os atributos "cadastrado"
        /// e "atualizado".
        /// </remarks>
        protected override void Cadastrar(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Atualiza a entidade no banco de dados.
        /// </summary>
        /// <remarks>
        /// O implementador dever� atribuir o valor
        /// verdadeiro para o atributo "atualizado".
        /// </remarks>
        protected override void Atualizar(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Descadastra a entidade no banco de dados.
        /// </summary>
        /// <remarks>
        /// O implementador dever� atribuir o valor
        /// falso para os atributos "cadastrado" e
        /// "atualizado".
        /// </remarks>
        protected override void Descadastrar(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

		#endregion

        /// <summary>
        /// Obt�m fotos do banco de dados.
        /// </summary>
        /// <returns>Vetor de fotos.</returns>
        public Foto[] ObterFotos()
        {
            return Entidades.�lbum.Foto.ObterFotos(this);
        }

        public void CarregarAnima��o()
        {
            if (!anima��oJ�Obtida)
            {
                // Carregar do banco de dados
                anima��o = �lbum.Anima��o.ObterAnima��o(this);
                anima��oJ�Obtida = true;
            }
        }

        /// <summary>
        /// Libera a foto da mem�ria.
        /// </summary>
        public void LiberarFoto()
        {
            if (anima��o != null)
            {
                anima��o.Dispose();
                anima��o = null;
                anima��oJ�Obtida = false;
            }
        }

        /// <summary>
        /// Inicia carga em segundo plano das mercadorias.
        /// </summary>
        /// <remarks>
        /// Fica � cargo do programador chamar este m�todo por fora.
        /// 
        /// Ele � chamado logo ap�s autentica��o no AoCarregarCompletamente de
        /// Apresenta��o.Formul�rios.BaseFormul�rio.
        /// </remarks>
        public static void IniciarCarga()
        {
            MercadoriaCampos.IniciarCarga();
        }

        public void Preparar()
        {
            if (campos is MercadoriaCamposLeve)
                ((MercadoriaCamposLeve)campos).Preparar();
        }

        public override string ToString()
        {
            return Refer�ncia;
        }

        /// <summary>
        /// Obt�m rastreamento de todas as mercadorias.
        /// Dado uma refer�ncia, retorna o seu rastro.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<RastroConsignado>> ObterRastreamento()
        {
            Dictionary<string, List<RastroConsignado>> hash = new Dictionary<string, List<RastroConsignado>>(StringComparer.Ordinal);

            IDbConnection conex�o = Conex�o;
            List<RastroConsignado> resultado = new List<RastroConsignado>();

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandTimeout = 120;
                    
                    cmd.CommandText = string.Format("SELECT p.codigo, p.nome, a.previsao, SUM(si.quantidade) - ifnull(rastreamentovenda.qtd,0) - ifnull(rastreamentoretorno.qtd,0) as saldo, si.referencia " +
                         " FROM saida s JOIN saidaitem si ON s.codigo = si.saida JOIN acertoconsignado a ON a.codigo = s.acerto " +
                         " JOIN pessoa p ON p.codigo = a.cliente " +
                         " left join " +
                         " ( SELECT p.codigo, SUM(vi.quantidade) as qtd, referencia " +
                         " FROM venda v JOIN vendaitem vi ON v.codigo = vi.venda JOIN acertoconsignado a ON a.codigo = v.acerto " +
                         " JOIN pessoa p ON p.codigo = a.cliente " +
                         " WHERE a.dataEfetiva IS NULL " +
                         " GROUP BY p.codigo, vi.referencia " +
                         " ) " +
                         " rastreamentovenda on p.codigo=rastreamentovenda.codigo " +
                         " and substr(si.referencia,1,{0})=substr(rastreamentovenda.referencia,1,{0}) " +

                         " left join " +
                         " ( " +
                         " SELECT p.codigo, SUM(ri.quantidade) as qtd, referencia " +
                         " FROM retorno r JOIN retornoitem ri ON r.codigo = ri.retorno JOIN acertoconsignado a ON a.codigo = r.acerto " +
                         " JOIN pessoa p ON p.codigo = a.cliente " +
                         " WHERE a.dataEfetiva IS NULL " +
                         " GROUP BY p.codigo, ri.referencia " +
                         " ) rastreamentoretorno on p.codigo=rastreamentoretorno.codigo " +
                         " and substr(si.referencia,1,{0})=substr(rastreamentoretorno.referencia,1,{0}) " +

                         " WHERE a.dataEfetiva IS NULL " +
                         " GROUP BY p.codigo, substr(si.referencia,1,{0}), a.previsao " +
                         " HAVING saldo > 0 " + 
                         " ORDER BY SUM(si.quantidade) desc ", TAMANHO_REFER�NCIA_RASTRE�VEL);

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (leitor.Read())
                            {
                                RastroConsignado rastro = new RastroConsignado();

                                rastro.Refer�nciaNum�rica = leitor.GetString(4);

                                rastro.Pessoa = new Entidades.Pessoa.PessoaC�digoNome(
                                    Convert.ToUInt64(leitor.GetValue(0)),
                                    leitor.GetString(1));
                                rastro.Devolu��o = leitor.IsDBNull(2) ? (DateTime?)null : (DateTime?)leitor.GetDateTime(2);
                                rastro.Quantidade = leitor.GetInt32(3);

                                // Procura uma lista para adicionar o rastro nela.
                                List<RastroConsignado> lista = null;
                                if (!hash.TryGetValue(ObterRefer�nciaRastre�vel(rastro.Refer�nciaNum�rica), out lista))
                                {
                                    lista = new List<RastroConsignado>();
                                    hash[ObterRefer�nciaRastre�vel(rastro.Refer�nciaNum�rica)] = lista;
                                }

                                lista.Add(rastro);
                            }
                        }
                        finally
                        {
                            leitor.Close();
                        }
                    }
                }
            }

            return hash;
        }

        /// <summary>
        /// Rastrea mercadoria em todos os estoques de consignado.
        /// </summary>
        public List<RastroConsignado> RastrearConsignado()
        {
            IDbConnection conex�o = Conex�o;
            List<RastroConsignado> resultado = new List<RastroConsignado>();

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.codigo, p.nome, a.previsao, SUM(si.quantidade) - ifnull(rastreamentovenda.qtd,0) - ifnull(rastreamentoretorno.qtd,0) " + 
                         " FROM saida s JOIN saidaitem si ON s.codigo = si.saida JOIN acertoconsignado a ON a.codigo = s.acerto " + 
                         " JOIN pessoa p ON p.codigo = a.cliente " + 
                         
                         " left join  " + 
                         " ( SELECT p.codigo, SUM(vi.quantidade) as qtd " + 
                         " FROM venda v JOIN vendaitem vi ON v.codigo = vi.venda JOIN acertoconsignado a ON a.codigo = v.acerto " + 
                         " JOIN pessoa p ON p.codigo = a.cliente " + 
                         " WHERE a.dataEfetiva IS NULL  " + 
                         " and referencia LIKE '" + ObterRefer�nciaRastre�vel() + "%' " + 
                         " GROUP BY p.codigo " + 
                         " ) " + 
                         " rastreamentovenda on p.codigo=rastreamentovenda.codigo " + 
                         
                         " left join " + 
                         " ( " + 
                         " SELECT p.codigo, SUM(ri.quantidade) as qtd " + 
                         " FROM retorno r JOIN retornoitem ri ON r.codigo = ri.retorno JOIN acertoconsignado a ON a.codigo = r.acerto " + 
                         " JOIN pessoa p ON p.codigo = a.cliente " + 
                         " WHERE a.dataEfetiva IS NULL  " +
                         " and referencia LIKE '" + ObterRefer�nciaRastre�vel() + "%' " + 
                         " GROUP BY p.codigo " + 
                         " ) rastreamentoretorno on p.codigo=rastreamentoretorno.codigo " + 
                         
                         " WHERE a.dataEfetiva IS NULL  " +
                         " and referencia LIKE '" + ObterRefer�nciaRastre�vel() + "%' " + 
                         " GROUP BY p.codigo " + 
                         " ORDER BY SUM(si.quantidade) desc";

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (leitor.Read())
                            {
                                RastroConsignado rastro = new RastroConsignado();

                                rastro.Refer�nciaNum�rica = Refer�nciaNum�rica;
                                rastro.Pessoa = new Entidades.Pessoa.PessoaC�digoNome(
                                    Convert.ToUInt64(leitor.GetValue(0)),
                                    leitor.GetString(1));
                                rastro.Devolu��o = leitor.IsDBNull(2) ? (DateTime?)null : (DateTime?)leitor.GetDateTime(2);
                                rastro.Quantidade = leitor.GetInt32(3);

                                resultado.Add(rastro);
                            }
                        }
                        finally
                        {
                            leitor.Close();
                        }
                    }
                }
            }

            return resultado;
        }

        private string ObterRefer�nciaRastre�vel()
        {
            return ObterRefer�nciaRastre�vel(Refer�nciaNum�rica);
        }

        public static string ObterRefer�nciaRastre�vel(string refer�ncia)
        {
            return refer�ncia?.Substring(0, TAMANHO_REFER�NCIA_RASTRE�VEL);
        }

        /// <summary>
        /// Rastrea mercadoria em todos as vendas marcadas como rastrado.
        /// </summary>
        public List<RastroVenda> RastrearVenda()
        {
            IDbConnection conex�o = Conex�o;
            List<RastroVenda> resultado = new List<RastroVenda>();

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "select venda.codigo, venda.data, sum(quantidade) as qtd, cliente, nome from vendaitem, venda "
                        + " left join pessoa on cliente=pessoa.codigo where venda.rastreada=1 "
                        + " and venda.codigo=vendaitem.venda "
                        + " and referencia LIKE '" + ObterRefer�nciaRastre�vel() + "%' " 
                        + " group by venda.codigo having qtd > 0";

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (leitor.Read())
                            {
                                RastroVenda rastro = new RastroVenda();

                                // 0: Venda.codigo
                                // 1: Venda.Data
                                // 2: Qtd
                                // 3: Cliente.Codigo
                                // 4: Cliente.Nome

                                rastro.Mercadoria = this;
                                rastro.Pessoa = new Entidades.Pessoa.PessoaC�digoNome(
                                    Convert.ToUInt64(leitor.GetValue(3)),
                                    leitor.GetString(4));
                                
                                rastro.Data = leitor.GetDateTime(1);
                                rastro.Quantidade = leitor.GetInt32(2);
                                rastro.C�digo = leitor.GetInt32(0);

                                resultado.Add(rastro);
                            }
                        }
                        finally
                        {
                            leitor.Close();
                        }
                    }
                }
            }

            return resultado;
        }

        public static bool ConferirSe�DePeso(string refer�nciaNum�rica)
        {
            return MercadoriaCampos.ObterMercadoria(refer�nciaNum�rica).DePeso;
        }

        /// <summary>
        /// O d�gito � quanto falta para um n�mero at� sua proxima dezena, 
        /// sendo esse n�mero a soma do triplo da soma dos d�gitos impares com a soma dos d�gitos pares.
        /// </summary>
        /// <param name="refer�nciaNum�rica"></param>
        /// <returns></returns>
        public static int ObterD�gito(string refer�nciaNum�rica)
        {
            // Concatena zeros � direita at� ter 11 d�gitos
            if (refer�nciaNum�rica.Length < TAMANHO_REFER�NCIA)
                refer�nciaNum�rica += new String('0', TAMANHO_REFER�NCIA - refer�nciaNum�rica.Length);

            // 48 � o ascii do zero '0'
            // Soma dos numeros de posi��o impar (1,3,5,9,11)
            int somaD�gitos�mpares =
                refer�nciaNum�rica[0] - 48 +
                refer�nciaNum�rica[2] - 48 +
                refer�nciaNum�rica[4] - 48 +
                refer�nciaNum�rica[6] - 48 +
                refer�nciaNum�rica[8] - 48 +
                refer�nciaNum�rica[10] - 48;

            int somaD�gitosPares =
                refer�nciaNum�rica[1] - 48 +
                refer�nciaNum�rica[3] - 48 +
                refer�nciaNum�rica[5] - 48 +
                refer�nciaNum�rica[7] - 48 +
                refer�nciaNum�rica[9] - 48;

            int contaMaluca = (somaD�gitos�mpares * 3) + somaD�gitosPares;
            int digito = (10 - contaMaluca % 10);

            return digito % 10;
        }


        /// <summary>
        /// Rastro de mercadoria.
        /// </summary>
        public struct RastroConsignado
        {
            //public Mercadoria Mercadoria;
            public string Refer�nciaNum�rica;
            public Pessoa.PessoaC�digoNome Pessoa;
            public int Quantidade;
            public DateTime? Devolu��o;

        }

        /// <summary>
        /// Rastro de mercadoria.
        /// </summary>
        public struct RastroVenda
        {
            public int C�digo;
            public Mercadoria Mercadoria;
            public Pessoa.PessoaC�digoNome Pessoa;
            public int Quantidade;
            public DateTime? Data;

        }

        public void EsquecerCoeficientePersonalizado()
        {
            coeficiente = null;
        }
    }


    /// <summary>
	/// C�digo de barras inv�lido
	/// </summary>
    [Serializable]
	public class C�digoBarrasInv�lido : ApplicationException
	{
		public C�digoBarrasInv�lido() : base("C�digo de barras inv�lido!")
		{
		}

		public C�digoBarrasInv�lido(string mensagem) : base(mensagem)
		{
		}
	}
}
