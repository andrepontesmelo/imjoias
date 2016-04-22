using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Collections;
using System.Data;
using Entidades.Relacionamento.Venda;
using Entidades.Configuração;
namespace Entidades.Pagamentos
{
    [DbTransação]
    public abstract class Pagamento : DbManipulaçãoAutomática, ICloneable, IPagamento
    {
        private static int totalAtributos = 10;

        protected ulong cliente;

        [DbRelacionamento("codigo", "registradopor")]
        protected Entidades.Pessoa.Funcionário registradopor;

        protected long? venda;

        [DbChavePrimária(true)]
        protected long codigo;

        protected double valor;
        protected DateTime data;
        protected bool pendente;
        protected bool devolvido;
        protected bool cobrarJuros;

        [DbColuna("descricao")]
        protected string descrição;

        /// <summary>
        /// Um cheque pode estar relacionado como pagamento de uma venda.
        /// nao é o caso.
        /// Quando o cheque fica sem fundo, ele pode estar vinculado a OUTRA venda,
        /// em que o valor corrigido de juros será pago, é então um débito.
        /// </summary>
        [DbAtributo(TipoAtributo.Ignorar)]
        protected uint? pagoNaVenda;

        public enum TipoEnum { Cheque, Dinheiro, NotaPromissória, Crédito, Ouro, Dolar };

        public abstract TipoEnum Tipo { get; }

