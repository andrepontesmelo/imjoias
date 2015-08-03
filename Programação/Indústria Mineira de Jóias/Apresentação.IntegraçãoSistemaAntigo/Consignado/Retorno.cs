using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Consignado
{
    public class Retorno
    {
        public List<RetornoItem> itens;
        private long cliente;
        private long código;
        private DateTime data;

        public Retorno(long código, long cliente, DateTime data)
        {
            itens = new List<RetornoItem>();
            this.cliente = cliente;
            this.data = data;
            this.código = código;
        }

        public void Gravar(DataSet mysql)
        {
            DataRow novaSaída = mysql.Tables["retorno"].NewRow();

            novaSaída["codigo"] = código;
            novaSaída["pessoa"] = cliente;
            novaSaída["acertado"] = false;
            novaSaída["travado"] = false;
            novaSaída["data"] = data;
            novaSaída["digitadopor"] = 999;

            mysql.Tables["retorno"].Rows.Add(novaSaída);

            foreach (RetornoItem i in itens)
                i.Gravar(mysql);
        }

        private static Dictionary<long, bool> hashRetornos = null;

        public static bool ExisteRetorno(long código, DataSet mysql)
        {
            if (hashRetornos == null)
            {
                hashRetornos = new Dictionary<long, bool>();

                foreach (DataRow i in mysql.Tables["retorno"].Rows)
                    hashRetornos[long.Parse(i["codigo"].ToString())] = true;
            }

            return hashRetornos.ContainsKey(código);
        }
    }

    public class RetornoItem
    {
        string referência;
        double quantidade;
        double peso;
        double índice;
        long retorno;

        public RetornoItem(string referência, double qtd, double peso, double índice, long retorno)
        {
            this.referência = referência;
            this.quantidade = qtd;
            this.peso = peso;
            this.índice = índice;
            this.retorno = retorno;
        }

        public void Gravar(DataSet mysql)
        {
            DataRow novaRetornoItem = mysql.Tables["retornoitem"].NewRow();

            novaRetornoItem["retorno"] = retorno;
            novaRetornoItem["referencia"] = referência;
            novaRetornoItem["peso"] = peso;
            novaRetornoItem["quantidade"] = quantidade;
            novaRetornoItem["data"] = DateTime.Now;
            novaRetornoItem["funcionario"] = 999;
            novaRetornoItem["indice"] = índice;

            mysql.Tables["retornoitem"].Rows.Add(novaRetornoItem);
        }
    }
}
