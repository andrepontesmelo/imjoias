using System;
using System.ComponentModel;
//using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Entidades.Privilégio;

namespace Apresentação.Formulários
{
	/// <summary>
	/// O controlador da base inferior é quem controla a
	/// exibição das base inferiores correlacionadas em um
	/// formulário, por meio de comunicação interna com as
	/// classes <see cref="BaseFormulário"/> e <see cref="Botão"/>.
	/// 
	/// O intuíto do controlador é deixar o código da base inferior
	/// mais enxuto, voltado somente à interface gráfica, permitindo
	/// ao usuário, assim, a partir de um mesmo botão, acessar
    ///	diferentes bases inferiores.
    ///	</summary>
    ///	
    ///	<remarks>
	/// As bases inferiores podem ser correlacionadas de duas maneiras:
	///  i) Pelo SubstituirBase.
	/// ii) Pelo método "Controlador.InserirBaseInferior";
	/// 
	/// Quando se utiliza o método SubstituirBase de uma base inferior,
	/// não estando ela inserida no controlador pelo método
	/// "InserirBaseInferior", a base a ser exibida será considerada
	/// temporária, tendo seus recursos liberados logo que também,
	/// substituída.
	/// 
	/// Quando a base inferior for inserida no controlador, ela será
	/// considerada permanente e nunca terá seus recursos liberados
	/// por ele.
	/// 
	/// Em um mesmo controlador, pode-se ter várias bases inferiores
	/// inseridas.
	/// </remarks>
	public class ControladorBaseInferior : System.ComponentModel.Component
	{
		private BaseInferior        baseAtual;
		private BaseFormulário      baseFormulário;
		private List<BaseInferior>  basesInferiores      = new List<BaseInferior>();
        private Botão               botão;
        private bool                retornarÀPrimeira;
		private bool	            permitirAutoExibição = true;

        /// <summary>
        /// Lista de bases inferiores que já foram exibidas,
        /// porém o usuário requisitou para voltar à tela anterior.
        /// Esta lista é esvaziada sempre que uma nova base é exibida.
        /// </summary>
        private List<BaseInferior> basesPosteriores = new List<BaseInferior>();

        public delegate void SubstituiçãoCallback(ControladorBaseInferior controlador, BaseInferior anterior, BaseInferior atual);

        /// <summary>
        /// Ocorre ao substituir base inferior.
        /// </summary>
        public event SubstituiçãoCallback AoSubstituirBase;

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
            baseFormulário = null;
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
		/// Formulário em que está contido.
		/// </summary>
		[Browsable(false)]
		public virtual BaseFormulário Formulário
		{
			get 
			{
				if (baseFormulário == null)
					throw new Exception("Formulário ainda não estabelecido.");
				
				return baseFormulário; 
			}
			set
			{
				if (baseFormulário != null)
					throw new Exception("Formulário já estabelecido.");

                if (value == null)
                    throw new ArgumentNullException("Formulário", "Formulário não pode ser nulo!");

				baseFormulário = value;
			}
		}

		/// <summary>
		/// Determina se ao esconder o controle exibirá
		/// da próxima vez a primeira base inferior inserida.
		/// </summary>
		[DefaultValue(false),
			Description("Determina se ao esconder o controle exibirá da próxima vez a primeira base inferior inserida.")]
		public bool RetornarÀPrimeira
		{
			get { return retornarÀPrimeira; }
			set { retornarÀPrimeira = value; }
		}

		/// <summary>
		/// Base inferior que está em exibição.
		/// </summary>
		[Browsable(false)]
		public BaseInferior Exibição
		{
			get { return baseAtual; }
		}

		/// <summary>
		/// Se o controlador está com base inferior em exibição.
		/// </summary>
		[Browsable(false)]
		public bool Exibindo
		{
			get { return baseFormulário.BaseAtual.Controlador == this; }
		}

		/// <summary>
		/// Botão vinculado ao controlador.
		/// </summary>
		public Botão Botão
		{
			get { return botão; }
		}

