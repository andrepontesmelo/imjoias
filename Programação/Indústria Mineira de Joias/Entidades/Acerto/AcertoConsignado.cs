using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Pessoa;
using Entidades.Relacionamento.Saída;
using Entidades.Relacionamento.Venda;
using Entidades.Relacionamento.Retorno;
using System.Data;
using Entidades.Configuração;
using Acesso.Comum.Cache;
using Entidades.Relacionamento;
using System.Collections;
using System.Threading;

namespace Entidades.Acerto
{
    /// <summary>
    /// Acerto de consignado. A cada inserção de item ou documento,
    /// verifica-se se a consistência do acerto está correta, isto é,
    /// se não existe mercadorias com mesma referência, porém com
    /// índices diferentes.
    /// </summary>
    [Cacheável("ObterAcerto"), NãoCopiarCache, DbTransação]
    public class AcertoConsignado : DbManipulaçãoAutomática
    {
        #region Atributos

#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbChavePrimária(true), DbColuna("codigo")]
        private ulong código;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbRelacionamento("codigo", "cliente")]
        private Pessoa.Pessoa cliente;

        [DbRelacionamento("codigo", "funcConsignado")]
        private Funcionário funcConsignado;

        [DbRelacionamento("codigo", "funcAcerto")]
        private Funcionário funcAcerto;

        [DbColuna("previsao")]
        private DateTime? previsão = null;

        private DateTime? dataEfetiva = null;

        [DbColuna("dataMarcacao")]
        private DateTime dataMarcação = DateTime.Now;

        //private bool acertado = false;

        [DbColuna("formulaAcerto")]
        private FórmulaAcerto fórmulaAcerto;

        [DbColuna("cotacao")]
        private double? cotação;

        private DbComposição<Saída> saídas;
        private DbComposição<Retorno> retornos;
        private DbComposição<Venda> vendas;

        #endregion

        #region Propriedades

        /// <summary>
        /// Código do acerto.
        /// </summary>
        public ulong Código { get { return código; } }


        public FórmulaAcerto FórmulaAcerto
        {
            get { return fórmulaAcerto; }
            set 
            { 
                fórmulaAcerto = value;
                DefinirDesatualizado();
            }
        }
                

