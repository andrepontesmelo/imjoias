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
using Apresentação.Impressão.Relatórios.Pedido.PedidosParaFornecedores;


namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class BasePedidos : BaseInferior
    {
        private Entidades.PedidoConserto.Pedido últimoPedidoClicado = null;

        private Entidades.Pessoa.Pessoa cliente = null;
        private DateTime dataInício, dataFim;
        private enum TipoDataEnum { RegistradosNoPeríodo, PrevistosParaOPeríodo }
        private TipoDataEnum tipoData;
        private bool ocultandoPedidosJáEntregues = false;
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

            Recarregar();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();

            if (últimoPedidoClicado != null)
            {
                listaPedidos.AtualizarExibição(últimoPedidoClicado);
            }
        }

        private void Recarregar()
        {
            bool somenteHoje;

            opçãoImprimirResumo.Visible = optPedidos.Checked;

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

        }

        private void EscolherPeríodo()
        {
            using (SeleçãoPeríodo dlg = new SeleçãoPeríodo())
            {
                dlg.PeríodoFinalMáximo = DateTime.MaxValue;
                dlg.PeríodoInicialMínimo = DateTime.MinValue;

                dlg.AtribuirPeríodo(dataInício, dataFim);

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
            AguardeDB.Mostrar();
            bool imprimirConsertos;

            imprimirConsertos = !mostrarApenasPedidos;

            //using (Apresentação.Formulários.JanelaImpressão janela = new Apresentação.Formulários.JanelaImpressão())
            //{
            //    UseWaitCursor = true;
            //    AguardeDB.Mostrar();

                ControleImpressãoPedido controle = new ControleImpressãoPedido();
                Apresentação.Impressão.Relatórios.Pedido.Relatório relatório = new Apresentação.Impressão.Relatórios.Pedido.Relatório();
                List<Entidades.PedidoConserto.Pedido> pedidos = listaPedidos.ObterPedidos();

                controle.PrepararImpressão(relatório, pedidos, dataInício, dataFim, imprimirConsertos, optPrevisão.Checked);
            //    janela.InserirDocumento(relatório, "Impressão");
            //    janela.Título = "Impressão de pedidos/consertos";
            //    janela.Descrição = "";

            //    AguardeDB.Fechar();
            //    UseWaitCursor = false;

            //    janela.ShowDialog(this);
            //}


            PrintDialog printDialog = new PrintDialog();
            AguardeDB.Fechar();
            DialogResult resultado = printDialog.ShowDialog(this);

            if (resultado == DialogResult.OK)
            {
                try
                {
                    relatório.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                    relatório.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ocorreu um erro na impressão. A impressora está ligada? \n" + err.Message, "Erro na impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                }

            } 
        }

        private void opçãoNovo_Click(object sender, EventArgs e)
        {
            BaseEditarPedido novaBase;

            if (cliente != null)
                novaBase = new BaseEditarPedido(cliente);
            else
                novaBase = new BaseEditarPedido();

            if (optConsertos.Checked)
                novaBase.Tipo = Entidades.PedidoConserto.Pedido.Tipo.Conserto;
            else
                novaBase.Tipo = Entidades.PedidoConserto.Pedido.Tipo.Pedido;
            
            SubstituirBase(novaBase);
        }

        private void optRecepção_CheckedChanged(object sender, EventArgs e)
        {
            if (optRecepção.Checked)
            {
                tipoData = TipoDataEnum.RegistradosNoPeríodo;
                //Recarregar();
            }
        }

        private void optPrevisão_CheckedChanged(object sender, EventArgs e)
        {
            if (optPrevisão.Checked)
            {
                tipoData = TipoDataEnum.PrevistosParaOPeríodo;
                //Recarregar();
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

        private void opçãoLocalizar_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BasePedidosBusca());
        }

        void listaPedidos_AoDuploClique(Entidades.PedidoConserto.Pedido pedido)
        {
            últimoPedidoClicado = pedido;
            SubstituirBase(new BaseEditarPedido(pedido));
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            List<Entidades.PedidoConserto.Pedido> pedidos = listaPedidos.ItensSelecionados;

            if (pedidos.Count > 0)
            {
                if (MessageBox.Show("Deseja excluir " + pedidos.Count.ToString() + " itens ?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes)
                    return;
            }

            listaPedidos.Limpar();
            AguardeDB.Mostrar();
            foreach (Entidades.PedidoConserto.Pedido p in pedidos)
            {
                p.Descadastrar();
            }
            AguardeDB.Fechar();
            Recarregar();
        }

        private void optTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (optTodos.Checked)
            {
                dataFim = DateTime.MaxValue;
                dataInício = DateTime.MinValue;
                Recarregar();
            }
        }

        private void optPrevisão_Click(object sender, EventArgs e)
        {
            EscolherPeríodo();
        }

        private void optRecepção_Click(object sender, EventArgs e)
        {
            EscolherPeríodo();
        }

        private void opçãoImprimirResumo_Click(object sender, EventArgs e)
        {
            //using (Apresentação.Formulários.JanelaImpressão janela = new Apresentação.Formulários.JanelaImpressão())
            //{
            //    UseWaitCursor = true;
            AguardeDB.Mostrar();

            //ControleImpressãoPedidosParaFornecedores controle = new ControleImpressãoPedidosParaFornecedores();
            Apresentação.Impressão.Relatórios.Pedido.PedidosParaFornecedores.Relatório relatório
                 = new Apresentação.Impressão.Relatórios.Pedido.PedidosParaFornecedores.Relatório();

            List<Entidades.PedidoConserto.Pedido> pedidos = listaPedidos.ObterPedidos();

            ControleImpressãoPedidosParaFornecedores.PrepararImpressão(relatório, pedidos);
            //    janela.InserirDocumento(relatório, "Impressão");
            //    janela.Título = "Impressão de pedidos/consertos";
            //    janela.Descrição = "";

            //    AguardeDB.Fechar();
            //    UseWaitCursor = false;

            //    janela.ShowDialog(this);
            //}

            PrintDialog printDialog = new PrintDialog();
            AguardeDB.Fechar();
            DialogResult resultado = printDialog.ShowDialog(this);

            if (resultado == DialogResult.OK)
            {
                try
                {
                    AguardeDB.Mostrar();
                    relatório.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                    relatório.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ocorreu um erro na impressão. A impressora está ligada? \n" + err.Message, "Erro na impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }
    }
}
