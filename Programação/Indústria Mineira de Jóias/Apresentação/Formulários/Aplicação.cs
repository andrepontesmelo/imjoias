//#define SERVIÇO_IMPRESSÃO

using System;
using System.Collections;
using System.Windows.Forms;
using Acesso.Comum;
using System.Threading;

namespace Apresentação.Formulários
{
    public class Aplicação : System.Windows.Forms.ApplicationContext
    {
        private static Aplicação aplicação;
        
        private System.Globalization.CultureInfo cultura;
        private Acesso.Comum.Usuários usuários;
        private BaseFormulário formulário;
        private Splash splash = null;
        private bool requisitarNovaSenha = false;
#if SERVIÇO_IMPRESSÃO
        private Apresentação.Impressão.Servidor.Serviço serviçoImpressão;
#endif

        public bool RequisitarNovaSenha
        {
            get { return requisitarNovaSenha; }
            set { requisitarNovaSenha = value; }
        }

        public System.Globalization.CultureInfo Cultura
        {
            get { return cultura; }
        }

        public Acesso.Comum.Usuários Usuários
        {
            get { return usuários; }
            set { usuários = value; }
        }
           
        internal BaseFormulário Formulário
        {
            get { return formulário; }
        }

        /// <param name="tipoFormulário">Formulário base, que herda de Apresentação.Formulários.BaseFormulário</param>
        public Aplicação(Type tipoFormulário, Usuários usuários, bool efetuarLogin, Splash splash)
        {
#if !DEBUG
			try
#endif
            {
                this.splash = splash;

                // Validar formulário
                if (typeof(BaseFormulário).IsInstanceOfType(tipoFormulário))
                    throw new Exception("A aplicação requer um formulário do tipo Apresentação.Formulários.BaseFormulário");

                try
                {
                    Application.EnableVisualStyles();
                }
                catch (Exception erro)
                {
                    if (splash != null)
                    {
                        splash.Mensagem = "Erro ao ligar efeitos visuais!";
                        System.Threading.Thread.Sleep(2000);
                        splash.Mensagem = erro.Message;
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                        MessageBox.Show("Erro ao ligar efeitos visuais!");
                }

                this.usuários = usuários;

                cultura = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR");

                if (splash != null)
                    splash.Mensagem = "Conectando ao banco de dados ... ";

                Usuários.AoRegistrarErro += new Usuários.ErroUsuárioHandler(AoRegistrarErro);

#if DEBUG 
                Console.WriteLine("Efetuando conexão!");

                Usuários.AoCriarConexão += new Usuários.UsuárioHandler(AoCriarConexão);
#endif

                Application.DoEvents();

                if (efetuarLogin)
                {
                    bool cancelouLogin = !Login.EfetuarLogin(usuários, splash);

                    if (cancelouLogin)
                        throw new LoginNãoEfetuado();

                    if (Acesso.Comum.Usuários.UsuárioAtual == null)
                        throw new LoginOuSenhaIncorretos();

                    if (Entidades.Pessoa.Funcionário.FuncionárioAtual == null)
                        throw new LoginNãoAssociadoAFuncionário();
                }
                else
                    Usuários.UsuárioAtual = usuários.EfetuarLogin("imjoias", "***REMOVED***");
            }
#if !DEBUG
			catch (LoginNãoEfetuado e)
			{
				/* Este erro só ocorre quando a versão é DEBUG.
				 * Em versão RELEASE, este erro implica em
				 * finalização do programa sem mostrar 
				 * qualquer mensagem.
				 */
				throw e;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Indústria Mineira de Jóias",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				throw new Exception("Não foi possível carregar o sistema.", e);
			}
#endif
            if (splash != null)
                splash.Mensagem = "Carregando controles gráficos ...";


#if DEBUG
            Console.WriteLine("Construindo janela principal!");
#endif

            try
            {
                formulário = (BaseFormulário) tipoFormulário.Assembly.CreateInstance(tipoFormulário.FullName);
                this.MainForm = formulário;
            }
            catch (Exception e)
            {
#if DEBUG
                MessageBox.Show("Ocorreu uma exceção não tratada e não depurável durante a criação do formulário:\n\n" + e.ToString());
                Application.Exit();
#else
					throw new Exception("Não foi possível construir janela principal!", e);
#endif
            }

#if SERVIÇO_IMPRESSÃO
            try
            {
                if (splash != null)
                    splash.Mensagem = "Preparando serviço de impressão remota...";

                Thread thread = new Thread(new ThreadStart(PrepararServiçoImpressão));
                thread.IsBackground = true;
                thread.Start();
            }
            catch { }
#endif
        }

#if SERVIÇO_IMPRESSÃO
        private void PrepararServiçoImpressão()
        {
            try
            {
                serviçoImpressão = new Apresentação.Impressão.Servidor.Serviço();
            }
            catch { }
        }
#endif

        /// <summary>
        /// Ocorre quando um erro é registrado por um usuário.
        /// </summary>
        /// <param name="usuário">Usuário que registrou o erro.</param>
        /// <param name="e">Exceção levantada pelo usuário.</param>
        void AoRegistrarErro(Acesso.Comum.Usuário usuário, Exception e)
        {
#if DEBUG
            Notificação.Mostrar(e.Message, e.ToString());
#else
            Notificação.Mostrar("Um relatório de erro foi registrado.", e.Message);
#endif
        }

#if DEBUG
        private void AoCriarConexão(Acesso.Comum.Usuário usuário)
        {
            //if (usuário.GerenciadorConexões != null)
            //    Notificação.Mostrar("Nova conexão", "O usuário " + usuário.Nome + " criou uma nova conexão.\n\nTotal: " + usuário.GerenciadorConexões.TotalConexões.ToString());
        }
#endif

        /// <summary>
        /// Dispara o método ao carregar do formulário.
        /// </summary>
        private void DispararAoCarregar()
        {
            if (splash != null)
            {
                splash.Show();
                //splash.Mensagem = "Carregando controles...";
                splash.Update();
            }

            //GC.Collect();

            

            Formulário.DispararAoCarregar(splash);

            //GC.Collect();

            if (splash != null)
            {
                splash.Close();
                splash.Dispose();
                splash = null;
                //GC.Collect();
            }
        }

        /// <summary>
        /// Ocorre ao sair da thread
        /// </summary>
        protected override void ExitThreadCore()
        {
            // Libera recursos do formulário
            if (formulário != null)
                formulário.Dispose();

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            /* Efetua logoff
             * 
             * -- Tomar cuidado para não efetuar logoff
             * antes de liberar recursos, como o formulário,
             * que dependam da conexão.
             */
            usuários.EfetuarLogoff(Acesso.Comum.Usuários.UsuárioAtual);

            base.ExitThreadCore();
        }

        public static void Executar(Usuários usuários)
        {
            Executar(typeof(BaseFormulário), usuários);
        }

        /// <summary>
        /// Executa uma aplicação.
        /// </summary>
        /// <param name="tipoFormulário">Formulário principal que herda de Apresentação.Formulários.BaseFormulário</param>
        /// <param name="fachada">Nome da faixada</param>
        /// <param name="efetuarLogin">Pedir que usuário efetua login no banco de dados</param>
        public static void Executar(Type tipoFormulário, Usuários usuários, bool efetuarLogin, bool mostrarSplash)
        {
#if DEBUG
            Console.WriteLine("========================================================");
            Console.WriteLine("Executando aplicação...");
#endif

            try
            {
                Application.SetCompatibleTextRenderingDefault(false);
                Application.EnableVisualStyles();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);
            }
            catch { }

            
#if !DEBUG
			try
#endif
            {
                Splash splash;

                // Mostra splash screen
                if (mostrarSplash)
                {
                    splash = new Splash();
                    splash.Show();
                    splash.Update();

#if DEBUG
                    Console.WriteLine("Splash exibido!");
#endif
                }
                else
                    splash = null;

                try
                {
                    aplicação = new Aplicação(tipoFormulário, usuários, efetuarLogin, splash);
                }
                catch (LoginNãoAssociadoAFuncionário)
                {
                    MessageBox.Show("O login não está associado a um funcionário", "Login não pode ser feito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                catch (LoginOuSenhaIncorretos)
                {
                    MessageBox.Show("Login e/ou senha incorretos. ", "Login não pode ser feito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

#if DEBUG
                Console.WriteLine("Disparando ao carregar!");
#endif
                aplicação.DispararAoCarregar();

                splash = null;


#if DEBUG
                Console.WriteLine("Aplicação pronta!");
                Console.WriteLine("========================================================");
#endif

                
                
                 
                 Application.Run(aplicação);

#if SERVIÇO_IMPRESSÃO
                try
                {
                    aplicação.serviçoImpressão.Dispose();
                }
                catch { }
#endif

                GC.Collect();
            }
#if !DEBUG
			catch (LoginNãoEfetuado)
			{
				// Nada aqui
			}
			catch (Exception e)
			{
				try
				{
					Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);

					MessageBox.Show("Ocorreu um erro e o programa será finalizado. Um relatório de erros foi gerado e enviado ao servidor.\n\nMensagem de erro: " + e.Message, "Falha no sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception e2)
				{
					MessageBox.Show("Ocorreu o seguinte erro no sistema e o programa será finalizado: " + e.ToString(), "Falha no sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
					MessageBox.Show("Não foi possível enviar relatório para os programadores devido ao seguinte problema: " + e2.ToString(), "Falha no sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
#endif
        }

        static void ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e.Exception);
            }
            catch (Exception e2)
            {
                MessageBox.Show("Ocorreu o seguinte erro no sistema: " + e.Exception.ToString(), "Falha no sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Não foi possível enviar relatório para os programadores devido ao seguinte problema: " + e2.ToString(), "Falha no sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Executa uma aplicação utilizando a fachada padrão, exigindo
        /// autenticação de usuário e mostrando tela de abertura.
        /// </summary>
        /// <param name="tipoFormulário">Formulário principal que herda de Apresentação.Formulários.BaseFormulário.</param>
        public static void Executar(Type tipoFormulário, Usuários usuários)
        {
            Executar(tipoFormulário, usuários, true, true);
        }

        /// <summary>
        /// Aplicação em execução
        /// </summary>
        public static Aplicação AplicaçãoAtual
        {
            get { return aplicação; }
        }

        /// <summary>
        /// Usuário atual.
        /// </summary>
        public Acesso.Comum.Usuário Usuário
        {
            get { return Acesso.Comum.Usuários.UsuárioAtual; }
        }

        private class LoginNãoEfetuado : Exception
        {
        }

        private class LoginOuSenhaIncorretos : LoginNãoEfetuado 
        {
        }

        private class LoginNãoAssociadoAFuncionário : LoginNãoEfetuado 
        {
        }
    }
}
