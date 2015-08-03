using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;
using Entidades.Relacionamento;

namespace Apresentação.Financeiro.Acerto
{
    public partial class JanelaDesconto : Apresentação.Formulários.JanelaExplicativa
    {
        AcertoConsignado acerto;
        double desconto;


        public JanelaDesconto()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Carregar(AcertoConsignado acerto)
        {
            this.acerto = acerto;

            double totalÍndiceSaída;
            double totalÍndiceVendidoMenosDevolvido;
            double totalVendaPeça;
            double porcentagemObtida;
            double porcentagemDada;

            desconto = 
            acerto.CalcularDesconto(out totalÍndiceSaída,
                out totalÍndiceVendidoMenosDevolvido,
                out totalVendaPeça,
                out porcentagemObtida,
                out porcentagemDada);

            txtDesconto.Text = desconto.ToString("C");
            txtPorcentagemVendida.Text = porcentagemObtida.ToString() + " % ";
            txtÍndiceLevado.Text = totalÍndiceSaída.ToString();
            txtÍndiceVendido.Text = totalÍndiceVendidoMenosDevolvido.ToString();
            txtÍndiceVendidoPeça.Text = totalVendaPeça.ToString();
            txtPorcentagemDesconto.Text = (porcentagemDada * 100).ToString() + " %";
        }

        private void btnAtualizarDescontoVenda_Click(object sender, EventArgs e)
        {
            List<Entidades.Relacionamento.Venda.Venda> vendas =
                acerto.Vendas.ExtrairElementos();

            if (vendas.Count > 1)
                MessageBox.Show("Favor atribuir o desconto manualmente. Existem " + vendas.Count.ToString() + " vendas neste acerto. Não sei qual venda alterar.", "Mais de uma venda no acerto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (vendas.Count == 0)
                MessageBox.Show("Não existem vendas neste acerto. Favor verificar", "Processo cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Entidades.Relacionamento.Venda.Venda v = vendas[0];

                if (v.Travado)
                {
                    MessageBox.Show("Por favor, destrave a venda para permitir esta operação. ", "Venda travada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                v.Desconto = desconto;
                v.Atualizar();

                MessageBox.Show("O desconto da venda foi alterado para " + desconto.ToString("C"), "Pronto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
