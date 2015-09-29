using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Acesso.Comum;

namespace Entidades.Relacionamento.Venda
{
    /// <summary>
    /// Serve apenas para exibição de dados na apresentação.
    /// Tem o poder de obter dados do banco de dados rapidamente
    /// E disponibiliza-los para exibição
    /// </summary>
    public class VendaSintetizada : DbManipulação, IDadosVenda
    {
        private static readonly string INICIO_SELECT = "SELECT v.codigo, v.controle, v.valortotal, v.nome, v.cliente, v.data, v.taxajuros, v.cotacao, e.semaforo from vendasintetizada v join comissao_semaforo e on v.codigo=e.venda ";

        private long código;
        private string nomeCliente;
        private string nomeVendedor;
        private double valorTotal;
        private uint? controle;
        private DateTime data;
        private double taxaJuros;
        private double cotação;

        private SemaforoEnum semáforo;

        public SemaforoEnum Semáforo
        {
            get { return semáforo; }
            set { semáforo = value; }
        }

        public double Cotação
        {
            get { return cotação; }
            set { cotação = value; }
        }

        public string NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        public string NomeVendedor
        {
            get { return nomeVendedor; }
            set { nomeVendedor = value; }
        }

        public double Valor
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }

        public double TaxaJuros
        {
            get { return taxaJuros; }
            set { taxaJuros = value; }
        }

        public uint DiasSemJuros
        {
            get
            { 
                throw new NotImplementedException(); 
            }
        }

        public long Código
        {
            get { return código; }
            set { código = value; }
        }

        public uint? Controle
        {
            get { return controle; }
            set { controle = value; }
        }

        public DateTime Data
        {
            get { return data; }
        }

        
        public static VendaSintetizada[] ObterVendas(List<long> códigos)
        {
            if (códigos.Count == 0) return (VendaSintetizada[])new ArrayList().ToArray(typeof(VendaSintetizada));

            bool primeiro = true;
            StringBuilder consulta = new StringBuilder(INICIO_SELECT);
            consulta.Append(" WHERE ");

            foreach (long cod in códigos)
            {
                if (primeiro)
                {
                    consulta.Append(" codigo= ");
                    consulta.Append(DbTransformar(cod));
                    primeiro = false;
                }
                else
                {
                    consulta.Append(" OR codigo= ");
                    consulta.Append(DbTransformar(cod));
                }
            }

            return RecuperarDados(consulta.ToString());
        }

        private enum Ordem { Código, Controle, ValorTotal, NomeVendedor, NomeCliente, Data, TaxaJuros, Cotação, Semaforo }

        private static VendaSintetizada[] RecuperarDados(string consulta)
        {
            ArrayList vendas = new ArrayList();

            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                IDataReader leitor = null;
                cmd.CommandTimeout = 30;
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
                                VendaSintetizada nova = new VendaSintetizada();
                                nova.código = leitor.GetInt64((int)Ordem.Código);

                                if (leitor.IsDBNull((int)Ordem.NomeCliente))
                                    nova.nomeCliente = "";
                                else
                                    nova.nomeCliente = leitor.GetString((int)Ordem.NomeCliente);

                                if (leitor.IsDBNull((int)Ordem.NomeVendedor))
                                    nova.nomeVendedor = "";
                                else
                                    nova.nomeVendedor = leitor.GetString((int)Ordem.NomeVendedor);

                                if (!leitor.IsDBNull((int)Ordem.Controle))
                                    nova.controle = Convert.ToUInt32(leitor.GetValue((int)Ordem.Controle));
                                else
                                    nova.controle = null;

                                if (!leitor.IsDBNull((int)Ordem.ValorTotal))
                                    nova.valorTotal = leitor.GetDouble((int)Ordem.ValorTotal);
                                else
                                    nova.valorTotal = 0;

                                nova.data = leitor.GetDateTime((int)Ordem.Data);
                                nova.TaxaJuros = leitor.GetDouble((int)Ordem.TaxaJuros);
                                nova.Cotação = leitor.GetDouble((int)Ordem.Cotação);

                                int semaforo = leitor.GetInt16((int)Ordem.Semaforo);
                                nova.Semáforo = (SemaforoEnum) Enum.ToObject(typeof(SemaforoEnum), semaforo);

                                vendas.Add(nova);
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

            return (VendaSintetizada[])vendas.ToArray(typeof(VendaSintetizada));

        }


        /// <summary>
        /// Retorna as todas as vendas independente do cliente ou vendedor.
        /// </summary>
        public static VendaSintetizada[] ObterVendas(DateTime início, DateTime final, bool somenteNãoAcertadas, bool? sedex)
        {
            return ObterVendas(false, null, início, final, somenteNãoAcertadas, sedex);
        }

