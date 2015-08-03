using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresentação.Mercadoria.Bandeja;
using Entidades;
using Negócio;

namespace Apresentação.Mercadoria	
{
	public class QuadroMercadoria : Apresentação.Formulários.Quadro
	{
        private Tabela tabela;

		internal TxtPeso txtPeso;
		internal System.Windows.Forms.Label lblPeso;
        internal AMS.TextBox.NumericTextBox txtQuantidade;
		private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label lblQuantidade;
		
		// Atributos
		private QuadroFoto controleFoto = null;
		private System.Windows.Forms.Button botão;
		private bool atualizarFotoNaSeleção = false;
        private bool modoRápido = false;
		
		private enum AçãoEnum { Adicionar, Alterar }
		private AçãoEnum ação = AçãoEnum.Adicionar;
        private TableLayoutPanel tableLayoutPanel;
        public Label lblReferência;
        public TxtMercadoria txtReferência;
        private CheckBox chkModoRápido;
        private ToolTip toolTip;

        private bool inícioAlteração = false;

		// Constutora
		public QuadroMercadoria()
		{
			InitializeComponent();
		}

		// Eventos
		public delegate void ReferênciaEscolhidaDelegate(Entidades.Mercadoria.Mercadoria mercadoria);
		public event ReferênciaEscolhidaDelegate EventoReferênciaEscolhida;

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
                txtReferência.Tabela = tabela;
            }
        }

		/// <summary>
		/// Controle para exibição das fotos das mercadorias.
		/// </summary>
		[Category("Foto")]
		[Browsable(true)]
		public QuadroFoto ControleFoto
		{
			get { return controleFoto; }
			set { controleFoto = value; }
		}
		
		/// <summary>
		/// A foto é atualizada no 'ControleFoto' durante seleção da mercadoria no listView do txtMercadoria. 
		/// </summary>
		[Category("Foto")]
		[Browsable(true)]
		public bool AtualizarFotoNaSeleção 
		{ 
			get { return atualizarFotoNaSeleção; }
			set { atualizarFotoNaSeleção = value; }
		}

        public bool SomenteDeLinha
        {
            get { return txtReferência.SomenteDeLinha; }
            set { txtReferência.SomenteDeLinha = value; }
        }

        /// <summary>
        /// Define modo rápido de digitação.
        /// </summary>
        [DefaultValue(false), Description("Ativa modo rápido em que basta digitar a referência que a quantidade é considerada 1.")]
        public bool ModoRápido
        {
            get
            {
                return modoRápido;
            }
            set
            {
                modoRápido = value;
                txtQuantidade.ReadOnly = modoRápido;

                if (modoRápido)
                    txtQuantidade.Text = "1";
                else
                    txtQuantidade.Text = "";

                if (modoRápido != chkModoRápido.Checked)
                    chkModoRápido.Checked = modoRápido;
            }
        }

		#endregion

		/// <summary>
		/// Atualiza o "Enabled" do botão, caso necessário
		/// </summary>
		private void ValidarDados()
		{
			bool dePeso = txtPeso.Enabled;

			botão.Enabled =  (
				((!dePeso) || (txtPeso.Double > 0))
				&& (txtQuantidade.Double > 0) 
				&& (txtReferência.ReferênciaCadastrada)
				);
		}

		/// <summary>
		/// Guarda o uma cópia do saquinho intacto, 
		/// antes de qualquer modificação, veja AlterarSaquinho()
		/// </summary>
		private ISaquinho saquinhoAntesAlteração;

		/// <summary>
		/// Deve ser chamado quando o usuário seleciona uma mercadoria na bandeja para alteração de seus dados.
		/// Os dados no quadro são descatardos, e substituídos pelo saquinho passado em parâmetro.
		/// O botão deve mudar para "Alterar", e ficar não enabled até que usuário faça alguma mudança.
		/// </summary>
		/// <param name="saquinho">A ser alterado</param>
		public void AlternarParaAlteração(ISaquinho saquinho)
		{
            saquinhoAntesAlteração = saquinho.Clone(saquinho.Quantidade);
            
           
            botão.Text = "&Alterar";

            /* A mudança do txtReferência irá gerar um evento
             * de que a referencia foi alterada. 
             * Então é necessário marcar que o controle acabou de ir para o modo alternaddo,
             * evitando que o quadro volte para o adicionar.
             */
            inícioAlteração = true;

            /* Alterar os dados requer que o modo de digitação
             * rápida seja desligado durante a alteração.
             * -- Júlio, 17/03/2006
             */
            ModoRápido = false;
            chkModoRápido.Enabled = false;

            txtReferência.Txt.Text = saquinho.Mercadoria.Referência;
            txtPeso.Text = saquinho.Peso.ToString();
            txtQuantidade.Text = saquinho.Quantidade.ToString();

            lblPeso.Enabled = txtPeso.Enabled = saquinho.Mercadoria.DePeso;
            ValidarDados();

            ação = AçãoEnum.Alterar;

            inícioAlteração = false;
		}
		
		/// <summary>
		/// Muda a ação, escreve 'Adicionar' no botão, não limpa os campos.
        /// Chame LimparCampos() antes para isto.
		/// 
		/// Deve ser chamado externamente, quando o usuário
		/// des-seleciona a bandeja.
		/// </summary>
		public void AlternarParaAdicionar()
		{
			ação = AçãoEnum.Adicionar;
			botão.Text = "&Adicionar";
            chkModoRápido.Enabled = true;
		}

        /// <summary>
        /// Limpa os campos de entrada do usuário.
        /// </summary>
        public void LimparCampos()
        {
            txtReferência.Txt.Clear();
            txtPeso.Enabled = false;
            txtPeso.Text = "";
            
            if (!modoRápido)
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
            this.txtPeso = new Apresentação.Mercadoria.TxtPeso();
            this.lblPeso = new System.Windows.Forms.Label();
            this.botão = new System.Windows.Forms.Button();
            this.txtQuantidade = new AMS.TextBox.NumericTextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblReferência = new System.Windows.Forms.Label();
            this.chkModoRápido = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtReferência = new Apresentação.Mercadoria.TxtMercadoria();
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
            // botão
            // 
            this.botão.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botão.Enabled = false;
            this.botão.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botão.Location = new System.Drawing.Point(149, 116);
            this.botão.Name = "botão";
            this.botão.Size = new System.Drawing.Size(75, 23);
            this.botão.TabIndex = 3;
            this.botão.Text = "&Adicionar";
            this.botão.Click += new System.EventHandler(this.botão_Click);
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
            // lblReferência
            // 
            this.lblReferência.AutoSize = true;
            this.lblReferência.Location = new System.Drawing.Point(6, 31);
            this.lblReferência.Name = "lblReferência";
            this.lblReferência.Size = new System.Drawing.Size(62, 13);
            this.lblReferência.TabIndex = 8;
            this.lblReferência.Text = "Referência:";
            // 
            // chkModoRápido
            // 
            this.chkModoRápido.AutoSize = true;
            this.chkModoRápido.Location = new System.Drawing.Point(9, 120);
            this.chkModoRápido.Name = "chkModoRápido";
            this.chkModoRápido.Size = new System.Drawing.Size(85, 17);
            this.chkModoRápido.TabIndex = 16;
            this.chkModoRápido.TabStop = false;
            this.chkModoRápido.Text = "Modo rápido";
            this.toolTip.SetToolTip(this.chkModoRápido, "Quando definido o modo rápido, basta completar a referência que a quantidade será" +
        " considerada como valor unitário. Este modo é útil para passar mercadorias no có" +
        "digo de barras.");
            this.chkModoRápido.UseVisualStyleBackColor = true;
            this.chkModoRápido.CheckedChanged += new System.EventHandler(this.cmdRápido_CheckedChanged);
            // 
            // txtReferência
            // 
            this.txtReferência.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferência.ControlePeso = this.txtPeso;
            this.txtReferência.Location = new System.Drawing.Point(9, 47);
            this.txtReferência.Name = "txtReferência";
            this.txtReferência.Referência = "";
            this.txtReferência.Size = new System.Drawing.Size(215, 20);
            this.txtReferência.SomenteCadastrado = true;
            this.txtReferência.TabIndex = 0;
            this.txtReferência.ReferênciaAlterada += new System.EventHandler(this.txtReferência_ReferênciaAlterada);
            this.txtReferência.ReferênciaConfirmada += new System.EventHandler(this.txtReferência_RefEscolhida);
            this.txtReferência.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // QuadroMercadoria
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.Controls.Add(this.chkModoRápido);
            this.Controls.Add(this.txtReferência);
            this.Controls.Add(this.lblReferência);
            this.Controls.Add(this.botão);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(999999, 146);
            this.MinimumSize = new System.Drawing.Size(160, 146);
            this.Name = "QuadroMercadoria";
            this.Size = new System.Drawing.Size(232, 146);
            this.Título = "Escolha da mercadoria";
            this.Load += new System.EventHandler(this.QuadroMercadoria_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.Controls.SetChildIndex(this.botão, 0);
            this.Controls.SetChildIndex(this.lblReferência, 0);
            this.Controls.SetChildIndex(this.txtReferência, 0);
            this.Controls.SetChildIndex(this.chkModoRápido, 0);
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
            //    if (txtReferência.Txt.Focused && txtReferência.Txt.Text.Length != 
            //    txtReferência.Txt.MaxLength)
            //        return;


            //    txtReferência_RefEscolhida(this, new EventArgs());
            //}
		}

		private void txtReferência_RefEscolhida(object sender, System.EventArgs e)
		{
            Entidades.Mercadoria.Mercadoria mercadoria = txtReferência.Mercadoria;

            if (mercadoria == null)
                throw new ArgumentNullException("mercadoria", "Verificação redundante encontrou um problema: a mercadoria obtida da referência foi nula ao clicar no botão de adicionar. O programa tem falhas se a conexão com o servidor não tiver caído. txtReferência.Referência = " + txtReferência.Referência);

			//A edição do peso só é possível se merc. for de peso
			lblPeso.Enabled = txtPeso.Enabled = mercadoria.DePeso;

			/* Dispara evento
			 * Este evento é útil, por exemplo, para alterar
			 * a foto da jóia.
			 */
			DispararAoEscolherReferência(mercadoria);

            ValidarDados();
            
            if (!modoRápido)
            {
                if (txtPeso.Enabled && txtReferência.DigitaçãoManual)
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
                // No modo rápido, adiciona apenas uma quantidade
                txtQuantidade.Text = "1";

                //if (mercadoria != null)
                    botão_Click(this, EventArgs.Empty);
            }
		}

        private void botão_Click(object sender, System.EventArgs e)
        {
            Entidades.Mercadoria.Mercadoria mercadoria;
            double quantidade;

#if DEBUG
            Console.WriteLine("Executando botão do TxtMercadoria: " + DateTime.Now.ToLongTimeString());
#endif

            mercadoria = txtReferência.Mercadoria;

            if (mercadoria == null)
                throw new ArgumentNullException("mercadoria", "Verificação redundante encontrou um problema: a mercadoria obtida da referência foi nula ao clicar no botão de adicionar. O programa tem falhas se a conexão com o servidor não tiver caído.");

            quantidade = txtQuantidade.Double;

            if ((ação == AçãoEnum.Adicionar) && (EventoAdicionou != null))
            {
                if (mercadoria.DePeso)
                    mercadoria.Peso = txtPeso.Double;

#if DEBUG
                Console.WriteLine("Disparando evento: " + DateTime.Now.ToLongTimeString());
#endif
                EventoAdicionou(mercadoria, quantidade);
            }
            else if ((ação == AçãoEnum.Alterar) && (EventoAlterou != null))
            {
#if DEBUG
                Console.WriteLine("Disparando evento: " + DateTime.Now.ToLongTimeString());
#endif
                EventoAlterou(saquinhoAntesAlteração, quantidade, Double.Parse(txtPeso.Text));
            }

#if DEBUG
            Console.WriteLine("Limpando campos: " + DateTime.Now.ToLongTimeString());
#endif

            LimparCampos();
            txtReferência.Focus();

            AlternarParaAdicionar();

#if DEBUG
            Console.WriteLine("Término da execução do botão: " + DateTime.Now.ToLongTimeString());
#endif
        }

        private void DispararAoEscolherReferência(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            if (EventoReferênciaEscolhida != null)
                EventoReferênciaEscolhida(mercadoria);

            /* este (!atualizarFotoNaSeleção) se dá porque
			 * não é necessário mostrar a foto se já foi mostrada no
			 * txtReferência_ReferênciaAlterada()
			 */

			if ((controleFoto != null) && (!atualizarFotoNaSeleção))
	            controleFoto.MostrarFoto(mercadoria);

			ValidarDados();
		}

		private void txtReferência_ReferênciaAlterada(object sender, EventArgs e)
		{
            if (!inícioAlteração)
            {
                // Corrige o botão, que pode ainda estar no estado de alterar.
                AlternarParaAdicionar();

                if ((atualizarFotoNaSeleção) && (controleFoto != null))
                    controleFoto.MostrarLogoIMJ();

                ValidarDados();
            }
		}

		private void txtQuantidade_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                botão.Focus();
                e.Handled = true;
            }
		}


        private void txtPeso_keyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                if (txtPeso.Double > 0 && txtPeso.Enabled)
                {
                    if (!modoRápido)
                    {
                        txtQuantidade.SelectAll();
                        txtQuantidade.Focus();
                        e.Handled = true;
                    }
                    else
                    {
                        // No modo rápido, adiciona apenas uma quantidade
                        txtQuantidade.Text = "1";

                        botão_Click(this, EventArgs.Empty);
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

        private void cmdRápido_CheckedChanged(object sender, EventArgs e)
        {
            ModoRápido = chkModoRápido.Checked;
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    txtQuantidade.SelectedText = Entidades.Configuração.DadosGlobais.Instância.Cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Enabled)
                txtReferência.Focus();
        }

        private void QuadroMercadoria_Load(object sender, EventArgs e)
        {
            if (modoRápido != chkModoRápido.Checked)
                chkModoRápido.Checked = modoRápido;
        }
    }
}
