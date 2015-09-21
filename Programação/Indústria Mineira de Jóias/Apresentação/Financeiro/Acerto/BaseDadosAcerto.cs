using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Acerto;

namespace Apresentação.Financeiro.Acerto
{
    /// <summary>
    /// Base inferior que apresenta dados do acerto.
    /// </summary>
    public partial class BaseDadosAcerto : BaseInferior
    {
        private AcertoConsignado acerto;

        /// <summary>
        /// Acerto a ser trabalhado.
        /// </summary>
        public AcertoConsignado AcertoConsignado
        {
            get { return acerto; }
            set
            {
                acerto = value;
                informaçõesAcerto.AcertoConsignado = acerto;
                listaDocumentosAcerto.AcertoConsignado = acerto;
                títuloBaseInferior1.Título = acerto.Cliente.Nome;
                títuloBaseInferior1.Descrição = string.Format(
                    "Acerto de mercadorias número {0}",
                    acerto.Código);

                opçãoEscolherDocumentos.Enabled &= !acerto.Acertado;
                opçãoIniciarRetorno.Enabled &= !acerto.Acertado;

                acerto.PrepararVerificaçãoConsistência();
            }
        }

        public BaseDadosAcerto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao exibir a base de dados de acerto.
        /// </summary>
        protected override void AoExibir()
        {
            base.AoExibir();

            bool liberarPrazo = true;

            foreach (Entidades.Relacionamento.Saída.Saída saída in acerto.Saídas)
                if (!(liberarPrazo &= saída.ObterTravadoEmCache()))
                    break;

            if (liberarPrazo)
            {
                botãoLiberarPrevisão.Texto = "Liberar mais prazo";
                informaçõesAcerto.PermitirAlteração = true;
                informaçõesAcerto.LiberarPrazo = false;
            }
            else
            {
                botãoLiberarPrevisão.Texto = "Alterar previsão";
                informaçõesAcerto.PermitirAlteração = false;
                informaçõesAcerto.LiberarPrazo = true;
            }

            botãoLiberarPrevisão.Visible = true;

            simulaçãoAcerto1.Carregar(acerto);
        }

        /// <summary>
        /// Libera usuário para alterar a previsão.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botãoLiberarPrevisão_LiberarRecurso(object sender, EventArgs e)
        {
            informaçõesAcerto.PermitirAlteração = true;
            informaçõesAcerto.LiberarPrazo = true;
            informaçõesAcerto.IniciarEdição();
        }

        /// <summary>
        /// Garante que um acerto terminado não está sendo editado.
        /// </summary>
        private void GarantirNãoAcertado()
        {
            if (acerto.Acertado)
                throw new NotSupportedException("Não é permitido alterar um acerto finalizado.");
        }

        /// <summary>
        /// Inicia um novo retorno.
        /// </summary>
        private void opçãoIniciarRetorno_Click(object sender, EventArgs e)
        {
            Entidades.Relacionamento.Retorno.Retorno retorno;
            Retorno.RetornoBaseInferior baseInferior = null;

            GarantirNãoAcertado();

            // Gerar retorno.
            retorno = new Entidades.Relacionamento.Retorno.Retorno(acerto.Cliente);
            retorno.DigitadoPor = Entidades.Pessoa.Funcionário.FuncionárioAtual;
            retorno.TabelaPreço = acerto.TabelaPreço;

            acerto.Retornos.Adicionar(retorno);

            // Mudar interface gráfica.
            try
            {
                baseInferior = new Apresentação.Financeiro.Retorno.RetornoBaseInferior();
                baseInferior.Abrir(retorno);
            }
            catch (ExceçãoTabelaVazia)
            {
                acerto.Retornos.Remover(retorno);

                if (baseInferior != null)
                    baseInferior.Dispose();

                return;
            }

            SubstituirBase(baseInferior);
        }

        /// <summary>
        /// Ocorre quando usuário clica em um documento.
        /// </summary>
        /// <param name="relacionamento">Documento que será aberto.</param>
        private void listaDocumentosAcerto_AoEscolherDocumento(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (relacionamento is Entidades.Relacionamento.Saída.Saída)
            {
                Saída.SaídaBaseInferior baseInferior = new Saída.SaídaBaseInferior();
                baseInferior.Abrir(relacionamento);
                SubstituirBase(baseInferior);
            }
            else if (relacionamento is Entidades.Relacionamento.Retorno.Retorno)
            {
                Retorno.RetornoBaseInferior baseInferior = new Apresentação.Financeiro.Retorno.RetornoBaseInferior();
                baseInferior.Abrir(relacionamento);
                SubstituirBase(baseInferior);
            }
            else if (relacionamento is Entidades.Relacionamento.Venda.Venda)
            {
                Venda.BaseEditarVenda baseInferior = new Apresentação.Financeiro.Venda.BaseEditarVenda();
                baseInferior.Abrir(relacionamento);
                SubstituirBase(baseInferior);
            }
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Ocorre quando usuário deseja escolher documentos para um acerto.
        /// </summary>
        private void opçãoEscolherDocumentos_Click(object sender, EventArgs e)
        {
            BaseSeleçãoDocumentos baseInferior = new BaseSeleçãoDocumentos();
            baseInferior.Acerto = acerto;
            SubstituirBase(baseInferior);
        }

        private void opçãoContabilizar_Click(object sender, EventArgs e)
        {
            BaseResumoAcerto baseInferior = new BaseResumoAcerto();
            baseInferior.Carregar(acerto);
            SubstituirBase(baseInferior);
        }

        private void btnCalcularDesconto_Click(object sender, EventArgs e)
        {
            JanelaDesconto janela = new JanelaDesconto();
            janela.Show();
            janela.Carregar(acerto);
        }
    }
}
