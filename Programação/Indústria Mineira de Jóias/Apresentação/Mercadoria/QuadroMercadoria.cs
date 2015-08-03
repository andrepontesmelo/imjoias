using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresenta��o.Mercadoria.Bandeja;
using Entidades;
using Neg�cio;

namespace Apresenta��o.Mercadoria	
{
	public class QuadroMercadoria : Apresenta��o.Formul�rios.Quadro
	{
        private Tabela tabela;

		internal TxtPeso txtPeso;
		internal System.Windows.Forms.Label lblPeso;
        internal AMS.TextBox.NumericTextBox txtQuantidade;
		private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label lblQuantidade;
		
		// Atributos
		private QuadroFoto controleFoto = null;
		private System.Windows.Forms.Button bot�o;
		private bool atualizarFotoNaSele��o = false;
        private bool modoR�pido = false;
		
		private enum A��oEnum { Adicionar, Alterar }
		private A��oEnum a��o = A��oEnum.Adicionar;
        private TableLayoutPanel tableLayoutPanel;
        public Label lblRefer�ncia;
        public TxtMercadoria txtRefer�ncia;
        private CheckBox chkModoR�pido;
        private ToolTip toolTip;

        private bool in�cioAltera��o = false;

		// Constutora
		public QuadroMercadoria()
		{
			InitializeComponent();
		}

		// Eventos
		public delegate void Refer�nciaEscolhidaDelegate(Entidades.Mercadoria.Mercadoria mercadoria);
		public event Refer�nciaEscolhidaDelegate EventoRefer�nciaEscolhida;

		public delegate void AdicionouDelegate(Entidades.Mercadoria.Mercadoria mercadoria, double quantidade);
		public event AdicionouDelegate EventoAdicionou;
		
		public delegate void AlterouDelegate(ISaquinho saquinhoOriginal, double novaQtd, double novoPeso);
		public event AlterouDelegate EventoAlterou;
	
		#region Propriedades

        [Browsable(false), ReadOnly(true), DefaultValue(null)]
        public Tabela Tabela
        {
            get { return tabela; }
            set
            {
                tabela = value;
                txtRefer�ncia.Tabela = tabela;
            }
        }

		/// <summary>
		/// Controle para exibi��o das fotos das mercadorias.
		/// </summary>
		[Category("Foto")]
		[Browsable(true)]
		public QuadroFoto ControleFoto
		{
			get { return controleFoto; }
			set { controleFoto = value; }
		}
		
		/// <summary>
		/// A foto � atualizada no 'ControleFoto' durante sele��o da mercadoria no listView do txtMercadoria. 
		/// </summary>
		[Category("Foto")]
		[Browsable(true)]
		public bool AtualizarFotoNaSele��o 
		{ 
			get { return atualizarFotoNaSele��o; }
			set { atualizarFotoNaSele��o = value; }
		}

        public bool SomenteDeLinha
        {
            get { return txtRefer�ncia.SomenteDeLinha; }
            set { txtRefer�ncia.SomenteDeLinha = value; }
        }

        /// <summary>
        /// Define modo r�pido de digita��o.
        /// </summary>
        [DefaultValue(false), Description("Ativa modo r�pido em que basta digitar a refer�ncia que a quantidade � considerada 1.")]
        public bool ModoR�pido
        {
            get
            {
                return modoR�pido;
            }
            set
            {
                modoR�pido = value;
                txtQuantidade.ReadOnly = modoR�pido;

                if (modoR�pido)
                    txtQuantidade.Text = "1";
                else
                    txtQuantidade.Text = "";

                if (modoR�pido != chkModoR�pido.Checked)
                    chkModoR�pido.Checked = modoR�pido;
            }
        }

		#endregion

		/// <summary>
		/// Atualiza o "Enabled" do bot�o, caso necess�rio
		/// </summary>
		private void ValidarDados()
		{
			bool dePeso = txtPeso.Enabled;

			bot�o.Enabled =  (
				((!dePeso) || (txtPeso.Double > 0))
				&& (txtQuantidade.Double > 0) 
				&& (txtRefer�ncia.Refer�nciaCadastrada)
				);
		}

		/// <summary>
		/// Guarda o uma c�pia do saquinho intacto, 
		/// antes de qualquer modifica��o, veja AlterarSaquinho()
		/// </summary>
		private ISaquinho saquinhoAntesAltera��o;

