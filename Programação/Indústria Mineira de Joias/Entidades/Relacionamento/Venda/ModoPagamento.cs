using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Configura��o;

namespace Entidades.Relacionamento.Venda
{
    public struct ModoPagamento
    {
        private string presta��es;
        private double juros;
        private double valorTotal;
        private double valorParcela;

        public string Presta��es
        { get { return presta��es; } }
        
        public double ValorTotal
        { get { return valorTotal; } }
        
        public double ValorParcela
        { get { return valorParcela; } }

        public double Juros
        { get { return juros; } }

        private ModoPagamento(string presta��es, double valor, double jurosAoM�s)
        {
            this.presta��es = presta��es;
            this.juros = Pre�o.CalcularJuros(presta��es, valor, jurosAoM�s);
            this.valorTotal = valor + juros;
            this.valorParcela = Math.Round(valorTotal / (double)Pre�o.ContarPresta��es(presta��es), 2);

            // Recalcular o juros cobrado e o valor total, devido ao arredondamento da parcela.
            this.valorTotal = this.valorParcela * Pre�o.ContarPresta��es(presta��es);
            this.juros = valorTotal - valor;
        }

        /// <summary>
        /// Consulta os dados globais pelos modos de pagamento padr�o
        /// E retorna os valores relativas a uma venda
        /// para impress�o de or�amento.
        /// </summary>
        public static List<ModoPagamento> ObterModosPagamento(Venda v)
        {
            List<ModoPagamento> lista = new List<ModoPagamento>();

            foreach (string forma in DadosGlobais.Inst�ncia.Parcelamento)
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
