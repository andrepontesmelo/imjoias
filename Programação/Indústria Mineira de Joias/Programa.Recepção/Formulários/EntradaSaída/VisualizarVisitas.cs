using Apresentação.Formulários;
using Entidades;
using Entidades.Configuração;
using System;
using System.Collections.Generic;

namespace Programa.Recepção.Formulários.EntradaSaída
{
    public partial class VisualizarVisitas : Apresentação.Formulários.JanelaExplicativa
    {
        public VisualizarVisitas()
        {
            DateTime hoje = DadosGlobais.Instância.HoraDataAtual;
            List<Visita> visitas;

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

