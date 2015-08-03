using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Entidades.Configuração;
using Apresentação.Formulários;

namespace Programa.Recepção.Formulários.EntradaSaída
{
    public partial class VisualizarVisitas : Apresentação.Formulários.JanelaExplicativa
    {
        public VisualizarVisitas()
        {
            DateTime hoje = DadosGlobais.Instância.HoraDataAtual;
            Visita[] visitas;

            AguardeDB.Mostrar();

            try
            {
                InitializeComponent();

                visitas = Visita.ObterVisitas(hoje.Date.Subtract(new TimeSpan(3, 0, 0, 0)), DateTime.MaxValue);

                lst.AdicionarVisitas(visitas);
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

