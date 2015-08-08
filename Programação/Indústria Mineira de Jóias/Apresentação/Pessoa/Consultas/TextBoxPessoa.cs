using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Pessoa;
using System.Collections.Generic;

namespace Apresentação.Pessoa.Consultas
{
	/// <summary>
	/// Summary description for TextBoxPessoa.
	/// </summary>
	public class TextBoxPessoa : System.Windows.Forms.UserControl
	{
		// Constantes
		public const int alturaMínimaLista = 160;

		// Atributos
		private ListView		lista = null;
		private ColetorPessoas	coletor = null;			// Deve-se usar o 'Coletor'
		private volatile bool	travar = false;			// Proteger contra pesquisa
		private volatile bool	segurarLista = false;
		private bool			funcionários = false;	// Listar somente funcionários
        private bool            vendedores = false;	    // Listar somente vendedores (representantes + funcionários)
		private Hashtable		refPessoas = null;		// Referência de pessoas para a listview (lista invertida)
		//private Hashtable		setoresCódigo;			// Setores pelo código
		private Entidades.Pessoa.Pessoa pessoa = null;			// Pessoa selecionada
		private Entidades.Pessoa.Pessoa pessoaAnterior = null;  // Seleção anterior 
		private bool			mostrarCabeçalho = true;
		private bool			desligarPesquisa = false;
        private bool            somenteCadastrados = false;
		

		// Eventos
        [Description("Usuário seleciona uma pessoa da lista ou a pessoa é encontrada a partir do prefixo ou nome digitado pelo usuário.")]
		public event EventHandler Selecionado;
        public event EventHandler Deselecionado;
		
        [Description("Uma pessoa foi escolhida. O usuário pode ter alterado pela lista ou então digitado um nome qualquer.")]
        public event EventHandler NomeAlterado;
        public event EventHandler TxtChanged;

        public new event KeyEventHandler KeyDown;

		// Listview
		private ColumnHeader colNome;
		private ColumnHeader colDados;

		// Designer
        private System.Windows.Forms.TextBox txt;
        private Button btnProcurar;
        private FormatadorNome formatadorNome;
        private PictureBox imagem;
        private IContainer components;

        int alturaProposta;

        /// <summary>
        /// Altura a ser considerada ao construir a lista
        /// </summary>
        public int AlturaProposta
        {
            get  { return alturaProposta; }
            set { alturaProposta = value; }
        }

		public TextBoxPessoa()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Cria colunas para listview
			colNome = new ColumnHeader();
			colNome.Text = "Nome";

			colDados = new ColumnHeader();
			colDados.Text = "Cidade";		// Ou setor, conforme propriedade funcionários
			colDados.Width = 200;

            this.AlturaProposta = 3 * this.Height;

