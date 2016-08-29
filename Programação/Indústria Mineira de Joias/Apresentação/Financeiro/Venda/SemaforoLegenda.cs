using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Venda
{
    public partial class SemaforoLegenda : Quadro
    {
        public delegate void LegendaClicada(SemaforoEnum legenda);
        public event LegendaClicada ClicouNaLegenda;

        public SemaforoLegenda()
        {
            InitializeComponent();
        }

        private void opçãoVendaDia_Click(object sender, System.EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.DoDia);
        }

        private void opçãoNFe_Click(object sender, System.EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.Nfe);
        }

        private void opçãoCobrança_Click(object sender, System.EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.Cobrança);
        }

        private void opçãoNãoQuitada_Click(object sender, System.EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.NãoQuitado);
        }

        private void opçãoQuitadaAberta_Click(object sender, System.EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.Quitado);
        }

        private void opçãoComissãoFechada_Click(object sender, System.EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.ComissãoFechada);
        }
    }
}
