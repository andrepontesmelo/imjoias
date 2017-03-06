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
            txtVerificaçãoDemaisPessoas.Text = Configurações.LimiarVerificaçãoDemaisPessoas.Valor.ToString();
            txtVerificaçãoPEP.Text = Configurações.LimiarVerificaçãoPessoaExpostaPoliticamente.Valor.ToString();

            trackBarVerificação.Definir(Configurações.LimiarVerificaçãoDemaisPessoas.Valor,
                Configurações.LimiarNotificaçãoDemaisPessoas.Valor);
       }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Configurações.QtdMeses.Valor = (int) txtMeses.Value;
            Configurações.LimiarNotificaçãoPessoaExpostaPoliticamente.Valor = (decimal) txtNotificaçãoPEP.Double;
            Configurações.LimiarNotificaçãoDemaisPessoas.Valor = (decimal) txtNotificaçãoDemaisPessoas.Double;
            Configurações.LimiarVerificaçãoPessoaExpostaPoliticamente.Valor = (decimal)txtVerificaçãoPEP.Double;
            Configurações.LimiarVerificaçãoDemaisPessoas.Valor = (decimal)txtVerificaçãoDemaisPessoas.Double;

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
            txtVerificaçãoDemaisPessoas.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS;
            txtVerificaçãoPEP.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_CONFERÊNCIA_PEP;
            txtNotificaçãoDemaisPessoas.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS;
            txtNotificaçãoPEP.Double = (double)ConfiguraçõesCoaf.PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP;
            txtMeses.Value = ConfiguraçõesCoaf.PADRÃO_QTD_MESES;

            AtualizarTrackbar();
        }

        private void AtualizarTrackbar()
        {
            trackBarVerificação.Definir(txtVerificaçãoPEP.Double, txtNotificaçãoPEP.Double);
        }

        private void trackBarVerificação_Scroll(object sender, EventArgs e)
        {
            txtVerificaçãoDemaisPessoas.Double = trackBarVerificação.CalcularValorProporcional(txtNotificaçãoDemaisPessoas.Double, 2);
            txtVerificaçãoPEP.Double = trackBarVerificação.CalcularValorProporcional(txtNotificaçãoPEP.Double, 2);
        }

        private void txtVerificaçãoPEP_Validated(object sender, EventArgs e)
        {
            AtualizarTrackbar();
        }

        private void txtVerificaçãoDemaisPessoas_Validated(object sender, EventArgs e)
        {
            trackBarVerificação.Definir(txtVerificaçãoDemaisPessoas.Double, txtNotificaçãoDemaisPessoas.Double);
        }
    }
}
