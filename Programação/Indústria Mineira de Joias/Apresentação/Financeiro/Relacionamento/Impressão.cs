using System.Collections.Generic;

namespace Apresenta��o.Financeiro
{
    public partial class Impress�o : Apresenta��o.Formul�rios.JanelaImpress�o
    {
        private List<Entidades.Relacionamento.Relacionamento> relacionamentos;

        public Impress�o()
        {
            InitializeComponent();
            relacionamentos = new List<Entidades.Relacionamento.Relacionamento>();
        }

        protected override void Ap�sImpresso()
        {
            base.Ap�sImpresso();

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

