using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Consignado
{
    public class Saida
    {
        public List<SaidaItem> itens;
        private long cliente;
        private long código;
        private DateTime data;


        public Saida(long código, long cliente, DateTime data)
        {
            itens = new List<SaidaItem>();
            this.cliente = cliente;
            this.data = data;
            this.código = código;
        }

        public void Gravar(DataSet mysql)
        {
            DataRow novaSaída = mysql.Tables["saida"].NewRow();
            
            novaSaída["codigo"] = código;
            novaSaída["pessoa"] = cliente;
            novaSaída["acertado"] = false;
            novaSaída["travado"] = false;
            novaSaída["data"] = data;
            novaSaída["digitadopor"] = 999;

            mysql.Tables["saida"].Rows.Add(novaSaída);

            foreach (SaidaItem i in itens)
                i.Gravar(mysql);
        }

        private static Dictionary<long, bool> hashSaídas = null;

        public static bool ExisteSaída(long código, DataSet mysql)
        {
            if (hashSaídas == null)
            {
                hashSaídas = new Dictionary<long, bool>();

                foreach (DataRow i in mysql.Tables["saida"].Rows)
                {
                    hashSaídas[long.Parse(i["codigo"].ToString())] = true;
                }
            }

            return hashSaídas.ContainsKey(código);
        }
    }

    public class SaidaItem
    {
        string referência;
        double quantidade;
        double peso;
        double índice;
        long saída;

        public SaidaItem(string referência, double qtd, double peso, double índice, long saída)
        {
            this.referência = referência;
            this.quantidade = qtd;
            this.peso = peso;
            this.índice = índice;
            this.saída = saída;
        }

        public void Gravar(DataSet mysql)
        {
            DataRow novaSaídaItem = mysql.Tables["saidaitem"].NewRow();

            novaSaídaItem["saida"] = saída;
            novaSaídaItem["referencia"] = referência;
            novaSaídaItem["peso"] = peso;
            novaSaídaItem["quantidade"] = quantidade;
            novaSaídaItem["data"] = DateTime.Now;
            novaSaídaItem["funcionario"] = 999;
            novaSaídaItem["indice"] = índice;

            mysql.Tables["saidaitem"].Rows.Add(novaSaídaItem);
        }
    }
}
