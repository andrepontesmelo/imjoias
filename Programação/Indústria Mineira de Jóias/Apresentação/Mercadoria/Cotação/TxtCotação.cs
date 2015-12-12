using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades;
using Apresentação.Mercadoria.Cotação;

namespace Apresentação.Mercadoria.Cotação
{
    /// <summary>
    /// TxtCotação é o responsável pela obtenção em primeira mão 
    /// dos objetos "Cotação" do contexto pela camada de Apresentação.
    /// Assim que uma cotação é cadastrada, apenas este controle deve disparar o evento. 
    /// Mas antes, ele deve pergutar através de um balão 
    /// para o usuário se pretende ou não utilizar a nova cotação.
    /// </summary>
    public class TxtCotação : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// Serve para informar se a cotação escolhida não é a mais recente
        /// </summary>
        Entidades.Financeiro.Cotação últimaCotação;

        private volatile bool valorDefinido = false;

        /// <summary>
        /// Moeda de trabalho.
        /// </summary>
        private Moeda moeda;

        // Balões
        private BalãoCotaçãoNãoCadastrada balãoNãoCadastrada = null;
        private BalãoCotaçãoDesatualizada balãoDesatualizada = null;

        // Atributos das propriedades
        private bool avisarCotaçõesNãoCadastradas = true;
        private bool avisarCotaçõesDesatualizadas = true;
        private bool avisarNovaCotação = true;
        private bool iniciarValorAtual = true;
        private bool mostrarListaCotações = true;

        // Último evento disparado.
        private Entidades.Financeiro.Cotação últimaEscolha = null;

        /// <summary>
        /// Indica se o contexto e controles flutuantes foram carregados.
        /// Só são carregados quando necessário.
        /// 
        /// Estes controles não são carregados no incio do programa porque:
        /// 1. inicialmente o contexto não pode ser obtido,
        /// 2. os controles não podem ser adicionados ao controle maior-pai,
        /// porque ele ainda não existe ou alguns filhos ainda não existem.
        /// </summary>
        private bool carregado = false;

        // Controles 
        private TxtCotaçãoPainel            painelFlutuante;
        private AMS.TextBox.CurrencyTextBox txt;
        private PictureBox                  picCotação;

        private ToolTip                     toolTipOk;
        private ToolTip                     toolTipDesatualizada;
        private IContainer                  components;

        private Moeda.MoedaSistema? moedaSistema = Moeda.MoedaSistema.Ouro;

        #region Eventos

        /// <summary>
        /// Invoque DispararEscolheuCotação ao invés de EscolheuCotação.
        /// Isto porque deve-se evitar Escolhas repetidas.
        /// </summary>
        public delegate void Escolha(Entidades.Financeiro.Cotação escolha);
        public event Escolha EscolheuCotação;

        #endregion

        #region Propriedades
        
        [Browsable(false), ReadOnly(true)]
        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value;

                if (painelFlutuante != null)
                    painelFlutuante.Moeda = value;

