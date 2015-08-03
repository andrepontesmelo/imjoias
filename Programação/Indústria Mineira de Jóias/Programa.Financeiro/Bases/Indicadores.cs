using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Financeiro.Cotação;

namespace Programa.Financeiro.Bases
{
    [Obsolete("Utilize Apresentação.Financeiro.Cotação.BaseCotações")]
    public partial class Indicadores : Apresentação.Formulários.BaseInferior
    {
        public Indicadores()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao clicar em registrar nova cotação do ouro.
        /// </summary>
        private void opçãoRegistrarOuro_Click(object sender, EventArgs e)
        {
            RegistrarCotação dlg;

            dlg = new RegistrarCotação();
            dlg.CotaçãoRegistrada += new RegistrarCotação.RegistrarCotaçãoDelegate(dlg_CotaçãoRegistrada);
            dlg.ShowDialog(ParentForm);
            dlg.CotaçãoRegistrada -= new RegistrarCotação.RegistrarCotaçãoDelegate(dlg_CotaçãoRegistrada);

        }

        private void dlg_CotaçãoRegistrada(Entidades.Cotação cotação)
        {
            //gráficoCotaçãoOuro1.AdicionarCotação(cotação);
            //listaCotaçãoOuro1.AdicionarCotação(cotação);

            //gráficoCotaçãoOuro1.Recarregar();
            //listaCotaçãoOuro1.CarregarCotações();
        }

        protected override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Construindo tela de cotações";

            base.AoCarregarCompletamente(splash);
        }
    }
}

