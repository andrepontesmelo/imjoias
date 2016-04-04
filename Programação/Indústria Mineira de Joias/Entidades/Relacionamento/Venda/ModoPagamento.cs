using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Configuração;

namespace Entidades.Relacionamento.Venda
{
    public struct ModoPagamento
    {
        private string prestações;
        private double juros;
        private double valorTotal;
        private double valorParcela;

        public string Prestações
        { get { return prestações; } }
        
        public double ValorTotal
        { get { return valorTotal; } }
        
        public double ValorParcela
        { get { return valorParcela; } }

        public double Juros
        { get { return juros; } }

        private ModoPagamento(string prestações, double valor, double jurosAoMês)
        {
            this.prestações = prestações;
            this.juros = Preço.CalcularJuros(prestações, valor, jurosAoMês);
            this.valorTotal = valor + juros;
            this.valorParcela = Math.Round(valorTotal / (double)Preço.ContarPrestações(prestações), 2);

            // Recalcular o juros cobrado e o valor total, devido ao arredondamento da parcela.
            this.valorTotal = this.valorParcela * Preço.ContarPrestações(prestações);
            this.juros = valorTotal - valor;
        }

        /// <summary>
        /// Consulta os dados globais pelos modos de pagamento padrão
        /// E retorna os valores relativas a uma venda
        /// para impressão de orçamento.
        /// </summary>
        public static List<ModoPagamento> ObterModosPagamento(Venda v)
        {
            List<ModoPagamento> lista = new List<ModoPagamento>();

            foreach (string forma in DadosGlobais.Instância.Parcelamento)
            {
                lista.Add(new ModoPagamento(
                    forma,
                    -v.Saldo,
                    v.TaxaJuros));
            }

            return lista;
        }
    }
}
