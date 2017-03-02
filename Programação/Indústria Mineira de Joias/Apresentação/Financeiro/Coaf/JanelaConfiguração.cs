using Apresentação.Formulários;
using Entidades.Coaf;
using Entidades.Configuração;
using System;

namespace Apresentação.Financeiro.Coaf
{
    public partial class JanelaConfiguração : JanelaExplicativa
    {
        private ConfiguraçõesCoaf Configurações => ConfiguraçõesCoaf.Instância;

        public JanelaConfiguração()
        {
            InitializeComponent();

            if (DadosGlobais.ModoDesenho)
                return;

            Carregar();
        }

        private void Carregar()
        {
            txtMeses.Value = Configurações.QtdMeses;
            txtNotificaçãoDemaisPessoas.Text = Configurações.LimiarNotificaçãoDemaisPessoas.Valor.ToString();
            txtNotificaçãoPEP.Text = Configurações.LimiarNotificaçãoPessoaExpostaPoliticamente.Valor.ToString();
            txtConferênciaDemaisPessoas.Text = Configurações.LimiarConferênciaDemaisPessoas.Valor.ToString();
            txtConferênciaPEP.Text = Configurações.LimiarConferênciaPessoaExpostaPoliticamente.Valor.ToString();

            trackBarVerificação.Definir(Configurações.LimiarConferênciaDemaisPessoas.Valor,
                Configurações.LimiarNotificaçãoDemaisPessoas.Valor);
       }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Configurações.QtdMeses.Valor = (int) txtMeses.Value;
            Configurações.LimiarNotificaçãoPessoaExpostaPoliticamente.Valor = (decimal) txtNotificaçãoPEP.Double;
            Configurações.LimiarNotificaçãoDemaisPessoas.Valor = (decimal) txtNotificaçãoDemaisPessoas.Double;
            Configurações.LimiarConferênciaPessoaExpostaPoliticamente.Valor = (decimal)txtConferênciaPEP.Double;
            Configurações.LimiarConferênciaDemaisPessoas.Valor = (decimal)txtConferênciaDemaisPessoas.Double;

            Close();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtMeses_ValueChanged(object sender, System.EventArgs e)
        {
            grupoPeríodo.Text = string.Format("Apuração: últimos {0} meses", txtMeses.Value);
        }

        private void btnRestaurarPadrão_Click(object sender, EventArgs e)
        {
            txtConferênciaDemaisPessoas.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS;
            txtConferênciaPEP.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_CONFERÊNCIA_PEP;
            txtNotificaçãoDemaisPessoas.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS;
            txtNotificaçãoPEP.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP;
            txtMeses.Value = ConfiguraçõesCoaf.PADRÃO_QTD_MESES;

            AtualizarTrackbar();
        }

        private void AtualizarTrackbar()
        {
            trackBarVerificação.Definir(txtConferênciaPEP.Double, txtNotificaçãoPEP.Double);
        }

        private void trackBarVerificação_Scroll(object sender, EventArgs e)
        {
            txtConferênciaDemaisPessoas.Double = trackBarVerificação.CalcularValorProporcional(txtNotificaçãoDemaisPessoas.Double, 2);
            txtConferênciaPEP.Double = trackBarVerificação.CalcularValorProporcional(txtNotificaçãoPEP.Double, 2);
        }

        private void txtConferênciaPEP_Validated(object sender, EventArgs e)
        {
            AtualizarTrackbar();
        }

        private void txtConferênciaDemaisPessoas_Validated(object sender, EventArgs e)
        {
            trackBarVerificação.Definir(txtConferênciaDemaisPessoas.Double, txtNotificaçãoDemaisPessoas.Double);
        }
    }
}
