using Apresentação.Financeiro.Acerto;
using Apresentação.Formulários;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Entidades.Acerto;
using Entidades.Configuração;
using Entidades.Privilégio;
using Entidades.Relacionamento;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// Base inferior que exibe a listagem dos documentos de consignado para um cliente.
    /// </summary>
    public class BaseConsignado : Apresentação.Formulários.BaseInferior
    {
        // Cliente ou representante
        private Entidades.Pessoa.Pessoa pessoa;

        protected Apresentação.Formulários.TítuloBaseInferior   título;
        protected Apresentação.Formulários.Quadro               quadroRelacionamentos;
        protected Apresentação.Formulários.Opção                opçãoNovoRelacionamento;
        protected Apresentação.Formulários.Opção                opçãoAbrirSeleção;
        private Apresentação.Formulários.Quadro                 quadroSeleção;
        private Apresentação.Formulários.Opção opçãoImprimir;
        protected Opção opçãoExcluír;
        protected Quadro quadro;
        private Opção opçãoMoverAcerto;
        private System.ComponentModel.IContainer                components = null;

        protected Entidades.Pessoa.Pessoa Cliente
        {
            get { return pessoa; }
        }

        protected virtual Entidades.Relacionamento.Relacionamento CriarEntidade(Entidades.Pessoa.Pessoa pessoa)
        {
            throw new Exception("método genérico");
        }

        /// <summary>
        /// Cria novo documento de relacionamento, 
        /// e já abre base-inferior para preenchimento dos dados
        /// </summary>
        protected void Criar()
        {
            AcertoConsignado acerto = EscolherAcerto.QuestionarUsuário(ParentForm, pessoa, true);

            if (acerto == null)
                return;

            UseWaitCursor = true;
            
            // Cria e abre controles de apresentação
            Entidades.Relacionamento.Relacionamento relacionamento = CriarEntidade(pessoa);

            relacionamento.DigitadoPor = Entidades.Pessoa.Funcionário.FuncionárioAtual;
            relacionamento.Data = DadosGlobais.Instância.HoraDataAtual;

            /* Cadastramento é feito quando o primeiro item é relacioando.
             * -- Júlio, 28/10/2006
             */
            //relacionamento.Cadastrar();

            if (acerto.TabelaPreço != null && relacionamento is RelacionamentoAcerto)
                 ((RelacionamentoAcerto) relacionamento).TabelaPreço = acerto.TabelaPreço;

            try
            {
                if (relacionamento is Entidades.Relacionamento.Saída.Saída)
                    acerto.Saídas.Adicionar((Entidades.Relacionamento.Saída.Saída)relacionamento);
                else if (relacionamento is Entidades.Relacionamento.Retorno.Retorno)
                    acerto.Retornos.Adicionar((Entidades.Relacionamento.Retorno.Retorno)relacionamento);
                else
                    throw new NotImplementedException("Falta verificação de tipo de documento para atribuição de acerto.");
            }
            catch (Entidades.Acerto.AcertoConsignado.DocumentoInconsistente erro)
            {
                MessageBox.Show(
                    ParentForm,
                    erro.Message,
                    "Criar novo documento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                BaseInferior novaBase = PrepararBaseConsignado(relacionamento);
                SubstituirBase(novaBase);
            }
            catch (PermissãoNegada erro)
            {
                MessageBox.Show(
                    ParentForm,
                    erro.Message,
                    "Permissão negada",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                if (acerto != null)
                    acerto.Remover(relacionamento);
            }

            UseWaitCursor = false;
        }

        protected virtual BaseEditarRelacionamento CriarBaseConsignado()
        {
            throw new Exception("Método abstrato");
        }

        public BaseConsignado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constrói a base inferior, carregando relacionamentos de um cliente.
        /// </summary>
        /// <param name="cliente">Cadastro do cliente.</param>
        public BaseConsignado(Entidades.Pessoa.Pessoa cliente)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            this.pessoa = cliente;
        }

        void BaseConsignado_DoubleClick(object sender, EventArgs e)
        {
            if (ObterLista().SelectedItems.Count > 0)
                Abrir();
        }

        void BaseConsignado_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (ObterLista().SelectedItems.Count > 0))
                Abrir();
        }


        protected virtual ListaConsignado ObterLista()
        {
            throw new Exception("metodo abstrato");
        }

        public override void AoCarregarCompletamente(Splash splash)
        {
            if (this.DesignMode) return;

            base.AoCarregarCompletamente(splash);

            // Registra os eventos
            ListaConsignado lista = ObterLista();
            lista.SelectedIndexChanged += new EventHandler(lista_SelectedIndexChanged);
            lista.KeyDown += new KeyEventHandler(BaseConsignado_KeyDown);
            lista.DoubleClick += new EventHandler(BaseConsignado_DoubleClick);
        }

        protected override void AoExibir()
        {
            if (this.DesignMode) return;

            base.AoExibir();

            // Recarrega lista, pois pode ter sido modificada.
            ObterLista().Carregar(pessoa);
        }

        void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lista = (ListView)sender;
            quadroSeleção.Visible = (lista.SelectedItems.Count == 1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
    
       
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroRelacionamentos = new Apresentação.Formulários.Quadro();
            this.opçãoNovoRelacionamento = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoMoverAcerto = new Apresentação.Formulários.Opção();
            this.opçãoAbrirSeleção = new Apresentação.Formulários.Opção();
            this.quadroSeleção = new Apresentação.Formulários.Quadro();
            this.opçãoExcluír = new Apresentação.Formulários.Opção();
            this.quadro = new Apresentação.Formulários.Quadro();
            this.esquerda.SuspendLayout();
            this.quadroRelacionamentos.SuspendLayout();
            this.quadroSeleção.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroRelacionamentos);
            this.esquerda.Controls.Add(this.quadroSeleção);
            this.esquerda.Size = new System.Drawing.Size(187, 376);
            this.esquerda.Controls.SetChildIndex(this.quadroSeleção, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroRelacionamentos, 0);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "relacionando para <pessoa>";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = null;
            this.título.Location = new System.Drawing.Point(208, 8);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(576, 70);
            this.título.TabIndex = 7;
            this.título.Título = "Consignado de saída/retorno";
            // 
            // quadroRelacionamentos
            // 
            this.quadroRelacionamentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroRelacionamentos.bInfDirArredondada = true;
            this.quadroRelacionamentos.bInfEsqArredondada = true;
            this.quadroRelacionamentos.bSupDirArredondada = true;
            this.quadroRelacionamentos.bSupEsqArredondada = true;
            this.quadroRelacionamentos.Controls.Add(this.opçãoNovoRelacionamento);
            this.quadroRelacionamentos.Controls.Add(this.opçãoImprimir);
            this.quadroRelacionamentos.Controls.Add(this.opçãoMoverAcerto);
            this.quadroRelacionamentos.Cor = System.Drawing.Color.Black;
            this.quadroRelacionamentos.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRelacionamentos.LetraTítulo = System.Drawing.Color.White;
            this.quadroRelacionamentos.Location = new System.Drawing.Point(7, 13);
            this.quadroRelacionamentos.MostrarBotãoMinMax = false;
            this.quadroRelacionamentos.Name = "quadroRelacionamentos";
            this.quadroRelacionamentos.Size = new System.Drawing.Size(160, 93);
            this.quadroRelacionamentos.TabIndex = 0;
            this.quadroRelacionamentos.Tamanho = 30;
            this.quadroRelacionamentos.Título = "Opções";
            // 
            // opçãoNovoRelacionamento
            // 
            this.opçãoNovoRelacionamento.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovoRelacionamento.Descrição = "Criar documento";
            this.opçãoNovoRelacionamento.Imagem = global::Apresentação.Resource.novo;
            this.opçãoNovoRelacionamento.Location = new System.Drawing.Point(7, 30);
            this.opçãoNovoRelacionamento.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoNovoRelacionamento.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovoRelacionamento.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovoRelacionamento.Name = "opçãoNovoRelacionamento";
            this.opçãoNovoRelacionamento.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovoRelacionamento.TabIndex = 2;
            this.opçãoNovoRelacionamento.Click += new System.EventHandler(this.opçãoNovoRelacionamento_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir...";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 50);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 22);
            this.opçãoImprimir.TabIndex = 4;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoMoverAcerto
            // 
            this.opçãoMoverAcerto.BackColor = System.Drawing.Color.Transparent;
            this.opçãoMoverAcerto.Descrição = "Mover para outro acerto...";
            this.opçãoMoverAcerto.Imagem = global::Apresentação.Resource.Acerto__Pequeno_;
            this.opçãoMoverAcerto.Location = new System.Drawing.Point(7, 70);
            this.opçãoMoverAcerto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoMoverAcerto.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoMoverAcerto.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoMoverAcerto.Name = "opçãoMoverAcerto";
            this.opçãoMoverAcerto.PermitirLiberaçãoRecurso = true;
            this.opçãoMoverAcerto.Privilégio = Entidades.Privilégio.Permissão.MoverDocumentoAcerto;
            this.opçãoMoverAcerto.Size = new System.Drawing.Size(150, 21);
            this.opçãoMoverAcerto.TabIndex = 6;
            this.opçãoMoverAcerto.Click += new System.EventHandler(this.opçãoMoverAcerto_Click);
            // 
            // opçãoAbrirSeleção
            // 
            this.opçãoAbrirSeleção.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAbrirSeleção.Descrição = "Abrir...";
            this.opçãoAbrirSeleção.Imagem = global::Apresentação.Resource.openfolderHS;
            this.opçãoAbrirSeleção.Location = new System.Drawing.Point(7, 30);
            this.opçãoAbrirSeleção.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoAbrirSeleção.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAbrirSeleção.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAbrirSeleção.Name = "opçãoAbrirSeleção";
            this.opçãoAbrirSeleção.Size = new System.Drawing.Size(150, 19);
            this.opçãoAbrirSeleção.TabIndex = 3;
            this.opçãoAbrirSeleção.Click += new System.EventHandler(this.opçãoAbrirSeleção_Click);
            // 
            // quadroSeleção
            // 
            this.quadroSeleção.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroSeleção.bInfDirArredondada = true;
            this.quadroSeleção.bInfEsqArredondada = true;
            this.quadroSeleção.bSupDirArredondada = true;
            this.quadroSeleção.bSupEsqArredondada = true;
            this.quadroSeleção.Controls.Add(this.opçãoAbrirSeleção);
            this.quadroSeleção.Controls.Add(this.opçãoExcluír);
            this.quadroSeleção.Cor = System.Drawing.Color.Black;
            this.quadroSeleção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroSeleção.LetraTítulo = System.Drawing.Color.White;
            this.quadroSeleção.Location = new System.Drawing.Point(7, 112);
            this.quadroSeleção.MostrarBotãoMinMax = false;
            this.quadroSeleção.Name = "quadroSeleção";
            this.quadroSeleção.Size = new System.Drawing.Size(160, 72);
            this.quadroSeleção.TabIndex = 1;
            this.quadroSeleção.Tamanho = 30;
            this.quadroSeleção.Título = "Documento selecionado";
            this.quadroSeleção.Visible = false;
            // 
            // opçãoExcluír
            // 
            this.opçãoExcluír.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluír.Descrição = "Excluir";
            this.opçãoExcluír.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoExcluír.Location = new System.Drawing.Point(7, 50);
            this.opçãoExcluír.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoExcluír.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluír.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluír.Name = "opçãoExcluír";
            this.opçãoExcluír.Size = new System.Drawing.Size(150, 19);
            this.opçãoExcluír.TabIndex = 5;
            this.opçãoExcluír.Visible = false;
            this.opçãoExcluír.Click += new System.EventHandler(this.opçãoExcluír_Click);
            // 
            // quadro
            // 
            this.quadro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro.bInfDirArredondada = false;
            this.quadro.bInfEsqArredondada = false;
            this.quadro.bSupDirArredondada = true;
            this.quadro.bSupEsqArredondada = true;
            this.quadro.Cor = System.Drawing.Color.Black;
            this.quadro.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro.LetraTítulo = System.Drawing.Color.White;
            this.quadro.Location = new System.Drawing.Point(193, 86);
            this.quadro.MostrarBotãoMinMax = false;
            this.quadro.Name = "quadro";
            this.quadro.Size = new System.Drawing.Size(604, 287);
            this.quadro.TabIndex = 8;
            this.quadro.Tamanho = 30;
            this.quadro.Título = "Título";
            // 
            // BaseConsignado
            // 
            this.Controls.Add(this.título);
            this.Controls.Add(this.quadro);
            this.Name = "BaseConsignado";
            this.Size = new System.Drawing.Size(800, 376);
            this.Controls.SetChildIndex(this.quadro, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroRelacionamentos.ResumeLayout(false);
            this.quadroSeleção.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Dá lugar para uma nova base inferior de digitação de consignado.
        /// </summary>
        /// <param name="consignado"></param>
        public BaseEditarRelacionamento PrepararBaseConsignado(Entidades.Relacionamento.Relacionamento consignado)
        {
            BaseEditarRelacionamento novaBase = CriarBaseConsignado();

            novaBase.Abrir(consignado);
            novaBase.TravaAlterada += new BaseEditarRelacionamento.TravaAlteradaHandler(TravaAlterada);

            return novaBase;
        }

        private void Abrir()
        {
            UseWaitCursor = true;
            ListaConsignado lista = ObterLista();

            if (lista.SelectedItems.Count == 1)
            {
                if (this.DesignMode) return;

                Entidades.Relacionamento.Relacionamento consignado = ObterLista().ItemSelecionado;

                SubstituirBase(PrepararBaseConsignado(consignado));
            }
            else
            {
                quadroSeleção.Visible = false;

                MessageBox.Show(
                    ParentForm,
                    "Por favor, selecione antes um documento.",
                    "Relação de Consignado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            UseWaitCursor = false;
        }

        private void opçãoAbrirSeleção_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void opçãoNovoRelacionamento_Click(object sender, EventArgs e)
        {
            Criar();
        }

        private void opçãoExcluír_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual TipoDocumento TipoDocumento
        { get { return TipoDocumento.Desconhecido; } }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            //Impressão janela;

            UseWaitCursor = true;

            List<Entidades.Relacionamento.Relacionamento> listaDocumentos;
                
            ListaConsignado lista = ObterLista();
            listaDocumentos = lista.ObterDocumentosMarcados();

            if (listaDocumentos.Count == 0)
            {
                UseWaitCursor = false;

                MessageBox.Show(
                    ParentForm,
                    "Por favor, selecione antes um documento.",
                    "Relação de Consignado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento))
            {
                dlg.PermitirEscolherPágina = listaDocumentos.Count == 1;

                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    FilaImpressão fila = FilaImpressão.ObterFila(dlg.ControleImpressão, dlg.Impressora);
                    ulong[] códigos = new ulong[listaDocumentos.Count];

                    for (int i = 0; i < listaDocumentos.Count; i++)
                        códigos[i] = (ulong)listaDocumentos[i].Código;

                    fila.Imprimir(códigos, dlg.NúmeroCópias);
                }
            }

            UseWaitCursor = false;
        }

        /// <summary>
        /// Ocorre quando a trava de um relacionamento é alterada
        /// pela interface gráfica.
        /// </summary>
        private void TravaAlterada(BaseEditarRelacionamento sender, Entidades.Relacionamento.RelacionamentoAcerto e, bool vendaTravada)
        {
            ListaConsignado lista = ObterLista();

            lista.AoMudarTrava(e);
        }

        private void opçãoMoverAcerto_Click(object sender, EventArgs e)
        {
            if (ObterLista().ObterDocumentosMarcados().Count == 0)
            {
                MessageBox.Show(
                    ParentForm,
                    "Para mover documentos para um acerto, é necessário marcá-los primeiro.",
                    "Mover para acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AcertoConsignado acerto = EscolherAcerto.QuestionarUsuário(ParentForm, pessoa, true);

            if (acerto == null)
                MessageBox.Show(
                    ParentForm,
                    "Operação cancelada.",
                    "Mover para outro acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (acerto.Acertado)
                MessageBox.Show(
                    ParentForm,
                    "Não é permitido mover documentos para um acerto já encerrado.\n\nOperação cancelada.",
                    "Mover para outro acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int contador = 0;

                AguardeDB.Mostrar();

                try
                {
                    foreach (RelacionamentoAcerto relacionamento in ObterLista().ObterDocumentosMarcados())
                    {
                        if (relacionamento.AcertoConsignado == null || !relacionamento.AcertoConsignado.Equals(acerto))
                        {
                            if (!acerto.Cadastrado)
                                acerto.Cadastrar();

                            if (relacionamento.AcertoConsignado != null)
                                relacionamento.AcertoConsignado.Remover(relacionamento);

                            acerto.Adicionar(relacionamento);
                            contador++;
                            relacionamento.Atualizar();
                        }
                    }

                    AoExibir();
                }
                finally
                {
                    AguardeDB.Fechar();

                    MessageBox.Show(
                        Parent,
                        string.Format("{0} documentos foram movidos para o acerto {1}.",
                        contador, acerto.Código),
                        "Mover para outro acerto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
       }
    }
}