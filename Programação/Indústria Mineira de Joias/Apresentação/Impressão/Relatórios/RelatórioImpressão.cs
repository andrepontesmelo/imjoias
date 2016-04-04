using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using Entidades.Relacionamento;
using System.Drawing.Printing;
using Entidades.Acerto;
using Entidades.Pessoa;
using Apresentação.Impressão.Relatórios.Venda;
using Apresentação.Impressão.Relatórios.Saída;
using Apresentação.Impressão.Relatórios.Retorno;
using Apresentação.Impressão.Relatórios.Acerto;
using Apresentação.Impressão.Relatórios.Pedido;
using Apresentação.Impressão.Relatórios.Pessoa;
using Apresentação.Impressão.Relatórios.Mercadoria;

namespace Apresentação.Impressão.Relatórios
{
    /// <summary>
    /// Controla a impressão de um documento.
    /// </summary>
    class RelatórioImpressão : IDisposable
    {
        private ReportClass relatório;
        private DadosRelatório dados;

        /// <summary>
        /// Constrói um trabalho de impressão para saída, venda ou retorno.
        /// </summary>
        /// <param name="dados">Dados do documento.</param>
        /// <param name="impressora">Impressora a ser utilizada.</param>
        public RelatórioImpressão(DadosRelatório dados, string impressora)
        {
            this.dados = dados;

#if DEBUG
            Console.WriteLine("Preparando trabalho!");
#endif
            switch (dados.Tipo)
            {
                //case TipoDocumento.Pedido:
                //    PrepararPedido(dados);
                //    break;

                case TipoDocumento.Pessoa:
                    PrepararPessoa((DadosRelatórioPessoa) dados);
                    break;

                case TipoDocumento.Mercadoria:
                    PrepararMercadoria((DadosRelatórioMercadoria) dados);
                    break;

                default:
                    throw new NotSupportedException();
            }

            relatório.PrintOptions.PrinterName = impressora;
#if DEBUG
            Console.WriteLine("Trabalho preparado!");
#endif
        }

        //private void PrepararPedido(DadosRelatório dados) //, DateTime início, DateTime fim)
        //{
        //    ControleImpressãoPedido controle = new ControleImpressãoPedido();

        //    relatório = new Pedido.Relatório();
        //    Entidades.PedidoConserto.Pedido [] pedidos;

        //    pedidos = dados.ApenasConsertos ?
        //            Entidades.PedidoConserto.Pedido.ObterConsertosRecebidos(dados.PeríodoInicial, dados.PeríodoFinal, dados.PeríodoPrevisão, true)
        //            : Entidades.PedidoConserto.Pedido.ObterEncomendasRecebidas(dados.PeríodoInicial, dados.PeríodoFinal, dados.PeríodoPrevisão, true);

        //    controle.PrepararImpressão(relatório, pedidos, dados.PeríodoInicial, dados.PeríodoFinal, dados.ApenasConsertos, dados.PeríodoPrevisão);
        //}

        private void PrepararPessoa(DadosRelatórioPessoa dados) 
        {
            ControleImpressãoPessoa controle = new ControleImpressãoPessoa();

            relatório = new Pessoa.RelatórioPessoa();
            List<Entidades.Pessoa.Impressão.PessoaImpressão> pessoas = Entidades.Pessoa.Impressão.PessoaImpressão.ObterPessoas(dados.Ordem, dados.Região);

            controle.PrepararImpressão(relatório, pessoas, dados.Região);
        }

        private void PrepararMercadoria(DadosRelatórioMercadoria dados)
        {
            ControleImpressãoMercadoria controle = new ControleImpressãoMercadoria();

            relatório = new Mercadoria.Relatório();
            List<Entidades.Mercadoria.MercadoriaImpressão> mercadorias = Entidades.Mercadoria.MercadoriaImpressão.ObterMercadorias(dados.Tabela);

            controle.PrepararImpressão(relatório, mercadorias);
        }


        public void Imprimir()
        {
#if DEBUG
            Console.WriteLine("Imprimindo trabalho!");
#endif
            relatório.PrintToPrinter(dados.Cópias > 0 ? dados.Cópias : 1, dados.Collated, dados.PágInicial, dados.PágFinal);
#if DEBUG
            Console.WriteLine("Impresso!");
#endif
        }

        public void Dispose()
        {
            relatório.Dispose();
        }
    }
}
