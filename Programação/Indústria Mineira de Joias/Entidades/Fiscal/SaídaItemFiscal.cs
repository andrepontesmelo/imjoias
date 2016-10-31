using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class SaídaItemFiscal : ItemFiscal
    {
        private const string RELAÇÃO = "saidaitemfiscal";
        private const string RELAÇÃO_PAI = "saidafiscal";

        [DbColuna("saidafiscal")]
        private string saidaFiscal;

        public SaídaItemFiscal(string referência, string descrição, int? cfop,
        TipoUnidade tipoUnidade, decimal quantidade, decimal valorUnitário,
        decimal valor) : base(referência, descrição, cfop, tipoUnidade, quantidade, valorUnitário, valor)
        {
        }

        public SaídaItemFiscal()
        {
        }

        protected override string Relação => RELAÇÃO;
        protected override string RelaçãoPai => RELAÇÃO_PAI;

        internal static List<SaídaItemFiscal> CarregarItens(string id)
        {
            return Mapear<SaídaItemFiscal>(string.Format("select * from {0} where {1}={2} ", 
                RELAÇÃO, RELAÇÃO_PAI,
                DbTransformar(id)));
        }
    }
}
