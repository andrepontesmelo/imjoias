using System;
using System.Collections.Generic;
using Entidades.Fiscal;

namespace Apresentação.Fiscal
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