		/// <summary>
		/// Deve ser chamado quando o usu�rio seleciona uma mercadoria na bandeja para altera��o de seus dados.
		/// Os dados no quadro s�o descatardos, e substitu�dos pelo saquinho passado em par�metro.
		/// O bot�o deve mudar para "Alterar", e ficar n�o enabled at� que usu�rio fa�a alguma mudan�a.
		/// </summary>
		/// <param name="saquinho">A ser alterado</param>
		public void AlternarParaAltera��o(ISaquinho saquinho)
		{
            saquinhoAntesAltera��o = saquinho.Clone(saquinho.Quantidade);
            
           
            bot�o.Text = "&Alterar";

            /* A mudan�a do txtRefer�ncia ir� gerar um evento
             * de que a referencia foi alterada. 
             * Ent�o � necess�rio marcar que o controle acabou de ir para o modo alternaddo,
             * evitando que o quadro volte para o adicionar.
             */
            in�cioAltera��o = true;

            /* Alterar os dados requer que o modo de digita��o
             * r�pida seja desligado durante a altera��o.
             * -- J�lio, 17/03/2006
             */
            ModoR�pido = false;
            chkModoR�pido.Enabled = false;

            txtRefer�ncia.Txt.Text = saquinho.Mercadoria.Refer�ncia;
            txtPeso.Text = saquinho.Peso.ToString();
            txtQuantidade.Text = saquinho.Quantidade.ToString();

            lblPeso.Enabled = txtPeso.Enabled = saquinho.Mercadoria.DePeso;
            ValidarDados();

            a��o = A��oEnum.Alterar;

            in�cioAltera��o = false;
		}
		
		/// <summary>
		/// Muda a a��o, escreve 'Adicionar' no bot�o, n�o limpa os campos.
        /// Chame LimparCampos() antes para isto.
		/// 
		/// Deve ser chamado externamente, quando o usu�rio
		/// des-seleciona a bandeja.
		/// </summary>
		public void AlternarParaAdicionar()
		{
			a��o = A��oEnum.Adicionar;
			bot�o.Text = "&Adicionar";
            chkModoR�pido.Enabled = true;
		}

        /// <summary>
        /// Limpa os campos de entrada do usu�rio.
        /// </summary>
        public void LimparCampos()
        {
            txtRefer�ncia.Txt.Clear();
            txtPeso.Enabled = false;
            txtPeso.Text = "";
            
            if (!modoR�pido)
                txtQuantidade.Text = "";
        }

