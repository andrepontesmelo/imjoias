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
            SubstituirBaseEdição(ProduçãoFiscal.Criar());
        }

        private void SubstituirBaseEdição(ProduçãoFiscal produção)
        {
            var baseProdução = new BaseProdução();
            baseProdução.Carregar(produção);
            SubstituirBase(baseProdução);
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaProduções.Carregar();
        }

        private void listaProduções1_AoDuploClique(object sender, EventArgs e)
        {
            var seleção = listaProduções.ObterSeleção();

            if (seleção.Count == 0)
                return;

            SubstituirBaseEdição(seleção[0]);
        }
    }
}
