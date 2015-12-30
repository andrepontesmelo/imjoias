using System;
using System.ComponentModel;
//using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Entidades.Privil�gio;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// O controlador da base inferior � quem controla a
	/// exibi��o das base inferiores correlacionadas em um
	/// formul�rio, por meio de comunica��o interna com as
	/// classes <see cref="BaseFormul�rio"/> e <see cref="Bot�o"/>.
	/// 
	/// O intu�to do controlador � deixar o c�digo da base inferior
	/// mais enxuto, voltado somente � interface gr�fica, permitindo
	/// ao usu�rio, assim, a partir de um mesmo bot�o, acessar
    ///	diferentes bases inferiores.
    ///	</summary>
    ///	
    ///	<remarks>
	/// As bases inferiores podem ser correlacionadas de duas maneiras:
	///  i) Pelo SubstituirBase.
	/// ii) Pelo m�todo "Controlador.InserirBaseInferior";
	/// 
	/// Quando se utiliza o m�todo SubstituirBase de uma base inferior,
	/// n�o estando ela inserida no controlador pelo m�todo
	/// "InserirBaseInferior", a base a ser exibida ser� considerada
	/// tempor�ria, tendo seus recursos liberados logo que tamb�m,
	/// substitu�da.
	/// 
	/// Quando a base inferior for inserida no controlador, ela ser�
	/// considerada permanente e nunca ter� seus recursos liberados
	/// por ele.
	/// 
	/// Em um mesmo controlador, pode-se ter v�rias bases inferiores
	/// inseridas.
	/// </remarks>
	public class ControladorBaseInferior : System.ComponentModel.Component
	{
		private BaseInferior        baseAtual;
		private BaseFormul�rio      baseFormul�rio;
		private List<BaseInferior>  basesInferiores      = new List<BaseInferior>();
        private Bot�o               bot�o;
        private bool                retornar�Primeira;
		private bool	            permitirAutoExibi��o = true;

        /// <summary>
        /// Lista de bases inferiores que j� foram exibidas,
        /// por�m o usu�rio requisitou para voltar � tela anterior.
        /// Esta lista � esvaziada sempre que uma nova base � exibida.
        /// </summary>
        private List<BaseInferior> basesPosteriores = new List<BaseInferior>();

        public delegate void Substitui��oCallback(ControladorBaseInferior controlador, BaseInferior anterior, BaseInferior atual);

        /// <summary>
        /// Ocorre ao substituir base inferior.
        /// </summary>
        public event Substitui��oCallback AoSubstituirBase;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ControladorBaseInferior(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
			
			if (components == null)
				components = new Container();
		}

		public ControladorBaseInferior()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			if (components == null)
				components = new Container();
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

            if (basesInferiores != null)
                foreach (BaseInferior baseInferior in basesInferiores)
                    baseInferior.Dispose();

            if (basesPosteriores != null)
                foreach (BaseInferior baseInferior in basesPosteriores)
                    baseInferior.Dispose();

            baseAtual = null;
            baseFormul�rio = null;
            basesInferiores = null;
            basesPosteriores = null;
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Formul�rio em que est� contido.
		/// </summary>
		[Browsable(false)]
		public virtual BaseFormul�rio Formul�rio
		{
			get 
			{
				if (baseFormul�rio == null)
					throw new Exception("Formul�rio ainda n�o estabelecido.");
				
				return baseFormul�rio; 
			}
			set
			{
				if (baseFormul�rio != null)
					throw new Exception("Formul�rio j� estabelecido.");

                if (value == null)
                    throw new ArgumentNullException("Formul�rio", "Formul�rio n�o pode ser nulo!");

				baseFormul�rio = value;
			}
		}

		/// <summary>
		/// Determina se ao esconder o controle exibir�
		/// da pr�xima vez a primeira base inferior inserida.
		/// </summary>
		[DefaultValue(false),
			Description("Determina se ao esconder o controle exibir� da pr�xima vez a primeira base inferior inserida.")]
		public bool Retornar�Primeira
		{
			get { return retornar�Primeira; }
			set { retornar�Primeira = value; }
		}

		/// <summary>
		/// Base inferior que est� em exibi��o.
		/// </summary>
		[Browsable(false)]
		public BaseInferior Exibi��o
		{
			get { return baseAtual; }
		}

		/// <summary>
		/// Se o controlador est� com base inferior em exibi��o.
		/// </summary>
		[Browsable(false)]
		public bool Exibindo
		{
			get { return baseFormul�rio.BaseAtual.Controlador == this; }
		}

		/// <summary>
		/// Bot�o vinculado ao controlador.
		/// </summary>
		public Bot�o Bot�o
		{
			get { return bot�o; }
		}

		/// <summary>
		/// Permite que uma base inferior se auto exiba.
		/// </summary>
		[DefaultValue(true), Description("Permite que uma base inferior se auto exiba.")]
		public bool PermitirAutoExibi��o
		{
			get { return permitirAutoExibi��o; }
			set { permitirAutoExibi��o = value; }
		}

        /// <summary>
        /// Lista de bases inferiores.
        /// </summary>
        public IList<BaseInferior> Bases
        {
            get { return basesInferiores; }
        }

		#endregion

		/// <summary>
		/// Define o bot�o associado ao controlador.
		/// </summary>
		/// <param name="bot�o">Bot�o associado.</param>
		/// <remarks>S� deve ser chamado pelo Bot�o.</remarks>
		internal void DefinirBot�o(Bot�o bot�o)
		{
			if (this.bot�o != null)
				throw new Exception("Bot�o j� associado a este controlador.");

			this.bot�o = bot�o;
		}

		/// <summary>
		/// Insere base inferior.
		/// </summary>
		/// <param name="baseInferior">Base inferior a ser exibida.</param>
		public void InserirBaseInferior(BaseInferior baseInferior)
		{
            if (Permiss�oFuncion�rio.ValidarPermiss�o(baseInferior.Privil�gio))
            {
                components.Add(baseInferior);
                basesInferiores.Add(baseInferior);

                baseInferior.DefinirControlador(this);

                Formul�rio.NovaBase(baseInferior);

                AoInserirBaseInferior(baseInferior);
            }
		}

        /// <summary>
        /// Remove base inferior.
        /// </summary>
        /// <param name="baseInferior"></param>
        public void RemoverBaseInferior(BaseInferior baseInferior)
        {
            components.Remove(baseInferior);
            basesInferiores.Remove(baseInferior);
        }

		/// <summary>
		/// Substitui base inferior atual por outra.
		/// </summary>
		/// <param name="novaBase">Nova base inferior a ser exibida pelo formul�rio.</param>
		/// <param name="origem">Quem mandou substituir.</param>
		/// <remarks>Chamada pela base inferior.</remarks>
		internal void SubstituirBase(BaseInferior novaBase, BaseInferior origem)
		{
			if (origem != baseAtual)
				throw new Exception("Base de origem n�o pode substituir base, pois n�o � a base atual!");

			if (!basesInferiores.Contains(novaBase))
			{
                Permiss�oFuncion�rio.AssegurarPermiss�o(novaBase.Privil�gio);

                if (novaBase.DefinirControlador(this))
                {
                    Formul�rio.NovaBase(novaBase);
                    novaBase.AoCarregarCompletamente(null);
                }
			}

			SubstituirBaseAtual(novaBase);
			MostrarBaseFormul�rio(novaBase);
		}

		/// <summary>
		/// Auto-exibi��o de uma base inferior.
		/// </summary>
		/// <param name="novaBase">Base inferior que est� se exibindo.</param>
		internal void AutoExibi��o(BaseInferior novaBase)
		{
			if (!permitirAutoExibi��o)
				throw new ApplicationException("Auto-exibi��o n�o � permitida para este controle.");

			if (!basesInferiores.Contains(novaBase))
				throw new ApplicationException("Auto-exibi��o de uma base que n�o est� inserida no controlador.");

			SubstituirBaseAtual(novaBase);
			MostrarBaseFormul�rio(novaBase);

			if (!Exibindo)
				Exibir();
		}

		/// <summary>
		/// Substitui a base inferior atual pela base inferior
		/// exibida anteriormente.
		/// </summary>
		internal void SubstituirBaseParaAnterior()
		{
            //if (baseAtual.baseAnterior == null)
            //    throw new NullReferenceException("N�o existe base anterior registrada.");

            //SubstituirBase(baseAtual.baseAnterior, baseAtual);

            if (baseAtual.baseAnterior != null)
                SubstituirBase(baseAtual.baseAnterior, baseAtual);
		}

		/// <summary>
		/// Substitui a base inferior atual pela primeira.
		/// </summary>
		internal void SubstituirBaseParaInicial()
		{
			SubstituirBase(basesInferiores[0], baseAtual);
		}

        /// <summary>
        /// Substitui base inferior atual por outra, mesmo que esta
        /// n�o tenha nenhum v�nculo com a base em exibi��o. O usu�rio
        /// � questionado se ele deseja que a base seja substitu�da.
        /// </summary>
        /// <param name="novaBase">Base inferior a ser exibida.</param>
        /// <param name="t�tulo">T�tulo da base inferior.</param>
        /// <param name="descri��o">Descri��o da base inferior.</param>
        public void SubstituirBaseArbitrariamente(BaseInferior novaBase, string t�tulo, string descri��o)
        {
            if (novaBase == baseAtual)
                return;

            using (QuestionarSubstitui��oBI dlg = new QuestionarSubstitui��oBI(t�tulo, descri��o))
            {
                if (dlg.ShowDialog(baseFormul�rio) == System.Windows.Forms.DialogResult.OK)
                {
                    if (!basesInferiores.Contains(novaBase))
                    {
                        Permiss�oFuncion�rio.AssegurarPermiss�o(novaBase.Privil�gio);

                        novaBase.DefinirControlador(this);
                        Formul�rio.NovaBase(novaBase);
                        novaBase.AoCarregarCompletamente(null);
                    }

                    SubstituirBaseAtual(novaBase);
                    MostrarBaseFormul�rio(novaBase);
                }
            }
        }

		/// <summary>
		/// Substitui base inferior atual por outra, sem substituir
		/// no formul�rio.
		/// </summary>
		/// <param name="novaBase">Nova base inferior definida como atual.</param>
		protected void SubstituirBaseAtual(BaseInferior novaBase)
		{
            BaseInferior anterior = baseAtual;

            // Verificar se estamos retornando
            if (baseAtual != null && novaBase == baseAtual.baseAnterior)
            {
                basesPosteriores.Add(baseAtual);
            }
            else // se n�o estamos retornando
            {
                /* Se a nova base inferior � tempor�ria, deve-se
                 * manter as bases anteriores at� que uma nova base
                 * inferior permanente seja exibida. Somente neste
                 * caso as bases inferiores anteriores e tempor�rias
                 * ser�o liberadas.
                 */
                if (basesInferiores.Contains(novaBase))
                {
                    if (novaBase != basesInferiores[0])
                        novaBase.baseAnterior = baseAtual;

                    while (baseAtual != null && !basesInferiores.Contains(baseAtual))
                    {
                        novaBase.baseAnterior = baseAtual.baseAnterior;
                        baseAtual.Dispose();
                        baseAtual = novaBase.baseAnterior;
                    }
                }
                else
                    novaBase.baseAnterior = baseAtual;

                LimparBasesPosteriores();
            }

			baseAtual = novaBase;

            if (AoSubstituirBase != null)
                AoSubstituirBase(this, anterior, baseAtual);
		}

        /// <summary>
        /// Limpa as bases posteriores.
        /// </summary>
        private void LimparBasesPosteriores()
        {
            foreach (BaseInferior baseInferior in basesPosteriores)
                if (baseAtual == baseInferior)
                    break;
                else if (!basesInferiores.Contains(baseAtual))
                    baseInferior.Dispose();

            basesPosteriores.Clear();
        }
		
		/// <summary>
		/// Substitui base inferior atual por outra.
		/// </summary>
		/// <param name="novaBase">Nova base inferior a ser exibida pelo formul�rio.</param>
		protected virtual void MostrarBaseFormul�rio(BaseInferior novaBase)
		{
			Formul�rio.SubstituirBase(novaBase, this);
		}

		/// <summary>
		/// Ocorre ao exibir.
		/// </summary>
		/// <remarks>
		/// Este m�todo � chamado pelo formul�rio.
		/// </remarks>
		protected internal virtual void AoExibir()
		{
		}

		/// <summary>
		/// Ocorre ao esconder.
		/// </summary>
		/// <remarks>
		/// Este m�todo � chamado pelo formul�rio.
		/// </remarks>
		protected internal virtual void AoEsconder()
		{
			if (retornar�Primeira)
				SubstituirBaseAtual(basesInferiores[0]);
		}

		/// <summary>
		/// Exibe base atual.
		/// </summary>
		/// <remarks>Este m�todo � chamado ao clicar no bot�o da base superior.</remarks>
		public virtual void Exibir()
		{
			if (basesInferiores.Count == 0)
				throw new Exception("N�o h� nenhuma base inferior associada a este bot�o");

			if (baseAtual == null)
				baseAtual = basesInferiores[0];

			if (retornar�Primeira || Exibindo)
				SubstituirBaseAtual(basesInferiores[0]);

			Formul�rio.SubstituirBase(baseAtual, this);
		}

		/// <summary>
		/// Ocorre quando o programa � carregado completamente.
		/// </summary>
		protected internal virtual void AoCarregarCompletamente(Splash splash)
		{
            bool falha = false;
            string problema = "";

            foreach (BaseInferior baseInferior in basesInferiores)
            {
                //try
                //{
                    baseInferior.AoCarregarCompletamente(splash);
//                }
//                catch (Exce��oP�sCarga e)
//                {
//                    problema += "\n" + e.Message;
//                    falha = true;
//                }
//                catch (Exception e)
//                {
//#if DEBUG
//                    System.Windows.Forms.MessageBox.Show(e.ToString());
//#endif
//                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
//                    problema += "\n" + baseInferior.GetType().ToString();
//                    falha = true;
//                }
            }

            if (falha)
                throw new Exce��oP�sCarga(problema);
		}

		/// <summary>
		/// Ocorre ao inserir uma base inferior.
		/// </summary>
		/// <param name="baseInferior">Base inferior inserida.</param>
		protected virtual void AoInserirBaseInferior(BaseInferior baseInferior)
		{
			// Nada aqui.
		}
    }
}
