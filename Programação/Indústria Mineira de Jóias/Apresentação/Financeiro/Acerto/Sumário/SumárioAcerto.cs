using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Acerto.Sumário;
using Entidades.Acerto;

namespace Apresentação.Financeiro.Acerto
{
    public partial class SumárioAcerto : Quadro
    {
        private AcertoConsignado entidade;

        public SumárioAcerto()
        {
            InitializeComponent();
        }

        public void Carregar(AcertoConsignado entidade)
        {
            this.entidade = entidade;

            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            SumárioTotalAcerto simulação = new SumárioTotalAcerto(entidade);
            simulação.Obter();

            e.Result = simulação;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SumárioTotalAcerto sumário = (SumárioTotalAcerto)e.Result;

            SumárioTotalAcertoItemValores saídas = sumário.ObterValores(EnumTipoSumário.Saida);
            lblSaídasPeça.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Saida, false));
            lblSaídasPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Saida, true));
            lblSaídasTotal.Text = CriarTexto(saídas);

            SumárioTotalAcertoItemValores retorno = sumário.ObterValores(EnumTipoSumário.Retorno);
            lblRetornoPeça.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Retorno, false));
            lblRetornoPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Retorno, true));
            lblRetornoTotal.Text = CriarTexto(retorno);

            SumárioTotalAcertoItemValores vendas = sumário.ObterValores(EnumTipoSumário.Venda);
            lblVendaPeça.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Venda, false));
            lblVendaPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Venda, true));
            lblVendaTotal.Text = CriarTexto(vendas);

            SumárioTotalAcertoItemValores saldo = sumário.ObterSaldo(false).Soma(sumário.ObterSaldo(true));
            lblSaldoPeça.Text = CriarTexto(sumário.ObterSaldo(false));
            lblSaldoPeso.Text = CriarTexto(sumário.ObterSaldo(true));
            lblSaldoTotal.Text = CriarTexto(saldo);

            if (saídas.Indice > 0)
            {
                double porcentagemVendida = 100 * (vendas.Indice / saídas.Indice);
                lblVendaPorcento.Text = Math.Round(porcentagemVendida) + "%";

                double porcentagemRetornada = 100 * (retorno.Indice / saídas.Indice);
                lblRetornoPorcento.Text = Math.Round(porcentagemRetornada) + "%";

                double porcentagemSaldo = 100 * (saldo.Indice / saídas.Indice);
                lblSaldoPorcento.Text = Math.Round(porcentagemSaldo) + "%";
            } else
            {
                lblVendaPorcento.Text =
                    lblRetornoPorcento.Text =
                    lblSaldoPorcento.Text = "";
            }
        }

        private string CriarTexto(SumárioTotalAcertoItemValores saidaPeça)
        {
            return Math.Round(saidaPeça.Peso, 2).ToString() + "g - " + Math.Round(saidaPeça.Indice, 2);
        }
    }
}
