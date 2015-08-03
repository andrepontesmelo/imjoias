using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Financeiro;

namespace Programa.Financeiro
{
    public static class Principal // : Apresentação.Usuário.InterForm.BaseFormulárioUsuário
    {
//        public Principal()
//        {
//            InitializeComponent();

//            if (this.DesignMode) return;

//            botãoAtendimento.Controlador = new Apresentação.Atendimento.Atendente.ControladorAtendimentoDinâmico();
//            //botãoConsultaRápida.Controlador = new ControladorBotãoConsultaRápida();
//            //botãoCotação.AdicionarBaseInferior(new Bases.Indicadores());
//            botãoCotação.AdicionarBaseInferior(new Apresentação.Financeiro.Cotação.BaseCotações());
//            botãoPendências.AdicionarBaseInferior(new Apresentação.Financeiro.Pendência.BasePendências());
//            //botãoMaisOpções.AdicionarBaseInferior(new Apresentação.Financeiro.BaseOpções());
//            ControladorBotãoConsultaRápida controlador = new ControladorBotãoConsultaRápida();
//            controlador.FormulárioPai = this;
//            botãoConsultaRápida.Controlador = controlador;
//#if DEBUG
//            //SubstituirBase(new Bases.Faturamento(), this);
//#endif
//        }

        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            Apresentação.Formulários.Aplicação.Executar(new Acesso.MySQL.MySQLUsuários());
        }
    }
}


