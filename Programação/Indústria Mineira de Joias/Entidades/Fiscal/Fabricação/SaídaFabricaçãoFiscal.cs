using Acesso.Comum;
using System.Collections.Generic;
using System;
using System.Text;

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

        public decimal PesoTotal => Peso * Quantidade;

        private static decimal CalcularQuantidadePeso(string referência, decimal quantidade, decimal peso)
        {
            bool depeso = Entidades.Mercadoria.Mercadoria.ConferirSeÉDePeso(referência);

            if (depeso)
                return quantidade * peso;
            else
                return quantidade;
        }

        internal static string ObterSqlInserçãoSaída(FabricaçãoFiscal fabricação, string referência, decimal quantidade, decimal valor, int cfop, decimal peso)
        {
            return string.Format("INSERT INTO saidafabricacaofiscal (fabricacaofiscal, referencia, quantidade, valor, cfop, peso, quantidadepeso) values ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                DbTransformar(fabricação.Código),
                DbTransformar(referência),
                DbTransformar(quantidade),
                DbTransformar(valor),
                DbTransformar(cfop),
                DbTransformar(peso),
                DbTransformar(CalcularQuantidadePeso(referência, quantidade, peso)));
        }

        internal static void AdicionarSqlInserçãoSaída(StringBuilder str, FabricaçãoFiscal fabricação, string referência, decimal quantidade, decimal valor, int cfop, decimal peso)
        {
            str.Append(string.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                DbTransformar(fabricação.Código),
                DbTransformar(referência),
                DbTransformar(quantidade),
                DbTransformar(valor),
                DbTransformar(cfop),
                DbTransformar(peso),
                DbTransformar(CalcularQuantidadePeso(referência, quantidade, peso))));
        }

        internal static StringBuilder ObterCabeçalhoSqlInserçãoSaída()
        {
            return new StringBuilder("INSERT INTO saidafabricacaofiscal (fabricacaofiscal, referencia, quantidade, valor, cfop, peso, quantidadepeso) values ");
        }

        public SaídaFabricaçãoFiscal(ItemFabricaçãoFiscal item, decimal peso)
        {
            this.codigo = item.Código;
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
            var sql = string.Format("UPDATE saidafabricacaofiscal set referencia={0}, quantidade={1}, valor={2}, cfop={3}, peso={4}, quantidadepeso={5} where codigo={6}",
            DbTransformar(entidade.Referência),
            DbTransformar(entidade.Quantidade),
            DbTransformar(entidade.Valor),
            DbTransformar(entidade.CFOP),
            DbTransformar(entidade.Peso),
            DbTransformar(CalcularQuantidadePeso(entidade.Referência, entidade.Quantidade, entidade.Peso)),
            DbTransformar(entidade.Código));
            ExecutarComando(sql);
        }

        public static void Excluir(ItemFabricaçãoFiscal entidade)
        {
            var sql = string.Format("DELETE FROM saidafabricacaofiscal where codigo={0}",
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
