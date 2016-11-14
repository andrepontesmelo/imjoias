using CrystalDecisions.CrystalReports.Engine;

namespace Apresentação.Administrativo.Fiscal.Janela
{
    public partial class JanelaImpressãoFiscal : Formulários.JanelaImpressão
    {
        public JanelaImpressãoFiscal()
        {
            InitializeComponent();
        }

        public void InserirDocumento(string título, string descrição, ReportClass relatório)
        {
            Título = título;
            Descrição = descrição;
            InserirDocumento(relatório, título);
        }
    }
}
