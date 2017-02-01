using System;
using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;
using Entidades.Configuração;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Venda
{
    public partial class SemaforoLegenda : Quadro
    {
        public delegate void LegendaClicada(SemaforoEnum legenda);
        public event LegendaClicada ClicouNaLegenda;
        private Opção[] opções;
        private string[] descriçãoLegendas;

        private ConfiguraçãoUsuário<bool> mostrarNãoQuitada;
        private ConfiguraçãoUsuário<bool> mostrarCobrança;
        private ConfiguraçãoUsuário<bool> mostrarQuitadaAberta;
        private ConfiguraçãoUsuário<bool> mostrarComissãoFechada;
        private ConfiguraçãoUsuário<bool> mostrarVendaDia;
        private ConfiguraçãoUsuário<bool> mostrarNFe;

        public SemaforoLegenda()
        {
            InitializeComponent();
            opções = new Opção[6] { opçãoNãoQuitada, opçãoCobrança, opçãoQuitadaAberta, opçãoComissãoFechada, opçãoVendaDia, opçãoNFe };
            descriçãoLegendas = new string[6] { "Não quitada", "Cobrança", "Quitada; c. aberta", "Comissão fechada", "Venda do dia", "Nota fiscal" };

            CarregarConfigurações();
            CarregarMarcações();
        }

        private void CarregarConfigurações()
        {
            mostrarNãoQuitada = new ConfiguraçãoUsuário<bool>("semáforo_mostrar_não_quitada", true);
            mostrarCobrança = new ConfiguraçãoUsuário<bool>("semáforo_mostrar_cobrança", true);
            mostrarQuitadaAberta = new ConfiguraçãoUsuário<bool>("semáforo_mostrar_quitada_aberta", true);
            mostrarComissãoFechada = new ConfiguraçãoUsuário<bool>("semáforo_mostrar_comissão_fechada", true);
            mostrarVendaDia = new ConfiguraçãoUsuário<bool>("semáforo_mostrar_venda_dia", true);
            mostrarNFe = new ConfiguraçãoUsuário<bool>("semáforo_mostrar_nfe", true);
        }

        private void CarregarMarcações()
        {
            CarregarMarcação(mostrarNãoQuitada, chkNãoQuitada);
            CarregarMarcação(mostrarCobrança, chkCobrança);
            CarregarMarcação(mostrarQuitadaAberta, chkQuitadaAberta);
            CarregarMarcação(mostrarComissãoFechada, chkComissãoFechada);
            CarregarMarcação(mostrarVendaDia, chkVendaDia);
            CarregarMarcação(mostrarNFe, chkNFe);
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

        private void PersistirMarcação(ConfiguraçãoUsuário<bool> configuração, CheckBox controle)
        {
            configuração.Valor = controle.Checked;
        }

        private void CarregarMarcação(ConfiguraçãoUsuário<bool> configuração, CheckBox controle)
        {
            controle.Checked = configuração.Valor;
        }

        private void chkVendaDia_CheckedChanged(object sender, EventArgs e)
        {
            PersistirMarcação(mostrarVendaDia, chkVendaDia);
        }

        private void chkNFe_CheckedChanged(object sender, EventArgs e)
        {
            PersistirMarcação(mostrarNFe, chkNFe);
        }

        private void chkCobrança_CheckedChanged(object sender, EventArgs e)
        {
            PersistirMarcação(mostrarCobrança, chkCobrança);
        }

        private void chkNãoQuitada_CheckedChanged(object sender, EventArgs e)
        {
            PersistirMarcação(mostrarNãoQuitada, chkNãoQuitada);
        }

        private void chkQuitadaAberta_CheckedChanged(object sender, EventArgs e)
        {
            PersistirMarcação(mostrarQuitadaAberta, chkQuitadaAberta);
        }

        private void chkComissãoFechada_CheckedChanged(object sender, EventArgs e)
        {
            PersistirMarcação(mostrarComissãoFechada, chkComissãoFechada);
        }
    }
}
