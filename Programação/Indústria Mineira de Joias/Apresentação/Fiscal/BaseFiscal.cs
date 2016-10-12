using Apresentação.Formulários;
using System;

namespace Apresentação.Fiscal
{
    public partial class BaseFiscal : BaseInferior
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
    }
}
