using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;
using System;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Venda.Semáforo
{
    public partial class SemaforoLegenda : Quadro
    {
        public delegate void LegendaClicada(SemaforoEnum legenda);
        public event LegendaClicada ClicouNaLegenda;
        private Opção[] opções;
        private string[] descriçãoLegendas;
        private ConfiguraçãoMarcaçãoSemáforo configuração;

        public SemaforoLegenda()
        {
            InitializeComponent();
            opções = new Opção[6] { opçãoNãoQuitada, opçãoCobrança, opçãoQuitadaAberta, opçãoComissãoFechada, opçãoVendaDia, opçãoNFe };
            descriçãoLegendas = new string[6] { "Não quitada", "Cobrança", "Quitada; c. aberta", "Comissão fechada", "Venda do dia", "Nota fiscal" };

            configuração = new ConfiguraçãoMarcaçãoSemáforo(new CheckBox[6] { chkNãoQuitada, chkCobrança, chkQuitadaAberta, chkComissãoFechada, chkVendaDia, chkNFe });
        }

        
        private void opçãoVendaDia_Click(object sender, EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.DoDia);
        }

        private void opçãoNFe_Click(object sender, EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.Nfe);
        }

        private void opçãoCobrança_Click(object sender, EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.Cobrança);
        }

        private void opçãoNãoQuitada_Click(object sender, EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.NãoQuitado);
        }

        private void opçãoQuitadaAberta_Click(object sender, EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.Quitado);
        }

        private void opçãoComissãoFechada_Click(object sender, EventArgs e)
        {
            ClicouNaLegenda?.Invoke(SemaforoEnum.ComissãoFechada);
        }

        internal void AtualizarContagemLegendas(int[] legendas)
        {
            for (int x = 0; x < opções.Length; x++)
            {
                bool possuiVenda = legendas[x] > 0;

                opções[x].Enabled = possuiVenda;
                opções[x].Descrição = descriçãoLegendas[x] + 
                    (possuiVenda ?  string.Format(" ({0})", legendas[x], descriçãoLegendas[x]) : "");
            }
        }
    }
}
