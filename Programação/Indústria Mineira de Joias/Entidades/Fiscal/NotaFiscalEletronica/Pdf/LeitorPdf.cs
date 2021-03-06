﻿using Entidades.Fiscal.Exceções;
using Entidades.Fiscal.Importação;
using Entidades.Fiscal.Importação.Resultado;
using Entidades.Fiscal.NotaFiscalEletronica.Pdf;
using Entidades.Fiscal.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;

namespace Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf
{
    public class LeitorPdf
    {
        private string nomeArquivo;
        private int? nfe;
        private string id;

        public string NomeArquivo => nomeArquivo;
        public int? Nfe => nfe;
        public string Id => id;

        public byte[] Ler()
        {
            return File.ReadAllBytes(nomeArquivo);
        }

        private LeitorPdf(string nomeArquivo) : this(nomeArquivo, ExtrairNfe(nomeArquivo))
        {
        }

        public static int ExtrairNfe(string nomeArquivo)
        {
            nomeArquivo = Path.GetFileName(nomeArquivo).ToLower();

            int resultado;

            bool ok = int.TryParse(Regex.Match(nomeArquivo, @"\D[0-9]{6}\D").Groups[0].Value, out resultado)
                && Regex.Matches(nomeArquivo, @"\D[0-9]{6}\s[0-9]{6}\D").Count == 0
                && Regex.Matches(nomeArquivo, @"\D[0-9]{6}\D").Count == 1;

            if (!ok) 
                ok = int.TryParse(Regex.Match(nomeArquivo, @"^(\d{6})(.*)$").Groups[1].Value, out resultado);

            if (!ok)
                ok = int.TryParse(Regex.Match(nomeArquivo, @".*\D(\d{6}).pdf$").Groups[1].Value, out resultado);

            if (!ok)
                throw new NomeArquivoInválido(nomeArquivo);

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

        private LeitorPdf(string nomeArquivo, int nfe)
        {
            this.nomeArquivo = nomeArquivo;
            this.nfe = nfe;
        }

        internal static List<LeitorPdf> Interpretar(List<string> arquivos, ResultadoImportação resultado, BackgroundWorker thread)
        {
            List<LeitorPdf> lidos = new List<LeitorPdf>();

            foreach (string arquivo in arquivos)
            {
                Importador.AtualizarPorcentagem(thread, resultado, arquivos);
        
                LeitorPdf leitor = TentaLerArquivo(resultado, arquivo);

                if (leitor != null)
                    lidos.Add(leitor);
            }

            return lidos;
        }

        private static LeitorPdf TentaLerArquivo(ResultadoImportação resultado, string arquivo)
        {
            try
            {
                LeitorPdf leitor = new LeitorPdf(arquivo);

                leitor.id = MapaIdNfe.Instância.ObterId(leitor.Nfe.Value);

                if (leitor.id == null)
                {
                    resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.SaídaFiscalNãoCadastradaParaPdf));
                    return null;
                }

                if (SaidaFiscalPdf.Cache.Contém((leitor.id)))
                {
                    resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.ChaveJáImportada, leitor.id));
                    return null;
                }

                resultado.ArquivosSucesso.Adicionar(new Arquivo(leitor.ToString(), leitor.id));
                SaidaFiscalPdf.Cache.Adicionar(leitor.id);

                return leitor;
            }
            catch (Exception erro)
            {
                resultado.AdicionarFalha(arquivo, erro);
                return null;
            }
        }

        public override string ToString()
        {
            return string.Format("Nfe #{0} - {1}", Nfe, NomeArquivo);
        }
    }
}
