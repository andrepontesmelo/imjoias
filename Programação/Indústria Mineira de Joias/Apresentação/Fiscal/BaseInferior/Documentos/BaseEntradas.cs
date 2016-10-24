using Apresentação.Fiscal.Lista;
using Apresentação.Formulários;
using Entidades.Fiscal;

namespace Apresentação.Fiscal.BaseInferior.Documentos
{
    public partial class BaseEntradas : BaseDocumentos
    {
        public BaseEntradas()
        {
            InitializeComponent();
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            CarregarLista();
            quadroTipo.Carregar(true);
        }

        private void quadroTipo_SeleçãoAlterada(object sender, System.EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            lista.Carregar(quadroTipo.Seleção?.Id);
        }

        private void opçãoNovo_Click(object sender, System.EventArgs e)
        {
            SubstituirBase(new BaseEntrada());
        }

        public override ListaDocumentoFiscal ObterListaAtiva()
        {
            return lista;
        }

        protected override void AbrirDocumento(DocumentoFiscal documento)
        {
            BaseEntrada novaBase = new BaseEntrada();
            novaBase.Carregar(documento);

            SubstituirBase(novaBase);
        }

        private void lista_CliqueDuplo(DocumentoFiscal documento)
        {
            if (documento == null)
                return;

            AbrirDocumento(documento);
        }
    }
}
