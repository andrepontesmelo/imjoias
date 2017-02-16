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
            txtMínimoDemais.Text = Configurações.ValorMínimoAcumuladoDemaisPessoas.Valor.ToString();
            txtMínimoPEP.Text = Configurações.ValorMínimoAcumuladoPessoaExpostaPoliticamente.Valor.ToString();
       }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Configurações.QtdMeses.Valor = (int) txtMeses.Value;
            Configurações.ValorMínimoAcumuladoPessoaExpostaPoliticamente.Valor = (decimal) txtMínimoPEP.Double;
            Configurações.ValorMínimoAcumuladoDemaisPessoas.Valor = (decimal) txtMínimoDemais.Double;

            Close();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtMeses_ValueChanged(object sender, System.EventArgs e)
        {
            grupoPeríodo.Text = string.Format("Período: últimos {0} meses", txtMeses.Value);
        }

        private void btnRestaurarPadrão_Click(object sender, EventArgs e)
        {
            Configurações.RestaurarPadrão();
            Carregar();
        }
    }
}