		/// <summary>
		/// Permite que uma base inferior se auto exiba.
		/// </summary>
		[DefaultValue(true), Description("Permite que uma base inferior se auto exiba.")]
		public bool PermitirAutoExibição
		{
			get { return permitirAutoExibição; }
			set { permitirAutoExibição = value; }
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
		/// Define o botão associado ao controlador.
		/// </summary>
		/// <param name="botão">Botão associado.</param>
		/// <remarks>Só deve ser chamado pelo Botão.</remarks>
		internal void DefinirBotão(Botão botão)
		{
			if (this.botão != null)
				throw new Exception("Botão já associado a este controlador.");

			this.botão = botão;
		}

		/// <summary>
		/// Insere base inferior.
		/// </summary>
		/// <param name="baseInferior">Base inferior a ser exibida.</param>
		public void InserirBaseInferior(BaseInferior baseInferior)
		{
            if (PermissãoFuncionário.ValidarPermissão(baseInferior.Privilégio))
            {
                components.Add(baseInferior);
                basesInferiores.Add(baseInferior);

                baseInferior.DefinirControlador(this);

                Formulário.NovaBase(baseInferior);

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
		/// <param name="novaBase">Nova base inferior a ser exibida pelo formulário.</param>
		/// <param name="origem">Quem mandou substituir.</param>
		/// <remarks>Chamada pela base inferior.</remarks>
		internal void SubstituirBase(BaseInferior novaBase, BaseInferior origem)
		{
			if (origem != baseAtual)
				throw new Exception("Base de origem não pode substituir base, pois não é a base atual!");

			if (!basesInferiores.Contains(novaBase))
			{
                PermissãoFuncionário.AssegurarPermissão(novaBase.Privilégio);

                if (novaBase.DefinirControlador(this))
                {
                    Formulário.NovaBase(novaBase);
                    novaBase.AoCarregarCompletamente(null);
                }
			}

			SubstituirBaseAtual(novaBase);
			MostrarBaseFormulário(novaBase);
		}

		/// <summary>
		/// Auto-exibição de uma base inferior.
		/// </summary>
		/// <param name="novaBase">Base inferior que está se exibindo.</param>
		internal void AutoExibição(BaseInferior novaBase)
		{
			if (!permitirAutoExibição)
				throw new ApplicationException("Auto-exibição não é permitida para este controle.");

			if (!basesInferiores.Contains(novaBase))
				throw new ApplicationException("Auto-exibição de uma base que não está inserida no controlador.");

			SubstituirBaseAtual(novaBase);
			MostrarBaseFormulário(novaBase);

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
            //    throw new NullReferenceException("Não existe base anterior registrada.");

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
        /// não tenha nenhum vínculo com a base em exibição. O usuário
        /// é questionado se ele deseja que a base seja substituída.
        /// </summary>
        /// <param name="novaBase">Base inferior a ser exibida.</param>
        /// <param name="título">Título da base inferior.</param>
        /// <param name="descrição">Descrição da base inferior.</param>
        public void SubstituirBaseArbitrariamente(BaseInferior novaBase, string título, string descrição)
        {
            if (novaBase == baseAtual)
                return;

            using (QuestionarSubstituiçãoBI dlg = new QuestionarSubstituiçãoBI(título, descrição))
            {
                if (dlg.ShowDialog(baseFormulário) == System.Windows.Forms.DialogResult.OK)
                {
                    if (!basesInferiores.Contains(novaBase))
                    {
                        PermissãoFuncionário.AssegurarPermissão(novaBase.Privilégio);

                        novaBase.DefinirControlador(this);
                        Formulário.NovaBase(novaBase);
                        novaBase.AoCarregarCompletamente(null);
                    }

                    SubstituirBaseAtual(novaBase);
                    MostrarBaseFormulário(novaBase);
                }
            }
        }

		/// <summary>
		/// Substitui base inferior atual por outra, sem substituir
		/// no formulário.
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
            else // se não estamos retornando
            {
                /* Se a nova base inferior é temporária, deve-se
                 * manter as bases anteriores até que uma nova base
                 * inferior permanente seja exibida. Somente neste
                 * caso as bases inferiores anteriores e temporárias
                 * serão liberadas.
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
		/// <param name="novaBase">Nova base inferior a ser exibida pelo formulário.</param>
		protected virtual void MostrarBaseFormulário(BaseInferior novaBase)
		{
			Formulário.SubstituirBase(novaBase, this);
		}

		/// <summary>
		/// Ocorre ao exibir.
		/// </summary>
		/// <remarks>
		/// Este método é chamado pelo formulário.
		/// </remarks>
		protected internal virtual void AoExibir()
		{
		}

		/// <summary>
		/// Ocorre ao esconder.
		/// </summary>
		/// <remarks>
		/// Este método é chamado pelo formulário.
		/// </remarks>
		protected internal virtual void AoEsconder()
		{
			if (retornarÀPrimeira)
				SubstituirBaseAtual(basesInferiores[0]);
		}

		/// <summary>
		/// Exibe base atual.
		/// </summary>
		/// <remarks>Este método é chamado ao clicar no botão da base superior.</remarks>
		public virtual void Exibir()
		{
			if (basesInferiores.Count == 0)
				throw new Exception("Não há nenhuma base inferior associada a este botão");

			if (baseAtual == null)
				baseAtual = basesInferiores[0];

			if (retornarÀPrimeira || Exibindo)
				SubstituirBaseAtual(basesInferiores[0]);

			Formulário.SubstituirBase(baseAtual, this);
		}

		/// <summary>
		/// Ocorre quando o programa é carregado completamente.
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
//                catch (ExceçãoPósCarga e)
//                {
//                    problema += "\n" + e.Message;
//                    falha = true;
//                }
//                catch (Exception e)
//                {
//#if DEBUG
//                    System.Windows.Forms.MessageBox.Show(e.ToString());
//#endif
//                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
//                    problema += "\n" + baseInferior.GetType().ToString();
//                    falha = true;
//                }
            }

            if (falha)
                throw new ExceçãoPósCarga(problema);
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
