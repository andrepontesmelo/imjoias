using Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf;

namespace Entidades.Fiscal.Pdf
{
    public class EntradaFiscalPdf : FiscalPdf
    {
        private static CacheIds cacheIds = new CacheIds("entradafiscalpdf");

        public EntradaFiscalPdf(string id, byte[] pdf) : base(id, pdf)
        {
        }

        public EntradaFiscalPdf()
        {
        }

        public static CacheIds Cache => cacheIds;

        public static EntradaFiscalPdf Obter(string idEntradaFiscal)
        {
            string sql = string.Format("select * from entradafiscalpdf where id={0}", DbTransformar(idEntradaFiscal));
            return MapearÚnicaLinha<EntradaFiscalPdf>(sql);
        }

        public override void Descadastrar()
        {
            base.Descadastrar();
            Cache.Remover(Id);
            CacheVendaPdf.Instância.Recarregar();
        }

        public override void Cadastrar()
        {
            base.Cadastrar();
            Cache.Adicionar(Id);
        }
    }
}
