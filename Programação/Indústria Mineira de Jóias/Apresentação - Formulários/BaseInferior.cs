using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Privilégio;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Base inferior do formulário base
	/// </summary>
	[Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", 
		 typeof(System.ComponentModel.Design.IDesigner))]
	[Serializable]
    public class BaseInferior : System.Windows.Forms.UserControl, IRequerPrivilégio
	{
		private bool                    jáAberto = false; // A baseInferior já foi completamente aberta
		internal BaseInferior           baseAnterior;
		private ControladorBaseInferior controlador;
        private Permissão               privilégios = Permissão.Nenhuma;
        
        /// <summary>
        /// Imagem a ser exibida no botão.
        /// </summary>
        private Image imagem = null;

		// Componentes
        protected System.Windows.Forms.Panel esquerda;
        private QuadroNavegação quadroNavegação;

		private System.ComponentModel.Container components = null;

		public BaseInferior()
		{
			InitializeComponent();
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseInferior));
            this.esquerda = new System.Windows.Forms.Panel();
            this.quadroNavegação = new Apresentação.Formulários.QuadroNavegação();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(183)))), ((int)(((byte)(153)))));
            this.esquerda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("esquerda.BackgroundImage")));
            this.esquerda.Controls.Add(this.quadroNavegação);
            this.esquerda.Dock = System.Windows.Forms.DockStyle.Left;
            this.esquerda.Location = new System.Drawing.Point(0, 0);
            this.esquerda.Name = "esquerda";
            this.esquerda.Padding = new System.Windows.Forms.Padding(4, 10, 27, 0);
            this.esquerda.Size = new System.Drawing.Size(187, 296);
            this.esquerda.TabIndex = 5;
            this.esquerda.Layout += new System.Windows.Forms.LayoutEventHandler(this.esquerda_Layout);
            this.esquerda.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.esquerda_ControlRemoved);
            this.esquerda.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.esquerda_ControlAdded);
            // 
            // quadroNavegação
            // 
            this.quadroNavegação.BackColor = System.Drawing.Color.Transparent;
            this.quadroNavegação.Location = new System.Drawing.Point(7, 13);
            this.quadroNavegação.MaximumSize = new System.Drawing.Size(160, 48);
            this.quadroNavegação.MinimumSize = new System.Drawing.Size(160, 48);
            this.quadroNavegação.Name = "quadroNavegação";
            this.quadroNavegação.Size = new System.Drawing.Size(160, 48);
            this.quadroNavegação.TabIndex = 0;
            // 
            // BaseInferior
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.esquerda);
            this.Name = "BaseInferior";
            this.Size = new System.Drawing.Size(800, 296);
            this.Load += new System.EventHandler(this.BaseInferior_Load);
            this.esquerda.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        [Description("Imagem a ser utilizada pelo botão."), DefaultValue(null)]
        public Image Imagem
        {
            get { return imagem; }
            set { imagem = value; }
        }

        /// <summary>
        /// Barra da esquerda.
        /// </summary>
        internal Panel Esquerda
        {
            get { return esquerda; }
        }

		/// <summary>
		/// Substitui base inferior atual por uma temporária.
        /// Assim que for novamente substituída, a base será desalocada.
		/// </summary>
		/// <param name="novaBase">Nova base inferior a ser exibida pelo formulário</param>
		public void SubstituirBase(BaseInferior novaBase)
		{
			controlador.SubstituirBase(novaBase, this);
		}

		/// <summary>
		/// Substitui base inferior atual pela base inferior
		/// exibida anteriormente.
		/// </summary>
		public void SubstituirBaseParaAnterior()
		{
			controlador.SubstituirBaseParaAnterior();
		}

		/// <summary>
		/// Substitui base inferior atual para a primeira.
		/// </summary>
		protected void SubstituirBaseParaInicial()
		{
			controlador.SubstituirBaseParaInicial();
		}

		/// <summary>
		/// Mostra base inferior atual.
		/// </summary>
		protected void Exibir()
		{
			controlador.AutoExibição(this);
		}

		/// <summary>
		/// Ocorre ao ser exibida pelo formulário base,
        /// mesmo que da primeira vez.
		/// </summary>
		protected virtual void AoExibir()
		{
            UseWaitCursor = true;

            PropagarAoExibir();
            OrganizarControlesEsquerda();

            UseWaitCursor = false;
		}

        /// <summary>
        /// Propaga chamada de ao exibir aos controles na base inferior.
        /// </summary>
        private void PropagarAoExibir()
        {
            Queue<ControlCollection> controles;

            controles = new Queue<ControlCollection>();
            controles.Enqueue(Controls);

            while (controles.Count > 0)
                foreach (Control controle in controles.Dequeue())
                {
                    if (controle is IAoMostrarBaseInferior)
                        ((IAoMostrarBaseInferior)controle).AoExibir(this);

                    if (controle.Controls.Count > 0)
                        controles.Enqueue(controle.Controls);
                }
        }

        /// <summary>
        /// Organia controles na barra da esquerda, posicionando-os
        /// adequadamente a partir do início delimitado.
        /// </summary>
        private void OrganizarControlesEsquerda()
        {
            List<Control> controles = new List<Control>(esquerda.Controls.Count);
            int y = quadroNavegação.Top;

            if (quadroNavegação.Visible)
                y += quadroNavegação.Height + quadroNavegação.Left;

            foreach (Control controle in esquerda.Controls)
                if (controle != quadroNavegação)
                    controles.Add(controle);

            controles.Sort(new Comparison<Control>(CompararControlesAltura));

            esquerda.SuspendLayout();

            foreach (Control controle in controles)
            {
                controle.Top = y;

                if (controle.Visible)
                    y += controle.Height + quadroNavegação.Left;
            }

            esquerda.ResumeLayout();
        }

        /// <summary>
        /// Compara a altura de dois controles.
        /// </summary>
        private int CompararControlesAltura(Control a, Control b)
        {
            return a.Top.CompareTo(b.Top);
        }

        /// <summary>
		/// Ocorre ao ser exibido pelo formulário base da primeira vez.
		/// (é a primeira vez que é chamado o AoExibir())
		/// </summary>
		protected virtual void AoExibirDaPrimeiraVez()
		{
            Queue<ControlCollection> controles;

            PermissãoFuncionário.AssegurarPermissão(privilégios);

            foreach (Control controle in esquerda.Controls)
            {
                IRequerPrivilégio controlePrivilégio = controle as IRequerPrivilégio;

                if (controlePrivilégio != null && !PermissãoFuncionário.ValidarPermissão(controlePrivilégio.Privilégio))
                    esquerda.Controls.Remove(controle);
            }

            controles = new Queue<ControlCollection>();
            controles.Enqueue(Controls);

            while (controles.Count > 0)
                foreach (Control controle in controles.Dequeue())
                {
                    if (controle is IAoMostrarBaseInferior)
                        ((IAoMostrarBaseInferior)controle).AoExibirDaPrimeiraVez(this);

                    if (controle.Controls.Count > 0)
                        controles.Enqueue(controle.Controls);
                }
		}

        /// <summary>
        /// Ocorre ao ser substituído por nova base.
        /// </summary>
        /// <param name="novaBase">Base que o substituiu.</param>
        protected virtual void AoSerSubstituído(BaseInferior novaBase)
        {
        }

		/// <summary>
		/// Método utilizado pelo formulário base
		/// </summary>
		internal void DispararAoExibir()
		{
            UseWaitCursor = true;

			if (!jáAberto) 
			{
				jáAberto = true;
				AoExibirDaPrimeiraVez();
			}

			AoExibir();

            UseWaitCursor = false;
		}

        /// <summary>
        /// Método utilizado pelo formulário base.
        /// </summary>
        internal void DispararAoSerSubstituido(BaseInferior novaBase)
        {
            AoSerSubstituído(novaBase);
        }

		/// <summary>
		/// Controlador da base inferior.
		/// </summary>
		[Browsable(false)]
		public ControladorBaseInferior Controlador
		{
			get { return controlador; }
		}

		/// <summary>
		/// Define o controlador atual.
		/// </summary>
		/// <param name="controlador">Controlador a definir.</param>
        /// <remarks>Verdadeiro se o controlador foi definido.</remarks>
		internal bool DefinirControlador(ControladorBaseInferior controlador)
		{
            // Em caso de retorno à base inferior...
            if (this.controlador == controlador)
                return false;

            // no entanto, controladores diferentes não são permitidos!
			if (this.controlador != null)
				throw new Exception("Controlador já foi atribuído para a base inferior.");
			
			this.controlador = controlador;

			AoDefinirControlador(controlador);

            return true;
		}

		/// <summary>
		/// Ocorre ao definir o controlador.
		/// </summary>
		/// <param name="controlador">Controlador definido.</param>
		protected virtual void AoDefinirControlador(ControladorBaseInferior controlador)
		{
			// Nada aqui.
		}

		/// <summary>
		/// Ocorre ao carregar completamente o programa.
		/// </summary>
		/// <remarks>Neste ponto já existe um usuário identificado.</remarks>
		protected internal virtual void AoCarregarCompletamente(Splash splash)
		{
            foreach (Control controle in esquerda.Controls)
            {
                IRequerPrivilégio controlePrivilégio = controle as IRequerPrivilégio;
                if (controlePrivilégio != null)
                     if (!PermissãoFuncionário.ValidarPermissão(controlePrivilégio.Privilégio))
                        esquerda.Controls.Remove(controle);
            }
            DispararPósCarga(Controls, splash);
		}

        /// <summary>
        /// Executa pós-carga nos controles que implementam a
        /// interface "IPósCargaSistema".
        /// </summary>
        /// <param name="controles">Conjunto de controles que
        /// podem ou não implementar IPósCargaSistema.</param>
        private void DispararPósCarga(ControlCollection controles, Splash splash)
        {
            bool falha = false;
            string problema = "";

            foreach (Control controle in controles)
            {
                IPósCargaSistema controlePósCarga = controle as IPósCargaSistema;

                try
                {
                    if (controlePósCarga != null)
                        controlePósCarga.AoCarregarCompletamente(splash);

                    DispararPósCarga(controle.Controls, splash);
                }
                catch (Exception e)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                    falha = true;
                    problema += "\n" + controle.GetType().ToString();
                }
            }

            if (falha)
                throw new ExceçãoPósCarga(problema);
        }

		/// <summary>
		/// Se a base inferior é a base atual.
		/// </summary>
		[Browsable(false)]
		public bool BaseAtual
		{
			get { return Controlador.Exibição == this; }
		}

		/// <summary>
		/// Se o controlador está com base inferior em exibição.
		/// </summary>
		[Browsable(false)]
		public bool Exibindo
		{
			get { return Controlador.Formulário.BaseAtual == this; }
		}

        /// <summary>
        /// Privilégio(s) necessário(s) para exibição da base inferior.
        /// </summary>
        [DefaultValue(Permissão.Nenhuma)]
        public Permissão Privilégio
        {
            get { return privilégios; }
            set { privilégios = value; }
        }

        /// <summary>
        /// Ocorre quando controles são alterados na esquerda.
        /// </summary>
        private void esquerda_Layout(object sender, LayoutEventArgs e)
        {
            if (!DesignMode && jáAberto && e.AffectedControl is IRequerPrivilégio)
                if (!PermissãoFuncionário.ValidarPermissão(((IRequerPrivilégio)e.AffectedControl).Privilégio))
                    esquerda.Controls.Remove(e.AffectedControl);
        }

        /// <summary>
        /// Ocorer quando um controle é adicionado no lado esquerdo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void esquerda_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Left = quadroNavegação.Left;
            e.Control.Width = quadroNavegação.Width;

            if (!DesignMode)
            {
                hashVisibilidade[e.Control] = e.Control.Visible;
                e.Control.VisibleChanged += new EventHandler(EsquerdaControl_VisibleChanged);
            }

            if (DesignMode && e.Control.Top < quadroNavegação.Top)
                MessageBox.Show("O controle " + e.Control.Name + " encontra-se acima da margem superior!");
        }

        private Dictionary<Control, bool> hashVisibilidade = new Dictionary<Control, bool>();

        void EsquerdaControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Control mudado = (Control)sender;

                if (mudado.Visible != hashVisibilidade[mudado])
                {
                    hashVisibilidade[mudado] = mudado.Visible;

                    if (mudado.Visible)
                    {
                        foreach (Control controle in esquerda.Controls)
                            if (controle.Top >= mudado.Top && controle != mudado && controle.Visible)
                                controle.Top += mudado.Height;
                    }
                    else
                        foreach (Control controle in esquerda.Controls)
                            if (controle.Top >= mudado.Top + mudado.Height && controle.Visible)
                                controle.Top -= mudado.Height;
                }
            }
        }

        /// <summary>
        /// Ocorre quando um controle é removido.
        /// </summary>
        private void esquerda_ControlRemoved(object sender, ControlEventArgs e)
        {
            foreach (Control controle in esquerda.Controls)
                if (controle.Top > e.Control.Top + e.Control.Height)
                    controle.Top -= e.Control.Height;
        }

        /// <summary>
        /// Ocorre quando a base inferior é carregada. Neste momento,
        /// são verificados os controles adicionados, caso a base
        /// encontra-se em modo de design.
        /// </summary>
        private void BaseInferior_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                quadroNavegação.Visible = false;
                this.esquerda.Paint += new System.Windows.Forms.PaintEventHandler(this.Design_EsquerdaPaint);
            }
        }

        /// <summary>
        /// Ocorre ao desenhar o lado esquerdo da base, quando esta se
        /// encontra em modo de design.
        /// </summary>
        private void Design_EsquerdaPaint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
            {
                e.Graphics.DrawLine(Pens.Green,
                    quadroNavegação.Left,
                    quadroNavegação.Top,
                    quadroNavegação.Right,
                    quadroNavegação.Top);

                e.Graphics.DrawLine(Pens.Green,
                    quadroNavegação.Left,
                    600 - 93 - System.Windows.Forms.SystemInformation.CaptionHeight,
                    quadroNavegação.Right,
                    600 - 93 - System.Windows.Forms.SystemInformation.CaptionHeight);

                e.Graphics.DrawString(
                    "Insira sobre a linha verde o primeiro quadro.",
                    this.Font, Brushes.Green,
                    new Rectangle(quadroNavegação.Left,
                    quadroNavegação.Top, quadroNavegação.Width,
                    quadroNavegação.Height));
            }
        }

        /// <summary>
        /// Esconde o quadro de navegação entre bases inferiores.
        /// </summary>
        protected void EsconderQuadroNavegação()
        {
            quadroNavegação.Visible = false;
        }
	}
}
