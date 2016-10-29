using Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Entidades.Fiscal.Pdf
{
    public class SaidaFiscalPdf : FiscalPdf
    {
        private static CacheIds cacheIds = new CacheIds("saidafiscalpdf");

        public static CacheIds Cache => cacheIds;

        public SaidaFiscalPdf(string id, byte[] pdf) : base(id, pdf)
        {
        }

        public SaidaFiscalPdf()
        {
        }

        internal static void Cadastrar(List<LeitorPdf> pdfs, BackgroundWorker thread)
        {
            int x = 0;

            foreach (LeitorPdf pdf in pdfs)
            {
                new SaidaFiscalPdf(pdf.Id, pdf.Ler()).Cadastrar();
                thread.ReportProgress(100 * ++x / pdfs.Count, string.Format("Cadastrando {0} pdfs no banco de dados", pdfs.Count));
            }
        }

        internal static void CadastrarLimpandoCache(List<LeitorPdf> pdfs, BackgroundWorker thread)
        {
            cacheIds.LimparCache();
            Cadastrar(pdfs, thread);
            CacheVendaPdf.Instância.Recarregar();
        }

        public static SaidaFiscalPdf Obter(long venda)
        {
            string sql = string.Format("select * from saidafiscalpdf where id=(select id from saidafiscal where numero =(select nfe from nfe where venda={0}))", DbTransformar(venda));
            return MapearÚnicaLinha<SaidaFiscalPdf>(sql);
        }

        public static SaidaFiscalPdf Obter(string idSaidaFiscal)
        {
            string sql = string.Format("select * from saidafiscalpdf where id={0}", DbTransformar(idSaidaFiscal));
            return MapearÚnicaLinha<SaidaFiscalPdf>(sql);
        }

        public override void Descadastrar()
        {
            base.Descadastrar();
            Cache.Remover(Id);
        }
    }
}
