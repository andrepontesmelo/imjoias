using Entidades.Configuração;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal
{
    public partial class SeleçãoPeríodo : UserControl
    {
        public event EventHandler AoAlterar;

        public SeleçãoPeríodo()
        {
            InitializeComponent();
        }

        public DateTime? DataInicial => dataInicial.Value as DateTime?;
        public DateTime? DataFinal => dataFinal.Value as DateTime?;
        public bool DatasVálidas => DataInicial.HasValue && DataFinal.HasValue &&
            DataInicial.Value <= DataFinal.Value;

        public void AtribuirDataInicial(DateTime data)
        {
            dataInicial.Value = data;
        }

        public void AtribuirDataFinal(DateTime data)
        {
            dataFinal.Value = data;
        }

        public void AtribuirIntervaloDatasPadrão()
        {
            var agora = DadosGlobais.Instância.HoraDataAtual;

            AtribuirDataInicial(new DateTime(agora.Year, agora.Month, 1));
            AtribuirDataFinal(new DateTime(agora.Year, agora.Month, 1).AddMonths(1).AddDays(-1));
        }

        private void dataInicial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !DatasVálidas;
        }

        private void dataFinal_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !DatasVálidas;
        }

        private void dataInicial_Validated(object sender, EventArgs e)
        {
            AoAlterar?.Invoke(sender, e);
        }

        private void dataFinal_Validated(object sender, EventArgs e)
        {
            AoAlterar?.Invoke(sender, e);
        }
    }
}
