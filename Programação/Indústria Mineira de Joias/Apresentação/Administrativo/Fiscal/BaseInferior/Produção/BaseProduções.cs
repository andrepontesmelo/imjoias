using Entidades.Fiscal.Produção;
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
            var baseProdução = new BaseProdução();
            baseProdução.Carregar(ProduçãoFiscal.Criar());

            SubstituirBase(baseProdução);
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaProduções1.Carregar();
        }
    }
}
