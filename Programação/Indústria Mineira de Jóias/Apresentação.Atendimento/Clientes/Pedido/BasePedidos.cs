using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Pedido;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Entidades.Configuração;

[assembly: ExporBotão(
    "Pedidos e Consertos",
    true, typeof(Apresentação.Atendimento.Clientes.Pedido.BasePedidos))]

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class BasePedidos : BaseInferior
    {
        private Entidades.Pessoa.Pessoa cliente = null;
        private DateTime dataInício, dataFim;
        private enum TipoDataEnum { RegistradosNoPeríodo, PrevistosParaOPeríodo }
        private TipoDataEnum tipoData;
        private bool ocultandoPedidosJáEntregues = true;
        private bool mostrarApenasPedidos = true;

        public BasePedidos()
        {
             InitializeComponent();
            tipoData = TipoDataEnum.RegistradosNoPeríodo;
        }

        public BasePedidos(Entidades.Pessoa.Pessoa cliente)
            : this()
        {
            this.cliente = cliente;
        }


        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();

            DateTime hoje = new DateTime(Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Year,
            Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Month,
            Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Day);

            dataInício = (cliente == null ? hoje : DateTime.MinValue);
            dataFim = hoje.AddDays(1);

//            Recarregar();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();
        }

        private void Recarregar()
        {
            bool somenteHoje;

            DateTime hoje = new DateTime(Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Year,
            Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Month,
            Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Day);

            somenteHoje = (dataInício.CompareTo(hoje) == 0 && dataFim.CompareTo(hoje.AddDays(1)) == 0);

            listaPedidos.Mostrar(cliente, dataInício, dataFim, tipoData == TipoDataEnum.PrevistosParaOPeríodo, ocultandoPedidosJáEntregues, mostrarApenasPedidos);
            títuloBaseInferior1.Descrição = "Listagem de " + (mostrarApenasPedidos ? "pedidos" : "consertos");
            
            if (cliente != null)
                títuloBaseInferior1.Título = cliente.Nome + " (" + cliente.Código.ToString() + ")";

            if (somenteHoje)
                títuloBaseInferior1.Descrição += (tipoData == TipoDataEnum.RegistradosNoPeríodo) ? "\nRegistrados hoje." : "\nPrevistos para hoje.";
            else
            {
                if (dataFim.Date.CompareTo(dataInício) == 0)
                {
                    títuloBaseInferior1.Descrição += (tipoData == TipoDataEnum.RegistradosNoPeríodo) ? "\nRegistrados em " : "\nPrevistos para ";
                    títuloBaseInferior1.Descrição += dataInício.ToLongDateString();
                }
                else
                {
                    títuloBaseInferior1.Descrição += (tipoData == TipoDataEnum.RegistradosNoPeríodo) ? "\nRegistrados de " : "\nPrevistos de ";
                    títuloBaseInferior1.Descrição += dataInício.ToLongDateString() + " para " + dataFim.ToLongDateString();
                }
            }
        }

        private void opçãoEscolherPeríodo_Click(object sender, EventArgs e)
        {
            using (SeleçãoPeríodo dlg = new SeleçãoPeríodo())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dataInício = dlg.PeríodoInicial;
                    dataFim = dlg.PeríodoFinal;
                    Recarregar();
                }
            }
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            //DateTime início, final;
            bool imprimirConsertos;

            //OpçõesImpressão opções = new OpçõesImpressão();
            //if (opções.ShowDialog(this) != DialogResult.OK)
            //    return;
            imprimirConsertos = !mostrarApenasPedidos;
                
            //if (listaPedidos.PeríodoInicial.HasValue)
            //{
            //    início = listaPedidos.PeríodoInicial.Value;
            //    final = listaPedidos.PeríodoFinal.Value;
            //}
            //else
            //{
            //    using (SeleçãoPeríodo dlg = new SeleçãoPeríodo("Impressão de pedidos", "Escolha o período para a data de recepção dos pedidos que serão escolhidos para impressão."))
            //    {
            //        dlg.PeríodoFinalMáximo = DadosGlobais.Instância.HoraDataAtual;

            //        if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
            //        {
            //            início = dlg.PeríodoInicial;
            //            final = dlg.PeríodoFinal;
            //        }
            //        else
            //            return;
            //    }
            //}

            using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento.Pedido))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                   {
                    DadosRelatório dados = new DadosRelatório(TipoDocumento.Pedido, dataInício, dataFim, imprimirConsertos, optPrevisão.Checked);
                    dados.Cópias = dlg.NúmeroCópias;

                    dlg.ControleImpressão.RequisitarImpressão(dlg.Impressora, dados);
                }
            }
        }

        private void opçãoNovo_Click(object sender, EventArgs e)
        {
            if (cliente != null)
                SubstituirBase(new BaseEditarPedido(cliente));
            else
                SubstituirBase(new BaseEditarPedido());
        }

        private void listaPedidos_AoClicar(ItemPedido sender, Entidades.Pedido pedido)
        {
            SubstituirBase(new BaseEditarPedido(pedido));
        }

        private void optRecepção_CheckedChanged(object sender, EventArgs e)
        {
            if (optRecepção.Checked)
            {
                tipoData = TipoDataEnum.RegistradosNoPeríodo;
                Recarregar();
            }
        }

        private void optPrevisão_CheckedChanged(object sender, EventArgs e)
        {
            if (optPrevisão.Checked)
            {
                tipoData = TipoDataEnum.PrevistosParaOPeríodo;
                Recarregar();
            }
        }

        private void opçãoMostraPedidosJaEntregues_Click(object sender, EventArgs e)
        {
            opçãoMostraPedidosJaEntregues.Visible = false;
            ocultandoPedidosJáEntregues = false;
            Recarregar();
            opçãoOcutarPedidosJaEntregues.Visible = true;
        }

        private void opçãoOcutarPedidosJaEntregues_Click(object sender, EventArgs e)
        {
            opçãoOcutarPedidosJaEntregues.Visible = false;
            ocultandoPedidosJáEntregues = true;
            Recarregar();
            opçãoMostraPedidosJaEntregues.Visible = true;
        }

        private void optPedidos_CheckedChanged(object sender, EventArgs e)
        {
            mostrarApenasPedidos = optPedidos.Checked;

            if (mostrarApenasPedidos)
                Recarregar();
        }

        private void optConsertos_CheckedChanged(object sender, EventArgs e)
        {
            mostrarApenasPedidos = optPedidos.Checked;

            if (!mostrarApenasPedidos)
                Recarregar();
        }
    }
}
