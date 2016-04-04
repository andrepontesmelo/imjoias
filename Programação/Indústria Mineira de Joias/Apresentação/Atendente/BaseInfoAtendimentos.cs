using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades;

namespace Apresentação.Atendimento.Atendente
{
    public partial class BaseInfoAtendimentos : BaseInferior
    {
        private DateTime períodoInicial;
        private DateTime períodoFinal;

        public BaseInfoAtendimentos()
        {
            InitializeComponent();

            períodoFinal = DadosGlobais.Instância.HoraDataAtual;
            períodoInicial = períodoFinal.Date.Subtract(new TimeSpan(7, 0, 0, 0));

            AtualizarPeríodo();
        }

        private void AtualizarPeríodo()
        {
            títuloBaseInferior.Descrição =
                string.Format("Informações sobre atendimentos de {0:dd/MM/yyyy} a {1:dd/MM/yyyy}.",
                períodoInicial, períodoFinal);

            Recarregar();
        }

        private void opçãoRecarregar_Click(object sender, EventArgs e)
        {
            Recarregar();
        }

        private void opçãoAlterarPeríodo_Click(object sender, EventArgs e)
        {
            using (SeleçãoPeríodo dlg = new SeleçãoPeríodo(
                "Histórico de atendimentos",
                "Escolha o período para exibição do histórico de atendimentos.",
                períodoInicial, períodoInicial))
            {
                dlg.PeríodoInicialMínimo = DadosGlobais.Instância.HoraDataAtual.Subtract(new TimeSpan(60, 0, 0, 0));

                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    períodoInicial = dlg.PeríodoInicial;
                    períodoFinal = dlg.PeríodoFinal;
                    AtualizarPeríodo();
                }
            }
        }

        private void Recarregar()
        {
            AguardeDB.Mostrar();

            try
            {
                Visita[] visitas = Visita.ObterVisitas(períodoInicial, períodoFinal);

                listViewVisitantes.Limpar();
                listViewVisitantes.AdicionarVisitas(visitas);
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }
    }
}
