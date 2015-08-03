using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Estatística.Windows
{
    public sealed partial class GráficoLinhas : GráficoEmGrade
    {
        private new Entidades.Estatística.Gráficos.GráficoLinhas desenhista
        {
            get { return (Entidades.Estatística.Gráficos.GráficoLinhas) base.desenhista; }
            set { base.desenhista = value; }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoLinhas.padrãoTamanhoVértice)]
        public float VérticeTamanho
        {
            get { return desenhista.VérticeTamanho; }
            set { desenhista.VérticeTamanho = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoLinhas.padrãoMostrarVértice)]
        public bool MostrarVértices
        {
            get { return desenhista.MostrarVértice; }
            set { desenhista.MostrarVértice = value; }
        }

        public GráficoLinhas()
        {
            InitializeComponent();

            desenhista = new Entidades.Estatística.Gráficos.GráficoLinhas();
        }
    }
}
