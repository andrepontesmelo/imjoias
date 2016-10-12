using Entidades.Fiscal.Tipo;

namespace Entidades.Fiscal
{
    public class SaídaItemFiscal : ItemFiscal
    {
        public SaídaItemFiscal(string referência, string descrição, int? cfop,
        TipoUnidade tipoUnidade, decimal quantidade, decimal valorUnitário,
        decimal valor) : base(referência, descrição, cfop, tipoUnidade, quantidade, valorUnitário, valor)
        {
        }

        protected override string Relação => "saidaitemfiscal";
        protected override string RelaçãoPai => "saidafiscal";
    }
}
