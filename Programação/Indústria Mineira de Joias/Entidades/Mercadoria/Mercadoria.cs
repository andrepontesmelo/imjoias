using Acesso.Comum;
using Acesso.Comum.Cache;
using Acesso.Comum.Exceções;
using Entidades.Álbum;
using Entidades.Configuração;
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
    /// Sempre que alterar um valor da chave primária,
    /// tais como "referência" e "peso", deve-se garantir
    /// controle de concorrência, visto que tal entidade
    /// é utilizada por outras entidades como chave primária.
    /// 
    /// Uma alteração destes valores pode gerar inconsistência
    /// em outras entidades.
    /// </remarks>
    [Serializable]
    [Cacheável("ObterMercadoriaComCache"), Validade(6, 0, 0)]
	public class Mercadoria : DbManipulação, IDisposable, ICloneable
	{
        private static readonly int TAMANHO_REFERÊNCIA = 11;
        private static readonly int TAMANHO_REFERÊNCIA_RASTREÁVEL = 8;

        /// <summary>
        /// Campos compartilhados.
        /// </summary>
        private IMercadoriaCampos campos;

        /// <summary>
        /// Tabela de preços.
        /// </summary>
        private Tabela tabela = null;

        // Campo necessário para servir ao DbRelacionamento.
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
		private Álbum.Animação		animação;

        private double? ranking;

		#region Construtoras

        protected Mercadoria() { }

        public Mercadoria(string referênciaFormatada, Tabela tabela)
        {
            string referência;
            int dígito;

            DesmascararReferência(referênciaFormatada, out referência, out dígito);

            campos = new MercadoriaCamposLeve(referência, dígito, null, null, null);

            this.referencia = campos.ReferênciaNumérica;
            this.peso = campos.PesoOriginal;
            this.tabela = tabela;
        }

        public Mercadoria(string referência, byte dígito, Tabela tabela)
        {
            campos = new MercadoriaCamposLeve(referência, dígito, null, null, null);
            this.referencia = campos.ReferênciaNumérica;
            this.peso = campos.PesoOriginal;
            this.tabela = tabela;
        }

        public Mercadoria(string referência, byte dígito, double peso, Tabela tabela)
        {
            campos = new MercadoriaCamposLeve(referência, dígito, null, null, peso);
            this.referencia = campos.ReferênciaNumérica;
            this.peso = peso;
            this.tabela = tabela;
        }

        public Mercadoria(string referência, byte dígito, double peso, double índice)
        {
            campos = new MercadoriaCamposLeve(referência, dígito, null, null, peso);
            this.referencia = campos.ReferênciaNumérica;
            this.peso = peso;
            this.Índice = índice;
        }

        /// <summary>
		/// Constrói uma mercadoria, sem obter do BD
		/// </summary>
		/// <param name="referência">Referência numérica</param>
		/// <param name="dígito">Dígito verificador</param>
		public Mercadoria(string referência, byte dígito, bool? foraDeLinha, bool dePeso, double peso, Tabela tabela)
		{
#if DEBUG
            if (!ValidarReferênciaNumérica(referência))
                throw new ArgumentException("Referência com tamanho errado.");
#endif

            campos = new MercadoriaCamposLeve(referência, dígito, foraDeLinha, dePeso, peso);

            this.referencia = campos.ReferênciaNumérica;

            if (dePeso)
                this.peso = peso;
            else
                this.peso = campos.PesoOriginal;

            this.tabela = tabela;
		}

        public Mercadoria(string referência, int dígito, bool foraDeLinha, bool dePeso,
            double peso, double índice, string descrição, string faixa, int? grupo,
            int teor)
        {
            campos = new MercadoriaCampos(referência, dígito, foraDeLinha, dePeso,
                peso, descrição, faixa, grupo, teor);
            
            this.referencia = referência;
            this.peso = peso;
            this.Índice = índice;
        }

        public static bool ValidarReferênciaNumérica(string referênciaNumérica)
        {
            return referênciaNumérica.Length == TAMANHO_REFERÊNCIA;
        }
		
		/// <summary>
		/// Constrói uma mercadoria, não obtem do BD.
		/// </summary>
		internal Mercadoria(IMercadoriaCampos campos, double? peso, Tabela tabela)
		{
            if (campos == null)
                throw new ArgumentNullException("campos");

            this.campos = campos;
            this.referencia = campos.ReferênciaNumérica;
            this.peso = peso;
            this.tabela = tabela;
        }

		/// <summary>
		/// Constrói uma mercadoria, não obtém do BD
		/// </summary>
		/// <param name="referência">Referência formatada</param>
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

                    using (IDbCommand cmd = Conexão.CreateCommand())
                    {
                        cmd.CommandText = string.Format(
                            "SELECT ranking_mercadoria({0}, {1})",
                            ReferênciaNumérica, Peso);

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

		public string Referência => campos.Referência; 
		public int Dígito => campos.Dígito;
		public string ReferênciaNumérica => campos.ReferênciaNumérica;
		public string Descrição => campos.Descrição;
		public int Teor => campos.Teor;
        public int CFOP => campos.CFOP;
        public int TipoUnidadeComercialCódigo => campos.TipoUnidadeComercial;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(TipoUnidadeComercialCódigo);
        public string ClassificaçãoFiscal => campos.ClassificaçãoFiscal;

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
		/// Coeficiente da mercadoria. Só é igual ao índice para mercadorias de peça.
		/// </summary>
		public double Coeficiente
		{
            get
            {
                if (!coeficiente.HasValue && campos.Coeficientes == null)
                    throw new Exception("A mercadoria " + Referência + " não tem índice calculado no banco. ");

                return coeficiente.HasValue ? coeficiente.Value : campos.Coeficientes[tabela];
            }
            set
            {
                coeficiente = value;
            }
		}

        /// <summary>
		/// Índice da mercadoria. 
		/// </summary>
		public double Índice
		{
			get
			{
                return Entidades.Mercadoria.Índice.Calcular(Coeficiente, Peso, DePeso);
			}
            set
            {
                if (DePeso)
                    Coeficiente = value / Peso;
                else
                    Coeficiente = value;
            }
		}

        public double ÍndiceArredondado
        {
            get
            {
                return Entidades.Mercadoria.Índice.Calcular(Coeficiente, Peso, DePeso, true);
            }
        }

		public bool DePeso => campos.DePeso;
        public bool DePesoManual => MercadoriaDePesoManual.PesoManual(campos.ReferênciaNumérica);
        public bool ForaDeLinha => campos.ForaDeLinha;

		/// <summary>
		/// Foto da mercadoria
		/// </summary>
		public Image Foto
		{
			get
			{
				// Obtem primeiro frame da animação.
                if (Animação != null)
                    return Animação.Foto;

                else if (!animaçãoJáObtida)
                {
                    CarregarAnimação();
                    return Foto;
                }
                else
                    return null;
			}
		}

        public Tabela TabelaPreço { get { return tabela; } set { tabela = value; } }


		/// <summary>
		/// Informa à propriedade Animação se ela obtém ou não, 
		/// no caso de ser nulo.
		/// Porque Animação=Nulo pode ser: 
		/// 1) não buscou ainda ou 2) já buscou mas não existe
		/// </summary>
		private bool animaçãoJáObtida = false;
		
		/// <summary>
		/// Obtém a animação.
		/// Caso não tenha sido buscada ainda, é buscada no Bd.
		/// É nulo caso não exista animação
		/// </summary>
		public Animação Animação
		{
			get
			{
                lock (this)
                {
                    if (!animaçãoJáObtida)
                    {
                        // Carregar do banco de dados
                        animação = Álbum.Animação.ObterAnimação(this);
                        animaçãoJáObtida = true;
                    }
                }
				
				return animação;
			}
		}

        //// Não é necessário fazer uma consulta para ver se o ícone realmente não existe
        //private bool íconeJáObtido = false;

		/// <summary>
		/// Ícone da mercadoria
		/// </summary>
		public Image Ícone
		{
			get
			{
                if (icone == null)
                {
                    Ícone íconeEmCache = CacheÍcones.Instância.Obter(this);

                    if (íconeEmCache != null)
                        icone = new DbFoto(íconeEmCache.Dados);
                }

                return icone;
			}
		}

        /// <summary>
        /// Determina se a foto já foi carregada do banco de dados.
        /// </summary>
        public bool FotoObtida
        {
            get { return animaçãoJáObtida; }
        }

		#endregion

		#region Formatação das referências

		/// <summary>
		/// Mascara a referência conforme formato 000.000.00.000-0
		/// </summary>
		/// <param name="referênciaNumérica">Referência numérica, sem formatação</param>
		/// <param name="dígito">Dígito verificador</param>
		/// <returns>Referência formatada</returns>
		public static string MascararReferência(string referênciaNumérica, int dígito)
		{
			string referência;

            if (referênciaNumérica.Length < TAMANHO_REFERÊNCIA)
                return referênciaNumérica;

			referência = referênciaNumérica.Substring(0, 3) + '.' +
				referênciaNumérica.Substring(3, 3) + '.' +
				referênciaNumérica.Substring(6, 2) + '.' +
				referênciaNumérica.Substring(8);
			
			if (dígito >= 0)
				referência += '-' + dígito.ToString();

			return referência;
		}

        public static string MascararReferência(string referênciaNuméricaSemDigito, bool adicionarDígito)
        {
            if (adicionarDígito)
                return MascararReferência(referênciaNuméricaSemDigito, 
                    ObterDígito(referênciaNuméricaSemDigito));
            else
                return MascararReferência(referênciaNuméricaSemDigito);
        }
                
        /// <summary>
        /// Mascara a referência conforme formato 000.000.00.000
        /// </summary>
        /// <param name="referênciaNumérica">Referência numérica, sem formatação</param>
        /// <returns>Referência formatada</returns>
        public static string MascararReferência(string referênciaNumérica)
        {
            string referência;

            if (referênciaNumérica.Length < TAMANHO_REFERÊNCIA)
                return referênciaNumérica;

            referência = referênciaNumérica.Substring(0, 3) + '.' +
                referênciaNumérica.Substring(3, 3) + '.' +
                referênciaNumérica.Substring(6, 2) + '.' +
                referênciaNumérica.Substring(8);

            return referência;
        }

		/// <summary>
		/// Desmascara referências retornando apenas os números
		/// </summary>
		/// <param name="referência">Referência formatada</param>
		/// <param name="referênciaNumérica">Referência numérica, sem dígito verificador</param>
		/// <param name="dígito">Dígito verificador</param>
		public static void DesmascararReferência(string referência, out string referênciaNumérica, out int dígito)
		{
			// Introduz valores padrões
			referênciaNumérica = "";
			dígito             = -1;

			// A referência pode ser inválida, ex: ao obter Acerto.
			if (referência == null)
				return;

			// Desmascara referência
			for (int i = 0; i < referência.Length; i++)
				if (char.IsDigit(referência[i]))
					referênciaNumérica += referência[i];
				else if (referência[i] == '-')				// Dígito verificador
				{
					if (i + 1 < referência.Length && char.IsDigit(referência[i + 1]))
						dígito = int.Parse(referência.Substring(i + 1));
					break;
				}
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			if (animação != null)
			{
                animação.Dispose();
			}

            //if (icone != null)
            //{
            //    icone.Dispose();
            //    icone = null;
            //    íconeJáObtido = false;
            //}
		}

		~Mercadoria()
		{
			Dispose();
		}

		#endregion

		#region Recuperação de dados

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
        /// Obtém vetor de mercadorias.
        /// </summary>
        /// <param name="prefixo">Prefixo da referência</param>
        /// <param name="limite">Limite de referências</param>
        /// <returns>Vetor de mercadorias do tipo Entidade.Mercadoria</returns>
        /// <remarks>
        /// Não são retornadas mercadorias fora de linha.
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
        /// Obtém mercadoria
        /// </summary>
        /// <param name="referência">Referência formatada da mercadoria</param>
        public static Mercadoria ObterMercadoria(string referência, Tabela tabela)
        {
            return CacheDb.Instância.ObterEntidade(typeof(Mercadoria), referência, tabela) as Mercadoria;
        }

        public static Mercadoria ObterMercadoria(string referência)
        {
            if (referência.Length > TAMANHO_REFERÊNCIA)
            {
                var referênciaSemDígito = referência.Substring(0, TAMANHO_REFERÊNCIA);
                string dígito = referência.Substring(TAMANHO_REFERÊNCIA, 1);

                var mercadoria = ObterMercadoria(referênciaSemDígito, Tabela.TabelaPadrão);

                if (mercadoria == null)
                    return null;

                return (mercadoria.Dígito.ToString().Equals(dígito) ? mercadoria : null);
            }

            return ObterMercadoria(referência, Tabela.TabelaPadrão);
        }

        /// <summary>
        /// Carrega uma mercadoria do banco de dados com o peso especificado.
        /// </summary>
        public static Mercadoria ObterMercadoria(string referência, double peso, Tabela tabela)
        {
            Mercadoria mercadoria;

            mercadoria = Acesso.Comum.Cache.CacheDb.Instância.ObterEntidade(typeof(Mercadoria), referência, tabela) as Mercadoria;
            
            if (mercadoria != null)
                mercadoria.Peso = peso;
#if DEBUG
            else
                Console.WriteLine("Mercadoria de referência {0} não encontrada!", referência);
#endif

            return mercadoria;
        }

		public static Mercadoria ObterMercadoriaComCache(string referência, Tabela tabela)
		{
            MercadoriaCampos campos = MercadoriaCampos.ObterMercadoria(referência);

            if (campos != null)
                return new Mercadoria(campos, tabela);
            else
                return null;
		}


		/// <summary>
		/// Obtém mercadoria
		/// </summary>
		/// <param name="referência">Referência numérica da mercadoria</param>
		/// <returns>Mercadoria</returns>
		public static Mercadoria ObterMercadoriaSemDígito(string referência, Tabela tabela)
		{
            MercadoriaCampos campos = MercadoriaCampos.ObterMercadoriaSemDígito(referência);

            if (campos != null)
                return new Mercadoria(campos, tabela);
            else
                return null;
		}

		/// <summary>
		/// Não cria outro objeto, mas atualiza as propriedades com o banco de dados.
		/// É útil no AtualizaObjetosIntrínsecos() do Entidades.Saquinho.Saquinho.
		/// </summary>
		public void ReobterInformações()
		{
			Mercadoria fresca;
			
			fresca = ObterMercadoria(Referência, tabela);

			if (fresca != null)
                campos = fresca.campos;
		}

		/// <summary>
		/// Verifica se determinada referência está cadastrada
		/// no banco de dados
		/// </summary>
		/// <param name="referência">Referência formatada a ser verificada</param>
		/// <returns>Se a referência está cadastrada</returns>
        public static bool VerificarExistência(string referênciaFormatada)
        {
            return VerificarExistência(referênciaFormatada, true);
        }

		/// <summary>
		/// Verifica se determinada referência está cadastrada
		/// no banco de dados
		/// </summary>
		/// <param name="referência">Referência formatada a ser verificada</param>
		/// <returns>Se a referência está cadastrada</returns>
        public static bool VerificarExistência(string referênciaFormatada, bool usarCache)
        {
            string referênciaNumérica;
            int dígito;

            DesmascararReferência(referênciaFormatada, out referênciaNumérica, out dígito);

            if (!usarCache)
            {
                IDbConnection conexão;

                conexão = Conexão;

                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM mercadoria"
                            + " WHERE referencia = " + DbTransformar(referênciaNumérica)
                            + " AND digito = " + DbTransformar(dígito);

                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }

            int dígitoCorreto = ObterDígito(referênciaNumérica);
            return dígito == dígitoCorreto;
        }

		/// <summary>
		/// Recupera a primeira referência próxima
		/// à referência chave.
		/// </summary>
		/// <param name="chave">Chave a ser recuperada</param>
		/// <returns>Referência</returns>
		public static string ObterReferênciaPróxima(string chave)
		{
            if (MercadoriaCampos.ÁrvoreCarregada)
            {
                MercadoriaCampos campos = MercadoriaCampos.ObterReferênciaPróxima(chave);

                if (campos != null)
                    return campos.Referência;
                else
                    return null;
            }
            else
            {
                IDbConnection conexão = Conexão;

                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT referencia, digito"
                        + " FROM mercadoria"
                        + " WHERE referencia LIKE '" + chave + "%'"
                        + " AND foradelinha = 0 LIMIT 1";

                    lock (conexão)
                    {
                        IDataReader leitor = null;

                        try
                        {
                            string referência;
                            int dígito;

                            using (leitor = cmd.ExecuteReader())
                            {

                                if (!leitor.Read())
                                    return null;

                                referência = leitor.GetString(0);
                                dígito = Convert.ToInt32(leitor.GetValue(1));
                            }

                            return MascararReferência(referência, dígito);
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

		#region Comparação

		/// <summary>
		/// Gera um código hash.
		/// </summary>
		public override int GetHashCode()
		{
			int hash, contador;

			hash = contador = 0;

			foreach (char c in ReferênciaNumérica)
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
		/// Verifica equivalência com outro objeto.
		/// </summary>
		public override bool Equals(object obj)
		{
			Mercadoria outra = obj as Mercadoria;

            return outra != null && this.ReferênciaNumérica == outra.ReferênciaNumérica
                && this.Peso == outra.Peso && this.Dígito == outra.Dígito
                && this.Descrição == outra.Descrição && this.Teor == outra.Teor
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
		/// Compara diferença entre duas mercadorias.
		/// </summary>
		public static bool operator != (Mercadoria a, Mercadoria b)
		{
			return !(a == b);
		}

		#endregion

		#region ICloneable Members

		/// <summary>
		/// Realiza uma cópia profunda do objeto
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

        #region Código de barras
        
        public string Codificar()
        {
            int código;
            double pesoPrático = DePeso ? Peso : 0;

            código = ObterCódigoMapeamento();

            /* Caso o código não seja encontrado no banco de dados,
             * será criado um novo para ele.
             */
            if (código < 0)
                código = GerarCódigoMapeamento();

            if (pesoPrático >= 90)
            {
                return string.Format("9{0:0000}{1:000}", Math.Floor(pesoPrático * 10), código);
            }
            else
            {
                if (código <= 999)
                    return string.Format("{0:000}{1:000}", Math.Floor(pesoPrático * 10), código);
                else if (código <= 100999)
                    return string.Format("{0:000}{1:00000}", Math.Floor(pesoPrático * 10), código - 1000);
            }

            throw new NotSupportedException("Não é possível codificar todas as etiquetas necessárias. O sistema está saturado, necessitando reciclagem de mapeamentos de código de barras!");
        }

        /// <summary>
        /// Obtém do banco de dados o código mapeado da mercadoria
        /// </summary>
        /// <returns>Código de mapeamento</returns>
        /// <remarks>Caso não encontre, retorna -1</remarks>
        private int ObterCódigoMapeamento()
        {
            double pesoPrático = DePeso ? Peso : 0;

            int código;

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    object obj;

                    cmd.CommandText = "SELECT codigo FROM mercadoriamapeamento "
                        + "WHERE referencia = '" + ReferênciaNumérica + "' "
                        + "AND peso = '" + pesoPrático.ToString(NumberFormatInfo.InvariantInfo) + "'";

                    obj = cmd.ExecuteScalar();

                    if (obj == null || obj == DBNull.Value)
                        código = -1;
                    else
                        código = Convert.ToInt32(obj);
                }
            }

            return código;
        }

        /// <summary>
        /// Gera o código de mapeamento, cadastrando-o no banco de dados
        /// </summary>
        /// <param name="referência">Referência a ser mapeada</param>
        /// <param name="peso">Peso da mercadoria</param>
        /// <returns>Código de mapeamento</returns>
        private int GerarCódigoMapeamento()
        {
            double pesoPrático = DePeso ? peso.Value : 0;
            int código;

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbTransaction transação = conexão.BeginTransaction())
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        object obj;

                        cmd.Transaction = transação;

                        // Obter código obsoleto
                        cmd.CommandText = "SELECT codigo FROM mercadoriamapeamento "
                            + "WHERE obsoleto = 1 "
                            + "AND peso = '" + pesoPrático.ToString(NumberFormatInfo.InvariantInfo) + "' "
                            + "LIMIT 1";

                        obj = cmd.ExecuteScalar();

                        if (obj != null && obj != DBNull.Value)
                        {
                            código = Convert.ToInt32(obj);

                            cmd.CommandText = "UPDATE mercadoriamapeamento SET obsoleto = 0, "
                                + "referencia = '" + ReferênciaNumérica + "', "
                                + "peso = '" + pesoPrático.ToString(NumberFormatInfo.InvariantInfo) + "' "
                                + "WHERE codigo = '" + código + "'";

                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "SELECT MAX(codigo) FROM mercadoriamapeamento "
                                + "WHERE peso = '" + pesoPrático.ToString(NumberFormatInfo.InvariantInfo) + "'";

                            obj = cmd.ExecuteScalar();

                            if (obj == DBNull.Value || obj == null)
                                código = 0;
                            else
                                código = Convert.ToInt32(obj) + 1;

                            cmd.CommandText = "INSERT INTO mercadoriamapeamento (codigo, peso, referencia) "
                                + "VALUES ('" + código + "', '" + pesoPrático.ToString(NumberFormatInfo.InvariantInfo)
                                + "', '" + ReferênciaNumérica + "')";

                            cmd.ExecuteNonQuery();
                        }

                        transação.Commit();
                    }
                }
            }

            return código;
        }

        /// <summary>
        /// Interpreta o código de barras
        /// </summary>
        /// <param name="código">Código de barras</param>
        /// <param name="mapCódigo">Código de mapeamento</param>
        /// <param name="mapPeso">Peso de mapeamento</param>
        public static void Interpretar(string código, out int mapCódigo, out double mapPeso)
        {
            checked
            {
                switch (código.Length)
                {
                    case 6:
                        mapCódigo = int.Parse(código.Substring(3));
                        mapPeso = double.Parse(código.Substring(0, 3)) / 10d;
                        break;

                    case 8:
                        if (código.StartsWith("9"))
                        {
                            mapCódigo = int.Parse(código.Substring(5));
                            mapPeso = double.Parse(código.Substring(1, 4)) / 10d + 90;
                        }
                        else
                        {
                            mapCódigo = int.Parse(código.Substring(3)) + 1000;
                            mapPeso = double.Parse(código.Substring(0, 3)) / 10d;
                        }
                        break;

                    default:
                        throw new CódigoBarrasInválido();
                }
            }
        }

        /// <summary>
        /// Interpreta o código de barras
        /// </summary>
        /// <param name="código">Código de barras</param>
        /// <returns>Mercadoria mapeada</returns>
        public static Mercadoria Interpretar(string código, Tabela tabela)
        {
            int mapCódigo;
            double mapPeso;
            string referência;

            Interpretar(código, out mapCódigo, out mapPeso);

            referência = ObterReferênciaMapeada(mapCódigo, mapPeso);

            if (referência != null)
            {
                Mercadoria mercadoria;

                mercadoria = ObterMercadoriaSemDígito(referência, tabela);

                if (mapPeso > 0)
                {
                    if (!mercadoria.DePeso)
                        throw new CódigoBarrasInválido("Código de barras contém peso para uma mercadoria que não é pesada!");
                        //throw new Exception("Código de barras contém peso para uma mercadoria que não é pesada!");

                    mercadoria.Peso = mapPeso;
                }

                return mercadoria;
            }
            else
                throw new CódigoBarrasInválido("Código de barras incorreto!");
                //throw new Exception("Código de barras incorreto!");
        }

        /// <summary>
        /// Obtém referência mapeada
        /// </summary>
        /// <param name="código">Código do mapeamento</param>
        /// <param name="peso">Peso do mapeamento</param>
        /// <returns>Referência mapeada</returns>
        private static string ObterReferênciaMapeada(int código, double peso)
        {
            string referência;
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    object obj;

                    cmd.CommandText = "SELECT referencia FROM mercadoriamapeamento "
                        + "WHERE codigo = '" + código.ToString() + "' "
                        + "AND peso = '" + peso.ToString(NumberFormatInfo.InvariantInfo) + "' "
                        + "AND obsoleto = 0";

                    obj = cmd.ExecuteScalar();

                    if (obj == DBNull.Value || obj == null)
                        return null;

                    referência = Convert.ToString(obj);
                }
            }

            return referência;
        }

        #endregion

        public static string FormatarPeso(double p, bool mostrarUnidade)
        {
            if (mostrarUnidade && p > 1000)
            {
                p /= 1000;
                return p.ToString("0", DadosGlobais.Instância.Cultura.NumberFormat) + " kg e " + p.ToString("0.00", DadosGlobais.Instância.Cultura.NumberFormat) + " g";
            }
            else
                return p.ToString("0.00", DadosGlobais.Instância.Cultura.NumberFormat) + (mostrarUnidade? " g" : "");
        }

        public static string FormatarPeso(double p)
        {
            return FormatarPeso(p, true);
        }

        public static string FormatarÍndice(double i)
        {
            return i.ToString("###,##0.00", DadosGlobais.Instância.Cultura.NumberFormat);
        }

		/// <summary>
		/// Força a mercadoria como cadastrada.
		/// </summary>
		/// 
		/// <remarks>
		/// Este método deverá ser utilizado somente
		/// quando a recuperação da mercadoria do banco
		/// de dados ocorre em outra entidade.
		/// </remarks>
		internal void ForçarCadastrada()
		{
			if (this.Cadastrado)
				throw new ExceçãoEntidade(this, "Não se pode forçar o cadastro de uma entidade já cadastrada.");

            DefinirCadastrado();
            DefinirAtualizado();

            if (campos is MercadoriaCampos)
                ((MercadoriaCampos)campos).ForçarCadastrada();
		}

        /// <summary>
        /// Calcula preço da mercadoria, dado uma cotação.
        /// </summary>
        /// <param name="cotação">Cotação a ser utilizada.</param>
        /// <returns>Preço da mercadoria.</returns>
        public Preço CalcularPreço(Cotação cotação)
        {
            return new Preço(this, cotação);
        }

        /// <summary>
        /// Calcula preço da mercadoria, utilizando a cotação
        /// vigente cadastrada no banco de dados.
        /// </summary>
        /// <param name="ouro">Ouro a ser considerado.</param>
        /// <returns>Preço da mercadoria.</returns>
        public Preço CalcularPreço(Moeda ouro)
        {
            return new Preço(this, ouro);
        }
        
		#region Atualização do banco de dados

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        /// <remarks>
        /// O implementador deverá atribuir o valor
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
        /// O implementador deverá atribuir o valor
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
        /// O implementador deverá atribuir o valor
        /// falso para os atributos "cadastrado" e
        /// "atualizado".
        /// </remarks>
        protected override void Descadastrar(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

		#endregion

        /// <summary>
        /// Obtém fotos do banco de dados.
        /// </summary>
        /// <returns>Vetor de fotos.</returns>
        public Foto[] ObterFotos()
        {
            return Entidades.Álbum.Foto.ObterFotos(this);
        }

        public void CarregarAnimação()
        {
            if (!animaçãoJáObtida)
            {
                // Carregar do banco de dados
                animação = Álbum.Animação.ObterAnimação(this);
                animaçãoJáObtida = true;
            }
        }

        /// <summary>
        /// Libera a foto da memória.
        /// </summary>
        public void LiberarFoto()
        {
            if (animação != null)
            {
                animação.Dispose();
                animação = null;
                animaçãoJáObtida = false;
            }
        }

        /// <summary>
        /// Inicia carga em segundo plano das mercadorias.
        /// </summary>
        /// <remarks>
        /// Fica à cargo do programador chamar este método por fora.
        /// 
        /// Ele é chamado logo após autenticação no AoCarregarCompletamente de
        /// Apresentação.Formulários.BaseFormulário.
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
            return Referência;
        }

        /// <summary>
        /// Obtém rastreamento de todas as mercadorias.
        /// Dado uma referência, retorna o seu rastro.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<RastroConsignado>> ObterRastreamento()
        {
            Dictionary<string, List<RastroConsignado>> hash = new Dictionary<string, List<RastroConsignado>>(StringComparer.Ordinal);

            IDbConnection conexão = Conexão;
            List<RastroConsignado> resultado = new List<RastroConsignado>();

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
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
                         " ORDER BY SUM(si.quantidade) desc ", TAMANHO_REFERÊNCIA_RASTREÁVEL);

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (leitor.Read())
                            {
                                RastroConsignado rastro = new RastroConsignado();

                                rastro.ReferênciaNumérica = leitor.GetString(4);

                                rastro.Pessoa = new Entidades.Pessoa.PessoaCódigoNome(
                                    Convert.ToUInt64(leitor.GetValue(0)),
                                    leitor.GetString(1));
                                rastro.Devolução = leitor.IsDBNull(2) ? (DateTime?)null : (DateTime?)leitor.GetDateTime(2);
                                rastro.Quantidade = leitor.GetInt32(3);

                                // Procura uma lista para adicionar o rastro nela.
                                List<RastroConsignado> lista = null;
                                if (!hash.TryGetValue(ObterReferênciaRastreável(rastro.ReferênciaNumérica), out lista))
                                {
                                    lista = new List<RastroConsignado>();
                                    hash[ObterReferênciaRastreável(rastro.ReferênciaNumérica)] = lista;
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
            IDbConnection conexão = Conexão;
            List<RastroConsignado> resultado = new List<RastroConsignado>();

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT p.codigo, p.nome, a.previsao, SUM(si.quantidade) - ifnull(rastreamentovenda.qtd,0) - ifnull(rastreamentoretorno.qtd,0) " + 
                         " FROM saida s JOIN saidaitem si ON s.codigo = si.saida JOIN acertoconsignado a ON a.codigo = s.acerto " + 
                         " JOIN pessoa p ON p.codigo = a.cliente " + 
                         
                         " left join  " + 
                         " ( SELECT p.codigo, SUM(vi.quantidade) as qtd " + 
                         " FROM venda v JOIN vendaitem vi ON v.codigo = vi.venda JOIN acertoconsignado a ON a.codigo = v.acerto " + 
                         " JOIN pessoa p ON p.codigo = a.cliente " + 
                         " WHERE a.dataEfetiva IS NULL  " + 
                         " and referencia LIKE '" + ObterReferênciaRastreável() + "%' " + 
                         " GROUP BY p.codigo " + 
                         " ) " + 
                         " rastreamentovenda on p.codigo=rastreamentovenda.codigo " + 
                         
                         " left join " + 
                         " ( " + 
                         " SELECT p.codigo, SUM(ri.quantidade) as qtd " + 
                         " FROM retorno r JOIN retornoitem ri ON r.codigo = ri.retorno JOIN acertoconsignado a ON a.codigo = r.acerto " + 
                         " JOIN pessoa p ON p.codigo = a.cliente " + 
                         " WHERE a.dataEfetiva IS NULL  " +
                         " and referencia LIKE '" + ObterReferênciaRastreável() + "%' " + 
                         " GROUP BY p.codigo " + 
                         " ) rastreamentoretorno on p.codigo=rastreamentoretorno.codigo " + 
                         
                         " WHERE a.dataEfetiva IS NULL  " +
                         " and referencia LIKE '" + ObterReferênciaRastreável() + "%' " + 
                         " GROUP BY p.codigo " + 
                         " ORDER BY SUM(si.quantidade) desc";

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (leitor.Read())
                            {
                                RastroConsignado rastro = new RastroConsignado();

                                rastro.ReferênciaNumérica = ReferênciaNumérica;
                                rastro.Pessoa = new Entidades.Pessoa.PessoaCódigoNome(
                                    Convert.ToUInt64(leitor.GetValue(0)),
                                    leitor.GetString(1));
                                rastro.Devolução = leitor.IsDBNull(2) ? (DateTime?)null : (DateTime?)leitor.GetDateTime(2);
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

        private string ObterReferênciaRastreável()
        {
            return ObterReferênciaRastreável(ReferênciaNumérica);
        }

        public static string ObterReferênciaRastreável(string referência)
        {
            return referência?.Substring(0, TAMANHO_REFERÊNCIA_RASTREÁVEL);
        }

        /// <summary>
        /// Rastrea mercadoria em todos as vendas marcadas como rastrado.
        /// </summary>
        public List<RastroVenda> RastrearVenda()
        {
            IDbConnection conexão = Conexão;
            List<RastroVenda> resultado = new List<RastroVenda>();

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "select venda.codigo, venda.data, sum(quantidade) as qtd, cliente, nome from vendaitem, venda "
                        + " left join pessoa on cliente=pessoa.codigo where venda.rastreada=1 "
                        + " and venda.codigo=vendaitem.venda "
                        + " and referencia LIKE '" + ObterReferênciaRastreável() + "%' " 
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
                                rastro.Pessoa = new Entidades.Pessoa.PessoaCódigoNome(
                                    Convert.ToUInt64(leitor.GetValue(3)),
                                    leitor.GetString(4));
                                
                                rastro.Data = leitor.GetDateTime(1);
                                rastro.Quantidade = leitor.GetInt32(2);
                                rastro.Código = leitor.GetInt32(0);

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

        public static bool ConferirSeÉDePeso(string referênciaNumérica)
        {
            return MercadoriaCampos.ObterMercadoria(referênciaNumérica).DePeso;
        }

        /// <summary>
        /// O dígito é quanto falta para um número até sua proxima dezena, 
        /// sendo esse número a soma do triplo da soma dos dígitos impares com a soma dos dígitos pares.
        /// </summary>
        /// <param name="referênciaNumérica"></param>
        /// <returns></returns>
        public static int ObterDígito(string referênciaNumérica)
        {
            // Concatena zeros à direita até ter 11 dígitos
            if (referênciaNumérica.Length < TAMANHO_REFERÊNCIA)
                referênciaNumérica += new String('0', TAMANHO_REFERÊNCIA - referênciaNumérica.Length);

            // 48 é o ascii do zero '0'
            // Soma dos numeros de posição impar (1,3,5,9,11)
            int somaDígitosÍmpares =
                referênciaNumérica[0] - 48 +
                referênciaNumérica[2] - 48 +
                referênciaNumérica[4] - 48 +
                referênciaNumérica[6] - 48 +
                referênciaNumérica[8] - 48 +
                referênciaNumérica[10] - 48;

            int somaDígitosPares =
                referênciaNumérica[1] - 48 +
                referênciaNumérica[3] - 48 +
                referênciaNumérica[5] - 48 +
                referênciaNumérica[7] - 48 +
                referênciaNumérica[9] - 48;

            int contaMaluca = (somaDígitosÍmpares * 3) + somaDígitosPares;
            int digito = (10 - contaMaluca % 10);

            return digito % 10;
        }


        /// <summary>
        /// Rastro de mercadoria.
        /// </summary>
        public struct RastroConsignado
        {
            //public Mercadoria Mercadoria;
            public string ReferênciaNumérica;
            public Pessoa.PessoaCódigoNome Pessoa;
            public int Quantidade;
            public DateTime? Devolução;

        }

        /// <summary>
        /// Rastro de mercadoria.
        /// </summary>
        public struct RastroVenda
        {
            public int Código;
            public Mercadoria Mercadoria;
            public Pessoa.PessoaCódigoNome Pessoa;
            public int Quantidade;
            public DateTime? Data;

        }

        public void EsquecerCoeficientePersonalizado()
        {
            coeficiente = null;
        }
    }


    /// <summary>
	/// Código de barras inválido
	/// </summary>
    [Serializable]
	public class CódigoBarrasInválido : ApplicationException
	{
		public CódigoBarrasInválido() : base("Código de barras inválido!")
		{
		}

		public CódigoBarrasInválido(string mensagem) : base(mensagem)
		{
		}
	}
}
