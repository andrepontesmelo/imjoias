using Acesso.Comum.Exceções;
using Apresentação.Financeiro.Acerto;
using Apresentação.Formulários;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Entidades.Relacionamento;
using Negócio;
using System;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    abstract public partial class BaseEditarRelacionamento : BaseInferior
    {
        private Relacionamento entidade;

        // Componentes
        private AMS.TextBox.IntegerTextBox integerTextBox1;
        private System.ComponentModel.IContainer components = null;
        private Quadro quadroAlternaBandeja;
        protected RadioButton optAgrupado;
        private RadioButton optHistórico;
        protected TítuloBaseInferior título;
        private Quadro quadroOpçãoPedido;
        private Opção opçãoImprimir;

        /// <summary>
        /// Ocorre quando a trava é alterada.
        /// </summary>
        public delegate void TravaAlteradaHandler(BaseEditarRelacionamento sender, 
            RelacionamentoAcerto e, bool entidadeTravada);

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

        protected Relacionamento Relacionamento
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
                TravaAlterada(this, entidade as RelacionamentoAcerto, entidadeTravada);
        }

        /// <summary>
        /// Deve ser chamado para abrir a propria base inferior
        /// </summary>
        /// <exception cref="ExceçãoTabelaVazia">Ocorre quando usuário não define uma tabela para o relacionamento.</exception>
        public virtual void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (relacionamento == null)
                throw new NullReferenceException("Relacionamento é nulo no Abrir() do RelacionamentoBaseInferior");

            this.entidade = relacionamento;

            txtObservação.Text = relacionamento.Observações == null ? "" : relacionamento.Observações;

            // Abre as bandejas
            CamposLivres = true;
            digitação.Abrir(relacionamento.Itens, relacionamento, this);
            CamposLivres = false;

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

        public virtual Relacionamento ReobterRelacionamento()
        {
            long código = Relacionamento.Código;

            if (Relacionamento is Entidades.Relacionamento.Saída.Saída)
                return Entidades.Relacionamento.Saída.Saída.ObterSaída(código);
            else if (Relacionamento is Entidades.Relacionamento.Retorno.Retorno)
                return Entidades.Relacionamento.Retorno.Retorno.ObterRetorno(código);

            throw new NotImplementedException(Relacionamento.GetType().ToString());
        }

        protected virtual void AlternarBandeja(object sender, EventArgs e)
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

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        void digitação_EntidadeTravada(bool travado)
        {
            AtualizarTravamento(travado);
        }

        protected abstract bool ValidarPermissãoDestravar();

        private void opçãoDestravar_Click(object sender, EventArgs e)
        {
            RelacionamentoAcerto relacionamentoAcerto = Relacionamento as RelacionamentoAcerto;

            bool entidadeTravada = relacionamentoAcerto.Travado;
            AtualizarTravamento(entidadeTravada);

            if (!entidadeTravada)
            {
                MessageBox.Show(this, "O documento já está destravado", "Erro ao destravar documento de consignado", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!ValidarPermissãoDestravar())
            {
                MessageBox.Show(this, "Você não tem permissão para destravar o documento.\n", 
                    "Não é possível destravar documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show(this, "Você rasgou o documento já impresso ? ", "Destravar documento de consignado", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
            {
                MessageBox.Show(this, "Você deveria rasgá-lo antes, caso contrário existirão duas versões impressas diferentes, o que gera confusão.", 
                    "Destravar documento de consignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show(this, " O servidor não pode destravar documento de consignado\n\n" + err.Message, 
                    "Erro ao destravar consignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            {
                try
                {
                    Relacionamento.Cadastrar();
                } catch (OperaçãoCancelada)
                {
                    MessageBox.Show(this,
                        "Venda ainda não foi salva.",
                        "Operação cancelada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

        }

        private void opçãoVisualizarImpressão_Click(object sender, EventArgs e)
        {
            Formulários.JanelaImpressão j = new Formulários.JanelaImpressão();
            InserirDocumento(j);
            j.Show();
        }

        protected abstract void InserirDocumento(Formulários.JanelaImpressão j);

        public void Recarregar()
        {
            Abrir(ReobterRelacionamento());
        }
    }
}
