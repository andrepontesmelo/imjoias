using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class Pdf
    {
        private string nomeArquivo;
        private int? nfe;

        public string NomeArquivo => nomeArquivo;
        public int? Nfe => nfe;

        public byte[] Ler()
        {
            return File.ReadAllBytes(nomeArquivo);
        }

        private Pdf(string nomeArquivo) : this(nomeArquivo, ExtrairNfe(nomeArquivo))
        {
        }

        public static int ExtrairNfe(string nomeArquivo)
        {
            nomeArquivo = Path.GetFileName(nomeArquivo).ToLower();

            int resultado;

            bool ok = int.TryParse(Regex.Match(nomeArquivo, @"^(.*)\D(\d{6})\D(.*)").Groups[2].Value, out resultado)
                && Regex.Matches(nomeArquivo, @"(\d{6}) ").Count == 1;

            if (!ok) 
                ok = int.TryParse(Regex.Match(nomeArquivo, @"^(\d{6})(.*)$").Groups[1].Value, out resultado);

            if (!ok)
                ok = int.TryParse(Regex.Match(nomeArquivo, @".*\D(\d{6}).pdf$").Groups[1].Value, out resultado);

            if (!ok)
                throw new ExcessãoNãoPodeExtrairNfeNomeArquivo(nomeArquivo);

            return resultado;
        }

        internal void AssegurarCódigoExistente()
        {
            if (!nfe.HasValue || nfe.Value.Equals(0))
                throw new NullReferenceException("Código não existente para pdf");
        }

        internal bool MesmoCódigo(int? outroNfe)
        {
            return nfe.HasValue && outroNfe.HasValue && nfe.Value.Equals(outroNfe.Value);
        }

        private Pdf(string nomeArquivo, int nfe)
        {
            this.nomeArquivo = nomeArquivo;
            this.nfe = nfe;
        }

        internal static List<Pdf> Interpretar(List<string> arquivos, out List<ExcessãoNãoPodeExtrairNfeNomeArquivo> erros)
        {
            List<Pdf> lista = new List<Pdf>();
            erros = new List<ExcessãoNãoPodeExtrairNfeNomeArquivo>();

            foreach (string arquivo in arquivos)
            {
                try
                {
                    lista.Add(new Pdf(arquivo));
                } catch (ExcessãoNãoPodeExtrairNfeNomeArquivo erro)
                {
                    erros.Add(erro);
                }
            }

            return lista;
        }

        public override string ToString()
        {
            return string.Format("Nfe #{0}", Nfe);
        }
    }
}
