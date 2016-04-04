using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Estatística.Windows
{
    public sealed partial class GráficoBarras : GráficoEmGrade
    {
        private new Entidades.Estatística.Gráficos.GráficoBarras desenhista
        {
            get { return (Entidades.Estatística.Gráficos.GráficoBarras)base.desenhista; }
            set { base.desenhista = value; }
        }

        public GráficoBarras()
        {
            InitializeComponent();

            desenhista = new Entidades.Estatística.Gráficos.GráficoBarras();
        }
    }
}
