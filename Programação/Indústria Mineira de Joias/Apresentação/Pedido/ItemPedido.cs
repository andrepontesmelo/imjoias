using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Configuração;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class ItemPedido : QuadroSimples
    {
        Entidades.PedidoConserto.Pedido pedido;

        public delegate void PedidoDelegate(ItemPedido sender, Entidades.PedidoConserto.Pedido pedido);
        public event PedidoDelegate AoClicar;

        public ItemPedido()
        {
            InitializeComponent();
        }

        public Entidades.PedidoConserto.Pedido Pedido
        {
            get { return pedido; }
        }


        public ItemPedido(Entidades.PedidoConserto.Pedido pedido) : this()
        {
            this.Visible = false;
            SuspendLayout();
            DateTime agora = DadosGlobais.Instância.HoraDataAtual;
            TimeSpan difPrevisão = pedido.DataPrevisão - agora;

            this.pedido = pedido;

            if (pedido.Cliente != null)
            {
                List<Entidades.Pessoa.Endereço.Endereço> endereços = pedido.Cliente.Endereços.ExtrairElementos();
                string endereço = endereços.Count > 0 ? endereços[0].Localidade != null ? endereços[0].Localidade.Nome + (endereços[0].Localidade.Estado != null ? " - " + endereços[0].Localidade.Estado.Sigla : "") : "" : "";
                lblCliente.Text = "#" + pedido.Cliente.Código.ToString() + " " + pedido.Cliente.Nome + " - " + endereço;
            }
            else
                lblCliente.Text = pedido.NomeDoCliente;

            lblCódigo.Text = pedido.Código.ToString();
            lblTipo.Text = pedido.TipoPedido.ToString();
            //lblControle.Text = pedido.Controle.HasValue ? pedido.Controle.ToString() : "N/D";

            if (pedido.Cliente != null)
            {
                if (pedido.Representante != null)
                {
                    lblRegião.Text = pedido.Cliente.Região != null ? pedido.Cliente.Região.Nome + " (" + pedido.Representante.PrimeiroNome + ")" : "";
                }
                else
                {
                    lblRegião.Text = pedido.Cliente.Região != null ? pedido.Cliente.Região.Nome : "";
                }
            }
            
            lblFuncionário.Text = pedido.Receptor.Nome;
            lblRecepção.Text = string.Format("{0:dd/MM/yyyy} {0:HH:mm}", pedido.DataRecepção);
            lblPrevisão.Text = string.Format("{0:dd/MM/yyyy}", pedido.DataPrevisão);
            lblConclusão.Text = pedido.DataConclusão.HasValue ? string.Format("{0:dd/MM/yyyy} {0:HH:mm}", pedido.DataConclusão.Value) : "N/D";
            lblEntrega.Text = pedido.DataEntrega.HasValue ? (string.Format("{0:dd/MM/yyyy} {0:HH:mm}", pedido.DataEntrega.Value) + " - " + (pedido.FuncionárioEntrega != null ? pedido.FuncionárioEntrega.PrimeiroNome : "" ) ) : "N/D";
            lblDescrição.Text = pedido.Observações;

            if (pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Conserto &&
                !pedido.DataOficina.HasValue)
            {
                this.Cor1 = Color.Red;
            }
            else
            {

                if (pedido.DataConclusão.HasValue)
                {
                    this.BackColor = this.Borda = this.Cor2 = Color.WhiteSmoke;
                    this.Cor1 = Color.Green;
                }
                else
                {
                    this.BackColor = this.Borda = this.Cor2 = Color.WhiteSmoke;
                    this.Cor1 = Color.Gold;
                }

                if (pedido.DataEntrega.HasValue)
                {
                    this.Cor1 = Color.Olive;
                    this.Cor2 = Color.Snow;
                    this.BackColor = Color.Olive;
                }
            }

            this.Visible = true;
            ResumeLayout();
        }

        private void ItemPedido_Click(object sender, EventArgs e)
        {
            AoClicar(this, pedido);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            JanelaImpressão janela = JanelaImpressão.Instância;
            janela.AdicionarPedidoNaFila(pedido);
            janela.Show();
        }

        internal void SelecionarViaTeclado()
        {
            this.Select();
            this.BackColor = SystemColors.ActiveCaption;
        }
    }
}
