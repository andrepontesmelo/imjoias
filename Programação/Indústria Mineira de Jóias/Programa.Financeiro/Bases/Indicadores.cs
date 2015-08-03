using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Financeiro.Cota��o;

namespace Programa.Financeiro.Bases
{
    [Obsolete("Utilize Apresenta��o.Financeiro.Cota��o.BaseCota��es")]
    public partial class Indicadores : Apresenta��o.Formul�rios.BaseInferior
    {
        public Indicadores()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao clicar em registrar nova cota��o do ouro.
        /// </summary>
        private void op��oRegistrarOuro_Click(object sender, EventArgs e)
        {
            RegistrarCota��o dlg;

            dlg = new RegistrarCota��o();
            dlg.Cota��oRegistrada += new RegistrarCota��o.RegistrarCota��oDelegate(dlg_Cota��oRegistrada);
            dlg.ShowDialog(ParentForm);
            dlg.Cota��oRegistrada -= new RegistrarCota��o.RegistrarCota��oDelegate(dlg_Cota��oRegistrada);

        }

        private void dlg_Cota��oRegistrada(Entidades.Cota��o cota��o)
        {
            //gr�ficoCota��oOuro1.AdicionarCota��o(cota��o);
            //listaCota��oOuro1.AdicionarCota��o(cota��o);

            //gr�ficoCota��oOuro1.Recarregar();
            //listaCota��oOuro1.CarregarCota��es();
        }

        protected override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Construindo tela de cota��es";

            base.AoCarregarCompletamente(splash);
        }
    }
}

