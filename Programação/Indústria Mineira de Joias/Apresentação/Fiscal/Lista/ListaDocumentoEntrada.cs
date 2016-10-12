using Entidades.Fiscal;
using System.Collections.Generic;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoEntrada : ListaDocumentoFiscal
    {
        public ListaDocumentoEntrada()
        {
            InitializeComponent();
        }

        protected override List<DocumentoFiscal> Obter(int? tipoDocumento)
        {
            return EntradaFiscal.Obter(tipoDocumento);
        }
    }
}