                carregado = false;
                Carregar();
            }
        }

        [Browsable(true), DisplayName("Moeda"), DefaultValue(Moeda.MoedaSistema.Ouro)]
        public Moeda.MoedaSistema? MoedaSistema
        {
            get { return moedaSistema; }
            set
            {
                moedaSistema = value;

                if (!DesignMode)
                {
                    moeda = value.HasValue ? Moeda.ObterMoeda(value.Value) : null;

                    if (painelFlutuante != null)
                        painelFlutuante.Moeda = moeda;
                }
                else
                    txt.Prefix = value.ToString();
            }
        }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return txt.ReadOnly; }
            set
            {
                txt.ReadOnly = value;

                if (painelFlutuante != null)
                    painelFlutuante.Enabled = !value;

                últimaEscolha = null;
            }
        }

        [Browsable(false), DefaultValue(0)]
        public double Valor
        {
            get { return txt.Double; }
            set { txt.Double = value; valorDefinido = true;  }
        }

        /// <summary>
        /// Pegue ou escolha a data para exibição das cotações.
        /// </summary>
        [Browsable(false), DefaultValue(null)]
        public DateTime? Data
        {
            get
            {
                if (DesignMode)
                    return null;
                else
                    return painelFlutuante.Data;
            }
            set
            {
                if (!DesignMode && carregado)
                {
                    //TxtCotaçãoPainel.DefinirDataCallback método;
                    DateTime valor;

                    //método = new TxtCotaçãoPainel.DefinirDataCallback(painelFlutuante.DefinirData);

                    if (value.HasValue)
                        valor = value.Value;
                    else
                        valor = DateTime.Today;

                    //método.BeginInvoke(valor, new AsyncCallback(AoDefinirDataPainel), método);

                    if (painelFlutuante != null)
                        painelFlutuante.DefinirData(valor);
                }
            }
        }

        [DefaultValue(true),
        Description("Avisa se a cotação não está cadastrada.")]
        public bool AvisarCotaçõesNãoCadastradas
        {
            get { return avisarCotaçõesNãoCadastradas; }
            set { avisarCotaçõesNãoCadastradas = value; }
        }

        [DefaultValue(true),
            Description("Avisa se a cotação está desatualizada.")]
        public bool AvisarCotaçõesDesatualizadas
        {
            get { return avisarCotaçõesDesatualizadas; }
            set { avisarCotaçõesDesatualizadas = value; }
        }

        /// <summary>
        /// Avisar quando surgirem novas cotações.
        /// </summary>
        [DefaultValue(true),
            Description("Avisa quando nova cotação é cadastrada, permitindo atualização conforme escolha de usuário.")]
        public bool AvisarNovaCotação
        {
            get { return avisarNovaCotação; }
            set { avisarNovaCotação = value; }
        }

        /// <summary>
        /// Cotação escolhida.
        /// </summary>
        public Entidades.Financeiro.Cotação  Cotação
        {
            get
            {
                Entidades.Financeiro.Cotação  cotação;

                if (painelFlutuante == null)
                    return null;

                cotação = painelFlutuante.CotaçãoSelecionada;

                if (cotação == null)
                    return txt.Double;
                else
                    return cotação;
            }
            set
            {
                if (value != null)
                    AtribuirCotação(value);
            }
        }

        /// <summary>
        /// Determina se o controle deve iniciar com o valor mais atual.
        /// </summary>
        [DefaultValue(true), Description("Determina se o controle deve iniciar com o valor mais atual.")]
        public bool IniciarValorAtual
        {
            get { return iniciarValorAtual; }
            set { iniciarValorAtual = value; }
        }

        /// <summary>
        /// Determina se deve ser exibido a lista de cotações.
        /// </summary>
        [DefaultValue(true), Description("Determina se o controle deve mostrar a lista de cotações.")]
        public bool MostrarListaCotações
        {
            get { return mostrarListaCotações; }
            set { mostrarListaCotações = value; }
        }

        #endregion

        /// <summary>
        /// Constrói o controle
        /// </summary>
        public TxtCotação()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt = new AMS.TextBox.CurrencyTextBox();
            this.toolTipOk = new System.Windows.Forms.ToolTip(this.components);
            this.picCotação = new System.Windows.Forms.PictureBox();
            this.toolTipDesatualizada = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCotação)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.AllowNegative = true;
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Flags = 7680;
            this.txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.MaxWholeDigits = 9;
            this.txt.Name = "txt";
            this.txt.RangeMax = 1.7976931348623157E+308;
            this.txt.RangeMin = -1.7976931348623157E+308;
            this.txt.Size = new System.Drawing.Size(145, 20);
            this.txt.TabIndex = 0;
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.Click += new System.EventHandler(this.txt_Click);
            this.txt.Leave += new System.EventHandler(this.OnLeave);
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conjunto_keyDown);
            // 
            // toolTipOk
            // 
            this.toolTipOk.ToolTipTitle = "Cotação do ouro";
            // 
            // picCotação
            // 
            this.picCotação.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCotação.BackColor = System.Drawing.SystemColors.Window;
            this.picCotação.Location = new System.Drawing.Point(126, 1);
            this.picCotação.Name = "picCotação";
            this.picCotação.Size = new System.Drawing.Size(18, 18);
            this.picCotação.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCotação.TabIndex = 1;
            this.picCotação.TabStop = false;
            this.toolTipOk.SetToolTip(this.picCotação, "A cotação do ouro encontra-se atualizada!");
            this.toolTipDesatualizada.SetToolTip(this.picCotação, "Atenção! A cotação encontra-se DESATUALIZADA!");
            // 
            // toolTipDesatualizada
            // 
            this.toolTipDesatualizada.Active = false;
            this.toolTipDesatualizada.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipDesatualizada.ToolTipTitle = "Cotação do ouro";
            // 
            // TxtCotação
            // 
            this.Controls.Add(this.picCotação);
            this.Controls.Add(this.txt);
            this.Name = "TxtCotação";
            this.Size = new System.Drawing.Size(145, 20);
            this.Load += new System.EventHandler(this.TxtCotação_Load);
            this.Leave += new System.EventHandler(this.OnLeave);
            this.Resize += new System.EventHandler(this.TxtCotação_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picCotação)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Libera recursos.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (this.TopLevelControl != null)
                {
                    this.TopLevelControl.SuspendLayout();
                    this.TopLevelControl.Controls.Remove(painelFlutuante);
                    this.TopLevelControl.ResumeLayout();
                }

                if (balãoDesatualizada != null)
                {
                    balãoDesatualizada.Dispose();
                    balãoDesatualizada = null;
                }

                if (balãoNãoCadastrada != null)
                {
                    balãoNãoCadastrada.Dispose();
                    balãoNãoCadastrada = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// O painel é flutuante porque está no controle toppest.
        /// portanto, é necessário posiciona-lo corretamente uma vez
        /// que os valores de posição trabalhados são relativos, e portanto,
        /// diferentes.
        /// </summary>
        private void ReposicionarPainelFlutuante()
        {
            if (ParentForm == null)
                return;

#if DEBUG
            if (painelFlutuante == null)
                throw new Exception("Não posso reposicionar o painel nulo");
#endif

            Point pontoZeroRaíz;	// Zero absoluto do formulario toppest
            Point pontoZeroMeu;		// Zero absoluto do formulario top
            Point posiçãoPanel;		// É o novoZero um pouco para direita
            Point novoZero;			/* Seu zero corresponde à coordenada relativa
									 * do top em relação ao toppest.
									 */

            // Obter coordenada relativa
            pontoZeroRaíz =
                this.ParentForm.PointToScreen(new Point(0, 0));

            pontoZeroMeu =
                this.PointToScreen(new Point(0, 0));

            // novoZero = pontoZeromeu - pontoZeroRaíz;
            novoZero = pontoZeroMeu;
            novoZero.Offset(-1 * pontoZeroRaíz.X, -1 * pontoZeroRaíz.Y);

            // Abaixa
            posiçãoPanel = novoZero;
            posiçãoPanel.Offset(0, this.Height);

            painelFlutuante.Bounds = new Rectangle
                (posiçãoPanel, new Size(this.Width, painelFlutuante.Height));

            painelFlutuante.BringToFront();
        }


        /// <summary>
        /// Carrega controles que compões o painelFlutuante.
        /// Caso o usuário deseje escolher a propridade, this.Data,
        /// ele deve chamar o Carregar antes.
        /// Veja comentário de 'carregado' no início do arquivo.
        /// </summary>
        private void Carregar()
        {
            if (DesignMode || Acesso.Comum.Usuários.UsuárioAtual == null || carregado)
                return;

            try
            {
                if (moeda == null && moedaSistema.HasValue)
                    moeda = Moeda.ObterMoeda(moedaSistema.Value);
                else if (moeda == null)
                    throw new Exception("Moeda é nula!");
            }
            catch (Exception e)
            {
                try
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                }
                catch { }

                MessageBox.Show(e.ToString());
            }
            
            try
            {
                if (painelFlutuante == null)
                    ConstruirPainel();

                carregado = true;

                if (moeda != null)
                {
                    últimaCotação = Entidades.Financeiro.Cotação.ObterCotaçãoVigente(moeda);

                    if (iniciarValorAtual && (txt.Double == 0 || !valorDefinido))
                        AtribuirCotação(últimaCotação);
                }
                else
                    últimaCotação = null;
            }
            catch (Entidades.Financeiro.Cotação.CotaçãoInexistente)
            {
                txt.Text = "";

                MessageBox.Show(
                    ParentForm,
                    "Não existe nenhuma cotação cadastrada para a moeda " + moeda.Nome + ".",
                    "Cotação - " + moeda.Nome,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception e)
            {
                try
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                }
                catch { }

                MessageBox.Show("Não foi possível carregar as cotações. O seguinte erro ocorreu:\n\n" + e.ToString(),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode && TopLevelControl != null)
            {
                Carregar();

                this.TopLevelControl.SuspendLayout();
                this.TopLevelControl.Controls.Add(painelFlutuante);
                this.TopLevelControl.ResumeLayout();

                ReposicionarPainelFlutuante();
            }
        }

        /// <summary>
        /// Constrói painel a ser exibido com cotações.
        /// </summary>
        private void ConstruirPainel()
        {
            try
            {
                painelFlutuante = new TxtCotaçãoPainel();
                painelFlutuante.Width = this.Width;
                painelFlutuante.Visible = false;
                painelFlutuante.Leave += new EventHandler(OnLeave);
                painelFlutuante.ListaDoubleClick += new EventHandler(lista_DoubleClick);
                painelFlutuante.Moeda = moeda;

                if (TopLevelControl == null)
                    return;
            }
            catch (Exception e)
            {
                try
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                }
                catch { }

                MessageBox.Show("Não será possível exibir as cotações já cadastradas.\n\n" + e.ToString(),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private delegate void EsconderPainelCallBack();

        /// <summary>
        /// Esconde o painel
        /// </summary>
        private void EsconderPainel()
        {
            if (txt.InvokeRequired)
            {
                EsconderPainelCallBack método = new EsconderPainelCallBack(EsconderPainel);
                txt.BeginInvoke(método);

            }
            else
            {
                Entidades.Financeiro.Cotação escolha = Cotação;

                if (escolha == null)
                    txt.Text = "";
                else
                    txt.Double = escolha.Valor;

                txt.SelectionStart = txt.Text.Length;

                painelFlutuante.Visible = false;
            }
        }

        /// <summary>
        /// Ocorre ao definir a data no painel.
        /// </summary>
        /// <param name="resultado"></param>
        private void AoDefinirDataPainel(IAsyncResult resultado)
        {
            TxtCotaçãoPainel.DefinirDataCallback método;

            método = (TxtCotaçãoPainel.DefinirDataCallback)resultado.AsyncState;

            método.EndInvoke(resultado);

            if (painelFlutuante.CotaçãoSelecionada != null || txt.Double <= 0)
                painelFlutuante.SelecionarÚltimo();
        }

        /// <summary>
        /// Ocorre ao pressionar uma tecla.
        /// </summary>
        private void conjunto_keyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (ReadOnly)
                return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    painelFlutuante.Visible = false;
                    e.Handled = true;
                    return;

                case Keys.Enter:
                    DispararEscolheuCotação();
                    EsconderPainel();
                    e.Handled = true;
                    return;

                case Keys.Down:
                    painelFlutuante.DescerSeleção();
                    e.Handled = true;
                    break;

                case Keys.Up:
                    painelFlutuante.SubirSeleção();
                    e.Handled = true;
                    break;

                case Keys.Delete:
                    // Apaga tudo da txt caso esteja no início do campo
                    if (txt.SelectionStart <= 3)
                        txt.Text = "";

                    break;
            }

            //if (txt.Focused)
            painelFlutuante.Visible = mostrarListaCotações;
        }

        /// <summary>
        /// Ocorre ao mudar o tamanho do controle
        /// </summary>
        private void TxtCotação_Resize(object sender, EventArgs e)
        {
            if (this.Height > 20)
                this.Height = 20;

            // Painel flutuante é nulo em design mode
            if (painelFlutuante != null)
            {
                painelFlutuante.Width = txt.Width = this.Width;
                ReposicionarPainelFlutuante();
            }
        }

        /// <summary>
        /// Ocorre ao entrar no TextBox
        /// </summary>
        private void txt_Enter(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                if (painelFlutuante == null)
                    Carregar();

                painelFlutuante.BringToFront();
                painelFlutuante.Visible = mostrarListaCotações;

                txt.ForeColor = SystemColors.ControlText;
                txt.BackColor = SystemColors.Window;

                picCotação.Visible = false;
            }
        }

        /// <summary>
        /// Ocorre ao alterar o conteúdo
        /// </summary>
        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (painelFlutuante != null && !ReadOnly)
                painelFlutuante.Selecionar(txt.Double);
        }

        /// <summary>
        /// Ocorre ao clicar.
        /// </summary>
        private void txt_Click(object sender, EventArgs e)
        {
            if (carregado && !ReadOnly)
                painelFlutuante.Visible = mostrarListaCotações;
        }

        /// <summary>
        /// Ocorre ao alterar seleção na lista.
        /// </summary>
        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidades.Financeiro.Cotação escolha = this.Cotação;

            /* As 2 verificações antes de atribuir o txt.Text resolvem
             * um possível loop infinito. Se sempre que a seleção da lista mudar
             * o txt também mudar, e sempre que o txt mudar a seleção mudar,
             * então o programa trava. A idéia é só mudar o outro caso seja 
             * realmente necessário. André, 27/01/05
             */
            if (escolha == null)
            {
                if (txt.Double <= 0)
                    return;

                txt.Text = "";
            }
            else if (txt.Double == escolha.Valor)
                return;

            txt.Double = escolha.Valor;

            IndicarCotação();
        }

        /// <summary>
        /// Ocorre ao clicar duas vezes na lista.
        /// </summary>
        private void lista_DoubleClick(object sender, EventArgs e)
        {
            DispararEscolheuCotação();
            EsconderPainel();
        }

        /// <summary>
        /// Dispara a nova cotação escolhida só não já tiver sido disparada.
        /// </summary>
        private void DispararEscolheuCotação()
        {
            Entidades.Financeiro.Cotação escolha = Cotação;

            if (escolha != null)
                txt.Double = escolha.Valor;

            if ((escolha != últimaEscolha) && (EscolheuCotação != null))
                EscolheuCotação(escolha);

            últimaEscolha = escolha;

            IndicarCotação();
        }

        /// <summary>
        /// Ocorre quando o controle ou um de seus componentes (tais como
        /// o painel flutuante) perde seu foco.
        /// </summary>
        private void OnLeave(object sender, System.EventArgs e)
        {
            if (!Focused && !ReadOnly)
            {
                EsconderPainel();
                DispararEscolheuCotação();

                picCotação.Visible = true;
            }
        }

        /// <summary>
        /// Se o objeto está focado.
        /// </summary>
        public override bool Focused
        {
            get
            {
                return base.Focused || painelFlutuante.Focused;
            }
        }

        /// <summary>
        /// Indica se a cotação é atual, não cadastrada ou antiga.
        /// </summary>
        private void IndicarCotação()
        {
            // Varejo não trabalha com cotação
            if (moeda.Código == 4)
                return;

            Entidades.Financeiro.Cotação escolha = Cotação;

            if (escolha != null)
            {
                if (!escolha.Cadastrado)
                    SinalizarCotaçãoNãoCadastrada();
                else if (Data.HasValue) 
                {
                    Entidades.Financeiro.Cotação[] cotações = 
                        Entidades.Financeiro.Cotação.ObterListaCotaçõesAtéDia(moeda, Data.Value);

                    if (cotações.Length > 0)
                    {
                        if (escolha.Valor != cotações[0].Valor)
                            SinalizarCotaçãoDesatualizada();
                    }
                }
                else
                    SinalizarCotaçãoAtualizada();
            }
        }

        /// <summary>
        /// Sinaliza que a cotação entrada encontra-se atualizada.
        /// </summary>
        private void SinalizarCotaçãoAtualizada()
        {
            txt.ForeColor = SystemColors.ControlText;
            txt.BackColor = SystemColors.Window;

            picCotação.Image = moeda.Ícone ?? Resource.ok;
            toolTipOk.Active = true;
            toolTipDesatualizada.Active = false;
        }

        /// <summary>
        /// Sinaliza que a cotação entrada encontra-se desatualizada.
        /// </summary>
        private void SinalizarCotaçãoDesatualizada()
        {
            if (avisarCotaçõesDesatualizadas)
                MostrarBalãoDesatualizada();

            txt.ForeColor = Color.FromKnownColor(KnownColor.Red);
            txt.BackColor = Color.FromKnownColor(KnownColor.White);

            picCotação.Image = Resource.error;
            toolTipOk.Active = false;
            toolTipDesatualizada.Active = true;
        }

        /// <summary>
        /// Sinaliza que a cotação entrada encontra-se não cadastrada.
        /// </summary>
        private void SinalizarCotaçãoNãoCadastrada()
        {
            if (avisarCotaçõesNãoCadastradas)
                MostrarBalãoNãoCadastrada();

            txt.ForeColor = Color.FromKnownColor(KnownColor.White);
            txt.BackColor = Color.FromKnownColor(KnownColor.Red);

            picCotação.Image = Resource.error;
            toolTipOk.Active = false;
            toolTipDesatualizada.Active = true;
        }

        /// <summary>
        /// Mostra balão informando que a cotação não encontra-se
        /// cadastrada.
        /// </summary>
        private void MostrarBalãoNãoCadastrada()
        {
            if (balãoNãoCadastrada == null)
                balãoNãoCadastrada = new BalãoCotaçãoNãoCadastrada();

            balãoNãoCadastrada.ShowBalloon(txt);
        }

        /// <summary>
        /// Mostra balão informando que a cotação encontra-se
        /// desatualizada.
        /// </summary>
        private void MostrarBalãoDesatualizada()
        {
            if (balãoDesatualizada == null)
                balãoDesatualizada = new BalãoCotaçãoDesatualizada();

            balãoDesatualizada.ShowBalloon(txt);
        }

        /// <summary>
        /// Já escolhe alguma cotação da data específica, caso exista.
        /// </summary>
        /// <param name="data"></param>
        public void AbrirCotaçãoDaData(DateTime data)
        {
            Data = data;
            painelFlutuante.SelecionarÚltimo();
        }

        ///// <summary>
        ///// Ocorre quando uma cotação executa alguma ação.
        ///// </summary>
        ///// <param name="sujeito">Cotação.</param>
        ///// <param name="ação">Ação realizada.</param>
        //private void ObservandoCotações(ISujeito sujeito, int ação, object objeto)
        //{
        //    ICotação cotação = (ICotação) sujeito;

        //    switch ((AçãoCotação) ação)
        //    {
        //        case AçãoCotação.NovaCotação:
        //            últimaCotação = cotação.Entidade.Data;

        //            if (avisarNovaCotação)
        //                PerguntarAtualização(cotação);
        //            break;
        //    }
        //}

        ///// <summary>
        ///// Pergunta se o usuário deseja atualizar para
        ///// a cotação recentemente cadastrada.
        ///// </summary>
        //private void PerguntarAtualização(ICotação cotação)
        //{
        //    Thread thread;

        //    thread = new Thread(new ParameterizedThreadStart(PerguntarAtualizaçãoAssíncrono));
        //    thread.Name = "TxtCotação - perguntar por atualização";
        //    thread.Start(cotação);
        //}

        ///// <summary>
        ///// Chamada para questionar usuário assincronamente
        ///// se ele deseja atualizar a cotação.
        ///// </summary>
        ///// <param name="obj">ICotação</param>
        //private void PerguntarAtualizaçãoAssíncrono(object obj)
        //{
        //    ICotação cotação = (ICotação)obj;
        //    ClientSponsor sponsor = new ClientSponsor();

        //    sponsor.Register((MarshalByRefObject)cotação);

        //    using (BalãoCotaçãoNova dlg = new BalãoCotaçãoNova(cotação))
        //    {
        //        if (dlg.ShowDialog(this) == DialogResult.Yes)
        //            AtribuirCotação(cotação);
        //    }

        //    sponsor.Unregister((MarshalByRefObject)cotação);
        //}

        private delegate void AtribuirCotaçãoCallback(Entidades.Financeiro.Cotação cotação);

        /// <summary>
        /// Atribui uma cotação ao TxtCotação.
        /// </summary>
        /// <param name="cotação">Cotação a ser atribuída.</param>
        private void AtribuirCotação(Entidades.Financeiro.Cotação cotação)
        {
            if (painelFlutuante == null)
                Carregar();

            if (painelFlutuante.InvokeRequired)
            {
                AtribuirCotaçãoCallback método = new AtribuirCotaçãoCallback(AtribuirCotação);

                painelFlutuante.BeginInvoke(método, cotação);
            }
            else
            {
                txt.Double = cotação.Valor;
                painelFlutuante.CotaçãoSelecionada = cotação;

                DispararEscolheuCotação();
            }
        }


        private void TxtCotação_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Carregar();
            }
            else
            {
                txt.Prefix = moedaSistema.ToString();
            }
        }

        ///// <summary>
        ///// Pergunta se o usuário deseja atualizar para
        ///// a cotação recentemente cadastrada.
        ///// </summary>
        //private void PerguntarAtualização(Entidades.Financeiro.Cotação cotação)
        //{
        //    Thread thread;

        //    thread = new Thread(new ParameterizedThreadStart(PerguntarAtualizaçãoAssíncrono));
        //    thread.Name = "TxtCotação - perguntar por atualização";
        //    thread.IsBackground = true;
        //    thread.Start(cotação);
        //}


        ///// <summary>
        ///// Chamada para questionar usuário assincronamente
        ///// se ele deseja atualizar a cotação.
        ///// </summary>
        ///// <param name="obj">ICotação</param>
        //private void PerguntarAtualizaçãoAssíncrono(object obj)
        //{
        //    Entidades.Financeiro.Cotação cotação = (Entidades.Financeiro.Cotação)obj;

        //    using (BalãoCotaçãoNova dlg = new BalãoCotaçãoNova(cotação))
        //    {
        //        if (dlg.ShowDialog(this) == DialogResult.Yes)
        //            AtribuirCotação(cotação);
        //    }
        //}

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* O padrão da cultura atual é utilizar virgula. 
             * No entanto, os funcionários utilizam o ponto do 
             * teclado numérico.
             */

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
                e.Handled = false;
            }
        }

        /// <summary>
        /// Deixa o TxtCotação vazio.
        /// </summary>
        public void Limpar()
        {
            txt.Text = "";
        }
    }
}
