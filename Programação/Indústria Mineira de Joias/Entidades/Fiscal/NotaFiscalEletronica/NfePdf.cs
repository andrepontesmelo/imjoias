using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class NfePdf : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        private long nfe;
        private byte[] pdf;

        public NfePdf()
        {
        }

        public NfePdf(Pdf arquivo)
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

        public static void LimparCache()
        {
            códigos = null;
        }

        public static NfePdf DeArquivo(Pdf arquivo)
        {
            return new NfePdf(arquivo);
        }

        internal static void Cadastrar(List<Pdf> pdfsFiltrados)
        {
            foreach (Pdf pdf in pdfsFiltrados)
                DeArquivo(pdf).Cadastrar();
        }

        public static NfePdf Obter(long venda)
        {
            string sql = string.Format("select * from nfepdf where nfe=(select nfe from nfe where venda={0})", DbTransformar(venda));
            return MapearÚnicaLinha<NfePdf>(sql);
        }
    }
}
