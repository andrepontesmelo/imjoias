using System;
using Acesso.Comum;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Entidades.Relacionamento;
using Entidades.Acerto;
using Entidades.Configura��o;
using Entidades.Mercadoria;
using Acesso.Comum.Cache;
using Entidades.Pagamentos;
using Entidades.Balan�o;
using Entidades.Privil�gio;
using System.Text;
using Acesso.Comum.Exce��es;

namespace Entidades.Relacionamento.Venda
{
    [Serializable, DbTransa��o]
    public class Venda : Entidades.Relacionamento.RelacionamentoAcerto, IDadosVenda
	{
		// Atributos
		protected double        cotacao;
        protected uint?         controle;

        [DbAtributo(TipoAtributo.Ignorar)]
        protected double?       valortotal;
        
        protected double        desconto;
        protected double        taxajuros = DadosGlobais.Inst�ncia.Juros;
        protected uint          diasSemJuros;
        [DbColuna("quitacao")]
        protected DateTime?     quita��o;

        protected bool rastreada;
        protected bool sedex;
        
        [DbRelacionamento("codigo", "cliente")]
		protected Entidades.Pessoa.Pessoa cliente;

        [DbRelacionamento("codigo", "corretor")]
        protected Entidades.Pessoa.Pessoa corretor;

        [DbAtributo(TipoAtributo.Ignorar)]
        protected Hist�ricoRelacionamentoDevolu��o itensDevolu��o;

        [DbRelacionamento("codigo", "vendedor")]
        protected Pessoa.Pessoa vendedor;

        protected DbComposi��o<VendaD�bito> itensD�bito;
        protected DbComposi��o<VendaCr�dito> itensCr�dito;

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
                
                if (DentroDaComiss�o.HasValue)
                    return true;

                IDbConnection conex�o = Conex�o;

                try
                {
                    lock (conex�o)
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                        using (IDbCommand cmd = conex�o.CreateCommand())
                        {
                            cmd.CommandText =
                                "SELECT travado FROM venda where codigo=" + DbTransformar(codigo);

                            travado = Convert.ToBoolean(cmd.ExecuteScalar());
                        }
                    }
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
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

