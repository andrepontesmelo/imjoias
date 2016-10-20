using Apresentação.Fiscal.Lista;
using Entidades;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseSaídas : BaseDocumentos
    {
        public BaseSaídas()
        {
            InitializeComponent();

            tabControl.TabPages.Clear();
            Setor[] setores = Setor.ObterSetoresAtendimento();
            foreach (Setor setor in setores)
            {
                TabPage aba = new TabPage(setor.Nome);
                tabControl.TabPages.Add(aba);
                ListaDocumentoSaída lista = new ListaDocumentoSaída();
                lista.Tag = (int) setor.Código;
                lista.Dock = DockStyle.Fill;
                aba.Controls.Add(lista);
            }
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            CarregarListas();
            quadroTipo.Carregar(false);
        }

        private void CarregarListas()
        {
            foreach (TabPage aba in tabControl.TabPages)
            {
                ListaDocumentoSaída lista = (ListaDocumentoSaída) aba.Controls[0];
                lista.Carregar(quadroTipo.Seleção?.Id, (int) lista.Tag);
            }
        }

        private void quadroTipo_SeleçãoAlterada(object sender, EventArgs e)
        {
            CarregarListas();
        }

        private void opçãoNovo_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseSaída());
        }

        protected override ListaDocumentoFiscal ObterListaAtiva()
        {
            return tabControl.SelectedTab.Controls[0] as ListaDocumentoFiscal;
        }
    }
}
