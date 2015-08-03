using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using Apresentação.Impressão.Servidor;
using Acesso.Comum;
using Acesso.MySQL;

namespace Serviço.ServidorImpressão
{
    /// <summary>
    /// Controla o serviço de impressão do Windows.
    /// </summary>
    public class ServiçoWindows : ServiceBase
    {
        private Apresentação.Impressão.Servidor.Serviço serviço;
        private Usuário usuário;
        private MySQLUsuários usuários;

        public ServiçoWindows()
        {
            usuários = new Acesso.MySQL.MySQLUsuários();

            this.CanStop = true;
            this.ServiceName = "IMJPrint";
        }

        /// <summary>
        /// Disparado ao iniciar o serviço.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            usuário = usuários.EfetuarLogin("imjoias", "***REMOVED***");

            if (usuário == null)
                throw new ApplicationException("Não foi possível autenticar.");

            serviço = new Apresentação.Impressão.Servidor.Serviço();
        }

        /// <summary>
        /// Disparado ao terminar o serviço.
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();

            serviço.Dispose();
            serviço = null;

            usuário.Dispose();
            usuário = null;
        }

        static void Main()
        {
            ServiceBase.Run(new ServiçoWindows());
        }
    }
}
