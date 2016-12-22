using Acesso.Comum;
using Entidades.Fiscal.Esquema;
using System.Collections.Generic;
using System.Data;
using System;

namespace Entidades.Fiscal.Fabricação
{
    [DbTabela("entradafabricacaofiscal")]
    public class EntradaFabricaçãoFiscal : ItemFabricaçãoFiscal
    {
        internal static readonly string RELAÇÃO = "entradafabricacaofiscal";

        internal static string ObterSqlInserçãoEntrada(int fabricação, string ingrediente, decimal qtd, decimal valor, int cfop)
        {
            return string.Format("INSERT INTO entradafabricacaofiscal (fabricacaofiscal, referencia, quantidade, valor, cfop) values ({0}, {1}, {2}, {3}, {4})",
                    DbTransformar(fabricação),
                    DbTransformar(ingrediente),
                    DbTransformar(qtd),
                    DbTransformar(valor),
                    DbTransformar(cfop));
        }

        public static List<ItemFabricaçãoFiscal> Obter(int fabricação)
        {
            return Mapear<ItemFabricaçãoFiscal>(string.Format("select codigo, referencia, quantidade, valor, cfop from " +
                " entradafabricacaofiscal where fabricacaofiscal={0}", DbTransformar(fabricação)));
        }

        public EntradaFabricaçãoFiscal()
        {
        }

        public static void Alterar(ItemFabricaçãoFiscal entidade)
        {
            var sql = string.Format("UPDATE entradafabricacaofiscal set referencia={0}, quantidade={1}, valor={2}, cfop={3} where codigo={4}",
            DbTransformar(entidade.Referência),
            DbTransformar(entidade.Quantidade),
            DbTransformar(entidade.Valor),
            DbTransformar(entidade.CFOP),
            DbTransformar(entidade.Código));

            ExecutarComando(sql);
        }

        public static void Excluir(ItemFabricaçãoFiscal entidade)
        {
            var sql = string.Format("DELETE FROM entradafabricacaofiscal where codigo={0}",
            DbTransformar(entidade.Código));

            ExecutarComando(sql);
        }

        public static void Excluir(List<ItemFabricaçãoFiscal> lista)
        {
            foreach (var entidade in lista)
                Excluir(entidade);
        }
    }
}
