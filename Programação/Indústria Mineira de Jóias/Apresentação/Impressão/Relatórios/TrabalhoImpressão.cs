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
using Apresentação.Impressão.Relatórios.Entrada;

namespace Apresentação.Impressão.Relatórios
{
    /// <summary>
    /// Controla a impressão de um documento.
    /// </summary>
    class TrabalhoImpressão : IDisposable
    {
        private ReportClass relatório;
        private DadosDocumento dados;

        /// <summary>
        /// Constrói um trabalho de impressão para saída, venda ou retorno.
        /// </summary>
        /// <param name="dados">Dados do documento.</param>
        /// <param name="impressora">Impressora a ser utilizada.</param>
        public TrabalhoImpressão(DadosDocumento dados, string impressora)
        {
            this.dados = dados;

#if DEBUG
            Console.WriteLine("Preparando trabalho!");
#endif
            switch (dados.Tipo)
            {
                case TipoDocumento.Saída:
                    PrepararSaída(dados);
                    break;

                case TipoDocumento.Retorno:
                    PrepararRetorno(dados);
                    break;

                case TipoDocumento.Venda:
                    PrepararVenda(dados);
                    break;

                case TipoDocumento.Acerto:
                    PrepararAcerto(dados);
                    break;
                
                case TipoDocumento.Entrada:
                    PrepararEntrada(dados);
                    break;

                default:
                    throw new NotSupportedException();
            }
            
            relatório.PrintOptions.PrinterName = impressora;
#if DEBUG
            Console.WriteLine("Trabalho preparado!");
#endif
        }

        private void PrepararSaída(DadosDocumento dados)
        {
            ControleImpressãoSaída controle = new ControleImpressãoSaída();
            Entidades.Relacionamento.Saída.Saída saída = Entidades.Relacionamento.Saída.Saída.ObterSaída(dados.Código);

            relatório = new Saída.Relatório();
            saída.Travado = true;

            controle.PrepararImpressão(relatório, saída);
        }

        private void PrepararEntrada(DadosDocumento dados)
        {
            ControleImpressãoEntrada controle = new ControleImpressãoEntrada();
            Entidades.Estoque.Entrada entrada = Entidades.Estoque.Entrada.Obter(dados.Código);

            relatório = new Estoque.Entrada.RelatorioEntrada();

            controle.PrepararImpressão(relatório, entrada);
        }


        private void PrepararRetorno(DadosDocumento dados)
        {
            ControleImpressãoRetorno controle = new ControleImpressãoRetorno();
            Entidades.Relacionamento.Retorno.Retorno retorno = Entidades.Relacionamento.Retorno.Retorno.ObterRetorno(dados.Código);

            relatório = new Retorno.Relatório();
            retorno.Travado = true;

            controle.PrepararImpressão(relatório, retorno);
        }

        private void PrepararVenda(DadosDocumento dados)
        {
            ControleImpressãoVenda controle = new ControleImpressãoVenda();
            Entidades.Relacionamento.Venda.Venda venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(dados.Código);

            relatório = new Venda.Relatório();
            venda.Travado = true;

            controle.PrepararImpressão(relatório, venda);
        }

        private void PrepararAcerto(DadosDocumento dados)
        {
            ControleImpressãoAcerto controle = new ControleImpressãoAcerto();
            Entidades.Acerto.ControleAcertoMercadorias acerto = new Entidades.Acerto.ControleAcertoMercadorias(AcertoConsignado.ObterAcerto(dados.Código));

            relatório = new Relatórios.Acerto.Relatório();

            controle.PrepararImpressão(relatório, acerto);
        }

//        /// <summary>
//        /// Constrói um trabalho de impressão de acerto.
//        /// </summary>
//        /// <param name="saídas">Saídas a serem consideradas.</param>
//        /// <param name="retornos">Retornos a serem considerados.</param>
//        /// <param name="vendas">Vendas a serem consideradas.</param>
//        /// <param name="impressora">Impressora a ser utilizada.</param>
//        public TrabalhoImpressão(AcertoConsignado acertoConsignado, string impressora)
//        {
//#if DEBUG
//            Console.WriteLine("Preparando trabalho!");
//#endif
//            Entidades.Acerto.ControleAcertoMercadorias acerto = new Entidades.Acerto.ControleAcertoMercadorias(acerto);

//            relatório = new Relatórios.Acerto.Relatório();
//            relatório.SetDataSource(acerto.ObterImpressão(true));
//            relatório.PrintOptions.PrinterName = impressora;
//            //relatório.Name = "Acerto - " + relacionamento.Pessoa.Nome;

//            this.dados = dados;
//#if DEBUG
//            Console.WriteLine("Trabalho preparado!");
//#endif
//        }

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
