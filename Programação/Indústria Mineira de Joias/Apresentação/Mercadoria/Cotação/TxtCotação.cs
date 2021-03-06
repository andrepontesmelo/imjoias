using Entidades;
using Entidades.Configura��o;
using Entidades.Moedas;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Cota��o
{
    public class TxtCota��o : UserControl
    {
        Entidades.Financeiro.Cota��o �ltimaCota��o;

        private Moeda moeda;

        private Bal�oCota��oN�oCadastrada bal�oN�oCadastrada = null;
        private Bal�oCota��oDesatualizada bal�oDesatualizada = null;

        private bool avisarCota��esN�oCadastradas = true;
        private bool avisarCota��esDesatualizadas = true;
        private bool avisarNovaCota��o = true;
        private bool iniciarValorAtual = true;
        private bool mostrarListaCota��es = true;

        private Entidades.Financeiro.Cota��o �ltimaEscolha = null;

        private bool carregado = false;

        private TxtCota��oPainel painelFlutuante;
        private AMS.TextBox.CurrencyTextBox txt;
        private PictureBox picCota��o;

        private ToolTip toolTipOk;
        private ToolTip toolTipDesatualizada;
        private IContainer components;

        private MoedaSistema? moedaSistema = Entidades.Moedas.MoedaSistema.Ouro;

        public delegate void Escolha(Entidades.Financeiro.Cota��o escolha);
        public event Escolha EscolheuCota��o;

        private bool ValorDefinido => Valor != 0;

        [Browsable(false), ReadOnly(true)]
        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value;

                if (painelFlutuante != null)
                    painelFlutuante.Moeda = value;
                else
                    Carregar();
                
            }
        }

        [Browsable(true), DisplayName("Moeda"), DefaultValue(Entidades.Moedas.MoedaSistema.Ouro)]
        public MoedaSistema? MoedaSistema
        {
            get { return moedaSistema; }
            set
            {
                moedaSistema = value;

                if (!DadosGlobais.ModoDesenho)
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

                �ltimaEscolha = null;
            }
        }

        [Browsable(false), DefaultValue(0)]
        public double Valor
        {
            get { return txt.Double; }
            set { txt.Double = value;  }
        }

        [Browsable(false), DefaultValue(null)]
        public DateTime? Data
        {
            get
            {
                if (DadosGlobais.ModoDesenho)
                    return null;
                else
                    return painelFlutuante.Data;
            }
            set
            {
                DateTime valor;

                if (value.HasValue)
                    valor = value.Value;
                else
                    valor = DateTime.Today;

                if (painelFlutuante != null)
                    painelFlutuante.DefinirData(valor);
            }
        }

        [DefaultValue(true),
        Description("Avisa se a cota��o n�o est� cadastrada.")]
        public bool AvisarCota��esN�oCadastradas
        {
            get { return avisarCota��esN�oCadastradas; }
            set { avisarCota��esN�oCadastradas = value; }
        }

        [DefaultValue(true),
            Description("Avisa se a cota��o est� desatualizada.")]
        public bool AvisarCota��esDesatualizadas
        {
            get { return avisarCota��esDesatualizadas; }
            set { avisarCota��esDesatualizadas = value; }
        }

        [DefaultValue(true),
            Description("Avisa quando nova cota��o � cadastrada, permitindo atualiza��o conforme escolha de usu�rio.")]
        public bool AvisarNovaCota��o
        {
            get { return avisarNovaCota��o; }
            set { avisarNovaCota��o = value; }
        }

        public Entidades.Financeiro.Cota��o  Cota��o
        {
            get
            {
                Entidades.Financeiro.Cota��o  cota��o;

                if (painelFlutuante == null)
                    return null;

                cota��o = painelFlutuante.Cota��oSelecionada;

                if (cota��o == null)
                    return txt.Double;
                else
                    return cota��o;
            }
            set
            {
                if (value != null)
                    AtribuirCota��o(value);
            }
        }

        [DefaultValue(true), Description("Determina se o controle deve iniciar com o valor mais atual.")]
        public bool IniciarValorAtual
        {
            get { return iniciarValorAtual; }
            set { iniciarValorAtual = value; }
        }

        [DefaultValue(true), Description("Determina se o controle deve mostrar a lista de cota��es.")]
        public bool MostrarListaCota��es
        {
            get { return mostrarListaCota��es; }
            set { mostrarListaCota��es = value; }
        }

        /// <summary>
        /// Constr�i o controle
        /// </summary>
        public TxtCota��o()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt = new AMS.TextBox.CurrencyTextBox();
            this.toolTipOk = new System.Windows.Forms.ToolTip(this.components);
            this.picCota��o = new System.Windows.Forms.PictureBox();
            this.toolTipDesatualizada = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCota��o)).BeginInit();
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
            this.toolTipOk.ToolTipTitle = "Cota��o do ouro";
            // 
            // picCota��o
            // 
            this.picCota��o.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCota��o.BackColor = System.Drawing.SystemColors.Window;
            this.picCota��o.Location = new System.Drawing.Point(126, 1);
            this.picCota��o.Name = "picCota��o";
            this.picCota��o.Size = new System.Drawing.Size(18, 18);
            this.picCota��o.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCota��o.TabIndex = 1;
            this.picCota��o.TabStop = false;
            this.toolTipOk.SetToolTip(this.picCota��o, "A cota��o do ouro encontra-se atualizada!");
            this.toolTipDesatualizada.SetToolTip(this.picCota��o, "Aten��o! A cota��o encontra-se DESATUALIZADA!");
            // 
            // toolTipDesatualizada
            // 
            this.toolTipDesatualizada.Active = false;
            this.toolTipDesatualizada.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipDesatualizada.ToolTipTitle = "Cota��o do ouro";
            // 
            // TxtCota��o
            // 
            this.Controls.Add(this.picCota��o);
            this.Controls.Add(this.txt);
            this.Name = "TxtCota��o";
            this.Size = new System.Drawing.Size(145, 20);
            this.Load += new System.EventHandler(this.TxtCota��o_Load);
            this.Leave += new System.EventHandler(this.OnLeave);
            this.Resize += new System.EventHandler(this.TxtCota��o_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picCota��o)).EndInit();
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

                if (bal�oDesatualizada != null)
                {
                    bal�oDesatualizada.Dispose();
                    bal�oDesatualizada = null;
                }

                if (bal�oN�oCadastrada != null)
                {
                    bal�oN�oCadastrada.Dispose();
                    bal�oN�oCadastrada = null;
                }
            }
            base.Dispose(disposing);
        }

        private void ReposicionarPainelFlutuante()
        {
#if DEBUG
            if (painelFlutuante == null)
                throw new Exception("N�o posso reposicionar o painel nulo");
#endif

            Point pontoZeroRa�z;	// Zero absoluto do formulario toppest
            Point pontoZeroMeu;		// Zero absoluto do formulario top
            Point posi��oPanel;		// � o novoZero um pouco para direita
            Point novoZero;			/* Seu zero corresponde � coordenada relativa
									 * do top em rela��o ao toppest.
									 */

            // Obter coordenada relativa
            if (ParentForm != null)
                pontoZeroRa�z = ParentForm.PointToScreen(new Point(0, 0));
            else
                pontoZeroRa�z = Parent.PointToScreen(new Point(0, 0));

            pontoZeroMeu =
                this.PointToScreen(new Point(0, 0));

            // novoZero = pontoZeromeu - pontoZeroRa�z;
            novoZero = pontoZeroMeu;
            novoZero.Offset(-1 * pontoZeroRa�z.X, -1 * pontoZeroRa�z.Y);

            // Abaixa e para esquerda
            posi��oPanel = novoZero;
            posi��oPanel.Offset(-10, this.Height);

            painelFlutuante.Bounds = new Rectangle
                (posi��oPanel, new Size(this.Width + 20, painelFlutuante.Height));

            painelFlutuante.BringToFront();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DadosGlobais.ModoDesenho && TopLevelControl != null)
            {
                Carregar();

                this.TopLevelControl.SuspendLayout();
                this.TopLevelControl.Controls.Add(painelFlutuante);
                this.TopLevelControl.ResumeLayout();

                ReposicionarPainelFlutuante();
            }
        }

        public void Carregar()
        {
            if (DadosGlobais.ModoDesenho || carregado)
                return;

            DefinirMoeda();
            ConstruirPainelComCota��o();

            if (!DadosGlobais.ModoDesenho && TopLevelControl != null)
            {
                this.TopLevelControl.SuspendLayout();
                this.TopLevelControl.Controls.Add(painelFlutuante);
                this.TopLevelControl.ResumeLayout();

                ReposicionarPainelFlutuante();
            }

            carregado = true;
            painelFlutuante.CargaInicial();
        }

        private void ConstruirPainelComCota��o()
        {
            try
            {
                if (painelFlutuante == null)
                    ConstruirPainel();

                if (moeda != null)
                {
                    �ltimaCota��o = Entidades.Financeiro.Cota��o.ObterCota��oVigente(moeda);

                    if (iniciarValorAtual && !ValorDefinido)
                        AtribuirCota��o(�ltimaCota��o);
                }
                else
                    �ltimaCota��o = null;
            }
            catch (Entidades.Financeiro.Cota��o.Cota��oInexistente)
            {
                txt.Text = "";

                MessageBox.Show(
                    ParentForm,
                    "N�o existe nenhuma cota��o cadastrada para a moeda " + moeda.Nome + ".",
                    "Cota��o - " + moeda.Nome,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception e)
            {
                try
                {
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                }
                catch { }

                MessageBox.Show("N�o foi poss�vel carregar as cota��es. O seguinte erro ocorreu:\n\n" + e.ToString(),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DefinirMoeda()
        {
            try
            {
                if (moeda == null && moedaSistema.HasValue)
                    moeda = Moeda.ObterMoeda(moedaSistema.Value);
                else if (moeda == null)
                    throw new Exception("Moeda � nula!");
            }
            catch (Exception e)
            {
                try
                {
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                }
                catch { }

                MessageBox.Show(e.ToString());
            }
        }


        /// <summary>
        /// Constr�i painel a ser exibido com cota��es.
        /// </summary>
        private void ConstruirPainel()
        {
            try
            {
                painelFlutuante = new TxtCota��oPainel();
                painelFlutuante.Width = this.Width + 20;
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
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                }
                catch { }

                MessageBox.Show("N�o ser� poss�vel exibir as cota��es j� cadastradas.\n\n" + e.ToString(),
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
                EsconderPainelCallBack m�todo = new EsconderPainelCallBack(EsconderPainel);
                txt.BeginInvoke(m�todo);

            }
            else
            {
                Entidades.Financeiro.Cota��o escolha = Cota��o;

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
            TxtCota��oPainel.DefinirDataCallback m�todo;

            m�todo = (TxtCota��oPainel.DefinirDataCallback)resultado.AsyncState;

            m�todo.EndInvoke(resultado);

            if (painelFlutuante.Cota��oSelecionada != null || txt.Double <= 0)
                painelFlutuante.SelecionarPrimeiro();
        }

        /// <summary>
        /// Ocorre ao pressionar uma tecla.
        /// </summary>
        private void conjunto_keyDown(object sender, KeyEventArgs e)
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
                    DispararEscolheuCota��o();
                    EsconderPainel();
                    e.Handled = true;
                    return;

                case Keys.Down:
                    painelFlutuante.DescerSele��o();
                    e.Handled = true;
                    break;

                case Keys.Up:
                    painelFlutuante.SubirSele��o();
                    e.Handled = true;
                    break;

                case Keys.Delete:
                    // Apaga tudo da txt caso esteja no in�cio do campo
                    if (txt.SelectionStart <= 3)
                        txt.Text = "";

                    break;
            }

            painelFlutuante.Visible = mostrarListaCota��es;
        }

        /// <summary>
        /// Ocorre ao mudar o tamanho do controle
        /// </summary>
        private void TxtCota��o_Resize(object sender, EventArgs e)
        {
            if (this.Height > 20)
                this.Height = 20;

            if (painelFlutuante != null)
            {
                painelFlutuante.Width = txt.Width = this.Width + 20;
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
                painelFlutuante.BringToFront();
                painelFlutuante.Visible = mostrarListaCota��es;

                txt.ForeColor = SystemColors.ControlText;
                txt.BackColor = SystemColors.Window;

                picCota��o.Visible = false;
            }
        }

        /// <summary>
        /// Ocorre ao alterar o conte�do
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
                painelFlutuante.Visible = mostrarListaCota��es;
        }

        /// <summary>
        /// Ocorre ao alterar sele��o na lista.
        /// </summary>
        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidades.Financeiro.Cota��o escolha = this.Cota��o;

            if (escolha == null)
            {
                if (txt.Double <= 0)
                    return;

                txt.Text = "";
            }
            else if (txt.Double == escolha.Valor)
                return;

            txt.Double = escolha.Valor;

            IndicarCota��o();
        }

        /// <summary>
        /// Ocorre ao clicar duas vezes na lista.
        /// </summary>
        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (!carregado)
                return;
            
            DispararEscolheuCota��o();
            EsconderPainel();
        }

        /// <summary>
        /// Dispara a nova cota��o escolhida s� n�o j� tiver sido disparada.
        /// </summary>
        private void DispararEscolheuCota��o()
        {
            Entidades.Financeiro.Cota��o escolha = Cota��o;

            if (escolha != null)
                txt.Double = escolha.Valor;

            if ((escolha != �ltimaEscolha) && (EscolheuCota��o != null))
                EscolheuCota��o(escolha);

            �ltimaEscolha = escolha;

            IndicarCota��o();
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
                DispararEscolheuCota��o();

                picCota��o.Visible = true;
            }
        }

        /// <summary>
        /// Se o objeto est� focado.
        /// </summary>
        public override bool Focused
        {
            get
            {
                return base.Focused || painelFlutuante.Focused;
            }
        }

        /// <summary>
        /// Indica se a cota��o � atual, n�o cadastrada ou antiga.
        /// </summary>
        private void IndicarCota��o()
        {
            if (!Enabled)
                return;

            if (moeda.C�digo == (uint) Entidades.Moedas.MoedaSistema.OuroVarejo)
                return;

            Entidades.Financeiro.Cota��o escolha = Cota��o;

            if (escolha != null)
            {
                if (!escolha.Cadastrado)
                {
                    SinalizarCota��oN�oCadastrada();
                    return;
                }
                else if (Data.HasValue)
                {
                    Entidades.Financeiro.Cota��o[] cota��es =
                        Entidades.Financeiro.Cota��o.ObterListaCota��esAt�Dia(moeda, Data.Value);

                    if (cota��es.Length > 0 && escolha.Valor != cota��es[0].Valor)
                    {
                        SinalizarCota��oDesatualizada();
                        return;
                    }
                }
            }

            SinalizarCota��oAtualizada();
        }

        /// <summary>
        /// Sinaliza que a cota��o entrada encontra-se atualizada.
        /// </summary>
        private void SinalizarCota��oAtualizada()
        {
            txt.ForeColor = SystemColors.ControlText;
            txt.BackColor = SystemColors.Window;

            picCota��o.Image = moeda.�cone ?? Resource.ok;
            toolTipOk.Active = true;
            toolTipDesatualizada.Active = false;
        }

        /// <summary>
        /// Sinaliza que a cota��o entrada encontra-se desatualizada.
        /// </summary>
        private void SinalizarCota��oDesatualizada()
        {
            if (avisarCota��esDesatualizadas)
                MostrarBal�oDesatualizada();

            txt.ForeColor = Color.FromKnownColor(KnownColor.Red);
            txt.BackColor = Color.FromKnownColor(KnownColor.White);

            picCota��o.Image = Resource.error;
            toolTipOk.Active = false;
            toolTipDesatualizada.Active = true;
        }

        /// <summary>
        /// Sinaliza que a cota��o entrada encontra-se n�o cadastrada.
        /// </summary>
        private void SinalizarCota��oN�oCadastrada()
        {
            if (avisarCota��esN�oCadastradas)
                MostrarBal�oN�oCadastrada();

            txt.ForeColor = Color.FromKnownColor(KnownColor.White);
            txt.BackColor = Color.FromKnownColor(KnownColor.Red);

            picCota��o.Image = Resource.error;
            toolTipOk.Active = false;
            toolTipDesatualizada.Active = true;
        }

        private void MostrarBal�oN�oCadastrada()
        {
            if (bal�oN�oCadastrada == null)
                bal�oN�oCadastrada = new Bal�oCota��oN�oCadastrada();

            bal�oN�oCadastrada.ShowBalloon(txt);
        }

        private void MostrarBal�oDesatualizada()
        {
            if (bal�oDesatualizada == null)
                bal�oDesatualizada = new Bal�oCota��oDesatualizada();

            bal�oDesatualizada.ShowBalloon(txt);
        }

        public void AbrirCota��oDaData(DateTime data)
        {
            Data = data;
            painelFlutuante.SelecionarPrimeiro();
        }

        public void SelecionarPrimeiro()
        {
            painelFlutuante?.SelecionarPrimeiro();
        }

        private delegate void AtribuirCota��oCallback(Entidades.Financeiro.Cota��o cota��o);

        private void AtribuirCota��o(Entidades.Financeiro.Cota��o cota��o)
        {
            if (painelFlutuante == null)
                return;

            if (painelFlutuante.InvokeRequired)
            {
                AtribuirCota��oCallback m�todo = new AtribuirCota��oCallback(AtribuirCota��o);
                painelFlutuante.BeginInvoke(m�todo, cota��o);
            }
            else
            {
                txt.Double = cota��o.Valor;
                painelFlutuante.Cota��oSelecionada = cota��o;

                if (carregado)
                    DispararEscolheuCota��o();
            }
        }


        private void TxtCota��o_Load(object sender, EventArgs e)
        {
            if (DadosGlobais.ModoDesenho)
                return;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
                e.Handled = false;
            }
        }

        public void Limpar()
        {
            txt.Text = "";
        }

        public void DefinirMoedaSelecionandoPrimeiro(Moeda moeda)
        {
            Moeda = moeda;
            SelecionarPrimeiro();
        }
    }
}
