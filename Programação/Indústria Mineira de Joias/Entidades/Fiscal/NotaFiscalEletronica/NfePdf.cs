using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class NfePdf : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        private long nfe;
        private byte[] pdf;

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
            {
                DeArquivo(pdf).Cadastrar();
            }
        }
    }
}
