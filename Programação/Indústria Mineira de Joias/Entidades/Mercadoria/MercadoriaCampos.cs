using Acesso.Comum;
using Acesso.Comum.Cache;
using Acesso.Comum.Exceções;
using Entidades.Árvores;
using System;
using System.Collections.Generic;
using System.Data;

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
    /// 
    /// Para otimizar a consulta de prefixos de mercadoria,
    /// o sistema carrega todas as mercadorias em segundo plano
    /// e as insere numa estrutura de árvore patrícia. Nesta árvore,
    /// só serão inseridas mercadorias que não sairam de linha.
    /// Para todos os efeitos, pesquisas de referência completa
    /// irão verificar o banco de dados sempre que ela não for
    /// encontrada na árvore.
    /// </remarks>
    [Serializable]
    [Cacheável("ObterMercadoriaSemCache"), Validade(0, 5, 0)]
    [DbTabela("mercadoria")]
	class MercadoriaCampos : DbManipulação, IDisposable, ICloneable, IMercadoriaCampos
	{
		protected string referencia;
		protected int digito = -1;
		protected string nome;
		protected int teor;
		protected double peso;
		protected string faixa;
		protected int? grupo;
		protected bool depeso;
		protected bool foradelinha;
        protected string classificacaofiscal;
        protected int tipounidade;
        protected int cfop;

        [NonSerialized]
		private DbFoto icone = null;
        private Coeficientes coeficientes = null;

        private static volatile Patricia<MercadoriaCampos> árvore;
        private static volatile bool carregandoPatricia = false;
        private static ControleCargaImagens controleCargaImagens = new ControleCargaImagens();

		/// <summary>
		/// Constrói uma mercadoria, sem obter do BD
		/// </summary>
		/// <param name="referência">Referência numérica</param>
		/// <param name="dígito">Dígito verificador</param>
		public MercadoriaCampos(string referência, int dígito)
		{
			this.referencia = referência;
			this.digito = dígito;

#if DEBUG
            if (!ValidarReferênciaNumérica(referência))
                throw new ArgumentException("Referência com tamanho errado.");
#endif
		}

        public MercadoriaCampos(string referência, int dígito, bool foraDeLinha, bool dePeso,
            double peso, string descrição, string faixa, int? grupo, int teor)
        {
            this.referencia = referência;
            this.digito = dígito;
            this.foradelinha = foraDeLinha;
            this.depeso = dePeso;
            this.teor = teor;
            this.peso = peso;
            this.nome = descrição;
            this.faixa = faixa;
            this.grupo = grupo;
        }

        public static bool ValidarReferênciaNumérica(string referênciaNumérica)
        {
            return referênciaNumérica.Length == 11;
        }
		
		/// <summary>
		/// Constrói uma mercadoria, não obtem do BD
		/// </summary>
		/// <param name="referência">Referência numérica</param>
		/// <param name="dígito">Dígito verificador</param>
		/// <param name="peso">Peso da mercadoria</param>
		public MercadoriaCampos(string referência, int dígito, double peso)
		{
			this.referencia = referência;
			this.digito = dígito;
			this.peso = peso;

#if DEBUG
            if (this.referencia.Length != 11)
                throw new ArgumentException("Referência com tamanho errado.");
#endif
        }

		/// <summary>
		/// Constrói uma mercadoria, não obtém do BD
		/// </summary>
		/// <param name="referência">Referência formatada</param>
		public MercadoriaCampos(string referência)
		{
			this.Referência = referência;
#if DEBUG
            if (this.referencia.Length != 11)
                throw new ArgumentException("Referência com tamanho errado.");
#endif
        }

		/// <summary>
		/// Constrói uma mercadoria vazia.
		/// </summary>
		/// 
		/// <remarks>
		/// Evite utilizar esta construtora. Ela é útil
		/// nas funções Mapear de recuperação de BD.
		/// </remarks>
		public MercadoriaCampos() {}
		
		private string referênciaFormatada = null;

		public string Referência
		{
			get
			{
				if (referênciaFormatada == null)
				{
					try
					{
						referênciaFormatada = Mercadoria.MascararReferência(referencia, digito);
					}
					catch
					{
						referênciaFormatada = referencia + " <Referência inválida!>";
					}
				}

				return referênciaFormatada;
			}
			set
			{
                Mercadoria.DesmascararReferência(value, out this.referencia, out this.digito);
				referênciaFormatada = null;
				// Caso o usuário obtenha a referência novamente, ela é re-processada.
                DefinirCadastrado(false);
                DefinirAtualizado(false);
#if DEBUG
            if (this.referencia.Length != 11)
                throw new ArgumentException("Referência com tamanho errado.");
#endif
            }
		}

		public int Dígito => digito;

		/// <summary>
		/// Referência numérica não formatada, sem dígito.
		/// </summary>
		public string ReferênciaNumérica
		{
			get { return referencia; }
		}

		/// <summary>
		/// Descrição da mercadoria
		/// </summary>
		public virtual string Descrição
		{
			get { return nome; }
			set { nome = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Teor da mercadoria
		/// </summary>
		public virtual int Teor
		{
			get { return teor; }
            set { teor = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Peso da mercadoria
		/// </summary>
		public virtual double PesoOriginal
		{
			get { return peso; }
			set
			{
				peso = value;
                DefinirDesatualizado();
			}
		}

		/// <summary>
		/// Faixa da meracdoria
		/// </summary>
		public virtual string Faixa
		{
			get { return faixa; }
            set { faixa = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Grupo da mercadoria
		/// </summary>
		public virtual int? Grupo
		{
			get { return grupo; }
            set { grupo = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Coeficiente da mercadoria. Só é igual ao índice para mercadorias de peça.
		/// </summary>
		public virtual Coeficientes Coeficientes
		{
            get { return coeficientes; } 
		}

		/// <summary>
		/// Mercadoria de peso
		/// </summary>
		public virtual bool DePeso
		{
			get { return depeso; }
            set { depeso = value; DefinirDesatualizado(); }
		}

		/// <summary>
		/// Fora de linha
		/// </summary>
		public virtual bool ForaDeLinha
		{
			get { return foradelinha; }
            set { foradelinha = value; DefinirDesatualizado(); }
		}

        public int CFOP => cfop;
        public int TipoUnidadeComercial => tipounidade;
        public string ClassificaçãoFiscal => classificacaofiscal;

		public void Dispose()
		{
            if (icone != null)
            {
                icone.Dispose();
                icone = null;
            }
		}

        public static IMercadoriaCampos[] ObterMercadorias(string prefixo, int limite)
        {
            return ObterMercadorias(prefixo, limite, false);
        }

		/// <summary>
		/// Obtém vetor de mercadorias
		/// </summary>
		/// <param name="prefixo">Prefixo da referência</param>
		/// <param name="limite">Limite de referências</param>
		/// <returns>Vetor de mercadorias do tipo Entidade.Mercadoria</returns>
        /// <remarks>
        /// Não são recuperadas mercadorias fora de linha.
        /// </remarks>
        public static IMercadoriaCampos[] ObterMercadorias(string prefixo, int limite, bool somenteComFotos)
        {
            string procura;
            int dígito;

            // Obter somente números do prefixo
            Mercadoria.DesmascararReferência(prefixo, out procura, out dígito);

            if (árvore != null)
            {
                PatriciaPrefixoEnumerator<MercadoriaCampos> enumerador;
                MercadoriaCampos[] campos;
                int i = 0;

                enumerador = árvore.GetPrefixo(procura);
                campos = new MercadoriaCampos[Math.Min(enumerador.Count, limite)];

                while (i < limite && enumerador.MoveNext())
                    campos[i++] = enumerador.Current;

                return campos;
            }
            else
            {
                IDbConnection conexão;
                List<MercadoriaCamposLeve> campos = new List<MercadoriaCamposLeve>();

                // Constrói comando
                conexão = Conexão;

                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        IDataReader leitor = null;

                        if (somenteComFotos)
                        {
                            // Recuperar mercadorias
                            cmd.CommandText = "SELECT distinct mercadoria.referencia, mercadoria.digito, mercadoria.dePeso, mercadoria.peso "
                                + "FROM mercadoria, foto  WHERE foto.mercadoria=referencia AND referencia LIKE '" + procura + "%' AND foradelinha = 0 LIMIT " + limite.ToString();
                        }
                        else
                        {
                            cmd.CommandText = "SELECT referencia, digito, dePeso, peso "
                                + "FROM mercadoria WHERE referencia LIKE '" + procura + "%' AND foradelinha = 0 LIMIT " + limite.ToString();

                        }

                        try
                        {
                            using (leitor = cmd.ExecuteReader())
                            {

                                while (leitor.Read())
                                    campos.Add(new MercadoriaCamposLeve(
                                        leitor.GetString(0),
                                        leitor.GetByte(1),
                                        null,
                                        leitor.GetBoolean(2),
                                        leitor.GetDouble(3)));
                            }
                        }
                        finally
                        {
                            if (leitor != null && !leitor.IsClosed)
                                leitor.Close();
                        }
                    }
                }

                return campos.ToArray();
            }
        }

        /// <summary>
        /// Obtém mercadoria a partir da referência completa e formatada.
        /// </summary>
        /// <param name="referência">Referência completa e formatada.</param>
        /// <returns>Campos da mercadoria.</returns>
        /// <remarks>
        /// Essa consulta é otimizada pelo uso de árvore patrícia,
        /// porém caso a mercadoria seja fora de linha, a consulta
        /// será realizada no banco de dados.
        /// </remarks>
        public static MercadoriaCampos ObterMercadoria(string referência)
        {
            MercadoriaCampos campos;
            string procura;			// Chave de proucra
            int dígito;

            Mercadoria.DesmascararReferência(referência, out procura, out dígito);

            if (árvore != null && árvore.TryGetValue(procura, out campos))
                return campos;

            /* Mesmo que a mercadoria não esteja na árvore, ela
             * será pesquisada no banco de dados, visto que
             * ela pode ser fora de linha e, portanto, não
             * constar na árvore de mercadorias.
             * -- Júlio, 18/11/2006
             */
            return CacheDb.Instância.ObterEntidade(typeof(MercadoriaCampos), referência) as MercadoriaCampos;
        }

        /// <summary>
        /// Realiza a consulta no banco de dados.
        /// </summary>
        /// <param name="referência">Referência completa.</param>
        /// <returns>Campos da mercadoria.</returns>
		public static MercadoriaCampos ObterMercadoriaSemCache(string referência)
		{
			string			 procura;			// Chave de proucra
			int				 dígito;
			MercadoriaCampos mercadoria;
			IDbConnection	 conexão;

            if (árvore == null)
                IniciarCarga();

			// Obter somente números do prefixo
			Mercadoria.DesmascararReferência(referência, out procura, out dígito);

			conexão = Conexão;

			lock (conexão)
			{
				// Constrói comando
				using (IDbCommand cmd = conexão.CreateCommand())
				{
					// Recuperar mercadorias
                    if (dígito < 0)
                        cmd.CommandText = "SELECT * "
                            + "FROM mercadoria WHERE referencia = " + DbTransformar(procura);
                    else
                        cmd.CommandText = "SELECT * "
                            + "FROM mercadoria WHERE referencia = " + DbTransformar(procura)
                            + " AND digito = " + DbTransformar(dígito);

					mercadoria = MapearÚnicaLinha<MercadoriaCampos>(cmd);

                    if (mercadoria != null)
                    {
                        mercadoria.coeficientes = new Coeficientes();

                        cmd.CommandText = "SELECT tabela, coeficiente FROM tabelamercadoria WHERE mercadoria = " + DbTransformar(procura);

                        foreach (TabelaMercadoria item in Mapear<TabelaMercadoria>(cmd))
                            mercadoria.coeficientes.AdicionarCoeficiente(item.tabela, item.coeficiente);
                    }
				}
			}

			return mercadoria;
		}


		/// <summary>
		/// Obtém mercadoria
		/// </summary>
		/// <param name="referência">Referência numérica da mercadoria</param>
		/// <returns>Mercadoria</returns>
		public static MercadoriaCampos ObterMercadoriaSemDígito(string referência)
		{
			MercadoriaCampos mercadoria;

            if (!árvore.TryGetValue(referência, out mercadoria))
            {
                IDbConnection conexão;

                conexão = Conexão;

                lock (conexão)
                {
                    // Constrói comando
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {

                        // Recuperar mercadorias
                        cmd.CommandText = "SELECT * "
                            + "FROM mercadoria WHERE referencia = " + DbTransformar(referência);

                        mercadoria = MapearÚnicaLinha<MercadoriaCampos>(cmd);
                    }
                }
            }

			return mercadoria;
		}

		/// <summary>
		/// Não cria outro objeto, mas atualiza as propriedades com o banco de dados.
		/// É útil no AtualizaObjetosIntrínsecos() do Entidades.Saquinho.Saquinho.
		/// </summary>
		public void ReobterInformações()
		{
			MercadoriaCampos fresca;
			
			fresca = ObterMercadoriaSemCache(Referência);

			if (fresca != null)
			{
				digito = fresca.digito;
				faixa = fresca.faixa;
				grupo = fresca.grupo;
				depeso = fresca.depeso;
				foradelinha = fresca.foradelinha;
				nome = fresca.nome;
				peso = fresca.peso;
				teor = fresca.teor;
			}
		}


		/// <summary>
		/// Gera um código hash.
		/// </summary>
		public override int GetHashCode()
		{
			int hash, contador;

			hash = contador = 0;

			foreach (char c in referencia)
			{
				hash    ^= c << contador;
				contador = (contador + 8) % (8 * 4);
			}

			hash ^= Convert.ToInt32(peso * 1000);

			return hash;
		}

		/// <summary>
		/// Verifica equivalência com outro objeto.
		/// </summary>
		public override bool Equals(object obj)
		{
			MercadoriaCampos outra = obj as MercadoriaCampos;

			return outra != null && this.referencia == outra.referencia
				&& this.peso == outra.peso && this.digito == outra.digito
				&& this.nome == outra.nome && this.teor == outra.teor
				&& this.peso == outra.peso && this.faixa == outra.faixa
				&& this.grupo == outra.grupo 
                && this.depeso == outra.depeso && this.foradelinha == outra.foradelinha;
		}
		
		/// <summary>
		/// Compara igualdade entre duas mercadorias.
		/// </summary>
		public static bool operator == (MercadoriaCampos a, MercadoriaCampos b)
		{
			if (((object) a) == null || ((object) b) == null)
				return ((object) a) == ((object) b);

			return a.Equals(b);
		}

		/// <summary>
		/// Compara diferença entre duas mercadorias.
		/// </summary>
		public static bool operator != (MercadoriaCampos a, MercadoriaCampos b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Realiza uma cópia profunda do objeto
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			MercadoriaCampos clonada = new MercadoriaCampos(referencia, digito);

			clonada.DePeso = DePeso;
			clonada.Descrição = Descrição != null ?
				(string) Descrição.Clone() : null;
			clonada.Faixa = Faixa;
			clonada.ForaDeLinha = ForaDeLinha;
			clonada.Grupo = Grupo;
			clonada.PesoOriginal = PesoOriginal;
			clonada.Teor = Teor;

			return clonada;
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
		}

        protected override void Cadastrar(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public static bool VerificarExistênciaÁrvore(string procura)
        {
            return árvore != null && árvore.Contains(procura);
        }

        public static bool ÁrvoreCarregada
        {
            get
            {
                return árvore != null;
            }
        }

        internal static MercadoriaCampos ObterReferênciaPróxima(string chave)
        {
            return árvore.GetFirstPrefix(chave);
        }

        /// <summary>
        /// Inicia carga em primeiro plano das mercadorias.
        /// </summary>
        public static void IniciarCarga()
        {
            if (carregandoPatricia)
                return;

            carregandoPatricia = true;
            árvore     = null;

            Carregar();
        }

        /// <summary>
        /// Carrega as mercadorias inserindo-as na árvore.
        /// </summary>
        private static void Carregar()
        {
            IDbConnection conexão = Conexão;

            if (Usuários.UsuárioAtual == null) return;
            Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

            try
            {
                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM mercadoria WHERE foradelinha = 0";

                        List<MercadoriaCampos> lista = Mapear<MercadoriaCampos>(cmd);
                        Patricia<MercadoriaCampos> árvore;

#if DEBUG
                        Console.WriteLine("Construindo árvore de mercadorias!");
#endif

                        árvore = new Patricia<MercadoriaCampos>();

                        foreach (MercadoriaCampos m in lista)
                        {
                            if (!String.IsNullOrEmpty(m.ReferênciaNumérica))
                                árvore.Add(m.ReferênciaNumérica, m);

                            m.Alterado += new DbManipulaçãoHandler(AoAlterarMercadoria);
                        }

                        // Carregar coeficientes.
                        cmd.CommandText = "SELECT * FROM tabelamercadoria";
                        List<TabelaMercadoria> coeficientes = Mapear<TabelaMercadoria>(cmd);

                        foreach (TabelaMercadoria item in coeficientes)
                        {
                            MercadoriaCampos m;
                            System.Diagnostics.Debug.Assert(item.mercadoria != null, "A mercadoria não deveria ser nula");

                            // Mercadorias fora de linha não são consideradas.
                            if (árvore.TryGetValue(item.mercadoria, out m))
                            {
#if DEBUG
                                System.Diagnostics.Debug.Assert(m.referencia == item.mercadoria);
#endif
                                if (m.coeficientes == null)
                                    m.coeficientes = new Coeficientes();

                                m.coeficientes.AdicionarCoeficiente(item.tabela, item.coeficiente);
                            }
                        }

                        MercadoriaCampos.árvore = árvore;
#if DEBUG
                        Console.WriteLine("Árvore construída!");
#endif
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, e.Message);
                Usuários.UsuárioAtual.RegistrarErro(new Exception("Erro montando árvore de mercadorias.", e));
            }
            finally
            {
                carregandoPatricia = false;
#if DEBUG
                System.Diagnostics.Debug.Assert(((Acesso.Comum.Adaptadores.ConexãoConcorrente)conexão).Ocupado == 0);
#endif
                Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
            }
        }

        private static void AoAlterarMercadoria(DbManipulação entidade)
        {
            árvore = null;
        }

        /// <summary>
        /// Libera a foto da memória.
        /// </summary>
        public void LiberarÍcone()
        {
            if (icone != null)
            {
                lock (this)
                {
                    icone.Dispose();
                    icone = null;
                }
            }
        }

    }
}
