using Entidades.Fiscal;
using System.Collections.Generic;

namespace Apresentação.Fiscal.Lista
{
    public partial class ListaDocumentoSaída : ListaDocumentoFiscal
    {
        public ListaDocumentoSaída()
        {
            InitializeComponent();
        }

        protected override List<DocumentoFiscal> Obter(int? tipoDocumento)
        {
            return SaídaFiscal.Obter(tipoDocumento);
        }
    }
}