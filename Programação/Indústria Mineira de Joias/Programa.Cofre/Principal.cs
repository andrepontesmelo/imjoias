using Apresenta��o.Formul�rios;
using System;

namespace Programa.Cofre
{
    public static class Principal
	{
        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            Aplica��o.Executar(new Acesso.MySQL.MySQLUsu�rios());
        }
	}
}


