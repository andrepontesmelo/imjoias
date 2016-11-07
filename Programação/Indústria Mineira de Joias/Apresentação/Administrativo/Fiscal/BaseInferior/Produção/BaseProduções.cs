using System;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Produção
{
    public partial class BaseProduções : Apresentação.Formulários.BaseInferior
    {
        public BaseProduções()
        {
            InitializeComponent();
        }

        private void opçãoNovaProdução_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseProdução());
        }
    }
}
