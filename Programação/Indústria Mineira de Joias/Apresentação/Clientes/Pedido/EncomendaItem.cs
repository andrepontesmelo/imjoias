using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Entidades.Mercadoria;
using Apresentação.Financeiro.Acerto;
using Apresentação.Mercadoria;
using Entidades.PedidoConserto;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class EncomendaItem : UserControl
    {
        private PedidoItem entidade;
        private bool carregando = false;

        public event EventHandler SolicitouExclusão;

        public EncomendaItem()
        {
            InitializeComponent();
        }

        public EncomendaItem(PedidoItem novo)
        {
            InitializeComponent();
            Item = novo;
        }

        public PedidoItem Item
        {
            set
            {
                carregando = true;
                entidade = value;

                txtQuantidade.Value = (decimal) value.Quantidade;
                txtMercadoria.Referência = value.ReferênciaFormatada;
                txtDescrição.Text = value.Descrição;

                MercadoriaFornecedor fornecedor = MercadoriaFornecedor.ObterFornecedor(value.ReferênciaNumérica);
                if (fornecedor != null)
                {
                    txtFornecedor.Txt.Text = fornecedor.Fornecedor.Nome;
                    txtReferênciaFornecedor.Text = fornecedor.ReferênciaFornecedor;
                }
                carregando = false;
            }
            get
            {
                return entidade;
            }
        }

        private void txtQuantidade_ValueChanged(object sender, EventArgs e)
        {
            if (!carregando)
            {
                entidade.Quantidade = (int)txtQuantidade.Value;
                Gravar();
            }
        }

        private void txtMercadoria_ReferênciaAlterada(object sender, EventArgs e)
        {
            if (!carregando)
            {
                AtualizarFornecedorApartirDaReferência(false);
            }
        }

        private void txtFornecedor_Leave(object sender, EventArgs e)
        {
            Entidades.Fornecedor fornecedorVálido = txtFornecedor.ObterFornecedor();

            if (fornecedorVálido != null)
            {
                MercadoriaFornecedor info = MercadoriaFornecedor.ObterFornecedor(txtMercadoria.Txt.Text);
                if (info != null)
                    txtReferênciaFornecedor.Text = info.ReferênciaFornecedor;
            } else if (txtFornecedor.Txt.Text.Trim().Length == 0)
            {
                txtReferênciaFornecedor.Text = "";
            }

            Gravar();
        }

        private void Gravar()
        {
            if (!carregando)
                entidade.Atualizar();
        }

        private void txtReferênciaFornecedor_Leave(object sender, EventArgs e)
        {
            Gravar();
        }

        private void txtDescrição_Leave(object sender, EventArgs e)
        {
            entidade.Descrição = txtDescrição.Text;
            Gravar();
        }

        private void EncomendaItem_MouseEnter(object sender, EventArgs e)
        {
            BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        private void EncomendaItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = System.Drawing.SystemColors.InactiveCaption;
        }

        private void panelExcluir_Click(object sender, EventArgs e)
        {
        }

        private void txtMercadoria_Leave(object sender, EventArgs e)
        {
            AtualizarFornecedorApartirDaReferência(true);
        }

        private void AtualizarFornecedorApartirDaReferência(bool gravar)
        {
            entidade.ReferênciaNumérica = 
                (txtMercadoria.ReferênciaNumérica.Length == 0 ? null : txtMercadoria.ReferênciaNumérica); 
            
            MercadoriaFornecedor info = MercadoriaFornecedor.ObterFornecedor(entidade.ReferênciaNumérica);

            if (info != null)
            {
                txtFornecedor.Txt.Text = info.Fornecedor.Nome;
                txtReferênciaFornecedor.Text = info.ReferênciaFornecedor;
            }
            else
            {
                txtFornecedor.Txt.Text = "";
                txtReferênciaFornecedor.Text = "";
            }

            if (gravar)
                Gravar();
        }

        private void btnRastrear_Click(object sender, EventArgs e)
        {
            Entidades.Mercadoria.Mercadoria m = txtMercadoria.Mercadoria;

            if (m != null)
            {
                RastrearMercadoria janela = new RastrearMercadoria(m);
                janela.Show();
            }
            else
            {
                MessageBox.Show("A referência " + txtMercadoria.Referência + " é não está cadastrada.", "Rastreamento cancelado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            if ((SolicitouExclusão != null) &&
                MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                SolicitouExclusão(this, null);
            }
        }
    }
}
