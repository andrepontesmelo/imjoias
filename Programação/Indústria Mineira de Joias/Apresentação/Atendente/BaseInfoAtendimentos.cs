using Apresentação.Formulários;
using Entidades;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                períodoInicial, períodoFinal))
            {

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
                List<Visita> visitas = Visita.ObterVisitas(períodoInicial, períodoFinal);

                listViewVisitantes.Limpar();
                listViewVisitantes.AdicionarVisitas(visitas);
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void listViewVisitantes_AoDuploClique(Visita visita)
        {
            List<Entidades.Pessoa.Pessoa> lstPessoas = visita.Pessoas.ExtrairElementos();
            if (lstPessoas.Count == 0)
                return;

            SubstituirBase(new BaseAtendimento(lstPessoas[0]));
        }
    }
}
