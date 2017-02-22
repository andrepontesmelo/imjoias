using System;
using System.Windows.Forms;

namespace Apresentação.Formulário.Componente
{
    public partial class TrackBarProporcional : TrackBar
    {
        public TrackBarProporcional()
        {
            InitializeComponent();
        }

        public void Definir(decimal valor, decimal máximo)
        {
            Definir((double)valor, (double)máximo);
        }

        public void Definir(double valor, double máximo)
        {
            if (máximo != 0)
                Definir(valor / máximo);
            else
                Definir(1);
        }

        public void Definir(double valorEntreZeroEUm)
        {
            if (valorEntreZeroEUm > 1)
                valorEntreZeroEUm = 1;

            if (valorEntreZeroEUm < 0)
                valorEntreZeroEUm = 0;

            Value = (int)((double) Maximum * valorEntreZeroEUm);
        }

        public double CalcularValorProporcional(double valorMáximo, int decimais)
        {
            double multiplicador = (double) Value / Maximum;

            return (double) Math.Round(multiplicador * valorMáximo, decimais);
        }

    }
}
