using Apresentação.Balanço;
using Entidades.Relacionamento;
using System;

namespace Apresentação.Administrativo.Balanço
{
    public partial class BaseBalanço : Apresentação.Formulários.BaseInferior
    {
        public BaseBalanço()
        {
            InitializeComponent();
        }

        public override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Construindo tela para balanço";

            base.AoCarregarCompletamente(splash);
        }

        private void opção1_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseResumo(listaSaídas.ObterCódigosMarcados(),
                listaRetornos.ObterCódigosMarcados(),
                listaVendas.ObterCódigosSelecionados(), 
                listaSedex.ObterCódigosSelecionados()
                ));
        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            // Recarrega as listas
            listaRetornos.Carregar();
            listaSaídas.Carregar();
            listaVendas.Carregar(false);
            listaSedex.Carregar(true);

            listaRetornos.Marcar(PersistênciaDocumentosBalanço.Instância.ListaRetornos);
            listaSaídas.Marcar(PersistênciaDocumentosBalanço.Instância.ListaSaídas);
            listaVendas.SelecionarApenas(PersistênciaDocumentosBalanço.Instância.ListaVendas);
            listaSedex.SelecionarApenas(PersistênciaDocumentosBalanço.Instância.ListaSedex);
        }

        private void opçãoFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void listaSaídas_DoubleClick(object sender, EventArgs e)
        {
            Entidades.Relacionamento.RelacionamentoAcerto entidade = (RelacionamentoAcerto) listaSaídas.ItemSelecionado;
            if (entidade == null) 
                return;

            Apresentação.Financeiro.Saída.SaídaBaseInferior saída = new Financeiro.Saída.SaídaBaseInferior();
            saída.Abrir(entidade);

            SubstituirBase(saída);
        }

        private void listaRetornos_DoubleClick(object sender, EventArgs e)
        {
            Entidades.Relacionamento.RelacionamentoAcerto entidade = (RelacionamentoAcerto) listaRetornos.ItemSelecionado;
            if (entidade == null)
                return;

            Apresentação.Financeiro.Retorno.RetornoBaseInferior retorno = new Financeiro.Retorno.RetornoBaseInferior();
            retorno.Abrir(entidade);

            SubstituirBase(retorno);
        }

        
        void listaVendas_AoDuploClique(long? códigoVenda)
        {
            if (códigoVenda.HasValue)
            {
                UseWaitCursor = true;
                Entidades.Relacionamento.RelacionamentoAcerto entidade =
                    Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda.Value);
                Apresentação.Financeiro.Venda.BaseEditarVenda venda = new Financeiro.Venda.BaseEditarVenda();
                UseWaitCursor = false;

                venda.Abrir(entidade);
                SubstituirBase(venda);
            }
        }

        private void listaSedex_AoDuploClique(long? códigoVenda)
        {
            if (códigoVenda.HasValue)
            {
                UseWaitCursor = true;
                Entidades.Relacionamento.RelacionamentoAcerto entidade =
                    Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda.Value);
                Apresentação.Financeiro.Venda.BaseEditarVenda venda = new Financeiro.Venda.BaseEditarVenda();
                UseWaitCursor = false;

                venda.Abrir(entidade);
                SubstituirBase(venda);
            }
        }

        private void listaSaídas_AoMarcar(object sender, EventArgs e)
        {
            PersistênciaDocumentosBalanço.Instância.MarcarSaídas(listaSaídas.ObterCódigosMarcados());
        }

        private void listaRetornos_AoMarcar(object sender, EventArgs e)
        {
            PersistênciaDocumentosBalanço.Instância.MarcarRetornos(listaRetornos.ObterCódigosMarcados());
        }

        private void listaVendas_AoMarcar(object sender, EventArgs e)
        {
            PersistênciaDocumentosBalanço.Instância.MarcarVendas(listaVendas.ObterCódigosSelecionados());
        }

        private void listaSedex_AoMarcar(object sender, EventArgs e)
        {
            PersistênciaDocumentosBalanço.Instância.MarcarSedex(listaSedex.ObterCódigosSelecionados());
        }
    }
}
