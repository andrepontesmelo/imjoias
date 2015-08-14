using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Relacionamento.Venda;
using Entidades.Configuração;

namespace Entidades.Controle
{
    public static class Dívida
    {
        public class InfoVenda : DbManipulaçãoSimples, IDadosVenda
        {
#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'
            [DbColuna("codigo")]
            private long código;
            private DateTime data;
            private double valorFinal;
            internal double dívida;
            private double taxaJuros;
            private double cotação;

#pragma warning restore 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

            public long Código { get { return código; } }
            public double ValorFinal { get { return valorFinal; } }
            public DateTime Data { get { return data; } }
            public double Dívida { get { return dívida; } }
            public double TaxaJuros { get { return taxaJuros; } }
            public double Cotação { get { return cotação; } }

            #region IDadosVenda Members

            string IDadosVenda.NomeCliente
            {
                get { throw new NotSupportedException("The method or operation is not implemented."); }
            }

            string IDadosVenda.NomeVendedor
            {
                get { throw new NotSupportedException("The method or operation is not implemented."); }
            }

            double IDadosVenda.Valor
            {
                get { throw new NotSupportedException("The method or operation is not implemented."); }
            }

            uint? IDadosVenda.Controle
            {
                get { throw new NotSupportedException("The method or operation is not implemented."); }
            }

            //double IDadosVenda.Comissão
            //{
            //    get { throw new NotSupportedException("The method or operation is not implemented."); }
            //}

            //bool IDadosVenda.Acertado
            //{
            //    get { throw new NotSupportedException("The method or operation is not implemented."); }
            //}

            uint IDadosVenda.DiasSemJuros
            {
                get { throw new NotImplementedException(); }
            }

            #endregion

            public static explicit operator Venda(InfoVenda info)
            {
                return Venda.ObterVenda(info.código);
            }

            /// <summary>
            /// Obtém vendas não quitadas de um cliente.
            /// </summary>
            public static InfoVenda[] ObterVendasNãoQuitadas(Pessoa.Pessoa cliente, out double dívida)
            {
                InfoVenda[] vendas = Mapear<InfoVenda>(
                    string.Format(
                    "SELECT codigo, (valortotal - desconto) AS valorFinal, taxajuros AS taxaJuros FROM venda WHERE cliente = {0} AND quitacao IS NULL",
                    DbTransformar(cliente.Código))).ToArray();

                return Entidades.Controle.Dívida.VerificarQuitação(vendas, out dívida);
            }


            SemaforoEnum IDadosVenda.Semáforo
            {
                get { throw new NotImplementedException(); }
            }
        }

        /// <summary>
        /// Obtém vendas não quitadas de um cliente.
        /// </summary>
        public static InfoVenda[] ObterVendasNãoQuitadas(Pessoa.Pessoa cliente, out double dívida)
        {
            return InfoVenda.ObterVendasNãoQuitadas(cliente, out dívida);
        }

        /// <summary>
        /// Verifica quais vendas podem ser quitadas, quitando-as.
        /// </summary>
        /// <param name="vendas">Vendas a serem verificadas.</param>
        /// <returns>Vendas não quitadas.</returns>
        private static InfoVenda[] VerificarQuitação(InfoVenda[] vendas, out double dívidaTotal)
        {
            List<InfoVenda> pendências = new List<InfoVenda>();
            DateTime hoje = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual;

            dívidaTotal = 0;

            foreach (InfoVenda venda in vendas)
            {
                double dívida, juros;

                Pagamentos.IPagamento[] pagamentos;

                pagamentos = Pagamentos.PagamentoGenérico.ObterPagamentos(venda);

                CalcularDívida(
                    venda.ValorFinal,
                    venda.Data,
                    hoje,
                    pagamentos,
                    Venda.ObterPrestações(pagamentos, venda.Data),
                    venda.TaxaJuros,
                    out dívida, 
                    out juros);

                venda.dívida = dívida;

                if (dívida <= 0)
                {
                    Venda.Quitar(venda);
                }
                else
                {
                    pendências.Add(venda);
                    dívidaTotal += dívida;
                }
            }

            return pendências.ToArray();
        }

        /// <summary>
        /// Calcula a dívida desta venda.
        /// </summary>
        /// <param name="valorFinalVenda">Valor com desconto e débitos da venda.</param>
        /// <param name="dataVenda">Data da venda.</param>
        /// <param name="hoje">Voce quer saber a dívida em qual data? </param>
        /// <param name="pagamentos">Lista de pagamentos efetuados.</param>
        /// <param name="prestações">Formato das prestações, para cálculo de juros.</param>
        /// <param name="dívida">Valor da dívida a pagar.</param>
        /// <param name="totaljuros">Juros cobrados.</param>
        /// <param name="taxajuros">Taxa de juros da venda.</param>
        /// <exception cref="PagamentoAmbíguo">Existe um ou mais pagamentos para várias vendas.</exception>
        public static void CalcularDívida(double valorFinalVenda, DateTime dataVenda, DateTime hoje, Pagamentos.IPagamento[] pagamentos, string[] prestações, double taxajuros, out double dívida, out double totaljuros)
        {
            //DateTime hoje = DadosGlobais.Instância.HoraDataAtual.Date;
            //int iPagamento = 0;

            dívida = valorFinalVenda;
            totaljuros = 0;

            List<Pagamentos.IPagamento> listaPagamentos = new List<Entidades.Pagamentos.IPagamento>(pagamentos);

            double pagoLíquido = Entidades.Pagamentos.Pagamento.CalcularValorPagoLíquido(listaPagamentos, dataVenda, taxajuros);
            dívida -= pagoLíquido;
            totaljuros = Entidades.Pagamentos.Pagamento.CalcularJuros(listaPagamentos, dataVenda, taxajuros);


            /* A variável dívida até agora tem a mesma data da venda.
             * O Seguinte código desloca para o tempo de hoje. 
             */

            //if (dívida > 0)
            //{
            double juros;

            //if (pagamentos.Length > 0)
            //    juros = Preço.CalcularJuros(
            //        ((TimeSpan)(hoje - pagamentos[pagamentos.Length - 1].Vencimento.Date)).Days,
            //        dívida, taxajuros);
            //else
            juros = Preço.CalcularJuros(
                dataVenda.Date,
                hoje,
                //                        ((TimeSpan)(hoje - data.Date)).Days,
                dívida, taxajuros);

            totaljuros += juros;
            dívida += juros;
            //}
        }
    }
}
