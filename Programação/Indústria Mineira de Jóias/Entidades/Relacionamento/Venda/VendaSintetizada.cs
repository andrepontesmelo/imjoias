using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Acesso.Comum;

namespace Entidades.Relacionamento.Venda
{
    /// <summary>
    /// Serve apenas para exibi��o de dados na apresenta��o.
    /// Tem o poder de obter dados do banco de dados rapidamente
    /// E disponibiliza-los para exibi��o
    /// </summary>
    public class VendaSintetizada : DbManipula��o, IDadosVenda
    {
        private static readonly string INICIO_SELECT = "SELECT v.codigo, v.controle, v.valortotal, v.nome, v.cliente, v.data, v.taxajuros, v.cotacao, e.semaforo from vendasintetizada v join comissao_semaforo e on v.codigo=e.venda ";

        private long c�digo;
        private string nomeCliente;
        private string nomeVendedor;
        private double valorTotal;
        private uint? controle;
        private DateTime data;
        private double taxaJuros;
        private double cota��o;

        private SemaforoEnum sem�foro;

        public SemaforoEnum Sem�foro
        {
            get { return sem�foro; }
            set { sem�foro = value; }
        }

        public double Cota��o
        {
            get { return cota��o; }
            set { cota��o = value; }
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

        public long C�digo
        {
            get { return c�digo; }
            set { c�digo = value; }
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

        
        public static VendaSintetizada[] ObterVendas(List<long> c�digos)
        {
            if (c�digos.Count == 0) return (VendaSintetizada[])new ArrayList().ToArray(typeof(VendaSintetizada));

            bool primeiro = true;
            StringBuilder consulta = new StringBuilder(INICIO_SELECT);
            consulta.Append(" WHERE ");

            foreach (long cod in c�digos)
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

        private enum Ordem { C�digo, Controle, ValorTotal, NomeVendedor, NomeCliente, Data, TaxaJuros, Cota��o, Semaforo }

        private static VendaSintetizada[] RecuperarDados(string consulta)
        {
            ArrayList vendas = new ArrayList();

            IDbConnection conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                IDataReader leitor = null;
                cmd.CommandTimeout = 30;
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
                                VendaSintetizada nova = new VendaSintetizada();
                                nova.c�digo = leitor.GetInt64((int)Ordem.C�digo);

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
                                nova.Cota��o = leitor.GetDouble((int)Ordem.Cota��o);

                                int semaforo = leitor.GetInt16((int)Ordem.Semaforo);
                                nova.Sem�foro = (SemaforoEnum) Enum.ToObject(typeof(SemaforoEnum), semaforo);

                                vendas.Add(nova);
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

            return (VendaSintetizada[])vendas.ToArray(typeof(VendaSintetizada));

        }


        /// <summary>
        /// Retorna as todas as vendas independente do cliente ou vendedor.
        /// </summary>
        public static VendaSintetizada[] ObterVendas(DateTime in�cio, DateTime final, bool somenteN�oAcertadas, bool? sedex)
        {
            return ObterVendas(false, null, in�cio, final, somenteN�oAcertadas, sedex);
        }

        /// <summary>
        /// Obtem vendas relacionadas a esta venda por pagamento.
        /// � olhado o conjunto de pagamentos desta venda.
        /// � retornado o conjunto de vendas relacionados 
        /// a este grupo de pagamentos
        /// </summary>
        /// <returns></returns>
        public static VendaSintetizada[] ObterVendasRelacionadasPorPagamento(long c�digo)
        {
            
            StringBuilder consulta = new StringBuilder(INICIO_SELECT);
            consulta.Append(", vinculovendapagamento vinc where ");
            consulta.Append(" v.codigo != ");
            consulta.Append(DbTransformar(c�digo));
            consulta.Append(" AND vinc.venda=v.codigo ");
            consulta.Append(" AND pagamento in ");
            consulta.Append(" (select pagamento from vinculovendapagamento where venda= ");
            consulta.Append(c�digo.ToString());
            consulta.Append(") group by venda ");

            return RecuperarDados(consulta.ToString());
        }

              /// <summary>
        /// Obt�m vendas de um cliente/vendedor.
        /// </summary>
        /// <remarks>
        /// S� funciona para cliente e vendedor n�o nulos
        /// </remarks>
        /// <returns>Vendas para o cliente/de um vendedor.</returns>
        public static VendaSintetizada[] ObterVendas(Entidades.Pessoa.Pessoa vendedor, Entidades.Pessoa.Pessoa cliente, DateTime in�cio, DateTime final)
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
                cmd.Append(DbTransformar(vendedor.C�digo));
            }

            if (cliente != null)
            {
                if (!colocouWhere)
                {
                    cmd.Append(" WHERE ");
                    colocouWhere = true;
                }

                cmd.Append(" clientecod = ");
                cmd.Append(DbTransformar(cliente.C�digo));
            }

            if (final != DateTime.MaxValue)
            {
                // Faz restri��o quanto a data
                cmd.Append(" AND data BETWEEN ");
                cmd.Append(DbTransformar(in�cio));
                cmd.Append(" AND ");
                cmd.Append(DbTransformar(final.AddDays(1).Date));
            }

            return RecuperarDados(cmd.ToString());
        }

        /// <summary>
        /// Obt�m vendas de um cliente/vendedor.
        /// </summary>
        /// <param name="vendedor">Verdadeiro indica que pessoa � o vendedor das vendas </param>
        /// <returns>Vendas para o cliente/de um vendedor.</returns>
        public static VendaSintetizada[] ObterVendas(bool vendedor, Entidades.Pessoa.Pessoa pessoa, DateTime in�cio, DateTime final, bool somenteN�oAcertadas, bool? sedex)
        {
            StringBuilder consulta = new StringBuilder(INICIO_SELECT);

            consulta.Append(" JOIN venda vv ON v.codigo=vv.codigo ");
            consulta.Append(" WHERE 1=1 ");

            if (pessoa != null)
            {
                consulta.Append("AND ");
                consulta.Append(vendedor ? "vendedorcod = " : "clientecod = ");
                consulta.Append(DbTransformar(pessoa.C�digo));
            }

            if ((in�cio != DateTime.MinValue) || (final != DateTime.MaxValue))
            {
                consulta.Append(" AND v.data BETWEEN ");
                consulta.Append(DbTransformar(in�cio));
                consulta.Append(" AND ");
                consulta.Append(DbTransformar(final.AddDays(1).Date));
            }

            if (somenteN�oAcertadas)
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
            return "Venda " + (controle.HasValue ? controle.ToString() : C�digo.ToString() + " (c�d. interno)");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IDadosVenda))
                return false;

            return ((IDadosVenda)obj).C�digo == this.C�digo;
        }

        public override int GetHashCode()
        {
            return c�digo.GetHashCode();
        }

        public static  VendaSintetizada[] ObterVendasSemComiss�o()
        {
            string consulta = INICIO_SELECT +
                " left join comissaovenda c on v.codigo=c.venda " + 
                " left join comissao_saldo s on s.venda=v.codigo " + 
                " where c.venda is null or s.venda is null or s.saldo != 1";

            return RecuperarDados(consulta);
        }
    }
}