			this.txt.ForeColor = SystemColors.ControlText;
            //setoresCódigo = new Hashtable();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txt = new System.Windows.Forms.TextBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.formatadorNome = new Apresentação.Pessoa.FormatadorNome(this.components);
            this.imagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatadorNome.SetFormatarNome(this.txt, true);
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(196, 20);
            this.txt.TabIndex = 0;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txt.Leave += new System.EventHandler(this.txt_Leave);
            this.txt.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            this.txt.Validated += new System.EventHandler(this.txt_Validated);
            // 
            // btnProcurar
            // 
            this.btnProcurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcurar.BackgroundImage = global::Apresentação.Resource.search4people;
            this.btnProcurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcurar.Location = new System.Drawing.Point(196, 0);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(20, 20);
            this.btnProcurar.TabIndex = 1;
            this.btnProcurar.TabStop = false;
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // imagem
            // 
            this.imagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagem.BackColor = System.Drawing.SystemColors.Window;
            this.imagem.Image = global::Apresentação.Resource.Lupa;
            this.imagem.Location = new System.Drawing.Point(179, 2);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(16, 16);
            this.imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagem.TabIndex = 2;
            this.imagem.TabStop = false;
            this.imagem.Visible = false;
            // 
            // TextBoxPessoa
            // 
            this.Controls.Add(this.imagem);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.txt);
            this.Name = "TextBoxPessoa";
            this.Size = new System.Drawing.Size(216, 20);
            this.Move += new System.EventHandler(this.TextBoxPessoa_Resize);
            this.Resize += new System.EventHandler(this.TextBoxPessoa_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Propriedades
        private bool podeSerNulo = true;
        [DefaultValue(false)]
        public bool NãoPodeSerNulo
        {
            get { return !podeSerNulo;  }
            set { podeSerNulo = !value;  }
        }

		[DefaultValue(false)]
		public bool DesligarPesquisa
		{
			get { return desligarPesquisa; }
			set
			{
				desligarPesquisa = value;

				if (value)
				{
					if (coletor != null)
						coletor.Cancelar();

					if (lista != null)
						lista.Visible = false;
				}
				else
					coletor.ProcurarImediatamente();
			}
		}

        [Browsable(false)]
		public Entidades.Pessoa.Pessoa Pessoa
		{
			get
            {
                if (somenteCadastrados && txt.Text.Length > 0 && pessoa == null)
                    ProcurarPessoaCadastrada();

                return pessoa;
            }
            set 
            {
                //bool válido;

                ////válido  = value == null || !funcionários || value is Funcionário || Funcionário.ÉFuncionário(value);
                ////válido &= value == null || !vendedores || value is Representante || value is Funcionário || Funcionário.ÉFuncionário(value) || Representante.ÉRepresentante(value);

                //válido  = value == null || !funcionários || value is Funcionário || Funcionário.ÉFuncionário(value);
                //válido &= value == null || !vendedores || value is Representante || value is Funcionário || Funcionário.ÉFuncionário(value) || Representante.ÉRepresentante(value);

                //if (válido)
                //{
                    // Atribui pessoa referente à linha selecionada
                    if (pessoa != null)
                        pessoaAnterior = pessoa;

                    pessoa = value;

                    // Garante que a textbox não vai requisitar pesquisa
                    travar = true;

                    AtualizarTextBox();

                    travar = false;
                //}
            }
        }

        private delegate void AtualizarCallback();

        private void AtualizarTextBox()
        {
            if (txt.InvokeRequired)
            {
                AtualizarCallback método = new AtualizarCallback(AtualizarTextBox);
                txt.BeginInvoke(método);
            }
            else
            {
                if (pessoa != null)
                {
                    txt.Text = pessoa.Nome;
                    txt.SelectAll();
                }
                else
                    txt.Text = "";
            }
        }

        /// <summary>
        /// Código da pessoa, código entrado ou nulo caso esteja
        /// escrito apenas um nome não cadastrado.
        /// </summary>
        private ulong? Código
        {
            get
            {
                if (Pessoa != null)
                    return Pessoa.Código;
                else if (txt.Text.Length > 0)
                {
                    // Verifica se é número
                    string texto = txt.Text.Trim();
                    bool éNúmero = true;
                    for (int x = 0; x < texto.Length; x++)
                        éNúmero &= char.IsNumber(texto, x);

                    if (éNúmero)
                        return ulong.Parse(txt.Text);
                    else
                        return null;
                }
                else
                    return null;
            }
        }

		/// <summary>
		/// Coletor de pessoas.
		/// </summary>
		private ColetorPessoas Coletor
		{
			get 
			{ 
				if (coletor == null)
					CriarColetor();

				return coletor;
			}
		}

		/// <summary>
		/// Texto
		/// </summary>
		public override string Text
		{
			get { return txt.Text; }
			set
			{
				travar = true;
				txt.Text = value;
				travar = false;
			}
		}

		public TextBox TextBox
		{
			get { return txt; }
		}

		/// <summary>
		/// Lista está sendo segurada
		/// </summary>
		public bool SegurandoLista
		{
			get { return segurarLista; }
		}

        /// <summary>
        /// Mostrar somente funcionários.
        /// </summary>
        [Description("Mostrar somente funcionários")]
		[DefaultValue(false)]
		public bool Funcionários
		{
			get { return funcionários; }
			set
			{
				funcionários = value;

				if (coletor != null)
					Coletor.Funcionários = value;

                colDados.Text = (funcionários || vendedores ? "Setor" : "Cidade");
			}
		}

        /// <summary>
        /// Define se deve ser exibido somente vendedores (funcionários + representantes).
        /// </summary>
        [DefaultValue(false), Description("Mostrar somente vendedores (funcionários + representates)")]
        public bool Vendedores
        {
            get { return vendedores; }
            set
            {
                vendedores = value;

                if (coletor != null)
                    Coletor.Vendedores = value;

                colDados.Text = (vendedores || funcionários ? "Setor" : "Cidade");
            }
        }

		/// <summary>
		/// Mostrar cabeçalho das colunas
		/// </summary>
		[DefaultValue(true),
		 Description("Determina se o cabeçalho deve ser mostrado ou não")]
		public bool MostrarCabeçalho
		{
			get { return mostrarCabeçalho; }
			set
			{
				mostrarCabeçalho = value;

				if (lista != null)
					lista.HeaderStyle = value ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
			}
		}

        /// <summary>
        /// Aceita somente pessoas cadastradas.
        /// </summary>
        [DefaultValue(false),
        Description("Determina se somente pessoas cadastradas devem ser aceitas.")]
        public bool SomenteCadastrado
        {
            get { return somenteCadastrados; }
            set
            {
                somenteCadastrados = value;

                if (value && txt.Text.Length > 0 && Pessoa == null)
                    ProcurarPessoaAssincronamente();
            }
        }

        /// <summary>
        /// Determina se deve mostrar botão de procurar.
        /// </summary>
        [DefaultValue(true)]
        public bool MostrarBotãoProcurar
        {
            get { return btnProcurar.Visible; }
            set
            {
                if (btnProcurar.Visible != value)
                {
                    btnProcurar.Visible = value;

                    if (value)
                    {
                        txt.Width = ClientSize.Width - btnProcurar.Width;
                        imagem.Left -= btnProcurar.Width;
                    }
                    else
                    {
                        txt.Width = ClientSize.Width;
                        imagem.Left += btnProcurar.Width;
                    }
                }
            }
        }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return txt.ReadOnly; }
            set
            {
                txt.ReadOnly = value;
                btnProcurar.Enabled = !value;
            }
        }

		#endregion

		/// <summary>
		/// Reposiciona a lista, conforme text box
		/// </summary>
		private void ReposicionarLista()
		{
			if (lista != null)
			{
				int larguraProposta = this.Width;

				Point pontoZeroRaíz;	//zero absoluto do formulario toppest
				Point pontoZeroMeu;		//zero absoluto do formulario top
				Point posiçãoLista;		//é o novoZero um pouco para direita
				Point novoZero;			
				/* novoZero:
				 * seu zero corresponde à coordenada relativa 
				 * do top em relação ao toppest
				 */
				
				// Obtem coordenada relativa
                if (this.ParentForm != null)
                {
                    pontoZeroRaíz = this.ParentForm.PointToScreen(new Point(0, 0));
                    pontoZeroMeu = this.PointToScreen(new Point(0, 0));

                    //novoZero = pontoZeromeu - pontoZeroRaíz;
                    novoZero = pontoZeroMeu;
                    novoZero.Offset(-1 * pontoZeroRaíz.X, -1 * pontoZeroRaíz.Y);

                    //abaixa:
                    posiçãoLista = novoZero;
                    posiçãoLista.Offset(0, this.Height);
                }
                else
                    posiçãoLista = new Point(lista.Left, lista.Top);

				//lista.Bounds = new Rectangle
				//	(posiçãoLista, new Size(larguraProposta < larguraMínimaLista ? larguraMínimaLista : larguraProposta, alturaProposta < alturaMínimaLista ? alturaMínimaLista : alturaProposta));

				lista.Bounds = new Rectangle
					(posiçãoLista, new Size(larguraProposta, alturaProposta < alturaMínimaLista ? alturaMínimaLista : alturaProposta));

				if (lista.Bottom > lista.Parent.ClientSize.Height)
					lista.Height -= lista.Bottom - lista.Parent.ClientSize.Height;

				colNome.Width = lista.Width - colDados.Width - 25;
				
				lista.BringToFront();
			}
		}

        private delegate void SinalizaçãoCallback();

        /// <summary>
        /// Sinaliza procura pela referência digitada.
        /// </summary>
        private void SinalizarProcura()
        {
            if (InvokeRequired)
            {
                SinalizaçãoCallback método = new SinalizaçãoCallback(SinalizarProcura);

                if (!Disposing)
                    BeginInvoke(método);
            }
            else
            {
                UseWaitCursor = true;
                Parent.UseWaitCursor = true;

                //imagem.Visible = true;
                //imagem.BringToFront();
            }
        }

        /// <summary>
        /// Retira sinalização.
        /// </summary>
        private void Dessinalizar()
        {
            if (InvokeRequired)
            {
                SinalizaçãoCallback método = new SinalizaçãoCallback(Dessinalizar);

                if (!Disposing)
                    BeginInvoke(método);
            }
            else
            {
                //txt.BackColor = Color.White;
                UseWaitCursor = false;
                Parent.UseWaitCursor = false;

                //imagem.Visible = false;
            }
        }

		/// <summary>
		/// Cria lista
		/// </summary>
		private void CriarLista()
		{
			// Constrói a listview
            lista = new ListView();

			// Atributos visuais
			int alturaProposta = 3 * this.Height;
			lista.Height		= alturaProposta < alturaMínimaLista ? alturaMínimaLista : alturaProposta;
			lista.Visible		= false;
			lista.Name			= this.Name + "Lista";
			lista.FullRowSelect = true;
			lista.MultiSelect	= false;
			lista.HideSelection = false;
			lista.View			= View.Details;
			lista.BorderStyle = BorderStyle.FixedSingle;
			lista.HeaderStyle	= mostrarCabeçalho ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
	
			// Eventos
			lista.SelectedIndexChanged += new EventHandler(lista_SelectedIndexChanged);
			lista.Click				   += new EventHandler(lista_Click);
			lista.MouseMove			   += new MouseEventHandler(lista_MouseMove);
			lista.MouseLeave		   += new EventHandler(lista_MouseLeave);

			// Colunas
			lista.Columns.Add(colNome);
			lista.Columns.Add(colDados);
			
			this.TopLevelControl.SuspendLayout();
			this.TopLevelControl.Controls.Add(lista);
			
			lista.BringToFront();

            ///* Se a lista for oculta antes de inserir no controle,
            // * o programa trava. (Bug do .net, talvez?)
            // */
            //lista.Visible = false;
		}

		/// <summary>
		/// Constrói coletor de dados.
		/// </summary>
		private void CriarColetor()
		{
			coletor = new ColetorPessoas(new ColetorPessoas.RecuperaçãoPessoasDelegate(Recuperação));
			coletor.Funcionários = funcionários;
			coletor.FinalDeBusca += new Apresentação.Formulários.Consultas.Coletor.FinalDeBuscaDelegate(coletor_FinalDeBusca);
            coletor.InícioDeBusca += new Apresentação.Formulários.Consultas.Coletor.InícioDeBuscaDelegate(coletor_InícioDeBusca);
			coletor.IgnorarMaiúsculoMinúsculo = true;
		}

        void coletor_InícioDeBusca()
        {
            SinalizarProcura();
        }

		/// <summary>
		/// Reconstruir lista de auto-complete
		/// </summary>
		private void txt_TextChanged(object sender, System.EventArgs e)
		{
            if (TxtChanged != null)
                TxtChanged(sender, e);

 			// Verificar se inicia pesquisa
			if (txt.Focused && !travar && !desligarPesquisa && lista != null)
			{
                if (txt.Text.Length == 0)
                {
                    lista.Visible = false;
                    pessoa = null;
                }
                else if (pessoa != null && string.Compare(pessoa.Nome, txt.Text, true) != 0)
                    pessoa = null;

                /* Movido para OnKeyUp, visto que alterações na
                 * formatação do TextBox -- provenientes do FormatadorNome --,
                 * disparam TextChanged, influenciando na marcação de tempo
                 * do Coletor.
                 * -- Júlio, 21/04/2006
                 */
                //else
                //    Coletor.Pesquisar(txt.Text);
			}

            if ((pessoaAnterior == null) || ((pessoa != null) && (pessoa.Código != pessoaAnterior.Código)))
            {
                if (NomeAlterado != null && Válido)
                    NomeAlterado(sender, e);
            }
		}

        private delegate void RecuperaçãoCallback(List<Entidades.Pessoa.Pessoa> pessoas);

		/// <summary>
		/// Ocorre quando o coletor recupera nomes
		/// </summary>
		/// <param name="nomes">Nomes recuperados da camada de acesso</param>
		private void Recuperação(List<Entidades.Pessoa.Pessoa> pessoas)
		{
            try
            {
                if (lista.InvokeRequired)
                {
                    RecuperaçãoCallback método = new RecuperaçãoCallback(Recuperação);
                    lista.BeginInvoke(método, new object[] { pessoas });
                }
                else
                {
                    // Limpar lista
                    lista.Visible = false;
                    lista.Items.Clear();

                    // Recriar hashtable para encontrar entidades pela linha selecionada do listview
                    refPessoas = new Hashtable(pessoas.Count);

                    // Verificar se há pessoas para mostrar
                    if (pessoas.Count == 0)
                    {
                        // Mostrar lista vazia para que o usuário não espere
                        //lista.Visible = Focused && !travar && txt.Text.Length > 0;

                        lista.Visible = false;

                        return;
                    }


                    ListViewItem[] itens = new ListViewItem[pessoas.Count];
                    int x = 0;

                    // Inserir pessoas
                    foreach (Entidades.Pessoa.Pessoa pessoa in pessoas)
                    {
                        if (pessoa is Entidades.Pessoa.Funcionário)
                        {
                            Entidades.Setor setor;
                            ListViewItem linha = new ListViewItem();

                            linha.Text = pessoa.Nome;

                            setor = ((Entidades.Pessoa.Funcionário)pessoa).Setor;

                            // A pessoa pode não ter setor
                            linha.SubItems.Add(setor == null ? "" : setor.Nome);
                            lista.Items.Add(linha);

                            refPessoas[linha] = pessoa;
                        }
                        else if (pessoa is Entidades.Pessoa.Representante)
                        {
                            ListViewItem linha = new ListViewItem();

                            linha.Text = pessoa.Nome;
                            linha.SubItems.Add("Representante");
                            lista.Items.Add(linha);

                            refPessoas[linha] = pessoa;
                        }
                        else if (pessoa != null)
                        {
                            ListViewItem linha = new ListViewItem();

                            linha.Text = pessoa.Nome;

                            List<Entidades.Pessoa.Endereço.Endereço> endereços
                                = pessoa.Endereços.ExtrairElementos();

                            if (endereços.Count != 0
                                && (endereços[0].Localidade != null)
                                && (endereços[0].Localidade.Estado != null))
                                linha.SubItems.Add(endereços[0].Localidade.Nome + " / " + endereços[0].Localidade.Estado.Sigla);
                            else
                                linha.SubItems.Add("");
                                
                            //linha.SubItems.Add(((Entidades.Pessoa.PessoaCPFCNPJRG)pessoa).Documento);

                            itens[x++] = linha;

                            refPessoas[linha] = pessoa;
                        }
                    }

                    lista.Items.AddRange(itens);

                    /* Verificar se o controle ainda retém o foco para mostrar a lista
                     * O foco no TextBox é sempre falso neste ponto, talvez porque esta
                     * função é chamada externamente pelo ColetorPessoas. (Estranho)
                     * Portanto, utiliza-se o travar para verificar se o controle está
                     * com foco.
                     *                      -- Júlio, 06/03/2004
                     */
                    if (!travar)
                    {
                        lista.Visible = Focused;
                        lista.BringToFront();
                    }
                }
            }
            catch (ObjectDisposedException)
            { /* Ignorar */ }
		}

		/// <summary>
		/// Ocorre quando se seleciona um item na lista
		/// </summary>
		private void lista_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lista.SelectedItems.Count != 1)
				return;

            AoSelecionar(lista.SelectedItems[0]);
		}

        /// <summary>
        /// Ocorre ao selecionar um item na lista.
        /// </summary>
        private void AoSelecionar(ListViewItem item)
        {
            if (!ReadOnly)
            {
                // Precisa ser a propriedade para não abrir a listView
                Pessoa = refPessoas[item] as Entidades.Pessoa.Pessoa;

                // Verificar se foi clicada
                if (lista.Focused)
                {
                    lista.Visible = false;
                    txt.Focus();
                }

                // Como foi selecionada uma pessoa, não é mais necessário segurar a lista
                segurarLista = false;

                //if (Selecionado != null)
                //    Selecionado(this, null);
            }
        }

		/// <summary>
		/// Ocorre quando se pressiona uma tecla no textbox
		/// </summary>
		private void txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (!Enabled)
                return;

			if (lista == null)
				return;

            // A chamada get da propriedade Pessoa zera txt.Text.
            string texto = txt.Text;

            try
			{
				int idx = -1;

				if (lista.SelectedIndices.Count > 0)
					idx = lista.SelectedIndices[0];

				switch (e.KeyCode)
				{
                    case Keys.Delete:
                        if (txt.SelectionLength == txt.TextLength)
                            Limpar();
                        break;

					case Keys.Down:
						if (++idx >= lista.Items.Count)
							idx = lista.Items.Count - 1;

						lista.Items[idx].Selected = true;
						lista.Items[idx].EnsureVisible();
						e.Handled = true;
						break;

					case Keys.Up:
						if (--idx < 0)
							idx = 0;

						lista.Items[idx].Selected = true;
						lista.Items[idx].EnsureVisible();
						e.Handled = true;
						break;

					case Keys.Enter:
                        if (Pessoa != null && Pessoa.Nome.Trim() == texto.Trim())
                        {
                            if (lista != null)
                                lista.Visible = false;

                            return;
                        }

                        if (somenteCadastrados && lista.Items.Count > 0)
                        {
                            Apresentação.Formulários.AguardeDB.Mostrar();
                            List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(texto.Trim());
                            Apresentação.Formulários.AguardeDB.Fechar();
                            using (ProcurarPessoaResultados dlg = new ProcurarPessoaResultados(pessoas))
                            {
                                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                                    Pessoa = dlg.PessoaSelecionada;
                            }
                            
                        }
						lista.Visible = false;
						e.Handled = true;
						break;

					case Keys.Escape:
						lista.Visible = false;
						break;
				}
			}
			catch
			{
				e.Handled = true;
			}
			finally
			{
				this.OnKeyDown(e);
			}

            if (KeyDown != null)
                KeyDown(this, e);            
		}

		/// <summary>
		/// Ocorre quando o mouse entra na lista
		/// </summary>
		private void lista_MouseMove(object sender, MouseEventArgs e)
		{
			segurarLista = true;
		}

		/// <summary>
		/// Ocorre quando o mouse sai da lista
		/// </summary>
		private void lista_MouseLeave(object sender, EventArgs e)
		{
			segurarLista = false;
		}

		/// <summary>
		/// Ocorre quando o textbox perde o foco
		/// </summary>
		private void txt_Leave(object sender, System.EventArgs e)
		{
            if (!Enabled)
                return;

			travar = true;

			if (!segurarLista && lista != null)
				lista.Visible = false;

            if (pessoa == null && funcionários && txt.Text.Length != 0 && lista.Items.Count > 0 && Válido)
                AoSelecionar(lista.Items[0]);
            else if (somenteCadastrados && !Focused && txt.Text.Length > 0 && Pessoa == null && Válido)
                ProcurarPessoaAssincronamente();
            else if (Código.HasValue && Pessoa == null && Válido)
                ProcurarPessoaAssincronamente();
            else if (Deselecionado != null && Pessoa == null && Válido)
                Deselecionado(this, EventArgs.Empty);
            else if (Selecionado != null && Pessoa != null && Válido)
                Selecionado(this, EventArgs.Empty);

            UseWaitCursor = false;
        }

		/// <summary>
		/// Ocorre quando o textbox ganha o foco
		/// </summary>
		private void txt_Enter(object sender, System.EventArgs e)
		{
            if (!Enabled)
                return;

            if (lista != null)
            {
                //lista.Visible = lista.Items.Count > 0;
            }
            else if (!this.DesignMode && this.TopLevelControl != null)
            {
                this.ParentForm.Cursor = Cursors.WaitCursor;

                CriarLista();
                ReposicionarLista();
                CriarColetor();

                this.TopLevelControl.ResumeLayout();

                this.ParentForm.Cursor = Cursors.Default;
            }

			travar = false;
		}

		/// <summary>
		/// Textbox redimensionado
		/// </summary>
		private void TextBoxPessoa_Resize(object sender, System.EventArgs e)
		{
			if (this.Height > 20)
			{
				this.SuspendLayout();
				this.Height = 20;
				this.ResumeLayout(true);
			}

			ReposicionarLista();
		}

		/// <summary>
		/// Usuário selecionou na lista clicando
		/// </summary>
		private void lista_Click(object sender, EventArgs e)
		{
			lista.Visible = false;
			segurarLista = false;
		}

        private delegate void FinalDeBuscaCallback();

		/// <summary>
		/// A busca foi cancelada pelo coletor ou finalizada
		/// </summary>
		private void coletor_FinalDeBusca()
		{
            if (lista.InvokeRequired)
            {
                FinalDeBuscaCallback método = new FinalDeBuscaCallback(coletor_FinalDeBusca);
                lista.BeginInvoke(método);
            }
            else
            {
                // Mostrar os resultados atuais, se o controle continua com foco
                if (lista != null && Focused && !travar)
                    lista.Visible = txt.Text.Length > 0;

                else if (pessoa == null && funcionários && !Focused && lista != null && lista.Items.Count > 0)
                    AoSelecionar(lista.Items[0]);

                Dessinalizar();
            }
		}

		private void txt_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (!Enabled)
                return;

            if (txt.Focused && !travar && !desligarPesquisa && lista != null && pessoa == null && e.KeyCode != Keys.Enter)
            {
                /* Requisitar pesquisa de nome ou esconder janela,
                 * conforme dados digitados.
                 */
                lista.Visible = false;

                Coletor.Pesquisar(txt.Text);
            }

            this.OnKeyUp(e);
		}

		private void txt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
            if (!Enabled)
                return;

            if (e.KeyChar == (char)8 && txt.SelectionLength == txt.TextLength)
                Limpar();

            this.OnKeyPress(e);
		}

        private void Limpar()
        {
            txt.Text = "";
        }

        public override bool Focused
        {
            get
            {
                return base.Focused || txt.Focused || (lista != null && lista.Focused) || btnProcurar.Focused;
            }
        }

        /// <summary>
        /// Ocorre ao clicar em procurar.
        /// </summary>
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            if (vendedores && !funcionários)
            {
                using (EscolherVendedor dlg = new EscolherVendedor(
                    "Escolha o vendedor desejado.",
                    txt.Text))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        Pessoa = dlg.Vendedor;
                }
            }
            else if (funcionários)
            {
                using (EscolherFuncionário dlg = new EscolherFuncionário(
                    "Escolha o funcionário desejado.",
                    txt.Text))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        Pessoa = dlg.Funcionário;
                }
            }
            else
                Pessoa = ProcurarPessoa.Procurar(ParentForm);


            if (Válido)
            {
                if (Pessoa != null)
                {
                    if (Selecionado != null)
                        Selecionado(this, null);
                }
                else
                    if (Deselecionado != null)
                        Deselecionado(this, null);
            }

            UseWaitCursor = false;
        }

        /// <summary>
        /// Procura pessoa cadastrada assincronamente.
        /// </summary>
        private void ProcurarPessoaAssincronamente()
        {
            ProcurarPessoaCadastradaCallback método;

            método = new ProcurarPessoaCadastradaCallback(ProcurarPessoaCadastrada);
            método.BeginInvoke(new AsyncCallback(AoTerminarProcuraPessoa), método);
        }

        private delegate void ProcurarPessoaCadastradaCallback();

        /// <summary>
        /// Procura pessoa cadastrada.
        /// </summary>
        private void ProcurarPessoaCadastrada()
        {
            if (txt.Text.Length == 0)
                return;

            // Verifica se é um código que está digitado.
            if (char.IsNumber(txt.Text[0]))
            {
                ulong código = ulong.Parse(txt.Text);

                if (this.funcionários)
                    Pessoa = Entidades.Pessoa.Funcionário.ObterPessoa(código);
                else
                    Pessoa = Entidades.Pessoa.Pessoa.ObterPessoa(código);
            }
            else
            {
                if (this.vendedores && !this.funcionários)
                {
                    List<Entidades.Pessoa.Pessoa> funcionários;

                    funcionários = Entidades.Pessoa.Funcionário.ObterFuncionários(txt.Text, 2);

                    if (funcionários.Count == 1)
                        Pessoa = funcionários[0];
                    else
                    {
                        Entidades.Pessoa.Representante[] representantes;

                        representantes = Entidades.Pessoa.Representante.ObterRepresentantes(txt.Text, 2);

                        if (representantes.Length == 1)
                            Pessoa = representantes[0];
                        else
                            Pessoa = null;
                    }
                }
                else if (this.funcionários)
                {
                    List<Entidades.Pessoa.Pessoa> funcionários;

                    funcionários = Entidades.Pessoa.Funcionário.ObterFuncionários(txt.Text, 2);

                    if (funcionários.Count == 1)
                        Pessoa = funcionários[0];
                    else
                        Pessoa = null;
                }
                else
                {
                    List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(txt.Text, 2);

                    if (pessoas.Count == 1)
                        Pessoa = pessoas[0];
                    else
                        Pessoa = null;
                }
            }

            if (Válido)
            {
                if (pessoa != null)
                {
                    if (Selecionado != null)
                        Selecionado(this, null);
                }
                else
                    if (Deselecionado != null)
                        Deselecionado(this, null);
            }
        }

        /// <summary>
        /// Ocorre ao terminar a procura por pessoa cadastrada.
        /// </summary>
        private void AoTerminarProcuraPessoa(IAsyncResult resultado)
        {
            ProcurarPessoaCadastradaCallback método;

            método = (ProcurarPessoaCadastradaCallback)resultado.AsyncState;
            método.EndInvoke(resultado);
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Válido;
        }

        private void txt_Validated(object sender, EventArgs e)
        {
        }

        private bool Válido
        {
            get
            {
                return podeSerNulo || Pessoa != null;
            }
        }
	}
}