        /// <summary>
        /// Cliente.
        /// </summary>
        public Pessoa.Pessoa Cliente { get { return cliente; } set { cliente = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Funcionário que registrou o consignado.
        /// </summary>
        public Funcionário FuncConsignado { get { return funcConsignado; } set { funcConsignado = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Funcionário que realizou o acerto.
        /// </summary>
        public Funcionário FuncAcerto { get { return funcAcerto; } set { funcAcerto = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Previsão do acerto.
        /// </summary>
        public DateTime? Previsão { get { return previsão; } set { previsão = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Data efetiva do acerto, quando ele foi acertado.
        /// </summary>
        public DateTime? DataEfetiva { get { return dataEfetiva; } set { dataEfetiva = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Data em que foi marcado/cadastrado o acerto.
        /// </summary>
        public DateTime DataMarcação { get { return dataMarcação; } }

        /// <summary>
        /// Se acertado.
        /// </summary>
        public bool Acertado 
        { 
            get 
            { 
                return DataEfetiva.HasValue; 
            } 
        }

        /// <summary>
        /// Lista de saídas.
        /// </summary>
        public DbComposição<Saída> Saídas
        {
            get
            {
                if (saídas == null)
                    ObterSaídas();

                return saídas;
            }
        }

        /// <summary>
        /// Lista de retornos.
        /// </summary>
        public DbComposição<Retorno> Retornos
        {
            get
            {
                if (retornos == null)
                    ObterRetornos();

                return retornos;
            }
        }

        /// <summary>
        /// Lista de vendas.
        /// </summary>
        public DbComposição<Venda> Vendas
        {
            get
            {
                if (vendas == null)
                    ObterVendas();

                return vendas;
            }
        }

        /// <summary>
        /// Tabela de preço.
        /// </summary>
        public Tabela TabelaPreço
        {
            get
            {
                if (saídas != null)
                {
                    // Todas as saídas usam a mesma tabela.
                    if (Saídas.ContarElementos() > 0)
                        return Saídas.ExtrairElementos()[0].TabelaPreço;
                }
                else
                {
                    if (Cadastrado)
                    {
                        IDbConnection conexão = Conexão;
                        object tabela;

                        lock (conexão)
                            using (IDbCommand cmd = conexão.CreateCommand())
                            {
                                cmd.CommandText = "SELECT tabela FROM saida WHERE acerto = " + DbTransformar(código) + " LIMIT 1";

                                tabela = cmd.ExecuteScalar();
                            }

                        if (!(tabela is DBNull))
                            return Entidades.Tabela.ObterTabela(Convert.ToUInt32(tabela));
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Cotação no momento da saída.
        /// </summary>
        public double? Cotação
        {
            get { return cotação; }
            set { cotação = value; DefinirDesatualizado(); }
        }

        #endregion

        #region Exceções

        public class DocumentoEmOutroAcerto : ApplicationException
        {
            public DocumentoEmOutroAcerto()
                : base("Não é permitido atribuir um documento a um acerto, quando ele já fizer parte de outro.")
            {
            }
        }

        public class DocumentoInconsistente : ApplicationException
        {
            public DocumentoInconsistente(string inconsistência)
                : base(inconsistência)
            { }
        }

        #endregion

        #region Recuperação de dados

        /// <summary>
        /// Obtém todos os acertos de um determinado período.
        /// </summary>
        public static AcertoConsignado[] ObterAcertos(Entidades.Pessoa.Pessoa pessoa, DateTime início, DateTime final)
        {
            return Mapear<AcertoConsignado>(
                string.Format(
                "SELECT * FROM acertoconsignado WHERE cliente = {0} AND (dataMarcacao BETWEEN {1} AND {2} OR dataEfetiva BETWEEN {1} AND {2} OR previsao BETWEEN {1} AND {2})",
                DbTransformar(pessoa.Código),
                DbTransformar(início), DbTransformar(final))).ToArray();
        }

        private void ObterSaídas()
        {
            if (Cadastrado)
            {
                saídas = new DbComposição<Saída>(
                    Saída.ObterSaídas(this),
                    new DbAção<Saída>(AdicionarSaída),
                    null,
                    new DbAção<Saída>(RemoverSaída));
            }
            else
                saídas = new DbComposição<Saída>(
                    new DbAção<Saída>(AdicionarSaída),
                    null,
                    new DbAção<Saída>(RemoverSaída));

            saídas.AoAdicionar += new DbComposição<Saída>.EventoComposição(AoAdicionarSaída);
            saídas.AoRemover += new DbComposição<Saída>.EventoComposição(AoRemoverSaída);
        }

        private void ObterRetornos()
        {
            if (Cadastrado)
            {
                retornos = new DbComposição<Retorno>(
                    Retorno.ObterRetornos(this),
                    new DbAção<Retorno>(AdicionarRetorno),
                    null,
                    new DbAção<Retorno>(RemoverRetorno));
            }
            else
                retornos = new DbComposição<Retorno>(
                    new DbAção<Retorno>(AdicionarRetorno),
                    null,
                    new DbAção<Retorno>(RemoverRetorno));

            retornos.AoAdicionar += new DbComposição<Retorno>.EventoComposição(AoAdicionarRetorno);
        }

        private void ObterVendas()
        {
            if (Cadastrado)
            {
                vendas = new DbComposição<Venda>(
                    Venda.ObterVendas(this),
                    new DbAção<Venda>(AdicionarVenda),
                    null,
                    new DbAção<Venda>(RemoverVenda));
            }
            else
                vendas = new DbComposição<Venda>(
                    new DbAção<Venda>(AdicionarVenda),
                    null,
                    new DbAção<Venda>(RemoverVenda));

            vendas.AoAdicionar += new DbComposição<Venda>.EventoComposição(AoAdicionarVenda);
            vendas.AoRemover += new DbComposição<Venda>.EventoComposição(AoRemoverVenda);
        }

        /// <summary>
        /// Obtém um acerto específico.
        /// </summary>
        public static AcertoConsignado ObterAcerto(ulong código)
        {
            return MapearÚnicaLinha<AcertoConsignado>(
                "SELECT * FROM acertoconsignado WHERE codigo = " + DbTransformar(código));
        }

        /// <summary>
        /// Obtém todos os acertos pendentes de uma pessoa.
        /// </summary>
        public static AcertoConsignado[] ObterAcertosPendentes(Entidades.Pessoa.Pessoa pessoa)
        {
            return Mapear<AcertoConsignado>(
                "SELECT * FROM acertoconsignado WHERE dataefetiva is null AND " +
                "cliente = " + DbTransformar(pessoa.Código) +
                " ORDER BY previsao").ToArray();
        }

        /// <summary>
        /// Obtém todos os acertos pendentes.
        /// </summary>
        public static AcertoConsignado[] ObterAcertosPendentes()
        {
            AcertoConsignado[] lista;

            DateTime inicio = DateTime.Now;

            lista = Obter("SELECT * FROM acertoconsignado " +
                " join pessoa on cliente=pessoa.codigo " +
                " left join pessoafisica pf on pessoa.codigo=pf.codigo " +
                " left join pessoajuridica on pessoa.codigo=pessoajuridica.codigo " +
                " WHERE dataefetiva is null ORDER BY previsao", 0, 9, 21).ToArray();

            TimeSpan tempo = DateTime.Now - inicio;

            return lista;
        }

        private static List<AcertoConsignado> Obter(string consulta, int inicioAcertoConsignado, int inicioPessoa, int inicioPessoaFisica)
        {
            List<AcertoConsignado> lista = new List<AcertoConsignado>();
            IDataReader leitor = null;
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = consulta;

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                AcertoConsignado entidade = new AcertoConsignado();
                                entidade.código = (ulong)leitor.GetInt64(inicioAcertoConsignado);

                                entidade.cliente = Pessoa.Pessoa.ObterPessoa(leitor, inicioPessoa, inicioPessoaFisica, 0);

                                entidade.funcConsignado = Funcionário.ObterPessoa((ulong)leitor.GetInt64(inicioAcertoConsignado + 2));

                                if (leitor["funcAcerto"] != DBNull.Value)
                                    entidade.funcAcerto = Funcionário.ObterPessoa((ulong)leitor.GetInt64(inicioAcertoConsignado + 3));

                                if (leitor["previsao"] != DBNull.Value)
                                    entidade.previsão = leitor.GetDateTime(inicioAcertoConsignado + 4);

                                if (leitor["dataEfetiva"] != DBNull.Value)
                                    entidade.dataEfetiva = leitor.GetDateTime(inicioAcertoConsignado + 5);

                                entidade.dataMarcação = leitor.GetDateTime(inicioAcertoConsignado + 6);

                                if (leitor["cotacao"] != DBNull.Value)
                                    entidade.cotação = leitor.GetDouble(inicioAcertoConsignado + 7);

                                entidade.fórmulaAcerto = (FórmulaAcerto)Enum.ToObject(typeof(FórmulaAcerto), leitor.GetInt32(inicioAcertoConsignado + 8));

                                entidade.DefinirCadastrado();
                                entidade.DefinirAtualizado();

                                lista.Add(entidade);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                    }
                }

            }

            return lista;
        }

        /// <summary>
        /// Obtém todos os acertos pendentes.
        /// </summary>
        /// <param name="data">Data da previsão de acerto.</param>
        public static AcertoConsignado[] ObterAcertosPendentes(DateTime data)
        {
            return Mapear<AcertoConsignado>(
                "SELECT * FROM acertoconsignado WHERE dataefetiva is null AND " +
                "DATE(previsao) = DATE(" + DbTransformar(data) + ")" +
                " ORDER BY previsao").ToArray();
        }

        #endregion

        #region Manipulação de relacionamentos

        /// <summary>
        /// Antes de atualizar um relacioamento.
        /// </summary>
        /// <param name="entidade">Entidade a ser verificada.</param>
        /// <param name="cancelar">Se deve cancelar a operação.</param>
        /// <exception cref="DocumentoInconsistente">Tabela ou índice de mercadoria ou cliente inconsistente.</exception>
        void AntesDeAtualizarRelacionamento(DbManipulação entidade, out bool cancelar)
        {
            Relacionamento.RelacionamentoAcerto relacionamento = (Relacionamento.RelacionamentoAcerto)entidade;

            /* Garantir que a entidade ainda está vinculada
             * a este acerto.
             */
            if (relacionamento.AcertoConsignado != null &&
                relacionamento.AcertoConsignado.Equals(this))
            {
                cancelar = true;

                GarantirConsitênciaPreço(relacionamento);
                GarantirConsistênciaPessoa(relacionamento);
            }

            cancelar = false;
        }

        /// <summary>
        /// Ocorre ao adicionar uma saída.
        /// </summary>
        void AoAdicionarSaída(DbComposição<Saída> composição, Saída entidade)
        {
            GarantirConsistênciaAdição(entidade, composição);
            entidade.DefinirAcertoConsignado(this);

            if (!Cadastrado)
                entidade.AntesDeCadastrar += new DbManipulaçãoCancelávelHandler(AntesDeCadastrarSaída);

            entidade.AntesDeAtualizar += new DbManipulaçãoCancelávelHandler(AntesDeAtualizarRelacionamento);
        }

        /// <summary>
        /// Disparado antes de cadastrar uma saída.
        /// </summary>
        private void AntesDeCadastrarSaída(DbManipulação entidade, out bool cancelar)
        {
            if (!Cadastrado)
            {
                // Verificar se realmente a entidade é deste acerto.
                if (!Saídas.Contém((Saída)entidade))
                {
                    cancelar = false;
                    return;
                }

                // Atribuir cotação caso cliente não seja do alto-atacado
                if (!cotação.HasValue && ((Saída)entidade).Pessoa.Setor == null || ((Saída)entidade).Pessoa.Setor.Código != Setor.ObterSetor(SetorSistema.AltoAtacado).Código)
                {
                    double valor = ((Saída)entidade).Cotação;

                    if (valor <= 0)
                        throw new NotSupportedException("Cotação deve ser maior que zero.");

                    cotação = valor;
                }

                Cadastrar();
            }

            cancelar = false;
        }

        /// <summary>
        /// Ocorre ao remover uma saída.
        /// </summary>
        void AoRemoverSaída(DbComposição<Saída> composição, Saída entidade)
        {
            if (entidade.AcertoConsignado != null && entidade.AcertoConsignado.Equals(this))
                entidade.DefinirAcertoConsignado(null);
        }

        /// <summary>
        /// Adiciona a saída no banco de dados.
        /// </summary>
        private void AdicionarSaída(IDbCommand cmd, Saída saída)
        {
            AtualizarEntidade(cmd, saída);
        }

        /// <summary>
        /// Remove a saída deste acerto no banco de dados.
        /// </summary>
        private void RemoverSaída(IDbCommand cmd, Saída saída)
        {
            AtualizarEntidade(cmd, saída);
        }

        /// <summary>
        /// Ocorre ao adicionar um retorno.
        /// </summary>
        private void AoAdicionarRetorno(DbComposição<Retorno> composição, Retorno entidade)
        {
            GarantirConsistênciaAdição(entidade, composição);
            entidade.DefinirAcertoConsignado(this);
            entidade.AntesDeAtualizar += new DbManipulaçãoCancelávelHandler(AntesDeAtualizarRelacionamento);
        }

        /// <summary>
        /// Adiciona o retorno no banco de dados.
        /// </summary>
        private void AdicionarRetorno(IDbCommand cmd, Retorno retorno)
        {
            AtualizarEntidade(cmd, retorno);
        }

        /// <summary>
        /// Remove o retorno deste acerto no banco de dados.
        /// </summary>
        private void RemoverRetorno(IDbCommand cmd, Retorno retorno)
        {
            AtualizarEntidade(cmd, retorno);
        }

        /// <summary>
        /// Ocorre ao adicionar uma venda.
        /// </summary>
        private void AoAdicionarVenda(DbComposição<Venda> composição, Venda entidade)
        {
            GarantirConsistênciaAdição(entidade, composição);
            entidade.DefinirAcertoConsignado(this);
            entidade.AntesDeAtualizar += new DbManipulaçãoCancelávelHandler(AntesDeAtualizarRelacionamento);
        }

        /// <summary>
        /// Ocorre ao remover uma venda.
        /// </summary>
        private void AoRemoverVenda(DbComposição<Venda> composição, Venda entidade)
        {
            if (entidade.AcertoConsignado != null && entidade.AcertoConsignado.Equals(this))
                entidade.DefinirAcertoConsignado(null);
        }

        /// <summary>
        /// Adiciona a venda no banco de dados.
        /// </summary>
        private void AdicionarVenda(IDbCommand cmd, Venda venda)
        {
            AtualizarEntidade(cmd, venda);
        }

        /// <summary>
        /// Remove a venda deste acerto no banco de dados.
        /// </summary>
        private void RemoverVenda(IDbCommand cmd, Venda venda)
        {
            AtualizarEntidade(cmd, venda);
        }

        public bool Contém(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (relacionamento is Saída)
                return Saídas.Contém((Saída) relacionamento);
            else if (relacionamento is Retorno)
                return Retornos.Contém((Retorno) relacionamento);
            else if (relacionamento is Venda)
                return Vendas.Contém((Venda) relacionamento);
            else
                throw new NotSupportedException();
        }

        public void Remover(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (relacionamento is Saída)
                Saídas.Remover((Saída)relacionamento);
            else if (relacionamento is Retorno)
                Retornos.Remover((Retorno)relacionamento);
            else if (relacionamento is Venda)
                Vendas.Remover((Venda)relacionamento);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Adiciona um documento de relacionamento ao acerto.
        /// </summary>
        /// <exception cref="DocumentoEmOutroAcerto">Documento adicionado já encontrava-se em outro acerto.</exception>
        /// <exception cref="DocumentoInconsistente">Tabela ou índice de mercadoria inconsistente.</exception>
        public void Adicionar(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (relacionamento is Saída)
                Saídas.Adicionar((Saída)relacionamento);
            else if (relacionamento is Retorno)
                Retornos.Adicionar((Retorno)relacionamento);
            else if (relacionamento is Venda)
                Vendas.Adicionar((Venda)relacionamento);
            else
                throw new NotSupportedException();
        }

        #endregion

        #region Manipulação de dados

        protected override void Cadastrar(IDbCommand cmd)
        {
            dataMarcação = DadosGlobais.Instância.HoraDataAtual;

            base.Cadastrar(cmd);
        }

        #endregion

        #region Garantia de consistência

        /// <summary>
        /// Controla a sincronização entre a thread atual e a thread
        /// de recuperação dos dados.
        /// </summary>
        [DbAtributo(TipoAtributo.Ignorar)]
        private EventWaitHandle sincronização;

        /// <summary>
        /// Prepara a verificação de consistência, carregando
        /// em segundo plano, se necessário, os itens dos documentos
        /// relacionados.
        /// </summary>
        public void PrepararVerificaçãoConsistência()
        {
            if (hashÍndice == null)
            {
                /* Para construir o hash de índices, é necessário
                 * carregar todos os itens das saídas, retornos e vendas,
                 * sendo a consulta mais demorada do sistema.
                 * Se possível, faremos em segundo plano.
                 */
                int d1, d2;

                ThreadPool.GetAvailableThreads(out d1, out d2);

                if (d1 > 0 && d2 > 0)
                {
                    sincronização = new EventWaitHandle(false, EventResetMode.ManualReset);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ConstruirHashÍndices));
                }
                else
                    ConstruirHashÍndices(null);
            }
        }

        /// <remarks>
        /// Não acesse diretamente esta variável. Prefira
        /// sempre acessar a propriedade.
        /// </remarks>
        [DbAtributo(TipoAtributo.Ignorar)]
        private Dictionary<string, double> hashÍndice;

        private Dictionary<string, double> HashÍndice
        {
            get
            {
                if (hashÍndice == null)
                {
                    /* Verificar se não está sendo carregado em segundo
                     * plano.
                     */
                    if (sincronização != null)
                        sincronização.WaitOne();
                    else
                        ConstruirHashÍndices(null);
                }

                return hashÍndice;
            }
        }

        private void ConstruirHashÍndices(object estado)
        {
            Dictionary<string, double> hashÍndice = new Dictionary<string, double>(StringComparer.Ordinal);

            // Gerar índice.
            try
            {
                IDbConnection conexão = Conexão;

                lock (conexão)
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "(SELECT referencia, peso, indice FROM saidaitem i JOIN saida s ON i.saida = s.codigo WHERE acerto = " + DbTransformar(código) + ")"
                            + "UNION (SELECT referencia, peso, indice FROM retornoitem i JOIN retorno r ON i.retorno = r.codigo WHERE acerto = " + DbTransformar(código) + ")"
                            + "UNION (SELECT referencia, peso, indice FROM vendaitem i JOIN venda v ON i.venda = v.codigo WHERE acerto = " + DbTransformar(código) + ")";

                        using (IDataReader leitor = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (leitor.Read())
                                    hashÍndice[leitor.GetString(0) + leitor.GetString(1)] = leitor.GetDouble(2);
                            }
                            finally
                            {
                                leitor.Close();
                            }
                        }
                    }
                
                this.hashÍndice = hashÍndice;
            }
            finally
            {
                // Sinalizar o término da construção.
                if (sincronização != null)
                    sincronização.Set();
            }
        }

        /// <summary>
        /// Garante a consistência do documento adicionado com o
        /// restante do acerto.
        /// </summary>
        /// <param name="entidade">Relacionamento a ser verificado.</param>
        /// <param name="composição">Conjunto de dados a ser verificado.</param>
        /// <exception cref="DocumentoEmOutroAcerto">Documento adicionado já encontrava-se em outro acerto.</exception>
        /// <exception cref="DocumentoInconsistente">Tabela ou índice de mercadoria inconsistente.</exception>
        private void GarantirConsistênciaAdição(Relacionamento.RelacionamentoAcerto entidade, IEnumerable composição)
        {
            try
            {
                if (entidade.AcertoConsignado != null)
                    throw new DocumentoEmOutroAcerto();

                if (Acertado)
                    throw new NotSupportedException("Não é possível adicionar um documento a um acerto já finalizado.");

                GarantirConsitênciaPreço(entidade);
                GarantirConsistênciaPessoa(entidade);
            }
            catch (Exception e)
            {
                Remover(entidade);
                throw e;
            }

            Venda venda = entidade as Venda;

            entidade.AntesDeCadastrarItem += new Entidades.Relacionamento.Relacionamento.AntesDeCadastrarItemCallback(AntesDeCadastrarItemRelacionamento);
        }

        /// <summary>
        /// Garante que todas os relacionamentos possuem o mesmo índice.
        /// </summary>
        /// <param name="relacionamento">Relacionamento a ser verificado.</param>
        /// <exception cref="DocumentoInconsistente">Tabela ou índice de mercadoria inconsistente.</exception>
        private void GarantirConsitênciaPreço(Relacionamento.RelacionamentoAcerto entidade)
        {
            if (entidade.TabelaPreço == null)
                entidade.TabelaPreço = TabelaPreço;

                /* um acerto de auto atacado pega documentos de tabela diferente.
                 * andré 15/01/2008
                 */

            else if (!entidade.TabelaPreço.Equals(TabelaPreço)
                && (cliente.Setor == null || Setor.ObterSetor(SetorSistema.AltoAtacado).Código != cliente.Setor.Código))
            {
                throw new DocumentoInconsistente("A tabela de preço não é a mesma utilizada no acerto.");
            }

            /* Verificar cotação apenas para clientes do atacado, visto
             * que representantes e alto-atacadistas sempre vendem na
             * cotação vigente e saem em outra data. Para representantes,
             * a cotação da saída não é relevante.
             * 
             * Verificação de consistencia para cotaçao comentada em 3/dez/07 
             * solicitado por toninho., André.
             */
            if (cotação.HasValue && !Representante.ÉRepresentante(cliente)
                && (cliente.Setor == null || Setor.ObterSetor(SetorSistema.AltoAtacado).Código != cliente.Setor.Código))
            {
                if (entidade is Saída && ((Saída)entidade).Cotação != cotação.Value)
                {
                    if (((Saída)entidade).Cotação == 0)
                        ((Saída)entidade).Cotação = cotação.Value;
                }
                else if (entidade is Venda && ((Venda)entidade).Cotação != cotação)
                {
                    if (((Venda)entidade).Cotação == 0)
                        ((Venda)entidade).Cotação = cotação.Value;
                }
            }
        }

        /// <summary>
        /// Verifica a consistência de um item específico.
        /// </summary>
        /// <param name="item">Item a ser verificado.</param>
        private void VerificarConsistênciaItem(HistóricoRelacionamentoItem item)
        {
            double valor;

            if (HashÍndice.TryGetValue(item.Mercadoria.ReferênciaNumérica + item.Mercadoria.Peso, out valor))
                if (valor - item.Índice >= 0.01)
                {
                    //if (Representante.ÉRepresentante(cliente))
                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(
                            new DocumentoInconsistente(
                                string.Format(
                                "Ignore esta mensagem pois é uma nota para o desenvolvedor. A mercadoria {0} encontra-se com índice {1} enquanto no acerto {4} em que ele está vinculado ela foi anteriormente relacionada com o valor {2} para o representante {3}.",
                                item.Mercadoria.Referência,
                                item.Índice,
                                valor, cliente.Nome,
                                código)));
                }
        }

        /// <summary>
        /// Garante que o relacionamento adicionado pertence ao
        /// mesmo cliente.
        /// </summary>
        /// <param name="entidade">Entidade a ser verificada.</param>
        /// <exception cref="DocumentoInconsistente">Se as pessoas forem diferentes.</exception>
        private void GarantirConsistênciaPessoa(Entidades.Relacionamento.RelacionamentoAcerto entidade)
        {
            Venda venda = entidade as Venda;

            if (venda != null && Representante.ÉRepresentante(venda.Vendedor))
            {
                if (!venda.Vendedor.Código.Equals(this.cliente.Código))
                    throw new DocumentoInconsistente(
                    string.Format(
                    "Como {0} é representante, o acerto deveria estar em nome dele. No entanto, está em nome de {1}",
                    venda.Vendedor.Nome, cliente.Nome));
            }
            else if (entidade.Pessoa != null &&
                !entidade.Pessoa.Código.Equals(this.cliente.Código) &&
                (this.Cliente.Código != Entidades.Pessoa.Pessoa.Varejo.Código))
                throw new DocumentoInconsistente(
                    string.Format(
                    "O documento foi relacionado para {0} enquanto o acerto está relacionado para {1}." + "\nO código " + entidade.Pessoa.Código.ToString() + " é diferente de " + this.cliente.Código.ToString(),
                    entidade.Pessoa.Nome, cliente.Nome));
            else if ((this.Cliente.Código == Entidades.Pessoa.Pessoa.Varejo.Código) && (cliente.Setor != Setor.ObterSetor(SetorSistema.Varejo)))
                throw new DocumentoInconsistente("Apenas clientes de varejo podem entrar no acerto de varejo");

        }

        /// <summary>
        /// Disparado sempre que um novo item for adicionado.
        /// </summary>
        /// <param name="item">Item adicionado.</param>
        /// <param name="cancelar">Se deve cancelar a adição.</param>
        void AntesDeCadastrarItemRelacionamento(HistóricoRelacionamentoItem item, out bool cancelar)
        {
            cancelar = false;
        }

        #endregion

        /// <summary>
        /// Finaliza o acerto.
        /// </summary>
        public void Acertar()
        {
            if (Acertado)
                throw new Exception("Acerto já estava finalizado.");

            dataEfetiva = DadosGlobais.Instância.HoraDataAtual;
            funcAcerto = Funcionário.FuncionárioAtual;

            Saída.TravarVários(ExtrairCódigos(saídas.ExtrairElementos()));
            Retorno.TravarVários(ExtrairCódigos(retornos.ExtrairElementos()));
            Venda.TravarVários(ExtrairCódigos(vendas.ExtrairElementos()));

            DefinirDesatualizado();
            Atualizar();
        }

        /// <summary>
        /// Calcula o valor das mercadorias que estão com o cliente.
        /// </summary>
        /// <returns>Valor das mercadorias.</returns>
        public double CalcularValorMercadorias()
        {
            if (cotação.HasValue)
            {
                IDbConnection conexão = Conexão;

                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    double valor;

                    object obj;

                    cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                        + " FROM saida s JOIN saidaitem i ON s.codigo = i.saida"
                        + " WHERE s.acerto = " + DbTransformar(this.Código);
                    obj = cmd.ExecuteScalar();

                    if (obj is DBNull)
                        return 0;
                    else
                        valor = Convert.ToDouble(obj);

                    cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                        + " FROM retorno r JOIN retornoitem i ON r.codigo = i.retorno"
                        + " WHERE r.acerto = " + DbTransformar(this.Código);
                    obj = cmd.ExecuteScalar();

                    if (!(obj is DBNull))
                        valor -= Convert.ToDouble(obj);

                    cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                        + " FROM venda v JOIN vendaitem i ON v.codigo = i.venda"
                        + " WHERE v.acerto = " + DbTransformar(this.Código);
                    obj = cmd.ExecuteScalar();

                    if (!(obj is DBNull))
                        valor -= Convert.ToDouble(obj);

                    return valor * Cotação.Value;
                }
            }
            else
                return 0;
        }

        public override bool Referente(DbManipulação entidade)
        {
            if (entidade is AcertoConsignado)
                if (((AcertoConsignado)entidade).código == código)
                    return true;

            return base.Referente(entidade);
        }

        /// <summary>
        /// Calcula o total de índice nas saídas
        /// </summary>
        public double CalcularÍndiceSaídas()
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                object obj;

                cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                    + " FROM saida s JOIN saidaitem i ON s.codigo = i.saida"
                    + " WHERE s.acerto = " + DbTransformar(this.Código);
                obj = cmd.ExecuteScalar();

                if (obj is DBNull)
                    return 0;
                else
                    return Convert.ToDouble(obj);
            }
        }

        /// <summary>
        /// Calcula o total de índice nas vendas (vendido menos devolvido)
        /// </summary>
        public double CalcularÍndiceVendas()
        {
            double valorVendido;
            double valorDevolvido;

            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                object obj;

                cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                    + " FROM venda v JOIN vendaitem i ON v.codigo = i.venda "
                    + " WHERE v.acerto = " + DbTransformar(this.Código);
                obj = cmd.ExecuteScalar();

                if (obj is DBNull)
                    valorVendido = 0;
                else
                    valorVendido = Convert.ToDouble(obj);
            }

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                object obj;

                cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                    + " FROM venda v JOIN vendadevolucao i ON v.codigo = i.venda "
                    + " WHERE v.acerto = " + DbTransformar(this.Código);
                obj = cmd.ExecuteScalar();

                if (obj is DBNull)
                    valorDevolvido = 0;
                else
                    valorDevolvido = Convert.ToDouble(obj);
            }


            return valorVendido - valorDevolvido;
        }

        /// <summary>
        /// Calcula o total de índice nas vendas (vendido menos devolvido).
        /// Apesar depeso=false.
        /// </summary>
        public double CalcularÍndiceVendasApenasDePeça()
        {
            double valorVendido;
            double valorDevolvido;

            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                object obj;

                cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                    + " FROM mercadoria, venda v JOIN vendaitem i ON v.codigo = i.venda "
                    + " WHERE v.acerto = " + DbTransformar(this.Código)
                    + " AND mercadoria.referencia=i.referencia "
                    + " AND depeso=false ";

                obj = cmd.ExecuteScalar();

                if (obj is DBNull)
                    valorVendido = 0;
                else
                    valorVendido = Convert.ToDouble(obj);
            }

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                object obj;

                cmd.CommandText = "SELECT SUM(round(i.indice,2) * i.quantidade)"
                    + " FROM mercadoria, venda v JOIN vendadevolucao i ON v.codigo = i.venda "
                    + " WHERE v.acerto = " + DbTransformar(this.Código)
                    + " AND mercadoria.referencia=i.referencia "
                    + " AND depeso = false ";

                obj = cmd.ExecuteScalar();

                if (obj is DBNull)
                    valorDevolvido = 0;
                else
                    valorDevolvido = Convert.ToDouble(obj);
            }


            return valorVendido - valorDevolvido;
        }


        /// <summary>
        /// a = Computa todas as saídas soma todo o índice (de peça e grama).
        /// b = Olha as vendas do acerto, soma todo indice vendido menos indice devolvido (de peça e grama).
        /// Computa valor da venda para dar desconto = somatorio indice de peça vendido menos devolvido.
        /// 
        /// Antes de 2013:
        /// Desconto = 15% caso a/b > 20%. Desconto = 10% caso a/b menor que 20%.
        /// 
        /// Após de 2013
        /// Descoto = 12%
        /// </summary>
        /// <param name="totalÍndiceSaida">Computa todas as saídas soma todo o índice (de peça e grama).</param>
        /// <param name="totalÍndiceVendidoMenosDevolvido">Olha as vendas do acerto, soma todo indice vendido menos indice devolvido (de peça e grama)</param>
        /// <param name="totalVendaPeça">Computa valor base da venda para dar desconto</param>
        /// <param name="porcentagemAtigida">totalÍndiceSaida/totalÍndiceVendidoMenosDevolvido</param>
        /// <returns>Valor em Real para desconto</returns>
        public double CalcularDesconto(out double totalÍndiceSaida, out double totalÍndiceVendidoMenosDevolvido,
            out double totalVendaPeça, out double porcentagemAtigida,
            out double porcentagemDadaDesconto)
        {
            if (!cotação.HasValue)
                throw new Exception("Cotação não definida para acerto");

            totalÍndiceSaida = CalcularÍndiceSaídas();
            totalÍndiceVendidoMenosDevolvido = CalcularÍndiceVendas();
            totalVendaPeça = CalcularÍndiceVendasApenasDePeça();

            // Deixa em porcentagem
            porcentagemAtigida = totalÍndiceVendidoMenosDevolvido / totalÍndiceSaida;
            porcentagemAtigida *= 100;
            porcentagemAtigida = Math.Round(porcentagemAtigida, 1);
            
            // Antes:
            //if (porcentagemAtigida >= 20)
            //    porcentagemDadaDesconto = 15;
            //else
            //    porcentagemDadaDesconto = 10;


            // Em 21/03/2013 foi pedido para alterar porcentagem de desconto sobre venda de peças
            // para 12% não importando quantidade vendida de peças Hoffman
            ConfiguraçãoGlobal<double> configuraçãoPorcentagemDadaDesconto = 
                new ConfiguraçãoGlobal<double>("DescontoAA", 12);

            porcentagemDadaDesconto = configuraçãoPorcentagemDadaDesconto.Valor;

            return Math.Round(totalVendaPeça * (porcentagemDadaDesconto / 100) * cotação.Value, 2);
        }

        private static List<long> ExtrairCódigos(IList lista)
        {
            List<long> códigos = new List<long>(lista.Count);

            foreach (Relacionamento.Relacionamento item in lista)
                códigos.Add(item.Código);

            return códigos;
        }

    }
}
