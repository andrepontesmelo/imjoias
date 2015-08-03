using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    public partial class BaseOpções : Apresentação.Formulários.BaseInferior
    {
        public BaseOpções()
        {
            InitializeComponent();
        }

        private void opção1_Click(object sender, EventArgs e)
        {
            //SubstituirBase(new Balanço.BaseBalanço());
        }

        private void opçãoCCusto_Click(object sender, EventArgs e)
        {
            SubstituirBase(new Apresentação.Mercadoria.Manutenção.ComponentesDeCusto.BaseListagem());
        }

        private void opçãoMercadorias_Click(object sender, EventArgs e)
        {
            SubstituirBase(new Apresentação.Mercadoria.Manutenção.BaseListagem());
        }

        public override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Construindo tela de opções auxiliares";

            base.AoCarregarCompletamente(splash);
        }

    }
}
