using System.Collections.Generic;

namespace Apresentação.Financeiro
{
    public partial class Impressão : Apresentação.Formulários.JanelaImpressão
    {
        private List<Entidades.Relacionamento.Relacionamento> relacionamentos;

        public Impressão()
        {
            InitializeComponent();
            relacionamentos = new List<Entidades.Relacionamento.Relacionamento>();
        }

        protected override void ApósImpresso()
        {
            base.ApósImpresso();

            foreach (Entidades.Relacionamento.RelacionamentoAcerto r in relacionamentos)
                if (!r.Travado) r.Travado = true;
        }

        public void InserirDocumento(CrystalDecisions.CrystalReports.Engine.ReportClass documento, string texto, Entidades.Relacionamento.Relacionamento relacionamento)
        {
            relacionamentos.Add(relacionamento);
            base.InserirDocumento(documento, texto);
        }
    }
}

