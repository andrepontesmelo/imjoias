using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Lifetime;
using Apresentação.Mercadoria.Bandeja;
using Entidades;
using Entidades.Relacionamento;
using Apresentação.Formulários;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Apresentação.Financeiro.Acerto;
using Negócio;

namespace Apresentação.Financeiro
{
    public partial class BaseEditarRelacionamento : Apresentação.Formulários.BaseInferior
    {
        private Entidades.Relacionamento.Relacionamento entidade;

        // Componentes
        private AMS.TextBox.IntegerTextBox integerTextBox1;
        private System.ComponentModel.IContainer components = null;
        private Apresentação.Formulários.Quadro quadroAlternaBandeja;
        protected System.Windows.Forms.RadioButton optAgrupado;
        private System.Windows.Forms.RadioButton optHistórico;
        protected Apresentação.Formulários.TítuloBaseInferior título;
        private Apresentação.Formulários.Quadro quadroOpçãoPedido;
        private Apresentação.Formulários.Opção opçãoImprimir;

        /// <summary>
        /// Ocorre quando a trava é alterada.
        /// </summary>
        public delegate void TravaAlteradaHandler(BaseEditarRelacionamento sender, RelacionamentoAcerto e);

        public event TravaAlteradaHandler TravaAlterada;

        ContextMenu mnuObservação;
        MenuItem mnuItemCopiar;
        MenuItem mnuItemColar;

        public BaseEditarRelacionamento()
        {
            InitializeComponent();

            mnuObservação = new ContextMenu();
            mnuItemCopiar = new MenuItem("Copiar");
            mnuItemCopiar.Click += new EventHandler(mnuItemCopiar_Click);

            mnuItemColar = new MenuItem("Colar");
            mnuItemColar.Click += new EventHandler(mnuItemColar_Click);

            mnuObservação.MenuItems.Add(mnuItemCopiar);
            mnuObservação.MenuItems.Add(mnuItemColar);
            txtObservação.ContextMenu = mnuObservação;
        }

        void mnuItemColar_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
                txtObservação.SelectedText = Clipboard.GetData(DataFormats.Text).ToString();
        }

