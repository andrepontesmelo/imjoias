using Apresentação.Formulários;
using System;

namespace Programa.Cofre
{
    public static class Principal
	{
        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            Aplicação.Executar(new Acesso.MySQL.MySQLUsuários());
        }
	}
}


