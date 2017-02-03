using Entidades.Fiscal.Importação.Resultado;
using Entidades.Fiscal.NotaFiscalEletronica;
using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using System.Collections.Generic;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorSaídaXMLAtacado : ImportadorNotaFiscal
    {
        public static readonly string DESCRIÇÃO = "Importação de XMLs de saída de atacado";
        public static readonly string PADRÂO_ARQUIVO = "*.xml";
        private Dictionary<uint, long> hashNfeVenda;

        public ImportadorSaídaXMLAtacado(Fechamento fechamento) : base(DESCRIÇÃO, PADRÂO_ARQUIVO, fechamento)
        {
            hashNfeVenda = VínculoNfeVenda.ObterHashNfeVenda();
        }

        protected override bool IgnorarDocumentoCNPJEmissor(ResultadoImportação resultado, string arquivo, DocumentoFiscal documento)
        {
            if (!documento.EmitidoPorEstaEmpresa)
            {
                ArquivoIgnorado ignorado = new ArquivoIgnorado(arquivo, Motivo.NotaEmitidaOutraEmpresa, documento.Id);
                resultado.ArquivosIgnorados.Adicionar(ignorado);

                return true;
            }

            return false;
        }

        protected override DocumentoFiscal Interpretar(string arquivo)
        {
            return new AdaptadorAtacadoSaída(new ParserXmlAtacado(arquivo), hashNfeVenda).Transformar();
        }

        protected override List<string> ObterIdsCadastrados()
        {
            return SaídaFiscal.ObterIds();
        }
    }
}
