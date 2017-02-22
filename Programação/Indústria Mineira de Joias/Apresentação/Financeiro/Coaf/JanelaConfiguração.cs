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

        private void DefinirTrackbar(decimal valor, decimal máximo)
        {
            DefinirTrackbar((double)valor, (double)máximo);
        }

        private void DefinirTrackbar(double valor, double máximo)
        {
            if (máximo != 0)
                DefinirTrackbar(valor / máximo);
            else
                DefinirTrackbar(1);
        }

        private void DefinirTrackbar(double valorEntreZeroEUm)
        {
            if (valorEntreZeroEUm > 1)
                valorEntreZeroEUm = 1;

            if (valorEntreZeroEUm < 0)
                valorEntreZeroEUm = 0;

            trackBarVerificação.Value = (int)((double) trackBarVerificação.Maximum * valorEntreZeroEUm);
        }

        private void Carregar()
        {
            txtMeses.Value = Configurações.QtdMeses;
            txtNotificaçãoDemaisPessoas.Text = Configurações.LimiarNotificaçãoDemaisPessoas.Valor.ToString();
            txtNotificaçãoPEP.Text = Configurações.LimiarNotificaçãoPessoaExpostaPoliticamente.Valor.ToString();
            txtConferênciaDemaisPessoas.Text = Configurações.LimiarConferênciaDemaisPessoas.Valor.ToString();
            txtConferênciaPEP.Text = Configurações.LimiarConferênciaPessoaExpostaPoliticamente.Valor.ToString();

            DefinirTrackbar(Configurações.LimiarConferênciaDemaisPessoas.Valor,
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
            Configurações.RestaurarPadrão();
            Carregar();
        }

        private double CalcularValorProporcional(double valorMáximo, int decimais)
        {
            double multiplicador = (double) trackBarVerificação.Value / trackBarVerificação.Maximum;

            return (double) Math.Round(multiplicador * valorMáximo, decimais);
        }

        private void trackBarVerificação_Scroll(object sender, EventArgs e)
        {
            txtConferênciaDemaisPessoas.Double = CalcularValorProporcional(txtNotificaçãoDemaisPessoas.Double, 2);
            txtConferênciaPEP.Double = CalcularValorProporcional(txtNotificaçãoPEP.Double, 2);
        }

        private void txtConferênciaPEP_Validated(object sender, EventArgs e)
        {
            DefinirTrackbar(txtConferênciaPEP.Double, txtNotificaçãoPEP.Double);
        }

        private void txtConferênciaDemaisPessoas_Validated(object sender, EventArgs e)
        {
            DefinirTrackbar(txtConferênciaDemaisPessoas.Double, txtNotificaçãoDemaisPessoas.Double);
        }
    }
}
