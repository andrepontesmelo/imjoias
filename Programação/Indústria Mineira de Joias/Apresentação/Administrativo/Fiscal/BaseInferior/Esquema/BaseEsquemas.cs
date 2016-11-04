using Entidades.Fiscal;
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
            List<EsquemaProdução> seleção = lista.Seleção;

            if (seleção == null || seleção.Count == 0)
                return;

            if (MessageBox.Show(this,
                string.Format("Deseja excluir {0} esquema{1} de produção ?", seleção.Count, (seleção.Count == 1 ? "" : "s")),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            EsquemaProdução.ExcluirRecarregandoCache(seleção);
            lista.Carregar();
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }
    }
}
