using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class EntradaItemFiscal : ItemFiscal
    {
        private const string RELAÇÃO = "entradaitemfiscal";
        private const string RELAÇÃO_PAI = "entradafiscal";

        [DbColuna("entradafiscal")]
        private string entradaFiscal;

        public EntradaItemFiscal(string referência, string descrição, int? cfop,
        TipoUnidade tipoUnidade, decimal quantidade, decimal valorUnitário,
        decimal valor) : base(referência, descrição, cfop, tipoUnidade, quantidade, valorUnitário, valor)
        {
        }

        public EntradaItemFiscal()
        {
        }

        protected override string Relação => RELAÇÃO;
        protected override string RelaçãoPai => RELAÇÃO_PAI;

        internal static List<EntradaItemFiscal> CarregarItens(string id)
        {
            return Mapear<EntradaItemFiscal>(string.Format("select * from {0} where {1}={2} ",
                RELAÇÃO, RELAÇÃO_PAI,
                DbTransformar(id)));
        }
    }
}