        void mnuItemCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, txtObservação.SelectedRtf);
        }

        /// <summary>
        /// Compos podem ser livres para alteração mesmo entidade sendo travada.
        /// </summary>
        private bool camposLivres;

        public bool CamposLivres
        {
            get { return camposLivres; }
            set { camposLivres = value; }
        }

        protected virtual TipoDocumento TipoDocumento { get { return TipoDocumento.Desconhecido; } }

        protected Entidades.Relacionamento.Relacionamento Relacionamento
        {
            get { return entidade; }
        }

        protected DigitaçãoComum Digitação
        {
            get { return digitação; }
        }

        protected virtual void AtualizarTravamento(bool entidadeTravada)
        {
            quadroTravamento.Visible = entidadeTravada;

            txtObservação.ReadOnly = entidadeTravada;


#if PROTEGER_DOCUMENTOS_ACERTADOS
            opçãoDestravar.Visible = Relacionamento.AcertoConsignado == null || !Relacionamento.AcertoConsignado.Acertado;
#else
            opçãoDestravar.Visible = entidadeTravada;
#endif

            digitação.AtualizarTravamento(entidadeTravada);

            if (TravaAlterada != null)
                TravaAlterada(this, entidade as RelacionamentoAcerto);
        }

        /// <summary>
        /// Deve ser chamado para abrir a propria base inferior
        /// </summary>
        /// <exception cref="ExceçãoTabelaVazia">Ocorre quando usuário não define uma tabela para o relacionamento.</exception>
        public virtual void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (relacionamento == null)
                throw new NullReferenceException("Relacionamento é nulo no Abrir() do RelacionamentoBaseInferior");

            // Registra o objeto de contexto
            this.entidade = relacionamento;

            txtObservação.Text = relacionamento.Observações == null ? "" : relacionamento.Observações;
            //AguardeDB.Mostrar();

            // Abre as bandejas
            CamposLivres = true;
            digitação.Abrir(relacionamento.Itens, relacionamento, this);
            CamposLivres = false;
            //AguardeDB.Fechar();

            RelacionamentoAcerto relacionamentoAcerto = relacionamento as RelacionamentoAcerto;


            if (relacionamentoAcerto != null)
            {
                AtualizarTravamento(relacionamentoAcerto.Travado);

                verificadorMercadoria.Enabled = relacionamentoAcerto.AcertoConsignado != null;
                verificadorMercadoria.Restringir(relacionamentoAcerto.AcertoConsignado);
                digitação.Verificador = verificadorMercadoria;

                if (relacionamentoAcerto.AcertoConsignado != null && relacionamentoAcerto.AcertoConsignado.Acertado)
                    SinalizaçãoAcertado.Sinalizar(this);
            }
        }

        /// <summary>
        /// Ao ser substituído, atualiza o banco de dados. Caso a entidade
        /// não esteja cadastrada, remove do acerto.
        /// </summary>
        protected override void AoSerSubstituído(BaseInferior novaBase)
        {
            base.AoSerSubstituído(novaBase);

            RelacionamentoAcerto relacionamentoAcerto = Relacionamento as RelacionamentoAcerto;

            if (Relacionamento.Cadastrado)
                Relacionamento.Atualizar();
            else if (relacionamentoAcerto != null && relacionamentoAcerto.AcertoConsignado != null
                && relacionamentoAcerto.AcertoConsignado.Contém(Relacionamento))
                relacionamentoAcerto.AcertoConsignado.Remover(Relacionamento);
        }

        protected virtual void AlternarBandeja(object sender, System.EventArgs e)
        {
            if (optAgrupado.Checked)
                digitação.TipoExibiçãoAtual = DigitaçãoComum.TipoExibição.TipoAgrupado;
            else
                digitação.TipoExibiçãoAtual = DigitaçãoComum.TipoExibição.TipoHistórico;
        }

        protected virtual void Imprimir()
        {
            using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento))
            {
                dlg.PermitirEscolherPágina = true;

                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    FilaImpressão fila = FilaImpressão.ObterFila(dlg.ControleImpressão, dlg.Impressora);

                    fila.Imprimir((ulong)entidade.Código, dlg.PáginaInicial, dlg.PáginaFinal, dlg.NúmeroCópias);
                }
            }

        }

        private void opçãoImprimir_Click(object sender, System.EventArgs e)
        {
            Imprimir();
        }

        void digitação_EntidadeTravada(bool travado)
        {
            AtualizarTravamento(travado);
        }

        protected virtual bool ValidarPermissãoDestravar()
        {
            throw new Exception("Método abastrato");
        }

        private void opçãoDestravar_Click(object sender, EventArgs e)
        {
            RelacionamentoAcerto relacionamentoAcerto = Relacionamento as RelacionamentoAcerto;


            bool entidadeTravada = relacionamentoAcerto.Travado;
            AtualizarTravamento(entidadeTravada);

            if (!entidadeTravada)
            {
                //Beepador.Erro();
                MessageBox.Show(this, "O documento já está destravado", "Erro ao destravar documento de consignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!ValidarPermissãoDestravar())
            {
                MessageBox.Show(this, "Você não tem permissão para destravar o documento.\n", "Não é possível destravar documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show(this, "Você rasgou o documento já impresso ? ", "Destravar documento de consignado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
            {
                MessageBox.Show(this, "Você deveria rasgá-lo antes, caso contrário existirão duas versões impressas diferentes, o que gera confusão.", "Destravar documento de consignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            try
            {
                relacionamentoAcerto.Travado = false;
                AtualizarTravamento(false);
            }
            catch (Exception err)
            {
                Beepador.Erro();
                MessageBox.Show(this, " O servidor não pode destravar documento de consignado\n\n" + err.Message, "Erro ao destravar consignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Dá mensagem de erro caso o documento encontra-se travado.
        /// </summary>
        /// <returns>tracado</returns>
        public bool ConferirTravamento()
        {
            RelacionamentoAcerto relacionamentoAcerto = Relacionamento as RelacionamentoAcerto;

            if (camposLivres || relacionamentoAcerto == null)
                return false;

            bool entidadeTravada = relacionamentoAcerto.Travado;

            AtualizarTravamento(entidadeTravada);

            //if (entidadeTravada && mostrarMensagemErro)
            //{
            //    Beepador.Erro();
            //    MessageBox.Show(this, "O documento não pode ser alterado porque encontra-se travado. \nContacte o supervisor para seu destravamento.",
            //        "Documento travado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            return entidadeTravada;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            RelacionamentoAcerto relacionamentoAcerto = Relacionamento as RelacionamentoAcerto;

            if (entidade.Cadastrado)
            {
                if (relacionamentoAcerto != null && relacionamentoAcerto.Travado)
                {
                    MessageBox.Show(
                        "Destrave antes",
                        "Documento travado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (MessageBox.Show(
                    ParentForm,
                    "Deseja mesmo excluir permanentemente este documento?",
                    "Excluir documento",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (Login.ExigirIdentificação(ParentForm, Entidades.Privilégio.Permissão.ConsignadoDestravar,
                        Entidades.Pessoa.Funcionário.FuncionárioAtual,
                        "Exclusão de documento",
                        "Exclusão de relação de consignado",
                        "É necessário autenticação de funcionário para iniciar a exclusão de documento."))
                    {
                        entidade.Descadastrar();
                        SubstituirBaseParaAnterior();
                    }
                    else
                        MessageBox.Show(ParentForm, "Operação abortada!",
                            "Exclusão de documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                SubstituirBaseParaAnterior();
        }

        private void txtObservação_Validated(object sender, EventArgs e)
        {
            Relacionamento.Observações = txtObservação.Text;

            if (entidade.Cadastrado)
                Relacionamento.Atualizar();
            else
                Relacionamento.Cadastrar();
        }
    }
}
