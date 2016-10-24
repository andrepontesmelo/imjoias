using Apresentação.Fiscal.Lista;
using Entidades;
using Entidades.Fiscal;
using System;
using System.Windows.Forms;

namespace Apresentação.Fiscal.BaseInferior.Documentos
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
                lista.CliqueDuplo += Lista_CliqueDuplo;
                aba.Controls.Add(lista);
            }
        }

        private void Lista_CliqueDuplo(DocumentoFiscal documento)
        {
            if (documento == null)
                return;

            AbrirDocumento(documento);
        }

        protected override void AoExibir()
        {
            base.AoExibir();
            CarregarListas();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();
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

        public override ListaDocumentoFiscal ObterListaAtiva()
        {
            return tabControl.SelectedTab.Controls[0] as ListaDocumentoFiscal;
        }

        protected override void AbrirDocumento(DocumentoFiscal documento)
        {
            BaseSaída novaBase = new BaseSaída();
            novaBase.Carregar(documento);

            SubstituirBase(novaBase);
        }
    }
}
