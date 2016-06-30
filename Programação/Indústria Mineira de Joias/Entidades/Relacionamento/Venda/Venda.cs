using System;
using Acesso.Comum;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Entidades.Relacionamento;
using Entidades.Acerto;
using Entidades.Configuração;
using Entidades.Mercadoria;
using Acesso.Comum.Cache;
using Entidades.Pagamentos;
using Entidades.Balanço;
using Entidades.Privilégio;
using System.Text;
using Acesso.Comum.Exceções;

namespace Entidades.Relacionamento.Venda
{
    [Serializable, DbTransação]
    public class Venda : Entidades.Relacionamento.RelacionamentoAcerto, IDadosVenda
	{
		// Atributos
		protected double        cotacao;
        protected uint?         controle;

        [DbAtributo(TipoAtributo.Ignorar)]
        protected double?       valortotal;
        
        protected double        desconto;
        protected double        taxajuros = DadosGlobais.Instância.Juros;
        protected uint          diasSemJuros;
        [DbColuna("quitacao")]
        protected DateTime?     quitação;

        protected bool rastreada;
        protected bool sedex;
        
        [DbRelacionamento("codigo", "cliente")]
		protected Entidades.Pessoa.Pessoa cliente;

        [DbRelacionamento("codigo", "corretor")]
        protected Entidades.Pessoa.Pessoa corretor;

        [DbAtributo(TipoAtributo.Ignorar)]
        protected HistóricoRelacionamentoDevolução itensDevolução;

        [DbRelacionamento("codigo", "vendedor")]
        protected Pessoa.Pessoa vendedor;

        protected DbComposição<VendaDébito> itensDébito;
        protected DbComposição<VendaCrédito> itensCrédito;

		#region Propriedades

        public bool Rastreada
        {
            get { return rastreada; }
            set
            {
                rastreada = value;
                DefinirDesatualizado();
            }
        }

        public Pessoa.Pessoa Vendedor
        {
            get { return vendedor; }
            set
            {
                vendedor = value;
                DefinirDesatualizado();
            }
        }

        public override Pessoa.Pessoa Pessoa
        {
            get { return cliente; }
            set { throw new NotSupportedException(); }
        }

        public bool Sedex
        {
            get { return sedex; }
            set 
            { 
                sedex = value;
                DefinirDesatualizado();
            }
        }

        public double Desconto
        {
            get
            {
                return desconto;
            }
            set
            {
                desconto = value;
                DefinirDesatualizado();
                DefinirValorTotalNulo();
            }
        }

        public double? DescontoPercentual
        {
            get 
            { 
                double v = Valor;

                return ObterDescontoPercentual(v);
            }
            set
            {
                if (value.HasValue)
                    Desconto = Valor * value.Value / 100;
                else
                    Desconto = 0;

                DefinirValorTotalNulo();
            }
        }

        public double? ObterDescontoPercentual(double valorVenda)
        {
            if (valorVenda == 0)
                return null;
            else
                return Math.Round(100 * (desconto / valorVenda), 1); 

        }

