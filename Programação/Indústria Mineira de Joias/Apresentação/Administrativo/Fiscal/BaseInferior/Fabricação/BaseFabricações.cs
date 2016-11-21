using Entidades.Fiscal.Fabricação;
using System;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.fabricação
{
    public partial class BaseFabricações : Apresentação.Formulários.BaseInferior
    {
        public BaseFabricações()
        {
            InitializeComponent();
        }

        private void opçãoNovafabricação_Click(object sender, EventArgs e)
        {
            SubstituirBaseEdição(FabricaçãoFiscal.Criar());
        }

        private void SubstituirBaseEdição(FabricaçãoFiscal fabricação)
        {
            SubstituirBase(new BaseFabricação(fabricação));
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaFabricações.Carregar();
        }

        private void listaFabricações1_AoDuploClique(object sender, EventArgs e)
        {
            var seleção = listaFabricações.ObterSeleção();

            if (seleção.Count == 0)
                return;

            SubstituirBaseEdição(seleção[0]);
        }
    }
}
