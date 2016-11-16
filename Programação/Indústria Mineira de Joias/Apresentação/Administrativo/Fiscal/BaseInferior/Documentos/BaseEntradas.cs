using Apresentação.Fiscal.BaseInferior.Documentos.Exclusão;
using Apresentação.Fiscal.Lista;
using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior.Documentos
{
    public partial class BaseEntradas : BaseDocumentos
    {
        public BaseEntradas()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();
            CarregarLista();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();
            quadroTipo.Carregar(true);
        }

        private void quadroTipo_SeleçãoAlterada(object sender, System.EventArgs e)
        {
            CarregarLista();
        }

        protected override void Recarregar()
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            if (!seleçãoPeríodo.DatasVálidas)
                seleçãoPeríodo.AtribuirIntervaloDatasPadrão();

            lista.Carregar(quadroTipo.Seleção?.Id, seleçãoPeríodo.DataInicial.Value, seleçãoPeríodo.DataFinal.Value);
        }

        public override ListaDocumentoFiscal ObterListaAtiva()
        {
            return lista;
        }

        protected override void Abrir(DocumentoFiscal documento)
        {
            BaseEntrada novaBase = new BaseEntrada();
            novaBase.Carregar(documento);

            SubstituirBase(novaBase);
        }

        private void lista_CliqueDuplo(DocumentoFiscal documento)
        {
            if (documento == null)
                return;

            Abrir(documento);
        }

        protected override DocumentoFiscal Criar()
        {
            return EntradaFiscal.CriarDocumento();
        }

        protected override ControladorExclusão ConstruirControlador()
        {
            return new ControladorExclusãoEntrada(this);
        }

        private void lista_AoSolicitarExclusão(object sender, System.EventArgs e)
        {
            Excluir();
        }
    }
}
