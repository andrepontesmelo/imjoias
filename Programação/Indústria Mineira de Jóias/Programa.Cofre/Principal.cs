using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Financeiro;
//using System.Collections.Generic;

namespace Programa.Cofre
{
	public static class Principal
	{
        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            Apresentação.Formulários.Aplicação.Executar(new Acesso.MySQL.MySQLUsuários());
        }
	}
}

