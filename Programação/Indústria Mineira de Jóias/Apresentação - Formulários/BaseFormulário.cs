using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using Entidades.Privilégio;
using System.IO;
using System.Collections.Generic;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class BaseFormulário : System.Windows.Forms.Form
	{
		// Atributos
		private BaseInferior baseAtual;

		/// <summary>
		/// Delegação para evento de substituição. O parâmetro cancelar
		/// impede a substituição da base inferior.
		/// </summary>
		public delegate void Substituição(object sender, BaseFormulário formulário, BaseInferior anterior, BaseInferior nova, out bool cancelar);

		/// <summary>
		/// Ocorre ao substituir a base inferior.
		/// </summary>
		public event Substituição AoSubstituirBaseInferior;

		// Formulário
		protected System.Windows.Forms.Panel topo;
		private System.Windows.Forms.Panel conteúdo;
		protected Apresentação.Formulários.BaseInferior baseInferior;
		protected Apresentação.Formulários.BarraBotões barraBotões;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BaseFormulário()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			baseAtual = baseInferior;

            if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width <= 800)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
		}

        /// <summary>
        /// Ocorre toda vez que um assembly é carregado tardiamente.
        /// </summary>
        private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            foreach (ExporBotãoAttribute exportação in args.LoadedAssembly.GetCustomAttributes(typeof(ExporBotãoAttribute), true))
            {
                Botão botão = ExportarBotão(args.LoadedAssembly, exportação);

                if (botão != null)
                    botão.Controlador.AoCarregarCompletamente(null);
            }
        }

        private static int ordem = 1;

        /// <summary>
        /// Insere o botão exportado à barra de botões.
        /// </summary>
        private Botão ExportarBotão(Assembly assembly, ExporBotãoAttribute exportação)
        {
            if (exportação.ExigirFuncionário && Entidades.Pessoa.Funcionário.FuncionárioAtual == null)
                return null;

            if (PermissãoFuncionário.ValidarPermissão(exportação.Permissões))
            {
                Botão botão;

                if (exportação.Botão == null)
                {
                    try
                    {
                        botão = new Botão();
                        botão.Texto = exportação.Texto;
                        botão.Privilégios = exportação.Permissões;
                        botão.BaseFormulário = this;

                        if (exportação.Ordenação.HasValue)
                            botão.Ordenação = exportação.Ordenação.Value;
                        else
                        {
                            botão.Ordenação = ordem;

                            if (ordem > 0)
                                ordem = -ordem - 1;
                            else
                                ordem = -ordem + 1;
                        }

                        if (exportação.Controlador != null)
                            botão.Controlador = (ControladorBaseInferior)exportação.Controlador.Assembly.CreateInstance(exportação.Controlador.FullName);

                        botão.RetornarÀPrimeira = exportação.RetornarÀPrimeira;

                        foreach (Type tipo in exportação.Bases)
                            botão.Controlador.InserirBaseInferior((BaseInferior)tipo.Assembly.CreateInstance(tipo.FullName));

                        if (botão.Controlador.Bases.Count > 0 && botão.Controlador.Bases[0].Imagem != null)
                            botão.Imagem = botão.Controlador.Bases[0].Imagem;
                    }
                    catch (ExceçãoBotãoNãoSuportado)
                    {
                        return null;
                    }
                }
                else
                    botão = (Botão)exportação.Botão.Assembly.CreateInstance(exportação.Botão.FullName);

                barraBotões.AdicionarBotão(botão);

                return botão;
            }

            return null;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

            barraBotões.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFormulário));
            this.topo = new System.Windows.Forms.Panel();
            this.barraBotões = new Apresentação.Formulários.BarraBotões();
            this.conteúdo = new System.Windows.Forms.Panel();
            this.baseInferior = new Apresentação.Formulários.BaseInferior();
            this.topo.SuspendLayout();
            this.conteúdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // topo
            // 
            this.topo.BackColor = System.Drawing.Color.Transparent;
            this.topo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topo.BackgroundImage")));
            this.topo.Controls.Add(this.barraBotões);
            this.topo.Dock = System.Windows.Forms.DockStyle.Top;
            this.topo.Location = new System.Drawing.Point(0, 0);
            this.topo.Name = "topo";
            this.topo.Size = new System.Drawing.Size(1200, 93);
            this.topo.TabIndex = 2;
            // 
            // barraBotões
            // 
            this.barraBotões.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barraBotões.BackColor = System.Drawing.Color.Transparent;
            this.barraBotões.Botões = new Apresentação.Formulários.Botão[0];
            this.barraBotões.Cursor = System.Windows.Forms.Cursors.Hand;
            this.barraBotões.Location = new System.Drawing.Point(188, 0);
            this.barraBotões.Name = "barraBotões";
            this.barraBotões.Size = new System.Drawing.Size(1012, 75);
            this.barraBotões.TabIndex = 0;
            // 
            // conteúdo
            // 
            this.conteúdo.Controls.Add(this.baseInferior);
            this.conteúdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conteúdo.Location = new System.Drawing.Point(0, 93);
            this.conteúdo.Name = "conteúdo";
            this.conteúdo.Size = new System.Drawing.Size(1200, 490);
            this.conteúdo.TabIndex = 3;
            // 
            // baseInferior
            // 
            this.baseInferior.BackColor = System.Drawing.Color.White;
            this.baseInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseInferior.Location = new System.Drawing.Point(0, 0);
            this.baseInferior.Name = "baseInferior";
            this.baseInferior.Size = new System.Drawing.Size(1200, 490);
            this.baseInferior.TabIndex = 4;
            // 
            // BaseFormulário
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 583);
            this.Controls.Add(this.conteúdo);
            this.Controls.Add(this.topo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "BaseFormulário";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indústria Mineira de Jóias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topo.ResumeLayout(false);
            this.conteúdo.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Substitui base inferior por outra.
		/// </summary>
		protected internal void SubstituirBase(BaseInferior b, object sender)
		{
            UseWaitCursor = true;

            try
            {
                if (b == null)
                    b = baseInferior;

                // Dispara evento de substituição.
                if (AoSubstituirBaseInferior != null)
                {
                    bool cancelar;

                    AoSubstituirBaseInferior(sender, this, baseAtual, b, out cancelar);

                    if (cancelar)
                    {
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                }

                // Verifica se controladora é a mesma
                if (b.Controlador != baseAtual.Controlador && baseAtual.Controlador != null)
                    baseAtual.Controlador.AoEsconder();

                this.SuspendLayout();
                conteúdo.SuspendLayout();

                // Preparar nova base inferior.
                b.SuspendLayout();
                b.Dock = System.Windows.Forms.DockStyle.None;
                b.Size = conteúdo.Size;
                b.Location = new System.Drawing.Point(0, 0);
                b.ResumeLayout();

                conteúdo.Controls.Clear();
                conteúdo.Controls.Add(b);

                conteúdo.ResumeLayout();
                this.ResumeLayout();

                b.Dock = System.Windows.Forms.DockStyle.Fill;

                baseAtual.DispararAoSerSubstituido(b);

                // Verifica se controladora é a mesma
                if (b.Controlador != baseAtual.Controlador && b.Controlador != null)
                    b.Controlador.AoExibir();

                baseAtual = b;

                // Dispara evento de exibição.
                b.DispararAoExibir();
            }
            finally
            {
                UseWaitCursor = false;
            }
		}

		/// <summary>
		/// Prepara base para ser utilizada
		/// </summary>
		/// <param name="b">Base inferior a ser utilizada.</param>
		protected internal void NovaBase(BaseInferior b)
		{
			b.BackColor = baseInferior.BackColor;
			b.Dock = System.Windows.Forms.DockStyle.Fill;
			b.Name = "baseInferior";
			b.Location = new System.Drawing.Point(0, 93);
			b.Size = new System.Drawing.Size(792, 413);
			b.TabIndex = 2;
		}

		/// <summary>
		/// É chamada assim que a todo o programa já está carregado.
		/// </summary>
        protected virtual void AoCarregarCompletamente(Splash splash)
        {
            bool falha = false;
            string problema = "";
            List<Botão> remoção = new List<Botão>();

            foreach (Botão botão in barraBotões.Botões)
            {
                //if (splash != null)
                //    splash.Mensagem = "Carregando botões principais: " + botão.Texto;

                try
                {
                    botão.Controlador.AoCarregarCompletamente(splash);
                }
                catch (ExceçãoBotãoNãoSuportado)
                {
                    remoção.Add(botão);
                }
                catch (ExceçãoPósCarga e)
                {
                    problema += "\n" + e.Message;
                    falha = true;
                }
                catch (Exception e)
                {
#if DEBUG
                    System.Windows.Forms.MessageBox.Show(e.ToString());
#endif
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                    problema += "\n" + baseInferior.GetType().ToString();
                    falha = true;
                }
            }

            foreach (Botão botão in remoção)
            {
                barraBotões.RemoverBotão(botão);
                botão.Dispose();
            }

            baseInferior.AoCarregarCompletamente(splash);
            baseInferior.DispararAoExibir();

            if (falha)
                throw new ExceçãoPósCarga(problema);
        }

		/// <summary>
		/// Deve ser chamado pelo programa de apresentação depois
        /// que os botões são configurados.
		/// </summary>
        /// 
		public void DispararAoCarregar(Splash splash)
		{
			System.Windows.Forms.Cursor cursorAnterior = Cursor.Current;

			Cursor.Current = Cursors.WaitCursor;

            if (splash != null)
                splash.Mensagem = "Cravando gemas...";
                //splash.Mensagem = "Consultando preços das mercadorias...";

            Entidades.Mercadoria.Mercadoria.IniciarCarga();
            //Entidades.Pessoa.PessoaBusca.Instância.Preparar();

            /* Carrega todos os botões declarados
             * nos assemblys.
             */
            ImportarBotões(splash);

            // Dispara o evento
			AoCarregarCompletamente(splash);

			this.Refresh();
			
			Cursor.Current = cursorAnterior;
		}

        private void ImportarBotões(Splash splash)
        {
            try
            {
                //if (splash != null)
                //    splash.Mensagem = "Criando botões de usuário...";

                // Insere todos os botões exportados.
                //foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                string caminho = AppDomain.CurrentDomain.BaseDirectory;
                //string[] partes = AppDomain.CurrentDomain.BaseDirectory

                //for (int i = 0; i < partes.Length - 1; i++)
                //    caminho += partes[i] + @"\";

                if (splash != null)
                    splash.Mensagem = "Polimento...";

                foreach (string arquivo in Directory.GetFiles(
                    caminho,
                    "Apresentacao.*.dll", SearchOption.TopDirectoryOnly))
                {
                    //if (splash != null)
                    //{
                    //    string[] pedaços = arquivo.Split('\\');
                    //    splash.Mensagem = "Preparando Ambiente " + pedaços[pedaços.Length - 1].
                    //        Replace("Apresentacao.", "").Replace(".dll", "").Replace(".", " ");
                        
                    //}

                    //Assembly assembly = Assembly.LoadFrom(arquivo);
                    Assembly assembly = Assembly.LoadFile(arquivo);

                    //if (splash != null)
                    //    splash.Mensagem = "Criando botões de usuário... (" + assembly.FullName + ")";

                    foreach (ExporBotãoAttribute exportação in assembly.GetCustomAttributes(typeof(ExporBotãoAttribute), true))
                        ExportarBotão(assembly, exportação);
                }

                AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(CurrentDomain_AssemblyLoad);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Application.Exit();
            }
        }

		/// <summary>
		/// Base atual.
		/// </summary>
		public BaseInferior BaseAtual
		{
			get { return baseAtual; }
		}

        protected override void OnClosed(EventArgs e)
        {
            baseAtual.DispararAoSerSubstituido(null);

            base.OnClosed(e);

            Dispose();
        }
	}
}
