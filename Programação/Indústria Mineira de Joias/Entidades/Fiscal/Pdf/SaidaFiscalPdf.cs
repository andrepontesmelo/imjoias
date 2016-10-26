using Acesso.Comum;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using Entidades.Fiscal.NotaFiscalEletronica.Pdf;
using Entidades.Fiscal.Importação.Resultado;

namespace Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf
{
    public class SaidaFiscalPdf : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        private string id;
        private byte[] pdf;

        public SaidaFiscalPdf()
        {
        }

        public SaidaFiscalPdf(string id, byte[] pdf)
        {
            this.id = id;
            this.pdf = pdf;
        }

        public string Id => id;
        public byte[] Pdf => pdf;

        private static List<string> códigos = null;

        public static List<string> ObterIdsCadastrados()
        {
            if (códigos == null)
                códigos = MapearStrings("select id from saidafiscalpdf");

            return códigos;
        }

        internal static void CadastrarLimpandoCache(List<LeitorPdf> pdfs, BackgroundWorker thread)
        {
            LimparCache();
            Cadastrar(pdfs, thread);
            CacheVendaPdf.Instância.Recarregar();
        }

        public static void LimparCache()
        {
            códigos = null;
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
        
        public static SaidaFiscalPdf Obter(long venda)
        {
            string sql = string.Format("select * from saidafiscalpdf where id=(select id from saidafiscal where numero =(select nfe from nfe where venda={0}))", DbTransformar(venda));
            return MapearÚnicaLinha<SaidaFiscalPdf>(sql);
        }
    }
}
