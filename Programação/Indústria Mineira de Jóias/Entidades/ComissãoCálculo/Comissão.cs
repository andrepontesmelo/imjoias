using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using Entidades.Pessoa.Endereço;
using Entidades.ComissãoCálculo.Impressão;

namespace Entidades.ComissãoCálculo
{
    /// <summary>
    /// Documento de comissão, de várias pessoas, geralmente de um mês.
    /// </summary>
    [DbTabela("comissao")]
    public class Comissão : DbManipulaçãoAutomática
    {
#pragma warning disable 0649
        [DbChavePrimária(true)]
        private int codigo;

        [DbColuna("descricao")]
        private String descrição;

        [DbColuna("mes")]
        private DateTime mês;
        private bool pago;

#pragma warning restore 0649

        public Comissão() { }

        public Comissão(String descrição, DateTime mês, bool pago)
        {
            this.descrição = descrição;
            this.mês = mês;
            this.pago = pago;
        }

        public int Código
        {
            get { return codigo; }
        }

        public String Descrição
        {
            get { return descrição; }
            set { descrição = value; DefinirDesatualizado(); }
        }

        public DateTime MêsReferência
        {
            get { return mês;  }
            set { mês = value; DefinirDesatualizado(); }
        }

        public bool Pago
        {
            get { return pago;  }
            set { pago = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Obtém todas as comissões do sistema
        /// </summary>
        /// <returns></returns>
        public static List<Comissão> ObterComissões()
        {
            return Mapear<Comissão>("select c.* from comissao c order by mes desc");
        }

        public int FecharLançamentos(List<ComissãoValor> selecionados, bool estorno)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    StringBuilder str = new StringBuilder(" INSERT into comissao");

                    if (estorno)
                        str.Append("estorno");

                    str.Append("venda (comissao,venda,pessoa) values ");
                    bool primeiro = true;
                    foreach (ComissãoValor cv in selecionados)
                    {
                        if (!primeiro)
                            str.Append(",");

                        str.Append("(");
                        str.Append(DbTransformar(Código));
                        str.Append(",");
                        str.Append(DbTransformar(cv.Venda));
                        str.Append(",");
                        str.Append(DbTransformar(cv.ComissãoPara.Código));
                        str.Append(")");

                        primeiro = false;
                    }

                    cmd.CommandText = str.ToString();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int AbrirLançamentos(List<ComissãoValor> selecionados, bool estorno)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    StringBuilder str = new StringBuilder(" DELETE from comissao");

                    if (estorno)
                        str.Append("estorno");

                    str.Append("venda WHERE ");
                    str.Append("comissao=");
                    str.Append(DbTransformar(Código));
                    str.Append(" AND (");
                    bool primeiro = true;
                    foreach (ComissãoValor cv in selecionados)
                    {
                        if (!primeiro)
                            str.Append(" OR ");
   
                        str.Append("(venda=");
                        str.Append(DbTransformar(cv.Venda));
                        str.Append(" and pessoa=");
                        str.Append(DbTransformar(cv.ComissãoPara.Código));
                        str.Append(")");

                        primeiro = false;
                    }
                    str.Append(")");
                    cmd.CommandText = str.ToString();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Impressão.ImpressãoComissãoVenda> ObterImpressãoVenda()
        {
            return Impressão.ImpressãoComissãoVenda.Obter(this);
        }

        public List<Impressão.ImpressãoComissãoVendaItem> ObterImpressãoVendaItem()
        {
            return Impressão.ImpressãoComissãoVendaItem.Obter(this);
        }

        public List<Impressão.ImpressãoResumo> ObterImpressãoResumo(Filtro filtro)
        {
            return Impressão.ImpressãoResumo.Obter(this, filtro);
        }

        public List<Impressão.ImpressãoRegraPessoa> ObterImpressãoRegraPessoa()
        {
            return Impressão.ImpressãoRegraPessoa.Obter(this); 
        }

        public List<Impressão.ImpressãoCompartilhada> ObterImpressãoCompartilhada()
        {
            return Impressão.ImpressãoCompartilhada.Obter(this);
        }

        public List<Impressão.ImpressãoSetor> ObterImpressãoSetor(Filtro filtro)
        {
            return Impressão.ImpressãoSetor.Obter(this, filtro);
        }

        public static bool ComissãoFechada(long venda)
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = " select saldo from comissao_saldo where venda=" + DbTransformar(venda);

                    object objeto = cmd.ExecuteScalar();

                    if (objeto == null)
                        return false;

                    long saldo = (long )objeto;

                    return saldo == 1;
            }
        }
    }
}
