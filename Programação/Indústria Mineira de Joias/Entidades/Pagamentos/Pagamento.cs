using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Collections;
using System.Data;
using Entidades.Relacionamento.Venda;
using Entidades.Configura��o;
namespace Entidades.Pagamentos
{
    [DbTransa��o]
    public abstract class Pagamento : DbManipula��oAutom�tica, ICloneable, IPagamento
    {
        private static int totalAtributos = 10;

        protected ulong cliente;

        [DbRelacionamento("codigo", "registradopor")]
        protected Entidades.Pessoa.Funcion�rio registradopor;

        protected long? venda;

        [DbChavePrim�ria(true)]
        protected long codigo;

        protected double valor;
        protected DateTime data;
        protected bool pendente;
        protected bool devolvido;
        protected bool cobrarJuros;

        [DbColuna("descricao")]
        protected string descri��o;

        /// <summary>
        /// Um cheque pode estar relacionado como pagamento de uma venda.
        /// nao � o caso.
        /// Quando o cheque fica sem fundo, ele pode estar vinculado a OUTRA venda,
        /// em que o valor corrigido de juros ser� pago, � ent�o um d�bito.
        /// </summary>
        [DbAtributo(TipoAtributo.Ignorar)]
        protected uint? pagoNaVenda;

        public enum TipoEnum { Cheque, Dinheiro, NotaPromiss�ria, Cr�dito, Ouro, Dolar };

        public abstract TipoEnum Tipo { get; }