        public int? DentroDaComiss�o
        {
            get
            {
                if (!Cadastrado) return null;

                IDbConnection conex�o = Conex�o;

                try
                {
                    lock (conex�o)
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                        bool naComiss�o = false;
                        using (IDbCommand cmd = conex�o.CreateCommand())
                        {
                            cmd.CommandText = "select saldo != 0  from comissao_saldo where venda = " + DbTransformar(C�digo);

                            naComiss�o = Convert.ToInt32(cmd.ExecuteScalar()) != 0;
                        }

                        if (naComiss�o)
                        {
                            using (IDbCommand cmd = conex�o.CreateCommand())
                            {
                                cmd.CommandText = "select max(comissao) from comissaovenda where venda = " + DbTransformar(C�digo);

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
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }   
            }
        }

        public double ValorDevolu��o
        {
            get
            {
                return ItensDevolu��o.CalcularPre�o(cotacao);
            }
        }

        /// <summary>
        /// Saldo da venda na data da venda. (-d�vida)
        /// </summary>
        public double Saldo
        {
            get
            {
                double d�vida = 0;
                double juros;
                List<IPagamento> listaPagamentos = new List<IPagamento>();
                List<Pagamento> pagamentos;
                string[] presta��es;

                try
                {
                    presta��es = ObterPresta��es(out pagamentos);
                    foreach (Pagamento p in pagamentos) listaPagamentos.Add(p);

                    CalcularD�vida(DataCobran�a, out d�vida, out juros, pagamentos, presta��es);
                }
                catch { }

                return -d�vida;
            }
        }

        /// <summary>
        /// Valor da venda, por�m sem juros.
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

        public double Cota��o
        {
            get { return cotacao;   }
            set 
            {
                cotacao = value;
                DefinirDesatualizado();
                DefinirValorTotalNulo();
            }
        }

        public class Inconsist�nciaEntreVendaPagamento : ApplicationException
        {
            public Inconsist�nciaEntreVendaPagamento(string msg) : base(msg) { }
        }

        /// <summary>
        /// Cliente que efetuou a compra.
        /// </summary>
        /// <remarks>
        /// N�o � poss�vel alterar o valor de cliente, caso
        /// existam pagamentos registrados nesta venda. Essa
        /// restri��o existe, visto que um pagamento pode pertencer
        /// a v�rias vendas.
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

                        TrocarDonoPagamentos(Cliente.C�digo);
                    }
                }
            }
        }

        private void TrocarDonoPagamentos(ulong novoCliente)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        cmd.CommandText = "UPDATE pagamento SET cliente=" + DbTransformar(novoCliente) + " WHERE venda=" + DbTransformar(C�digo);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
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

        public virtual Hist�ricoRelacionamentoDevolu��o ItensDevolu��o
        {
            get
            {
                if (itensDevolu��o == null && Itens == null)
                    throw new Exception("Nunca deveria chegar aqui, pois Itens deveria criar as listas.");

                return itensDevolu��o;
            }
        }

        /// <summary>
        /// N�mero de controle.
        /// </summary>
        public uint? Controle
        {
            get { return controle; }
            set { controle = value; DefinirDesatualizado();  }
        }

        /// <summary>
        /// D�bitos da venda.
        /// </summary>
        public DbComposi��o<VendaD�bito> ItensD�bito
        {
            get
            {
                if (itensD�bito == null)
                {
                    itensD�bito = new DbComposi��o<VendaD�bito>(VendaD�bito.ObterD�bitos(this));
                    itensD�bito.Alterado += new DbManipula��oHandler(AoAlterarItensD�bito);
                    itensD�bito.AoAdicionar += new DbComposi��o<VendaD�bito>.EventoComposi��o(AoAdicionarItensD�bito);

                    foreach (VendaD�bito entidade in itensD�bito)
                        entidade.Alterado += new DbManipula��oHandler(AoAlterarD�bito);
                }

                return itensD�bito;
            }
        }

        /// <summary>
        /// D�bitos da venda.
        /// </summary>
        public DbComposi��o<VendaCr�dito> ItensCr�dito
        {
            get
            {
                if (itensCr�dito == null)
                {
                    itensCr�dito = new DbComposi��o<VendaCr�dito>(VendaCr�dito.ObterCr�ditos(this));
                    itensCr�dito.Alterado += new DbManipula��oHandler(AoAlterarItensCr�dito);
                    itensCr�dito.AoAdicionar += new DbComposi��o<VendaCr�dito>.EventoComposi��o(AoAdicionarItensCr�dito);

                    foreach (VendaCr�dito entidade in itensCr�dito)
                        entidade.Alterado += new DbManipula��oHandler(AoAlterarCr�dito);
                }

                return itensCr�dito;
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
        /// Data de quita��o da venda.
        /// </summary>
        public DateTime? Quita��o
        {
            get { return quita��o; }
            set { quita��o = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Determina se a venda foi quitada.
        /// </summary>
        public bool Quitada
        {
            get { return quita��o.HasValue; }
        }


		#endregion

        /// <summary>
        /// Pode ser a data da venda, ou esta acrescida dos dias de juros,
        /// ou seja, � a data em que ainda n�o h� juros (dias=0)
        /// </summary>
        public DateTime DataCobran�a
        {
            get
            {
                return Pre�o.SomarDias(Data, (int)DiasSemJuros);
            }
        }


        public Venda()
        {
            this.digitadopor = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;

            travado = false;

            AntesDeCadastrarItem += new AntesDeCadastrarItemCallback(Venda_AntesDeCadastrarItem);
        }

        void Venda_AntesDeCadastrarItem(Hist�ricoRelacionamentoItem item, out bool cancelar)
        {
            cancelar = false;
        }

        protected override Hist�ricoRelacionamento ConstruirItens()
        {
            itensDevolu��o = new Hist�ricoRelacionamentoDevolu��o(this);
            return new Hist�ricoRelacionamentoVenda(this);
        }

        #region Recupera��o do banco de dados

        public static Venda ObterVenda(long c�digo)
        {
            return ObterVenda((ulong)c�digo);
        }

        public static Venda ObterVenda(ulong c�digo)
        {
            Venda venda;

            venda = Mapear�nicaLinha<Venda>(
                "SELECT * FROM venda WHERE "
                + "codigo = " + DbTransformar(c�digo));

            return venda;
        }

        /// <summary>
        /// Verifica exist�ncia de uma venda com o n�mero de controle.
        /// </summary>
        /// <param name="n�meroControle">N�mero de controle a ser verificado.</param>
        /// <returns>O c�digo da venda que tem determinado n�mero de controle.</returns>
        public static long? VerificarExist�ncia(uint? n�meroControle)
        {
            if (n�meroControle == null) return null;

            IDbConnection conex�o = Conex�o;

            try
            {
                lock (conex�o)
                {

                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);


                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        long? c�digoVenda;

                        cmd.CommandText = "SELECT codigo FROM venda WHERE controle = "
                            + DbTransformar(n�meroControle);

                        lock (conex�o)
                            c�digoVenda = Convert.ToInt64(cmd.ExecuteScalar());

                        if (c�digoVenda == 0)
                            return null;
                        else
                            return c�digoVenda;
                    }
                }
            }
            finally
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);

            }
        }

        /// <summary>
        /// Obt�m vendas n�o quitadas de um cliente.
        /// </summary>
        public static Venda[] ObterVendasN�oQuitadas(Pessoa.Pessoa cliente, out double d�vida)
        {
            Venda[] vendas = Mapear<Venda>(
                string.Format(
                "SELECT * FROM venda WHERE cliente = {0} AND quitacao IS NULL",
                DbTransformar(cliente.C�digo))).ToArray();

            return VerificarQuita��o(vendas, out d�vida);
        }

        /// <summary>
        /// Obt�m vendas n�o quitadas.
        /// </summary>
        public static Venda[] ObterVendasN�oQuitadas(out double d�vidaTotal)
        {
            Venda[] vendas = Mapear<Venda>(
                "SELECT * FROM venda WHERE quitacao IS NULL").ToArray();

            return VerificarQuita��o(vendas, out d�vidaTotal);
        }

        /// <summary>
        /// Obt�m as pessoas que possuem vendas ainda n�o quitadas.
        /// </summary>
        public static List<Entidades.Pessoa.Pessoa> ObterPessoasComVendasN�oQuitadas()
        {
            IDbConnection conex�o = Conex�o;
            List<ulong> c�digos = new List<ulong>();

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT cliente FROM venda WHERE quitacao IS NULL AND cliente IS NOT NULL";

                    try
                    {

                        using (IDataReader leitor = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (leitor.Read())
                                    c�digos.Add(Convert.ToUInt64(leitor.GetValue(0)));
                            }
                            finally
                            {
                                leitor.Close();
                            }
                        }
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }
            List<Entidades.Pessoa.Pessoa> pessoas = new List<Entidades.Pessoa.Pessoa>(c�digos.Count);

            for (int i = 0; i < pessoas.Count; i++)
                pessoas[i] = Entidades.Pessoa.Pessoa.ObterPessoa(c�digos[i]);

            return pessoas;
        }

        /// <summary>
        /// Verifica quais vendas podem ser quitadas, quitando-as.
        /// </summary>
        /// <param name="vendas">Vendas a serem verificadas.</param>
        /// <returns>Vendas n�o quitadas.</returns>
        public static Venda[] VerificarQuita��o(Venda[] vendas, out double d�vidaTotal)
        {
            List<Venda> pend�ncias = new List<Venda>();

            d�vidaTotal = 0;

            foreach (Venda venda in vendas)
            {
                if (!venda.ExistePagamentoPendente())
                {
                    double d�vida, juros;

                    venda.CalcularD�vida(out d�vida, out juros);

                    if (d�vida == 0)
                    {
                        //venda.Quitar();
                    }
                    else
                    {
                        pend�ncias.Add(venda);
                        d�vidaTotal += d�vida;
                    }
                }
                else
                    pend�ncias.Add(venda);
            }

            return pend�ncias.ToArray();
        }

        /// <summary>
        /// Verifica se existe algum pagamento pendente.
        /// </summary>
        /// <returns>Se existe algum pagamento pendente.</returns>
        public bool ExistePagamentoPendente()
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                try
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = string.Format(
                            "SELECT COUNT(*) FROM vinculovendapagamento v JOIN pagamento p ON v.pagamento = p.codigo WHERE v.venda = {0} AND p.pendente = 1",
                            DbTransformar(C�digo));

                        return Convert.ToBoolean(cmd.ExecuteScalar());
                    }
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
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
            Permiss�oFuncion�rio.AssegurarPermiss�o(Permiss�o.ManipularComiss�o);

            if (inverter)
                quita��o = null;
            else
                quita��o = DadosGlobais.Inst�ncia.HoraDataAtual;

            bool necess�rioPersistirTodaEntidade = !Atualizado;
                IDbConnection conex�o = Conex�o;

                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    try
                    {
                        using (IDbCommand cmd = conex�o.CreateCommand())
                        {
                            cmd.CommandText = string.Format(
                                "UPDATE venda SET quitacao = " + (inverter ? " NULL " : " NOW()  ") + " WHERE codigo = {0}",
                                DbTransformar(C�digo));
                            cmd.ExecuteNonQuery();
                        }

                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                } 

                // Disparar eventos.
                DefinirDesatualizado();

                if (necess�rioPersistirTodaEntidade)
                    Atualizar();
            
                DefinirAtualizado();
        }

        /// <summary>
        /// Quita uma venda no banco de dados.
        /// </summary>
        /// <param name="venda">Venda a ser quitada.</param>
        internal static void Quitar(IDadosVenda venda)
        {
            Permiss�oFuncion�rio.AssegurarPermiss�o(Permiss�o.ManipularComiss�o);

            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                try
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = string.Format(
                            "UPDATE venda SET quitacao = NOW() WHERE codigo = {0}",
                            DbTransformar(venda.C�digo));
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
            }
        }

        /// <summary>
        /// Obt�m vendas vinculadas a um acerto.
        /// </summary>
        public static List<Venda> ObterVendas(AcertoConsignado acerto)
        {
            List<Venda> vendas = Mapear<Venda>(
                "SELECT * FROM venda WHERE acerto = " + DbTransformar(acerto.C�digo));

            return vendas;
        }

  
        /// <summary>
        /// Recupera cole��es de um conjunto de vendas.
        /// </summary>
        /// <param name="vendas">Vendas cujas cole��es ser�o recuperadas.</param>
        private static new void RecuperarCole��es(IEnumerable vendas)
        {
            
            IDbConnection conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                lock (conex�o)
                {
                    /* As cole��es requerem acessar outras tabelas, tais como
                     * Mercadoria e Pessoa. Se uma dessas entidades utilizarem a
                     * mesma conex�o, por estarem na mesma Thread, elas n�o ter�o
                     * acesso ao DataReader.
                     */
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    try
                    {
                        foreach (Venda venda in vendas)
                            venda.RecuperarCole��es(cmd);
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }
        }

        /// <summary>
        /// Recupera as cole��es de devolu��es e vendas.
        /// </summary>
        /// <param name="cmd">Comando do banco de dados a ser utilizado.</param>
        private void RecuperarCole��es(IDbCommand cmd)
        {
            base.RecuperarCole��o(cmd);
            itensDevolu��o.Recuperar(cmd);
        }
        
        /// <summary>
        /// Obt�m total de vendas para um cliente.
        /// </summary>
        /// <returns>Total de vendas.</returns>
        public static ulong ObterTotalVendasCliente(Entidades.Pessoa.Pessoa cliente)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                try
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM venda WHERE "
                            + "cliente = " + DbTransformar(cliente.C�digo);

                        return Convert.ToUInt64(cmd.ExecuteScalar());
                    }

                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
            }
        }

        /// <summary>
        /// Obt�m total de vendas de um vendedor.
        /// </summary>
        /// <param name="vendedor">
        /// Vendedor pode ser um funcion�rio ou um representante.
        /// </param>
        /// <returns>Total de vendas.</returns>
        public static ulong ObterTotalVendasVendedor(Entidades.Pessoa.Pessoa vendedor)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                        cmd.CommandText = "SELECT COUNT(*) FROM venda WHERE "
                            + "vendedor = " + DbTransformar(vendedor.C�digo);

                        return Convert.ToUInt64(cmd.ExecuteScalar());
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
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
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                try
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    using (IDbCommand cmd = conex�o.CreateCommand())
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
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
            }

            return valortotal.Value;
        }

        protected enum OrdemAcerto { Refer�ncia, D�gito, Peso, Quantidade, �ndice };

        private static void ObterAcerto(string consulta, Dictionary<string, Acerto.SaquinhoAcerto> hash, F�rmulaAcerto f�rmula)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                    try
                    {

                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string refer�ncia = leitor.GetString((int)OrdemAcerto.Refer�ncia);
                                byte d�gito = leitor.GetByte((int)OrdemAcerto.D�gito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double �ndice = leitor.GetDouble((int)OrdemAcerto.�ndice);

                                //SaquinhoAcerto itemNovo = new SaquinhoAcerto(new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, �ndice), 0, peso, �ndice);
                                SaquinhoAcerto itemNovo = SaquinhoAcerto.Construir(f�rmula, new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, �ndice), 0, peso, �ndice);

                                // Item a ser utilizado
                                SaquinhoAcerto item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, null);
                                bool itemJ�Existente = hash.TryGetValue(itemNovo.Identifica��oAgrup�vel(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJ�Existente)
                                    item = itemNovo;

                                item.QtdVenda += qtd;

                                if (!itemJ�Existente)
                                    hash.Add(item.Identifica��oAgrup�vel(), item);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }

                }
            }
        }

        private static void ObterAcertoDevolu��o(string consulta, Dictionary<string, Acerto.SaquinhoAcerto> hash, F�rmulaAcerto f�rmula)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    try
                    {

                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string refer�ncia = leitor.GetString((int)OrdemAcerto.Refer�ncia);
                                byte d�gito = leitor.GetByte((int)OrdemAcerto.D�gito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double �ndice = leitor.GetDouble((int)OrdemAcerto.�ndice);

                                //SaquinhoAcerto itemNovo = new SaquinhoAcerto(new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, �ndice), 0, peso, �ndice);
                                SaquinhoAcerto itemNovo = SaquinhoAcerto.Construir(f�rmula, new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, �ndice), 0, peso, �ndice);

                                bool itemJ�Existente;

                                // Item a ser utilizado
                                SaquinhoAcerto item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, null);
                                itemJ�Existente = hash.TryGetValue(itemNovo.Identifica��oAgrup�vel(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJ�Existente)
                                    item = itemNovo;

                                item.QtdDevolvida += qtd;

                                if (!itemJ�Existente)
                                    hash.Add(item.Identifica��oAgrup�vel(), item);

                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }
        }

        public static List<long> ObterAcerto(List<long> c�digoVendas, Dictionary<string, Acerto.SaquinhoAcerto> hash, F�rmulaAcerto f�rmula)
        {
            StringBuilder consulta = new StringBuilder();

            if (c�digoVendas.Count != 0)
            {
                consulta.Append("select vendaitem.referencia, mercadoria.digito, vendaitem.peso, sum(quantidade), vendaitem.indice as qtd from vendaitem, venda, ");
                consulta.Append(" mercadoria where venda.codigo = vendaitem.venda AND venda.codigo IN ");
                consulta.Append(DbTransformarConjunto(c�digoVendas));
                consulta.Append(" AND mercadoria.referencia = vendaitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso");

                ObterAcerto(consulta.ToString(), hash, f�rmula);

                /* Considerar tamb�m a devolu��o no acerto, contabilizando
                 * negativamente.
                 * -- J�lio, 18/10/2007
                 */

                consulta.Clear();

                consulta.Append("select vendadevolucao.referencia, mercadoria.digito, vendadevolucao.peso, sum(quantidade), vendadevolucao.indice as qtd from vendadevolucao, venda, ");
                consulta.Append(" mercadoria where venda.codigo=vendadevolucao.venda AND venda.codigo IN ");
                consulta.Append(DbTransformarConjunto(c�digoVendas));
                consulta.Append(" AND mercadoria.referencia=vendadevolucao.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso");

                ObterAcertoDevolu��o(consulta.ToString(), hash, f�rmula);
            }

            return c�digoVendas;
        }

        private enum OrdemRastro { Controle, Data, Documento, Quantidade };

        public static void PreencherRastro(Entidades.Mercadoria.Mercadoria mercadoria, Pessoa.Pessoa pessoa, List<RastroItem> lista, List<long> c�digoVendas)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;

            if (c�digoVendas.Count == 0)
                return;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                  
                    try
                    {
                        cmd.CommandText = "select controle, venda.data, venda.codigo, sum(vendaitem.quantidade) as qtd from venda "
                        + ", vendaitem WHERE vendaitem.venda=venda.codigo "
                        + "AND acerto in (select codigo from acertoconsignado where dataefetiva is null) AND referencia=" + DbTransformar(mercadoria.Refer�nciaNum�rica);

                        if (mercadoria.DePeso)
                            cmd.CommandText += " AND peso=" + DbTransformar(mercadoria.Peso);

                        cmd.CommandText += " AND venda.codigo IN " + DbTransformarConjunto(c�digoVendas);
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
                                    rastroItem.Documento = "Venda sem c�d. controle";

                                lista.Add(rastroItem);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
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
            venda.Data = Entidades.Configura��o.DadosGlobais.Inst�ncia.HoraDataAtual;
            venda.cliente = cliente;
            venda.vendedor = vendedor;
            //venda.Cota��o = Entidades.Financeiro.Cota��o.ObterCota��oVigente(moeda);
            //venda.Cadastrar();

            return venda;
        }

        internal override void RecuperarCole��o(IDbCommand cmd)
        {
            // Recupera itens vendidos
            base.RecuperarCole��o(cmd);

            // Recupera itens devolvidos
            itensDevolu��o.Recuperar(cmd);
        }

        /// <summary>
        /// Este m�todo deve ser chamado toda vez que a venda � alterada de
        /// forma que seu valor seja alterado.
        /// </summary>
        private void DefinirValorTotalNulo()
        {
            IDbConnection conex�o;

            conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        cmd.CommandText = "update venda set valortotal=null where codigo=" + DbTransformar(C�digo);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
        }

        /// <summary>
        /// Obt�m a data da �ltima venda acertada.
        /// </summary>
        /// <returns>Data da �ltima venda.</returns>
        public static DateTime ObterData�ltimaVendaAcertada(Entidades.Pessoa.Pessoa vendedor)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(data) FROM venda WHERE vendedor = "
                        + DbTransformar(vendedor.C�digo)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is not null) ";

                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // N�o existem vendas...
                        return DateTime.MinValue;
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
        }

        /// <summary>
        /// Obt�m a data da primeira venda n�o acertada.
        /// </summary>
        /// <returns>Data da primeira venda n�o acertada.</returns>
        public static DateTime ObterDataPrimeiraVendaN�oAcertada(Entidades.Pessoa.Pessoa vendedor)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM venda WHERE vendedor = "
                        + DbTransformar(vendedor.C�digo)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // N�o existem vendas...
                        return DateTime.MinValue;
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
        }
        public static void TravarV�rios(List<long> c�digos)
        {
            IDbConnection conex�o = Conex�o;
            if (c�digos.Count == 0) return;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                        cmd.CommandText = "update venda set travado=1 "
                        + " where codigo IN " + DbTransformarConjunto(c�digos);

                        cmd.ExecuteNonQuery();
                    } finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
        }

        public override string ToString()
        {
            return "Venda " + (controle.HasValue ? controle.ToString() : C�digo.ToString() + " (c�d. interno)");
        }

        public double CalcularD�bitos()
        {
            double valor = 0;

            foreach (VendaD�bito entidade in ItensD�bito)
                valor += entidade.ValorL�quido;

            return valor;
        }

        public double CalcularCr�ditos()
        {
            double valor = 0;

            foreach (VendaCr�dito entidade in ItensCr�dito)
                valor += entidade.ValorL�quido;

            return valor;
        }


        /// <summary>
        /// Em consulta �nica, 
        /// dado uma lista de c�digo de vendas, retorna ex:
        /// '1 (c�d. interno)' ==> quando controle � nulo
        /// '2 ' ==> o pr�prio controle. 
        /// 
        /// </summary>
        /// <param name="c�digoVendas"></param>
        /// <returns></returns>
        public static List<string> ObterC�digoVendas(List<long> c�digoVendas)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;
            List<string> c�digosFormatados = new List<string>();

            if (c�digoVendas.Count == 0) return c�digosFormatados;

            conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                IDbCommand cmd = conex�o.CreateCommand();
                cmd.CommandText = "select if(controle is null, concat(codigo, ";
                cmd.CommandText += "' (c�d. interno)'), controle) from venda where codigo IN "
                    + DbTransformarConjunto(c�digoVendas);

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            c�digosFormatados.Add(leitor.GetString(0));
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();

                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
            }

            return c�digosFormatados;
        }


        public static List<long> ObterC�digos(List<IDadosVenda> vendas)
        {
            List<long> c�digos = new List<long>(vendas.Count);

            foreach (IDadosVenda d in vendas)
                c�digos.Add(d.C�digo);

            return c�digos;
        }

        /// <summary>
        /// Remove o n�mero de controle.
        /// </summary>
        public void RemoverControle()
        {
            IDbConnection conex�o;

            Privil�gio.Permiss�oFuncion�rio.AssegurarPermiss�o(Entidades.Privil�gio.Permiss�o.VendasRemoverControle);

            conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        cmd.CommandText = "UPDATE venda SET controle = NULL WHERE codigo = " + DbTransformar(codigo);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                    }
                }
            }

            controle = null;

            CacheDb.Inst�ncia.Remover(this);
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
        /// Calcula a d�vida desta venda.
        /// </summary>
        /// <param name="d�vida">Valor da d�vida a pagar.</param>
        /// <param name="totaljuros">Juros cobrados.</param>
        /// <exception cref="PagamentoAmb�guo">Existe um ou mais pagamentos para v�rias vendas.</exception>
        public void CalcularD�vida(out double d�vida, out double totaljuros)
        {
            CalcularD�vida(Entidades.Configura��o.DadosGlobais.Inst�ncia.HoraDataAtual, out d�vida, out totaljuros);
        }


        /// <summary>
        /// Calcula a d�vida desta venda.
        /// </summary>
        /// <param name="d�vida">Valor da d�vida a pagar.</param>
        /// <param name="totaljuros">Juros cobrados.</param>
        /// <exception cref="PagamentoAmb�guo">Existe um ou mais pagamentos para v�rias vendas.</exception>
        public void CalcularD�vida(DateTime quando, out double d�vida, out double totaljuros)
        {
            List<Entidades.Pagamentos.Pagamento> pagamentos;
            string[] presta��es = ObterPresta��es(out pagamentos);

            CalcularD�vida(quando, out d�vida, out totaljuros, pagamentos, presta��es);
        }

        public void CalcularD�vida(double valorTotalVenda, DateTime d�vidaQuando, out double d�vida, out double totaljuros, List<Entidades.Pagamentos.Pagamento> pagamentos, string[] presta��es)
        {
            double valor = valorTotalVenda;
            double d�bitos = CalcularD�bitos();
            double cr�ditos = CalcularCr�ditos();

            double valorFinalVenda = valor + d�bitos - cr�ditos;

            Entidades.Controle.D�vida.CalcularD�vida(
                valorFinalVenda,
                DataCobran�a,
                d�vidaQuando,
                pagamentos.ToArray(),
                presta��es,
                taxajuros,
                out d�vida, out totaljuros);
        }

        /// <summary>
        /// Calcula a d�vida desta venda.
        /// </summary>
        /// <param name="d�vida">Valor da d�vida a pagar.</param>
        /// <param name="totaljuros">Juros cobrados.</param>
        /// <exception cref="PagamentoAmb�guo">Existe um ou mais pagamentos para v�rias vendas.</exception>
        public void CalcularD�vida(DateTime d�vidaQuando, out double d�vida, out double totaljuros, List<Entidades.Pagamentos.Pagamento> pagamentos, string[] presta��es)
        {
            CalcularD�vida(this.Valor, d�vidaQuando, out d�vida, out totaljuros, pagamentos, presta��es);
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            AtualizarEntidade(cmd, ItensD�bito);
            AtualizarEntidade(cmd, ItensCr�dito);

            base.Atualizar(cmd);
        }

        /// <summary>
        /// Ocorre ao adicionar um item de d�bito.
        /// </summary>
        void AoAdicionarItensD�bito(DbComposi��o<VendaD�bito> composi��o, VendaD�bito entidade)
        {
            if (((VendaD�bito)entidade).Venda != this)
            {
                composi��o.Remover(entidade);
                throw new ApplicationException("D�bito da venda n�o est� vinculada � venda que o cadastra.");
            }

            entidade.Alterado += new DbManipula��oHandler(AoAlterarD�bito);
        }

        /// <summary>
        /// Ocorre ao adicionar um item de cr�dito.
        /// </summary>
        void AoAdicionarItensCr�dito(DbComposi��o<VendaCr�dito> composi��o, VendaCr�dito entidade)
        {
            if (((VendaCr�dito)entidade).Venda != this)
            {
                composi��o.Remover(entidade);
                throw new ApplicationException("Cr�dito da venda n�o est� vinculada � venda que o cadastra.");
            }

            entidade.Alterado += new DbManipula��oHandler(AoAlterarCr�dito);
        }


        /// <summary>
        /// Ocorre ao alterar um d�bito.
        /// </summary>
        private void AoAlterarD�bito(DbManipula��o entidade)
        {
            if (entidade.Cadastrado)
                entidade.Atualizar();
        }

        /// <summary>
        /// Ocorre ao alterar um d�bito.
        /// </summary>
        private void AoAlterarCr�dito(DbManipula��o entidade)
        {
            if (entidade.Cadastrado)
                entidade.Atualizar();
        }

        /// <summary>
        /// Ocorre sempre que a composi��o de d�bitos for modificada.
        /// </summary>
        private void AoAlterarItensD�bito(DbManipula��o entidade)
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
            } catch (Opera��oCancelada)
            {
            }
        }

        /// <summary>
        /// Ocorre sempre que a composi��o de d�bitos for modificada.
        /// </summary>
        private void AoAlterarItensCr�dito(DbManipula��o entidade)
        {
            if (!Cadastrado)
                CadastrarCapturandoErro();

            entidade.Atualizar();
        }

        /// <summary>
        /// Obt�m as presta��es utilizadas para pagar uma venda.
        /// </summary>
        /// <returns>Presta��es</returns>
        /// <exception cref="PagamentoAmb�guo">Em caso de pagamentos vinculados a v�rias vendas ou datas diferentes da venda.</exception>
        public string[] ObterPresta��es()
        {
            List<Pagamento> pagamentos;
            string[] presta��es;

            presta��es = ObterPresta��es(out pagamentos);

            pagamentos.Clear();

            return presta��es;
        }

        /// <summary>
        /// Obt�m as presta��es utilizadas para pagar uma venda.
        /// </summary>
        /// <returns>Presta��es</returns>
        /// <exception cref="PagamentoAmb�guo">Em caso de pagamentos vinculados a v�rias vendas ou datas diferentes da venda.</exception>
        public string[] ObterPresta��es(out List<Pagamento> pagamentos)
        {
            pagamentos = new List<Pagamento>(Pagamento.ObterPagamentos(this));
            pagamentos.Sort(Pagamento.CompararDataVencimento);

            return ObterPresta��es(pagamentos.ToArray(), DataCobran�a);
        }

        /// <summary>
        /// Obt�m as presta��es utilizadas para pagar uma venda.
        /// </summary>
        /// <param name="pagamentos">Pagamentos ordenados pela data de vencimento.</param>
        /// <param name="data">Data da venda.</param>
        /// <returns>Presta��es</returns>
        /// <exception cref="PagamentoAmb�guo">Em caso de pagamentos vinculados a v�rias vendas ou datas diferentes da venda.</exception>
        public static string[] ObterPresta��es(IEnumerable<IPagamento> pagamentos, DateTime data)
        {
            List<string> resultado = new List<string>();
            string presta��es = "";
            int corre��o = 0;

            foreach (IPagamento pagamento in pagamentos)
            {
                int dias = Pre�o.CalcularDias(data.Date, pagamento.�ltimoVencimento.Date);

                dias += corre��o;
                
                if (presta��es.Length == 0)
                    presta��es = dias.ToString();
                else
                    presta��es += "x" + dias.ToString();
            }

            resultado.Add(presta��es);

            return resultado.ToArray();
        }

        public override bool PermiteAltera��oTabela()
        {
            return base.PermiteAltera��oTabela() && ItensDevolu��o.Count == 0;
        }


        public static void ObterAcerto(List<long> vendas, Dictionary<string, Balan�o.SaquinhoBalan�o> hash)
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

        private static void ObterAcerto(string consulta, Dictionary<string, Balan�o.SaquinhoBalan�o> hash)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conex�o)
                {
                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string refer�ncia = leitor.GetString((int)OrdemAcerto.Refer�ncia);
                                byte d�gito = leitor.GetByte((int)OrdemAcerto.D�gito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double �ndice = leitor.GetDouble((int)OrdemAcerto.�ndice);

                                SaquinhoBalan�o itemNovo = new SaquinhoBalan�o(new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, �ndice), 0, peso, �ndice);

                                // Item a ser utilizado
                                SaquinhoBalan�o item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, null);
                                bool itemJ�Existente = hash.TryGetValue(itemNovo.Identifica��oAgrup�vel(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJ�Existente)
                                    item = itemNovo;

                                item.QtdVenda += qtd;

                                if (!itemJ�Existente)
                                    hash.Add(item.Identifica��oAgrup�vel(), item);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }

        }

        public static Dictionary<long, long?> ObterC�digoVendasQuePagam(Pagamento[] pagamentos)
        {
            Dictionary<long, long?> hashPagamentoVenda = new Dictionary<long, long?>();

            if (pagamentos.Length == 0)
                return hashPagamentoVenda;

            using (IDbConnection conex�o = Conex�o)
            {
                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                    IDataReader leitor = null;

                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = "select pagamento, venda  from vendadebito where pagamento IN " +
                            DbTransformarConjunto(pagamentos);

                        try
                        {
                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
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

                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                        }
                    }

                }
            }

            return hashPagamentoVenda;
        }

        public static void ObtemRecordes(Entidades.Pessoa.Pessoa pessoa, out double? maiorVenda, out DateTime? �ltimaVenda)
        {
            bool ehCliente = (Entidades.Pessoa.Pessoa.�Cliente(pessoa));

            maiorVenda = null;
            �ltimaVenda = null;

            IDbConnection conex�o;
            IDataReader leitor = null;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = "select max(valortotal), max(data) from venda where " +
                    (ehCliente ? "cliente" : "vendedor") +
                    "= " + DbTransformar(pessoa.C�digo);

                lock (conex�o)
                {
                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                if (!leitor.IsDBNull(0))
                                    maiorVenda = leitor.GetDouble(0);

                                if (!leitor.IsDBNull(1))
                                    �ltimaVenda = leitor.GetDateTime(1);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }
        }

        public override void Descadastrar()
        {
            int? dentroDaComiss�o = DentroDaComiss�o;

            if (dentroDaComiss�o.HasValue)
                throw new Exception("Venda na comiss�o " + dentroDaComiss�o.Value.ToString());
            else
            {
                base.Descadastrar();

                Entidades.Pessoa.Funcion�rio.Funcion�rioAtual.RegistrarHist�rico("Exclus�o de venda " + C�digo.ToString());
            }
        }

        SemaforoEnum IDadosVenda.Sem�foro
        {
            get { throw new NotImplementedException(); }
        }

        public static string FormatarC�digo(long c�digo)
        {
            return c�digo.ToString("000,###");
        }


        public string C�digoFormatado
        {
            get { return FormatarC�digo(C�digo); }
        }

        public void TransferirPagamentosParaD�bitosEmTransa��o(List<KeyValuePair<Pagamento, VendaD�bito>> lstPagamentoD�bitos)
        {
            itensD�bito = null;

            VendaD�bito.TransferirPagamentosParaD�bitosEmTransa��o(lstPagamentoD�bitos);
        }
    }
}
