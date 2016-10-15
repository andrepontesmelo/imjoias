using System;
using static Entidades.Setor;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaídas : BaseDocumentos
    {
        public BaseSaídas()
        {
            InitializeComponent();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            CarregarListas();
        }

        private void CarregarListas()
        {
            lstAtacado.Carregar(quadroTipo.Seleção?.Id, (int) SetorSistema.Atacado);
            lstVarejo.Carregar(quadroTipo.Seleção?.Id, (int) SetorSistema.Varejo);
        }

        private void quadroTipo_SeleçãoAlterada(object sender, EventArgs e)
        {
            CarregarListas();
        }
    }
}