        public bool Devolvido { get { return devolvido; } set { devolvido = value; DefinirDesatualizado();  } }
        public bool CobrarJuros { get { return cobrarJuros; } set { cobrarJuros = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Identifica��o do cheque.
        /// </summary>
        public string Descri��o { get { return descri��o; } set { descri��o = value; DefinirDesatualizado(); } }

        public string Descri��oCompleta
        {
            get
            {
                string completa = "";

                if (Descri��o != null && Descri��o.Trim().Length > 0)
                    completa = Descri��o.Trim();

                if (Descri��oAdicional != null && Descri��oAdicional.Trim().Length > 0)
                {
                    if (!String.IsNullOrEmpty(completa)) 
                        completa += " - ";
                    completa += Descri��oAdicional.Trim();
                }

                return completa;
            }
        }
        /// <summary>
        /// � uma descri��o adicional, a ser mostrada de forma concatenada � impress�o do pagamento ou na tela.
        /// Pode ser, por exemplo, "3,2 g ouro para fundir". � uma descri��o redundante n�o armazenada.
        /// </summary>
        public virtual string Descri��oAdicional
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



        public long C�digo
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
                    using (IDbConnection conex�o = Conex�o)
                    {
                        object resposta = null;

                        using (IDbCommand cmd = conex�o.CreateCommand())
                        {
                            cmd.CommandText = "select venda from vendadebito where pagamento = " + DbTransformar(C�digo);
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

        public abstract DateTime �ltimoVencimento { get; set; }

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

        public Entidades.Pessoa.Funcion�rio RegistradoPor
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

        public Pagamento(ulong cliente, int c�digo, double valor, DateTime data, bool pendente, bool cadastrado, bool cobrarJuros)
        {
            this.cliente = cliente;
            this.codigo = c�digo;
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
            comando.Append(DbTransformar(this.registradopor.C�digo));
            comando.Append(", ");
            comando.Append(DbTransformar(this.devolvido));
            comando.Append(", ");
            comando.Append(DbTransformar(this.descri��o));
            comando.Append(", ");
            comando.Append(DbTransformar(this.cobrarJuros));
            comando.Append(", ");
            comando.Append((venda.HasValue ? DbTransformar(this.venda.Value) : "null"));
            comando.Append(") ");

            cmd.CommandText = comando.ToString(); 
            cmd.ExecuteNonQuery();

            this.codigo = Obter�ltimoC�digoInserido(cmd.Connection);
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            cmd.CommandText = "UPDATE pagamento SET " +
                " cliente = " + DbTransformar(this.cliente) + ", " +
                " valor = " + DbTransformar(this.valor) + ", " +
                " data = " + DbTransformar(this.data) + ", " +
                " pendente = " + DbTransformar(this.pendente) + ", " +
                " registradopor = " + DbTransformar(this.registradopor.C�digo) + ", " +
                " devolvido = " + DbTransformar(this.devolvido) + ", " +
                " cobrarJuros = " + DbTransformar(this.cobrarJuros) + ", " + 
                " descricao = " + DbTransformar(this.descri��o) + ", " + 
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

        protected static Pagamento ObterPagamento(long c�digo)
        {
            Pagamento entidade = Dinheiro.ObterPagamento(c�digo);

            if (entidade == null)
                entidade = Cheque.ObterPagamento(c�digo);

            if (entidade == null)
                entidade = NotaPromiss�ria.ObterPagamento(c�digo);

            if (entidade == null)
                entidade = Ouro.ObterPagamento(c�digo);

            if (entidade == null)
                entidade = Dolar.ObterPagamento(c�digo);

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
                descri��o = leitor.GetString(inicioAtributosPagamento + 8);

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

            if (venda != null && venda.C�digo == 0)
                return pagamentos.ToArray();

            IDbConnection conex�o;
            IDataReader leitor = null;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
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
                    cmd.CommandText += " where cliente=" + DbTransformar(cliente.C�digo);

                    if (somentePendente)
                        cmd.CommandText += " AND pendente = 1 ";
                }

                if (venda != null)
                {
                    cmd.CommandText += " where venda=" + DbTransformar(venda.C�digo);
                }

                lock (conex�o)
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
                                    entidade = new NotaPromiss�ria();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos);
                                }
                                else if (!leitor.IsDBNull(totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos + NotaPromiss�ria.totalAtributos))
                                {
                                    entidade = new Ouro();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos + NotaPromiss�ria.totalAtributos);
                                }
                                else
                                {
                                    entidade = new Dolar();
                                    entidade.PreencherAtributos(leitor, 0, totalAtributos + Dinheiro.totalAtributos + Cheque.totalAtributos + NotaPromiss�ria.totalAtributos + Ouro.totalAtributos);
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
            IDbConnection conex�o = Conex�o;
            IDataReader leitor = null;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = "select count(*) from pagamento where pendente=1 AND cliente=" + DbTransformar(cliente.C�digo);
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
        /// Dado lista de pagamentos, cria uma hash do c�digo de cada uma apontando para a entidade.
        /// </summary>
        public static Dictionary<long, Pagamento> CriarHashC�digoPagamento(IEnumerable<Pagamento> pagamentos)
        {
            Dictionary<long, Pagamento> hash = new Dictionary<long, Pagamento>();

            foreach (Pagamento p in pagamentos)
                hash.Add(p.C�digo, p);

            return hash;
        }

        /// <summary>
        /// Obtem o n�mero de dias de juros cobrado
        /// caso o pagamento seja vinculado com a venda do par�metro.
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        public int ObterDiasJuros(IDadosVenda venda)
        {
            if (CobrarJuros)
                return Pre�o.CalcularDias(Pre�o.SomarDias(venda.Data, (int)venda.DiasSemJuros), �ltimoVencimento);
            else
                return 0;
        }

        public double ObterValorL�quido(IDadosVenda venda)
        {
            if (CobrarJuros)
            {
                return Pre�o.Corrigir(�ltimoVencimento.Date, Pre�o.SomarDias(venda.Data, (int)venda.DiasSemJuros),
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
            p.descri��o = descri��o;
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
            return a.�ltimoVencimento.CompareTo(b.�ltimoVencimento);
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

        public static double CalcularValorL�quido(IPagamento p, DateTime cobran�a, double juros)
        {
            return Pre�o.Corrigir(p.�ltimoVencimento, cobran�a, p.Valor, juros);
        }

        /// <summary>
        /// Calcula juros embutidos em cada pagamento relativo a uma data de cobran�a.
        /// Contabiliza o juros bruto em cada pagamento e soma todos eles.
        /// </summary>
        public static double CalcularJuros(List<IPagamento> pagamentos, DateTime cobran�a, double taxaJuros)
        {
            double pagoLiquido = CalcularValorPagoL�quido(pagamentos, cobran�a, taxaJuros);
            double pagoBruto = CalcularValorPago(pagamentos);

            return pagoBruto - pagoLiquido;
        }

        public static double CalcularValorPagoL�quido(List<IPagamento> pagamentos, DateTime cobran�a, double juros)
        {
            double total = 0;
            foreach (IPagamento p in pagamentos)
                if (p.CobrarJuros)
                    total += CalcularValorL�quido(p, cobran�a, juros);
                else
                    total += p.Valor;

            return total;
        }
    }
}
