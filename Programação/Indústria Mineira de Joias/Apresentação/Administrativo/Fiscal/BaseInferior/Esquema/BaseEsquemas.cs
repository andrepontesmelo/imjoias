using Entidades.Fiscal.Esquema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public partial class BaseEsquemas : Apresentação.Formulários.BaseInferior
    {
        public BaseEsquemas()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            lista.Carregar();
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
            lista.Carregar();
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void opçãoNovo_Click(object sender, EventArgs e)
        {
            var baseEsquema = new BaseEsquema();
            baseEsquema.Carregar(new EsquemaFabricação());

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
    }
}
