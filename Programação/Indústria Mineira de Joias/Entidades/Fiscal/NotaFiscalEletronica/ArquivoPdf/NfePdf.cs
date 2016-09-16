using Acesso.Comum;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf
{
    public class NfePdf : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        private long nfe;
        private byte[] pdf;

        public NfePdf()
        {
        }

        public NfePdf(LeitorPdf arquivo)
        {
            arquivo.AssegurarCódigoExistente();

            nfe = arquivo.Nfe.Value;

            pdf = arquivo.Ler();
        }

        public long Nfe => nfe;
        public byte[] Pdf => pdf;

        private static List<long> códigos = null;

        public static List<long> ObterNfes()
        {
            if (códigos == null)
                códigos = MapearCódigos("select nfe from nfepdf");

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

        public static NfePdf DeArquivo(LeitorPdf arquivo)
        {
            return new NfePdf(arquivo);
        }

        internal static void Cadastrar(List<LeitorPdf> pdfs, BackgroundWorker thread)
        {
            int x = 0;

            foreach (LeitorPdf pdf in pdfs)
            {
                DeArquivo(pdf).Cadastrar();
                thread.ReportProgress(100 * ++x / pdfs.Count, string.Format("Cadastrando {0} pdfs no banco de dados", pdfs.Count));
            }
        }

        public static NfePdf Obter(long venda)
        {
            string sql = string.Format("select * from nfepdf where nfe=(select nfe from nfe where venda={0})", DbTransformar(venda));
            return MapearÚnicaLinha<NfePdf>(sql);
        }
    }
}