        public bool Devolvido { get { return devolvido; } set { devolvido = value; DefinirDesatualizado();  } }
        public bool CobrarJuros { get { return cobrarJuros; } set { cobrarJuros = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Identificação do cheque.
        /// </summary>
        public string Descrição { get { return descrição; } set { descrição = value; DefinirDesatualizado(); } }

        public string DescriçãoCompleta
        {
            get
            {
                string completa = "";

                if (Descrição != null && Descrição.Trim().Length > 0)
                    completa = Descrição.Trim();

                if (DescriçãoAdicional != null && DescriçãoAdicional.Trim().Length > 0)
                {
                    if (!String.IsNullOrEmpty(completa)) 
                        completa += " - ";
                    completa += DescriçãoAdicional.Trim();
                }

                return completa;
            }
        }
        /// <summary>
        /// É uma descrição adicional, a ser mostrada de forma concatenada à impressão do pagamento ou na tela.
        /// Pode ser, por exemplo, "3,2 g ouro para fundir". É uma descrição redundante não armazenada.
        /// </summary>
        public virtual string DescriçãoAdicional
        {
            get
            {
                if (!pendente)
                    return "";
                else
                    return "PENDENTE ";
            }
        }

        public long? Venda
        {
            get
            {
                return venda;
            }
            set 
            { 
                venda = value;
                DefinirDesatualizado();
            }
        }



        public long Código
        {
            get { return codigo; }
        }

        public double Valor
        {
            get { return valor; }
            set 
            { 
                if (valor != value)
                    DefinirDesatualizado();

                valor = value;
            }
        }

        public long? PagoNaVenda
        {
            get
            {
                if (pagoNaVenda.HasValue)
                    return pagoNaVenda;
                else
                {
                    // Pega do banco de dados
                    using (IDbConnection conexão = Conexão)
                    {
                        object resposta = null;

                        using (IDbCommand cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = "select venda from vendadebito where pagamento = " + DbTransformar(Código);
                            resposta = cmd.ExecuteScalar();
                        }

                        if (resposta == null)
                            return null;
                        else
                            pagoNaVenda = (uint)resposta;
                    
                        return pagoNaVenda;
                    }
                }
            }
        }

        public DateTime Data
        {
            get { return data; }
            set 
            { 
                if (data != value)
                    DefinirDesatualizado();
                    
                data = value;
            }
        }

        public abstract DateTime ÚltimoVencimento { get; set; }

        public bool Pendente
        {
            get { return pendente; }
            set 
            { 
                if (pendente != value)
                    DefinirDesatualizado();
                
                pendente = value;
            }
        }

        public Entidades.Pessoa.Funcionário RegistradoPor
        {
            get { return registradopor; }
            set 
            { 
                if (registradopor != value)
                    DefinirDesatualizado();

                registradopor = value;
            }
        }

        public ulong Cliente
        {
            get { return cliente; }
            set 
            { 
                if (cliente != value)
                    DefinirDesatualizado();

                cliente = value;
            }
        }

        public bool Compartilhado { get { return false; } }

        public Pagamento(ulong cliente, int código, double valor, DateTime data, bool pendente, bool cadastrado, bool cobrarJuros)
        {
            this.cliente = cliente;
            this.codigo = código;
            this.valor = valor;
            this.data = data;
            this.pendente = pendente;
            this.cobrarJuros = cobrarJuros;

            venda = null;
        }

        public Pagamento()
        {
            cobrarJuros = true;
        }

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            StringBuilder comando = new StringBuilder();

            comando.Append("INSERT INTO pagamento (cliente, valor, data, pendente, registradopor, devolvido, descricao, cobrarJuros, venda) ");
            comando.Append("VALUES (");
            comando.Append(DbTransformar(this.cliente));
            comando.Append(", " );
            comando.Append(DbTransformar(this.valor));
            comando.Append(", ");
            comando.Append(DbTransformar(this.data));
            comando.Append(", ");
            comando.Append(DbTransformar(this.pendente));
            comando.Append(", ");
            comando.Append(DbTransformar(this.registradopor.Código));
            comando.Append(", ");
            comando.Append(DbTransformar(this.devolvido));
            comando.Append(", ");
            comando.Append(DbTransformar(this.descrição));
            comando.Append(", ");
            comando.Append(DbTransformar(this.cobrarJuros));
            comando.Append(", ");
            comando.Append((venda.HasValue ? DbTransformar(this.venda.Value) : "null"));
            comando.Append(") ");

            cmd.CommandText = comando.ToString(); 
            cmd.ExecuteNonQuery();

            this.codigo = ObterÚltimoCódigoInserido(cmd.Connection);
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            cmd.CommandText = "UPDATE pagamento SET " +
                " cliente = " + DbTransformar(this.cliente) + ", " +
                " valor = " + DbTransformar(this.valor) + ", " +
                " data = " + DbTransformar(this.data) + ", " +
                " pendente = " + DbTransformar(this.pendente) + ", " +
                " registradopor = " + DbTransformar(this.registradopor.Código) + ", " +
                " devolvido = " + DbTransformar(this.devolvido) + ", " +
                " cobrarJuros = " + DbTransformar(this.cobrarJuros) + ", " + 
                " descricao = " + DbTransformar(this.descrição) + ", " + 
                " venda = " + (venda.HasValue ? DbTransformar(venda.Value) : " null ") + 
                " WHERE codigo = " + DbTransformar(this.codigo);

            cmd.ExecuteNonQuery();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            // Descadastra pagamento
            cmd.CommandText = "DELETE FROM pagamento WHERE codigo = " + DbTransformar(codigo);
            cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Recupera todos os pagamentos associados ao cliente
        /// </summary>
        public static Pagamento[] ObterPagamentos(Entidades.Pessoa.Pessoa cliente)
        {
            return ObterPagamentos(cliente, null, false);
        }

        /// <summary>
        /// Recupera todos os pagamentos associados ao cliente
        /// </summary>
        public static Pagamento[] ObterPagamentos(Entidades.Pessoa.Pessoa cliente, bool somentePendente)
        {
            return ObterPagamentos(cliente, null, somentePendente);
        }

        /// <summary>
        /// Recupera todos os pagamentos associados a uma venda.
        /// </summary>
        public static Pagamento[] ObterPagamentos(IDadosVenda venda)
        {
            return ObterPagamentos(null, venda, false);
        }

        protected static Pagamento ObterPagamento(long código)
        {
            Pagamento entidade = Dinheiro.ObterPagamento(código);

            if (entidade == null)
                entidade = Cheque.ObterPagamento(código);

            if (entidade == null)
                entidade = NotaPromissória.ObterPagamento(código);

            if (entidade == null)
                entidade = Ouro.ObterPagamento(código);

            if (entidade == null)
                entidade = Dolar.ObterPagamento(código);

            return entidade;
        }

        protected virtual void PreencherAtributos(IDataReader leitor, int inicioAtributosPagamento, int inicioAtributosEspecifico)
        {
            codigo = leitor.GetInt32(inicioAtributosPagamento);
            cliente = (ulong) leitor.GetInt64(inicioAtributosPagamento + 1);
            valor = leitor.GetDouble(inicioAtributosPagamento + 2);
            data = leitor.GetDateTime(inicioAtributosPagamento + 3);
            pendente = leitor.GetBoolean(inicioAtributosPagamento + 4);
            registradopor = leitor.GetInt32(inicioAtributosPagamento + 5);
            devolvido = leitor.GetBoolean(inicioAtributosPagamento + 6);
            cobrarJuros = leitor.GetBoolean(inicioAtributosPagamento + 7);

            if (!leitor.IsDBNull(inicioAtributosPagamento + 8))
                descrição = leitor.GetString(inicioAtributosPagamento + 8);

            if (!leitor.IsDBNull(inicioAtributosPagamento + 9))
                venda = leitor.GetInt32(inicioAtributosPagamento + 9);
        } 

        /// <summary>
        /// Um dos dois parametros precisa ser nulo!
        /// Ou recupera vendas de um cliente ou relacionadas a uma venda!
        /// </summary>
        private static Pagamento[] ObterPagamentos(Entidades.Pessoa.Pessoa cliente, IDadosVenda venda, bool somentePendente)
        {
            List<Pagamento> pagamentos = new List<Pagamento>();

            if (venda != null && venda.Código == 0)
                return pagamentos.ToArray();

            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = "select p.*,d.*, c.*, pr.*, o.*, dl.* from pagamento p " + 
                                " left join dinheiro d on p.codigo=d.codigo " +
                                " left join cheque c on p.codigo=c.codigo " +
                                " left join notapromissoria pr on p.codigo=pr.codigo " +
                                " left join ouro o on p.codigo=o.codigo " +
                                " left join dolar dl on p.codigo=dl.codigo ";

                if (cliente != null && venda != null)
                    throw new InvalidOperationException();

                if (cliente != null)
                {
                    cmd.CommandText += " where cliente=" + DbTransformar(cliente.Código);

                    if (somentePendente)
                        cmd.CommandText += " AND pendente = 1 ";
                }

                if (venda != null)
                {
                    cmd.CommandText += " where venda=" + DbTransformar(venda.Código);
                }

                lock (conexão)
                {
                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {

                            Pagamento entidade;

                            while (leitor.Read())
                            {
                                if (!leitor.IsDBNull(totalAtributos))
                                {
                                    entidade = new Dinheiro();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos);
                                }
                                else if (!leitor.IsDBNull(totalAtributos + Dinheiro.totalAtributos))
                                {
                                    entidade = new Cheque();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos + Dinheiro.totalAtributos);
                                }
                                else if (!leitor.IsDBNull(totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos))
                                {
                                    entidade = new NotaPromissória();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos);
                                }
                                else if (!leitor.IsDBNull(totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos + NotaPromissória.totalAtributos))
                                {
                                    entidade = new Ouro();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos + NotaPromissória.totalAtributos);
                                }
                                else
                                {
                                    entidade = new Dolar();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos + NotaPromissória.totalAtributos + Ouro.totalAtributos);
                                }

                                entidade.DefinirCadastrado();
                                pagamentos.Add(entidade);
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

            return pagamentos.ToArray();
        }
        
