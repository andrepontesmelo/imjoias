using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Financeiro;

namespace Programa.Financeiro
{
    public static class Principal // : Apresenta��o.Usu�rio.InterForm.BaseFormul�rioUsu�rio
    {
//        public Principal()
//        {
//            InitializeComponent();

//            if (this.DesignMode) return;

//            bot�oAtendimento.Controlador = new Apresenta��o.Atendimento.Atendente.ControladorAtendimentoDin�mico();
//            //bot�oConsultaR�pida.Controlador = new ControladorBot�oConsultaR�pida();
//            //bot�oCota��o.AdicionarBaseInferior(new Bases.Indicadores());
//            bot�oCota��o.AdicionarBaseInferior(new Apresenta��o.Financeiro.Cota��o.BaseCota��es());
//            bot�oPend�ncias.AdicionarBaseInferior(new Apresenta��o.Financeiro.Pend�ncia.BasePend�ncias());
//            //bot�oMaisOp��es.AdicionarBaseInferior(new Apresenta��o.Financeiro.BaseOp��es());
//            ControladorBot�oConsultaR�pida controlador = new ControladorBot�oConsultaR�pida();
//            controlador.Formul�rioPai = this;
//            bot�oConsultaR�pida.Controlador = controlador;
//#if DEBUG
//            //SubstituirBase(new Bases.Faturamento(), this);
//#endif
//        }

        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            Apresenta��o.Formul�rios.Aplica��o.Executar(new Acesso.MySQL.MySQLUsu�rios());
        }
    }
}


