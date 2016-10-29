using Apresentação.Fiscal.BaseInferior.Documentos.Exclusão;
using Apresentação.Fiscal.Lista;
using Entidades.Configuração;
using Entidades.Fiscal;
using System;
using System.ComponentModel;

namespace Apresentação.Fiscal.BaseInferior.Documentos
{
    public partial class BaseDocumentos : Formulários.BaseInferior
    {
        private ControladorExclusão controlador;

        public BaseDocumentos()
        {
            InitializeComponent();

            if (DadosGlobais.ModoDesenho)
                return;

            controlador = ConstruirControlador();
        }

        protected virtual ControladorExclusão ConstruirControlador()
        {
            throw new Exception("abstrato");
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

        public virtual ListaDocumentoFiscal ObterListaAtiva()
        {
            throw new System.Exception("abstrato");
        }

        protected virtual void Abrir(DocumentoFiscal documento)
        {
            throw new System.Exception("abstrato");
        }

        private void opçãoNovo_Click(object sender, System.EventArgs e)
        {
            Abrir(Criar());
        }

        protected virtual DocumentoFiscal Criar()
        {
            throw new Exception("abstrato");
        }
    }
}