        public override bool Travado
        {
            get
            {
                if (!Cadastrado) return travado;
                
                if (DentroDaComissão.HasValue)
                    return true;

                IDbConnection conexão = Conexão;

                try
                {
                    lock (conexão)
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                        using (IDbCommand cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText =
                                "SELECT travado FROM venda where codigo=" + DbTransformar(codigo);

                            travado = Convert.ToBoolean(cmd.ExecuteScalar());
                        }
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
                return travado;
            }
            set
            {
                travado = value;
                DefinirDesatualizado();

                if (Cadastrado)
                    Atualizar();
            }
        }

        public int? DentroDaComissão
        {
            get
            {
                if (!Cadastrado) return null;

                IDbConnection conexão = Conexão;

                try
                {
                    lock (conexão)
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                        bool naComissão = false;
                        using (IDbCommand cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = "select saldo != 0  from comissao_saldo where venda = " + DbTransformar(Código);

                            naComissão = Convert.ToInt32(cmd.ExecuteScalar()) != 0;
                        }

                        if (naComissão)
                        {
                            using (IDbCommand cmd = conexão.CreateCommand())
                            {
                                cmd.CommandText = "select max(comissao) from comissaovenda where venda = " + DbTransformar(Código);

                                object resultado = cmd.ExecuteScalar();

                                if (resultado == null || resultado == DBNull.Value)
                                    return null;

                                return Convert.ToInt32(resultado);
                            }
                        }
                        else
                            return null;
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }   
            }
        }

        public double ValorDevolução
        {
            get
            {
                return ItensDevolução.CalcularPreço(cotacao);
            }
        }

        /// <summary>
        /// Saldo da venda na data da venda. (-dívida)
        /// </summary>
        public double Saldo
        {
            get
            {
                double dívida = 0;
                double juros;
                List<IPagamento> listaPagamentos = new List<IPagamento>();
                List<Pagamento> pagamentos;
                string[] prestações;

                try
                {
                    prestações = ObterPrestações(out pagamentos);
                    foreach (Pagamento p in pagamentos) listaPagamentos.Add(p);

                    CalcularDívida(DataCobrança, out dívida, out juros, pagamentos, prestações);
                }
                catch { }

                return -dívida;
            }
        }

        /// <summary>
        /// Valor da venda, porém sem juros.
        /// </summary>
        public double Valor
        {
            get
            {
                    CalcularValor();
                    
                    if (Cadastrado)
                        Atualizar();

                    return valortotal.Value;
            }
        }

        public double Cotação
        {
            get { return cotacao;   }
            set 
            {
                cotacao = value;
                DefinirDesatualizado();
                DefinirValorTotalNulo();
            }
        }

        public class InconsistênciaEntreVendaPagamento : ApplicationException
        {
            public InconsistênciaEntreVendaPagamento(string msg) : base(msg) { }
        }

        /// <summary>
        /// Cliente que efetuou a compra.
        /// </summary>
        /// <remarks>
        /// Não é possível alterar o valor de cliente, caso
        /// existam pagamentos registrados nesta venda. Essa
        /// restrição existe, visto que um pagamento pode pertencer
        /// a várias vendas.
        /// </remarks>
		public Pessoa.Pessoa Cliente
		{
			get { return cliente;   }
            set
            {
                if (cliente != value)
                {
                    cliente = value;
                    DefinirDesatualizado();

                    if (Cadastrado)
                    {
                        Atualizar();

                        TrocarDonoPagamentos(Cliente.Código);
                    }
                }
            }
        }

        private void TrocarDonoPagamentos(ulong novoCliente)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        cmd.CommandText = "UPDATE pagamento SET cliente=" + DbTransformar(novoCliente) + " WHERE venda=" + DbTransformar(Código);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                    }
                }
            }
        }

        public string NomeCliente
        {
            get {  return cliente != null ? cliente.Nome : ""; }
        }

        public string NomeVendedor
        {
            get { return vendedor != null ? vendedor.Nome : ""; }
        }

        public virtual HistóricoRelacionamentoDevolução ItensDevolução
        {
            get
            {
                if (itensDevolução == null && Itens == null)
                    throw new Exception("Nunca deveria chegar aqui, pois Itens deveria criar as listas.");

                return itensDevolução;
            }
        }

        /// <summary>
        /// Número de controle.
        /// </summary>
        public uint? Controle
        {
            get { return controle; }
            set { controle = value; DefinirDesatualizado();  }
        }

        /// <summary>
        /// Débitos da venda.
        /// </summary>
        public DbComposição<VendaDébito> ItensDébito
        {
            get
            {
                if (itensDébito == null)
                {
                    itensDébito = new DbComposição<VendaDébito>(VendaDébito.ObterDébitos(this));
                    itensDébito.Alterado += new DbManipulaçãoHandler(AoAlterarItensDébito);
                    itensDébito.AoAdicionar += new DbComposição<VendaDébito>.EventoComposição(AoAdicionarItensDébito);

                    foreach (VendaDébito entidade in itensDébito)
                        entidade.Alterado += new DbManipulaçãoHandler(AoAlterarDébito);
                }

                return itensDébito;
            }
        }

        /// <summary>
        /// Débitos da venda.
        /// </summary>
        public DbComposição<VendaCrédito> ItensCrédito
        {
            get
            {
                if (itensCrédito == null)
                {
                    itensCrédito = new DbComposição<VendaCrédito>(VendaCrédito.ObterCréditos(this));
                    itensCrédito.Alterado += new DbManipulaçãoHandler(AoAlterarItensCrédito);
                    itensCrédito.AoAdicionar += new DbComposição<VendaCrédito>.EventoComposição(AoAdicionarItensCrédito);

                    foreach (VendaCrédito entidade in itensCrédito)
                        entidade.Alterado += new DbManipulaçãoHandler(AoAlterarCrédito);
                }

                return itensCrédito;
            }
        }

        /// <summary>
        /// Taxa de juros.
        /// </summary>
        public double TaxaJuros
        {
            get { return taxajuros; }
            set { taxajuros = value; DefinirDesatualizado();  }
        }

        /// <summary>
        /// Dias com desconto de juros.
        /// </summary>
        public uint DiasSemJuros
        {
            get { return diasSemJuros; }
            set { diasSemJuros = value; DefinirDesatualizado(); }
        }

    

        /// <summary>
        /// Data de quitação da venda.
        /// </summary>
        public DateTime? Quitação
        {
            get { return quitação; }
            set { quitação = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Determina se a venda foi quitada.
        /// </summary>
        public bool Quitada
        {
            get { return quitação.HasValue; }
        }


		#endregion

        /// <summary>
        /// Pode ser a data da venda, ou esta acrescida dos dias de juros,
        /// ou seja, é a data em que ainda não há juros (dias=0)
        /// </summary>
        public DateTime DataCobrança
        {
            get
            {
                return Preço.SomarDias(Data, (int)DiasSemJuros);
            }
        }


        public Venda()
        {
            this.digitadopor = Entidades.Pessoa.Funcionário.FuncionárioAtual;

            travado = false;

            AntesDeCadastrarItem += new AntesDeCadastrarItemCallback(Venda_AntesDeCadastrarItem);
        }

        void Venda_AntesDeCadastrarItem(HistóricoRelacionamentoItem item, out bool cancelar)
        {
            cancelar = false;
        }

        protected override HistóricoRelacionamento ConstruirItens()
        {
            itensDevolução = new HistóricoRelacionamentoDevolução(this);
            return new HistóricoRelacionamentoVenda(this);
        }

        #region Recuperação do banco de dados

        public static Venda ObterVenda(long código)
        {
            return ObterVenda((ulong)código);
        }

        public static Venda ObterVenda(ulong código)
        {
            Venda venda;

            venda = MapearÚnicaLinha<Venda>(
                "SELECT * FROM venda WHERE "
                + "codigo = " + DbTransformar(código));

            return venda;
        }

        /// <summary>
        /// Verifica existência de uma venda com o número de controle.
        /// </summary>
        /// <param name="númeroControle">Número de controle a ser verificado.</param>
        /// <returns>O código da venda que tem determinado número de controle.</returns>
        public static long? VerificarExistência(uint? númeroControle)
        {
            if (númeroControle == null) return null;

            IDbConnection conexão = Conexão;

            try
            {
                lock (conexão)
                {

                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);


                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        long? códigoVenda;

                        cmd.CommandText = "SELECT codigo FROM venda WHERE controle = "
                            + DbTransformar(númeroControle);

                        lock (conexão)
                            códigoVenda = Convert.ToInt64(cmd.ExecuteScalar());

                        if (códigoVenda == 0)
                            return null;
                        else
                            return códigoVenda;
                    }
                }
            }
            finally
            {
                Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);

            }
        }

        /// <summary>
        /// Obtém vendas não quitadas de um cliente.
        /// </summary>
        public static Venda[] ObterVendasNãoQuitadas(Pessoa.Pessoa cliente, out double dívida)
        {
            Venda[] vendas = Mapear<Venda>(
                string.Format(
                "SELECT * FROM venda WHERE cliente = {0} AND quitacao IS NULL",
                DbTransformar(cliente.Código))).ToArray();

            return VerificarQuitação(vendas, out dívida);
        }

        /// <summary>
        /// Obtém vendas não quitadas.
        /// </summary>
        public static Venda[] ObterVendasNãoQuitadas(out double dívidaTotal)
        {
            Venda[] vendas = Mapear<Venda>(
                "SELECT * FROM venda WHERE quitacao IS NULL").ToArray();

            return VerificarQuitação(vendas, out dívidaTotal);
        }

        /// <summary>
        /// Obtém as pessoas que possuem vendas ainda não quitadas.
        /// </summary>
        public static List<Entidades.Pessoa.Pessoa> ObterPessoasComVendasNãoQuitadas()
        {
            IDbConnection conexão = Conexão;
            List<ulong> códigos = new List<ulong>();

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT cliente FROM venda WHERE quitacao IS NULL AND cliente IS NOT NULL";

                    try
                    {

                        using (IDataReader leitor = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (leitor.Read())
                                    códigos.Add(Convert.ToUInt64(leitor.GetValue(0)));
                            }
                            finally
                            {
                                leitor.Close();
                            }
                        }
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
            List<Entidades.Pessoa.Pessoa> pessoas = new List<Entidades.Pessoa.Pessoa>(códigos.Count);

            for (int i = 0; i < pessoas.Count; i++)
                pessoas[i] = Entidades.Pessoa.Pessoa.ObterPessoa(códigos[i]);

            return pessoas;
        }

        /// <summary>
        /// Verifica quais vendas podem ser quitadas, quitando-as.
        /// </summary>
        /// <param name="vendas">Vendas a serem verificadas.</param>
        /// <returns>Vendas não quitadas.</returns>
        public static Venda[] VerificarQuitação(Venda[] vendas, out double dívidaTotal)
        {
            List<Venda> pendências = new List<Venda>();

            dívidaTotal = 0;

            foreach (Venda venda in vendas)
            {
                if (!venda.ExistePagamentoPendente())
                {
                    double dívida, juros;

                    venda.CalcularDívida(out dívida, out juros);

                    if (dívida == 0)
                    {
                        //venda.Quitar();
                    }
                    else
                    {
                        pendências.Add(venda);
                        dívidaTotal += dívida;
                    }
                }
                else
                    pendências.Add(venda);
            }

            return pendências.ToArray();
        }

        /// <summary>
        /// Verifica se existe algum pagamento pendente.
        /// </summary>
        /// <returns>Se existe algum pagamento pendente.</returns>
        public bool ExistePagamentoPendente()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = string.Format(
                            "SELECT COUNT(*) FROM vinculovendapagamento v JOIN pagamento p ON v.pagamento = p.codigo WHERE v.venda = {0} AND p.pendente = 1",
                            DbTransformar(Código));

                        return Convert.ToBoolean(cmd.ExecuteScalar());
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }

        }
        
        public void Quitar()
        {
            Quitar(false);
        }

        public void Desquitar()
        {
            Quitar(true);
        }

        /// <summary>
        /// Quita a venda.
        /// </summary>
        public void Quitar(bool inverter)
        {
            PermissãoFuncionário.AssegurarPermissão(Permissão.ManipularComissão);

            if (inverter)
                quitação = null;
            else
                quitação = DadosGlobais.Instância.HoraDataAtual;

            bool necessárioPersistirTodaEntidade = !Atualizado;
                IDbConnection conexão = Conexão;

                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    try
                    {
                        using (IDbCommand cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = string.Format(
                                "UPDATE venda SET quitacao = " + (inverter ? " NULL " : " NOW()  ") + " WHERE codigo = {0}",
                                DbTransformar(Código));
                            cmd.ExecuteNonQuery();
                        }

                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                } 

                // Disparar eventos.
                DefinirDesatualizado();

                if (necessárioPersistirTodaEntidade)
                    Atualizar();
            
                DefinirAtualizado();
        }

        /// <summary>
        /// Quita uma venda no banco de dados.
        /// </summary>
        /// <param name="venda">Venda a ser quitada.</param>
        internal static void Quitar(IDadosVenda venda)
        {
            PermissãoFuncionário.AssegurarPermissão(Permissão.ManipularComissão);

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = string.Format(
                            "UPDATE venda SET quitacao = NOW() WHERE codigo = {0}",
                            DbTransformar(venda.Código));
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }
        }

        /// <summary>
        /// Obtém vendas vinculadas a um acerto.
        /// </summary>
        public static List<Venda> ObterVendas(AcertoConsignado acerto)
        {
            List<Venda> vendas = Mapear<Venda>(
                "SELECT * FROM venda WHERE acerto = " + DbTransformar(acerto.Código));

            return vendas;
        }

  
        /// <summary>
        /// Recupera coleções de um conjunto de vendas.
        /// </summary>
        /// <param name="vendas">Vendas cujas coleções serão recuperadas.</param>
        private static new void RecuperarColeções(IEnumerable vendas)
        {
            
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                lock (conexão)
                {
                    /* As coleções requerem acessar outras tabelas, tais como
                     * Mercadoria e Pessoa. Se uma dessas entidades utilizarem a
                     * mesma conexão, por estarem na mesma Thread, elas não terão
                     * acesso ao DataReader.
                     */
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    try
                    {
                        foreach (Venda venda in vendas)
                            venda.RecuperarColeções(cmd);
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
        }

        /// <summary>
        /// Recupera as coleções de devoluções e vendas.
        /// </summary>
        /// <param name="cmd">Comando do banco de dados a ser utilizado.</param>
        private void RecuperarColeções(IDbCommand cmd)
        {
            base.RecuperarColeção(cmd);
            itensDevolução.Recuperar(cmd);
        }
        
        /// <summary>
        /// Obtém total de vendas para um cliente.
        /// </summary>
        /// <returns>Total de vendas.</returns>
        public static ulong ObterTotalVendasCliente(Entidades.Pessoa.Pessoa cliente)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM venda WHERE "
                            + "cliente = " + DbTransformar(cliente.Código);

                        return Convert.ToUInt64(cmd.ExecuteScalar());
                    }

                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }
        }

        /// <summary>
        /// Obtém total de vendas de um vendedor.
        /// </summary>
        /// <param name="vendedor">
        /// Vendedor pode ser um funcionário ou um representante.
        /// </param>
        /// <returns>Total de vendas.</returns>
        public static ulong ObterTotalVendasVendedor(Entidades.Pessoa.Pessoa vendedor)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                        cmd.CommandText = "SELECT COUNT(*) FROM venda WHERE "
                            + "vendedor = " + DbTransformar(vendedor.Código);

                        return Convert.ToUInt64(cmd.ExecuteScalar());
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Calcula valor total da venda.
        /// </summary>
        /// <returns>Valor total da venda.</returns>
        public double CalcularValor()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                try
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        object obj;

                        cmd.CommandText = "CALL calcularvendavalortotal(" + DbTransformar(codigo) + ")";
                        cmd.CommandText += "; SELECT valortotal FROM venda WHERE codigo = " + DbTransformar(codigo);
                        obj = cmd.ExecuteScalar();

                        valortotal = Convert.ToDouble(obj);
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }

            return valortotal.Value;
        }

        protected enum OrdemAcerto { Referência, Dígito, Peso, Quantidade, Índice };

        private static void ObterAcerto(string consulta, Dictionary<string, Acerto.SaquinhoAcerto> hash, FórmulaAcerto fórmula)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                    try
                    {

                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string referência = leitor.GetString((int)OrdemAcerto.Referência);
                                byte dígito = leitor.GetByte((int)OrdemAcerto.Dígito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double índice = leitor.GetDouble((int)OrdemAcerto.Índice);

                                //SaquinhoAcerto itemNovo = new SaquinhoAcerto(new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);
                                SaquinhoAcerto itemNovo = SaquinhoAcerto.Construir(fórmula, new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);

                                // Item a ser utilizado
                                SaquinhoAcerto item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(referência, dígito, peso, null);
                                bool itemJáExistente = hash.TryGetValue(itemNovo.IdentificaçãoAgrupável(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJáExistente)
                                    item = itemNovo;

                                item.QtdVenda += qtd;

                                if (!itemJáExistente)
                                    hash.Add(item.IdentificaçãoAgrupável(), item);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }

                }
            }
        }

        private static void ObterAcertoDevolução(string consulta, Dictionary<string, Acerto.SaquinhoAcerto> hash, FórmulaAcerto fórmula)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    try
                    {

                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string referência = leitor.GetString((int)OrdemAcerto.Referência);
                                byte dígito = leitor.GetByte((int)OrdemAcerto.Dígito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double índice = leitor.GetDouble((int)OrdemAcerto.Índice);

                                //SaquinhoAcerto itemNovo = new SaquinhoAcerto(new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);
                                SaquinhoAcerto itemNovo = SaquinhoAcerto.Construir(fórmula, new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);

                                bool itemJáExistente;

                                // Item a ser utilizado
                                SaquinhoAcerto item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(referência, dígito, peso, null);
                                itemJáExistente = hash.TryGetValue(itemNovo.IdentificaçãoAgrupável(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJáExistente)
                                    item = itemNovo;

                                item.QtdDevolvida += qtd;

                                if (!itemJáExistente)
                                    hash.Add(item.IdentificaçãoAgrupável(), item);

                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
        }

        public static List<long> ObterAcerto(List<long> códigoVendas, Dictionary<string, Acerto.SaquinhoAcerto> hash, FórmulaAcerto fórmula)
        {
            StringBuilder consulta = new StringBuilder();

            if (códigoVendas.Count != 0)
            {
                consulta.Append("select vendaitem.referencia, mercadoria.digito, vendaitem.peso, sum(quantidade), vendaitem.indice as qtd from vendaitem, venda, ");
                consulta.Append(" mercadoria where venda.codigo = vendaitem.venda AND venda.codigo IN ");
                consulta.Append(DbTransformarConjunto(códigoVendas));
                consulta.Append(" AND mercadoria.referencia = vendaitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso");

                ObterAcerto(consulta.ToString(), hash, fórmula);

                /* Considerar também a devolução no acerto, contabilizando
                 * negativamente.
                 * -- Júlio, 18/10/2007
                 */

                consulta.Clear();

                consulta.Append("select vendadevolucao.referencia, mercadoria.digito, vendadevolucao.peso, sum(quantidade), vendadevolucao.indice as qtd from vendadevolucao, venda, ");
                consulta.Append(" mercadoria where venda.codigo=vendadevolucao.venda AND venda.codigo IN ");
                consulta.Append(DbTransformarConjunto(códigoVendas));
                consulta.Append(" AND mercadoria.referencia=vendadevolucao.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso");

                ObterAcertoDevolução(consulta.ToString(), hash, fórmula);
            }

            return códigoVendas;
        }

        private enum OrdemRastro { Controle, Data, Documento, Quantidade };

        public static void PreencherRastro(Entidades.Mercadoria.Mercadoria mercadoria, Pessoa.Pessoa pessoa, List<RastroItem> lista, List<long> códigoVendas)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            if (códigoVendas.Count == 0)
                return;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                  
                    try
                    {
                        cmd.CommandText = "select controle, venda.data, venda.codigo, sum(vendaitem.quantidade) as qtd from venda "
                        + ", vendaitem WHERE vendaitem.venda=venda.codigo "
                        + "AND acerto in (select codigo from acertoconsignado where dataefetiva is null) AND referencia=" + DbTransformar(mercadoria.ReferênciaNumérica);

                        if (mercadoria.DePeso)
                            cmd.CommandText += " AND peso=" + DbTransformar(mercadoria.Peso);

                        cmd.CommandText += " AND venda.codigo IN " + DbTransformarConjunto(códigoVendas);
                        cmd.CommandText += " GROUP BY venda.codigo, referencia, peso HAVING qtd != 0 ORDER by venda.data";

                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                DateTime data = leitor.GetDateTime((int)OrdemRastro.Data);
                                long documento = leitor.GetInt64((int)OrdemRastro.Documento);
                                double qtd = leitor.GetDouble((int)OrdemRastro.Quantidade);

                                RastroItem rastroItem = new Entidades.Acerto.RastroItem(RastroItem.TipoEnum.Venda, data, documento, qtd);

                                if (!leitor.IsDBNull((int)OrdemRastro.Controle))
                                    rastroItem.Documento = "Venda #" + leitor.GetInt64((int)OrdemRastro.Controle);
                                else
                                    rastroItem.Documento = "Venda sem cód. controle";

                                lista.Add(rastroItem);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
        }

        /// <summary>
        /// Cria nova venda.
        /// </summary>
        public static Venda CriarNovaVenda(Entidades.Pessoa.Pessoa cliente, Entidades.Pessoa.Pessoa vendedor)
        {
            Venda venda = new Venda();
            venda.Data = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual;
            venda.cliente = cliente;
            venda.vendedor = vendedor;
            //venda.Cotação = Entidades.Financeiro.Cotação.ObterCotaçãoVigente(moeda);
            //venda.Cadastrar();

            return venda;
        }

        internal override void RecuperarColeção(IDbCommand cmd)
        {
            // Recupera itens vendidos
            base.RecuperarColeção(cmd);

            // Recupera itens devolvidos
            itensDevolução.Recuperar(cmd);
        }

        /// <summary>
        /// Este método deve ser chamado toda vez que a venda é alterada de
        /// forma que seu valor seja alterado.
        /// </summary>
        private void DefinirValorTotalNulo()
        {
            IDbConnection conexão;

            conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        cmd.CommandText = "update venda set valortotal=null where codigo=" + DbTransformar(Código);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
        }

        /// <summary>
        /// Obtém a data da última venda acertada.
        /// </summary>
        /// <returns>Data da última venda.</returns>
        public static DateTime ObterDataÚltimaVendaAcertada(Entidades.Pessoa.Pessoa vendedor)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(data) FROM venda WHERE vendedor = "
                        + DbTransformar(vendedor.Código)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is not null) ";

                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem vendas...
                        return DateTime.MinValue;
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
        }

        /// <summary>
        /// Obtém a data da primeira venda não acertada.
        /// </summary>
        /// <returns>Data da primeira venda não acertada.</returns>
        public static DateTime ObterDataPrimeiraVendaNãoAcertada(Entidades.Pessoa.Pessoa vendedor)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM venda WHERE vendedor = "
                        + DbTransformar(vendedor.Código)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem vendas...
                        return DateTime.MinValue;
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
        }
        public static void TravarVários(List<long> códigos)
        {
            IDbConnection conexão = Conexão;
            if (códigos.Count == 0) return;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                        cmd.CommandText = "update venda set travado=1 "
                        + " where codigo IN " + DbTransformarConjunto(códigos);

                        cmd.ExecuteNonQuery();
                    } finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
        }

        public override string ToString()
        {
            return "Venda " + (controle.HasValue ? controle.ToString() : Código.ToString() + " (cód. interno)");
        }

        public double CalcularDébitos()
        {
            double valor = 0;

            foreach (VendaDébito entidade in ItensDébito)
                valor += entidade.ValorLíquido;

            return valor;
        }

        public double CalcularCréditos()
        {
            double valor = 0;

            foreach (VendaCrédito entidade in ItensCrédito)
                valor += entidade.ValorLíquido;

            return valor;
        }


        /// <summary>
        /// Em consulta única, 
        /// dado uma lista de código de vendas, retorna ex:
        /// '1 (cód. interno)' ==> quando controle é nulo
        /// '2 ' ==> o próprio controle. 
        /// 
        /// </summary>
        /// <param name="códigoVendas"></param>
        /// <returns></returns>
        public static List<string> ObterCódigoVendas(List<long> códigoVendas)
        {
            IDbConnection conexão;
            IDataReader leitor = null;
            List<string> códigosFormatados = new List<string>();

            if (códigoVendas.Count == 0) return códigosFormatados;

            conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                IDbCommand cmd = conexão.CreateCommand();
                cmd.CommandText = "select if(controle is null, concat(codigo, ";
                cmd.CommandText += "' (cód. interno)'), controle) from venda where codigo IN "
                    + DbTransformarConjunto(códigoVendas);

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            códigosFormatados.Add(leitor.GetString(0));
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();

                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }

            return códigosFormatados;
        }


        public static List<long> ObterCódigos(List<IDadosVenda> vendas)
        {
            List<long> códigos = new List<long>(vendas.Count);

            foreach (IDadosVenda d in vendas)
                códigos.Add(d.Código);

            return códigos;
        }

        /// <summary>
        /// Remove o número de controle.
        /// </summary>
        public void RemoverControle()
        {
            IDbConnection conexão;

            Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.VendasRemoverControle);

            conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        cmd.CommandText = "UPDATE venda SET controle = NULL WHERE codigo = " + DbTransformar(codigo);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                    }
                }
            }

            controle = null;

            CacheDb.Instância.Remover(this);
        }

        /// <summary>
        /// Calcula o valor pago.
        /// </summary>
        /// <returns>Valor pago.</returns>
        public double CalcularValorPago()
        {
            double valorPago = 0;

            foreach (Pagamento pagamento in Pagamento.ObterPagamentos(this))
                valorPago += pagamento.Valor;

            return valorPago;
        }

        /// <summary>
        /// Calcula a dívida desta venda.
        /// </summary>
        /// <param name="dívida">Valor da dívida a pagar.</param>
        /// <param name="totaljuros">Juros cobrados.</param>
        /// <exception cref="PagamentoAmbíguo">Existe um ou mais pagamentos para várias vendas.</exception>
        public void CalcularDívida(out double dívida, out double totaljuros)
        {
            CalcularDívida(Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual, out dívida, out totaljuros);
        }


        /// <summary>
        /// Calcula a dívida desta venda.
        /// </summary>
        /// <param name="dívida">Valor da dívida a pagar.</param>
        /// <param name="totaljuros">Juros cobrados.</param>
        /// <exception cref="PagamentoAmbíguo">Existe um ou mais pagamentos para várias vendas.</exception>
        public void CalcularDívida(DateTime quando, out double dívida, out double totaljuros)
        {
            List<Entidades.Pagamentos.Pagamento> pagamentos;
            string[] prestações = ObterPrestações(out pagamentos);

            CalcularDívida(quando, out dívida, out totaljuros, pagamentos, prestações);
        }

        public void CalcularDívida(double valorTotalVenda, DateTime dívidaQuando, out double dívida, out double totaljuros, List<Entidades.Pagamentos.Pagamento> pagamentos, string[] prestações)
        {
            double valor = valorTotalVenda;
            double débitos = CalcularDébitos();
            double créditos = CalcularCréditos();

            double valorFinalVenda = valor + débitos - créditos;

            Entidades.Controle.Dívida.CalcularDívida(
                valorFinalVenda,
                DataCobrança,
                dívidaQuando,
                pagamentos.ToArray(),
                prestações,
                taxajuros,
                out dívida, out totaljuros);
        }

        /// <summary>
        /// Calcula a dívida desta venda.
        /// </summary>
        /// <param name="dívida">Valor da dívida a pagar.</param>
        /// <param name="totaljuros">Juros cobrados.</param>
        /// <exception cref="PagamentoAmbíguo">Existe um ou mais pagamentos para várias vendas.</exception>
        public void CalcularDívida(DateTime dívidaQuando, out double dívida, out double totaljuros, List<Entidades.Pagamentos.Pagamento> pagamentos, string[] prestações)
        {
            CalcularDívida(this.Valor, dívidaQuando, out dívida, out totaljuros, pagamentos, prestações);
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            AtualizarEntidade(cmd, ItensDébito);
            AtualizarEntidade(cmd, ItensCrédito);

            base.Atualizar(cmd);
        }

        /// <summary>
        /// Ocorre ao adicionar um item de débito.
        /// </summary>
        void AoAdicionarItensDébito(DbComposição<VendaDébito> composição, VendaDébito entidade)
        {
            if (((VendaDébito)entidade).Venda != this)
            {
                composição.Remover(entidade);
                throw new ApplicationException("Débito da venda não está vinculada à venda que o cadastra.");
            }

            entidade.Alterado += new DbManipulaçãoHandler(AoAlterarDébito);
        }

        /// <summary>
        /// Ocorre ao adicionar um item de crédito.
        /// </summary>
        void AoAdicionarItensCrédito(DbComposição<VendaCrédito> composição, VendaCrédito entidade)
        {
            if (((VendaCrédito)entidade).Venda != this)
            {
                composição.Remover(entidade);
                throw new ApplicationException("Crédito da venda não está vinculada à venda que o cadastra.");
            }

            entidade.Alterado += new DbManipulaçãoHandler(AoAlterarCrédito);
        }


        /// <summary>
        /// Ocorre ao alterar um débito.
        /// </summary>
        private void AoAlterarDébito(DbManipulação entidade)
        {
            if (entidade.Cadastrado)
                entidade.Atualizar();
        }

        /// <summary>
        /// Ocorre ao alterar um débito.
        /// </summary>
        private void AoAlterarCrédito(DbManipulação entidade)
        {
            if (entidade.Cadastrado)
                entidade.Atualizar();
        }

        /// <summary>
        /// Ocorre sempre que a composição de débitos for modificada.
        /// </summary>
        private void AoAlterarItensDébito(DbManipulação entidade)
        {
            if (!Cadastrado)
                CadastrarCapturandoErro();

            entidade.Atualizar();
        }

        private void CadastrarCapturandoErro()
        {
            try
            {
                Cadastrar();
            } catch (OperaçãoCancelada)
            {
            }
        }

        /// <summary>
        /// Ocorre sempre que a composição de débitos for modificada.
        /// </summary>
        private void AoAlterarItensCrédito(DbManipulação entidade)
        {
            if (!Cadastrado)
                CadastrarCapturandoErro();

            entidade.Atualizar();
        }

        /// <summary>
        /// Obtém as prestações utilizadas para pagar uma venda.
        /// </summary>
        /// <returns>Prestações</returns>
        /// <exception cref="PagamentoAmbíguo">Em caso de pagamentos vinculados a várias vendas ou datas diferentes da venda.</exception>
        public string[] ObterPrestações()
        {
            List<Pagamento> pagamentos;
            string[] prestações;

            prestações = ObterPrestações(out pagamentos);

            pagamentos.Clear();

            return prestações;
        }

        /// <summary>
        /// Obtém as prestações utilizadas para pagar uma venda.
        /// </summary>
        /// <returns>Prestações</returns>
        /// <exception cref="PagamentoAmbíguo">Em caso de pagamentos vinculados a várias vendas ou datas diferentes da venda.</exception>
        public string[] ObterPrestações(out List<Pagamento> pagamentos)
        {
            pagamentos = new List<Pagamento>(Pagamento.ObterPagamentos(this));
            pagamentos.Sort(Pagamento.CompararDataVencimento);

            return ObterPrestações(pagamentos.ToArray(), DataCobrança);
        }

        /// <summary>
        /// Obtém as prestações utilizadas para pagar uma venda.
        /// </summary>
        /// <param name="pagamentos">Pagamentos ordenados pela data de vencimento.</param>
        /// <param name="data">Data da venda.</param>
        /// <returns>Prestações</returns>
        /// <exception cref="PagamentoAmbíguo">Em caso de pagamentos vinculados a várias vendas ou datas diferentes da venda.</exception>
        public static string[] ObterPrestações(IEnumerable<IPagamento> pagamentos, DateTime data)
        {
            List<string> resultado = new List<string>();
            string prestações = "";
            int correção = 0;

            foreach (IPagamento pagamento in pagamentos)
            {
                int dias = Preço.CalcularDias(data.Date, pagamento.ÚltimoVencimento.Date);

                dias += correção;
                
                if (prestações.Length == 0)
                    prestações = dias.ToString();
                else
                    prestações += "x" + dias.ToString();
            }

            resultado.Add(prestações);

            return resultado.ToArray();
        }

        public override bool PermiteAlteraçãoTabela()
        {
            return base.PermiteAlteraçãoTabela() && ItensDevolução.Count == 0;
        }


        public static void ObterAcerto(List<long> vendas, Dictionary<string, Balanço.SaquinhoBalanço> hash)
        {
            string consulta;

            if (vendas.Count != 0)
            {
                consulta =
                    "select vendaitem.referencia, mercadoria.digito, vendaitem.peso, sum(quantidade), vendaitem.indice as qtd from vendaitem, venda, "
                    + " mercadoria where venda.codigo = vendaitem.venda AND venda.codigo IN "
                    + DbTransformarConjunto(vendas);
                consulta += " AND mercadoria.referencia = vendaitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash);
            }

            return;
        }

        private static void ObterAcerto(string consulta, Dictionary<string, Balanço.SaquinhoBalanço> hash)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conexão)
                {
                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string referência = leitor.GetString((int)OrdemAcerto.Referência);
                                byte dígito = leitor.GetByte((int)OrdemAcerto.Dígito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double índice = leitor.GetDouble((int)OrdemAcerto.Índice);

                                SaquinhoBalanço itemNovo = new SaquinhoBalanço(new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);

                                // Item a ser utilizado
                                SaquinhoBalanço item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(referência, dígito, peso, null);
                                bool itemJáExistente = hash.TryGetValue(itemNovo.IdentificaçãoAgrupável(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJáExistente)
                                    item = itemNovo;

                                item.QtdVenda += qtd;

                                if (!itemJáExistente)
                                    hash.Add(item.IdentificaçãoAgrupável(), item);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }

        }

        public static Dictionary<long, long?> ObterCódigoVendasQuePagam(Pagamento[] pagamentos)
        {
            Dictionary<long, long?> hashPagamentoVenda = new Dictionary<long, long?>();

            if (pagamentos.Length == 0)
                return hashPagamentoVenda;

            using (IDbConnection conexão = Conexão)
            {
                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                    IDataReader leitor = null;

                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "select pagamento, venda  from vendadebito where pagamento IN " +
                            DbTransformarConjunto(pagamentos);

                        try
                        {
                            Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                            using (leitor = cmd.ExecuteReader())
                            {
                                while (leitor.Read())
                                {
                                    int pagamento = leitor.GetInt32(0);
                                    int venda = leitor.GetInt32(1);

                                    hashPagamentoVenda[pagamento] = venda;
                                }
                            }
                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();

                            Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                        }
                    }

                }
            }

            return hashPagamentoVenda;
        }

        public static void ObtemRecordes(Entidades.Pessoa.Pessoa pessoa, out double? maiorVenda, out DateTime? últimaVenda)
        {
            bool ehCliente = (Entidades.Pessoa.Pessoa.ÉCliente(pessoa));

            maiorVenda = null;
            últimaVenda = null;

            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = "select max(valortotal), max(data) from venda where " +
                    (ehCliente ? "cliente" : "vendedor") +
                    "= " + DbTransformar(pessoa.Código);

                lock (conexão)
                {
                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                if (!leitor.IsDBNull(0))
                                    maiorVenda = leitor.GetDouble(0);

                                if (!leitor.IsDBNull(1))
                                    últimaVenda = leitor.GetDateTime(1);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
        }

        public override void Descadastrar()
        {
            int? dentroDaComissão = DentroDaComissão;

            if (dentroDaComissão.HasValue)
                throw new Exception("Venda na comissão " + dentroDaComissão.Value.ToString());
            else
            {
                base.Descadastrar();

                Entidades.Pessoa.Funcionário.FuncionárioAtual.RegistrarHistórico("Exclusão de venda " + Código.ToString());
            }
        }

        SemaforoEnum IDadosVenda.Semáforo
        {
            get { throw new NotImplementedException(); }
        }

        public static string FormatarCódigo(long código)
        {
            return código.ToString("000,###");
        }


        public string CódigoFormatado
        {
            get { return FormatarCódigo(Código); }
        }

        public void TransferirPagamentosParaDébitosEmTransação(List<KeyValuePair<Pagamento, VendaDébito>> lstPagamentoDébitos)
        {
            itensDébito = null;

            VendaDébito.TransferirPagamentosParaDébitosEmTransação(lstPagamentoDébitos);
        }
    }
}
