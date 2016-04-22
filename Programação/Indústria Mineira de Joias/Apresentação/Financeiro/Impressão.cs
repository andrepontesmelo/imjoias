using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    public partial class Impressão : Apresentação.Formulários.JanelaImpressão
    {
        private List<Entidades.Relacionamento.Relacionamento> relacionamentos;

        //public delegate void ImpressoDelegate();
        //public event ImpressoDelegate Impresso;

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

        /// <summary>
        /// Por este método, o documento é conhecido e automatiamente é travado após impressão.
        /// </summary>
        public void InserirDocumento(CrystalDecisions.CrystalReports.Engine.ReportClass documento, string texto, Entidades.Relacionamento.Relacionamento relacionamento)
        {
            relacionamentos.Add(relacionamento);
            base.InserirDocumento(documento, texto);
        }
    }
}

