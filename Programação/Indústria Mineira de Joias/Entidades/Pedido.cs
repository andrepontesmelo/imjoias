using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Pessoa;
using System.Data;
using Entidades.Configuração;

namespace Entidades
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

        private static readonly int TotalAtributos = 14;

        #region Atributos
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'
        [DbChavePrimária(true), DbColuna("codigo")]
        private ulong código;
#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        private uint? controle;
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

        private DateTime? dataEntrega;

        [DbColuna("observacoes")]
        private string observações;

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
                //switch ((Entrega) valor)
                //{
                //    case Entrega.Levar:
                //        return 'L';
                //        break;

                //    case Entrega.Despachar:
                //        return 'D';
                //        break;

                //    default:
                //        throw new NotSupportedException();
                
                return (int)valor;
            }
        }

        #region Propriedades

        /// <summary>
        /// Código do pedido.
        /// </summary>
        public ulong Código { get { return código; } }

        /// <summary>
        /// Número de controle do pedido.
        /// </summary>
        public uint? Controle { get { return controle; } set { controle = value; DefinirDesatualizado(); } }

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
            return Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE cliente = {0} order by dataRecepcao",
                DbTransformar(cliente.Código))).ToArray();
        }

        /// <summary>
        /// Obtém um pedido
        /// </summary>
        public static Pedido ObterPedido(uint controle, Tipo tipo)
        {
            return MapearÚnicaLinha<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE tipo = {0} AND controle = {1}",
                DbTransformar(tipo),
                DbTransformar(controle)));
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidos(Representante representante)
        {
            return Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE representante = {0} order by dataRecepcao",
                DbTransformar(representante.Código))).ToArray();
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido ObterPedido(uint código)
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
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = string.Format(
                        "SELECT * FROM pedido left join pessoa on pedido.cliente=pessoa.codigo left join pessoafisica on pessoa.codigo=pessoafisica.codigo " +
                        " left join pessoa p on p.codigo=pedido.representante left join pessoafisica pf on pf.codigo=pedido.representante WHERE " + (períodoPrevisão ? "dataPrevisao" : "dataRecepcao")
                        + " BETWEEN {0} AND {1} "
                        + (ocultarJáEntregues ? "AND dataEntrega is null " : "")
                        + " and tipo = " + (apenasPedidos ? "'E'" : "'C'")
                        + " order by dataRecepcao",
                        inicio, DbTransformar(fim.Date.AddDays(1)));

                        leitor = cmd.ExecuteReader();

                        while (leitor.Read())
                            pedidos.Add(Obter(leitor, 0));
                    }
                    catch (Exception erro)
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

        private static Pedido Obter(IDataReader leitor, int inicioPedidos)
        {
            Pedido pedido = new Pedido();
            pedido.código = (ulong) leitor.GetInt64(0 + inicioPedidos);

            if (!leitor.IsDBNull(1 + inicioPedidos))
                pedido.controle = (uint)leitor.GetInt32(1 + inicioPedidos);

            pedido.tipo = (Tipo)new ConversorTipo().ConverterDeDB(leitor.GetString(2 + inicioPedidos));

            pedido.cliente = Entidades.Pessoa.Pessoa.ObterPessoa(leitor, TotalAtributos + inicioPedidos,
                TotalAtributos + inicioPedidos + Entidades.Pessoa.Pessoa.TotalAtributos, 0);

            if (!leitor.IsDBNull(4 + inicioPedidos))
                pedido.representante = Entidades.Pessoa.Representante.Obter(leitor,
                    TotalAtributos + inicioPedidos + Entidades.Pessoa.Pessoa.TotalAtributos + Entidades.Pessoa.PessoaFísica.TotalAtributos,
                    TotalAtributos + inicioPedidos + 2 * Entidades.Pessoa.Pessoa.TotalAtributos + Entidades.Pessoa.PessoaFísica.TotalAtributos);


            if (!leitor.IsDBNull(5 + inicioPedidos))
                pedido.receptor = Funcionário.ObterPessoa((ulong)leitor.GetInt64(5 + inicioPedidos));

            if (!leitor.IsDBNull(6 + inicioPedidos))
                pedido.dataRecepção = leitor.GetDateTime(6 + inicioPedidos);

            if (!leitor.IsDBNull(7 + inicioPedidos))
                pedido.dataPrevisão = leitor.GetDateTime(7 + inicioPedidos);

            if (!leitor.IsDBNull(8 + inicioPedidos))
                pedido.dataConclusão = leitor.GetDateTime(8 + inicioPedidos);

            if (!leitor.IsDBNull(9 + inicioPedidos))
                pedido.dataEntrega = leitor.GetDateTime(9 + inicioPedidos);

            if (!leitor.IsDBNull(10 + inicioPedidos))
                pedido.observações = leitor.GetString(10 + inicioPedidos);

            pedido.entrega = (Entrega) new ConversorTipoEntrega().ConverterDeDB(leitor.GetString(11 + inicioPedidos));

            if (!leitor.IsDBNull(12 + inicioPedidos))
                pedido.funcionarioentrega = Funcionário.ObterPessoa((ulong) leitor.GetInt64(12 + inicioPedidos));

            pedido.pertenceAoCliente = leitor.GetBoolean(13 + inicioPedidos);


            pedido.DefinirCadastrado();
            pedido.DefinirAtualizado();

            return pedido;
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

            return Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE " + (períodoPrevisão ? "dataPrevisao" : "dataRecepcao") 
                + " BETWEEN {0} AND {1} AND tipo=2 "
                + (ocultarJáEntregues ? "AND dataEntrega is null " : "") 
                + " order by dataRecepcao",
                inicio, DbTransformar(fim.Date.AddDays(1)))).ToArray();
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidosRecebidos(Pessoa.Pessoa cliente, DateTime início, DateTime fim, bool períodoPrevisão, bool ocultarJáEntregues, bool apenasPedidos)
        {
            string inicio = início.Date == DateTime.MinValue ? "'null'" : DbTransformar(início.Date);

            return Mapear<Pedido>(
                string.Format(
                "SELECT * FROM pedido WHERE " + (períodoPrevisão ? "dataPrevisao" : "dataRecepcao")
                + " BETWEEN {0} AND {1} AND (cliente = {2} OR representante = {2}) "
                + (ocultarJáEntregues ? "AND dataEntrega is null " : " ") 
                + "AND tipo = " + (apenasPedidos ? "'E'" : "'C'")
                + " order by dataRecepcao",
                inicio, DbTransformar(fim.Date.AddDays(1)),
                DbTransformar(cliente.Código))).ToArray();
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidosPendentes()
        {
            return Mapear<Pedido>("SELECT * FROM pedido WHERE dataEntrega IS NULL order by dataRecepcao").ToArray();
        }

        /// <summary>
        /// Obtém pedidos de um cliente.
        /// </summary>
        public static Pedido[] ObterPedidosPendentes(Entidades.Pessoa.Pessoa pessoa)
        {
            return Mapear<Pedido>(string.Format(
                "SELECT * FROM pedido WHERE dataEntrega IS NULL AND (cliente = {0} OR representante = {0}) order by dataRecepcao",
                DbTransformar(pessoa.Código))).ToArray();
        }

        /// <summary>
        /// Verifica existência de um documento específico.
        /// </summary>
        public bool VerificarExistência(Tipo tipo, uint controle)
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = string.Format(
                    "SELECT COUNT(*) FROM pedido WHERE tipo = {0} AND controle = {1}",
                    DbTransformar(tipo),
                    DbTransformar(controle));
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

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
        public static int ContarPedidosPendentesProntos(Entidades.Pessoa.Pessoa cliente)
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = string.Format(
                    "SELECT COUNT(*) FROM pedido WHERE (cliente = {0} OR representante = {0}) AND dataEntrega IS NULL AND dataConclusao IS NOT NULL",
                    DbTransformar(cliente.Código));
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        #endregion

        public override string ToString()
        {
            return TipoPedido.ToString() + " #" + Código.ToString();
        }
    }
}
