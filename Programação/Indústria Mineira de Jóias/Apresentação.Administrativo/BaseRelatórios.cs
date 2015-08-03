using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

[assembly: ExporBotão("Administrativo", true,
    typeof(Apresentação.Administrativo.BaseRelatórios))]

namespace Apresentação.Administrativo
{
    public partial class BaseRelatórios : Apresentação.Formulários.BaseInferior
    {
        public BaseRelatórios()
        {
            InitializeComponent();
        }

        private void quadroOpçãoBalanço_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                SubstituirBase(new Balanço.BaseBalanço());
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }
    }
}

