using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Install;
using System.ServiceProcess;
using System.ComponentModel;

namespace Serviço.ServidorImpressão
{
    [RunInstaller(true)]
    public class Instalador : Installer
    {
        public Instalador()
        {
            ServiceProcessInstaller processo;
            ServiceInstaller instalador;

            processo = new ServiceProcessInstaller();
            processo.Account = ServiceAccount.LocalService;

            instalador = new ServiceInstaller();
            instalador.ServiceName = "IMJPrint";
            instalador.DisplayName = "Indústria Mineira de Jóias - Servidor de impressão";
            instalador.StartType = ServiceStartMode.Automatic;

            Installers.Add(processo);
            Installers.Add(instalador);
        }
    }
}
