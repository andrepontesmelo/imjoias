using Entidades.Fiscal.Importação.Resultado;
using Entidades.Fiscal.NotaFiscalEletronica;
using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using System.Collections.Generic;

namespace Entidades.Fiscal.Importação
{
    public class ImportadorEntradaXMLAtacado : ImportadorNotaFiscal
    {
        public static readonly string DESCRIÇÃO = "Importação de XMLs de entrada de atacado";
        public static readonly string PADRÂO_ARQUIVO = "*.xml";

        public ImportadorEntradaXMLAtacado() : base(DESCRIÇÃO, PADRÂO_ARQUIVO)
        {
        }

        protected override bool IgnorarDocumentoCNPJEmissor(ResultadoImportação resultado, string arquivo, DocumentoFiscal documento)
        {
            if (documento.EmitidoPorEstaEmpresa)
            {
                resultado.ArquivosIgnorados.Adicionar(new ArquivoIgnorado(arquivo, Motivo.NotaEmitidaOutraEmpresa, documento.Id));
                return true;
            }

            return false;
        }

        protected override DocumentoFiscal Interpretar(string arquivo)
        {
            return new AdaptadorAtacadoEntrada(new ParserXmlAtacado(arquivo)).Transformar();
        }

        protected override List<string> ObterIdsCadastrados()
        {
            return EntradaFiscal.ObterIds();
        }
    }
}
