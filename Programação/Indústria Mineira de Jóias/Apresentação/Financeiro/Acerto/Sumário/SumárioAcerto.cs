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
        private AcertoConsignado acerto;
        private Entidades.Pessoa.Pessoa pessoa;

        public SumárioAcerto()
        {
            InitializeComponent();

            AtualizarVisibilidades();
        }

        public void Carregar(AcertoConsignado acerto)
        {
            this.acerto = acerto;

            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }

        public void Carregar(Entidades.Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;

            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            SumárioTotalAcerto simulação = null;
            
            if (acerto != null)
                simulação = new SumárioTotalAcerto(acerto);

            if (pessoa != null)
                simulação = new SumárioTotalAcerto(pessoa);

            simulação.Obter();

            e.Result = simulação;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SumárioTotalAcerto sumário = (SumárioTotalAcerto)e.Result;

            SumárioTotalAcertoItemValores saídas = sumário.ObterValores(EnumTipoSumário.Saida);
            lblSaídasPeçaPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Saida, false), true);
            lblSaídasPesoPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Saida, true), true);
            lblSaídasTotalPeso.Text = CriarTexto(saídas, true);

            lblSaídasPeçaÍndice.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Saida, false), false);
            lblSaídasPesoÍndice.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Saida, true), false);
            lblSaídasTotalÍndice.Text = CriarTexto(saídas, false);

            SumárioTotalAcertoItemValores retorno = sumário.ObterValores(EnumTipoSumário.Retorno);
            lblRetornoPeçaPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Retorno, false), true);
            lblRetornoPesoPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Retorno, true), true);
            lblRetornoTotalPeso.Text = CriarTexto(retorno, true);

            lblRetornoPeçaÍndice.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Retorno, false), false);
            lblRetornoPesoÍndice.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Retorno, true), false);
            lblRetornoTotalÍndice.Text = CriarTexto(retorno, false);

            SumárioTotalAcertoItemValores vendas = sumário.ObterValores(EnumTipoSumário.Venda);
            lblVendaPeçaPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Venda, false), true);
            lblVendaPesoPeso.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Venda, true), true);
            lblVendaTotalPeso.Text = CriarTexto(vendas, true);

            lblVendaPeçaÍndice.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Venda, false), false);
            lblVendaPesoÍndice.Text = CriarTexto(sumário.ObterValores(EnumTipoSumário.Venda, true), false);
            lblVendaTotalÍndice.Text = CriarTexto(vendas, false);

            SumárioTotalAcertoItemValores saldo = sumário.ObterSaldo(false).Soma(sumário.ObterSaldo(true));
            lblSaldoPeçaPeso.Text = CriarTexto(sumário.ObterSaldo(false), true);
            lblSaldoPesoPeso.Text = CriarTexto(sumário.ObterSaldo(true), true);
            lblSaldoTotalPeso.Text = CriarTexto(saldo, true);

            lblSaldoPeçaÍndice.Text = CriarTexto(sumário.ObterSaldo(false), false);
            lblSaldoPesoÍndice.Text = CriarTexto(sumário.ObterSaldo(true), false);
            lblSaldoTotalÍndice.Text = CriarTexto(saldo, false);

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

        private string CriarTexto(SumárioTotalAcertoItemValores item, bool peso)
        {
            if (peso)
            {
                if (item.Peso == 0)
                    return "";

                return Entidades.Mercadoria.Mercadoria.FormatarPeso(Math.Round(item.Peso, 2), true);
            }
            else
            {
                // Índice
                if (item.Indice == 0)
                    return "";
                
                return Entidades.Mercadoria.Mercadoria.FormatarÍndice(Math.Round(item.Indice, 2));
            }
            
        }

        private void optPeso_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarVisibilidades();
        }

        private void AtualizarVisibilidades()
        {
            lblSaídasPeçaÍndice.Visible =
            lblSaídasPesoÍndice.Visible =
            lblSaídasTotalÍndice.Visible =
            lblRetornoPeçaÍndice.Visible =
            lblRetornoPesoÍndice.Visible =
            lblRetornoTotalÍndice.Visible =
            lblVendaPeçaÍndice.Visible =
            lblVendaPesoÍndice.Visible =
            lblVendaTotalÍndice.Visible =
            lblSaldoPeçaÍndice.Visible =
            lblSaldoPesoÍndice.Visible =
            lblSaldoTotalÍndice.Visible =
            optÍndice.Checked;

            lblSaídasPeçaPeso.Visible =
            lblSaídasPesoPeso.Visible =
            lblSaídasTotalPeso.Visible =
            lblRetornoPeçaPeso.Visible =
            lblRetornoPesoPeso.Visible =
            lblRetornoTotalPeso.Visible =
            lblVendaPeçaPeso.Visible =
            lblVendaPesoPeso.Visible =
            lblVendaTotalPeso.Visible =
            lblSaldoPeçaPeso.Visible =
            lblSaldoPesoPeso.Visible =
            lblSaldoTotalPeso.Visible =
            optPeso.Checked;
        }

    }
}
