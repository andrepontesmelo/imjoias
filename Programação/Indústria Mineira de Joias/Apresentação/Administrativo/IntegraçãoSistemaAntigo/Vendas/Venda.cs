using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Vendas
{
    public class Venda
    {
        public List<VendaItem> itens;
        private long cliente;
        private long vendedor;
        private long código;
        private DateTime data;
        private double cotação;

        public Venda(long código, long cliente, DateTime data, double cotação, long vendedor)
        {
            itens = new List<VendaItem>();
            this.cliente = cliente;
            this.data = data;
            this.código = código;
            this.cotação = cotação;
            this.vendedor = vendedor;
        }

        public void Gravar(DataSet mysql)
        {
            DataRow novaVenda = mysql.Tables["Venda"].NewRow();
            
            novaVenda["codigo"] = código;
            novaVenda["cotacao"] = cotação;
            //novaVenda["acertado"] = false;
            novaVenda["verificado"] = false;
            novaVenda["travado"] = false;
            novaVenda["data"] = data;
            novaVenda["cliente"] = cliente;
            novaVenda["digitadopor"] = 999;
            novaVenda["vendedor"] = vendedor;
            novaVenda["controle"] = DBNull.Value;
            novaVenda["desconto"] = 0;

            mysql.Tables["venda"].Rows.Add(novaVenda);

            foreach (VendaItem i in itens)
                i.Gravar(mysql);
        }

        private static Dictionary<long, DataRow> hashVendas = null;

        public static bool ExisteVenda(long código, DataSet mysql)
        {
            if (hashVendas == null)
            {
                hashVendas = new Dictionary<long, DataRow>();

                foreach (DataRow i in mysql.Tables["venda"].Rows)
                    hashVendas[long.Parse(i["codigo"].ToString())] = i;
            }

            return hashVendas.ContainsKey(código);
        }

        public static DataRow ObterVenda(long código)
        {
            return hashVendas[código];
        }
    }

    public class VendaItem
    {
        string referência;
        double quantidade;
        double peso;
        double índice;
        long venda;

        public VendaItem(string referência, double qtd, double peso, double índice, long venda)
        {
            this.referência = referência;
            this.quantidade = qtd;
            this.peso = peso;
            this.índice = índice;
            this.venda = venda;
        }

        public void Gravar(DataSet mysql)
        {
            DataRow novaVendaItem = mysql.Tables["vendaitem"].NewRow();

            novaVendaItem["venda"] = venda;
            novaVendaItem["referencia"] = referência;
            novaVendaItem["peso"] = peso;
            novaVendaItem["quantidade"] = quantidade;
            novaVendaItem["data"] = DateTime.Now;
            novaVendaItem["funcionario"] = 999;
            novaVendaItem["indice"] = índice;

            mysql.Tables["vendaitem"].Rows.Add(novaVendaItem);
        }
    }
}
