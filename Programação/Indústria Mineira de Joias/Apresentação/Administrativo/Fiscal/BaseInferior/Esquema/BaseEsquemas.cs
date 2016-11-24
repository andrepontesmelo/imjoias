using Entidades.Fiscal.Esquema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.Fiscal;
using Apresentação.Administrativo.Fiscal.Janela;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public partial class BaseEsquemas : Formulários.BaseInferior
    {
        private Fechamento fechamento;

        public BaseEsquemas()
        {
            InitializeComponent();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            CarregarLista();
        }

        private void CarregarLista()
        {
            lista.Carregar(fechamento);
        }

        private void lista_AoExcluir(object sender, System.EventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            List<EsquemaFabricação> seleção = lista.Seleção;

            if (seleção == null || seleção.Count == 0)
                return;

            if (MessageBox.Show(this,
                string.Format("Deseja excluir {0} esquema{1} de fabricação ?", seleção.Count, (seleção.Count == 1 ? "" : "s")),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            EsquemaFabricação.Excluir(seleção);
            lista.Carregar(fechamento);
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void opçãoNovo_Click(object sender, EventArgs e)
        {
            var baseEsquema = new BaseEsquema();
            baseEsquema.Carregar(new EsquemaFabricação(fechamento));

            SubstituirBase(baseEsquema);
        }

        private void lista_AoDuploClique(object sender, EventArgs e)
        {
            if (lista.Seleção == null || lista.Seleção.Count == 0)
                return;

            var baseEsquema = new BaseEsquema();
            baseEsquema.Carregar(lista.Seleção[0]);

            SubstituirBase(baseEsquema);
        }

        internal void Carregar(Fechamento fechamento)
        {
            this.fechamento = fechamento;

            if (lista != null)
                CarregarLista();
        }

        private void opçãoImportarEsquemas_Click(object sender, EventArgs e)
        {
            var janela = new JanelaImportaçãoEsquema();
            janela.Carregar(fechamento);
            janela.ShowDialog(this);

            Carregar(fechamento);
        }
    }
}
