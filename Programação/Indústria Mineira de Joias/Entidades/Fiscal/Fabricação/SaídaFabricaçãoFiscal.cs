using Acesso.Comum;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Fabricação
{
    [DbTabela("saidafabricacaofiscal")]
    public class SaídaFabricaçãoFiscal : ItemFabricaçãoFiscal
    {
        internal static readonly string RELAÇÃO = "saidafabricacaofiscal";
        private decimal peso;

        public decimal Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        internal static string ObterSqlInserçãoSaída(FabricaçãoFiscal fabricação, decimal qtdReceitas, string referência, decimal quantidade, decimal valor, int cfop, decimal peso)
        {
            return string.Format("INSERT INTO saidafabricacaofiscal (fabricacaofiscal, referencia, quantidade, valor, cfop, peso) values ({0}, {1}, {2}, {3}, {4}, {5})",
                DbTransformar(fabricação.Código),
                DbTransformar(referência),
                DbTransformar(quantidade),
                DbTransformar(valor),
                DbTransformar(cfop),
                DbTransformar(peso));
        }

        public SaídaFabricaçãoFiscal(ItemFabricaçãoFiscal item, decimal peso)
        {
            this.referencia = item.Referência;
            this.quantidade = item.Quantidade;
            this.valor = item.Valor;
            this.cfop = item.CFOP;
            this.peso = peso;
        }

        public SaídaFabricaçãoFiscal(string referência, decimal quantidade, decimal valor, int cfop, decimal peso) :
            base(referência, quantidade, valor, cfop)
        {
            this.peso = peso;
        }

        public SaídaFabricaçãoFiscal()
        {
        }

        public static List<SaídaFabricaçãoFiscal> Obter(int fabricação)
        {
            return Mapear<SaídaFabricaçãoFiscal>(string.Format("select codigo, referencia, quantidade, valor, cfop, peso from " +
                " saidafabricacaofiscal where fabricacaofiscal={0}", DbTransformar(fabricação)));
        }

        
        public static void Alterar(SaídaFabricaçãoFiscal entidade)
        {
            var sql = string.Format("UPDATE saidafabricacaofiscal set referencia={0}, quantidade={1}, valor={2}, cfop={3}, peso={4} where codigo={5}",
            DbTransformar(entidade.Referência),
            DbTransformar(entidade.Quantidade),
            DbTransformar(entidade.Valor),
            DbTransformar(entidade.CFOP),
            DbTransformar(entidade.Peso),
            DbTransformar(entidade.Código));

            ExecutarComando(sql);
        }

        public static void Excluir(ItemFabricaçãoFiscal entidade)
        {
            var sql = string.Format("DELETE FROM saidafabricacaofiscal where codigo={0}",
            DbTransformar(entidade.Código));

            ExecutarComando(sql);
        }
    }
}
