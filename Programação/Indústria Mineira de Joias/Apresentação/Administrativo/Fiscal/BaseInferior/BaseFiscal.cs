using Apresentação.Administrativo.Fiscal.BaseInferior;
using Apresentação.Fiscal.BaseInferior.Documentos;
using Apresentação.Fiscal.Janela;
using System;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseFiscal : Formulários.BaseInferior
    {
        public BaseFiscal()
        {
            InitializeComponent();
        }

        private void opçãoImportação_Click(object sender, EventArgs e)
        {
            new JanelaImportação().Show();
        }

        private void opçãoEntradas_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseEntradas());
        }

        private void opçãoSaídas_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseSaídas());
        }

        private void opçãoMáquinasECF_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseMaquinasFiscais());
        }
    }
}
