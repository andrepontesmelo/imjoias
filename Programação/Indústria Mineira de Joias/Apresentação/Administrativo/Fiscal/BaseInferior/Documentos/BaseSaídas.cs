using Apresentação.Fiscal.Lista;
using Entidades;
using Entidades.Fiscal;
using System;
using System.Windows.Forms;
using Apresentação.Fiscal.BaseInferior.Documentos.Exclusão;

namespace Apresentação.Fiscal.BaseInferior.Documentos
{
    public partial class BaseSaídas : BaseDocumentos
    {
        public BaseSaídas()
        {
            InitializeComponent();

            tabControl.TabPages.Clear();
            foreach (Setor setor in Setor.ObterSetoresAtendimento())
                tabControl.TabPages.Add(CriarAba(setor));
        }

        private TabPage CriarAba(Setor setor)
        {
            TabPage aba = new TabPage(setor.Nome);

            aba.Controls.Add(CriarLista(setor));

            return aba;
        }

        private ListaDocumentoSaída CriarLista(Setor setor)
        {
            var lista = new ListaDocumentoSaída();

            lista.Tag = setor.Código;
            lista.Dock = DockStyle.Fill;
            lista.CliqueDuplo += Lista_CliqueDuplo;
            lista.AoSolicitarExclusão += Lista_AoSolicitarExclusão;

            return lista;
        }

        private void Lista_AoSolicitarExclusão(object sender, EventArgs e)
        {
            Excluir();
        }

        private void Lista_CliqueDuplo(DocumentoFiscal documento)
        {
            if (documento == null)
                return;

            Abrir(documento);
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

        protected override void Recarregar()
        {
            CarregarListas();
        }

        private void CarregarListas()
        {
            if (!seleçãoPeríodo.DatasVálidas)
                seleçãoPeríodo.AtribuirIntervaloDatasPadrão();

            foreach (TabPage aba in tabControl.TabPages)
            {
                ListaDocumentoSaída lista = (ListaDocumentoSaída) aba.Controls[0];
                lista.Carregar(quadroTipo.Seleção?.Id, (uint) lista.Tag, seleçãoPeríodo.DataInicial.Value, seleçãoPeríodo.DataFinal.Value);
            }
        }

        private void quadroTipo_SeleçãoAlterada(object sender, EventArgs e)
        {
            CarregarListas();
        }

        public override ListaDocumentoFiscal ObterListaAtiva()
        {
            return tabControl.SelectedTab.Controls[0] as ListaDocumentoFiscal;
        }

        protected override void Abrir(DocumentoFiscal documento)
        {
            BaseSaída novaBase = new BaseSaída();
            novaBase.Carregar(documento);

            SubstituirBase(novaBase);
        }

        protected override DocumentoFiscal Criar()
        {
            var lista = ObterListaAtiva() as ListaDocumentoSaída;
            return SaídaFiscal.CriarDocumento(lista.Setor);
        }

        protected override ControladorExclusão ConstruirControlador()
        {
            return new ControladorExclusãoSaída(this);
        }
    }
}