        /// <summary>
        /// Obtem vendas relacionadas a esta venda por pagamento.
        /// É olhado o conjunto de pagamentos desta venda.
        /// É retornado o conjunto de vendas relacionados 
        /// a este grupo de pagamentos
        /// </summary>
        /// <returns></returns>
        public static VendaSintetizada[] ObterVendasRelacionadasPorPagamento(long código)
        {
            
            StringBuilder consulta = new StringBuilder(INICIO_SELECT);
            consulta.Append(", vinculovendapagamento vinc where ");
            consulta.Append(" v.codigo != ");
            consulta.Append(DbTransformar(código));
            consulta.Append(" AND vinc.venda=v.codigo ");
            consulta.Append(" AND pagamento in ");
            consulta.Append(" (select pagamento from vinculovendapagamento where venda= ");
            consulta.Append(código.ToString());
            consulta.Append(") group by venda ");

            return RecuperarDados(consulta.ToString());
        }

              /// <summary>
        /// Obtém vendas de um cliente/vendedor.
        /// </summary>
        /// <remarks>
        /// Só funciona para cliente e vendedor não nulos
        /// </remarks>
        /// <returns>Vendas para o cliente/de um vendedor.</returns>
        public static VendaSintetizada[] ObterVendas(Entidades.Pessoa.Pessoa vendedor, Entidades.Pessoa.Pessoa cliente, DateTime início, DateTime final)
        {
            StringBuilder cmd = new StringBuilder(INICIO_SELECT);
            bool colocouWhere = false;

            if (vendedor != null)
            {
                if (!colocouWhere)
                {
                    cmd.Append(" WHERE ");
                    colocouWhere = true;
                }
                cmd.Append(" vendedorcod = ");
                cmd.Append(DbTransformar(vendedor.Código));
            }

            if (cliente != null)
            {
                if (!colocouWhere)
                {
                    cmd.Append(" WHERE ");
                    colocouWhere = true;
                }

                cmd.Append(" clientecod = ");
                cmd.Append(DbTransformar(cliente.Código));
            }

            if (final != DateTime.MaxValue)
            {
                // Faz restrição quanto a data
                cmd.Append(" AND data BETWEEN ");
                cmd.Append(DbTransformar(início));
                cmd.Append(" AND ");
                cmd.Append(DbTransformar(final.AddDays(1).Date));
            }

            return RecuperarDados(cmd.ToString());
        }

        /// <summary>
        /// Obtém vendas de um cliente/vendedor.
        /// </summary>
        /// <param name="vendedor">Verdadeiro indica que pessoa é o vendedor das vendas </param>
        /// <returns>Vendas para o cliente/de um vendedor.</returns>
        public static VendaSintetizada[] ObterVendas(bool vendedor, Entidades.Pessoa.Pessoa pessoa, DateTime início, DateTime final, bool somenteNãoAcertadas, bool? sedex)
        {
            StringBuilder consulta = new StringBuilder(INICIO_SELECT);

            consulta.Append(" JOIN venda vv ON v.codigo=vv.codigo ");
            consulta.Append(" WHERE 1=1 ");

            if (pessoa != null)
            {
                consulta.Append("AND ");
                consulta.Append(vendedor ? "vendedorcod = " : "clientecod = ");
                consulta.Append(DbTransformar(pessoa.Código));
            }

            if ((início != DateTime.MinValue) || (final != DateTime.MaxValue))
            {
                consulta.Append(" AND v.data BETWEEN ");
                consulta.Append(DbTransformar(início));
                consulta.Append(" AND ");
                consulta.Append(DbTransformar(final.AddDays(1).Date));
            }

            if (somenteNãoAcertadas)
            {
                consulta.Append(" AND vv.acerto in (select codigo from acertoconsignado where dataefetiva is null) ");
            }


            if (sedex.HasValue)
            {
                consulta.Append(" AND vv.sedex = ");
                consulta.Append(DbTransformar(sedex.Value));
            }

            return RecuperarDados(consulta.ToString());
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string ToString()
        {
            return "Venda " + (controle.HasValue ? controle.ToString() : Código.ToString() + " (cód. interno)");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IDadosVenda))
                return false;

            return ((IDadosVenda)obj).Código == this.Código;
        }

        public override int GetHashCode()
        {
            return código.GetHashCode();
        }

        public static  VendaSintetizada[] ObterVendasSemComissão()
        {
            string consulta = INICIO_SELECT +
                " left join comissaovenda c on v.codigo=c.venda " + 
                " left join comissao_saldo s on s.venda=v.codigo " + 
                " where c.venda is null or s.venda is null or s.saldo != 1";

            return RecuperarDados(consulta);
        }
    }
}