		#region Dispose
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txtPeso = new Apresenta��o.Mercadoria.TxtPeso();
            this.lblPeso = new System.Windows.Forms.Label();
            this.bot�o = new System.Windows.Forms.Button();
            this.txtQuantidade = new AMS.TextBox.NumericTextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblRefer�ncia = new System.Windows.Forms.Label();
            this.chkModoR�pido = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtRefer�ncia = new Apresenta��o.Mercadoria.TxtMercadoria();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPeso
            // 
            this.txtPeso.AllowNegative = false;
            this.txtPeso.DigitsInGroup = 0;
            this.txtPeso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPeso.Enabled = false;
            this.txtPeso.Flags = 65536;
            this.txtPeso.Location = new System.Drawing.Point(3, 16);
            this.txtPeso.MaxDecimalPlaces = 1;
            this.txtPeso.MaxWholeDigits = 9;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Prefix = "";
            this.txtPeso.RangeMax = 1.7976931348623157E+308D;
            this.txtPeso.RangeMin = -1.7976931348623157E+308D;
            this.txtPeso.Size = new System.Drawing.Size(106, 20);
            this.txtPeso.TabIndex = 1;
            this.txtPeso.TextChanged += new System.EventHandler(this.txtPeso_TextChanged);
            this.txtPeso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPeso_keyDown);
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Enabled = false;
            this.lblPeso.Location = new System.Drawing.Point(3, 0);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(34, 13);
            this.lblPeso.TabIndex = 13;
            this.lblPeso.Text = "Peso:";
            // 
            // bot�o
            // 
            this.bot�o.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bot�o.Enabled = false;
            this.bot�o.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bot�o.Location = new System.Drawing.Point(149, 116);
            this.bot�o.Name = "bot�o";
            this.bot�o.Size = new System.Drawing.Size(75, 23);
            this.bot�o.TabIndex = 3;
            this.bot�o.Text = "&Adicionar";
            this.bot�o.Click += new System.EventHandler(this.bot�o_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.AllowNegative = false;
            this.txtQuantidade.DigitsInGroup = 0;
            this.txtQuantidade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantidade.Flags = 65536;
            this.txtQuantidade.Location = new System.Drawing.Point(115, 16);
            this.txtQuantidade.MaxDecimalPlaces = 1;
            this.txtQuantidade.MaxWholeDigits = 9;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Prefix = "";
            this.txtQuantidade.RangeMax = 1.7976931348623157E+308D;
            this.txtQuantidade.RangeMin = -1.7976931348623157E+308D;
            this.txtQuantidade.Size = new System.Drawing.Size(106, 20);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            this.txtQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantidade_KeyDown);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(115, 0);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 11;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.txtPeso, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblQuantidade, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.txtQuantidade, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblPeso, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(224, 44);
            this.tableLayoutPanel.TabIndex = 14;
            // 
            // lblRefer�ncia
            // 
            this.lblRefer�ncia.AutoSize = true;
            this.lblRefer�ncia.Location = new System.Drawing.Point(6, 31);
            this.lblRefer�ncia.Name = "lblRefer�ncia";
            this.lblRefer�ncia.Size = new System.Drawing.Size(62, 13);
            this.lblRefer�ncia.TabIndex = 8;
            this.lblRefer�ncia.Text = "Refer�ncia:";
            // 
            // chkModoR�pido
            // 
            this.chkModoR�pido.AutoSize = true;
            this.chkModoR�pido.Location = new System.Drawing.Point(9, 120);
            this.chkModoR�pido.Name = "chkModoR�pido";
            this.chkModoR�pido.Size = new System.Drawing.Size(85, 17);
            this.chkModoR�pido.TabIndex = 16;
            this.chkModoR�pido.TabStop = false;
            this.chkModoR�pido.Text = "Modo r�pido";
            this.toolTip.SetToolTip(this.chkModoR�pido, "Quando definido o modo r�pido, basta completar a refer�ncia que a quantidade ser�" +
        " considerada como valor unit�rio. Este modo � �til para passar mercadorias no c�" +
        "digo de barras.");
            this.chkModoR�pido.UseVisualStyleBackColor = true;
            this.chkModoR�pido.CheckedChanged += new System.EventHandler(this.cmdR�pido_CheckedChanged);
            // 
            // txtRefer�ncia
            // 
            this.txtRefer�ncia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefer�ncia.ControlePeso = this.txtPeso;
            this.txtRefer�ncia.Location = new System.Drawing.Point(9, 47);
            this.txtRefer�ncia.Name = "txtRefer�ncia";
            this.txtRefer�ncia.Refer�ncia = "";
            this.txtRefer�ncia.Size = new System.Drawing.Size(215, 20);
            this.txtRefer�ncia.SomenteCadastrado = true;
            this.txtRefer�ncia.TabIndex = 0;
            this.txtRefer�ncia.Refer�nciaAlterada += new System.EventHandler(this.txtRefer�ncia_Refer�nciaAlterada);
            this.txtRefer�ncia.Refer�nciaConfirmada += new System.EventHandler(this.txtRefer�ncia_RefEscolhida);
            this.txtRefer�ncia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // QuadroMercadoria
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.chkModoR�pido);
            this.Controls.Add(this.txtRefer�ncia);
            this.Controls.Add(this.lblRefer�ncia);
            this.Controls.Add(this.bot�o);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(999999, 146);
            this.MinimumSize = new System.Drawing.Size(160, 146);
            this.Name = "QuadroMercadoria";
            this.Size = new System.Drawing.Size(232, 146);
            this.T�tulo = "Escolha da mercadoria";
            this.Load += new System.EventHandler(this.QuadroMercadoria_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.Controls.SetChildIndex(this.bot�o, 0);
            this.Controls.SetChildIndex(this.lblRefer�ncia, 0);
            this.Controls.SetChildIndex(this.txtRefer�ncia, 0);
            this.Controls.SetChildIndex(this.chkModoR�pido, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Tratamento de eventos

		private void txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{

            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtRefer�ncia.Txt.Focused && txtRefer�ncia.Txt.Text.Length != 
            //    txtRefer�ncia.Txt.MaxLength)
            //        return;


            //    txtRefer�ncia_RefEscolhida(this, new EventArgs());
            //}
		}

		private void txtRefer�ncia_RefEscolhida(object sender, System.EventArgs e)
		{
            Entidades.Mercadoria.Mercadoria mercadoria = txtRefer�ncia.Mercadoria;

            if (mercadoria == null)
                throw new ArgumentNullException("mercadoria", "Verifica��o redundante encontrou um problema: a mercadoria obtida da refer�ncia foi nula ao clicar no bot�o de adicionar. O programa tem falhas se a conex�o com o servidor n�o tiver ca�do. txtRefer�ncia.Refer�ncia = " + txtRefer�ncia.Refer�ncia);

			//A edi��o do peso s� � poss�vel se merc. for de peso
			lblPeso.Enabled = txtPeso.Enabled = mercadoria.DePeso;

			/* Dispara evento
			 * Este evento � �til, por exemplo, para alterar
			 * a foto da j�ia.
			 */
			DispararAoEscolherRefer�ncia(mercadoria);

            ValidarDados();
            
            if (!modoR�pido)
            {
                if (txtPeso.Enabled && txtRefer�ncia.Digita��oManual)
                {
                    txtPeso.SelectAll();
                    txtPeso.Focus();
                }
                else
                {
                    txtQuantidade.SelectAll();
                    txtQuantidade.Focus();
                }
            }
            else if (mercadoria.DePeso && txtPeso.Double <= 0)
            {
                Beepador.Erro();
                txtPeso.Focus();
                txtPeso.SelectAll();
            }
            else
            {
                // No modo r�pido, adiciona apenas uma quantidade
                txtQuantidade.Text = "1";

                //if (mercadoria != null)
                    bot�o_Click(this, EventArgs.Empty);
            }
		}

        private void bot�o_Click(object sender, System.EventArgs e)
        {
            Entidades.Mercadoria.Mercadoria mercadoria;
            double quantidade;

#if DEBUG
            Console.WriteLine("Executando bot�o do TxtMercadoria: " + DateTime.Now.ToLongTimeString());
#endif

            mercadoria = txtRefer�ncia.Mercadoria;

            if (mercadoria == null)
                throw new ArgumentNullException("mercadoria", "Verifica��o redundante encontrou um problema: a mercadoria obtida da refer�ncia foi nula ao clicar no bot�o de adicionar. O programa tem falhas se a conex�o com o servidor n�o tiver ca�do.");

            quantidade = txtQuantidade.Double;

            if ((a��o == A��oEnum.Adicionar) && (EventoAdicionou != null))
            {
                if (mercadoria.DePeso)
                    mercadoria.Peso = txtPeso.Double;

#if DEBUG
                Console.WriteLine("Disparando evento: " + DateTime.Now.ToLongTimeString());
#endif
                EventoAdicionou(mercadoria, quantidade);
            }
            else if ((a��o == A��oEnum.Alterar) && (EventoAlterou != null))
            {
#if DEBUG
                Console.WriteLine("Disparando evento: " + DateTime.Now.ToLongTimeString());
#endif
                EventoAlterou(saquinhoAntesAltera��o, quantidade, Double.Parse(txtPeso.Text));
            }

#if DEBUG
            Console.WriteLine("Limpando campos: " + DateTime.Now.ToLongTimeString());
#endif

            LimparCampos();
            txtRefer�ncia.Focus();

            AlternarParaAdicionar();

#if DEBUG
            Console.WriteLine("T�rmino da execu��o do bot�o: " + DateTime.Now.ToLongTimeString());
#endif
        }

        private void DispararAoEscolherRefer�ncia(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            if (EventoRefer�nciaEscolhida != null)
                EventoRefer�nciaEscolhida(mercadoria);

            /* este (!atualizarFotoNaSele��o) se d� porque
			 * n�o � necess�rio mostrar a foto se j� foi mostrada no
			 * txtRefer�ncia_Refer�nciaAlterada()
			 */

			if ((controleFoto != null) && (!atualizarFotoNaSele��o))
	            controleFoto.MostrarFoto(mercadoria);

			ValidarDados();
		}

		private void txtRefer�ncia_Refer�nciaAlterada(object sender, EventArgs e)
		{
            if (!in�cioAltera��o)
            {
                // Corrige o bot�o, que pode ainda estar no estado de alterar.
                AlternarParaAdicionar();

                if ((atualizarFotoNaSele��o) && (controleFoto != null))
                    controleFoto.MostrarLogoIMJ();

                ValidarDados();
            }
		}

		private void txtQuantidade_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                bot�o.Focus();
                e.Handled = true;
            }
		}


        private void txtPeso_keyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                if (txtPeso.Double > 0 && txtPeso.Enabled)
                {
                    if (!modoR�pido)
                    {
                        txtQuantidade.SelectAll();
                        txtQuantidade.Focus();
                        e.Handled = true;
                    }
                    else
                    {
                        // No modo r�pido, adiciona apenas uma quantidade
                        txtQuantidade.Text = "1";

                        bot�o_Click(this, EventArgs.Empty);
                    }
                }
			}
		}

		private void txtPeso_TextChanged(object sender, System.EventArgs e)
		{
			ValidarDados();
		}

		private void txtQuantidade_TextChanged(object sender, System.EventArgs e)
		{
			ValidarDados();
		}
    
        #endregion

        private void cmdR�pido_CheckedChanged(object sender, EventArgs e)
        {
            ModoR�pido = chkModoR�pido.Checked;
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    txtQuantidade.SelectedText = Entidades.Configura��o.DadosGlobais.Inst�ncia.Cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Enabled)
                txtRefer�ncia.Focus();
        }

        private void QuadroMercadoria_Load(object sender, EventArgs e)
        {
            if (modoR�pido != chkModoR�pido.Checked)
                chkModoR�pido.Checked = modoR�pido;
        }
    }
}
