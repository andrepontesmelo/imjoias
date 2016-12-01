using Apresentação.Fiscal.BaseInferior.Documentos.Exclusão;
using Apresentação.Fiscal.Lista;
using Apresentação.Formulário.Exceção;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Fiscal.ListaDocumento;
using Entidades.Fiscal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Fiscal.BaseInferior.Documentos
{
    public partial class BaseDocumentos : Formulários.BaseInferior
    {
        private ControladorExclusão controlador;

        public BaseDocumentos()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            comboFechamento.Carregar();
            controlador = ConstruirControlador();
        }

        protected virtual ControladorExclusão ConstruirControlador()
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void opçãoExcluir_Click(object sender, System.EventArgs e)
        {
            Excluir();
        }

        protected void Excluir()
        {
            if (controlador.Excluir())
                Recarregar();
        }

        protected virtual void Recarregar()
        {
        }

        protected Fechamento Fechamento => comboFechamento.Seleção;

        protected bool MostrarMensagemFechamentoDeveSerEscolhido()
        {
            if (Fechamento == null)
            {
                MessageBox.Show("Selecionar um fechamento");
                return true;
            }

            return false;
        }
        public virtual ListaDocumentoFiscal ObterListaAtiva()
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        protected virtual void Abrir(DocumentoFiscal documento)
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void opçãoNovo_Click(object sender, System.EventArgs e)
        {
            Abrir(Criar());
        }

        protected virtual DocumentoFiscal Criar()
        {
            throw new ExceçãoChamadaMétodoAbstrato();
        }

        private void comboFechamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recarregar();
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            var controlador = new ControladorImpressão();
            var relatório = controlador.CriarRelatório(Fechamento, ObterEntidades());

            var janela = new JanelaImpressão();
            janela.InserirDocumento(relatório, "Documento");
            janela.ShowDialog();
        }

        protected virtual List<DocumentoFiscal> ObterEntidades()
        {
            throw new NotImplementedException();
        }
    }
}