        static int ContarPagamentosPendentes(Entidades.Pessoa.Pessoa cliente)
        {
            int qtd;
            IDbConnection conexão = Conexão;
            IDataReader leitor = null;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = "select count(*) from pagamento where pendente=1 AND cliente=" + DbTransformar(cliente.Código);
                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {
                        leitor.Read();
                        qtd = leitor.GetInt32(0);
                    }
                }
                finally
                {
                    {
                        if (leitor != null && !leitor.IsClosed)
                            leitor.Close();
                    }
                }
            }

            return qtd;
        }

        /// <summary>
        /// Dado lista de pagamentos, cria uma hash do código de cada uma apontando para a entidade.
        /// </summary>
        public static Dictionary<long, Pagamento> CriarHashCódigoPagamento(IEnumerable<Pagamento> pagamentos)
        {
            Dictionary<long, Pagamento> hash = new Dictionary<long, Pagamento>();

            foreach (Pagamento p in pagamentos)
                hash.Add(p.Código, p);

            return hash;
        }

        /// <summary>
        /// Obtem o número de dias de juros cobrado
        /// caso o pagamento seja vinculado com a venda do parâmetro.
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        public int ObterDiasJuros(IDadosVenda venda)
        {
            if (CobrarJuros)
                return Preço.CalcularDias(Preço.SomarDias(venda.Data, (int)venda.DiasSemJuros), ÚltimoVencimento);
            else
                return 0;
        }

        public double ObterValorLíquido(IDadosVenda venda)
        {
            if (CobrarJuros)
            {
                return Preço.Corrigir(ÚltimoVencimento.Date, Preço.SomarDias(venda.Data, (int)venda.DiasSemJuros),
                    Valor, venda.TaxaJuros);
            }
            else
            {
                return Valor;
            }
        }

        public new void DefinirDesatualizado()
        {
            base.DefinirDesatualizado();
        }

        protected virtual void ClonarAtributos(Pagamento p)
        {
            p.codigo = codigo;
            p.data = data;
            p.cliente = cliente;
            p.registradopor = registradopor;
            p.pendente = pendente;
            p.valor = valor;
            p.devolvido = devolvido;
            p.cobrarJuros = cobrarJuros;
            p.descrição = descrição;
            p.venda = venda;

            p.DefinirAtualizado(Atualizado);
            p.DefinirCadastrado(Cadastrado);
        }

        protected abstract Pagamento CriarEntidade();

        #region ICloneable Members

        public object Clone()
        {
            Pagamento novoPagamento = CriarEntidade();
            ClonarAtributos(novoPagamento);

            return novoPagamento;
        }

        #endregion

        public static int CompararDataVencimento(Pagamento a, Pagamento b)
        {
            int r = a.Data.CompareTo(b.Data);

            if (r == 0)
                return CompararVencimento(a, b);
            else
                return r;
        }

        public static int CompararVencimento(Pagamento a, Pagamento b)
        {
            return a.ÚltimoVencimento.CompareTo(b.ÚltimoVencimento);
        }

        public static double CalcularValorPago(List<IPagamento> pagamentos)
        {
            double valorPago = 0;

            foreach (IPagamento pagamento in pagamentos)
                valorPago += pagamento.Valor;

            return valorPago;
        }

        public override string ToString()
        {
            return Tipo.ToString();
        }

        public static double CalcularValorLíquido(IPagamento p, DateTime cobrança, double juros)
        {
            return Preço.Corrigir(p.ÚltimoVencimento, cobrança, p.Valor, juros);
        }

        /// <summary>
        /// Calcula juros embutidos em cada pagamento relativo a uma data de cobrança.
        /// Contabiliza o juros bruto em cada pagamento e soma todos eles.
        /// </summary>
        public static double CalcularJuros(List<IPagamento> pagamentos, DateTime cobrança, double taxaJuros)
        {
            double pagoLiquido = CalcularValorPagoLíquido(pagamentos, cobrança, taxaJuros);
            double pagoBruto = CalcularValorPago(pagamentos);

            return pagoBruto - pagoLiquido;
        }

        public static double CalcularValorPagoLíquido(List<IPagamento> pagamentos, DateTime cobrança, double juros)
        {
            double total = 0;
            foreach (IPagamento p in pagamentos)
                if (p.CobrarJuros)
                    total += CalcularValorLíquido(p, cobrança, juros);
                else
                    total += p.Valor;

            return total;
        }
    }
}
