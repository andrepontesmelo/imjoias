using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;

[assembly: ExporBot�o("Administrativo", true,
    typeof(Apresenta��o.Administrativo.BaseRelat�rios))]

namespace Apresenta��o.Administrativo
{
    public partial class BaseRelat�rios : Apresenta��o.Formul�rios.BaseInferior
    {
        public BaseRelat�rios()
        {
            InitializeComponent();
        }

        private void quadroOp��oBalan�o_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                SubstituirBase(new Balan�o.BaseBalan�o());
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }
    }
}

