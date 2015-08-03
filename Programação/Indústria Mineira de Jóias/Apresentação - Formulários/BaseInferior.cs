using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Privil�gio;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Base inferior do formul�rio base
	/// </summary>
	[Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", 
		 typeof(System.ComponentModel.Design.IDesigner))]
	[Serializable]
    public class BaseInferior : System.Windows.Forms.UserControl, IRequerPrivil�gio
	{
		private bool                    j�Aberto = false; // A baseInferior j� foi completamente aberta
		internal BaseInferior           baseAnterior;
		private ControladorBaseInferior controlador;
        private Permiss�o               privil�gios = Permiss�o.Nenhuma;
        
        /// <summary>
        /// Imagem a ser exibida no bot�o.
        /// </summary>
        private Image imagem = null;

		// Componentes
        protected System.Windows.Forms.Panel esquerda;
        private QuadroNavega��o quadroNavega��o;

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
            this.quadroNavega��o = new Apresenta��o.Formul�rios.QuadroNavega��o();
            this.esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(183)))), ((int)(((byte)(153)))));
            this.esquerda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("esquerda.BackgroundImage")));
            this.esquerda.Controls.Add(this.quadroNavega��o);
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
            // quadroNavega��o
            // 
            this.quadroNavega��o.BackColor = System.Drawing.Color.Transparent;
            this.quadroNavega��o.Location = new System.Drawing.Point(7, 13);
            this.quadroNavega��o.MaximumSize = new System.Drawing.Size(160, 48);
            this.quadroNavega��o.MinimumSize = new System.Drawing.Size(160, 48);
            this.quadroNavega��o.Name = "quadroNavega��o";
            this.quadroNavega��o.Size = new System.Drawing.Size(160, 48);
            this.quadroNavega��o.TabIndex = 0;
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

        [Description("Imagem a ser utilizada pelo bot�o."), DefaultValue(null)]
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
		/// Substitui base inferior atual por uma tempor�ria.
        /// Assim que for novamente substitu�da, a base ser� desalocada.
		/// </summary>
		/// <param name="novaBase">Nova base inferior a ser exibida pelo formul�rio</param>
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
			controlador.AutoExibi��o(this);
		}

		/// <summary>
		/// Ocorre ao ser exibida pelo formul�rio base,
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
        /// adequadamente a partir do in�cio delimitado.
        /// </summary>
        private void OrganizarControlesEsquerda()
        {
            List<Control> controles = new List<Control>(esquerda.Controls.Count);
            int y = quadroNavega��o.Top;

            if (quadroNavega��o.Visible)
                y += quadroNavega��o.Height + quadroNavega��o.Left;

            foreach (Control controle in esquerda.Controls)
                if (controle != quadroNavega��o)
                    controles.Add(controle);

            controles.Sort(new Comparison<Control>(CompararControlesAltura));

            esquerda.SuspendLayout();

            foreach (Control controle in controles)
            {
                controle.Top = y;

                if (controle.Visible)
                    y += controle.Height + quadroNavega��o.Left;
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
		/// Ocorre ao ser exibido pelo formul�rio base da primeira vez.
		/// (� a primeira vez que � chamado o AoExibir())
		/// </summary>
		protected virtual void AoExibirDaPrimeiraVez()
		{
            Queue<ControlCollection> controles;

            Permiss�oFuncion�rio.AssegurarPermiss�o(privil�gios);

            foreach (Control controle in esquerda.Controls)
            {
                IRequerPrivil�gio controlePrivil�gio = controle as IRequerPrivil�gio;

                if (controlePrivil�gio != null && !Permiss�oFuncion�rio.ValidarPermiss�o(controlePrivil�gio.Privil�gio))
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
        /// Ocorre ao ser substitu�do por nova base.
        /// </summary>
        /// <param name="novaBase">Base que o substituiu.</param>
        protected virtual void AoSerSubstitu�do(BaseInferior novaBase)
        {
        }

		/// <summary>
		/// M�todo utilizado pelo formul�rio base
		/// </summary>
		internal void DispararAoExibir()
		{
            UseWaitCursor = true;

			if (!j�Aberto) 
			{
				j�Aberto = true;
				AoExibirDaPrimeiraVez();
			}

			AoExibir();

            UseWaitCursor = false;
		}

        /// <summary>
        /// M�todo utilizado pelo formul�rio base.
        /// </summary>
        internal void DispararAoSerSubstituido(BaseInferior novaBase)
        {
            AoSerSubstitu�do(novaBase);
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
            // Em caso de retorno � base inferior...
            if (this.controlador == controlador)
                return false;

            // no entanto, controladores diferentes n�o s�o permitidos!
			if (this.controlador != null)
				throw new Exception("Controlador j� foi atribu�do para a base inferior.");
			
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
		/// <remarks>Neste ponto j� existe um usu�rio identificado.</remarks>
		protected internal virtual void AoCarregarCompletamente(Splash splash)
		{
            foreach (Control controle in esquerda.Controls)
            {
                IRequerPrivil�gio controlePrivil�gio = controle as IRequerPrivil�gio;
                if (controlePrivil�gio != null)
                     if (!Permiss�oFuncion�rio.ValidarPermiss�o(controlePrivil�gio.Privil�gio))
                        esquerda.Controls.Remove(controle);
            }
            DispararP�sCarga(Controls, splash);
		}

        /// <summary>
        /// Executa p�s-carga nos controles que implementam a
        /// interface "IP�sCargaSistema".
        /// </summary>
        /// <param name="controles">Conjunto de controles que
        /// podem ou n�o implementar IP�sCargaSistema.</param>
        private void DispararP�sCarga(ControlCollection controles, Splash splash)
        {
            bool falha = false;
            string problema = "";

            foreach (Control controle in controles)
            {
                IP�sCargaSistema controleP�sCarga = controle as IP�sCargaSistema;

                try
                {
                    if (controleP�sCarga != null)
                        controleP�sCarga.AoCarregarCompletamente(splash);

                    DispararP�sCarga(controle.Controls, splash);
                }
                catch (Exception e)
                {
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                    falha = true;
                    problema += "\n" + controle.GetType().ToString();
                }
            }

            if (falha)
                throw new Exce��oP�sCarga(problema);
        }

		/// <summary>
		/// Se a base inferior � a base atual.
		/// </summary>
		[Browsable(false)]
		public bool BaseAtual
		{
			get { return Controlador.Exibi��o == this; }
		}

		/// <summary>
		/// Se o controlador est� com base inferior em exibi��o.
		/// </summary>
		[Browsable(false)]
		public bool Exibindo
		{
			get { return Controlador.Formul�rio.BaseAtual == this; }
		}

        /// <summary>
        /// Privil�gio(s) necess�rio(s) para exibi��o da base inferior.
        /// </summary>
        [DefaultValue(Permiss�o.Nenhuma)]
        public Permiss�o Privil�gio
        {
            get { return privil�gios; }
            set { privil�gios = value; }
        }

        /// <summary>
        /// Ocorre quando controles s�o alterados na esquerda.
        /// </summary>
        private void esquerda_Layout(object sender, LayoutEventArgs e)
        {
            if (!DesignMode && j�Aberto && e.AffectedControl is IRequerPrivil�gio)
                if (!Permiss�oFuncion�rio.ValidarPermiss�o(((IRequerPrivil�gio)e.AffectedControl).Privil�gio))
                    esquerda.Controls.Remove(e.AffectedControl);
        }

        /// <summary>
        /// Ocorer quando um controle � adicionado no lado esquerdo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void esquerda_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Left = quadroNavega��o.Left;
            e.Control.Width = quadroNavega��o.Width;

            if (!DesignMode)
            {
                hashVisibilidade[e.Control] = e.Control.Visible;
                e.Control.VisibleChanged += new EventHandler(EsquerdaControl_VisibleChanged);
            }

            if (DesignMode && e.Control.Top < quadroNavega��o.Top)
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
        /// Ocorre quando um controle � removido.
        /// </summary>
        private void esquerda_ControlRemoved(object sender, ControlEventArgs e)
        {
            foreach (Control controle in esquerda.Controls)
                if (controle.Top > e.Control.Top + e.Control.Height)
                    controle.Top -= e.Control.Height;
        }

        /// <summary>
        /// Ocorre quando a base inferior � carregada. Neste momento,
        /// s�o verificados os controles adicionados, caso a base
        /// encontra-se em modo de design.
        /// </summary>
        private void BaseInferior_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                quadroNavega��o.Visible = false;
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
                    quadroNavega��o.Left,
                    quadroNavega��o.Top,
                    quadroNavega��o.Right,
                    quadroNavega��o.Top);

                e.Graphics.DrawLine(Pens.Green,
                    quadroNavega��o.Left,
                    600 - 93 - System.Windows.Forms.SystemInformation.CaptionHeight,
                    quadroNavega��o.Right,
                    600 - 93 - System.Windows.Forms.SystemInformation.CaptionHeight);

                e.Graphics.DrawString(
                    "Insira sobre a linha verde o primeiro quadro.",
                    this.Font, Brushes.Green,
                    new Rectangle(quadroNavega��o.Left,
                    quadroNavega��o.Top, quadroNavega��o.Width,
                    quadroNavega��o.Height));
            }
        }

        /// <summary>
        /// Esconde o quadro de navega��o entre bases inferiores.
        /// </summary>
        protected void EsconderQuadroNavega��o()
        {
            quadroNavega��o.Visible = false;
        }
	}
}
