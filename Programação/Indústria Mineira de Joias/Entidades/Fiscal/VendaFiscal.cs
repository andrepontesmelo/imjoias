using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class VendaFiscal : DbManipulaçãoSimples
    {
        private DateTime dataEmissão;
        private TipoVenda tipoVenda;
        private string id;
        private decimal valorTotal;

        private List<VendaItemFiscal> itens;

        public VendaFiscal()
        {
        }

        public VendaFiscal(TipoVenda tipoVenda, DateTime dataEmissão, string id, 
            decimal valorTotal, List<VendaItemFiscal> itens)
        {
            this.tipoVenda = tipoVenda;
            this.dataEmissão = dataEmissão;
            this.id = id;
            this.valorTotal = valorTotal;
            this.itens = itens;
        }

        internal static List<string> ObterIdsCadastrados()
        {
            return MapearStrings("select id from vendafiscal");
        }

        public TipoVenda TipoVenda => tipoVenda;
        public DateTime DataEmissão => dataEmissão;
        public string Id => id;
        public List<VendaItemFiscal> Itens => itens;
        public decimal ValorTotal => valorTotal;

        public void Cadastrar()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbTransaction transação = conexão.BeginTransaction())
                {
                    CadastrarEntidade(transação, conexão);
                    VendaItemFiscal.CadastrarItens(id, itens, transação, conexão);

                    transação.Commit();
                }
            }
        }

        private void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO vendafiscal (dataemissao, tipovenda, id, valortotal) values ({0}, {1}, {2}, {3})",
                    DbTransformar(dataEmissão),
                    DbTransformar(((char) tipoVenda).ToString()),
                    DbTransformar(id),
                    DbTransformar(ValorTotal));

                cmd.ExecuteNonQuery();
            }
        }
    }
}
