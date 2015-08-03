using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Acerto;
using System.Data;
using Entidades.Balanço;

namespace Entidades.Relacionamento.Venda
{
    public class Sedex : Venda
    {
        public static void ObterAcertoSedex(List<long> documentos, Dictionary<string, Balanço.SaquinhoBalanço> hash)
        {
            string consulta;

            if (documentos.Count != 0)
            {
                consulta =
                    "select vendaitem.referencia, mercadoria.digito, vendaitem.peso, sum(quantidade), vendaitem.indice as qtd from vendaitem, venda, "
                    + " mercadoria where venda.codigo = vendaitem.venda AND venda.codigo IN "
                    + DbTransformarConjunto(documentos);
                consulta += " AND mercadoria.referencia = vendaitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash);
            }

            return;
        }
                
        public static new void ObterAcerto(List<long> documentos, Dictionary<string, Balanço.SaquinhoBalanço> hash)
        {
            string consulta;

            if (documentos.Count != 0)
            {
                consulta =
                    "select vendaitem.referencia, mercadoria.digito, vendaitem.peso, sum(quantidade), vendaitem.indice as qtd from vendaitem, venda, "
                    + " mercadoria where venda.codigo = vendaitem.venda AND venda.codigo IN "
                    + DbTransformarConjunto(documentos);
                consulta += " AND mercadoria.referencia = vendaitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash);
            }

            return;
        }

        private static void ObterAcerto(string consulta, Dictionary<string, Balanço.SaquinhoBalanço> hash)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conexão)
                {
                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string referência = leitor.GetString((int)OrdemAcerto.Referência);
                                byte dígito = leitor.GetByte((int)OrdemAcerto.Dígito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double índice = leitor.GetDouble((int)OrdemAcerto.Índice);

                                //SaquinhoAcerto itemNovo = new SaquinhoAcerto(new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);
                                SaquinhoBalanço itemNovo = new SaquinhoBalanço(new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);

                                // Item a ser utilizado
                                SaquinhoBalanço item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(referência, dígito, peso, null);
                                bool itemJáExistente = hash.TryGetValue(itemNovo.IdentificaçãoAgrupável(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJáExistente)
                                    item = itemNovo;

                                item.QtdSedex += qtd;

                                if (!itemJáExistente)
                                    hash.Add(item.IdentificaçãoAgrupável(), item);
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
    }
}
