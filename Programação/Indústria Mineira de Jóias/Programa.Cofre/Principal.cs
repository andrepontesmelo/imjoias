using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Apresenta��o.Financeiro;
//using System.Collections.Generic;

namespace Programa.Cofre
{
	public static class Principal
	{
        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            Apresenta��o.Formul�rios.Aplica��o.Executar(new Acesso.MySQL.MySQLUsu�rios());
        }
	}
}

