using Apresentação.Administrativo.Fiscal.Janela;
using Entidades.Fiscal;
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
            var fabricação = FabricaçãoFiscal.Criar();
            var janelaEdiçãoFabricação = new JanelaEdiçãoFabricação(fabricação);
            var resultado = janelaEdiçãoFabricação.Mostrar(this);

            if (resultado == System.Windows.Forms.DialogResult.Cancel)
            {
                fabricação.Descadastrar();
                return;
            }

            SubstituirBaseEdição(fabricação);
        }

        private void SubstituirBaseEdição(FabricaçãoFiscal fabricação)
        {
            SubstituirBase(new BaseFabricação(fabricação));
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Carregar();
        }

        private void listaFabricações1_AoDuploClique(object sender, EventArgs e)
        {
            var seleção = listaFabricações.ObterSeleção();

            if (seleção.Count == 0)
                return;

            SubstituirBaseEdição(seleção[0]);
        }

        private void comboFechamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void Carregar()
        {
            comboFechamento.Carregar();
            CarregarLista();
        }

        private void CarregarLista()
        {
            Fechamento fechamento = comboFechamento.Seleção;
            listaFabricações.Carregar(fechamento.Início, fechamento.Fim);
        }
    }
}
