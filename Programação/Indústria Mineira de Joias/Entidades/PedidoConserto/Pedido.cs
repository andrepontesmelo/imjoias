using Acesso.Comum;
using Entidades.Configuração;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades.PedidoConserto
{
    /// <summary>
    /// Pedido de encomenda ou conserto.
    /// </summary>
    public class Pedido : DbManipulaçãoAutomática
    {
        public Pedido()
        {
            entrega = Entrega.Levar;
        }

        private static readonly int TotalAtributosPedidos = 18;

        #region Atributos
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'
        [DbChavePrimária(true), DbColuna("codigo")]
        private ulong código;
#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        //private uint? controle;
        private bool pertenceAoCliente;

        [DbConversão(typeof(Pedido.ConversorTipo))]
        public enum Tipo
        {
            Conserto = 1, Pedido = 2
        }

        [DbConversão(typeof(Pedido.ConversorTipoEntrega))]
        public enum Entrega
        {
            Levar = 1, Despachar = 2
        }

        private Tipo tipo;
        private Entrega entrega;

        [DbRelacionamento("codigo", "cliente")]
        private Pessoa.Pessoa cliente;

        [DbRelacionamento("codigo", "funcionarioentrega")]        
        private Pessoa.Funcionário funcionarioentrega;

        [DbRelacionamento("codigo", "funcionariooficina")]
        private Pessoa.Funcionário funcionariooficina;

        [DbRelacionamento("codigo", "funcionarioconclusao")]
        private Pessoa.Funcionário funcionarioconclusao;

        [DbRelacionamento("codigo", "representante")]
        private Pessoa.Pessoa representante;

        [DbRelacionamento("codigo", "receptor")]
        private Funcionário receptor;

        [DbColuna("dataRecepcao")]
        private DateTime dataRecepção = DadosGlobais.Instância.HoraDataAtual;

        [DbColuna("dataPrevisao")]
        private DateTime dataPrevisão = DadosGlobais.Instância.HoraDataAtual.AddDays(7);

        [DbColuna("dataConclusao")]
        private DateTime? dataConclusão;

        [DbColuna("dataOficina")]
        private DateTime? dataOficina;

        private double valor;

        private DateTime? dataEntrega;

        [DbColuna("nomecliente")]
        private string nomeCliente;

        [DbColuna("observacoes")]
        private string observações;

        /// <summary>
        /// É uma string para visualização da descrição dos itens. 
        /// read-only.
        /// </summary>
        public string DescriçãoItens
        {
            get { return descriçãoItens; }
            set { descriçãoItens = value; }
        }
                

        [DbAtributo(TipoAtributo.Ignorar)]
        private string descriçãoItens;


        #endregion

        /// <summary>
        /// Conversor da enumeração tipo para banco de dados.
        /// </summary>
        public class ConversorTipo : DbConversor
        {
            public override object ConverterDeDB(object valor)
            {
                switch (valor.ToString()[0])
                {
                    case 'C':
                    case 'c':
                        return Tipo.Conserto;

                    case 'E':
                    case 'e':
                        return Tipo.Pedido;

                    default:
                        throw new NotSupportedException();
                }
            }

            public override object ConverterParaDB(object valor)
            {
                return (int)valor;
            }
        }
    
    
        
        /// <summary>
        /// Conversor da enumeração tipo para banco de dados.
        /// </summary>
        public class ConversorTipoEntrega : DbConversor
        {
            public override object ConverterDeDB(object valor)
            {
                switch (valor.ToString()[0])
                {
                    case 'D':
                    case 'd':
                        return Entrega.Despachar;

                    case 'L':
                    case 'l':
                        return Entrega.Levar;

                    default:
                        throw new NotSupportedException();
                }
            }

            public override object ConverterParaDB(object valor)
            {
                return (int) valor;
            }
        }

        #region Propriedades

        /// <summary>
        /// Código do pedido.
        /// </summary>
        public ulong Código { get { return código; } }

        /// <summary>
        /// Se o pedido/conserto pertence ao cliente ou se pertence à empresa.
        /// </summary>
        public bool PertenceAoCliente { get { return pertenceAoCliente; } set { pertenceAoCliente = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Tipo do pedido.
        /// </summary>
        public Tipo TipoPedido { get { return tipo; } set { tipo = value; DefinirDesatualizado(); } }

        public Entrega EntregaPedido { get { return entrega; } set { entrega = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Cliente que requisitou o pedido.
        /// </summary>
        public Pessoa.Pessoa Cliente { get { return cliente; } set { cliente = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Cliente que requisitou o pedido.
        /// </summary>
        public string NomeDoCliente { get { return nomeCliente; } set { nomeCliente = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Representante que recebeu o pedido.
        /// </summary>
        /// <remarks>Pode ser nulo.</remarks>
        public Pessoa.Pessoa Representante { get { return representante; } set { representante = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Funcionário que recebeu o pedido.
        /// </summary>
        public Funcionário Receptor { get { return receptor; } set { receptor = value; } }

        /// <summary>
        /// Data da recepção do pedido.
        /// </summary>
        public DateTime DataRecepção { get { return dataRecepção; } set { dataRecepção = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Data da previsão do pedido.
        /// </summary>
        public DateTime DataPrevisão { get { return dataPrevisão; } 
            set {  dataPrevisão = value; DefinirDesatualizado();  } }

        /// <summary>
        /// Data da conclusão do pedido.
        /// </summary>
        public DateTime? DataConclusão { get { return dataConclusão; } set { dataConclusão = value; DefinirDesatualizado(); } }

        public DateTime? DataOficina { get { return dataOficina; } set { dataOficina = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Data da entrega do pedido.
        /// </summary>
        public DateTime? DataEntrega 
        { 
            get { return dataEntrega; } 
            set 
            { 
                dataEntrega = value;
                funcionarioentrega = Entidades.Pessoa.Funcionário.ObterFuncionárioPorUsuário(Acesso.Comum.Usuários.UsuárioAtual.Nome); 

                DefinirDesatualizado(); 
            } 
        }

        /// <summary>
        /// Retorna o funcionário que realizou a entrega
        /// </summary>
        public Funcionário FuncionárioEntrega
        {
            get { return funcionarioentrega; }
            set { funcionarioentrega = value;  }
        }

        public Funcionário FuncionárioConclusão
        {
            get { return funcionarioconclusao; }
            set { funcionarioconclusao = value; }
        }

        public Funcionário FuncionárioOficina
        {
            get { return funcionariooficina; }
            set { funcionariooficina = value; }
        }

        public double Valor
        {
            get { return valor; }
            set
            {
                valor = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Observações acerca do pedido.
        /// </summary>
        public string Observações { get { return observações; } set { observações = value; DefinirDesatualizado(); } }

        #endregion

        #region Recuperação de dados

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidos(Pessoa.Pessoa cliente)
        {
            Pedido[] pedidos = Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE cliente = {0} order by dataRecepcao",
                DbTransformar(cliente.Código))).ToArray();

            PreencherObservaçõesDosItens(pedidos);
            return pedidos;
        }

        ///// <summary>
        ///// Obtém um pedido
        ///// </summary>
        //public static Pedido ObterPedido(uint controle, Tipo tipo)
        //{
        //    return MapearÚnicaLinha<Pedido>(
        //        string.Format(
        //        "SELECT * FROM pedido WHERE tipo = {0} AND controle = {1}",
        //        DbTransformar(tipo),
        //        DbTransformar(controle)));
        //}

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidos(Representante representante)
        {
            Pedido[] pedidos = Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE representante = {0} order by dataRecepcao",
                DbTransformar(representante.Código))).ToArray();

            PreencherObservaçõesDosItens(pedidos);
            return pedidos;
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido ObterPedido(long código)
        {
            return MapearÚnicaLinha<Pedido>(
               string.Format(
               "SELECT * FROM pedido WHERE codigo = {0}",
               DbTransformar(código)));
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidosRecebidos(DateTime início, DateTime fim, bool períodoPrevisão, bool ocultarJáEntregues, bool apenasPedidos)
        {
            IDataReader leitor = null;
            List<Pedido> pedidos = new List<Pedido>();

            string inicio = início.Date == DateTime.MinValue ? "'null'" : DbTransformar(início.Date);

            IDbConnection conexao = Conexão;
            lock (conexao)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexao);
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        DateTime dataFimUtilizar = (fim.Date.Date == DateTime.MaxValue.Date ? DateTime.MaxValue : fim.Date.AddDays(1));

                        cmd.CommandText = string.Format(
                        "SELECT * FROM pedido left join pessoa on pedido.cliente=pessoa.codigo left join pessoafisica on pessoa.codigo=pessoafisica.codigo left join pessoajuridica pj on pessoa.codigo=pj.codigo " +
                        " left join pessoa p on p.codigo=pedido.representante left join pessoafisica pf on pf.codigo=pedido.representante WHERE " + (períodoPrevisão ? "dataPrevisao" : "dataRecepcao")
                        + " BETWEEN {0} AND {1} "
                        + (ocultarJáEntregues ? "AND dataEntrega is null " : "")
                        + " and tipo = " + (apenasPedidos ? "'E'" : "'C'")
                        + " order by dataRecepcao",
                        inicio, DbTransformar(dataFimUtilizar));

                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                                pedidos.Add(Obter(leitor, 0));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexao);
                    }
                }
            }

            Pedido[] pedidosVetor = pedidos.ToArray();
            PreencherObservaçõesDosItens(pedidosVetor);
            return pedidosVetor;
        }    

        public static void PreencherObservaçõesDosItens(Pedido[] pedidos)
        {
            if (pedidos.Length == 0)
                return;

            Dictionary<ulong, Pedido> hash = new Dictionary<ulong, Pedido>();
            foreach (Pedido p in pedidos)
                hash.Add(p.Código, p);

            IDataReader leitor = null;

            IDbConnection conexao = Conexão;
            lock (conexao)
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText =
                        "select pedido, GROUP_CONCAT(concat(quantidade, ' ', mercadoria, ' ', ifnull(descricao,''), ';')) from pedidoitem where pedido in "
                        + DbTransformarConjunto(pedidos) + "  group by pedido ";

                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                Pedido p;
                                if (hash.TryGetValue((ulong)leitor.GetInt32(0), out p))
                                {
                                    if (!leitor.IsDBNull(1))
                                        p.DescriçãoItens = leitor.GetString(1);
                                }
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
        }

        private static Pedido Obter(IDataReader leitor, int inicioPedidos)
        {
            Pedido pedido = new Pedido();
            pedido.código = (ulong) leitor.GetInt64(0 + inicioPedidos);

            pedido.tipo = (Tipo)new ConversorTipo().ConverterDeDB(leitor.GetString(1 + inicioPedidos));

            var fimPedidos = TotalAtributosPedidos + inicioPedidos;
            var inícioPessoaFísicaCliente = fimPedidos + Pessoa.Pessoa.TotalAtributos;
            var inícioPessoaJurídicaCliente = inícioPessoaFísicaCliente + PessoaFísica.TotalAtributos;

            pedido.cliente = Pessoa.Pessoa.ObterPessoa(leitor, fimPedidos, inícioPessoaFísicaCliente, inícioPessoaJurídicaCliente);

            var inícioPessoaRepresentante = inícioPessoaJurídicaCliente + PessoaJurídica.TotalAtributos;
            var inícioPessoaFísicaRepresenante = inícioPessoaRepresentante + Pessoa.Pessoa.TotalAtributos;

            if (!leitor.IsDBNull(3 + inicioPedidos))
                pedido.representante = Entidades.Pessoa.Representante.Obter(leitor,
                    inícioPessoaRepresentante, inícioPessoaFísicaRepresenante);

            if (!leitor.IsDBNull(4 + inicioPedidos))
                pedido.receptor = Funcionário.ObterPessoa((ulong)leitor.GetInt64(4 + inicioPedidos));

            if (!leitor.IsDBNull(5 + inicioPedidos))
                pedido.dataRecepção = leitor.GetDateTime(5 + inicioPedidos);

            if (!leitor.IsDBNull(6 + inicioPedidos))
                pedido.dataPrevisão = leitor.GetDateTime(6 + inicioPedidos);

            if (!leitor.IsDBNull(7 + inicioPedidos))
                pedido.dataConclusão = leitor.GetDateTime(7 + inicioPedidos);

            if (!leitor.IsDBNull(8 + inicioPedidos))
                pedido.dataEntrega = leitor.GetDateTime(8 + inicioPedidos);

            if (!leitor.IsDBNull(9 + inicioPedidos))
                pedido.observações = leitor.GetString(9 + inicioPedidos);

            pedido.entrega = (Entrega) new ConversorTipoEntrega().ConverterDeDB(leitor.GetString(10 + inicioPedidos));

            if (!leitor.IsDBNull(11 + inicioPedidos))
                pedido.funcionarioentrega = Funcionário.ObterPessoa((ulong) leitor.GetInt64(11 + inicioPedidos));

            pedido.pertenceAoCliente = leitor.GetBoolean(12 + inicioPedidos);
            pedido.valor = leitor.GetDouble(13 + inicioPedidos);

            if (!leitor.IsDBNull(14 + inicioPedidos))
                pedido.nomeCliente = leitor.GetString(14 + inicioPedidos);

            if (!leitor.IsDBNull(15 + inicioPedidos))
                pedido.dataOficina = leitor.GetDateTime(15 + inicioPedidos);

            if (!leitor.IsDBNull(16 + inicioPedidos))
                pedido.funcionariooficina = Funcionário.ObterPessoa((ulong)leitor.GetInt64(16 + inicioPedidos));

            if (!leitor.IsDBNull(17 + inicioPedidos))
                pedido.funcionarioconclusao = Funcionário.ObterPessoa((ulong)leitor.GetInt64(17 + inicioPedidos));


            pedido.DefinirCadastrado();
            pedido.DefinirAtualizado();

            return pedido;
        }

        /// <summary>
        /// Busca livre. Pode-se usar como palavrachave o código do pedido, ou algum pedaço do nome do cliente
        /// ou algum texto dentro da observação para pedidos e consertos.
        /// </summary>
        public static Pedido[] Obter(string palavraChave, int limite)
        {
            IDataReader leitor = null;
            List<Pedido> pedidos = new List<Pedido>();
            IDbConnection conexao = Conexão;

            palavraChave = palavraChave.Trim();
            StringBuilder consulta = new StringBuilder();

            consulta.Append(" SELECT * FROM ( ");
            int código;
            if (Int32.TryParse(palavraChave, out código))
            {
                consulta.Append("select * from pedido where codigo=");
                consulta.Append(DbTransformar(código));
                consulta.Append(" UNION ");
            }

            consulta.Append("select * from pedido where cliente in ( ");
            consulta.Append(" select codigo from pessoa where nome like '");
            consulta.Append(palavraChave);
            consulta.Append("%' UNION select codigo from pessoa where nome like '%");
            consulta.Append(palavraChave);
            consulta.Append("' UNION select codigo from pessoa where nome like '%");
            consulta.Append(palavraChave.Replace(' ', '%'));
            consulta.Append("%') UNION select * from pedido where observacoes like '%");
            consulta.Append(palavraChave);
            consulta.Append("%'");

            consulta.Append(" ) consulta ");
            
            consulta.Append(" left join pessoa on consulta.cliente=pessoa.codigo left join pessoafisica on pessoa.codigo=pessoafisica.codigo ");
            consulta.Append(" left join pessoajuridica pj on pessoa.codigo=pj.codigo ");
            consulta.Append(" left join pessoa p on p.codigo=consulta.representante left join pessoafisica pf on pf.codigo=consulta.representante ");

            consulta.Append(" LIMIT ");

            consulta.Append(limite);

            lock (conexao)
            {
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = consulta.ToString();

                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                                pedidos.Add(Obter(leitor, 0));
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                    }
                }
            }

            return pedidos.ToArray();
        }


        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterConsertosRecebidos(DateTime início, DateTime fim, bool períodoPrevisão, bool ocultarJáEntregues)
        {
            string inicio = início.Date == DateTime.MinValue ? "'null'" : DbTransformar(início.Date);

            return Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE " + (períodoPrevisão ? "dataPrevisao" : "dataRecepcao") 
                + " BETWEEN {0} AND {1} AND tipo=1 "
                + (ocultarJáEntregues ? "AND dataEntrega is null " : "") 
                + " order by dataRecepcao",
                inicio, DbTransformar(fim.Date.AddDays(1)))).ToArray();
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterEncomendasRecebidas(DateTime início, DateTime fim, bool períodoPrevisão, bool ocultarJáEntregues)
        {
            string inicio = início.Date == DateTime.MinValue ? "'null'" : DbTransformar(início.Date);
            string dataFinal = fim == DateTime.MaxValue ? DbTransformar(fim) : DbTransformar(fim.Date.AddDays(1));

            Pedido[] pedidos = Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE " + (períodoPrevisão ? "dataPrevisao" : "dataRecepcao") 
                + " BETWEEN {0} AND {1} AND tipo=2 "
                + (ocultarJáEntregues ? "AND dataEntrega is null " : "") 
                + " order by dataRecepcao",
                inicio, dataFinal)).ToArray();

            PreencherObservaçõesDosItens(pedidos);

            return pedidos;
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidosRecebidos(Pessoa.Pessoa cliente, DateTime início, DateTime fim, bool períodoPrevisão, bool ocultarJáEntregues, bool apenasPedidos)
        {
            string inicio = início.Date == DateTime.MinValue ? "'null'" : DbTransformar(início.Date);

            if (fim != DateTime.MaxValue)
                fim = fim.Date.AddDays(1);

            Pedido[] pedidos = Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE " + (períodoPrevisão ? "dataPrevisao" : "dataRecepcao")
                + " BETWEEN {0} AND {1} AND (cliente = {2} OR representante = {2}) "
                + (ocultarJáEntregues ? "AND dataEntrega is null " : " ") 
                + "AND tipo = " + (apenasPedidos ? "'E'" : "'C'")
                + " order by dataRecepcao",
                inicio, DbTransformar(fim.Date),
                DbTransformar(cliente.Código))).ToArray();

            PreencherObservaçõesDosItens(pedidos);
            return pedidos;
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidosPendentes()
        {
            Pedido[] pedidos = Mapear<Pedido>("SELECT * FROM pedido WHERE dataEntrega IS NULL order by dataRecepcao").ToArray();
            PreencherObservaçõesDosItens(pedidos);
            return pedidos;
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidosPendentes(Entidades.Pessoa.Pessoa pessoa)
        {
            Pedido[] pedidos = Mapear<Pedido>(string.Format(
                "SELECT * FROM pedido WHERE dataEntrega IS NULL AND (cliente = {0} OR representante = {0}) order by dataRecepcao",
                DbTransformar(pessoa.Código))).ToArray();

            PreencherObservaçõesDosItens(pedidos);
            return pedidos;
        }

        ///// <summary>
        ///// Verifica existência de um documento específico.
        ///// </summary>
        //public bool VerificarExistência(Tipo tipo, uint controle)
        //{
        //    IDbConnection conexão = Conexão;

        //    using (IDbCommand cmd = conexão.CreateCommand())
        //    {
        //        cmd.CommandText = string.Format(
        //            "SELECT COUNT(*) FROM pedido WHERE tipo = {0} AND controle = {1}",
        //            DbTransformar(tipo),
        //            DbTransformar(controle));
        //        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        //    }
        //}

        /// <summary>
        /// Conta a quantidade de pedidos pendentes existem para um
        /// determinado cliente.
        /// </summary>
        /// <returns>Quantidade de pedidos pendentes.</returns>
        public static int ContarPedidosPendentes(Entidades.Pessoa.Pessoa cliente)
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = string.Format(
                    "SELECT COUNT(*) FROM pedido WHERE (cliente = {0} OR representante = {0}) AND dataEntrega IS NULL",
                    DbTransformar(cliente.Código));
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Conta a quantidade de pedidos pendentes prontos que existem para um
        /// determinado cliente.
        /// </summary>
        /// <returns>Quantidade de pedidos pendentes.</returns>
        public static void ContarPedidosPendentesProntos(Entidades.Pessoa.Pessoa cliente, out int pedidos, out int consertos)
        {
            pedidos = 0;
            consertos = 0;

            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            
            {
                cmd.CommandText = string.Format(
                    "SELECT tipo, COUNT(*) FROM pedido WHERE (cliente = {0} OR representante = {0}) AND dataEntrega IS NULL AND dataConclusao IS NOT NULL group by tipo",
                    DbTransformar(cliente.Código));

                using (IDataReader leitor = cmd.ExecuteReader())
                {
                    try
                    {
                        while (leitor.Read())
                        {
                            char tipo = leitor.GetChar(0);
                            int qtd = leitor.GetInt16(1);

                            if (tipo == 'E')
                                pedidos = qtd;
                            else if (tipo == 'C')
                                consertos = qtd;
                            else
                                throw new NotImplementedException();
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                    }
                }
            }
        }

        #endregion

        public override string ToString()
        {
            return TipoPedido.ToString() + " #" + Código.ToString();
        }
    }
}
