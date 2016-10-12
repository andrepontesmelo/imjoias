using Entidades.Fiscal.Tipo;

namespace Entidades.Fiscal
{
    public class EntradaItemFiscal : ItemFiscal
    {
        public EntradaItemFiscal(string referência, string descrição, int? cfop,
        TipoUnidade tipoUnidade, decimal quantidade, decimal valorUnitário,
        decimal valor) : base(referência, descrição, cfop, tipoUnidade, quantidade, valorUnitário, valor)
        {
        }

        protected override string Relação => "entradaitemfiscal";
        protected override string RelaçãoPai => "entradafiscal";
    }
}
