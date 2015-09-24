using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;

namespace Apresentação.Financeiro.Acerto
{
    public partial class ListaDocumentosAcerto : UserControl
    {
        public event ListaDocumentosAcertoItem.ClickDelegate AoEscolherDocumento;

        private AcertoConsignado acerto;

        public AcertoConsignado AcertoConsignado
        {
            get { return acerto; }
            set
            {
                acerto = value;

                SuspendLayout();
                exibiçãoDocumentos1.AcertoConsignado = value;
                exibiçãoDocumentos2.AcertoConsignado = value;
                exibiçãoDocumentos3.AcertoConsignado = value;
                ResumeLayout();
            }
        }

        public void Recarregar(AcertoConsignado acerto)
        {
            AcertoConsignado = acerto;

            exibiçãoDocumentos1.Recarregar(acerto);
            exibiçãoDocumentos2.Recarregar(acerto);
            exibiçãoDocumentos3.Recarregar(acerto);
        }

        public ListaDocumentosAcerto()
        {
            InitializeComponent();
        }

        private void exibiçãoDocumentos_AoClicar(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            AoEscolherDocumento(relacionamento);
        }
    }
}
