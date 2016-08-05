using Apresentação.Formulários;
using System;

namespace Programa.Integrador
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Aplicação.Executar(new Acesso.MySQL.MySQLUsuários(), true, new Splash());
            new Apresentação.IntegraçãoSistemaAntigo.ProcessoIntegração().ImportarDadosDoSistemaLegado();
        }
    }
}
