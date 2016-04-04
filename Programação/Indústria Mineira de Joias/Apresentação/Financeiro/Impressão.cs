using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro
{
    public partial class Impress�o : Apresenta��o.Formul�rios.JanelaImpress�o
    {
        private List<Entidades.Relacionamento.Relacionamento> relacionamentos;

        //public delegate void ImpressoDelegate();
        //public event ImpressoDelegate Impresso;

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

        /// <summary>
        /// Por este m�todo, o documento � conhecido e automatiamente � travado ap�s impress�o.
        /// </summary>
        public void InserirDocumento(CrystalDecisions.CrystalReports.Engine.ReportClass documento, string texto, Entidades.Relacionamento.Relacionamento relacionamento)
        {
            relacionamentos.Add(relacionamento);
            base.InserirDocumento(documento, texto);
        }
    }
}

